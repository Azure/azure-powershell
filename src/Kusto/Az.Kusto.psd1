@{
  GUID = '18c61846-f6f0-425e-ba4b-5cf903e2bdd8'
  RootModule = './Az.Kusto.psm1'
  ModuleVersion = '0.1.4'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: Kusto cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.Kusto.private.dll'
  FormatsToProcess = './Az.Kusto.format.ps1xml'
  FunctionsToExport = 'Add-AzKustoClusterLanguageExtension', 'Add-AzKustoDatabasePrincipal', 'Get-AzKustoAttachedDatabaseConfiguration', 'Get-AzKustoCluster', 'Get-AzKustoClusterFollowerDatabase', 'Get-AzKustoClusterLanguageExtension', 'Get-AzKustoClusterOutboundNetworkDependencyEndpoint', 'Get-AzKustoClusterPrincipalAssignment', 'Get-AzKustoClusterSku', 'Get-AzKustoDatabase', 'Get-AzKustoDatabasePrincipal', 'Get-AzKustoDatabasePrincipalAssignment', 'Get-AzKustoDataConnection', 'Get-AzKustoManagedPrivateEndpoint', 'Get-AzKustoOperationsResult', 'Get-AzKustoOperationsResultLocation', 'Get-AzKustoPrivateEndpointConnection', 'Get-AzKustoPrivateLinkResource', 'Get-AzKustoScript', 'Get-AzKustoSku', 'Invoke-AzKustoDataConnectionValidation', 'Invoke-AzKustoDetachClusterFollowerDatabase', 'Invoke-AzKustoDiagnoseClusterVirtualNetwork', 'New-AzKustoAttachedDatabaseConfiguration', 'New-AzKustoCluster', 'New-AzKustoClusterPrincipalAssignment', 'New-AzKustoDatabase', 'New-AzKustoDatabasePrincipalAssignment', 'New-AzKustoDataConnection', 'New-AzKustoManagedPrivateEndpoint', 'New-AzKustoPrivateEndpointConnection', 'New-AzKustoScript', 'Remove-AzKustoAttachedDatabaseConfiguration', 'Remove-AzKustoCluster', 'Remove-AzKustoClusterLanguageExtension', 'Remove-AzKustoClusterPrincipalAssignment', 'Remove-AzKustoDatabase', 'Remove-AzKustoDatabasePrincipal', 'Remove-AzKustoDatabasePrincipalAssignment', 'Remove-AzKustoDataConnection', 'Remove-AzKustoManagedPrivateEndpoint', 'Remove-AzKustoPrivateEndpointConnection', 'Remove-AzKustoScript', 'Start-AzKustoCluster', 'Stop-AzKustoCluster', 'Test-AzKustoAttachedDatabaseConfigurationNameAvailability', 'Test-AzKustoClusterNameAvailability', 'Test-AzKustoClusterPrincipalAssignmentNameAvailability', 'Test-AzKustoDatabaseNameAvailability', 'Test-AzKustoDatabasePrincipalAssignmentNameAvailability', 'Test-AzKustoDataConnectionNameAvailability', 'Test-AzKustoManagedPrivateEndpointNameAvailability', 'Test-AzKustoScriptNameAvailability', 'Update-AzKustoCluster', 'Update-AzKustoDatabase', 'Update-AzKustoDataConnection', 'Update-AzKustoManagedPrivateEndpoint', 'Update-AzKustoScript', '*'
  AliasesToExport = '*'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'Kusto'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
