@{
  GUID = '5a382cc7-bd7c-4aee-b85e-844a1631d925'
  RootModule = './Az.FileShare.psm1'
  ModuleVersion = '0.1.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: FileShare cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.FileShare.private.dll'
  FormatsToProcess = './Az.FileShare.format.ps1xml'
  FunctionsToExport = 'Get-AzFileShare', 'Get-AzFileShareInformationalOperationLimit', 'Get-AzFileShareInformationalOperationProvisioningRecommendation', 'Get-AzFileShareInformationalOperationUsageData', 'Get-AzFileShareSnapshot', 'New-AzFileShare', 'New-AzFileShareSnapshot', 'Remove-AzFileShare', 'Remove-AzFileShareSnapshot', 'Test-AzFileShareNameAvailability', 'Update-AzFileShare', 'Update-AzFileShareSnapshot'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'FileShare'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
