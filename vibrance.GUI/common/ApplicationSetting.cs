using System.Xml.Serialization;

namespace vibrance.GUI.common
{
    public class ApplicationSetting
    {
        public ApplicationSetting()
        {
        }

        public ApplicationSetting(string name, string fileName, int ingameLevel, ResolutionModeWrapper resolutionSettings, bool isResolutionChangeNeeded)
        {
            Name = name;
            FileName = fileName;
            IngameLevel = ingameLevel;
            ResolutionSettings = resolutionSettings;
            IsResolutionChangeNeeded = isResolutionChangeNeeded;
        }

        public string Name { get; set; }
        public string FileName { get; set; }
        public int IngameLevel { get; set; }
        public bool IsResolutionChangeNeeded { get; set; }

        [XmlElement(IsNullable = true)] public ResolutionModeWrapper ResolutionSettings { get; set; }

        public override bool Equals(object obj)
        {
            // Check for null values and compare run-time types.
            if (obj == null || GetType() != obj.GetType())
                return false;

            var that = (ApplicationSetting)obj;
            return FileName.Equals(that.FileName);
        }

        public override int GetHashCode()
        {
            return FileName.GetHashCode();
        }
    }
}
