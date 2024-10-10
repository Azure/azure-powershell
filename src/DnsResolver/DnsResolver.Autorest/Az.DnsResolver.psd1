@{
  GUID = '88e239b3-f615-4018-adf3-f0952a0f46a8'
  RootModule = './Az.DnsResolver.psm1'
  ModuleVersion = '0.2.9'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: DnsResolver cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.DnsResolver.private.dll'
  FormatsToProcess = './Az.DnsResolver.format.ps1xml'
  FunctionsToExport = 'Get-AzDnsForwardingRuleset', 'Get-AzDnsForwardingRulesetDnsResolverPolicyVirtualNetworkLink', 'Get-AzDnsForwardingRulesetForwardingRule', 'Get-AzDnsForwardingRulesetVirtualNetworkLink', 'Get-AzDnsResolver', 'Get-AzDnsResolverDnsSecurityRule', 'Get-AzDnsResolverDomainList', 'Get-AzDnsResolverInboundEndpoint', 'Get-AzDnsResolverOutboundEndpoint', 'Get-AzDnsResolverPolicy', 'New-AzDnsForwardingRuleset', 'New-AzDnsForwardingRulesetDnsResolverPolicyVirtualNetworkLink', 'New-AzDnsForwardingRulesetForwardingRule', 'New-AzDnsForwardingRulesetVirtualNetworkLink', 'New-AzDnsResolver', 'New-AzDnsResolverDnsSecurityRule', 'New-AzDnsResolverDomainList', 'New-AzDnsResolverInboundEndpoint', 'New-AzDnsResolverIPConfigurationObject', 'New-AzDnsResolverOutboundEndpoint', 'New-AzDnsResolverPolicy', 'New-AzDnsResolverTargetDnsServerObject', 'Remove-AzDnsForwardingRuleset', 'Remove-AzDnsForwardingRulesetDnsResolverPolicyVirtualNetworkLink', 'Remove-AzDnsForwardingRulesetForwardingRule', 'Remove-AzDnsForwardingRulesetVirtualNetworkLink', 'Remove-AzDnsResolver', 'Remove-AzDnsResolverDnsSecurityRule', 'Remove-AzDnsResolverDomainList', 'Remove-AzDnsResolverInboundEndpoint', 'Remove-AzDnsResolverOutboundEndpoint', 'Remove-AzDnsResolverPolicy', 'Update-AzDnsForwardingRuleset', 'Update-AzDnsForwardingRulesetDnsResolverPolicyVirtualNetworkLink', 'Update-AzDnsForwardingRulesetForwardingRule', 'Update-AzDnsForwardingRulesetVirtualNetworkLink', 'Update-AzDnsResolver', 'Update-AzDnsResolverDnsSecurityRule', 'Update-AzDnsResolverDomainList', 'Update-AzDnsResolverInboundEndpoint', 'Update-AzDnsResolverOutboundEndpoint', 'Update-AzDnsResolverPolicy', '*'
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
