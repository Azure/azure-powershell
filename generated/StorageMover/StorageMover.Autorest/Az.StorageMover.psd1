@{
  GUID = 'fa4418e5-2dd1-4577-a8f7-098cbc85a94c'
  RootModule = './Az.StorageMover.psm1'
  ModuleVersion = '1.7.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: StorageMover cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.StorageMover.private.dll'
  FormatsToProcess = './Az.StorageMover.format.ps1xml'
  FunctionsToExport = 'Get-AzStorageMover', 'Get-AzStorageMoverAgent', 'Get-AzStorageMoverConnection', 'Get-AzStorageMoverEndpoint', 'Get-AzStorageMoverJobDefinition', 'Get-AzStorageMoverJobRun', 'Get-AzStorageMoverProject', 'New-AzStorageMover', 'New-AzStorageMoverAzNfsFileShareEndpoint', 'New-AzStorageMoverAzSmbFileShareEndpoint', 'New-AzStorageMoverAzStorageContainerEndpoint', 'New-AzStorageMoverConnection', 'New-AzStorageMoverJobDefinition', 'New-AzStorageMoverMultiCloudConnectorEndpoint', 'New-AzStorageMoverNfsEndpoint', 'New-AzStorageMoverProject', 'New-AzStorageMoverS3WithHmacEndpoint', 'New-AzStorageMoverSmbEndpoint', 'New-AzStorageMoverUploadLimitWeeklyRecurrenceObject', 'Remove-AzStorageMover', 'Remove-AzStorageMoverConnection', 'Remove-AzStorageMoverEndpoint', 'Remove-AzStorageMoverJobDefinition', 'Remove-AzStorageMoverProject', 'Start-AzStorageMoverJobDefinition', 'Stop-AzStorageMoverJobDefinition', 'Unregister-AzStorageMoverAgent', 'Update-AzStorageMover', 'Update-AzStorageMoverAgent', 'Update-AzStorageMoverAzNfsFileShareEndpoint', 'Update-AzStorageMoverAzSmbFileShareEndpoint', 'Update-AzStorageMoverAzStorageContainerEndpoint', 'Update-AzStorageMoverJobDefinition', 'Update-AzStorageMoverMultiCloudConnectorEndpoint', 'Update-AzStorageMoverNfsEndpoint', 'Update-AzStorageMoverProject', 'Update-AzStorageMoverS3WithHmacEndpoint', 'Update-AzStorageMoverSmbEndpoint'
  AliasesToExport = 'New-AzStorageMoverSmbFileShareEndpoint', 'Update-AzStorageMoverSmbFileShareEndpoint'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'StorageMover'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
