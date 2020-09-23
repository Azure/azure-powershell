@{
  GUID = '259a0542-8329-4b9e-8f72-dab0efc583e9'
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
  FunctionsToExport = 'Connect-AzConnectedMachine', 'Get-AzConnectedMachine', 'Get-AzConnectedMachineExtension', 'New-AzConnectedMachineExtension', 'Remove-AzConnectedMachine', 'Remove-AzConnectedMachineExtension', 'Set-AzConnectedMachineExtension', 'Update-AzConnectedMachineExtension', '*'
  AliasesToExport = '*'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'ConnectedMachine'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
