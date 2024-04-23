@{
  GUID = 'ffbed74a-2473-42d2-95fc-73adffd13d49'
  RootModule = './Az.EdgeOrder.psm1'
  ModuleVersion = '0.1.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: EdgeOrder cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.EdgeOrder.private.dll'
  FormatsToProcess = './Az.EdgeOrder.format.ps1xml'
  FunctionsToExport = 'Get-AzEdgeOrder', 'Get-AzEdgeOrderAddress', 'Get-AzEdgeOrderConfiguration', 'Get-AzEdgeOrderItem', 'Get-AzEdgeOrderProductFamily', 'Get-AzEdgeOrderProductFamilyMetadata', 'Invoke-AzEdgeOrderItemCancellation', 'Invoke-AzEdgeOrderReturnOrderItem', 'New-AzEdgeOrderAddress', 'New-AzEdgeOrderContactDetailsObject', 'New-AzEdgeOrderFilterablePropertyObject', 'New-AzEdgeOrderHierarchyInformationObject', 'New-AzEdgeOrderItem', 'New-AzEdgeOrderOrderItemDetailsObject', 'New-AzEdgeOrderPreferencesObject', 'New-AzEdgeOrderShippingAddressObject', 'Remove-AzEdgeOrderAddress', 'Remove-AzEdgeOrderItem', 'Update-AzEdgeOrderAddress', 'Update-AzEdgeOrderItem', '*'
  AliasesToExport = '*'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'EdgeOrder'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
