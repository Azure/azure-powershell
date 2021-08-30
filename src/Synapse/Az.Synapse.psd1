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
  FunctionsToExport = 'Get-AzSynapseKustoPool', 'New-AzSynapseKustoPool', 'Remove-AzSynapseKustoPool', 'Update-AzSynapseKustoPool', '*'
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
