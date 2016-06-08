using System;
using System.Collections.Generic;

namespace Microsoft.WindowsAzure.Commands.Common.Extensions.DSC
{
    public static class DscExtensionCmdletConstants
    {
        //common extension constants
        internal static readonly string ExtensionPublishedNamespace = "Microsoft.Powershell";
        internal static readonly string ExtensionPublishedName = "DSC";
        internal const string DefaultContainerName = "windows-powershell-dsc";

        internal const int MinMajorPowerShellVersion = 4;
        internal const string ZipFileExtension = ".zip";
        internal const string Ps1FileExtension = ".ps1";
        internal const string Psm1FileExtension = ".psm1";


        internal static readonly HashSet<String> UploadArchiveAllowedFileExtensions =
            new HashSet<String>(StringComparer.OrdinalIgnoreCase) { Ps1FileExtension, Psm1FileExtension, ZipFileExtension };
        internal static readonly HashSet<String> CreateArchiveAllowedFileExtensions =
            new HashSet<String>(StringComparer.OrdinalIgnoreCase) { Ps1FileExtension, Psm1FileExtension };
    }
}
