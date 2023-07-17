@{
  GUID = '4b1300f7-8ec1-4e8b-978c-f31e7b650f41'
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
  FunctionsToExport = 'Get-AzSphereCatalog', 'Get-AzSphereCatalogDeployment', 'Get-AzSphereCatalogDevice', 'Get-AzSphereCatalogDeviceGroup', 'Get-AzSphereCatalogDeviceInsight', 'Get-AzSphereCertificate', 'Get-AzSphereCertificateCertChain', 'Get-AzSphereCertificateProof', 'Get-AzSphereDeployment', 'Get-AzSphereDevice', 'Get-AzSphereDeviceGroup', 'Get-AzSphereImage', 'Get-AzSphereProduct', 'Invoke-AzSphereClaimDeviceGroupDevice', 'Invoke-AzSphereCountCatalogDevice', 'Invoke-AzSphereCountDeviceGroupDevice', 'Invoke-AzSphereCountProductDevice', 'New-AzSphereCatalog', 'New-AzSphereDeployment', 'New-AzSphereDevice', 'New-AzSphereDeviceCapabilityImage', 'New-AzSphereDeviceGroup', 'New-AzSphereImage', 'New-AzSphereProduct', 'Remove-AzSphereCatalog', 'Remove-AzSphereDeployment', 'Remove-AzSphereDevice', 'Remove-AzSphereDeviceGroup', 'Remove-AzSphereImage', 'Remove-AzSphereProduct', 'Update-AzSphereCatalog', 'Update-AzSphereDeployment', 'Update-AzSphereDevice', 'Update-AzSphereDeviceGroup', 'Update-AzSphereImage', 'Update-AzSphereProduct'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'Sphere'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
