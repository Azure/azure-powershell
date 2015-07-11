using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.WindowsAzure.Commands.Common.Extensions.DSC
{
    public static class DscExtensionCmdletConstants
    {
        public const int MinMajorPowerShellVersion = 4;
        public const string ZipFileExtension = ".zip";
        public const string Ps1FileExtension = ".ps1";
        public const string Psm1FileExtension = ".psm1";
        public const string DefaultContainerName = "windows-powershell-dsc";

        public static readonly HashSet<String> UploadArchiveAllowedFileExtensions =
            new HashSet<String>(StringComparer.OrdinalIgnoreCase) { Ps1FileExtension, Psm1FileExtension, ZipFileExtension };
        public static readonly HashSet<String> CreateArchiveAllowedFileExtensions =
            new HashSet<String>(StringComparer.OrdinalIgnoreCase) { Ps1FileExtension, Psm1FileExtension };
    }
}
