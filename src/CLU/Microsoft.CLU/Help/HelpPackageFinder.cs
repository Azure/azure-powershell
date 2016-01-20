using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.CLU.Help
{
    internal class HelpPackageFinder : IHelpPackageFinder
    {
        public HelpPackageFinder(string packagePath)
        {
            this.PackagePath = packagePath;
        }

        public IEnumerable<CommandDispatchHelper.PkgInfo> FindPackages()
        {
            var rootInfo = new System.IO.DirectoryInfo(this.PackagePath);

            foreach (var pkgPath in rootInfo.EnumerateDirectories())
            {
                foreach (var versionPath in pkgPath.EnumerateDirectories())
                {
                    yield return new CommandDispatchHelper.PkgInfo(pkgPath.Name, versionPath.Name, pkgPath.FullName);
                }
            }
        }

        #region Private Properties

        private string PackagePath { get; set; }

        #endregion
    }
}
