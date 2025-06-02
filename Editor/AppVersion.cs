using UnityEditor;

namespace TinyBuilder
{
    public record AppVersion
    {
        private readonly string _value;

        public AppVersion(string value)
        {
            _value = value;
        }

        public string Value() => _value;

        public AppVersion Increment()
        {
            string[] versionParts = _value.Split('.');

            if (versionParts.Length != 3)
            {
                PlayerSettings.bundleVersion = "0.0.1";
                return new AppVersion(PlayerSettings.bundleVersion);
            }

            int major = int.Parse(versionParts[0]);
            int minor = int.Parse(versionParts[1]);
            int patch = int.Parse(versionParts[2]);
            patch++;

            PlayerSettings.bundleVersion = $"{major}.{minor}.{patch}";

            return new AppVersion(PlayerSettings.bundleVersion);
        }
    }
}