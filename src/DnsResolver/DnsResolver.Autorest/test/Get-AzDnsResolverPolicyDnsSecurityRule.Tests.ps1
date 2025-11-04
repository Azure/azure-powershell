if(($null -eq $TestName) -or ($TestName -contains 'Get-AzDnsResolverPolicyDnsSecurityRule'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzDnsResolverPolicyDnsSecurityRule.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzDnsResolverPolicyDnsSecurityRule' {
    It 'Get single DNS security rule by name, expect DNS security rule by name retrieved' {
        # ARRANGE
        $dnsResolverPolicyName = "psdnsresolverpolicyforrulename1m0cdag";
        $dnsSecurityRuleName = "psdnssecurityrulename1m0cdag";
        $dnsResolverDomainListName = "psdnsresolverdomainlistforrulename1m0cdag";
        $resolverPolicy = New-AzDnsResolverPolicy -Name $dnsResolverPolicyName -ResourceGroupName $RESOURCE_GROUP_NAME -Location $location
        $domainList = New-AzDnsResolverDomainList -Name $dnsResolverDomainListName -ResourceGroupName $RESOURCE_GROUP_NAME -Location $location -Domain @("contoso.com.", "example.com.")
        $securityRule = New-AzDnsResolverPolicyDnsSecurityRule -Name $dnsSecurityRuleName -DnsResolverPolicyName $dnsResolverPolicyName -ResourceGroupName $RESOURCE_GROUP_NAME -Location $location -DnsResolverDomainList @{id = $domainList.Id;} -DnsSecurityRuleState "Enabled" -ActionType "Block" -Priority 100

        # ACT - ASSERT
        {Get-AzDnsResolverPolicyDnsSecurityRule -Name $dnsSecurityRuleName -DnsResolverPolicyName $dnsResolverPolicyName -ResourceGroupName $RESOURCE_GROUP_NAME} | Should -Not -Throw
    
        # UNDO
        Start-Sleep -Seconds 5
        Remove-AzDnsResolverPolicyDnsSecurityRule -DnsResolverPolicyName $dnsResolverPolicyName -DnsSecurityRuleName $dnsSecurityRuleName -ResourceGroupName $RESOURCE_GROUP_NAME
        Start-Sleep -Seconds 5
        Remove-AzDnsResolverDomainList -Name $dnsResolverDomainListName -ResourceGroupName $RESOURCE_GROUP_NAME
        Start-Sleep -Seconds 5
        Remove-AzDnsResolverPolicy -Name $dnsResolverPolicyName -ResourceGroupName $RESOURCE_GROUP_NAME
    }

    It 'List DNS resolver policies in a resource group, expected least number of DNS resolver policies retrieved' {
        # ARRANGE
        $dnsResolverPolicyName = "psdnsresolverpolicyforrulename2n1edag";
        $dnsSecurityRuleName = "psdnssecurityrulename2n1edag";
        $dnsResolverDomainListName = "psdnsresolverdomainlistforrulename2n1edag";
        $resolverPolicy = New-AzDnsResolverPolicy -Name $dnsResolverPolicyName -ResourceGroupName $RESOURCE_GROUP_NAME -Location $location
        $domainList = New-AzDnsResolverDomainList -Name $dnsResolverDomainListName -ResourceGroupName $RESOURCE_GROUP_NAME -Location $location -Domain @("contoso.com.", "example.com.")
        $securityRule = New-AzDnsResolverPolicyDnsSecurityRule -Name $dnsSecurityRuleName -DnsResolverPolicyName $dnsResolverPolicyName -ResourceGroupName $RESOURCE_GROUP_NAME -Location $location -DnsResolverDomainList @{id = $domainList.Id;} -DnsSecurityRuleState "Enabled" -ActionType "Block" -Priority 100

        # ACT
        $securityRules =  Get-AzDnsResolverPolicyDnsSecurityRule -DnsResolverPolicyName $dnsResolverPolicyName -ResourceGroupName $RESOURCE_GROUP_NAME

        # ASSERT
        $securityRules.Count | Should -BeGreaterThan 0

        # UNDO
        Start-Sleep -Seconds 5
        Remove-AzDnsResolverPolicyDnsSecurityRule -DnsResolverPolicyName $dnsResolverPolicyName -DnsSecurityRuleName $dnsSecurityRuleName -ResourceGroupName $RESOURCE_GROUP_NAME
        Start-Sleep -Seconds 5
        Remove-AzDnsResolverDomainList -Name $dnsResolverDomainListName -ResourceGroupName $RESOURCE_GROUP_NAME
        Start-Sleep -Seconds 5
        Remove-AzDnsResolverPolicy -Name $dnsResolverPolicyName -ResourceGroupName $RESOURCE_GROUP_NAME
    }
}
