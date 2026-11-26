@{
  GUID = '73e842ba-6e7b-45c9-b431-e6582e3fb922'
  RootModule = './Az.CloudHealth.psm1'
  ModuleVersion = '0.1.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: CloudHealth cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.CloudHealth.private.dll'
  FormatsToProcess = './Az.CloudHealth.format.ps1xml'
  FunctionsToExport = 'Add-AzMonitorHealthModelEntityDataAnnotation', 'Get-AzMonitorHealthModel', 'Get-AzMonitorHealthModelAuthenticationSetting', 'Get-AzMonitorHealthModelDiscoveryRule', 'Get-AzMonitorHealthModelEntity', 'Get-AzMonitorHealthModelEntityDataAnnotation', 'Get-AzMonitorHealthModelEntityHistory', 'Get-AzMonitorHealthModelEntitySignalHistory', 'Get-AzMonitorHealthModelEntitySignalRecommendation', 'Get-AzMonitorHealthModelRelationship', 'Get-AzMonitorHealthModelSignalDefinition', 'Invoke-AzMonitorHealthModelIngestEntityHealthReport', 'New-AzMonitorHealthModel', 'New-AzMonitorHealthModelApplicationInsightsTopologySpecificationObject', 'New-AzMonitorHealthModelAuthenticationSetting', 'New-AzMonitorHealthModelDiscoveryRule', 'New-AzMonitorHealthModelEntity', 'New-AzMonitorHealthModelEvaluationRuleObject', 'New-AzMonitorHealthModelLogAnalyticsQuerySignalDefinitionPropertiesObject', 'New-AzMonitorHealthModelManagedIdentityAuthenticationSettingPropertiesObject', 'New-AzMonitorHealthModelPrometheusMetricsSignalDefinitionPropertiesObject', 'New-AzMonitorHealthModelRelationship', 'New-AzMonitorHealthModelResourceGraphQuerySpecificationObject', 'New-AzMonitorHealthModelResourceMetricSignalDefinitionPropertiesObject', 'New-AzMonitorHealthModelSignalDefinition', 'New-AzMonitorHealthModelThresholdRuleV2Object', 'Remove-AzMonitorHealthModel', 'Remove-AzMonitorHealthModelAuthenticationSetting', 'Remove-AzMonitorHealthModelDiscoveryRule', 'Remove-AzMonitorHealthModelEntity', 'Remove-AzMonitorHealthModelRelationship', 'Remove-AzMonitorHealthModelSignalDefinition', 'Update-AzMonitorHealthModel', 'Update-AzMonitorHealthModelAuthenticationSetting', 'Update-AzMonitorHealthModelDiscoveryRule', 'Update-AzMonitorHealthModelEntity', 'Update-AzMonitorHealthModelRelationship', 'Update-AzMonitorHealthModelSignalDefinition'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'CloudHealth'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
