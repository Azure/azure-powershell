@{
  GUID = '9602a6b3-8b77-4f08-a6ed-edefff13e149'
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
  FunctionsToExport = 'Get-AzDataBoxJob', 'Get-AzDataBoxJobCredential', 'New-AzDataBoxContactDetailsObject', 'New-AzDataBoxCustomerDiskJobDetailsObject', 'New-AzDataBoxDiskJobDetailsObject', 'New-AzDataBoxHeavyJobDetailsObject', 'New-AzDataBoxJob', 'New-AzDataBoxJobDetailsObject', 'New-AzDataBoxKeyEncryptionKeyObject', 'New-AzDataBoxManagedDiskDetailsObject', 'New-AzDataBoxShippingAddressObject', 'New-AzDataBoxStorageAccountDetailsObject', 'New-AzDataBoxTransferConfigurationObject', 'Remove-AzDataBoxJob', 'Stop-AzDataBoxJob', 'Update-AzDataBoxJob', '*'
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
