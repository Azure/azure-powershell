@{
  GUID = 'ae1a09bf-916c-480c-a1bb-bace1453a91e'
  RootModule = './Az.Blockchain.psm1'
  ModuleVersion = '0.1.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: Blockchain cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.Blockchain.private.dll'
  FormatsToProcess = './Az.Blockchain.format.ps1xml'
  FunctionsToExport = 'Get-AzBlockchainConsortium', 'Get-AzBlockchainMember', 'Get-AzBlockchainMemberApiKey', 'Get-AzBlockchainMemberConsortiumMember', 'Get-AzBlockchainSku', 'Get-AzBlockchainTransactionNode', 'Get-AzBlockchainTransactionNodeApiKey', 'New-AzBlockchainMember', 'New-AzBlockchainMemberApiKey', 'New-AzBlockchainTransactionNode', 'New-AzBlockchainTransactionNodeApiKey', 'Remove-AzBlockchainMember', 'Remove-AzBlockchainTransactionNode', 'Test-AzBlockchainLocationNameAvailability', 'Update-AzBlockchainMember', 'Update-AzBlockchainTransactionNode', '*'
  AliasesToExport = '*'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'Blockchain'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
