@{
  GUID = 'cc1d1de1-1601-4440-82c6-76c6673d8aba'
  RootModule = './Az.StorageAction.psm1'
  ModuleVersion = '0.1.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: StorageAction cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.StorageAction.private.dll'
  FormatsToProcess = './Az.StorageAction.format.ps1xml'
  FunctionsToExport = 'Get-AzStorageActionTask', 'Get-AzStorageActionTaskAssignment', 'Get-AzStorageActionTasksReport', 'Invoke-AzStorageActionTaskPreviewAction', 'New-AzStorageActionTask', 'New-AzStorageActionTaskOperationObject', 'New-AzStorageActionTaskPreviewBlobPropertiesObject', 'New-AzStorageActionTaskPreviewKeyValuePropertiesObject', 'Remove-AzStorageActionTask', 'Update-AzStorageActionTask'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'StorageAction'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
