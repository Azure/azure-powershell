@{
  GUID = '4554efe3-acd8-4d37-b17e-7325f143c299'
  RootModule = './Az.TrustedSigning.psm1'
  ModuleVersion = '0.1.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: TrustedSigning cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.TrustedSigning.private.dll'
  FormatsToProcess = './Az.TrustedSigning.format.ps1xml'
  FunctionsToExport = 'Get-AzTrustedSigningAccount', 'Get-AzTrustedSigningCertificateProfile', 'New-AzTrustedSigningAccount', 'New-AzTrustedSigningCertificateProfile', 'Remove-AzTrustedSigningAccount', 'Remove-AzTrustedSigningCertificateProfile', 'Test-AzTrustedSigningAccountNameAvailability', 'Update-AzTrustedSigningAccount'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'TrustedSigning'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
