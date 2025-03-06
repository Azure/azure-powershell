@{
  GUID = '7ea61e8f-5ed6-47dc-ba45-306cec0eb4f7'
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
  FunctionsToExport = 'Get-AzScVmmAvailabilitySet', 'Get-AzScVmmCloud', 'Get-AzScVmmGuestAgent', 'Get-AzScVmmInventoryItem', 'Get-AzScVmmServer', 'Get-AzScVmmVirtualMachineInstance', 'Get-AzScVmmVirtualMachineTemplate', 'Get-AzScVmmVirtualNetwork', 'Get-AzScVmmVMInstanceHybridIdentityMetadata', 'New-AzScVmmAvailabilitySet', 'New-AzScVmmCloud', 'New-AzScVmmGuestAgent', 'New-AzScVmmInventoryItem', 'New-AzScVmmServer', 'New-AzScVmmVirtualMachineInstance', 'New-AzScVmmVirtualMachineInstanceCheckpoint', 'New-AzScVmmVirtualMachineTemplate', 'New-AzScVmmVirtualNetwork', 'Remove-AzScVmmAvailabilitySet', 'Remove-AzScVmmCloud', 'Remove-AzScVmmGuestAgent', 'Remove-AzScVmmInventoryItem', 'Remove-AzScVmmServer', 'Remove-AzScVmmVirtualMachineInstance', 'Remove-AzScVmmVirtualMachineInstanceCheckpoint', 'Remove-AzScVmmVirtualMachineTemplate', 'Remove-AzScVmmVirtualNetwork', 'Restart-AzScVmmVirtualMachineInstance', 'Restore-AzScVmmVirtualMachineInstanceCheckpoint', 'Set-AzScVmmAvailabilitySet', 'Set-AzScVmmCloud', 'Set-AzScVmmServer', 'Set-AzScVmmVirtualMachineInstance', 'Set-AzScVmmVirtualMachineTemplate', 'Set-AzScVmmVirtualNetwork', 'Start-AzScVmmVirtualMachineInstance', 'Stop-AzScVmmVirtualMachineInstance', 'Update-AzScVmmAvailabilitySet', 'Update-AzScVmmCloud', 'Update-AzScVmmGuestAgent', 'Update-AzScVmmInventoryItem', 'Update-AzScVmmServer', 'Update-AzScVmmVirtualMachineInstance', 'Update-AzScVmmVirtualMachineTemplate', 'Update-AzScVmmVirtualNetwork'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'ScVmm'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
