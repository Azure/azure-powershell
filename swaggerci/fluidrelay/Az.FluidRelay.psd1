@{
  GUID = '1b2d6822-52c7-421f-80c2-fe3876bfd620'
  RootModule = './Az.FluidRelay.psm1'
  ModuleVersion = '0.1.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: FluidRelay cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.FluidRelay.private.dll'
  FormatsToProcess = './Az.FluidRelay.format.ps1xml'
  FunctionsToExport = 'Get-AzFluidRelayOperation', 'Get-AzFluidRelayServer', 'Get-AzFluidRelayServerKey', 'New-AzFluidRelayServer', 'New-AzFluidRelayServerKey', 'Remove-AzFluidRelayServer', 'Update-AzFluidRelayServer', '*'
  AliasesToExport = '*'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'FluidRelay'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
