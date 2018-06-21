#########################################################################################
#
# Copyright (c) Microsoft Corporation. All rights reserved.
#
# Licensed under the MIT license.
#
# PSSwaggerUtility Module
#
#########################################################################################

ConvertFrom-StringData @'
###PSLOC

    NugetBootstrapPrompt=One or more NuGet packages that PSSwagger requires are missing, and PSSwagger is unable to find NuGet.exe in its cache locations or in your Path. PSSwagger needs to download NuGet.exe.
    NugetBootstrapDownload=Downloading NuGet.exe from '{0}' to '{1}'.
    NuGetPackageRequired=PSSwagger needs to download the NuGet package '{0}' to compile the generated assembly for .NET.
    NuGetPackageSpecificVersionRequired=PSSwagger needs to download the NuGet package '{0}' of version '{1}' to compile the generated assembly for .NET.
    DownloadingNuGetPackage=Downloading NuGet package '{0}'...
    BootstrapConfirmTitle=Do you want PSSwagger to download the missing tools or packages for you?
    FailedToInstallNuGetPackage=NuGet package '{0}' failed to install.
    NuGetStandardOut=Output from NuGet.exe: {0}
    MissingNuGetPackage=NuGet package '{0}' was not found in either the local PSSwagger package cache '{1}' or the global PSSwagger package cache '{2}'.
    MissingNuGetPackageSpecificVersion=NuGet package '{0}' of version '{3}' was not found in either the local PSSwagger package cache '{1}' or the global PSSwagger package cache '{2}'.
    CodeFileSignatureValidationFailed=Failed to validate the signature of file '{0}'.
    FailedToAddType=Unable to add '{0}' type.
    NuGetMissing=NuGet.exe missing. This usually means the user did not consent to download NuGet.exe when prompted.
    NuGetFailedToInstall=NuGet.exe failed to install to path '{0}'.
    CSharpNamespace=Microsoft.AzureStack.Management.Subscription
###PSLOC
'@
