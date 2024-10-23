if(($null -eq $TestName) -or ($TestName -contains 'New-AzDnsResolverPolicyDnsSecurityRule'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzDnsResolverPolicyDnsSecurityRule.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzDnsResolverPolicyDnsSecurityRule' {
    It 'Create DNS security rule' {
        # ARRANGE
        $dnsResolverPolicyName = "psdnsresolverpolicyforrulename0j0cdzg";
        $dnsSecurityRuleName = "psdnssecurityrulename0j0cdzg";
        $dnsResolverDomainListName = "psdnsresolverdomainlistforrulename0j0cdzg";
        $resourceGroupName = "powershell-test-rg-debug-new";
        $location = "westus2";
        $resolverPolicy = New-AzDnsResolverPolicy -Name $dnsResolverPolicyName -ResourceGroupName $resourceGroupName -Location $location
        $domainList = New-AzDnsResolverDomainList -Name $dnsResolverDomainListName -ResourceGroupName $resourceGroupName -Location $location -Domain @("contoso.com.", "example.com.")

        # ACT
        $securityRule = New-AzDnsResolverPolicyDnsSecurityRule -Name $dnsSecurityRuleName -DnsResolverPolicyName $dnsResolverPolicyName -ResourceGroupName $resourceGroupName -Location $location -DnsResolverDomainList @{id = $domainList.Id;} -DnsSecurityRuleState "Enabled" -ActionType "Block" -ActionBlockResponseCode "SERVFAIL" -Priority 100

        # ASSERT
        {Get-AzDnsResolverPolicyDnsSecurityRule -DnsResolverPolicyName $dnsResolverPolicyName -DnsSecurityRuleName $dnsSecurityRuleName -ResourceGroupName $resourceGroupName } | Should -Not -Throw
    }
}
