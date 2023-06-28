@{
  GUID = '787ef00f-9345-469d-9156-0654cdc69286'
  RootModule = './Az.PaloAltoNetworks.psm1'
  ModuleVersion = '0.1.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: PaloAltoNetworks cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.PaloAltoNetworks.private.dll'
  FormatsToProcess = './Az.PaloAltoNetworks.format.ps1xml'
  FunctionsToExport = 'Get-AzPaloAltoNetworksFirewall', 'Get-AzPaloAltoNetworksFirewallLogProfile', 'Get-AzPaloAltoNetworksFirewallStatus', 'Get-AzPaloAltoNetworksFirewallSupportInfo', 'Get-AzPaloAltoNetworksFqdnListLocalRulestack', 'Get-AzPaloAltoNetworksLocalRule', 'Get-AzPaloAltoNetworksLocalRuleCounter', 'Get-AzPaloAltoNetworksLocalRulestack', 'Get-AzPaloAltoNetworksLocalRulestackAdvancedSecurityObject', 'Get-AzPaloAltoNetworksLocalRulestackAppId', 'Get-AzPaloAltoNetworksLocalRulestackChangeLog', 'Get-AzPaloAltoNetworksLocalRulestackCountry', 'Get-AzPaloAltoNetworksLocalRulestackFirewall', 'Get-AzPaloAltoNetworksLocalRulestackPredefinedUrlCategory', 'Get-AzPaloAltoNetworksLocalRulestackSecurityService', 'Get-AzPaloAltoNetworksLocalRulestackSupportInfo', 'Get-AzPaloAltoNetworksPrefixListLocalRulestack', 'Invoke-AzPaloAltoNetworksCommitLocalRulestack', 'Invoke-AzPaloAltoNetworksRevertLocalRulestack', 'New-AzPaloAltoNetworksFirewall', 'New-AzPaloAltoNetworksFqdnListLocalRulestack', 'New-AzPaloAltoNetworksFrontendSettingObject', 'New-AzPaloAltoNetworksIPAddressObject', 'New-AzPaloAltoNetworksLocalRule', 'New-AzPaloAltoNetworksLocalRulestack', 'New-AzPaloAltoNetworksNetworkProfileObject', 'New-AzPaloAltoNetworksPrefixListLocalRulestack', 'New-AzPaloAltoNetworksTagInfoObject', 'Remove-AzPaloAltoNetworksFirewall', 'Remove-AzPaloAltoNetworksFqdnListLocalRulestack', 'Remove-AzPaloAltoNetworksLocalRule', 'Remove-AzPaloAltoNetworksLocalRulestack', 'Remove-AzPaloAltoNetworksPrefixListLocalRulestack', 'Reset-AzPaloAltoNetworksLocalRuleCounter', 'Save-AzPaloAltoNetworksFirewallLogProfile', 'Update-AzPaloAltoNetworksFirewall', 'Update-AzPaloAltoNetworksLocalRuleCounter', 'Update-AzPaloAltoNetworksLocalRulestack', '*'
  AliasesToExport = '*'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'PaloAltoNetworks'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
