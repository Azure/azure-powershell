@{
# region definition 
  RootModule = './Az.KeyVault.psm1'
  ModuleVersion = '0.0.1'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: KeyVault cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.KeyVault.private.dll'
  FormatsToProcess = './Az.KeyVault.format.ps1xml'
# endregion 

# region persistent data 
  GUID = 'bf1e620f-fefa-4441-215c-6cb11384ed1a'
# endregion 

# region private data 
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'KeyVault'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
      Profiles = 'latest-2019-04-30', 'hybrid-2019-03-01'
    }
  }
# endregion 

# region exports
  CmdletsToExport = 'Backup-AzKeyVaultCertificate', 'Backup-AzKeyVaultKey', 'Backup-AzKeyVaultSecret', 'Backup-AzKeyVaultStorageAccount', 'Get-AzKeyVault', 'Get-AzKeyVaultCertificate', 'Get-AzKeyVaultCertificateContact', 'Get-AzKeyVaultCertificateIssuer', 'Get-AzKeyVaultCertificateOperation', 'Get-AzKeyVaultCertificatePolicy', 'Get-AzKeyVaultCertificateVersion', 'Get-AzKeyVaultKey', 'Get-AzKeyVaultKeyVersion', 'Get-AzKeyVaultSecret', 'Get-AzKeyVaultSecretVersion', 'Get-AzKeyVaultStorageAccount', 'Get-AzKeyVaultStorageSasDefinition', 'Import-AzKeyVaultCertificate', 'Import-AzKeyVaultKey', 'Invoke-AzKeyVaultSignKey', 'Invoke-AzKeyVaultUnwrapKey', 'Invoke-AzKeyVaultWrapKey', 'Merge-AzKeyVaultCertificate', 'New-AzKeyVault', 'New-AzKeyVaultCertificate', 'New-AzKeyVaultKey', 'New-AzKeyVaultStorageAccountKey', 'Protect-AzKeyVaultKey', 'Remove-AzKeyVault', 'Remove-AzKeyVaultCertificate', 'Remove-AzKeyVaultCertificateContact', 'Remove-AzKeyVaultCertificateIssuer', 'Remove-AzKeyVaultCertificateOperation', 'Remove-AzKeyVaultKey', 'Remove-AzKeyVaultSecret', 'Remove-AzKeyVaultStorageAccount', 'Remove-AzKeyVaultStorageSasDefinition', 'Restore-AzKeyVaultCertificate', 'Restore-AzKeyVaultKey', 'Restore-AzKeyVaultSecret', 'Restore-AzKeyVaultStorageAccount', 'Set-AzKeyVault', 'Set-AzKeyVaultAccessPolicy', 'Set-AzKeyVaultCertificateContact', 'Set-AzKeyVaultCertificateIssuer', 'Set-AzKeyVaultSecret', 'Set-AzKeyVaultStorageAccount', 'Set-AzKeyVaultStorageSasDefinition', 'Test-AzKeyVaultKey', 'Test-AzKeyVaultNameAvailability', 'Undo-AzKeyVaultCertificateRemoval', 'Undo-AzKeyVaultKeyRemoval', 'Undo-AzKeyVaultSecretRemoval', 'Undo-AzKeyVaultStorageAccountRemoval', 'Undo-AzKeyVaultStorageSasDefinitionRemoval', 'Unprotect-AzKeyVaultKey', 'Update-AzKeyVault', 'Update-AzKeyVaultCertificate', 'Update-AzKeyVaultCertificateIssuer', 'Update-AzKeyVaultCertificateOperation', 'Update-AzKeyVaultCertificatePolicy', 'Update-AzKeyVaultKey', 'Update-AzKeyVaultSecret', 'Update-AzKeyVaultStorageAccount', 'Update-AzKeyVaultStorageSasDefinition', '*'
  AliasesToExport = 'Backup-AzKeyVaultManagedStorageAccount', 'Get-AzKeyVaultManagedStorageAccount', 'Get-AzKeyVaultManagedStorageSasDefinition', 'Add-AzKeyVaultKey', 'Add-AzKeyVaultCertificate', 'Update-AzKeyVaultManagedStorageAccountKey', 'Remove-AzKeyVaultManagedStorageAccount', 'Remove-AzKeyVaultManagedStorageSasDefinition', 'Restore-AzKeyVaultManagedStorageAccount', 'Undo-AzKeyVaultManagedStorageAccountRemoval', 'Add-AzKeyVaultCertificateContact', 'Add-AzKeyVaultManagedStorageAccount', 'Set-AzKeyVaultManagedStorageSasDefinition', 'Undo-AzKeyVaultManagedStorageSasDefinitionRemoval', 'Stop-AzKeyVaultCertificateOperation', 'Set-AzKeyVaultCertificatePolicy', 'Update-AzKeyVaultManagedStorageAccount', 'Update-AzKeyVaultManagedStorageSasDefinition', '*'
# endregion

}