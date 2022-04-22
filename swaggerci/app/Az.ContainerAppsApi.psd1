@{
  GUID = 'b9654583-90a1-4207-95b5-333c72ee539d'
  RootModule = './Az.ContainerAppsApi.psm1'
  ModuleVersion = '0.1.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: ContainerAppsApi cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.ContainerAppsApi.private.dll'
  FormatsToProcess = './Az.ContainerAppsApi.format.ps1xml'
  FunctionsToExport = 'Get-AzContainerAppsApiCertificate', 'Get-AzContainerAppsApiContainerApp', 'Get-AzContainerAppsApiContainerAppAuthConfig', 'Get-AzContainerAppsApiContainerAppCustomHostNameAnalysis', 'Get-AzContainerAppsApiContainerAppRevision', 'Get-AzContainerAppsApiContainerAppRevisionReplica', 'Get-AzContainerAppsApiContainerAppsAuthConfig', 'Get-AzContainerAppsApiContainerAppSecret', 'Get-AzContainerAppsApiContainerAppSourceControl', 'Get-AzContainerAppsApiContainerAppsSourceControl', 'Get-AzContainerAppsApiDaprComponent', 'Get-AzContainerAppsApiDaprComponentSecret', 'Get-AzContainerAppsApiManagedEnvironment', 'Get-AzContainerAppsApiManagedEnvironmentsStorage', 'Initialize-AzContainerAppsApiContainerAppRevision', 'Invoke-AzContainerAppsApiDeactivateContainerAppRevision', 'New-AzContainerAppsApiCertificate', 'New-AzContainerAppsApiContainerApp', 'New-AzContainerAppsApiContainerAppAuthConfig', 'New-AzContainerAppsApiContainerAppSourceControl', 'New-AzContainerAppsApiDaprComponent', 'New-AzContainerAppsApiManagedEnvironment', 'New-AzContainerAppsApiManagedEnvironmentStorage', 'Remove-AzContainerAppsApiCertificate', 'Remove-AzContainerAppsApiContainerApp', 'Remove-AzContainerAppsApiContainerAppsAuthConfig', 'Remove-AzContainerAppsApiContainerAppsSourceControl', 'Remove-AzContainerAppsApiDaprComponent', 'Remove-AzContainerAppsApiManagedEnvironment', 'Remove-AzContainerAppsApiManagedEnvironmentsStorage', 'Restart-AzContainerAppsApiContainerAppRevision', 'Test-AzContainerAppsApiNamespaceNameAvailability', 'Update-AzContainerAppsApiCertificate', 'Update-AzContainerAppsApiContainerApp', 'Update-AzContainerAppsApiManagedEnvironment', '*'
  AliasesToExport = '*'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'ContainerAppsApi'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
