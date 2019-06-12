@{
# region definition 
  RootModule = './Az.Monitor.psm1'
  ModuleVersion = '0.0.1'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: Monitor cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.Monitor.private.dll'
  FormatsToProcess = './Az.Monitor.format.ps1xml'
# endregion 

# region persistent data 
  GUID = '8af1772b-37e1-433d-78ad-cafc09b9763e'
# endregion 

# region private data 
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'Monitor'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
      Profiles = 'latest-2019-04-30', 'hybrid-2019-03-01'
    }
  }
# endregion 

# region exports
  CmdletsToExport = 'Enable-AzActionGroupReceiver', 'Get-AzActionGroup', 'Get-AzActivityLog', 'Get-AzActivityLogAlert', 'Get-AzAlertRule', 'Get-AzAlertRuleIncident', 'Get-AzAutoscaleSetting', 'Get-AzBaseline', 'Get-AzDiagnosticSetting', 'Get-AzDiagnosticSettingsCategory', 'Get-AzEventCategory', 'Get-AzLogProfile', 'Get-AzMetric', 'Get-AzMetricAlert', 'Get-AzMetricAlertsStatus', 'Get-AzMetricAlertStatus', 'Get-AzMetricBaseline', 'Get-AzMetricDefinition', 'Get-AzMetricNamespace', 'Get-AzScheduledQueryRule', 'Get-AzTenantActivityLog', 'Get-AzVMInsightOnboardingStatus', 'Invoke-AzCalculateMetricBaseline', 'New-AzActionGroup', 'New-AzActivityLogAlert', 'New-AzAlertRule', 'New-AzAutoscaleSetting', 'New-AzDiagnosticSetting', 'New-AzLogProfile', 'New-AzMetric', 'New-AzMetricAlert', 'New-AzScheduledQueryRule', 'Remove-AzActionGroup', 'Remove-AzActivityLogAlert', 'Remove-AzAlertRule', 'Remove-AzAutoscaleSetting', 'Remove-AzDiagnosticSetting', 'Remove-AzLogProfile', 'Remove-AzMetricAlert', 'Remove-AzScheduledQueryRule', 'Set-AzActionGroup', 'Set-AzActivityLogAlert', 'Set-AzAlertRule', 'Set-AzAutoscaleSetting', 'Set-AzDiagnosticSetting', 'Set-AzLogProfile', 'Set-AzMetricAlert', 'Set-AzScheduledQueryRule', 'Update-AzActionGroup', 'Update-AzActivityLogAlert', 'Update-AzAlertRule', 'Update-AzAutoscaleSetting', 'Update-AzLogProfile', 'Update-AzMetricAlert', 'Update-AzScheduledQueryRule', '*'
  AliasesToExport = 'Get-AzLog', 'Get-AzMetricAlertRuleV2', 'Add-AzMetricAlertRule', 'Add-AzMetricAlertRuleV2', 'Remove-AzMetricAlertRuleV2', 'Add-AzAutoscaleSetting', 'Add-AzLogProfile', '*'
# endregion

}