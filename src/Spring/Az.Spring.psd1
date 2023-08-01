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
  FunctionsToExport = 'Deploy-AzSpringApp', 'Disable-AzSpringDeploymentRemoteDebugging', 'Disable-AzSpringTestEndpoint', 'Enable-AzSpringDeploymentRemoteDebugging', 'Enable-AzSpringTestEndpoint', 'Get-AzSpring', 'Get-AzSpringApiPortal', 'Get-AzSpringApiPortalCustomDomain', 'Get-AzSpringApp', 'Get-AzSpringAppBinding', 'Get-AzSpringAppCustomDomain', 'Get-AzSpringAppDeployment', 'Get-AzSpringAppDeploymentLogFileUrl', 'Get-AzSpringBuildpackBinding', 'Get-AzSpringBuildService', 'Get-AzSpringBuildServiceAgentPool', 'Get-AzSpringBuildServiceBuilder', 'Get-AzSpringBuildServiceBuilderDeployment', 'Get-AzSpringBuildServiceSupportedBuildpack', 'Get-AzSpringBuildServiceSupportedStack', 'Get-AzSpringCertificate', 'Get-AzSpringConfigServer', 'Get-AzSpringConfigurationService', 'Get-AzSpringDeploymentRemoteDebuggingConfig', 'Get-AzSpringGateway', 'Get-AzSpringGatewayCustomDomain', 'Get-AzSpringGatewayRouteConfig', 'Get-AzSpringMonitoringSetting', 'Get-AzSpringRegistry', 'Get-AzSpringRuntimeVersion', 'Get-AzSpringSku', 'Get-AzSpringStorage', 'Get-AzSpringTestKey', 'New-AzSpring', 'New-AzSpringApiPortal', 'New-AzSpringApiPortalCustomDomain', 'New-AzSpringApp', 'New-AzSpringAppBinding', 'New-AzSpringAppCustomDomain', 'New-AzSpringAppDeployment', 'New-AzSpringAppDeploymentBuildResultObject', 'New-AzSpringAppDeploymentJarUploadedObject', 'New-AzSpringAppDeploymentNetCoreZipUploadedObject', 'New-AzSpringAppDeploymentSourceUploadedObject', 'New-AzSpringAppLoadedCertificateObject', 'New-AzSpringBuildpackBinding', 'New-AzSpringBuildpackObject', 'New-AzSpringBuildpacksGroupObject', 'New-AzSpringBuildServiceAgentPool', 'New-AzSpringBuildServiceBuilder', 'New-AzSpringCertificate', 'New-AzSpringConfigurationService', 'New-AzSpringConfigurationServiceGitRepositoryObject', 'New-AzSpringContentCertificateObject', 'New-AzSpringCustomPersistentDiskResourceObject', 'New-AzSpringDeploymentSettingObject', 'New-AzSpringGateway', 'New-AzSpringGatewayApiRouteObject', 'New-AzSpringGatewayCustomDomain', 'New-AzSpringGatewayRouteConfig', 'New-AzSpringGitPatternRepositoryObject', 'New-AzSpringKeyVaultCertificateObject', 'New-AzSpringStorage', 'New-AzSpringTestKey', 'Remove-AzSpring', 'Remove-AzSpringApiPortal', 'Remove-AzSpringApiPortalCustomDomain', 'Remove-AzSpringApp', 'Remove-AzSpringAppBinding', 'Remove-AzSpringAppCustomDomain', 'Remove-AzSpringAppDeployment', 'Remove-AzSpringBuildpackBinding', 'Remove-AzSpringBuildServiceBuilder', 'Remove-AzSpringCertificate', 'Remove-AzSpringConfigurationService', 'Remove-AzSpringGateway', 'Remove-AzSpringGatewayCustomDomain', 'Remove-AzSpringGatewayRouteConfig', 'Remove-AzSpringStorage', 'Restart-AzSpringAppDeployment', 'Start-AzSpring', 'Start-AzSpringAppDeployment', 'Stop-AzSpring', 'Stop-AzSpringAppDeployment', 'Test-AzSpringApiPortalDomain', 'Test-AzSpringAppCustomDomain', 'Test-AzSpringConfigServer', 'Test-AzSpringConfigurationService', 'Test-AzSpringGatewayDomain', 'Test-AzSpringNameAvailability', 'Update-AzSpring', 'Update-AzSpringApiPortal', 'Update-AzSpringApiPortalCustomDomain', 'Update-AzSpringApp', 'Update-AzSpringAppActiveDeployment', 'Update-AzSpringAppBinding', 'Update-AzSpringAppCustomDomain', 'Update-AzSpringAppDeployment', 'Update-AzSpringBuildService', 'Update-AzSpringBuildServiceAgentPool', 'Update-AzSpringBuildServiceBuilder', 'Update-AzSpringCertificate', 'Update-AzSpringConfigServer', 'Update-AzSpringConfigurationService', 'Update-AzSpringGateway', 'Update-AzSpringGatewayCustomDomain', 'Update-AzSpringGatewayRouteConfig', 'Update-AzSpringMonitoringSetting', 'Update-AzSpringStorage'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'Spring'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
