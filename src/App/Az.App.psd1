@{
  GUID = 'd26b4cc7-1502-410b-9c3d-a553c0d2d624'
  RootModule = './Az.App.psm1'
  ModuleVersion = '0.2.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: App cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.App.private.dll'
  FormatsToProcess = './Az.App.format.ps1xml'
  FunctionsToExport = 'Disable-AzAppContainerAppRevision', 'Enable-AzAppContainerAppRevision', 'Get-AzAppAvailableWorkloadProfile', 'Get-AzAppBillingMeter', 'Get-AzAppConnectedEnv', 'Get-AzAppConnectedEnvCert', 'Get-AzAppConnectedEnvDapr', 'Get-AzAppConnectedEnvDaprSecret', 'Get-AzAppConnectedEnvStorage', 'Get-AzAppContainerApp', 'Get-AzAppContainerAppAuthConfig', 'Get-AzAppContainerAppAuthToken', 'Get-AzAppContainerAppCustomHostName', 'Get-AzAppContainerAppDiagnosticDetector', 'Get-AzAppContainerAppDiagnosticRevision', 'Get-AzAppContainerAppDiagnosticRoot', 'Get-AzAppContainerAppManagedEnv', 'Get-AzAppContainerAppManagedEnvCert', 'Get-AzAppContainerAppManagedEnvDapr', 'Get-AzAppContainerAppManagedEnvDaprSecret', 'Get-AzAppContainerAppManagedEnvStorage', 'Get-AzAppContainerAppRevision', 'Get-AzAppContainerAppRevisionReplica', 'Get-AzAppContainerAppSecret', 'Get-AzAppContainerAppSourceControl', 'Get-AzAppJob', 'Get-AzAppJobSecret', 'Get-AzAppJobsExecution', 'Get-AzAppManagedCert', 'Get-AzAppManagedEnvAuthToken', 'Get-AzAppManagedEnvDiagnosticDetector', 'Get-AzAppManagedEnvDiagnosticRoot', 'Get-AzAppManagedEnvWorkloadProfileState', 'Invoke-AzAppJobExecution', 'New-AzAppConfigurationObject', 'New-AzAppConnectedEnv', 'New-AzAppConnectedEnvCert', 'New-AzAppConnectedEnvDapr', 'New-AzAppConnectedEnvStorage', 'New-AzAppContainerApp', 'New-AzAppContainerAppAuthConfig', 'New-AzAppContainerAppManagedEnv', 'New-AzAppContainerAppManagedEnvCert', 'New-AzAppContainerAppManagedEnvDapr', 'New-AzAppContainerAppManagedEnvStorage', 'New-AzAppContainerAppProbeHttpGetHttpHeadersItemObject', 'New-AzAppContainerAppProbeObject', 'New-AzAppContainerAppSourceControl', 'New-AzAppContainerObject', 'New-AzAppCustomDomainObject', 'New-AzAppDaprMetadataObject', 'New-AzAppEnvironmentVarObject', 'New-AzAppIdentityProvidersObject', 'New-AzAppInitContainerObject', 'New-AzAppIPSecurityRestrictionRuleObject', 'New-AzAppJob', 'New-AzAppJobExecutionContainerObject', 'New-AzAppJobScaleRuleObject', 'New-AzAppManagedCert', 'New-AzAppRegistryCredentialsObject', 'New-AzAppScaleRuleAuthObject', 'New-AzAppScaleRuleObject', 'New-AzAppSecretObject', 'New-AzAppSecretVolumeItemObject', 'New-AzAppServiceBindObject', 'New-AzAppTrafficWeightObject', 'New-AzAppVolumeMountObject', 'New-AzAppVolumeObject', 'New-AzAppWorkloadProfileObject', 'Remove-AzAppConnectedEnv', 'Remove-AzAppConnectedEnvCert', 'Remove-AzAppConnectedEnvDapr', 'Remove-AzAppConnectedEnvStorage', 'Remove-AzAppContainerApp', 'Remove-AzAppContainerAppAuthConfig', 'Remove-AzAppContainerAppManagedEnv', 'Remove-AzAppContainerAppManagedEnvCert', 'Remove-AzAppContainerAppManagedEnvDapr', 'Remove-AzAppContainerAppManagedEnvStorage', 'Remove-AzAppContainerAppSourceControl', 'Remove-AzAppJob', 'Remove-AzAppManagedCert', 'Restart-AzAppContainerAppRevision', 'Start-AzAppContainerApp', 'Start-AzAppJob', 'Stop-AzAppContainerApp', 'Stop-AzAppJobExecution', 'Stop-AzAppJobMultipleExecution', 'Test-AzAppConnectedEnvNameAvailability', 'Test-AzAppNamespaceAvailability', 'Update-AzAppConnectedEnv', 'Update-AzAppConnectedEnvCert', 'Update-AzAppConnectedEnvDapr', 'Update-AzAppConnectedEnvStorage', 'Update-AzAppContainerApp', 'Update-AzAppContainerAppAuthConfig', 'Update-AzAppContainerAppManagedEnv', 'Update-AzAppContainerAppManagedEnvCert', 'Update-AzAppContainerAppManagedEnvDapr', 'Update-AzAppContainerAppManagedEnvStorage', 'Update-AzAppContainerAppSourceControl', 'Update-AzAppJob', 'Update-AzAppManagedCert'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'App'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
