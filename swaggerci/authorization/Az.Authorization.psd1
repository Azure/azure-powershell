@{
  GUID = 'c5daaabe-da78-498e-88f5-111a28b777e6'
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
  FunctionsToExport = 'Add-AzAuthorizationAccessReviewInstanceDecision', 'Get-AzAuthorizationAccessReviewDefaultSetting', 'Get-AzAuthorizationAccessReviewHistoryDefinition', 'Get-AzAuthorizationAccessReviewHistoryDefinitionInstance', 'Get-AzAuthorizationAccessReviewInstance', 'Get-AzAuthorizationAccessReviewInstanceAssignedForMyApproval', 'Get-AzAuthorizationAccessReviewInstanceContactedReviewer', 'Get-AzAuthorizationAccessReviewInstanceDecision', 'Get-AzAuthorizationAccessReviewInstanceMyDecision', 'Get-AzAuthorizationAccessReviewInstancesAssignedForMyApproval', 'Get-AzAuthorizationAccessReviewScheduleDefinition', 'Get-AzAuthorizationAccessReviewScheduleDefinitionsAssignedForMyApproval', 'Get-AzAuthorizationTenantLevelAccessReviewInstanceContactedReviewer', 'Invoke-AzAuthorizationAcceptAccessReviewInstanceRecommendation', 'New-AzAuthorizationAccessReviewHistoryDefinition', 'New-AzAuthorizationAccessReviewHistoryDefinitionInstanceDownloadUri', 'New-AzAuthorizationAccessReviewInstance', 'New-AzAuthorizationAccessReviewScheduleDefinition', 'Remove-AzAuthorizationAccessReviewHistoryDefinition', 'Remove-AzAuthorizationAccessReviewScheduleDefinition', 'Reset-AzAuthorizationAccessReviewInstanceDecision', 'Send-AzAuthorizationAccessReviewInstanceReminder', 'Stop-AzAuthorizationAccessReviewInstance', 'Stop-AzAuthorizationAccessReviewScheduleDefinition', 'Update-AzAuthorizationAccessReviewInstanceMyDecision', '*'
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
