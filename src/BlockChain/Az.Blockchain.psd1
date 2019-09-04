@{
  GUID = '4764b8dc-2c3c-4162-b5de-b8d6fc16800e'
  RootModule = './Az.Blockchain.psm1'
  ModuleVersion = '0.0.1'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: Blockchain cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.Blockchain.private.dll'
  FormatsToProcess = './Az.Blockchain.format.ps1xml'
  CmdletsToExport = 'Get-AzBlockchainLocationConsortium', 'Get-AzBlockchainMember', 'Get-AzBlockchainMemberApiKey', 'Get-AzBlockchainMemberConsortiumMember', 'Get-AzBlockchainMemberOperationResult', 'Get-AzBlockchainMemberRegenerateApiKey', 'Get-AzBlockchainSku', 'Get-AzBlockchainTransactionNode', 'Get-AzBlockchainTransactionNodeApiKey', 'Get-AzBlockchainTransactionNodeRegenerateApiKey', 'New-AzBlockchainMember', 'New-AzBlockchainTransactionNode', 'Remove-AzBlockchainMember', 'Remove-AzBlockchainTransactionNode', 'Test-AzBlockchainLocationNameAvailability', 'Update-AzBlockchainMember', 'Update-AzBlockchainTransactionNode', '*'
  AliasesToExport = '*'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'Blockchain'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
      Profiles = 'latest-2019-04-30'
    }
  }
}
