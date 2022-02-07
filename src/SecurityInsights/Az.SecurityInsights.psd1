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
  FunctionsToExport = 'Get-AzSentinelAlertRule', 'Get-AzSentinelAlertRuleAction', 'Get-AzSentinelAlertRuleTemplate', 'Get-AzSentinelAutomationRule', 'Get-AzSentinelBookmark', 'Get-AzSentinelBookmarkRelation', 'Get-AzSentinelDataConnector', 'Get-AzSentinelEnrichment', 'Get-AzSentinelEntity', 'Get-AzSentinelEntityActivity', 'Get-AzSentinelEntityInsight', 'Get-AzSentinelEntityQuery', 'Get-AzSentinelEntityQueryTemplate', 'Get-AzSentinelEntityRelation', 'Get-AzSentinelEntityTimeline', 'Get-AzSentinelIncident', 'Get-AzSentinelIncidentAlert', 'Get-AzSentinelIncidentBookmark', 'Get-AzSentinelIncidentComment', 'Get-AzSentinelIncidentEntity', 'Get-AzSentinelIncidentRelation', 'Get-AzSentinelMetadata', 'Get-AzSentinelOnboardingState', 'Get-AzSentinelSetting', 'Get-AzSentinelSourceControlRepository', 'Get-AzSentinelThreatIntelligenceIndicator', 'Get-AzSentinelThreatIntelligenceIndicatorMetric', 'Invoke-AzSentinelDataConnectorsCheckRequirement', 'Invoke-AzSentinelThreatIntelligenceIndicatorQuery', 'New-AzSentinelAlertRule', 'New-AzSentinelDataConnector', 'New-AzSentinelEntityQuery', 'Update-AzSentinelAlertRule', 'Update-AzSentinelDataConnector', 'Update-AzSentinelEntityQuery', 'Update-AzSentinelSetting', '*'
  AliasesToExport = '*'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'SecurityInsights'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
