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
  FunctionsToExport = 'Disable-AzAppContainerAppRevision', 'Enable-AzAppContainerAppRevision', 'Get-AzAppAvailableWorkloadProfile', 'Get-AzAppBillingMeter', 'Get-AzAppConnectedEnvironment', 'Get-AzAppConnectedEnvironmentsCertificate', 'Get-AzAppConnectedEnvironmentsDaprComponent', 'Get-AzAppConnectedEnvironmentsDaprComponentSecret', 'Get-AzAppConnectedEnvironmentsStorage', 'Get-AzAppContainerApp', 'Get-AzAppContainerAppAuthConfig', 'Get-AzAppContainerAppAuthToken', 'Get-AzAppContainerAppCustomHostName', 'Get-AzAppContainerAppDiagnosticDetector', 'Get-AzAppContainerAppDiagnosticRevision', 'Get-AzAppContainerAppDiagnosticRoot', 'Get-AzAppContainerAppManagedEnv', 'Get-AzAppContainerAppManagedEnvCert', 'Get-AzAppContainerAppManagedEnvDapr', 'Get-AzAppContainerAppManagedEnvDaprSecret', 'Get-AzAppContainerAppManagedEnvStorage', 'Get-AzAppContainerAppRevision', 'Get-AzAppContainerAppRevisionReplica', 'Get-AzAppContainerAppSecret', 'Get-AzAppContainerAppSourceControl', 'Get-AzAppJob', 'Get-AzAppJobSecret', 'Get-AzAppJobsExecution', 'Get-AzAppManagedCertificate', 'Get-AzAppManagedEnvironmentAuthToken', 'Get-AzAppManagedEnvironmentDiagnosticDetector', 'Get-AzAppManagedEnvironmentsDiagnosticRoot', 'Get-AzAppManagedEnvironmentWorkloadProfileState', 'Invoke-AzAppJobExecution', 'New-AzAppConnectedEnvironment', 'New-AzAppConnectedEnvironmentsCertificate', 'New-AzAppConnectedEnvironmentsDaprComponent', 'New-AzAppConnectedEnvironmentsStorage', 'New-AzAppContainerApp', 'New-AzAppContainerAppAuthConfig', 'New-AzAppContainerAppManagedEnv', 'New-AzAppContainerAppManagedEnvCert', 'New-AzAppContainerAppManagedEnvDapr', 'New-AzAppContainerAppManagedEnvStorage', 'New-AzAppContainerAppSourceControl', 'New-AzAppJob', 'New-AzAppManagedCertificate', 'Remove-AzAppConnectedEnvironment', 'Remove-AzAppConnectedEnvironmentsCertificate', 'Remove-AzAppConnectedEnvironmentsDaprComponent', 'Remove-AzAppConnectedEnvironmentsStorage', 'Remove-AzAppContainerApp', 'Remove-AzAppContainerAppAuthConfig', 'Remove-AzAppContainerAppManagedEnv', 'Remove-AzAppContainerAppManagedEnvCert', 'Remove-AzAppContainerAppManagedEnvDapr', 'Remove-AzAppContainerAppManagedEnvStorage', 'Remove-AzAppContainerAppSourceControl', 'Remove-AzAppJob', 'Remove-AzAppManagedCertificate', 'Restart-AzAppContainerAppRevision', 'Start-AzAppContainerApp', 'Start-AzAppJob', 'Stop-AzAppContainerApp', 'Stop-AzAppJobExecution', 'Stop-AzAppJobMultipleExecution', 'Test-AzAppConnectedEnvironmentNameAvailability', 'Test-AzAppNamespaceNameAvailability', 'Update-AzAppConnectedEnvironment', 'Update-AzAppConnectedEnvironmentsCertificate', 'Update-AzAppConnectedEnvironmentsDaprComponent', 'Update-AzAppConnectedEnvironmentsStorage', 'Update-AzAppContainerApp', 'Update-AzAppContainerAppAuthConfig', 'Update-AzAppContainerAppManagedEnv', 'Update-AzAppContainerAppManagedEnvCert', 'Update-AzAppContainerAppManagedEnvDapr', 'Update-AzAppContainerAppManagedEnvStorage', 'Update-AzAppContainerAppSourceControl', 'Update-AzAppJob', 'Update-AzAppManagedCertificate'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'App'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
