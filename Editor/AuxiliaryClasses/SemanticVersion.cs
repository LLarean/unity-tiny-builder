using System;

#if UNITY_EDITOR
namespace TinyBuilder
{
    /// <summary>
    /// https://semver.org/
    /// </summary>
    public class SemanticVersion
    {
        private readonly string _value;

        /// <summary>
        /// </summary>
        /// <param name="value">"1.2.3" - Major.Minor.Patch</param>
        public SemanticVersion(string value)
        {
            _value = value;
        }

        public int Major()
        {
            return GetNumber(GetSplitParts(), 0);
        }

        public int Minor()
        {
            return GetNumber(GetSplitParts(), 1);
        }

        public int Patch()
        {
            return GetNumber(GetSplitParts(), 2);
        }

        private string[] GetSplitParts()
        {
            string[] versionParts = _value.Split('.');

            if (versionParts.Length != 3)
            {
                throw new FormatException($"Incorrect version format: 3 parts expected, received {_value}");
            }

            return versionParts;
        }

        private int GetNumber(string[] versionParts, int index)
        {
            if (int.TryParse(versionParts[index], out var number) == false)
            {
                throw new FormatException($"The value of '{versionParts[index]}' is not a valid number");
            }

            return number;
        }
    }
}
#endif