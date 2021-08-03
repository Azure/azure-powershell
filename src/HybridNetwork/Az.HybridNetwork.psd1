@{
  GUID = 'f89b6c26-e325-45ed-99fb-8dfb9602d334'
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
  FunctionsToExport = 'Get-AzHybridNetworkFunction', 'Get-AzHybridNetworkFunctionVendor', 'Get-AzHybridNetworkFunctionVendorSku', 'Get-AzHybridNetworkRoleInstance', 'Get-AzHybridNetworkVendor', 'Get-AzHybridNetworkVendorNetworkFunction', 'Get-AzHybridNetworkVendorSku', 'Get-AzHybridNetworkVendorSkuPreview', 'New-AzHybridNetworkFunction', 'New-AzHybridNetworkVendor', 'New-AzHybridNetworkVendorNetworkFunction', 'New-AzHybridNetworkVendorSku', 'New-AzHybridNetworkVendorSkuPreview', 'Remove-AzHybridNetworkFunction', 'Remove-AzHybridNetworkVendor', 'Remove-AzHybridNetworkVendorSku', 'Remove-AzHybridNetworkVendorSkuPreview', 'Restart-AzHybridNetworkRoleInstance', 'Set-AzHybridNetworkFunction', 'Set-AzHybridNetworkVendor', 'Set-AzHybridNetworkVendorNetworkFunction', 'Set-AzHybridNetworkVendorSku', 'Set-AzHybridNetworkVendorSkuPreview', 'Start-AzHybridNetworkRoleInstance', 'Stop-AzHybridNetworkRoleInstance', 'Update-AzHybridNetworkFunctionTag', '*'
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
