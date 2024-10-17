@{
  GUID = 'b65e8f96-90e3-45f1-9d1e-37daff2dd80a'
  RootModule = './Az.PrivateDns.psm1'
  ModuleVersion = '1.1.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: PrivateDns cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.PrivateDns.private.dll'
  FormatsToProcess = './Az.PrivateDns.format.ps1xml'
  FunctionsToExport = 'Get-AzPrivateDnsVirtualNetworkLink', 'New-AzPrivateDnsVirtualNetworkLink', 'Remove-AzPrivateDnsVirtualNetworkLink', 'Update-AzPrivateDnsVirtualNetworkLink', '*'
  AliasesToExport = '*'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'PrivateDns'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
