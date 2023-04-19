using System;

namespace vibrance.GUI.common
{
    public class ResolutionModeWrapper
    {
        public ResolutionModeWrapper()
        {
        }

        public ResolutionModeWrapper(Devmode mode)
        {
            DmPelsWidth = mode.dmPelsWidth;
            DmPelsHeight = mode.dmPelsHeight;
            DmBitsPerPel = mode.dmBitsPerPel;
            DmDisplayFrequency = mode.dmDisplayFrequency;
            DmDisplayFixedOutput = mode.dmDisplayFixedOutput;
        }

        public uint DmPelsWidth { get; set; }
        public uint DmPelsHeight { get; set; }
        public uint DmBitsPerPel { get; set; }
        public uint DmDisplayFrequency { get; set; }
        public uint DmDisplayFixedOutput { get; set; }

        public override string ToString()
        {
            return string.Format("{0} x {1} @ {3} hz ({2} bit, {4})", DmPelsWidth, DmPelsHeight,
                DmBitsPerPel, DmDisplayFrequency, Enum.GetName(typeof(Dmdfo), DmDisplayFixedOutput));
        }

        public override bool Equals(object obj)
        {
            ResolutionModeWrapper that = null;

            //if the object is of type DEVMODE, it corresponding ResolutionModeWrapper 
            //will be determined and the second check will always pass
            if (obj is Devmode) that = new ResolutionModeWrapper((Devmode)obj);
            if (obj is ResolutionModeWrapper || that != null)
            {
                that = that == null ? obj as ResolutionModeWrapper : that;
                if (DmPelsWidth == that.DmPelsWidth &&
                    DmPelsHeight == that.DmPelsHeight &&
                    DmBitsPerPel == that.DmBitsPerPel &&
                    DmDisplayFrequency == that.DmDisplayFrequency &&
                    DmDisplayFixedOutput == that.DmDisplayFixedOutput)
                    return true;
            }

            return false;
        }

        protected bool Equals(ResolutionModeWrapper other)
        {
            return DmPelsWidth == other.DmPelsWidth && DmPelsHeight == other.DmPelsHeight && DmBitsPerPel == other.DmBitsPerPel && DmDisplayFrequency == other.DmDisplayFrequency &&
                   DmDisplayFixedOutput == other.DmDisplayFixedOutput;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (int)DmPelsWidth;
                hashCode = (hashCode * 397) ^ (int)DmPelsHeight;
                hashCode = (hashCode * 397) ^ (int)DmBitsPerPel;
                hashCode = (hashCode * 397) ^ (int)DmDisplayFrequency;
                hashCode = (hashCode * 397) ^ (int)DmDisplayFixedOutput;
                return hashCode;
            }
        }
    }
}
