@{
  GUID = '31cbb5e8-747f-4f2f-8eaa-cf4f6b5206d5'
  RootModule = './Az.CognitiveServices.psm1'
  ModuleVersion = '0.1.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: CognitiveServices cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.CognitiveServices.private.dll'
  FormatsToProcess = './Az.CognitiveServices.format.ps1xml'
  FunctionsToExport = 'Clear-AzCognitiveServicesDeletedAccount', 'Get-AzCognitiveServicesAccount', 'Get-AzCognitiveServicesAccountKey', 'Get-AzCognitiveServicesAccountModel', 'Get-AzCognitiveServicesAccountSku', 'Get-AzCognitiveServicesAccountUsage', 'Get-AzCognitiveServicesCommitmentPlan', 'Get-AzCognitiveServicesCommitmentTier', 'Get-AzCognitiveServicesDeletedAccount', 'Get-AzCognitiveServicesDeployment', 'Get-AzCognitiveServicesPrivateEndpointConnection', 'Get-AzCognitiveServicesPrivateLinkResource', 'Get-AzCognitiveServicesResourceSku', 'New-AzCognitiveServicesAccount', 'New-AzCognitiveServicesAccountKey', 'New-AzCognitiveServicesCommitmentPlan', 'New-AzCognitiveServicesDeployment', 'New-AzCognitiveServicesPrivateEndpointConnection', 'Remove-AzCognitiveServicesAccount', 'Remove-AzCognitiveServicesCommitmentPlan', 'Remove-AzCognitiveServicesDeployment', 'Remove-AzCognitiveServicesPrivateEndpointConnection', 'Test-AzCognitiveServicesDomainAvailability', 'Test-AzCognitiveServicesSkuAvailability', 'Update-AzCognitiveServicesAccount', '*'
  AliasesToExport = '*'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'CognitiveServices'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
