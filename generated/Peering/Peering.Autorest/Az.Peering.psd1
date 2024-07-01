@{
  GUID = '78c6a853-5ea3-4374-9c5f-5b532d62c892'
  RootModule = './Az.Peering.psm1'
  ModuleVersion = '0.1.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: Peering cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.Peering.private.dll'
  FormatsToProcess = './Az.Peering.format.ps1xml'
  FunctionsToExport = 'Get-AzPeering', 'Get-AzPeeringAsn', 'Get-AzPeeringCdnPrefix', 'Get-AzPeeringConnectionMonitorTest', 'Get-AzPeeringLegacy', 'Get-AzPeeringLocation', 'Get-AzPeeringReceivedRoute', 'Get-AzPeeringRegisteredAsn', 'Get-AzPeeringRegisteredPrefix', 'Get-AzPeeringRpUnbilledPrefix', 'Get-AzPeeringService', 'Get-AzPeeringServiceCountry', 'Get-AzPeeringServiceLocation', 'Get-AzPeeringServicePrefix', 'Get-AzPeeringServiceProvider', 'Initialize-AzPeeringServiceConnectionMonitor', 'New-AzPeering', 'New-AzPeeringAsn', 'New-AzPeeringCheckServiceProviderAvailabilityInputObject', 'New-AzPeeringConnectionMonitorTest', 'New-AzPeeringContactDetailObject', 'New-AzPeeringDirectConnectionObject', 'New-AzPeeringExchangeConnectionObject', 'New-AzPeeringRegisteredAsn', 'New-AzPeeringRegisteredPrefix', 'New-AzPeeringService', 'New-AzPeeringServicePrefix', 'Remove-AzPeering', 'Remove-AzPeeringAsn', 'Remove-AzPeeringConnectionMonitorTest', 'Remove-AzPeeringRegisteredAsn', 'Remove-AzPeeringRegisteredPrefix', 'Remove-AzPeeringService', 'Remove-AzPeeringServicePrefix', 'Start-AzPeeringInvokeLookingGlass', 'Test-AzPeeringRegisteredPrefix', 'Test-AzPeeringServiceProviderAvailability', 'Update-AzPeering', 'Update-AzPeeringService', '*'
  AliasesToExport = '*'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'Peering'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
