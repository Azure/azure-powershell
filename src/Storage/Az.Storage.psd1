@{
# region definition 
  RootModule = './Az.Storage.psm1'
  ModuleVersion = '0.0.1'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: Storage cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.Storage.private.dll'
  FormatsToProcess = './Az.Storage.format.ps1xml'
# endregion 

# region persistent data 
  GUID = 'f53f52d4-46f1-4c1a-ea8d-2b74552f6379'
# endregion 

# region private data 
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'Storage'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
      Profiles = 'latest-2019-04-30', 'hybrid-2019-03-01'
    }
  }
# endregion 

# region exports
  CmdletsToExport = 'Clear-AzBlobContainerLegalHold', 'Get-AzBlobContainer', 'Get-AzBlobContainerImmutabilityPolicy', 'Get-AzBlobServiceProperty', 'Get-AzManagementPolicy', 'Get-AzSku', 'Get-AzStorageAccount', 'Get-AzStorageAccountKey', 'Get-AzStorageAccountProperty', 'Get-AzStorageAccountSas', 'Get-AzStorageAccountServiceSas', 'Get-AzUsage', 'Invoke-AzExtendBlobContainerImmutabilityPolicy', 'Invoke-AzLeaseBlobContainer', 'Lock-AzBlobContainerImmutabilityPolicy', 'New-AzBlobContainer', 'New-AzBlobContainerImmutabilityPolicy', 'New-AzManagementPolicy', 'New-AzStorageAccount', 'New-AzStorageAccountKey', 'Remove-AzBlobContainer', 'Remove-AzBlobContainerImmutabilityPolicy', 'Remove-AzManagementPolicy', 'Remove-AzStorageAccount', 'Revoke-AzStorageAccountUserDelegationKey', 'Set-AzBlobContainerImmutabilityPolicy', 'Set-AzBlobContainerLegalHold', 'Set-AzBlobServiceProperty', 'Set-AzManagementPolicy', 'Set-AzStorageAccount', 'Test-AzStorageAccountNameAvailability', 'Update-AzBlobContainer', 'Update-AzStorageAccount', '*'
  AliasesToExport = '*'
# endregion

}