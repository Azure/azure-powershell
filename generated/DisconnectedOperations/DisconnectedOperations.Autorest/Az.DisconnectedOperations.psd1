@{
  GUID = '39527e8c-901e-4f93-9349-a8b5f7dc1e27'
  RootModule = './Az.DisconnectedOperations.psm1'
  ModuleVersion = '1.0.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: DisconnectedOperations cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.DisconnectedOperations.private.dll'
  FormatsToProcess = './Az.DisconnectedOperations.format.ps1xml'
  FunctionsToExport = 'Get-AzDisconnectedOperationsArtifact', 'Get-AzDisconnectedOperationsArtifactDownloadUri', 'Get-AzDisconnectedOperationsDisconnectedOperation', 'Get-AzDisconnectedOperationsDisconnectedOperationDeploymentManifest', 'Get-AzDisconnectedOperationsHardwareSetting', 'Get-AzDisconnectedOperationsImage', 'Get-AzDisconnectedOperationsImageDownloadUri', 'New-AzDisconnectedOperationsDisconnectedOperation', 'New-AzDisconnectedOperationsHardwareSetting', 'Remove-AzDisconnectedOperationsDisconnectedOperation', 'Remove-AzDisconnectedOperationsHardwareSetting', 'Update-AzDisconnectedOperationsDisconnectedOperation', 'Update-AzDisconnectedOperationsHardwareSetting'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'DisconnectedOperations'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
