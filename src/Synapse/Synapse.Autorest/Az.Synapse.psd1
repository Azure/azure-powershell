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
  FunctionsToExport = 'Add-AzSynapseKustoPoolLanguageExtension', 'Get-AzSynapseKustoPool', 'Get-AzSynapseKustoPoolAttachedDatabaseConfiguration', 'Get-AzSynapseKustoPoolDatabase', 'Get-AzSynapseKustoPoolDatabasePrincipalAssignment', 'Get-AzSynapseKustoPoolDataConnection', 'Get-AzSynapseKustoPoolFollowerDatabase', 'Get-AzSynapseKustoPoolLanguageExtension', 'Get-AzSynapseKustoPoolPrincipalAssignment', 'Get-AzSynapseKustoPoolSku', 'Invoke-AzSynapseDetachKustoPoolFollowerDatabase', 'New-AzSynapseKustoPool', 'New-AzSynapseKustoPoolAttachedDatabaseConfiguration', 'New-AzSynapseKustoPoolDatabase', 'New-AzSynapseKustoPoolDatabasePrincipalAssignment', 'New-AzSynapseKustoPoolDataConnection', 'New-AzSynapseKustoPoolPrincipalAssignment', 'Remove-AzSynapseKustoPool', 'Remove-AzSynapseKustoPoolAttachedDatabaseConfiguration', 'Remove-AzSynapseKustoPoolDatabase', 'Remove-AzSynapseKustoPoolDatabasePrincipalAssignment', 'Remove-AzSynapseKustoPoolDataConnection', 'Remove-AzSynapseKustoPoolLanguageExtension', 'Remove-AzSynapseKustoPoolPrincipalAssignment', 'Start-AzSynapseKustoPool', 'Stop-AzSynapseKustoPool', 'Update-AzSynapseKustoPool', 'Update-AzSynapseKustoPoolDatabase', 'Update-AzSynapseKustoPoolDataConnection', '*'
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
