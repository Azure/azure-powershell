@{
  GUID = '4cd9af10-559e-4fb9-8dcd-d3e8eb9e03b7'
  RootModule = './Az.CostManagement.psm1'
  ModuleVersion = '0.3.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: Cost cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.CostManagement.private.dll'
  FormatsToProcess = './Az.CostManagement.format.ps1xml'
  FunctionsToExport = 'Get-AzCostManagementExport', 'Get-AzCostManagementExportExecutionHistory', 'Invoke-AzCostManagementExecuteExport', 'Invoke-AzCostManagementQuery', 'Invoke-AzCostManagementReservationDetailReport', 'New-AzCostManagementDetailReport', 'New-AzCostManagementExport', 'New-AzCostManagementQueryComparisonExpressionObject', 'New-AzCostManagementQueryFilterObject', 'Remove-AzCostManagementExport', 'Update-AzCostManagementExport', '*'
  AliasesToExport = '*'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'Cost'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
