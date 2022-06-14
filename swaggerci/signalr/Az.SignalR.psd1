@{
  GUID = '6a425d48-98eb-4e14-82b6-3b85440e7c20'
  RootModule = './Az.SignalR.psm1'
  ModuleVersion = '0.1.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: SignalR cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.SignalR.private.dll'
  FormatsToProcess = './Az.SignalR.format.ps1xml'
  FunctionsToExport = 'Get-AzSignalR', 'Get-AzSignalRCustomCertificate', 'Get-AzSignalRCustomDomain', 'Get-AzSignalRKey', 'Get-AzSignalRPrivateEndpointConnection', 'Get-AzSignalRPrivateLinkResource', 'Get-AzSignalRSharedPrivateLinkResource', 'Get-AzSignalRSku', 'Get-AzSignalRUsage', 'New-AzSignalR', 'New-AzSignalRCustomCertificate', 'New-AzSignalRCustomDomain', 'New-AzSignalRKey', 'New-AzSignalRSharedPrivateLinkResource', 'Remove-AzSignalR', 'Remove-AzSignalRCustomCertificate', 'Remove-AzSignalRCustomDomain', 'Remove-AzSignalRPrivateEndpointConnection', 'Remove-AzSignalRSharedPrivateLinkResource', 'Restart-AzSignalR', 'Test-AzSignalRNameAvailability', 'Update-AzSignalR', '*'
  AliasesToExport = '*'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'SignalR'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
