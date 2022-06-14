@{
  GUID = '2c3d66ff-6af7-47c5-8d43-bff61022c2cd'
  RootModule = './Az.Maintenance.psm1'
  ModuleVersion = '0.1.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: Maintenance cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.Maintenance.private.dll'
  FormatsToProcess = './Az.Maintenance.format.ps1xml'
  FunctionsToExport = 'Get-AzMaintenanceApplyUpdate', 'Get-AzMaintenanceApplyUpdateForResourceGroup', 'Get-AzMaintenanceApplyUpdateParent', 'Get-AzMaintenanceConfiguration', 'Get-AzMaintenanceConfigurationAssignment', 'Get-AzMaintenanceConfigurationAssignmentParent', 'Get-AzMaintenanceConfigurationAssignmentsWithinSubscription', 'Get-AzMaintenanceConfigurationsForResourceGroup', 'Get-AzMaintenancePublicMaintenanceConfiguration', 'Get-AzMaintenanceUpdate', 'Get-AzMaintenanceUpdateParent', 'New-AzMaintenanceConfiguration', 'New-AzMaintenanceConfigurationAssignment', 'New-AzMaintenanceConfigurationAssignmentParent', 'Remove-AzMaintenanceConfiguration', 'Remove-AzMaintenanceConfigurationAssignment', 'Remove-AzMaintenanceConfigurationAssignmentParent', 'Update-AzMaintenanceConfiguration', '*'
  AliasesToExport = '*'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'Maintenance'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
