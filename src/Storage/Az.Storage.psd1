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
  CmdletsToExport = 'Clear-AzRmStorageContainerLegalHold', 'Get-AzRmStorageContainer', 'Get-AzRmStorageContainerImmutabilityPolicy', 'Get-AzSku', 'Get-AzStorageAccount', 'Get-AzStorageAccountKey', 'Get-AzStorageAccountManagementPolicy', 'Get-AzStorageAccountProperty', 'Get-AzStorageAccountSas', 'Get-AzStorageAccountServiceSas', 'Get-AzStorageBlobServiceProperty', 'Get-AzStorageUsage', 'Invoke-AzExtendBlobContainerImmutabilityPolicy', 'Invoke-AzLeaseBlobContainer', 'Invoke-AzStorageAccountFailover', 'Lock-AzRmStorageContainerImmutabilityPolicy', 'New-AzRmStorageContainer', 'New-AzRmStorageContainerImmutabilityPolicy', 'New-AzStorageAccount', 'New-AzStorageAccountKey', 'New-AzStorageAccountManagementPolicy', 'Remove-AzRmStorageContainer', 'Remove-AzRmStorageContainerImmutabilityPolicy', 'Remove-AzStorageAccount', 'Remove-AzStorageAccountManagementPolicy', 'Revoke-AzStorageAccountUserDelegationKey', 'Set-AzRmStorageContainerImmutabilityPolicy', 'Set-AzRmStorageContainerLegalHold', 'Set-AzStorageAccount', 'Set-AzStorageAccountManagementPolicy', 'Set-AzStorageBlobServiceProperty', 'Test-AzStorageAccountNameAvailability', 'Update-AzRmStorageContainer', '*'
  AliasesToExport = 'Remove-AzRmStorageContainerLegalHold', 'Add-AzRmStorageContainerLegalHold', 'Get-AzStorageAccountNameAvailability', '*'
# endregion

}