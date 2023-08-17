@{
  GUID = '88e239b3-f615-4018-adf3-f0952a0f46a8'
  RootModule = './Az.DnsResolver.psm1'
  ModuleVersion = '0.2.1'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: DnsResolver cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.DnsResolver.private.dll'
  FormatsToProcess = './Az.DnsResolver.format.ps1xml'
  FunctionsToExport = 'Get-AzDnsForwardingRuleset', 'Get-AzDnsForwardingRulesetForwardingRule', 'Get-AzDnsForwardingRulesetVirtualNetworkLink', 'Get-AzDnsResolver', 'Get-AzDnsResolverInboundEndpoint', 'Get-AzDnsResolverOutboundEndpoint', 'New-AzDnsForwardingRuleset', 'New-AzDnsForwardingRulesetForwardingRule', 'New-AzDnsForwardingRulesetVirtualNetworkLink', 'New-AzDnsResolver', 'New-AzDnsResolverInboundEndpoint', 'New-AzDnsResolverIPConfigurationObject', 'New-AzDnsResolverOutboundEndpoint', 'New-AzDnsResolverTargetDnsServerObject', 'Remove-AzDnsForwardingRuleset', 'Remove-AzDnsForwardingRulesetForwardingRule', 'Remove-AzDnsForwardingRulesetVirtualNetworkLink', 'Remove-AzDnsResolver', 'Remove-AzDnsResolverInboundEndpoint', 'Remove-AzDnsResolverOutboundEndpoint', 'Update-AzDnsForwardingRuleset', 'Update-AzDnsForwardingRulesetForwardingRule', 'Update-AzDnsForwardingRulesetVirtualNetworkLink', 'Update-AzDnsResolver', 'Update-AzDnsResolverInboundEndpoint', 'Update-AzDnsResolverOutboundEndpoint', '*'
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
