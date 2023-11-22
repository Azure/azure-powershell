@{
  GUID = '9b1ae3b2-2cbe-48e1-9467-63d13ad61b4a'
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
  FunctionsToExport = 'Get-AzScVmmAvailabilitySet', 'Get-AzScVmmCloud', 'Get-AzScVmmInventoryItem', 'Get-AzScVmmServer', 'Get-AzScVmmVirtualMachineInstance', 'Get-AzScVmmVirtualMachineInstanceHybridIdentityMetadata', 'Get-AzScVmmVirtualMachineTemplate', 'Get-AzScVmmVirtualNetwork', 'Get-AzScVmmVMInstanceGuestAgent', 'New-AzScVmmAvailabilitySet', 'New-AzScVmmAvailabilitySetListItemObject', 'New-AzScVmmCheckpointObject', 'New-AzScVmmCloud', 'New-AzScVmmInventoryItem', 'New-AzScVmmNetworkInterfaceObject', 'New-AzScVmmNetworkInterfaceUpdateObject', 'New-AzScVmmServer', 'New-AzScVmmVirtualDiskObject', 'New-AzScVmmVirtualDiskUpdateObject', 'New-AzScVmmVirtualMachineInstance', 'New-AzScVmmVirtualMachineInstanceCheckpoint', 'New-AzScVmmVirtualMachineTemplate', 'New-AzScVmmVirtualNetwork', 'New-AzScVmmVMInstanceGuestAgent', 'Remove-AzScVmmAvailabilitySet', 'Remove-AzScVmmCloud', 'Remove-AzScVmmInventoryItem', 'Remove-AzScVmmServer', 'Remove-AzScVmmVirtualMachineInstance', 'Remove-AzScVmmVirtualMachineInstanceCheckpoint', 'Remove-AzScVmmVirtualMachineTemplate', 'Remove-AzScVmmVirtualNetwork', 'Remove-AzScVmmVMInstanceGuestAgent', 'Restart-AzScVmmVirtualMachineInstance', 'Restore-AzScVmmVirtualMachineInstanceCheckpoint', 'Start-AzScVmmVirtualMachineInstance', 'Stop-AzScVmmVirtualMachineInstance', 'Update-AzScVmmAvailabilitySet', 'Update-AzScVmmCloud', 'Update-AzScVmmInventoryItem', 'Update-AzScVmmServer', 'Update-AzScVmmVirtualMachineInstance', 'Update-AzScVmmVirtualMachineTemplate', 'Update-AzScVmmVirtualNetwork', 'Update-AzScVmmVMInstanceGuestAgent'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'ScVmm'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
