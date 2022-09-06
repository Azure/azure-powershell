@{
  GUID = 'a0ad279a-4e68-428d-8864-28b698ac90f8'
  RootModule = './Az.ConnectedVMware.psm1'
  ModuleVersion = '0.1.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: ConnectedVMware cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.ConnectedVMware.private.dll'
  FormatsToProcess = './Az.ConnectedVMware.format.ps1xml'
  FunctionsToExport = 'Get-AzConnectedVMwareCluster', 'Get-AzConnectedVMwareDatastore', 'Get-AzConnectedVMwareGuestAgent', 'Get-AzConnectedVMwareHost', 'Get-AzConnectedVMwareHybridIdentityMetadata', 'Get-AzConnectedVMwareInventoryItem', 'Get-AzConnectedVMwareMachineExtension', 'Get-AzConnectedVMwareResourcePool', 'Get-AzConnectedVMwareVCenter', 'Get-AzConnectedVMwareVirtualMachine', 'Get-AzConnectedVMwareVirtualMachineTemplate', 'Get-AzConnectedVMwareVirtualNetwork', 'Install-AzConnectedVMwareVirtualMachinePatch', 'Invoke-AzConnectedVMwareAssessVirtualMachinePatch', 'New-AzConnectedVMwareCluster', 'New-AzConnectedVMwareDatastore', 'New-AzConnectedVMwareGuestAgent', 'New-AzConnectedVMwareHost', 'New-AzConnectedVMwareHybridIdentityMetadata', 'New-AzConnectedVMwareInventoryItem', 'New-AzConnectedVMwareMachineExtension', 'New-AzConnectedVMwareResourcePool', 'New-AzConnectedVMwareVCenter', 'New-AzConnectedVMwareVirtualMachine', 'New-AzConnectedVMwareVirtualMachineTemplate', 'New-AzConnectedVMwareVirtualNetwork', 'Remove-AzConnectedVMwareCluster', 'Remove-AzConnectedVMwareDatastore', 'Remove-AzConnectedVMwareGuestAgent', 'Remove-AzConnectedVMwareHost', 'Remove-AzConnectedVMwareHybridIdentityMetadata', 'Remove-AzConnectedVMwareInventoryItem', 'Remove-AzConnectedVMwareMachineExtension', 'Remove-AzConnectedVMwareResourcePool', 'Remove-AzConnectedVMwareVCenter', 'Remove-AzConnectedVMwareVirtualMachine', 'Remove-AzConnectedVMwareVirtualMachineTemplate', 'Remove-AzConnectedVMwareVirtualNetwork', 'Restart-AzConnectedVMwareVirtualMachine', 'Start-AzConnectedVMwareVirtualMachine', 'Stop-AzConnectedVMwareVirtualMachine', 'Update-AzConnectedVMwareCluster', 'Update-AzConnectedVMwareDatastore', 'Update-AzConnectedVMwareHost', 'Update-AzConnectedVMwareMachineExtension', 'Update-AzConnectedVMwareResourcePool', 'Update-AzConnectedVMwareVCenter', 'Update-AzConnectedVMwareVirtualMachine', 'Update-AzConnectedVMwareVirtualMachineTemplate', 'Update-AzConnectedVMwareVirtualNetwork', '*'
  AliasesToExport = '*'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'ConnectedVMware'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
