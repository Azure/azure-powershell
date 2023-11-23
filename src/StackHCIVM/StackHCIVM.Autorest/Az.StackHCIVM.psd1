@{
  GUID = '7389f67c-ec9d-4c13-9c9a-308834413af6'
  RootModule = './Az.StackHCIVM.psm1'
  ModuleVersion = '0.1.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: StackHcivm cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.StackHCIVM.private.dll'
  FormatsToProcess = './Az.StackHCIVM.format.ps1xml'
  FunctionsToExport = 'Add-AzStackHCIVMVirtualMachineDataDisk', 'Add-AzStackHCIVMVirtualMachineNetworkInterface', 'Get-AzStackHCIVMImage', 'Get-AzStackHCIVMLogicalNetwork', 'Get-AzStackHCIVMNetworkInterface', 'Get-AzStackHCIVMStoragePath', 'Get-AzStackHCIVMVirtualHardDisk', 'Get-AzStackHCIVMVirtualMachine', 'New-AzStackHCIVMImage', 'New-AzStackHCIVMLogicalNetwork', 'New-AzStackHCIVMNetworkInterface', 'New-AzStackHCIVMStoragePath', 'New-AzStackHCIVMVirtualHardDisk', 'New-AzStackHCIVMVirtualMachine', 'Remove-AzStackHCIVMImage', 'Remove-AzStackHCIVMLogicalNetwork', 'Remove-AzStackHCIVMNetworkInterface', 'Remove-AzStackHCIVMStoragePath', 'Remove-AzStackHCIVMVirtualHardDisk', 'Remove-AzStackHCIVMVirtualMachine', 'Remove-AzStackHCIVMVirtualMachineDataDisk', 'Remove-AzStackHCIVMVirtualMachineNetworkInterface', 'Restart-AzStackHCIVMVirtualMachine', 'Start-AzStackHCIVMVirtualMachine', 'Stop-AzStackHCIVMVirtualMachine', 'Update-AzStackHCIVMImage', 'Update-AzStackHCIVMLogicalNetwork', 'Update-AzStackHCIVMNetworkInterface', 'Update-AzStackHCIVMStoragePath', 'Update-AzStackHCIVMVirtualHardDisk', 'Update-AzStackHCIVMVirtualMachine'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'StackHcivm'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
