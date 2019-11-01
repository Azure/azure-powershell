@{
  GUID = '0a14cfae-a756-41e9-a937-75521614c685'
  RootModule = 'Azs.Storage.Admin.psm1'
  ModuleVersion = '0.0.1'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = ''
  CompanyName = ''
  Copyright = ''
  Description = ''
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Azs.Storage.Admin.private.dll'
  FormatsToProcess = './Azs.Storage.Admin.format.ps1xml'
  CmdletsToExport = 'Get-AzsStorageAccount', 'Get-AzsStorageAcquisition', 'Get-AzsStorageQuota', 'Get-AzsStorageSetting', 'Invoke-AzsStorageReclaimStorageAccountStorageCapacity', 'New-AzsStorageQuota', 'Remove-AzsStorageQuota', 'Restore-AzsStorageAccount', 'Set-AzsStorageQuota', 'Set-AzsStorageSetting', '*'
  AliasesToExport = '*'
  PrivateData = @{
    PSData = @{
      Tags = ''
      LicenseUri = ''
      ProjectUri = ''
      ReleaseNotes = ''
    }
  }
}
