@{
  GUID = '807473b6-22c7-4e49-80d1-05b11be37c71'
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
  CmdletsToExport = 'Get-AzBlockchainConsortium', 'Get-AzBlockchainMember', 'Get-AzBlockchainMemberApiKey', 'Get-AzBlockchainMemberConsortiumMember', 'Get-AzBlockchainSku', 'Get-AzBlockchainTransactionNode', 'Get-AzBlockchainTransactionNodeApiKey', 'New-AzBlockchainMember', 'New-AzBlockchainMemberApiKey', 'New-AzBlockchainTransactionNode', 'New-AzBlockchainTransactionNodeApiKey', 'Remove-AzBlockchainMember', 'Remove-AzBlockchainTransactionNode', 'Test-AzBlockchainLocationNameAvailability', 'Update-AzBlockchainMember', 'Update-AzBlockchainTransactionNode', '*'
  AliasesToExport = '*'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'Blockchain'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
      Profiles = 'latest-2019-04-30'
    }
  }
}
