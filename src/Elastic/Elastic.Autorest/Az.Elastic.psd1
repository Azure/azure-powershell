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
  FunctionsToExport = 'Get-AzElasticAllTrafficFilter', 'Get-AzElasticBillingInfo', 'Get-AzElasticConnectedPartnerResource', 'Get-AzElasticDeploymentInfo', 'Get-AzElasticDetailUpgradableVersion', 'Get-AzElasticDetailVMIngestion', 'Get-AzElasticListAssociatedTrafficFilter', 'Get-AzElasticMonitor', 'Get-AzElasticMonitoredResource', 'Get-AzElasticOpenAi', 'Get-AzElasticOpenAiStatus', 'Get-AzElasticOrganizationApiKey', 'Get-AzElasticOrganizationElasticToAzureSubscriptionMapping', 'Get-AzElasticTagRule', 'Get-AzElasticVersion', 'Get-AzElasticVMHost', 'Join-AzElasticAssociateTrafficFilter', 'New-AzElasticCreateAndAssociateIPFilter', 'New-AzElasticCreateAndAssociatePlFilter', 'New-AzElasticExternalUser', 'New-AzElasticFilteringTagObject', 'New-AzElasticMonitor', 'New-AzElasticOpenAi', 'New-AzElasticTagRule', 'Remove-AzElasticDetachAndDeleteTrafficFilter', 'Remove-AzElasticMonitor', 'Remove-AzElasticOpenAi', 'Remove-AzElasticTrafficFilter', 'Update-AzElasticDetachTrafficFilter', 'Update-AzElasticExternalUser', 'Update-AzElasticMonitor', 'Update-AzElasticVMCollection', '*'
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
