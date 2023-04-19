using System;

namespace vibrance.GUI.AMD.vendor.adl32
{
    public class AdlCheckLibrary
    {
        private static readonly AdlCheckLibrary _adlCheckLibrary = new AdlCheckLibrary();
        private readonly IntPtr _adlLibrary = IntPtr.Zero;

        private AdlCheckLibrary()
        {
            try
            {
                if (1 == AdlImport.ADL_Main_Control_IsFunctionValid(IntPtr.Zero, "ADL_Main_Control_Create")) _adlLibrary = AdlImport.GetModuleHandle(AdlImport.AtiadlFileName);
            }
            catch (DllNotFoundException)
            {
            }
            catch (EntryPointNotFoundException)
            {
            }
            catch (Exception)
            {
            }
        }

        ~AdlCheckLibrary()
        {
            if (IntPtr.Zero != _adlCheckLibrary._adlLibrary) AdlImport.ADL_Main_Control_Destroy();
        }

        public static bool IsFunctionValid(string functionName)
        {
            var result = false;
            if (IntPtr.Zero != _adlCheckLibrary._adlLibrary)
                if (1 == AdlImport.ADL_Main_Control_IsFunctionValid(_adlCheckLibrary._adlLibrary, functionName))
                    result = true;
            return result;
        }

        public static IntPtr GetProcAddress(string functionName)
        {
            var result = IntPtr.Zero;
            if (IntPtr.Zero != _adlCheckLibrary._adlLibrary) result = AdlImport.ADL_Main_Control_GetProcAddress(_adlCheckLibrary._adlLibrary, functionName);
            return result;
        }
    }
}
