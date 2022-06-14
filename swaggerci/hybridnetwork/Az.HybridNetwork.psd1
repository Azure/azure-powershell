@{
  GUID = 'f689435d-5e1a-4250-a584-3f33213824d4'
  RootModule = './Az.HybridNetwork.psm1'
  ModuleVersion = '0.1.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: HybridNetwork cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.HybridNetwork.private.dll'
  FormatsToProcess = './Az.HybridNetwork.format.ps1xml'
  FunctionsToExport = 'Get-AzHybridNetworkDevice', 'Get-AzHybridNetworkDeviceRegistrationKey', 'Get-AzHybridNetworkFunction', 'Get-AzHybridNetworkFunctionVendor', 'Get-AzHybridNetworkFunctionVendorSku', 'Get-AzHybridNetworkRoleInstance', 'Get-AzHybridNetworkVendor', 'Get-AzHybridNetworkVendorNetworkFunction', 'Get-AzHybridNetworkVendorSku', 'Get-AzHybridNetworkVendorSkuCredential', 'Get-AzHybridNetworkVendorSkuPreview', 'Invoke-AzHybridNetworkExecuteNetworkFunctionRequest', 'New-AzHybridNetworkDevice', 'New-AzHybridNetworkFunction', 'New-AzHybridNetworkVendor', 'New-AzHybridNetworkVendorNetworkFunction', 'New-AzHybridNetworkVendorSku', 'New-AzHybridNetworkVendorSkuPreview', 'Remove-AzHybridNetworkDevice', 'Remove-AzHybridNetworkFunction', 'Remove-AzHybridNetworkVendor', 'Remove-AzHybridNetworkVendorSku', 'Remove-AzHybridNetworkVendorSkuPreview', 'Restart-AzHybridNetworkRoleInstance', 'Start-AzHybridNetworkRoleInstance', 'Stop-AzHybridNetworkRoleInstance', 'Update-AzHybridNetworkDeviceTag', 'Update-AzHybridNetworkFunctionTag', '*'
  AliasesToExport = '*'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'HybridNetwork'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
