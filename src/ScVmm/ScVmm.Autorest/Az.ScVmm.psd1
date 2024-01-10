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
  FunctionsToExport = 'Get-AzScVmmAvailabilitySet', 'Get-AzScVmmCloud', 'Get-AzScVmmInventoryItem', 'Get-AzScVmmServer', 'Get-AzScVmmVirtualNetwork', 'Get-AzScVmmVM', 'Get-AzScVmmVMGuestAgent', 'Get-AzScVmmVMHybridIdentityMetadata', 'Get-AzScVmmVMTemplate', 'New-AzScVmmAvailabilitySet', 'New-AzScVmmAvailabilitySetListItemObject', 'New-AzScVmmCheckpointObject', 'New-AzScVmmCloud', 'New-AzScVmmInventoryItem', 'New-AzScVmmNetworkInterfaceObject', 'New-AzScVmmNetworkInterfaceUpdateObject', 'New-AzScVmmServer', 'New-AzScVmmVirtualDiskObject', 'New-AzScVmmVirtualDiskUpdateObject', 'New-AzScVmmVirtualNetwork', 'New-AzScVmmVM', 'New-AzScVmmVMCheckpoint', 'New-AzScVmmVMGuestAgent', 'New-AzScVmmVMTemplate', 'Remove-AzScVmmAvailabilitySet', 'Remove-AzScVmmCloud', 'Remove-AzScVmmInventoryItem', 'Remove-AzScVmmServer', 'Remove-AzScVmmVirtualNetwork', 'Remove-AzScVmmVM', 'Remove-AzScVmmVMCheckpoint', 'Remove-AzScVmmVMGuestAgent', 'Remove-AzScVmmVMTemplate', 'Restart-AzScVmmVM', 'Restore-AzScVmmVMCheckpoint', 'Start-AzScVmmVM', 'Stop-AzScVmmVM', 'Update-AzScVmmAvailabilitySet', 'Update-AzScVmmCloud', 'Update-AzScVmmServer', 'Update-AzScVmmVirtualNetwork', 'Update-AzScVmmVM', 'Update-AzScVmmVMGuestAgent', 'Update-AzScVmmVMTemplate'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'ScVmm'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
