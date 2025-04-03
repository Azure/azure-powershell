@{
  GUID = '7ebdca69-2cd3-40e4-aeae-4c34d4188eee'
  RootModule = './Az.ComputeFleet.psm1'
  ModuleVersion = '0.1.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: ComputeFleet cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.ComputeFleet.private.dll'
  FormatsToProcess = './Az.ComputeFleet.format.ps1xml'
  FunctionsToExport = 'Get-AzComputeFleet', 'Get-AzComputeFleetVMSS', 'New-AzComputeFleet', 'Remove-AzComputeFleet', 'Update-AzComputeFleet'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'ComputeFleet'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
