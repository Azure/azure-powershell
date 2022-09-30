using System;
using System.Linq;

namespace Tools.Common.Models
{
    public class AzurePSVersion : ICloneable, IComparable<AzurePSVersion>, IEquatable<AzurePSVersion>
    {
        public int Major { get; private set; }
        public int Minor { get; private set; }
        public int Patch { get; private set; }
        public string Label { get; set; }

        public bool IsPreview { get {
                return (Major == 0) || !string.IsNullOrEmpty(Label);
            } 
        }

        public AzurePSVersion(string version)
        {
            if(string.IsNullOrWhiteSpace(version))
            {
                throw new ArgumentNullException("Version string cannot be null or blank.");
            }

            var comps = version.Split('-').Select(c => c.Trim()).ToArray();
            var semanticVersion = version;
            if (comps.Length == 2)
            {
                if(string.IsNullOrWhiteSpace(comps[1]))
                {
                    throw new ArgumentException($"Label in version {version} cannot be empty.");
                }
                Label = comps[1];
                semanticVersion = comps[0];
            }
            else if(comps.Length ==0 || comps.Length > 2)
            {
                throw new ArgumentException($"The format of version {version} cannot have more than one dash character.");
            }

            if(string.IsNullOrWhiteSpace(semanticVersion))
            {
                throw new ArgumentException($"The format of version {version} doesn't have major version.");
            }

            comps = semanticVersion.Split('.').Select(c => c.Trim()).ToArray();

            if (comps.Length > 3)
            {
                throw new ArgumentException($"The format of version {version} doesn't follow pattern major.minor.patch .");
            }
            try
            {
                Major = int.Parse(comps[0]);
                Minor = (comps.Length > 1) ? int.Parse(comps[1]) : 0;
                Patch = (comps.Length > 2) ? int.Parse(comps[2]) : 0;
            }
            catch (FormatException)
            {
                throw new ArgumentException($"The format of version {version} doesn't follow pattern major.minor.patch .");
            }
        }

        public AzurePSVersion(int major, int minor, int patch, string label) : this(major, minor, patch)
        {
            this.Label = label;
        }

        public AzurePSVersion(int major, int minor, int patch)
        {
            this.Major = major;
            this.Minor = minor;
            this.Patch = patch;
        }

        public object Clone()
        {
            return new AzurePSVersion(Major, Minor, Patch, Label);
        }

        public int CompareTo(AzurePSVersion other)
        {
            if(other.Major != Major)
            {
                return Major.CompareTo(other.Major);
            }
            if (other.Minor != Minor)
            {
                return Minor.CompareTo(other.Minor);
            }
            if (other.Patch != Patch)
            {
                return Patch.CompareTo(other.Patch);
            }
            if(Label == null)
            {
                return (other.Label == null)? 0 : -1;
            }
            else
            {
                return (other.Label == null) ? 1 : Label.CompareTo(other.Label);
            }
        }

        public bool Equals(AzurePSVersion other)
        {
            if(other == null)
            {
                return false;
            }

            return (other.Major == Major && other.Minor == Minor && other.Patch == Patch && other.Label == Label);
        }
        public override bool Equals(object other)
        {
            if (this.GetType().Equals(other?.GetType()))
                return false;
            return Equals((AzurePSVersion)other);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            var semanticVersion = $"{Major}.{Minor}.{Patch}";
            return (string.IsNullOrEmpty(Label)) ? semanticVersion : $"{semanticVersion}-{Label}"; 
        }

        public static bool operator ==(AzurePSVersion v1, AzurePSVersion v2)
        {
            if(v1 is null)
            {
                return (v2 is null);
            }
            if(v2 is null)
            {
                return false;
            }
            return (v1.CompareTo(v2) == 0);
        }

        public static bool operator !=(AzurePSVersion v1, AzurePSVersion v2)
        {
            return !(v1 == v2);
        }

        public static bool operator >(AzurePSVersion v1, AzurePSVersion v2)
        {
            return (v1.CompareTo(v2) > 0);
        }

        public static bool operator <(AzurePSVersion v1, AzurePSVersion v2)
        {
            return (v1.CompareTo(v2) < 0);
        }

        public static bool operator >=(AzurePSVersion v1, AzurePSVersion v2)
        {
            return (v1.CompareTo(v2) >= 0);
        }

        public static bool operator <=(AzurePSVersion v1, AzurePSVersion v2)
        {
            return (v1.CompareTo(v2) <= 0);
        }
    }
}
