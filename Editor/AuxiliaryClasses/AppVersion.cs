#if UNITY_EDITOR
using UnityEditor;

namespace TinyBuilder
{
    public record AppVersion
    {
        private readonly string _value = PlayerSettings.bundleVersion;

        public string Value() => _value;

        public AppVersion Increment()
        {
            var version = new SemanticVersion(_value);

            int patch = version.Patch();
            patch++;

            PlayerSettings.bundleVersion = $"{version.Major()}.{version.Minor()}.{patch}";

            return new AppVersion();
        }
    }
}
#endif