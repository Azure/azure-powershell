@{
  GUID = '21bdebd2-08fb-474b-9b85-a6b7415bd1f2'
  RootModule = './Az.EmailService.psm1'
  ModuleVersion = '0.1.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: EmailService cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.EmailService.private.dll'
  FormatsToProcess = './Az.EmailService.format.ps1xml'
  FunctionsToExport = 'Get-AzEmailService', 'Get-AzEmailServiceDomain', 'Get-AzEmailServiceSenderUsername', 'Invoke-AzEmailServiceInitiateDomainVerification', 'New-AzEmailService', 'New-AzEmailServiceDomain', 'New-AzEmailServiceSenderUsername', 'Remove-AzEmailService', 'Remove-AzEmailServiceDomain', 'Remove-AzEmailServiceSenderUsername', 'Stop-AzEmailServiceDomainVerification', 'Update-AzEmailService', 'Update-AzEmailServiceDomain', 'Update-AzEmailServiceSenderUsername'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'EmailService'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
