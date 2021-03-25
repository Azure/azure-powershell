@{
  GUID = 'ed46e8cd-1eb8-4568-809e-9917eabc3429'
  RootModule = './Az.ProviderHub.psm1'
  ModuleVersion = '0.1.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: ProviderHub cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/ProviderHub.private.dll'
  FormatsToProcess = './Az.ProviderHub.format.ps1xml'
  FunctionsToExport = 'Get-AzProviderHubCustomRollout', 'Get-AzProviderHubDefaultRollout', 'Get-AzProviderHubNotificationRegistration', 'Get-AzProviderHubProviderRegistration', 'Get-AzProviderHubResourceTypeRegistration', 'Get-AzProviderHubSku', 'Get-AzProviderHubSkuNestedResourceTypeFirst', 'Get-AzProviderHubSkuNestedResourceTypeSecond', 'Get-AzProviderHubSkuNestedResourceTypeThird', 'Invoke-AzProviderHubManifestCheckin', 'New-AzProviderHubCustomRollout', 'New-AzProviderHubDefaultRollout', 'New-AzProviderHubManifest', 'New-AzProviderHubNotificationRegistration', 'New-AzProviderHubProviderRegistration', 'New-AzProviderHubProviderRegistrationOperation', 'New-AzProviderHubResourceTypeRegistration', 'New-AzProviderHubSku', 'New-AzProviderHubSkuNestedResourceTypeFirst', 'New-AzProviderHubSkuNestedResourceTypeSecond', 'New-AzProviderHubSkuNestedResourceTypeThird', 'Remove-AzProviderHubDefaultRollout', 'Remove-AzProviderHubNotificationRegistration', 'Remove-AzProviderHubProviderRegistration', 'Remove-AzProviderHubResourceTypeRegistration', 'Remove-AzProviderHubSku', 'Remove-AzProviderHubSkuNestedResourceTypeFirst', 'Remove-AzProviderHubSkuNestedResourceTypeSecond', 'Remove-AzProviderHubSkuNestedResourceTypeThird', 'Set-AzProviderHubCustomRollout', 'Set-AzProviderHubDefaultRollout', 'Set-AzProviderHubNotificationRegistration', 'Set-AzProviderHubProviderRegistration', 'Set-AzProviderHubResourceTypeRegistration', 'Set-AzProviderHubSku', 'Set-AzProviderHubSkuNestedResourceTypeFirst', 'Set-AzProviderHubSkuNestedResourceTypeSecond', 'Set-AzProviderHubSkuNestedResourceTypeThird', 'Stop-AzProviderHubDefaultRollout', '*'
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
