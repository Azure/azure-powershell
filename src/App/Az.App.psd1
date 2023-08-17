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
  FunctionsToExport = 'Disable-AzContainerAppRevision', 'Enable-AzContainerAppRevision', 'Get-AzContainerApp', 'Get-AzContainerAppAuthConfig', 'Get-AzContainerAppAuthToken', 'Get-AzContainerAppAvailableWorkloadProfile', 'Get-AzContainerAppBillingMeter', 'Get-AzContainerAppConnectedEnv', 'Get-AzContainerAppConnectedEnvCert', 'Get-AzContainerAppConnectedEnvDapr', 'Get-AzContainerAppConnectedEnvDaprSecret', 'Get-AzContainerAppConnectedEnvStorage', 'Get-AzContainerAppCustomHostName', 'Get-AzContainerAppDiagnosticDetector', 'Get-AzContainerAppDiagnosticRevision', 'Get-AzContainerAppDiagnosticRoot', 'Get-AzContainerAppJob', 'Get-AzContainerAppJobExecution', 'Get-AzContainerAppJobSecret', 'Get-AzContainerAppManagedCert', 'Get-AzContainerAppManagedEnv', 'Get-AzContainerAppManagedEnvAuthToken', 'Get-AzContainerAppManagedEnvCert', 'Get-AzContainerAppManagedEnvDapr', 'Get-AzContainerAppManagedEnvDaprSecret', 'Get-AzContainerAppManagedEnvDiagnosticDetector', 'Get-AzContainerAppManagedEnvDiagnosticRoot', 'Get-AzContainerAppManagedEnvStorage', 'Get-AzContainerAppManagedEnvWorkloadProfileState', 'Get-AzContainerAppRevision', 'Get-AzContainerAppRevisionReplica', 'Get-AzContainerAppSecret', 'Get-AzContainerAppSourceControl', 'Invoke-AzContainerAppJobExecution', 'New-AzContainerApp', 'New-AzContainerAppAuthConfig', 'New-AzContainerAppConfigurationObject', 'New-AzContainerAppConnectedEnv', 'New-AzContainerAppConnectedEnvCert', 'New-AzContainerAppConnectedEnvDapr', 'New-AzContainerAppConnectedEnvStorage', 'New-AzContainerAppCustomDomainObject', 'New-AzContainerAppDaprMetadataObject', 'New-AzContainerAppEnvironmentVarObject', 'New-AzContainerAppIdentityProvidersObject', 'New-AzContainerAppInitContainerObject', 'New-AzContainerAppIPSecurityRestrictionRuleObject', 'New-AzContainerAppJob', 'New-AzContainerAppJobExecutionContainerObject', 'New-AzContainerAppJobScaleRuleObject', 'New-AzContainerAppManagedCert', 'New-AzContainerAppManagedEnv', 'New-AzContainerAppManagedEnvCert', 'New-AzContainerAppManagedEnvDapr', 'New-AzContainerAppManagedEnvStorage', 'New-AzContainerAppObject', 'New-AzContainerAppProbeHttpGetHttpHeadersItemObject', 'New-AzContainerAppProbeObject', 'New-AzContainerAppRegistryCredentialsObject', 'New-AzContainerAppScaleRuleAuthObject', 'New-AzContainerAppScaleRuleObject', 'New-AzContainerAppSecretObject', 'New-AzContainerAppSecretVolumeItemObject', 'New-AzContainerAppServiceBindObject', 'New-AzContainerAppSourceControl', 'New-AzContainerAppTrafficWeightObject', 'New-AzContainerAppVolumeMountObject', 'New-AzContainerAppVolumeObject', 'New-AzContainerAppWorkloadProfileObject', 'Remove-AzContainerApp', 'Remove-AzContainerAppAuthConfig', 'Remove-AzContainerAppConnectedEnv', 'Remove-AzContainerAppConnectedEnvCert', 'Remove-AzContainerAppConnectedEnvDapr', 'Remove-AzContainerAppConnectedEnvStorage', 'Remove-AzContainerAppJob', 'Remove-AzContainerAppManagedCert', 'Remove-AzContainerAppManagedEnv', 'Remove-AzContainerAppManagedEnvCert', 'Remove-AzContainerAppManagedEnvDapr', 'Remove-AzContainerAppManagedEnvStorage', 'Remove-AzContainerAppSourceControl', 'Restart-AzContainerAppRevision', 'Start-AzContainerApp', 'Start-AzContainerAppJob', 'Stop-AzContainerApp', 'Stop-AzContainerAppJobExecution', 'Stop-AzContainerAppJobMultipleExecution', 'Test-AzContainerAppConnectedEnvNameAvailability', 'Test-AzContainerAppNamespaceAvailability', 'Update-AzContainerApp', 'Update-AzContainerAppAuthConfig', 'Update-AzContainerAppConnectedEnvCert', 'Update-AzContainerAppConnectedEnvDapr', 'Update-AzContainerAppConnectedEnvStorage', 'Update-AzContainerAppJob', 'Update-AzContainerAppManagedCert', 'Update-AzContainerAppManagedEnv', 'Update-AzContainerAppManagedEnvCert', 'Update-AzContainerAppManagedEnvDapr', 'Update-AzContainerAppManagedEnvStorage', 'Update-AzContainerAppSourceControl'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'App'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
