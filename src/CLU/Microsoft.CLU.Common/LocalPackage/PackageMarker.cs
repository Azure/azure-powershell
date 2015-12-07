using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace Microsoft.CLU.Common
{
    /// <summary>
    /// Type whose instance stores metadata details of a LocalPackage.
    /// </summary>
    internal class PackageMarker
    {
        /// <summary>
        /// Indicates whether the marker exists or not.
        /// </summary>
        public bool Exists
        {
            get
            {
                return File.Exists(_fullPath);
            }
        }

        /// <summary>
        /// Gets all referrers of the package.
        /// </summary>
        public IEnumerable<string> PackageReferrers
        {
            get
            {
                return Exists ?
                    File.ReadAllLines(_fullPath).Select(l => l.Trim()).Where(l => !string.IsNullOrEmpty(l)) :
                    new string[0];
            }
        }

        /// <summary>
        /// Creates an instance of the PackageMarker
        /// </summary>
        /// <param name="packageFullPath">The full path to the package</param>
        public PackageMarker(string packageFullPath)
        {
            Debug.Assert(!string.IsNullOrEmpty(packageFullPath));
            _fullPath = Path.Combine(packageFullPath, Common.Constants.PkgMarkerFileName);
        }

        /// <summary>
        /// Adds a package reference.
        /// </summary>
        /// <param name="referrer">The package referrer</param>
        public void AddPackageReference(string referrer)
        {
            var referrers = PackageReferrers.ToSet();
            referrers.Add(referrer);
            File.WriteAllLines(_fullPath, referrers);
        }

        /// <summary>
        /// Removes a package reference.
        /// </summary>
        /// <param name="referrer">The package referrer</param>
        public void RemovePackageReference(string referrer)
        {
            if (Exists)
            {
                var referrers = PackageReferrers.ToSet();
                referrers.Remove(referrer);
                if (referrers.Count == 0)
                {
                    File.Delete(_fullPath);
                }
                else
                {
                    File.WriteAllLines(_fullPath, referrers);
                }
            }
        }

        #region Private fields

        /// <summary>
        /// Absolute path to the package marker file.
        /// </summary>
        private string _fullPath;

        #endregion
    }
}
