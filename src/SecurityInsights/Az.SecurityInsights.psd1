@{
  GUID = '3a0e09d6-7b89-4078-a565-5db26e7455b8'
  RootModule = './Az.SecurityInsights.psm1'
  ModuleVersion = '1.2.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: SecurityInsights cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.SecurityInsights.private.dll'
  FormatsToProcess = './Az.SecurityInsights.format.ps1xml'
  FunctionsToExport = 'Get-AzSentinelAlertRule', 'Get-AzSentinelAlertRuleAction', 'Get-AzSentinelAlertRuleTemplate', 'Get-AzSentinelAutomationRule', 'Get-AzSentinelBookmark', 'Get-AzSentinelDataConnector', 'Get-AzSentinelIncident', 'Get-AzSentinelIncidentAlert', 'Get-AzSentinelIncidentBookmark', 'Get-AzSentinelIncidentComment', 'Get-AzSentinelIncidentEntity', 'Get-AzSentinelIncidentRelation', 'Get-AzSentinelMetadata', 'Get-AzSentinelOnboardingState', 'Get-AzSentinelSecurityMlAnalyticsSetting', 'Get-AzSentinelThreatIntelligenceIndicator', 'Get-AzSentinelThreatIntelligenceIndicatorMetric', 'Invoke-AzSentinelThreatIntelligenceIndicatorQuery', 'New-AzSentinelAlertRule', 'New-AzSentinelAlertRuleAction', 'New-AzSentinelAnomalySecurityMlAnalyticsSettingsObject', 'New-AzSentinelAutomationRule', 'New-AzSentinelAutomationRuleActionCondition', 'New-AzSentinelAutomationRuleActionObject', 'New-AzSentinelBookmark', 'New-AzSentinelDataConnector', 'New-AzSentinelIncident', 'New-AzSentinelIncidentComment', 'New-AzSentinelIncidentRelation', 'New-AzSentinelOnboardingState', 'New-AzSentinelSecurityMlAnalyticsSetting', 'Remove-AzSentinelAlertRule', 'Remove-AzSentinelAlertRuleAction', 'Remove-AzSentinelAutomationRule', 'Remove-AzSentinelBookmark', 'Remove-AzSentinelDataConnector', 'Remove-AzSentinelIncident', 'Remove-AzSentinelIncidentComment', 'Remove-AzSentinelIncidentRelation', 'Remove-AzSentinelOnboardingState', 'Remove-AzSentinelSecurityMlAnalyticsSetting', 'Update-AzSentinelAlertRule', 'Update-AzSentinelAlertRuleAction', 'Update-AzSentinelAutomationRule', 'Update-AzSentinelBookmark', 'Update-AzSentinelDataConnector', 'Update-AzSentinelIncident', 'Update-AzSentinelIncidentComment', 'Update-AzSentinelIncidentRelation', 'Update-AzSentinelSecurityMlAnalyticsSetting'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'SecurityInsights'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
