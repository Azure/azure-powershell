@{
  GUID = '874ad4d2-9877-44bf-9f40-4868e44fb018'
  RootModule = './Az.ScVmm.psm1'
  ModuleVersion = '0.1.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: ScVmm cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.ScVmm.private.dll'
  FormatsToProcess = './Az.ScVmm.format.ps1xml'
  FunctionsToExport = 'Add-AzScVmmVMDisk', 'Add-AzScVmmVMNic', 'Get-AzScVmmAvailabilitySet', 'Get-AzScVmmCloud', 'Get-AzScVmmInventoryItem', 'Get-AzScVmmServer', 'Get-AzScVmmVirtualNetwork', 'Get-AzScVmmVM', 'Get-AzScVmmVMDisk', 'Get-AzScVmmVMExtension', 'Get-AzScVmmVMGuestAgent', 'Get-AzScVmmVMNic', 'Get-AzScVmmVMTemplate', 'New-AzScVmmAvailabilitySet', 'New-AzScVmmCloud', 'New-AzScVmmNetworkInterfaceObject', 'New-AzScVmmNetworkInterfaceUpdateObject', 'New-AzScVmmServer', 'New-AzScVmmVirtualDiskObject', 'New-AzScVmmVirtualDiskUpdateObject', 'New-AzScVmmVirtualNetwork', 'New-AzScVmmVM', 'New-AzScVmmVMCheckpoint', 'New-AzScVmmVMExtension', 'New-AzScVmmVMGuestAgent', 'New-AzScVmmVMTemplate', 'Remove-AzScVmmAvailabilitySet', 'Remove-AzScVmmCloud', 'Remove-AzScVmmServer', 'Remove-AzScVmmVirtualNetwork', 'Remove-AzScVmmVM', 'Remove-AzScVmmVMCheckpoint', 'Remove-AzScVmmVMDisk', 'Remove-AzScVmmVMExtension', 'Remove-AzScVmmVMNic', 'Remove-AzScVmmVMTemplate', 'Restart-AzScVmmVM', 'Restore-AzScVmmVMCheckpoint', 'Start-AzScVmmVM', 'Stop-AzScVmmVM', 'Update-AzScVmmAvailabilitySet', 'Update-AzScVmmCloud', 'Update-AzScVmmServer', 'Update-AzScVmmVirtualNetwork', 'Update-AzScVmmVM', 'Update-AzScVmmVMDisk', 'Update-AzScVmmVMExtension', 'Update-AzScVmmVMNic', 'Update-AzScVmmVMTemplate'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'ScVmm'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
