@{
  GUID = '4318274c-45d2-46e8-b397-01b7ff341037'
  RootModule = './Az.ContainerApp.psm1'
  ModuleVersion = '0.1.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: ContainerApp cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.ContainerApp.private.dll'
  FormatsToProcess = './Az.ContainerApp.format.ps1xml'
  FunctionsToExport = 'Get-AzCertificate', 'Get-AzContainerApp', 'Get-AzContainerAppAuthConfig', 'Get-AzContainerAppCustomHostNameAnalysis', 'Get-AzContainerAppRevision', 'Get-AzContainerAppRevisionReplica', 'Get-AzContainerAppsAuthConfig', 'Get-AzContainerAppSecret', 'Get-AzContainerAppSourceControl', 'Get-AzContainerAppsSourceControl', 'Get-AzDaprComponent', 'Get-AzDaprComponentSecret', 'Get-AzManagedEnvironment', 'Get-AzManagedEnvironmentsStorage', 'Initialize-AzContainerAppRevision', 'Invoke-AzDeactivateContainerAppRevision', 'New-AzCertificate', 'New-AzContainerApp', 'New-AzContainerAppAuthConfig', 'New-AzContainerAppSourceControl', 'New-AzDaprComponent', 'New-AzManagedEnvironment', 'New-AzManagedEnvironmentStorage', 'Remove-AzCertificate', 'Remove-AzContainerApp', 'Remove-AzContainerAppsAuthConfig', 'Remove-AzContainerAppsSourceControl', 'Remove-AzDaprComponent', 'Remove-AzManagedEnvironment', 'Remove-AzManagedEnvironmentsStorage', 'Restart-AzContainerAppRevision', 'Update-AzCertificate', 'Update-AzContainerApp', 'Update-AzManagedEnvironment', '*'
  AliasesToExport = '*'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'ContainerApp'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
