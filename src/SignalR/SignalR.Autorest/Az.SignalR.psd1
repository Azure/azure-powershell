@{
  GUID = '887a3597-2c6e-46ff-a239-c56a20f0bf79'
  RootModule = 'Az.SignalR.psm1'
  ModuleVersion = '0.1.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: WebPubSub cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.SignalR.private.dll'
  FormatsToProcess = './Az.SignalR.format.ps1xml'
  FunctionsToExport = 'Get-AzWebPubSub', 'Get-AzWebPubSubCustomCertificate', 'Get-AzWebPubSubCustomDomain', 'Get-AzWebPubSubHub', 'Get-AzWebPubSubKey', 'Get-AzWebPubSubSku', 'Get-AzWebPubSubUsage', 'New-AzWebPubSub', 'New-AzWebPubSubCustomCertificate', 'New-AzWebPubSubCustomDomain', 'New-AzWebPubSubEventHubEndpointObject', 'New-AzWebPubSubEventNameFilterObject', 'New-AzWebPubSubHub', 'New-AzWebPubSubKey', 'Remove-AzWebPubSub', 'Remove-AzWebPubSubCustomCertificate', 'Remove-AzWebPubSubCustomDomain', 'Remove-AzWebPubSubHub', 'Restart-AzWebPubSub', 'Test-AzWebPubSubNameAvailability', 'Update-AzWebPubSub', '*'
  AliasesToExport = '*'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'WebPubSub'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
