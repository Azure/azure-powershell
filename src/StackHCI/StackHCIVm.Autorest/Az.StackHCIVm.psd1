@{
  GUID = '7389f67c-ec9d-4c13-9c9a-308834413af6'
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
  FunctionsToExport = 'Add-AzStackHCIVmVirtualMachineDataDisk', 'Add-AzStackHCIVmVirtualMachineNetworkInterface', 'Get-AzStackHCIVmImage', 'Get-AzStackHciVMLogicalNetwork', 'Get-AzStackHCIVmNetworkInterface', 'Get-AzStackHCIVmStoragePath', 'Get-AzStackHCIVmVirtualHardDisk', 'Get-AzStackHCIVmVirtualMachine', 'New-AzStackHCIVmImage', 'New-AzStackHCIVmLogicalNetwork', 'New-AzStackHCIVmNetworkInterface', 'New-AzStackHCIVmStoragePath', 'New-AzStackHCIVmVirtualHardDisk', 'New-AzStackHCIVmVirtualMachine', 'Remove-AzStackHCIVmImage', 'Remove-AzStackHCIVmLogicalNetwork', 'Remove-AzStackHCIVmNetworkInterface', 'Remove-AzStackHCIVmStoragePath', 'Remove-AzStackHCIVmVirtualHardDisk', 'Remove-AzStackHCIVmVirtualMachine', 'Remove-AzStackHCIVmVirtualMachineDataDisk', 'Remove-AzStackHCIVmVirtualMachineNetworkInterface', 'Restart-AzStackHCIVmVirtualMachine', 'Start-AzStackHCIVmVirtualMachine', 'Stop-AzStackHCIVmVirtualMachine', 'Update-AzStackHCIVmImage', 'Update-AzStackHCIVmLogicalNetwork', 'Update-AzStackHCIVmNetworkInterface', 'Update-AzStackHCIVmStoragePath', 'Update-AzStackHCIVmVirtualHardDisk', 'Update-AzStackHCIVmVirtualMachine', '*'
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
