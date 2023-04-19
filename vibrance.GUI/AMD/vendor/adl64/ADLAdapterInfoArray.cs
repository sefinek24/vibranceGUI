using System.Runtime.InteropServices;

namespace vibrance.GUI.AMD.vendor.adl64
{
    [StructLayout(LayoutKind.Sequential)]
    internal struct AdlAdapterInfoArray
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = Adl.AdlMaxAdapters)]
        internal AdlAdapterInfo[] ADLAdapterInfo;
    }
}
