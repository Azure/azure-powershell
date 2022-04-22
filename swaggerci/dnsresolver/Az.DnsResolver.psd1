@{
  GUID = 'debb7ec0-f431-4490-8a75-4a47fdcb7593'
  RootModule = './Az.DnsResolver.psm1'
  ModuleVersion = '0.1.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: DnsResolver cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.DnsResolver.private.dll'
  FormatsToProcess = './Az.DnsResolver.format.ps1xml'
  FunctionsToExport = 'Get-AzDnsResolver', 'Get-AzDnsResolverDnsForwardingRuleset', 'Get-AzDnsResolverForwardingRule', 'Get-AzDnsResolverInboundEndpoint', 'Get-AzDnsResolverOutboundEndpoint', 'Get-AzDnsResolverVirtualNetworkLink', 'New-AzDnsResolver', 'New-AzDnsResolverDnsForwardingRuleset', 'New-AzDnsResolverForwardingRule', 'New-AzDnsResolverInboundEndpoint', 'New-AzDnsResolverOutboundEndpoint', 'New-AzDnsResolverVirtualNetworkLink', 'Remove-AzDnsResolver', 'Remove-AzDnsResolverDnsForwardingRuleset', 'Remove-AzDnsResolverForwardingRule', 'Remove-AzDnsResolverInboundEndpoint', 'Remove-AzDnsResolverOutboundEndpoint', 'Remove-AzDnsResolverVirtualNetworkLink', 'Update-AzDnsResolver', 'Update-AzDnsResolverDnsForwardingRuleset', 'Update-AzDnsResolverForwardingRule', 'Update-AzDnsResolverInboundEndpoint', 'Update-AzDnsResolverOutboundEndpoint', 'Update-AzDnsResolverVirtualNetworkLink', '*'
  AliasesToExport = '*'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'DnsResolver'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
