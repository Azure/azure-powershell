@{
  GUID = '2e1edc57-5849-4b9d-9705-805c2c7ce10b'
  RootModule = './Az.Resiliency.psm1'
  ModuleVersion = '0.1.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: Resiliency cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.Resiliency.private.dll'
  FormatsToProcess = './Az.Resiliency.format.ps1xml'
  FunctionsToExport = 'Add-AzResiliencyDrillRunNote', 'Complete-AzResiliencyDrillRun', 'Get-AzResiliencyDrill', 'Get-AzResiliencyDrillResource', 'Get-AzResiliencyDrillRun', 'Get-AzResiliencyDrillRunReportDownloadUrl', 'Get-AzResiliencyDrillRunResource', 'Get-AzResiliencyEnrollment', 'Get-AzResiliencyGoalAssignment', 'Get-AzResiliencyGoalAssignmentCapacity', 'Get-AzResiliencyGoalResource', 'Get-AzResiliencyOperationStatus', 'Get-AzResiliencyRecoveryJob', 'Get-AzResiliencyRecoveryJobResource', 'Get-AzResiliencyRecoveryPlan', 'Get-AzResiliencyRecoveryResource', 'Get-AzResiliencyUsagePlan', 'Invoke-AzResiliencyDrillRunFailover', 'Invoke-AzResiliencyDrillRunReprotect', 'Invoke-AzResiliencyRecoveryJobRetry', 'Invoke-AzResiliencyRecoveryPlanFailover', 'Invoke-AzResiliencyRecoveryPlanFinalize', 'Invoke-AzResiliencyRecoveryPlanReprotect', 'New-AzResiliencyDrill', 'New-AzResiliencyDrillRunReport', 'New-AzResiliencyEnrollment', 'New-AzResiliencyGoalAssignment', 'New-AzResiliencyRecoveryPlan', 'New-AzResiliencyUsagePlan', 'Remove-AzResiliencyDrill', 'Remove-AzResiliencyEnrollment', 'Remove-AzResiliencyGoalAssignment', 'Remove-AzResiliencyRecoveryPlan', 'Remove-AzResiliencyUsagePlan', 'Resume-AzResiliencyDrillRun', 'Resume-AzResiliencyRecoveryJob', 'Set-AzResiliencyEnrollment', 'Set-AzResiliencyUsagePlan', 'Start-AzResiliencyDrill', 'Stop-AzResiliencyDrill', 'Sync-AzResiliencyDrillReadiness', 'Sync-AzResiliencyGoalResource', 'Test-AzResiliencyDrillExecutionValidation', 'Test-AzResiliencyRecoveryPlanFailoverValidation', 'Test-AzResiliencyRecoveryPlanOperationValidation', 'Test-AzResiliencyRecoveryPlanReadiness', 'Test-AzResiliencyRecoveryPlanReprotectValidation', 'Update-AzResiliencyDrill', 'Update-AzResiliencyDrillResource', 'Update-AzResiliencyEnrollment', 'Update-AzResiliencyGoalAssignment', 'Update-AzResiliencyGoalResource', 'Update-AzResiliencyRecoveryPlan', 'Update-AzResiliencyRecoveryPlanResource', 'Update-AzResiliencyUsagePlan'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'Resiliency'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
