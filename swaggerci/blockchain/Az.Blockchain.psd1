@{
  GUID = 'ed4c9032-84b4-426c-87b6-656762c882b2'
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
  FunctionsToExport = 'Get-AzBlockchainLocationConsortium', 'Get-AzBlockchainMember', 'Get-AzBlockchainMemberApiKey', 'Get-AzBlockchainMemberConsortiumMember', 'Get-AzBlockchainMemberOperationResult', 'Get-AzBlockchainMemberRegenerateApiKey', 'Get-AzBlockchainSku', 'Get-AzBlockchainTransactionNode', 'Get-AzBlockchainTransactionNodeApiKey', 'Get-AzBlockchainTransactionNodeRegenerateApiKey', 'New-AzBlockchainMember', 'New-AzBlockchainTransactionNode', 'Remove-AzBlockchainMember', 'Remove-AzBlockchainTransactionNode', 'Test-AzBlockchainLocationNameAvailability', 'Update-AzBlockchainMember', 'Update-AzBlockchainTransactionNode', '*'
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
