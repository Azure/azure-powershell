@{
  GUID = '203dd0d3-7536-434e-a703-31828851e037'
  RootModule = 'Authorization.psm1'
  ModuleVersion = '0.1.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: Authorization cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.Resources.Authorization.private.dll'
  FormatsToProcess = 'Authorization.format.ps1xml'
  FunctionsToExport = 'Get-AzEligibleChildResource', 'Get-AzRoleAssignmentSchedule', 'Get-AzRoleAssignmentScheduleInstance', 'Get-AzRoleAssignmentScheduleRequest', 'Get-AzRoleEligibilitySchedule', 'Get-AzRoleEligibilityScheduleInstance', 'Get-AzRoleEligibilityScheduleRequest', 'Get-AzRoleManagementPolicy', 'Get-AzRoleManagementPolicyAssignment', 'New-AzRoleAssignmentScheduleRequest', 'New-AzRoleEligibilityScheduleRequest', 'New-AzRoleManagementPolicyAssignment', 'Remove-AzRoleManagementPolicy', 'Remove-AzRoleManagementPolicyAssignment', 'Stop-AzRoleAssignmentScheduleRequest', 'Stop-AzRoleEligibilityScheduleRequest', 'Update-AzRoleManagementPolicy', '*'
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
