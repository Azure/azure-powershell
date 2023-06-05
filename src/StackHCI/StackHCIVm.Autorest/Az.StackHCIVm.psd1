@{
  GUID = '613891a4-c2f6-4b8d-843d-801d4e783d77'
  RootModule = './Az.StackHCIVm.psm1'
  ModuleVersion = '1.1.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: StackHciVM cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.StackHCIVm.private.dll'
  FormatsToProcess = './Az.StackHCIVm.format.ps1xml'
  FunctionsToExport = 'Add-AzStackHCIVMVirtualMachineDataDisk', 'Confirm-IpConfigrations', 'Confirm-IpPools', 'Confirm-Routes', 'Confirm-Subnets', 'Get-AzStackHciVMGalleryImage', 'Get-AzStackHciVMGuestAgent', 'Get-AzStackHciVMHybridIdentityMetadata', 'Get-AzStackHCIVMImage', 'Get-AzStackHciVMMachineExtension', 'Get-AzStackHciVMMarketplaceGalleryImage', 'Get-AzStackHCIVMNetworkInterface', 'Get-AzStackHCIVMStoragePath', 'Get-AzStackHCIVMVirtualHardDisk', 'Get-AzStackHCIVMVirtualMachine', 'Get-AzStackHCIVMVirtualNetwork', 'New-AzStackHciVMGalleryImage', 'New-AzStackHciVMGuestAgent', 'New-AzStackHciVMHybridIdentityMetadata', 'New-AzStackHCIVMImage', 'New-AzStackHciVMMachineExtension', 'New-AzStackHciVMMarketplaceGalleryImage', 'New-AzStackHCIVMNetworkInterface', 'New-AzStackHCIVMNetworkInterfaceIpConfig', 'New-AzStackHCIVMStoragePath', 'New-AzStackHCIVMVirtualHardDisk', 'New-AzStackHCIVMVirtualMachine', 'New-AzStackHCIVMVirtualNetwork', 'Remove-AzStackHciVMGalleryImage', 'Remove-AzStackHciVMGuestAgent', 'Remove-AzStackHciVMHybridIdentityMetadata', 'Remove-AzStackHCIVMImage', 'Remove-AzStackHciVMMachineExtension', 'Remove-AzStackHciVMMarketplaceGalleryImage', 'Remove-AzStackHciVMNetworkInterface', 'Remove-AzStackHciVMStoragePath', 'Remove-AzStackHciVMVirtualHardDisk', 'Remove-AzStackHciVMVirtualMachine', 'Remove-AzStackHCIVMVirtualMachineDataDisk', 'Remove-AzStackHciVMVirtualNetwork', 'Restart-AzStackHciVMVirtualMachine', 'Set-AzStackHciVMGalleryImage', 'Set-AzStackHciVMMachineExtension', 'Set-AzStackHciVMMarketplaceGalleryImage', 'Set-AzStackHciVMNetworkInterface', 'Set-AzStackHciVMStorageContainer', 'Set-AzStackHciVMVirtualHardDisk', 'Set-AzStackHciVMVirtualMachine', 'Set-AzStackHciVMVirtualNetwork', 'Start-AzStackHciVMVirtualMachine', 'Stop-AzStackHciVMVirtualMachine', 'Update-AzStackHciVMGalleryImage', 'Update-AzStackHCIVMImage', 'Update-AzStackHciVMMachineExtension', 'Update-AzStackHciVMMarketplaceGalleryImage', 'Update-AzStackHciVMNetworkInterface', 'Update-AzStackHciVMStoragePath', 'Update-AzStackHciVMVirtualHardDisk', 'Update-AzStackHciVMVirtualMachine', 'Update-AzStackHciVMVirtualNetwork', '*'
  AliasesToExport = '*'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'StackHciVM'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
