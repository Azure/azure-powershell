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
  FunctionsToExport = 'Disable-AzContainerAppRevision', 'Enable-AzContainerAppRevision', 'Get-AzAvailableWorkloadProfile', 'Get-AzBillingMeter', 'Get-AzConnectedEnvironment', 'Get-AzConnectedEnvironmentsCertificate', 'Get-AzConnectedEnvironmentsDaprComponent', 'Get-AzConnectedEnvironmentsDaprComponentSecret', 'Get-AzConnectedEnvironmentsStorage', 'Get-AzContainerApp', 'Get-AzContainerAppAuthConfig', 'Get-AzContainerAppAuthToken', 'Get-AzContainerAppCustomHostName', 'Get-AzContainerAppDiagnosticDetector', 'Get-AzContainerAppDiagnosticRevision', 'Get-AzContainerAppDiagnosticRoot', 'Get-AzContainerAppManagedEnv', 'Get-AzContainerAppManagedEnvCert', 'Get-AzContainerAppManagedEnvDapr', 'Get-AzContainerAppManagedEnvDaprSecret', 'Get-AzContainerAppManagedEnvStorage', 'Get-AzContainerAppRevision', 'Get-AzContainerAppRevisionReplica', 'Get-AzContainerAppSecret', 'Get-AzContainerAppSourceControl', 'Get-AzJob', 'Get-AzJobSecret', 'Get-AzJobsExecution', 'Get-AzManagedCertificate', 'Get-AzManagedEnvironmentAuthToken', 'Get-AzManagedEnvironmentDiagnosticDetector', 'Get-AzManagedEnvironmentsDiagnosticRoot', 'Get-AzManagedEnvironmentWorkloadProfileState', 'Invoke-AzJobExecution', 'New-AzConnectedEnvironment', 'New-AzConnectedEnvironmentsCertificate', 'New-AzConnectedEnvironmentsDaprComponent', 'New-AzConnectedEnvironmentsStorage', 'New-AzContainerApp', 'New-AzContainerAppAuthConfig', 'New-AzContainerAppManagedEnv', 'New-AzContainerAppManagedEnvCert', 'New-AzContainerAppManagedEnvDapr', 'New-AzContainerAppManagedEnvStorage', 'New-AzContainerAppSourceControl', 'New-AzJob', 'New-AzManagedCertificate', 'Remove-AzConnectedEnvironment', 'Remove-AzConnectedEnvironmentsCertificate', 'Remove-AzConnectedEnvironmentsDaprComponent', 'Remove-AzConnectedEnvironmentsStorage', 'Remove-AzContainerApp', 'Remove-AzContainerAppAuthConfig', 'Remove-AzContainerAppManagedEnv', 'Remove-AzContainerAppManagedEnvCert', 'Remove-AzContainerAppManagedEnvDapr', 'Remove-AzContainerAppManagedEnvStorage', 'Remove-AzContainerAppSourceControl', 'Remove-AzJob', 'Remove-AzManagedCertificate', 'Restart-AzContainerAppRevision', 'Start-AzContainerApp', 'Start-AzJob', 'Stop-AzContainerApp', 'Stop-AzJobExecution', 'Stop-AzJobMultipleExecution', 'Test-AzConnectedEnvironmentNameAvailability', 'Test-AzNamespaceNameAvailability', 'Update-AzConnectedEnvironmentsCertificate', 'Update-AzConnectedEnvironmentsDaprComponent', 'Update-AzConnectedEnvironmentsStorage', 'Update-AzContainerApp', 'Update-AzContainerAppAuthConfig', 'Update-AzContainerAppManagedEnv', 'Update-AzContainerAppManagedEnvCert', 'Update-AzContainerAppManagedEnvDapr', 'Update-AzContainerAppManagedEnvStorage', 'Update-AzContainerAppSourceControl', 'Update-AzJob', 'Update-AzManagedCertificate'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'App'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
