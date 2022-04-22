@{
  GUID = '7a836b39-209d-4483-9960-4162595590df'
  RootModule = './Az.AppPlatform.psm1'
  ModuleVersion = '0.1.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: AppPlatform cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.AppPlatform.private.dll'
  FormatsToProcess = './Az.AppPlatform.format.ps1xml'
  FunctionsToExport = 'Disable-AzAppPlatformServiceTestEndpoint', 'Enable-AzAppPlatformServiceTestEndpoint', 'Get-AzAppPlatformApiPortal', 'Get-AzAppPlatformApiPortalCustomDomain', 'Get-AzAppPlatformApp', 'Get-AzAppPlatformAppResourceUploadUrl', 'Get-AzAppPlatformBinding', 'Get-AzAppPlatformBuildpackBinding', 'Get-AzAppPlatformBuildService', 'Get-AzAppPlatformBuildServiceAgentPool', 'Get-AzAppPlatformBuildServiceBuild', 'Get-AzAppPlatformBuildServiceBuilder', 'Get-AzAppPlatformBuildServiceBuildResult', 'Get-AzAppPlatformBuildServiceBuildResultLog', 'Get-AzAppPlatformBuildServiceResourceUploadUrl', 'Get-AzAppPlatformBuildServiceSupportedBuildpack', 'Get-AzAppPlatformBuildServiceSupportedStack', 'Get-AzAppPlatformCertificate', 'Get-AzAppPlatformConfigServer', 'Get-AzAppPlatformConfigurationService', 'Get-AzAppPlatformCustomDomain', 'Get-AzAppPlatformDeployment', 'Get-AzAppPlatformDeploymentLogFileUrl', 'Get-AzAppPlatformGateway', 'Get-AzAppPlatformGatewayCustomDomain', 'Get-AzAppPlatformGatewayRouteConfig', 'Get-AzAppPlatformMonitoringSetting', 'Get-AzAppPlatformRuntimeVersion', 'Get-AzAppPlatformService', 'Get-AzAppPlatformServiceRegistry', 'Get-AzAppPlatformServiceTestKey', 'Get-AzAppPlatformSku', 'Get-AzAppPlatformStorage', 'New-AzAppPlatformApiPortal', 'New-AzAppPlatformApiPortalCustomDomain', 'New-AzAppPlatformApp', 'New-AzAppPlatformBinding', 'New-AzAppPlatformBuildpackBinding', 'New-AzAppPlatformBuildServiceBuild', 'New-AzAppPlatformBuildServiceBuilder', 'New-AzAppPlatformCertificate', 'New-AzAppPlatformConfigurationService', 'New-AzAppPlatformCustomDomain', 'New-AzAppPlatformDeployment', 'New-AzAppPlatformDeploymentHeapDump', 'New-AzAppPlatformDeploymentThreadDump', 'New-AzAppPlatformGateway', 'New-AzAppPlatformGatewayCustomDomain', 'New-AzAppPlatformGatewayRouteConfig', 'New-AzAppPlatformService', 'New-AzAppPlatformServiceTestKey', 'New-AzAppPlatformStorage', 'Remove-AzAppPlatformApiPortal', 'Remove-AzAppPlatformApiPortalCustomDomain', 'Remove-AzAppPlatformApp', 'Remove-AzAppPlatformBinding', 'Remove-AzAppPlatformBuildpackBinding', 'Remove-AzAppPlatformBuildServiceBuilder', 'Remove-AzAppPlatformCertificate', 'Remove-AzAppPlatformConfigurationService', 'Remove-AzAppPlatformCustomDomain', 'Remove-AzAppPlatformDeployment', 'Remove-AzAppPlatformGateway', 'Remove-AzAppPlatformGatewayCustomDomain', 'Remove-AzAppPlatformGatewayRouteConfig', 'Remove-AzAppPlatformService', 'Remove-AzAppPlatformServiceRegistry', 'Remove-AzAppPlatformStorage', 'Restart-AzAppPlatformDeployment', 'Start-AzAppPlatformDeployment', 'Start-AzAppPlatformDeploymentJfr', 'Start-AzAppPlatformService', 'Stop-AzAppPlatformDeployment', 'Stop-AzAppPlatformService', 'Test-AzAppPlatformApiPortalDomain', 'Test-AzAppPlatformAppDomain', 'Test-AzAppPlatformConfigServer', 'Test-AzAppPlatformConfigurationService', 'Test-AzAppPlatformGatewayDomain', 'Test-AzAppPlatformServiceNameAvailability', 'Update-AzAppPlatformApp', 'Update-AzAppPlatformBinding', 'Update-AzAppPlatformConfigServerPatch', 'Update-AzAppPlatformCustomDomain', 'Update-AzAppPlatformDeployment', 'Update-AzAppPlatformMonitoringSettingPatch', 'Update-AzAppPlatformService', '*'
  AliasesToExport = '*'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'AppPlatform'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
