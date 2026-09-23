@{
  GUID = '4855dcb5-d1a4-45e3-b4b2-49d37925ed0b'
  RootModule = './Az.Sphere.psm1'
  ModuleVersion = '0.1.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: Sphere cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.Sphere.private.dll'
  FormatsToProcess = './Az.Sphere.format.ps1xml'
  FunctionsToExport = 'Get-AzSphereCatalog', 'Get-AzSphereCatalogDevice', 'Get-AzSphereCatalogDeviceGroup', 'Get-AzSphereCatalogDeviceInsight', 'Get-AzSphereCertificate', 'Get-AzSphereCertificateCertChain', 'Get-AzSphereCertificateProof', 'Get-AzSphereDeployment', 'Get-AzSphereDevice', 'Get-AzSphereDeviceGroup', 'Get-AzSphereImage', 'Get-AzSphereProduct', 'Invoke-AzSphereCountCatalogDevice', 'Invoke-AzSphereCountDeviceGroupDevice', 'Invoke-AzSphereCountProductDevice', 'New-AzSphereCatalog', 'New-AzSphereDeployment', 'New-AzSphereDevice', 'New-AzSphereDeviceCapabilityImage', 'New-AzSphereDeviceGroup', 'New-AzSphereImage', 'New-AzSphereProduct', 'New-AzSphereProductDefaultDeviceGroup', 'Remove-AzSphereCatalog', 'Remove-AzSphereDeviceGroup', 'Remove-AzSphereProduct', 'Update-AzSphereCatalog', 'Update-AzSphereDevice', 'Update-AzSphereDeviceGroup', 'Update-AzSphereProduct'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'Sphere'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
