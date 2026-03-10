@{
  GUID = '9a3409c4-0fed-4a92-8b66-12d43371ce81'
  RootModule = './Az.ArtifactSigning.psm1'
  ModuleVersion = '0.1.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: ArtifactSigning cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.ArtifactSigning.private.dll'
  FormatsToProcess = './Az.ArtifactSigning.format.ps1xml'
  FunctionsToExport = 'Get-AzArtifactSigningAccount', 'Get-AzArtifactSigningCertificateProfile', 'New-AzArtifactSigningAccount', 'New-AzArtifactSigningCertificateProfile', 'Remove-AzArtifactSigningAccount', 'Remove-AzArtifactSigningCertificateProfile', 'Test-AzArtifactSigningAccountNameAvailability', 'Update-AzArtifactSigningAccount'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'ArtifactSigning'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
