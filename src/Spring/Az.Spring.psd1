@{
  GUID = 'f3f8e32f-ee2e-4bbd-ae45-4a269662faec'
  RootModule = './Az.Spring.psm1'
  ModuleVersion = '0.1.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: Spring cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.Spring.private.dll'
  FormatsToProcess = './Az.Spring.format.ps1xml'
  FunctionsToExport = 'Deploy-AzSpringApp', 'Disable-AzSpringTestEndpoint', 'Enable-AzSpringTestEndpoint', 'Get-AzSpring', 'Get-AzSpringApp', 'Get-AzSpringAppBinding', 'Get-AzSpringAppCustomDomain', 'Get-AzSpringAppDeployment', 'Get-AzSpringAppDeploymentLogFileUrl', 'Get-AzSpringBuildpackBinding', 'Get-AzSpringBuildService', 'Get-AzSpringBuildServiceAgentPool', 'Get-AzSpringBuildServiceBuilder', 'Get-AzSpringBuildServiceSupportedBuildpack', 'Get-AzSpringBuildServiceSupportedStack', 'Get-AzSpringCertificate', 'Get-AzSpringConfigServer', 'Get-AzSpringConfigurationService', 'Get-AzSpringMonitoringSetting', 'Get-AzSpringRegistry', 'Get-AzSpringRuntimeVersion', 'Get-AzSpringSku', 'Get-AzSpringTestKey', 'New-AzSpring', 'New-AzSpringApp', 'New-AzSpringAppBinding', 'New-AzSpringAppCustomDomain', 'New-AzSpringAppDeployment', 'New-AzSpringAppDeploymentBuildResultObject', 'New-AzSpringAppDeploymentJarUploadedObject', 'New-AzSpringAppDeploymentNetCoreZipUploadedObject', 'New-AzSpringAppDeploymentSourceUploadedObject', 'New-AzSpringAppLoadedCertificateObject', 'New-AzSpringBuildpackBinding', 'New-AzSpringBuildpackObject', 'New-AzSpringBuildpacksGroupObject', 'New-AzSpringBuildServiceAgentPool', 'New-AzSpringBuildServiceBuilder', 'New-AzSpringCertificate', 'New-AzSpringConfigurationService', 'New-AzSpringConfigurationServiceGitRepositoryObject', 'New-AzSpringContentCertificateObject', 'New-AzSpringGitPatternRepositoryObject', 'New-AzSpringKeyVaultCertificateObject', 'New-AzSpringRegistry', 'New-AzSpringTestKey', 'Remove-AzSpring', 'Remove-AzSpringApp', 'Remove-AzSpringAppBinding', 'Remove-AzSpringAppCustomDomain', 'Remove-AzSpringAppDeployment', 'Remove-AzSpringBuildpackBinding', 'Remove-AzSpringBuildServiceBuilder', 'Remove-AzSpringCertificate', 'Remove-AzSpringConfigurationService', 'Restart-AzSpringAppDeployment', 'Start-AzSpringAppDeployment', 'Start-AzSpringAppDeploymentJfr', 'Stop-AzSpringAppDeployment', 'Test-AzSpringAppCustomDomain', 'Test-AzSpringConfigServer', 'Test-AzSpringConfigurationService', 'Test-AzSpringNameAvailability', 'Update-AzSpring', 'Update-AzSpringApp', 'Update-AzSpringAppActiveDeployment', 'Update-AzSpringAppBinding', 'Update-AzSpringAppCustomDomain', 'Update-AzSpringAppDeployment', 'Update-AzSpringBuildpackBinding', 'Update-AzSpringBuildService', 'Update-AzSpringBuildServiceAgentPool', 'Update-AzSpringBuildServiceBuilder', 'Update-AzSpringCertificate', 'Update-AzSpringConfigServer', 'Update-AzSpringConfigurationService', 'Update-AzSpringMonitoringSetting'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'Spring'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
