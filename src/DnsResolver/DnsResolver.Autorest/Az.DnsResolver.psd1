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
  FunctionsToExport = 'Get-AzDnsForwardingRuleset', 'Get-AzDnsForwardingRulesetForwardingRule', 'Get-AzDnsForwardingRulesetVirtualNetworkLink', 'Get-AzDnsResolver', 'Get-AzDnsResolverDomainList', 'Get-AzDnsResolverInboundEndpoint', 'Get-AzDnsResolverOutboundEndpoint', 'Get-AzDnsResolverPolicy', 'Get-AzDnsResolverPolicyDnsSecurityRule', 'Get-AzDnsResolverPolicyVirtualNetworkLink', 'New-AzDnsForwardingRuleset', 'New-AzDnsForwardingRulesetForwardingRule', 'New-AzDnsForwardingRulesetVirtualNetworkLink', 'New-AzDnsResolver', 'New-AzDnsResolverDomainList', 'New-AzDnsResolverInboundEndpoint', 'New-AzDnsResolverIPConfigurationObject', 'New-AzDnsResolverOutboundEndpoint', 'New-AzDnsResolverPolicy', 'New-AzDnsResolverPolicyDnsSecurityRule', 'New-AzDnsResolverPolicyVirtualNetworkLink', 'New-AzDnsResolverTargetDnsServerObject', 'Remove-AzDnsForwardingRuleset', 'Remove-AzDnsForwardingRulesetForwardingRule', 'Remove-AzDnsForwardingRulesetVirtualNetworkLink', 'Remove-AzDnsResolver', 'Remove-AzDnsResolverDomainList', 'Remove-AzDnsResolverInboundEndpoint', 'Remove-AzDnsResolverOutboundEndpoint', 'Remove-AzDnsResolverPolicy', 'Remove-AzDnsResolverPolicyDnsSecurityRule', 'Remove-AzDnsResolverPolicyVirtualNetworkLink', 'Update-AzDnsForwardingRuleset', 'Update-AzDnsForwardingRulesetForwardingRule', 'Update-AzDnsForwardingRulesetVirtualNetworkLink', 'Update-AzDnsResolver', 'Update-AzDnsResolverDomainList', 'Update-AzDnsResolverInboundEndpoint', 'Update-AzDnsResolverOutboundEndpoint', 'Update-AzDnsResolverPolicy', 'Update-AzDnsResolverPolicyDnsSecurityRule', 'Update-AzDnsResolverPolicyVirtualNetworkLink', '*'
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
