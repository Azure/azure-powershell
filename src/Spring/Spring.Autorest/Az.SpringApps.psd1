@{
  GUID = '7e7ae67c-2553-4801-9603-a949d5b4d3ca'
  RootModule = './Az.SpringApps.psm1'
  ModuleVersion = '0.1.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: SpringApps cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.SpringApps.private.dll'
  FormatsToProcess = './Az.SpringApps.format.ps1xml'
  FunctionsToExport = 'Deploy-AzSpringApp', 'Disable-AzSpringDeploymentRemoteDebugging', 'Disable-AzSpringTestEndpoint', 'Enable-AzSpringDeploymentRemoteDebugging', 'Enable-AzSpringTestEndpoint', 'Get-AzSpringApiPortal', 'Get-AzSpringApiPortalCustomDomain', 'Get-AzSpringApp', 'Get-AzSpringAppCustomDomain', 'Get-AzSpringAppDeployment', 'Get-AzSpringAppDeploymentLogFileUrl', 'Get-AzSpringAppDeploymentRemoteDebuggingConfig', 'Get-AzSpringBuildpackBinding', 'Get-AzSpringBuildService', 'Get-AzSpringBuildServiceAgentPool', 'Get-AzSpringBuildServiceBuilder', 'Get-AzSpringBuildServiceBuilderDeployment', 'Get-AzSpringBuildServiceSupportedBuildpack', 'Get-AzSpringBuildServiceSupportedStack', 'Get-AzSpringCertificate', 'Get-AzSpringCloudGateway', 'Get-AzSpringCloudGatewayCustomDomain', 'Get-AzSpringCloudGatewayRouteConfig', 'Get-AzSpringConfigServer', 'Get-AzSpringConfigurationService', 'Get-AzSpringMonitoringSetting', 'Get-AzSpringService', 'Get-AzSpringServiceRegistry', 'Get-AzSpringStorage', 'Get-AzSpringTestKey', 'New-AzSpringApiPortal', 'New-AzSpringApiPortalCustomDomain', 'New-AzSpringApp', 'New-AzSpringAppActiveDeploymentCollectionObject', 'New-AzSpringAppCustomDomain', 'New-AzSpringAppDeployment', 'New-AzSpringAppDeploymentBuildResultObject', 'New-AzSpringAppDeploymentJarUploadedObject', 'New-AzSpringAppDeploymentNetCoreZipUploadedObject', 'New-AzSpringAppDeploymentSettingAddonConfigObject', 'New-AzSpringAppDeploymentSettingEnvVariableObject', 'New-AzSpringAppDeploymentSettingObject', 'New-AzSpringAppDeploymentSourceUploadedObject', 'New-AzSpringAppLoadedCertificateObject', 'New-AzSpringBuildpackBinding', 'New-AzSpringBuildpackObject', 'New-AzSpringBuildpacksGroupObject', 'New-AzSpringBuildServiceAgentPool', 'New-AzSpringBuildServiceBuilder', 'New-AzSpringCertificate', 'New-AzSpringCloudGateway', 'New-AzSpringCloudGatewayApiRouteObject', 'New-AzSpringCloudGatewayCustomDomain', 'New-AzSpringCloudGatewayRouteConfig', 'New-AzSpringConfigurationService', 'New-AzSpringConfigurationServiceGitObject', 'New-AzSpringContentCertificateObject', 'New-AzSpringCustomPersistentDiskResourceObject', 'New-AzSpringGitPatternObject', 'New-AzSpringKeyVaultCertificateObject', 'New-AzSpringService', 'New-AzSpringServiceRegistry', 'New-AzSpringStorage', 'New-AzSpringTestKey', 'Remove-AzSpringApiPortal', 'Remove-AzSpringApiPortalCustomDomain', 'Remove-AzSpringApp', 'Remove-AzSpringAppCustomDomain', 'Remove-AzSpringAppDeployment', 'Remove-AzSpringBuildpackBinding', 'Remove-AzSpringBuildServiceBuilder', 'Remove-AzSpringCertificate', 'Remove-AzSpringCloudGateway', 'Remove-AzSpringCloudGatewayCustomDomain', 'Remove-AzSpringCloudGatewayRouteConfig', 'Remove-AzSpringConfigurationService', 'Remove-AzSpringService', 'Remove-AzSpringStorage', 'Restart-AzSpringAppDeployment', 'Start-AzSpringAppDeployment', 'Start-AzSpringAppDeploymentJfr', 'Start-AzSpringService', 'Stop-AzSpringAppDeployment', 'Stop-AzSpringService', 'Test-AzSpringApiPortalDomain', 'Test-AzSpringAppCustomDomainNameAvailability', 'Test-AzSpringConfigServer', 'Test-AzSpringConfigurationService', 'Test-AzSpringGatewayDomain', 'Test-AzSpringNameAvailability', 'Update-AzSpringApiPortal', 'Update-AzSpringApiPortalCustomDomain', 'Update-AzSpringApp', 'Update-AzSpringAppActiveDeployment', 'Update-AzSpringAppCustomDomain', 'Update-AzSpringAppDeployment', 'Update-AzSpringBuildpackBinding', 'Update-AzSpringBuildService', 'Update-AzSpringBuildServiceAgentPool', 'Update-AzSpringBuildServiceBuilder', 'Update-AzSpringCertificate', 'Update-AzSpringCloudGateway', 'Update-AzSpringCloudGatewayCustomDomain', 'Update-AzSpringCloudGatewayRouteConfig', 'Update-AzSpringConfigServer', 'Update-AzSpringConfigurationService', 'Update-AzSpringMonitoringSetting', 'Update-AzSpringService', 'Update-AzSpringStorage'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'SpringApps'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
