@{
  GUID = '42cf5e19-9176-4826-9f5b-e5e9654fc69c'
  RootModule = './Az.WebPubSub.psm1'
  ModuleVersion = '0.1.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: WebPubSub cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.WebPubSub.private.dll'
  FormatsToProcess = './Az.WebPubSub.format.ps1xml'
  FunctionsToExport = 'Get-AzWebPubSub', 'Get-AzWebPubSubEventHandler', 'Get-AzWebPubSubHub', 'Get-AzWebPubSubKey', 'Get-AzWebPubSubPrivateEndpointConnection', 'Get-AzWebPubSubPrivateLinkResource', 'Get-AzWebPubSubSharedPrivateLinkResource', 'Get-AzWebPubSubSku', 'Get-AzWebPubSubUsage', 'New-AzWebPubSub', 'New-AzWebPubSubEventHandler', 'New-AzWebPubSubHub', 'New-AzWebPubSubKey', 'New-AzWebPubSubSharedPrivateLinkResource', 'Remove-AzWebPubSub', 'Remove-AzWebPubSubEventHandler', 'Remove-AzWebPubSubHub', 'Remove-AzWebPubSubPrivateEndpointConnection', 'Remove-AzWebPubSubSharedPrivateLinkResource', 'Restart-AzWebPubSub', 'Test-AzWebPubSubNameAvailability', 'Update-AzWebPubSub', '*'
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
