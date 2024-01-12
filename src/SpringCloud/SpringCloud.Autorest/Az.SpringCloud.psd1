@{
  GUID = '697e18d3-95de-4211-86a1-ec7c4e163874'
  RootModule = './Az.SpringCloud.psm1'
  ModuleVersion = '0.1.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: SpringCloud cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.SpringCloud.private.dll'
  FormatsToProcess = './Az.SpringCloud.format.ps1xml'
  FunctionsToExport = 'Deploy-AzSpringCloudApp', 'Disable-AzSpringCloudTestEndpoint', 'Enable-AzSpringCloudTestEndpoint', 'Get-AzSpringCloud', 'Get-AzSpringCloudApp', 'Get-AzSpringCloudAppBinding', 'Get-AzSpringCloudAppCustomDomain', 'Get-AzSpringCloudAppDeployment', 'Get-AzSpringCloudAppDeploymentLogFileUrl', 'Get-AzSpringCloudBuildpackBinding', 'Get-AzSpringCloudBuildService', 'Get-AzSpringCloudBuildServiceAgentPool', 'Get-AzSpringCloudBuildServiceBuilder', 'Get-AzSpringCloudBuildServiceSupportedBuildpack', 'Get-AzSpringCloudBuildServiceSupportedStack', 'Get-AzSpringCloudCertificate', 'Get-AzSpringCloudConfigServer', 'Get-AzSpringCloudConfigurationService', 'Get-AzSpringCloudMonitoringSetting', 'Get-AzSpringCloudRegistry', 'Get-AzSpringCloudRuntimeVersion', 'Get-AzSpringCloudSku', 'Get-AzSpringCloudTestKey', 'New-AzSpringCloud', 'New-AzSpringCloudApp', 'New-AzSpringCloudAppBinding', 'New-AzSpringCloudAppCustomDomain', 'New-AzSpringCloudAppDeployment', 'New-AzSpringCloudAppDeploymentBuildResultObject', 'New-AzSpringCloudAppDeploymentJarUploadedObject', 'New-AzSpringCloudAppDeploymentNetCoreZipUploadedObject', 'New-AzSpringCloudAppDeploymentSourceUploadedObject', 'New-AzSpringCloudAppLoadedCertificateObject', 'New-AzSpringCloudBuildpackBinding', 'New-AzSpringCloudBuildpackObject', 'New-AzSpringCloudBuildpacksGroupObject', 'New-AzSpringCloudBuildServiceAgentPool', 'New-AzSpringCloudBuildServiceBuilder', 'New-AzSpringCloudCertificate', 'New-AzSpringCloudConfigurationService', 'New-AzSpringCloudConfigurationServiceGitRepositoryObject', 'New-AzSpringCloudContentCertificateObject', 'New-AzSpringCloudGitPatternRepositoryObject', 'New-AzSpringCloudKeyVaultCertificateObject', 'New-AzSpringCloudTestKey', 'Remove-AzSpringCloud', 'Remove-AzSpringCloudApp', 'Remove-AzSpringCloudAppBinding', 'Remove-AzSpringCloudAppCustomDomain', 'Remove-AzSpringCloudAppDeployment', 'Remove-AzSpringCloudBuildpackBinding', 'Remove-AzSpringCloudBuildServiceBuilder', 'Remove-AzSpringCloudCertificate', 'Remove-AzSpringCloudConfigurationService', 'Restart-AzSpringCloudAppDeployment', 'Start-AzSpringCloudAppDeployment', 'Start-AzSpringCloudAppDeploymentJfr', 'Stop-AzSpringCloudAppDeployment', 'Test-AzSpringCloudAppCustomDomain', 'Test-AzSpringCloudConfigServer', 'Test-AzSpringCloudConfigurationService', 'Test-AzSpringCloudNameAvailability', 'Update-AzSpringCloud', 'Update-AzSpringCloudApp', 'Update-AzSpringCloudAppActiveDeployment', 'Update-AzSpringCloudAppBinding', 'Update-AzSpringCloudAppCustomDomain', 'Update-AzSpringCloudAppDeployment', 'Update-AzSpringCloudConfigServer', 'Update-AzSpringCloudMonitoringSetting', '*'
  AliasesToExport = '*'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'SpringCloud'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
