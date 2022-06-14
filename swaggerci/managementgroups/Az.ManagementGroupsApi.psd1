@{
  GUID = '1abc5d82-4775-4eed-a45e-0ca01dfddce1'
  RootModule = './Az.ManagementGroupsApi.psm1'
  ModuleVersion = '0.1.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: ManagementGroupsApi cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.ManagementGroupsApi.private.dll'
  FormatsToProcess = './Az.ManagementGroupsApi.format.ps1xml'
  FunctionsToExport = 'Get-AzManagementGroupsApiEntity', 'Get-AzManagementGroupsApiHierarchySetting', 'Get-AzManagementGroupsApiManagementGroup', 'Get-AzManagementGroupsApiManagementGroupDescendant', 'Get-AzManagementGroupsApiManagementGroupSubscription', 'Get-AzManagementGroupsApiManagementGroupSubscriptionUnderManagementGroup', 'Invoke-AzManagementGroupsApiTenantBackfillStatus', 'New-AzManagementGroupsApiHierarchySetting', 'New-AzManagementGroupsApiManagementGroup', 'Remove-AzManagementGroupsApiHierarchySetting', 'Remove-AzManagementGroupsApiManagementGroup', 'Remove-AzManagementGroupsApiManagementGroupSubscription', 'Start-AzManagementGroupsApiTenantBackfill', 'Test-AzManagementGroupsApiNameAvailability', 'Update-AzManagementGroupsApiHierarchySetting', 'Update-AzManagementGroupsApiManagementGroup', '*'
  AliasesToExport = '*'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'ManagementGroupsApi'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
