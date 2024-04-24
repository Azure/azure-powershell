@{
  GUID = '7b4d2bea-a7a6-48f5-b26e-4ce98db31845'
  RootModule = './Az.ProviderHub.psm1'
  ModuleVersion = '0.1.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: ProviderHub cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.ProviderHub.private.dll'
  FormatsToProcess = './Az.ProviderHub.format.ps1xml'
  FunctionsToExport = 'Get-AzProviderHubCustomRollout', 'Get-AzProviderHubDefaultRollout', 'Get-AzProviderHubNotificationRegistration', 'Get-AzProviderHubProviderRegistration', 'Get-AzProviderHubResourceTypeRegistration', 'Get-AzProviderHubSku', 'Invoke-AzProviderHubManifestCheckin', 'New-AzProviderHubCustomRollout', 'New-AzProviderHubDefaultRollout', 'New-AzProviderHubManifest', 'New-AzProviderHubNotificationRegistration', 'New-AzProviderHubProviderRegistration', 'New-AzProviderHubResourceTypeRegistration', 'New-AzProviderHubSku', 'Remove-AzProviderHubDefaultRollout', 'Remove-AzProviderHubNotificationRegistration', 'Remove-AzProviderHubProviderRegistration', 'Remove-AzProviderHubResourceTypeRegistration', 'Remove-AzProviderHubSku', 'Stop-AzProviderHubDefaultRollout', '*'
  AliasesToExport = '*'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'ProviderHub'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
