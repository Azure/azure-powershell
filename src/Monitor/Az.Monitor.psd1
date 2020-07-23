@{
  GUID = '364b2dcf-3b5b-4752-b9e9-a267e94981d7'
  RootModule = './Az.Monitor.psm1'
  ModuleVersion = '4.0.2'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: Monitor cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.Monitor.private.dll'
  FormatsToProcess = './Az.Monitor.format.ps1xml'
  CmdletsToExport = 'Disable-AzActivityLogAlert', 'Enable-AzActivityLogAlert', 'Get-AzActionGroup', 'Get-AzActivityLog', 'Get-AzActivityLogAlert', 'Get-AzAlertRule', 'Get-AzAlertRuleIncident', 'Get-AzAutoscaleSetting', 'Get-AzDiagnosticSetting', 'Get-AzDiagnosticSettingCategory', 'Get-AzEventCategory', 'Get-AzLogProfile', 'Get-AzMetric', 'Get-AzMetricAlert', 'Get-AzMetricAlertStatus', 'Get-AzMetricBaseline', 'Get-AzMetricDefinition', 'Get-AzMetricNamespace', 'Get-AzScheduledQueryRule', 'Get-AzTenantActivityLog', 'Get-AzVMInsightOnboardingStatus', 'Invoke-AzCalculateMetricBaseline', 'New-AzActionGroup', 'New-AzActivityLogAlert', 'New-AzAlertRule', 'New-AzAutoscaleSetting', 'New-AzDiagnosticSetting', 'New-AzLogProfile', 'New-AzMetricAlert', 'New-AzScheduledQueryRule', 'Remove-AzActionGroup', 'Remove-AzActivityLogAlert', 'Remove-AzAlertRule', 'Remove-AzAutoscaleSetting', 'Remove-AzDiagnosticSetting', 'Remove-AzLogProfile', 'Remove-AzMetricAlert', 'Remove-AzScheduledQueryRule', 'Set-AzActionGroup', 'Set-AzActivityLogAlert', 'Set-AzAutoscaleSetting', 'Set-AzDiagnosticSetting', 'Set-AzLogProfile', 'Set-AzScheduledQueryRule', 'Update-AzAlertRule', 'Update-AzAutoscaleSetting', 'Update-AzLogProfile', 'Update-AzMetricAlert', 'Update-AzScheduledQueryRule', '*'
  AliasesToExport = 'Get-AzLog', 'Get-AzMetricAlertRuleV2', 'Add-AzMetricAlertRule', 'Add-AzLogProfile', 'Add-AzMetricAlertRuleV2', 'Remove-AzMetricAlertRuleV2', 'Add-AzAutoscaleSetting', '*'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'Monitor'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
      Prerelease = 'preview'
      Profiles = 'latest-2019-04-30', 'hybrid-2019-03-01'
    }
  }
}
