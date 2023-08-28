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
  FunctionsToExport = 'Get-AzConnectedVMwareCluster', 'Get-AzConnectedVMwareDatastore', 'Get-AzConnectedVMwareHost', 'Get-AzConnectedVMwareInventoryItem', 'Get-AzConnectedVMwareResourcePool', 'Get-AzConnectedVMwareVCenter', 'Get-AzConnectedVMwareVMInstance', 'Get-AzConnectedVMwareVMInstanceGuestAgent', 'Get-AzConnectedVMwareVMInstanceHybridIdentityMetadata', 'Get-AzConnectedVMwareVMTemplate', 'Get-AzConnectedVMwareVNet', 'New-AzConnectedVMwareCluster', 'New-AzConnectedVMwareDatastore', 'New-AzConnectedVMwareHost', 'New-AzConnectedVMwareInventoryItem', 'New-AzConnectedVMwareResourcePool', 'New-AzConnectedVMwareVCenter', 'New-AzConnectedVMwareVMInstance', 'New-AzConnectedVMwareVMInstanceGuestAgent', 'New-AzConnectedVMwareVMTemplate', 'New-AzConnectedVMwareVNet', 'Remove-AzConnectedVMwareCluster', 'Remove-AzConnectedVMwareDatastore', 'Remove-AzConnectedVMwareHost', 'Remove-AzConnectedVMwareInventoryItem', 'Remove-AzConnectedVMwareResourcePool', 'Remove-AzConnectedVMwareVCenter', 'Remove-AzConnectedVMwareVMInstance', 'Remove-AzConnectedVMwareVMInstanceGuestAgent', 'Remove-AzConnectedVMwareVMTemplate', 'Remove-AzConnectedVMwareVNet', 'Restart-AzConnectedVMwareVMInstance', 'Start-AzConnectedVMwareVMInstance', 'Stop-AzConnectedVMwareVMInstance', 'Update-AzConnectedVMwareCluster', 'Update-AzConnectedVMwareDatastore', 'Update-AzConnectedVMwareHost', 'Update-AzConnectedVMwareResourcePool', 'Update-AzConnectedVMwareVCenter', 'Update-AzConnectedVMwareVMInstance', 'Update-AzConnectedVMwareVMTemplate', 'Update-AzConnectedVMwareVNet', '*'
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
