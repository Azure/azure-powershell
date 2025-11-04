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
        $resolverPolicy = New-AzDnsResolverPolicy -Name $dnsResolverPolicyName -ResourceGroupName $RESOURCE_GROUP_NAME -Location $location
        $domainList = New-AzDnsResolverDomainList -Name $dnsResolverDomainListName -ResourceGroupName $RESOURCE_GROUP_NAME -Location $location -Domain @("contoso.com.", "example.com.")
        $securityRule = New-AzDnsResolverPolicyDnsSecurityRule -Name $dnsSecurityRuleName -DnsResolverPolicyName $dnsResolverPolicyName -ResourceGroupName $RESOURCE_GROUP_NAME -Location $location -DnsResolverDomainList @{id = $domainList.Id;} -DnsSecurityRuleState "Enabled" -ActionType "Block" -Priority 100

        # ACT
        $securityRule = Update-AzDnsResolverPolicyDnsSecurityRule -Name $dnsSecurityRuleName -DnsResolverPolicyName $dnsResolverPolicyName -ResourceGroupName $RESOURCE_GROUP_NAME -Priority 101

        # ASSERT
        $updatedSecurityRule = Get-AzDnsResolverPolicyDnsSecurityRule -DnsResolverPolicyName $dnsResolverPolicyName -DnsSecurityRuleName $dnsSecurityRuleName -ResourceGroupName $RESOURCE_GROUP_NAME
        $securityRule.Priority | Should -Be 101

        # UNDO
        Start-Sleep -Seconds 5
        Remove-AzDnsResolverPolicyDnsSecurityRule -DnsResolverPolicyName $dnsResolverPolicyName -DnsSecurityRuleName $dnsSecurityRuleName -ResourceGroupName $RESOURCE_GROUP_NAME
        Start-Sleep -Seconds 5
        Remove-AzDnsResolverDomainList -Name $dnsResolverDomainListName -ResourceGroupName $RESOURCE_GROUP_NAME
        Start-Sleep -Seconds 5
        Remove-AzDnsResolverPolicy -Name $dnsResolverPolicyName -ResourceGroupName $RESOURCE_GROUP_NAME
    }
}
