@{
  GUID = '8edd1f4e-819c-4167-b734-ccf5e8c5dc9d'
  RootModule = './Az.StorageMover.psm1'
  ModuleVersion = '1.2.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: StorageMover cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.StorageMover.private.dll'
  FormatsToProcess = './Az.StorageMover.format.ps1xml'
  FunctionsToExport = 'Get-AzStorageMover', 'Get-AzStorageMoverAgent', 'Get-AzStorageMoverEndpoint', 'Get-AzStorageMoverJobDefinition', 'Get-AzStorageMoverJobRun', 'Get-AzStorageMoverProject', 'New-AzStorageMover', 'New-AzStorageMoverAzSmbFileShareEndpoint', 'New-AzStorageMoverAzStorageContainerEndpoint', 'New-AzStorageMoverJobDefinition', 'New-AzStorageMoverNfsEndpoint', 'New-AzStorageMoverProject', 'New-AzStorageMoverSmbEndpoint', 'New-AzStorageMoverUploadLimitWeeklyRecurrenceObject', 'Remove-AzStorageMover', 'Remove-AzStorageMoverEndpoint', 'Remove-AzStorageMoverJobDefinition', 'Remove-AzStorageMoverProject', 'Start-AzStorageMoverJobDefinition', 'Stop-AzStorageMoverJobDefinition', 'Unregister-AzStorageMoverAgent', 'Update-AzStorageMover', 'Update-AzStorageMoverAgent', 'Update-AzStorageMoverAzSmbFileShareEndpoint', 'Update-AzStorageMoverAzStorageContainerEndpoint', 'Update-AzStorageMoverJobDefinition', 'Update-AzStorageMoverNfsEndpoint', 'Update-AzStorageMoverProject', 'Update-AzStorageMoverSmbEndpoint', '*'
  AliasesToExport = 'New-AzStorageMoverSmbFileShareEndpoint', 'Update-AzStorageMoverSmbFileShareEndpoint', '*'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'StorageMover'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
