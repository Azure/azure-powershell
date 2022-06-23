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
  FunctionsToExport = 'Disable-AzSpringCloudTestEndpoint', 'Enable-AzSpringCloudTestEndpoint', 'Get-AzSpringCloud', 'Get-AzSpringCloudApp', 'Get-AzSpringCloudAppBinding', 'Get-AzSpringCloudAppCustomDomain', 'Get-AzSpringCloudAppDeployment', 'Get-AzSpringCloudAppDeploymentLogFileUrl', 'Get-AzSpringCloudAppResourceUploadUrl', 'Get-AzSpringCloudBuildpackBinding', 'Get-AzSpringCloudBuildService', 'Get-AzSpringCloudBuildServiceAgentPool', 'Get-AzSpringCloudBuildServiceBuild', 'Get-AzSpringCloudBuildServiceBuilder', 'Get-AzSpringCloudBuildServiceBuildResult', 'Get-AzSpringCloudBuildServiceBuildResultLog', 'Get-AzSpringCloudBuildServiceResourceUploadUrl', 'Get-AzSpringCloudBuildServiceSupportedBuildpack', 'Get-AzSpringCloudBuildServiceSupportedStack', 'Get-AzSpringCloudCertificate', 'Get-AzSpringCloudConfigServer', 'Get-AzSpringCloudConfigurationService', 'Get-AzSpringCloudMonitoringSetting', 'Get-AzSpringCloudRegistry', 'Get-AzSpringCloudRuntimeVersion', 'Get-AzSpringCloudSku', 'Get-AzSpringCloudTestKey', 'New-AzSpringCloud', 'New-AzSpringCloudApp', 'New-AzSpringCloudAppBinding', 'New-AzSpringCloudAppCustomDomain', 'New-AzSpringCloudAppDeployment', 'New-AzSpringCloudAppDeploymentHeapDump', 'New-AzSpringCloudAppDeploymentThreadDump', 'New-AzSpringCloudAppLoadedCertificateObject', 'New-AzSpringCloudBuildpackBinding', 'New-AzSpringCloudBuildpackPropertiesObject', 'New-AzSpringCloudBuildpacksGroupPropertiesObject', 'New-AzSpringCloudBuildServiceBuild', 'New-AzSpringCloudBuildServiceBuilder', 'New-AzSpringCloudCertificate', 'New-AzSpringCloudConfigurationService', 'New-AzSpringCloudConfigurationServiceGitRepositoryObject', 'New-AzSpringCloudGitPatternRepositoryObject', 'New-AzSpringCloudTestKey', 'Remove-AzSpringCloud', 'Remove-AzSpringCloudApp', 'Remove-AzSpringCloudAppBinding', 'Remove-AzSpringCloudAppCustomDomain', 'Remove-AzSpringCloudAppDeployment', 'Remove-AzSpringCloudBuildpackBinding', 'Remove-AzSpringCloudBuildServiceBuilder', 'Remove-AzSpringCloudCertificate', 'Remove-AzSpringCloudConfigurationService', 'Remove-AzSpringCloudRegistry', 'Restart-AzSpringCloudAppDeployment', 'Start-AzSpringCloudAppDeployment', 'Start-AzSpringCloudAppDeploymentJfr', 'Stop-AzSpringCloudAppDeployment', 'Test-AzSpringCloudAppDomain', 'Test-AzSpringCloudConfigServer', 'Test-AzSpringCloudConfigurationService', 'Test-AzSpringCloudNameAvailability', 'Update-AzSpringCloud', 'Update-AzSpringCloudApp', 'Update-AzSpringCloudAppBinding', 'Update-AzSpringCloudAppCustomDomain', 'Update-AzSpringCloudAppDeployment', 'Update-AzSpringCloudConfigServer', 'Update-AzSpringCloudMonitoringSetting', '*'
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
