@{
  GUID = 'aa8fbb4e-739a-4b60-b500-11592e31aa54'
  RootModule = './Az.Synapse.psm1'
  ModuleVersion = '0.1.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: Synapse cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.Synapse.private.dll'
  FormatsToProcess = './Az.Synapse.format.ps1xml'
  FunctionsToExport = 'Add-AzSynapseKustoPoolLanguageExtension', 'Get-AzSynapseAttachedDatabaseConfiguration', 'Get-AzSynapseDatabase', 'Get-AzSynapseDatabasePrincipalAssignment', 'Get-AzSynapseDataConnection', 'Get-AzSynapseKustoOperation', 'Get-AzSynapseKustoPool', 'Get-AzSynapseKustoPoolFollowerDatabase', 'Get-AzSynapseKustoPoolLanguageExtension', 'Get-AzSynapseKustoPoolPrincipalAssignment', 'Get-AzSynapseKustoPoolSku', 'Invoke-AzSynapseDataConnectionValidation', 'Invoke-AzSynapseDetachKustoPoolFollowerDatabase', 'New-AzSynapseAttachedDatabaseConfiguration', 'New-AzSynapseDatabase', 'New-AzSynapseDatabasePrincipalAssignment', 'New-AzSynapseDataConnection', 'New-AzSynapseKustoPool', 'New-AzSynapseKustoPoolPrincipalAssignment', 'Remove-AzSynapseAttachedDatabaseConfiguration', 'Remove-AzSynapseDatabase', 'Remove-AzSynapseDatabasePrincipalAssignment', 'Remove-AzSynapseDataConnection', 'Remove-AzSynapseKustoPool', 'Remove-AzSynapseKustoPoolLanguageExtension', 'Remove-AzSynapseKustoPoolPrincipalAssignment', 'Set-AzSynapseAttachedDatabaseConfiguration', 'Set-AzSynapseDatabase', 'Set-AzSynapseDatabasePrincipalAssignment', 'Set-AzSynapseDataConnection', 'Set-AzSynapseKustoPool', 'Set-AzSynapseKustoPoolPrincipalAssignment', 'Start-AzSynapseKustoPool', 'Stop-AzSynapseKustoPool', 'Test-AzSynapseDatabasePrincipalAssignmentNameAvailability', 'Test-AzSynapseDataConnectionNameAvailability', 'Test-AzSynapseKustoPoolChildResourceNameAvailability', 'Test-AzSynapseKustoPoolNameAvailability', 'Test-AzSynapseKustoPoolPrincipalAssignmentNameAvailability', 'Update-AzSynapseDatabase', 'Update-AzSynapseDataConnection', 'Update-AzSynapseKustoPool', '*'
  AliasesToExport = '*'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'Synapse'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
