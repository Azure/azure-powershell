@{
  GUID = '6f17a12c-1e03-4fce-8cdc-25681756eef7'
  RootModule = './Az.Autoscale.psm1'
  ModuleVersion = '0.1.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: Autoscale cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.Autoscale.private.dll'
  FormatsToProcess = './Az.Autoscale.format.ps1xml'
  FunctionsToExport = 'Get-AzAutoscalePredictiveMetric', 'Get-AzAutoscaleSetting', 'New-AzAutoscaleNotificationObject', 'New-AzAutoscaleProfileObject', 'New-AzAutoscaleScaleRuleMetricDimensionObject', 'New-AzAutoscaleScaleRuleObject', 'New-AzAutoscaleSetting', 'New-AzAutoscaleWebhookNotificationObject', 'Remove-AzAutoscaleSetting', 'Update-AzAutoscaleSetting', '*'
  AliasesToExport = '*'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'Autoscale'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
