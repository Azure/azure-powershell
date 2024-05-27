@{
  GUID = '37b6c269-cf74-4717-832a-72e8d433e8fc'
  RootModule = './Az.Compute.psm1'
  ModuleVersion = '0.3.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: Compute cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.Compute.private.dll'
  FormatsToProcess = './Az.Compute.format.ps1xml'
  FunctionsToExport = 'Get-AzGalleryApplication', 'Get-AzGalleryApplicationVersion', 'Invoke-AzSpotPlacementRecommender', 'New-AzGalleryApplication', 'New-AzGalleryApplicationVersion', 'Remove-AzGalleryApplication', 'Remove-AzGalleryApplicationVersion', 'Remove-AzVMRunCommand', 'Remove-AzVmssVMRunCommand', 'Set-AzVMRunCommand', 'Set-AzVmssVMRunCommand', 'Update-AzGalleryApplication', 'Update-AzGalleryApplicationVersion', '*'
  AliasesToExport = '*'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'Compute'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
