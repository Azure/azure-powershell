@{
  GUID = 'ac429574-aa9e-48ba-b46c-129fe2b846d2'
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
  FunctionsToExport = 'Dismount-AzElasticTrafficFilter', 'Get-AzElasticAllTrafficFilter', 'Get-AzElasticAssociatedTrafficFilter', 'Get-AzElasticDeploymentInfo', 'Get-AzElasticDetailUpgradableVersion', 'Get-AzElasticDetailVMIngestion', 'Get-AzElasticMonitor', 'Get-AzElasticMonitoredResource', 'Get-AzElasticOrganizationApiKey', 'Get-AzElasticTagRule', 'Get-AzElasticVersion', 'Get-AzElasticVMHost', 'Mount-AzElasticTrafficFilter', 'New-AzElasticExternalUser', 'New-AzElasticFilteringTagObject', 'New-AzElasticIPFilter', 'New-AzElasticMonitor', 'New-AzElasticPrivateLinkFilter', 'New-AzElasticTagRule', 'Remove-AzElasticMonitor', 'Remove-AzElasticTrafficFilter', 'Remove-AzElasticUnassociatedTrafficFilter', 'Update-AzElasticExternalUser', 'Update-AzElasticMonitor', 'Update-AzElasticMonitorVersion', 'Update-AzElasticTagRule', 'Update-AzElasticVMCollection'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'Elastic'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
