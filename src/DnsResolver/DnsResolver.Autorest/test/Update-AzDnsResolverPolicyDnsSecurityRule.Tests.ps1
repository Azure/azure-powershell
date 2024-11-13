if(($null -eq $TestName) -or ($TestName -contains 'Update-AzDnsResolverPolicyDnsSecurityRule'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzDnsResolverPolicyDnsSecurityRule.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzDnsResolverPolicyDnsSecurityRule' {
    It 'Updates a DNS Security Rule' {
        # ARRANGE
        $dnsResolverPolicyName = "psdnsresolverpolicyforrulename5cd8dcg";
        $dnsSecurityRuleName = "psdnssecurityrulename5cd8dcg";
        $dnsResolverDomainListName = "psdnsresolverdomainlistforrulename5cd8dcg";
        $resourceGroupName = "powershell-test-rg-debug-update";
        $location = "westus2";
        $resolverPolicy = New-AzDnsResolverPolicy -Name $dnsResolverPolicyName -ResourceGroupName $resourceGroupName -Location $location
        $domainList = New-AzDnsResolverDomainList -Name $dnsResolverDomainListName -ResourceGroupName $resourceGroupName -Location $location -Domain @("contoso.com.", "example.com.")
        $securityRule = New-AzDnsResolverPolicyDnsSecurityRule -Name $dnsSecurityRuleName -DnsResolverPolicyName $dnsResolverPolicyName -ResourceGroupName $resourceGroupName -Location $location -DnsResolverDomainList @{id = $domainList.Id;} -DnsSecurityRuleState "Enabled" -ActionType "Block" -ActionBlockResponseCode "SERVFAIL" -Priority 100

        # ACT
        $securityRule = Update-AzDnsResolverPolicyDnsSecurityRule -Name $dnsSecurityRuleName -DnsResolverPolicyName $dnsResolverPolicyName -ResourceGroupName $resourceGroupName -Priority 101

        # ASSERT
        $updatedSecurityRule = Get-AzDnsResolverPolicyDnsSecurityRule -DnsResolverPolicyName $dnsResolverPolicyName -DnsSecurityRuleName $dnsSecurityRuleName -ResourceGroupName $resourceGroupName
        $securityRule.Priority | Should -Be 101
    }
}
