@{
  GUID = '5b50d9cb-6a6c-43c3-9cbf-24c0c7233926'
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
  FunctionsToExport = 'Get-AzFluidRelayContainer', 'Get-AzFluidRelayServer', 'Get-AzFluidRelayServerKey', 'New-AzFluidRelayServer', 'New-AzFluidRelayServerKey', 'Remove-AzFluidRelayContainer', 'Remove-AzFluidRelayServer', 'Update-AzFluidRelayServer', '*'
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
