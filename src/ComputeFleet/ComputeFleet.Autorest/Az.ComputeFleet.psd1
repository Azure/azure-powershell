@{
  GUID = '957f617c-6cbe-4ea3-b46c-ab3ae8eddb3c'
  RootModule = './Az.ComputeFleet.psm1'
  ModuleVersion = '0.2.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: ComputeFleet cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.ComputeFleet.private.dll'
  FormatsToProcess = './Az.ComputeFleet.format.ps1xml'
  FunctionsToExport = 'Get-AzComputeFleetMarketplaceAgreement', 'Get-AzComputeFleetOrganization', 'New-AzComputeFleetOrganization', 'Remove-AzComputeFleetOrganization', 'Update-AzComputeFleetOrganization', '*'
  AliasesToExport = '*'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'ComputeFleet'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
