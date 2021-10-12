@{
  GUID = 'c2e638b2-62c1-41e6-bc07-abefe1868954'
  RootModule = './Az.ConnectedNetwork.psm1'
  ModuleVersion = '0.1.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: ConnectedNetwork cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.ConnectedNetwork.private.dll'
  FormatsToProcess = './Az.ConnectedNetwork.format.ps1xml'
  FunctionsToExport = 'Get-AzConnectedNetworkDevice', 'Get-AzConnectedNetworkDeviceRegistrationKey', 'Get-AzConnectedNetworkFunction', 'Get-AzConnectedNetworkFunctionVendor', 'Get-AzConnectedNetworkFunctionVendorSku', 'Get-AzConnectedNetworkVendor', 'Get-AzConnectedNetworkVendorFunction', 'Get-AzConnectedNetworkVendorFunctionRoleInstance', 'Get-AzConnectedNetworkVendorSku', 'Get-AzConnectedNetworkVendorSkuPreview', 'New-AzConnectedNetworkDevice', 'New-AzConnectedNetworkFunction', 'New-AzConnectedNetworkVendor', 'New-AzConnectedNetworkVendorFunction', 'New-AzConnectedNetworkVendorSku', 'New-AzConnectedNetworkVendorSkuPreview', 'Remove-AzConnectedNetworkDevice', 'Remove-AzConnectedNetworkFunction', 'Remove-AzConnectedNetworkVendor', 'Remove-AzConnectedNetworkVendorSku', 'Remove-AzConnectedNetworkVendorSkuPreview', 'Restart-AzConnectedNetworkVendorFunctionRoleInstance', 'Start-AzConnectedNetworkVendorFunctionRoleInstance', 'Stop-AzConnectedNetworkVendorFunctionRoleInstance', 'Update-AzConnectedNetworkDeviceTag', 'Update-AzConnectedNetworkFunctionTag', '*'
  AliasesToExport = '*'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'ConnectedNetwork'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
