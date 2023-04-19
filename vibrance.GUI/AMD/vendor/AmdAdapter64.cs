using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using vibrance.GUI.AMD.vendor.adl64;

namespace vibrance.GUI.AMD.vendor
{
    public class AmdAdapter64 : IAmdAdapter
    {
        private List<Display> displays;
        private Disposer disposer;

        public void Init()
        {
            displays = new List<Display>();
            disposer = new Disposer();

            var numberOfAdapters = 0;

            Adl.AdlMainControlCreate(Adl.AdlMainMemoryAlloc, 1);

            if (Adl.AdlAdapterNumberOfAdaptersGet != null) _ = Adl.AdlAdapterNumberOfAdaptersGet(ref numberOfAdapters);
            Adl.AdlMainControlCreate(Adl.AdlMainMemoryAlloc, 1);

            if (numberOfAdapters <= 0) return;
            var osAdapterInfoData = new AdlAdapterInfoArray();

            if (Adl.AdlAdapterAdapterInfoGet == null) return;
            var size = Marshal.SizeOf(osAdapterInfoData);
            var adapterBuffer = Marshal.AllocCoTaskMem(size);
            Marshal.StructureToPtr(osAdapterInfoData, adapterBuffer, false);

            var adlRet = Adl.AdlAdapterAdapterInfoGet(adapterBuffer, size);
            if (adlRet == Adl.AdlSuccess)
            {
                osAdapterInfoData = (AdlAdapterInfoArray)Marshal.PtrToStructure(adapterBuffer, osAdapterInfoData.GetType());
                var isActive = 0;

                for (var i = 0; i < numberOfAdapters; i++)
                {
                    var adlAdapterInfo = osAdapterInfoData.ADLAdapterInfo[i];

                    var adapterIndex = adlAdapterInfo.AdapterIndex;

                    if (Adl.AdlAdapterActiveGet != null) adlRet = Adl.AdlAdapterActiveGet(adlAdapterInfo.AdapterIndex, ref isActive);

                    if (Adl.AdlSuccess != adlRet) continue;
                    var oneDisplayInfo = new AdlDisplayInfo();

                    if (Adl.AdlDisplayDisplayInfoGet == null) continue;
                    var numberOfDisplays = 0;
                    adlRet = Adl.AdlDisplayDisplayInfoGet(adlAdapterInfo.AdapterIndex, ref numberOfDisplays, out var displayBuffer, 1);
                    if (Adl.AdlSuccess == adlRet)
                    {
                        var displayInfoData = new List<AdlDisplayInfo>();
                        for (var j = 0; j < numberOfDisplays; j++)
                        {
                            oneDisplayInfo = (AdlDisplayInfo)Marshal.PtrToStructure(new IntPtr(displayBuffer.ToInt64() + j * Marshal.SizeOf(oneDisplayInfo)), oneDisplayInfo.GetType());
                            displayInfoData.Add(oneDisplayInfo);
                        }

                        for (var j = 0; j < numberOfDisplays; j++)
                        {
                            var adlDisplayInfo = displayInfoData[j];

                            if (adlDisplayInfo.DisplayID.DisplayLogicalAdapterIndex == -1) continue;

                            displays.Add(new Display
                            {
                                DisplayInfo = adlDisplayInfo,
                                AdapterInfo = adlAdapterInfo,
                                Index = adapterIndex
                            });
                        }
                    }

                    disposer.DisplayBufferList.Add(displayBuffer);
                }
            }

            disposer.AdapterBuffer = adapterBuffer;
        }

        public bool IsAvailable()
        {
            if (Adl.AdlMainControlCreate == null) return false;
            if (Adl.AdlSuccess != Adl.AdlMainControlCreate(Adl.AdlMainMemoryAlloc, 1)) return false;
            if (Adl.AdlMainControlDestroy != null) _ = Adl.AdlMainControlDestroy();

            return true;
        }

        public void SetSaturationOnAllDisplays(int vibranceLevel)
        {
            SetSaturationOnDisplay(vibranceLevel, null);
        }

        public void SetSaturationOnDisplay(int vibranceLevel, string displayName)
        {
            SetSaturation((adlDisplayInfo, adlAdapterInfo, adapterIndex) =>
            {
                var infoValue = adlDisplayInfo.DisplayID.DisplayLogicalIndex;
                var adapterIsAssociatedWithDisplay = adapterIndex == adlDisplayInfo.DisplayID.DisplayLogicalAdapterIndex;
                if (adapterIsAssociatedWithDisplay && (adlAdapterInfo.DisplayName == displayName || displayName == null))
                    Adl.AdlDisplayColorSet(
                        adapterIndex,
                        infoValue,
                        Adl.AdlDisplayColorSaturation,
                        vibranceLevel);
            });
        }

        public void Dispose()
        {
            disposer?.Dispose();
        }

        private void SetSaturation(Action<AdlDisplayInfo, AdlAdapterInfo, int> handle)
        {
            foreach (var display in displays) handle(display.DisplayInfo, display.AdapterInfo, display.Index);
        }

        private class Display
        {
            public AdlDisplayInfo DisplayInfo { get; set; }

            public AdlAdapterInfo AdapterInfo { get; set; }

            public int Index { get; set; }
        }

        private class Disposer : IDisposable
        {
            public Disposer()
            {
                DisplayBufferList = new List<IntPtr>();
            }

            public List<IntPtr> DisplayBufferList { get; }
            public IntPtr AdapterBuffer { get; set; }

            public void Dispose()
            {
                foreach (var intPtr in DisplayBufferList.Where(intPtr => intPtr != IntPtr.Zero))
                    Marshal.FreeCoTaskMem(intPtr);

                if (AdapterBuffer != IntPtr.Zero) Marshal.FreeCoTaskMem(AdapterBuffer);
                if (Adl.AdlMainControlDestroy != null) _ = Adl.AdlMainControlDestroy();
            }
        }
    }
}
