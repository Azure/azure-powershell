@{
  GUID = 'e4d67574-e99d-4cbf-ae32-b4c82f99f88a'
  RootModule = './Az.Metrics.psm1'
  ModuleVersion = '0.1.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: Metrics cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.Metrics.private.dll'
  FormatsToProcess = './Az.Metrics.format.ps1xml'
  FunctionsToExport = 'Get-AzMetricsBatch', 'Get-AzMetricsMetric', 'Get-AzMetricsMetricDefinition'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'Metrics'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
