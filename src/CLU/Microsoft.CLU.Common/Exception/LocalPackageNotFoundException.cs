using Microsoft.CLU.Common.Properties;
using System;

namespace Microsoft.CLU.Common
{
    /// <summary>
    ///The exception that is thrown when an attempt to load a package that does not exist on pkgs directory.
    /// </summary>
    internal class LocalPackageNotFoundException : Exception
    {
        /// <summary>
        /// Creates LocalPackageNotFoundException.
        /// </summary>
        /// <param name="packageName">The package name</param>
        public LocalPackageNotFoundException(string packageName) : base(string.Format(Strings.LocalPackageNotFoundException_Ctor_Message, packageName))
        { }
    }
}
