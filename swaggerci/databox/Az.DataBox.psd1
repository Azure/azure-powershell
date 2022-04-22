@{
  GUID = '3ac8cee6-4037-42b3-bc48-383456741975'
  RootModule = './Az.DataBox.psm1'
  ModuleVersion = '0.1.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: DataBox cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.DataBox.private.dll'
  FormatsToProcess = './Az.DataBox.format.ps1xml'
  FunctionsToExport = 'Get-AzDataBoxJob', 'Get-AzDataBoxJobCredentials', 'Get-AzDataBoxServiceAvailableSku', 'Invoke-AzDataBoxBookJobShipmentPickUp', 'Invoke-AzDataBoxMarkJobDeviceShipped', 'Invoke-AzDataBoxMitigate', 'Invoke-AzDataBoxRegionServiceConfiguration', 'New-AzDataBoxJob', 'Remove-AzDataBoxJob', 'Stop-AzDataBoxJob', 'Test-AzDataBoxServiceAddress', 'Test-AzDataBoxServiceInput', 'Update-AzDataBoxJob', '*'
  AliasesToExport = '*'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'DataBox'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
