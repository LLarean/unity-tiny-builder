#if UNITY_EDITOR
using UnityEngine;

namespace TinyBuilder
{
    public record Settings
    {
        private readonly BuildSettings _buildSettings;

        public Settings(BuildSettings buildSettings)
        {
            _buildSettings = buildSettings;
        }

        public string BuildFileName()
        {
            return _buildSettings.Prefix + _buildSettings.ProjectName + Application.version + _buildSettings.Postfix;
        }
    }
}
#endif