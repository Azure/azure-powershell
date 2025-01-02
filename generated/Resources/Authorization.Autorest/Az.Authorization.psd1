@{
  GUID = '7f96e662-b170-4f95-899f-bbd1828cd20b'
  RootModule = './Az.Authorization.psm1'
  ModuleVersion = '0.1.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: Authorization cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.Authorization.private.dll'
  FormatsToProcess = './Az.Authorization.format.ps1xml'
  FunctionsToExport = 'Get-AzRoleAssignmentSchedule', 'Get-AzRoleAssignmentScheduleInstance', 'Get-AzRoleAssignmentScheduleRequest', 'Get-AzRoleEligibilitySchedule', 'Get-AzRoleEligibilityScheduleInstance', 'Get-AzRoleEligibilityScheduleRequest', 'Get-AzRoleEligibleChildResource', 'Get-AzRoleManagementPolicy', 'Get-AzRoleManagementPolicyAssignment', 'New-AzRoleAssignmentScheduleRequest', 'New-AzRoleEligibilityScheduleRequest', 'New-AzRoleManagementPolicyAssignment', 'Remove-AzRoleManagementPolicy', 'Remove-AzRoleManagementPolicyAssignment', 'Stop-AzRoleAssignmentScheduleRequest', 'Stop-AzRoleEligibilityScheduleRequest', 'Update-AzRoleManagementPolicy', '*'
  AliasesToExport = '*'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'Authorization'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
