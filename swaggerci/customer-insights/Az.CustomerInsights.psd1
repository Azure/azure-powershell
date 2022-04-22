@{
  GUID = '94a47bd2-d95b-4c67-8630-0a7712930fa5'
  RootModule = './Az.CustomerInsights.psm1'
  ModuleVersion = '0.1.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: CustomerInsights cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.CustomerInsights.private.dll'
  FormatsToProcess = './Az.CustomerInsights.format.ps1xml'
  FunctionsToExport = 'Get-AzCustomerInsightsAuthorizationPolicy', 'Get-AzCustomerInsightsConnector', 'Get-AzCustomerInsightsConnectorMapping', 'Get-AzCustomerInsightsHub', 'Get-AzCustomerInsightsImageUploadUrl', 'Get-AzCustomerInsightsInteraction', 'Get-AzCustomerInsightsInteractionRelationshipLink', 'Get-AzCustomerInsightsKpi', 'Get-AzCustomerInsightsLink', 'Get-AzCustomerInsightsPrediction', 'Get-AzCustomerInsightsPredictionModelStatus', 'Get-AzCustomerInsightsPredictionTrainingResult', 'Get-AzCustomerInsightsProfile', 'Get-AzCustomerInsightsProfileEnrichingKpi', 'Get-AzCustomerInsightsRelationship', 'Get-AzCustomerInsightsRelationshipLink', 'Get-AzCustomerInsightsRole', 'Get-AzCustomerInsightsRoleAssignment', 'Get-AzCustomerInsightsView', 'Get-AzCustomerInsightsWidgetType', 'Invoke-AzCustomerInsightsModelPredictionStatus', 'New-AzCustomerInsightsAuthorizationPolicy', 'New-AzCustomerInsightsAuthorizationPolicyPrimaryKey', 'New-AzCustomerInsightsAuthorizationPolicySecondaryKey', 'New-AzCustomerInsightsConnector', 'New-AzCustomerInsightsConnectorMapping', 'New-AzCustomerInsightsHub', 'New-AzCustomerInsightsInteraction', 'New-AzCustomerInsightsKpi', 'New-AzCustomerInsightsLink', 'New-AzCustomerInsightsPrediction', 'New-AzCustomerInsightsProfile', 'New-AzCustomerInsightsRelationship', 'New-AzCustomerInsightsRelationshipLink', 'New-AzCustomerInsightsRoleAssignment', 'New-AzCustomerInsightsView', 'Remove-AzCustomerInsightsConnector', 'Remove-AzCustomerInsightsConnectorMapping', 'Remove-AzCustomerInsightsHub', 'Remove-AzCustomerInsightsKpi', 'Remove-AzCustomerInsightsLink', 'Remove-AzCustomerInsightsPrediction', 'Remove-AzCustomerInsightsProfile', 'Remove-AzCustomerInsightsRelationship', 'Remove-AzCustomerInsightsRelationshipLink', 'Remove-AzCustomerInsightsRoleAssignment', 'Remove-AzCustomerInsightsView', 'Update-AzCustomerInsightsHub', 'Update-AzCustomerInsightsKpi', '*'
  AliasesToExport = '*'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'CustomerInsights'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
