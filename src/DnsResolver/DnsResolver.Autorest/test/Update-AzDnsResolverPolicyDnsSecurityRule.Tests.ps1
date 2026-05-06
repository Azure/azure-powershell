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

# Load post-merge test helper for routing to Frontend endpoint
. (Join-Path $PSScriptRoot 'postMergeTestHelper.ps1')
if ($TestMode -ne 'playback') {
    $postMergeStep = New-PostMergeTestHttpPipelineStep
    $existingMock = $PSDefaultParameterValues["*:HttpPipelinePrepend"]
    $PSDefaultParameterValues["*:HttpPipelinePrepend"] = [Microsoft.Azure.PowerShell.Cmdlets.DnsResolver.Runtime.SendAsyncStep[]]@(
        [Microsoft.Azure.PowerShell.Cmdlets.DnsResolver.Runtime.SendAsyncStep]$postMergeStep,
        [Microsoft.Azure.PowerShell.Cmdlets.DnsResolver.Runtime.SendAsyncStep]$existingMock
    )
}

Describe 'Update-AzDnsResolverPolicyDnsSecurityRule' {
    It 'Updates a DNS Security Rule priority' {
        # ARRANGE
        $dnsResolverPolicyName = "psdnsresolverpolicyforrulename5cd8dcg";
        $dnsSecurityRuleName = "psdnssecurityrulename5cd8dcg";
        $dnsResolverDomainListName = "psdnsresolverdomainlistforrulename5cd8dcg";
        $resourceGroupName = "powershell-test-rg-debug-update";
        $location = "westus2";
        $resolverPolicy = New-AzDnsResolverPolicy -Name $dnsResolverPolicyName -ResourceGroupName $resourceGroupName -Location $location
        $domainList = New-AzDnsResolverDomainList -Name $dnsResolverDomainListName -ResourceGroupName $resourceGroupName -Location $location -Domain @("contoso.com.", "example.com.")
        $securityRule = New-AzDnsResolverPolicyDnsSecurityRule -Name $dnsSecurityRuleName -DnsResolverPolicyName $dnsResolverPolicyName -ResourceGroupName $resourceGroupName -Location $location -DnsResolverDomainList @{id = $domainList.Id;} -DnsSecurityRuleState "Enabled" -ActionType "Block" -Priority 100

        # ACT
        $securityRule = Update-AzDnsResolverPolicyDnsSecurityRule -Name $dnsSecurityRuleName -DnsResolverPolicyName $dnsResolverPolicyName -ResourceGroupName $resourceGroupName -Priority 101

        # ASSERT
        $updatedSecurityRule = Get-AzDnsResolverPolicyDnsSecurityRule -DnsResolverPolicyName $dnsResolverPolicyName -DnsSecurityRuleName $dnsSecurityRuleName -ResourceGroupName $resourceGroupName
        $securityRule.Priority | Should -Be 101
    }

    It 'Updates a DNS Security Rule with DisableCnameChainValidation' {
        # ARRANGE
        $dnsResolverPolicyName = "psdnsresolverpolicyforrulenamedcv2";
        $dnsSecurityRuleName = "psdnssecurityrulenamedcv2";
        $dnsResolverDomainListName = "psdnsresolverdomainlistforrulenamedcv2";
        $resourceGroupName = "powershell-test-rg-debug-update";
        $location = "westus2";
        $resolverPolicy = New-AzDnsResolverPolicy -Name $dnsResolverPolicyName -ResourceGroupName $resourceGroupName -Location $location
        $domainList = New-AzDnsResolverDomainList -Name $dnsResolverDomainListName -ResourceGroupName $resourceGroupName -Location $location -Domain @("contoso.com.", "example.com.")
        $securityRule = New-AzDnsResolverPolicyDnsSecurityRule -Name $dnsSecurityRuleName -DnsResolverPolicyName $dnsResolverPolicyName -ResourceGroupName $resourceGroupName -Location $location -DnsResolverDomainList @{id = $domainList.Id;} -DnsSecurityRuleState "Enabled" -ActionType "Block" -Priority 100

        # ACT
        $securityRule = Update-AzDnsResolverPolicyDnsSecurityRule -Name $dnsSecurityRuleName -DnsResolverPolicyName $dnsResolverPolicyName -ResourceGroupName $resourceGroupName -DisableCnameChainValidation

        # ASSERT
        $securityRule.DisableCnameChainValidation | Should -Be $true
    }
}
