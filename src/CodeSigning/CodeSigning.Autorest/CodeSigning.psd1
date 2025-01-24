@{
  GUID = 'f1088de3-4792-49a9-9865-57b17f7bc993'
  RootModule = './CodeSigning.psm1'
  ModuleVersion = '0.1.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = ''
  CompanyName = ''
  Copyright = ''
  Description = ''
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/CodeSigning.private.dll'
  FormatsToProcess = './CodeSigning.format.ps1xml'
  FunctionsToExport = 'Get-CertificateProfile', 'Get-CodeSigningAccount', 'Get-Operation', 'New-CertificateProfile', 'New-CodeSigningAccount', 'Remove-CertificateProfile', 'Remove-CodeSigningAccount', 'Revoke-CertificateProfileCertificate', 'Test-CodeSigningAccountNameAvailability', 'Update-CodeSigningAccount'
  PrivateData = @{
    PSData = @{
      Tags = ''
      LicenseUri = ''
      ProjectUri = ''
      ReleaseNotes = ''
    }
  }
}
