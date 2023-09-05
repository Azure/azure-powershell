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
  FunctionsToExport = 'Add-AzStackHciVMVirtualMachineDataDisk', 'Add-AzStackHciVMVirtualMachineNic', 'Get-AzStackHciVMImage', 'Get-AzStackHciVMNetworkInterface', 'Get-AzStackHciVMStoragePath', 'Get-AzStackHciVMVirtualHardDisk', 'Get-AzStackHciVMVirtualMachine', 'Get-AzStackHciVMVirtualNetwork', 'New-AzStackHciVMImage', 'New-AzStackHciVMNetworkInterface', 'New-AzStackHciVMNetworkInterfaceIpConfig', 'New-AzStackHciVMStoragePath', 'New-AzStackHciVMVirtualHardDisk', 'New-AzStackHciVMVirtualMachine', 'New-AzStackHciVMVirtualNetwork', 'New-AzStackHciVMVirtualNetworkSubnetConfig', 'Remove-AzStackHciVMImage', 'Remove-AzStackHciVMNetworkInterface', 'Remove-AzStackHciVMStoragePath', 'Remove-AzStackHciVMVirtualHardDisk', 'Remove-AzStackHciVMVirtualMachine', 'Remove-AzStackHciVMVirtualMachineDataDisk', 'Remove-AzStackHciVMVirtualMachineNic', 'Remove-AzStackHciVMVirtualNetwork', 'Restart-AzStackHciVMVirtualMachine', 'Start-AzStackHciVMVirtualMachine', 'Stop-AzStackHciVMVirtualMachine', 'Update-AzStackHciVMImage', 'Update-AzStackHciVMNetworkInterface', 'Update-AzStackHciVMStoragePath', 'Update-AzStackHciVMVirtualHardDisk', 'Update-AzStackHciVMVirtualMachine', 'Update-AzStackHciVMVirtualNetwork', '*'
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
