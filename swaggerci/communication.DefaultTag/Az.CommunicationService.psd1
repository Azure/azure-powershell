@{
  GUID = 'd3fa77db-c378-4134-8839-a48f239535d4'
  RootModule = './Az.CommunicationService.psm1'
  ModuleVersion = '0.1.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: CommunicationService cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.CommunicationService.private.dll'
  FormatsToProcess = './Az.CommunicationService.format.ps1xml'
  FunctionsToExport = 'Get-AzCommunicationService', 'Get-AzCommunicationServiceDomain', 'Get-AzCommunicationServiceEmailService', 'Get-AzCommunicationServiceEmailServiceVerifiedExchangeOnlineDomain', 'Get-AzCommunicationServiceKey', 'Get-AzCommunicationServiceSenderUsername', 'Invoke-AzCommunicationServiceInitiateDomainVerification', 'Invoke-AzCommunicationServiceLinkCommunicationServiceNotificationHub', 'New-AzCommunicationService', 'New-AzCommunicationServiceDomain', 'New-AzCommunicationServiceEmailService', 'New-AzCommunicationServiceKey', 'New-AzCommunicationServiceSenderUsername', 'Remove-AzCommunicationService', 'Remove-AzCommunicationServiceDomain', 'Remove-AzCommunicationServiceEmailService', 'Remove-AzCommunicationServiceSenderUsername', 'Stop-AzCommunicationServiceDomainVerification', 'Test-AzCommunicationServiceNameAvailability', 'Update-AzCommunicationService', 'Update-AzCommunicationServiceDomain', 'Update-AzCommunicationServiceEmailService', '*'
  AliasesToExport = '*'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'CommunicationService'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
