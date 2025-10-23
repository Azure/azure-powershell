@{
  GUID = '9435e7a6-441e-47d6-a9a8-fce807710d97'
  RootModule = './Az.DnsResolver.psm1'
  ModuleVersion = '1.3.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: DnsResolver cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.DnsResolver.private.dll'
  FormatsToProcess = './Az.DnsResolver.format.ps1xml'
  FunctionsToExport = 'Get-AzDnsForwardingRuleset', 'Get-AzDnsForwardingRulesetForwardingRule', 'Get-AzDnsForwardingRulesetVirtualNetworkLink', 'Get-AzDnsResolver', 'Get-AzDnsResolverDomainList', 'Get-AzDnsResolverInboundEndpoint', 'Get-AzDnsResolverOutboundEndpoint', 'Get-AzDnsResolverPolicy', 'Get-AzDnsResolverPolicyDnsSecurityRule', 'Get-AzDnsResolverPolicyVirtualNetworkLink', 'Invoke-AzDnsResolverBulkDnsResolverDomainList', 'New-AzDnsForwardingRuleset', 'New-AzDnsForwardingRulesetForwardingRule', 'New-AzDnsForwardingRulesetVirtualNetworkLink', 'New-AzDnsResolver', 'New-AzDnsResolverDomainList', 'New-AzDnsResolverInboundEndpoint', 'New-AzDnsResolverIPConfigurationObject', 'New-AzDnsResolverOutboundEndpoint', 'New-AzDnsResolverPolicy', 'New-AzDnsResolverPolicyDnsSecurityRule', 'New-AzDnsResolverPolicyVirtualNetworkLink', 'New-AzDnsResolverTargetDnsServerObject', 'Remove-AzDnsForwardingRuleset', 'Remove-AzDnsForwardingRulesetForwardingRule', 'Remove-AzDnsForwardingRulesetVirtualNetworkLink', 'Remove-AzDnsResolver', 'Remove-AzDnsResolverDomainList', 'Remove-AzDnsResolverInboundEndpoint', 'Remove-AzDnsResolverOutboundEndpoint', 'Remove-AzDnsResolverPolicy', 'Remove-AzDnsResolverPolicyDnsSecurityRule', 'Remove-AzDnsResolverPolicyVirtualNetworkLink', 'Update-AzDnsForwardingRuleset', 'Update-AzDnsForwardingRulesetForwardingRule', 'Update-AzDnsForwardingRulesetVirtualNetworkLink', 'Update-AzDnsResolver', 'Update-AzDnsResolverDomainList', 'Update-AzDnsResolverInboundEndpoint', 'Update-AzDnsResolverOutboundEndpoint', 'Update-AzDnsResolverPolicy', 'Update-AzDnsResolverPolicyDnsSecurityRule', 'Update-AzDnsResolverPolicyVirtualNetworkLink', '*'
  AliasesToExport = '*'
  PrivateData = @{
    PSData = @{
      Prerelease = 'preview'
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'DnsResolver'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
