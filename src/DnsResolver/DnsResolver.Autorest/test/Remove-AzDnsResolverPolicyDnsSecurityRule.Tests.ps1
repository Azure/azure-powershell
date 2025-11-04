if(($null -eq $TestName) -or ($TestName -contains 'Remove-AzDnsResolverPolicyDnsSecurityRule'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzDnsResolverPolicyDnsSecurityRule.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Remove-AzDnsResolverPolicyDnsSecurityRule' {
    It 'Delete a DNS security rule by name, expected DNS security rule deleted' {
        # ARRANGE
        $dnsResolverPolicyName = "psdnsresolverpolicyforrulename8y8cdzg";
        $dnsSecurityRuleName = "psdnssecurityrulename8y8cdzg";
        $dnsResolverDomainListName = "psdnsresolverdomainlistforrulename8y8cdzg";
        $resolverPolicy = New-AzDnsResolverPolicy -Name $dnsResolverPolicyName -ResourceGroupName $RESOURCE_GROUP_NAME -Location $location
        $domainList = New-AzDnsResolverDomainList -Name $dnsResolverDomainListName -ResourceGroupName $RESOURCE_GROUP_NAME -Location $location -Domain @("contoso.com.", "example.com.")
        $securityRule = New-AzDnsResolverPolicyDnsSecurityRule -Name $dnsSecurityRuleName -DnsResolverPolicyName $dnsResolverPolicyName -ResourceGroupName $RESOURCE_GROUP_NAME -Location $location -DnsResolverDomainList @{id = $domainList.Id;} -DnsSecurityRuleState "Enabled" -ActionType "Block" -Priority 100

        # ACT
        Remove-AzDnsResolverPolicyDnsSecurityRule -Name $dnsSecurityRuleName -DnsResolverPolicyName $dnsResolverPolicyName -ResourceGroupName $RESOURCE_GROUP_NAME

        # ASSERT
        {Get-AzDnsResolverPolicyDnsSecurityRule -DnsResolverPolicyName $dnsResolverPolicyName -DnsSecurityRuleName $dnsSecurityRuleName -ResourceGroupName $RESOURCE_GROUP_NAME } | Should -Throw
    
        # UNDO
        Start-Sleep -Seconds 5
        Remove-AzDnsResolverDomainList -Name $dnsResolverDomainListName -ResourceGroupName $RESOURCE_GROUP_NAME
        Start-Sleep -Seconds 5
        Remove-AzDnsResolverPolicy -Name $dnsResolverPolicyName -ResourceGroupName $RESOURCE_GROUP_NAME
    }

   It 'Delete a DNS security rule via identity, expected DNS security rule deleted' {
        # ARRANGE
        $dnsResolverPolicyName = "psdnsresolverpolicyforrulename0j9ujzg";
        $dnsSecurityRuleName = "psdnssecurityrulename0j9ujzg";
        $dnsResolverDomainListName = "psdnsresolverdomainlistforrulename0j9ujzg";
        $resolverPolicy = New-AzDnsResolverPolicy -Name $dnsResolverPolicyName -ResourceGroupName $RESOURCE_GROUP_NAME -Location $location
        $domainList = New-AzDnsResolverDomainList -Name $dnsResolverDomainListName -ResourceGroupName $RESOURCE_GROUP_NAME -Location $location -Domain @("contoso.com.", "example.com.")
        $securityRule = New-AzDnsResolverPolicyDnsSecurityRule -Name $dnsSecurityRuleName -DnsResolverPolicyName $dnsResolverPolicyName -ResourceGroupName $RESOURCE_GROUP_NAME -Location $location -DnsResolverDomainList @{id = $domainList.Id;} -DnsSecurityRuleState "Enabled" -ActionType "Block" -Priority 100

        # ACT
        Get-AzDnsResolverPolicyDnsSecurityRule -DnsResolverPolicyName $dnsResolverPolicyName -DnsSecurityRuleName $dnsSecurityRuleName -ResourceGroupName $RESOURCE_GROUP_NAME | Remove-AzDnsResolverPolicyDnsSecurityRule

        # ASSERT
        {Get-AzDnsResolverPolicyDnsSecurityRule -DnsResolverPolicyName $dnsResolverPolicyName -DnsSecurityRuleName $dnsSecurityRuleName -ResourceGroupName $RESOURCE_GROUP_NAME } | Should -Throw
    
        # UNDO
        Start-Sleep -Seconds 5
        Remove-AzDnsResolverDomainList -Name $dnsResolverDomainListName -ResourceGroupName $RESOURCE_GROUP_NAME
        Start-Sleep -Seconds 5
        Remove-AzDnsResolverPolicy -Name $dnsResolverPolicyName -ResourceGroupName $RESOURCE_GROUP_NAME
    }
}
