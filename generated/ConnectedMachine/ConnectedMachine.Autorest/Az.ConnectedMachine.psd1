@{
  GUID = '368c49bb-8fdf-4c4d-96bd-47d9f9cd5734'
  RootModule = './Az.ConnectedMachine.psm1'
  ModuleVersion = '0.1.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: ConnectedMachine cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.ConnectedMachine.private.dll'
  FormatsToProcess = './Az.ConnectedMachine.format.ps1xml'
  FunctionsToExport = 'Connect-AzConnectedMachine', 'Get-AzConnectedExtensionMetadata', 'Get-AzConnectedLicense', 'Get-AzConnectedMachine', 'Get-AzConnectedMachineExtension', 'Get-AzConnectedNetworkSecurityPerimeterConfiguration', 'Get-AzConnectedPrivateLinkScope', 'Install-AzConnectedMachinePatch', 'Invoke-AzConnectedAssessMachinePatch', 'Invoke-AzConnectedReconcileNetworkSecurityPerimeterConfiguration', 'New-AzConnectedLicense', 'New-AzConnectedLicenseDetail', 'New-AzConnectedMachineExtension', 'New-AzConnectedPrivateLinkScope', 'Remove-AzConnectedLicense', 'Remove-AzConnectedMachine', 'Remove-AzConnectedMachineExtension', 'Remove-AzConnectedPrivateLinkScope', 'Set-AzConnectedLicense', 'Set-AzConnectedMachineExtension', 'Set-AzConnectedPrivateLinkScope', 'Update-AzConnectedExtension', 'Update-AzConnectedMachine', 'Update-AzConnectedMachineExtension', 'Update-AzConnectedPrivateLinkScopeTag'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'ConnectedMachine'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
