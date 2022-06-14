@{
  GUID = 'f4fd3a27-ddaa-4621-b69c-9d2e164f32bf'
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
  FunctionsToExport = 'Get-AzPeering', 'Get-AzPeeringCdnPeeringPrefix', 'Get-AzPeeringConnectionMonitorTest', 'Get-AzPeeringLegacyPeering', 'Get-AzPeeringLocation', 'Get-AzPeeringPeerAsn', 'Get-AzPeeringPrefix', 'Get-AzPeeringReceivedRoute', 'Get-AzPeeringRegisteredAsn', 'Get-AzPeeringRegisteredPrefix', 'Get-AzPeeringService', 'Get-AzPeeringServiceCountry', 'Get-AzPeeringServiceLocation', 'Get-AzPeeringServiceProvider', 'Initialize-AzPeeringServiceConnectionMonitor', 'Invoke-AzPeeringInvokeLookingGlass', 'New-AzPeering', 'New-AzPeeringConnectionMonitorTest', 'New-AzPeeringPeerAsn', 'New-AzPeeringPrefix', 'New-AzPeeringRegisteredAsn', 'New-AzPeeringRegisteredPrefix', 'New-AzPeeringService', 'Remove-AzPeering', 'Remove-AzPeeringConnectionMonitorTest', 'Remove-AzPeeringPeerAsn', 'Remove-AzPeeringPrefix', 'Remove-AzPeeringRegisteredAsn', 'Remove-AzPeeringRegisteredPrefix', 'Remove-AzPeeringService', 'Test-AzPeeringServiceProviderAvailability', 'Update-AzPeering', 'Update-AzPeeringService', '*'
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
