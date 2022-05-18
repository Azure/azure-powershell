@{
  GUID = 'd26b4cc7-1502-410b-9c3d-a553c0d2d624'
  RootModule = './Az.App.psm1'
  ModuleVersion = '0.1.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: App cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.App.private.dll'
  FormatsToProcess = './Az.App.format.ps1xml'
  FunctionsToExport = 'Disable-AzContainerAppRevision', 'Enable-AzContainerAppRevision', 'Get-AzContainerApp', 'Get-AzContainerAppAuthConfig', 'Get-AzContainerAppCustomHostName', 'Get-AzContainerAppManagedEnv', 'Get-AzContainerAppManagedEnvCert', 'Get-AzContainerAppManagedEnvDapr', 'Get-AzContainerAppManagedEnvDaprSecret', 'Get-AzContainerAppManagedEnvStorage', 'Get-AzContainerAppRevision', 'Get-AzContainerAppRevisionReplica', 'Get-AzContainerAppsAuthConfig', 'Get-AzContainerAppSecret', 'Get-AzContainerAppSourceControl', 'Get-AzContainerAppsSourceControl', 'New-AzContainer', 'New-AzContainerApp', 'New-AzContainerAppAuthConfig', 'New-AzContainerAppManagedEnv', 'New-AzContainerAppManagedEnvCert', 'New-AzContainerAppManagedEnvDapr', 'New-AzContainerAppManagedEnvStorage', 'New-AzContainerAppProbe', 'New-AzContainerAppSourceControl', 'New-AzCustomDomain', 'New-AzCustomScaleRuleMetadata', 'New-AzDaprMetadata', 'New-AzEnvironmentVar', 'New-AzHttpScaleRuleMetadata', 'New-AzIdentityProviders', 'New-AzIdentityProvidersCustomOpenIdConnectProviders', 'New-AzRegistryCredentials', 'New-AzScaleRule', 'New-AzScaleRuleAuth', 'New-AzSecret', 'New-AzTrafficWeight', 'New-AzVolume', 'New-AzVolumeMount', 'Remove-AzContainerApp', 'Remove-AzContainerAppAuthConfig', 'Remove-AzContainerAppManagedEnv', 'Remove-AzContainerAppManagedEnvCert', 'Remove-AzContainerAppManagedEnvDapr', 'Remove-AzContainerAppManagedEnvStorage', 'Remove-AzContainerAppSourceControl', 'Restart-AzContainerAppRevision', 'Update-AzContainerApp', 'Update-AzContainerAppManagedEnv', 'Update-AzContainerAppManagedEnvCert', '*'
  AliasesToExport = '*'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'App'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
