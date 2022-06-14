@{
  GUID = '5f4518b3-56dc-49ef-b10c-6cfc0b42ed30'
  RootModule = './Az.Elastic.psm1'
  ModuleVersion = '0.1.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: Elastic cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.Elastic.private.dll'
  FormatsToProcess = './Az.Elastic.format.ps1xml'
  FunctionsToExport = 'Get-AzElasticDeploymentInfo', 'Get-AzElasticMonitor', 'Get-AzElasticMonitoredResource', 'Get-AzElasticTagRule', 'Get-AzElasticVMHost', 'Invoke-AzElasticDetailVMIngestion', 'New-AzElasticMonitor', 'New-AzElasticTagRule', 'Remove-AzElasticMonitor', 'Remove-AzElasticTagRule', 'Update-AzElasticMonitor', 'Update-AzElasticVMCollection', '*'
  AliasesToExport = '*'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'Elastic'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
