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

# Load post-merge test helper for routing to Frontend endpoint
. (Join-Path $PSScriptRoot 'postMergeTestHelper.ps1')
if ($TestMode -ne 'playback') {
    $postMergeStep = New-PostMergeTestHttpPipelineStep
    $existingMock = $PSDefaultParameterValues["*:HttpPipelinePrepend"]
    # Order matters: steps are chained last→first, so [PostMerge, Mock] yields Mock→PostMerge→terminal
    $PSDefaultParameterValues["*:HttpPipelinePrepend"] = [Microsoft.Azure.PowerShell.Cmdlets.DnsResolver.Runtime.SendAsyncStep[]]@(
        [Microsoft.Azure.PowerShell.Cmdlets.DnsResolver.Runtime.SendAsyncStep]$postMergeStep,
        [Microsoft.Azure.PowerShell.Cmdlets.DnsResolver.Runtime.SendAsyncStep]$existingMock
    )
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
        $securityRule = New-AzDnsResolverPolicyDnsSecurityRule -Name $dnsSecurityRuleName -DnsResolverPolicyName $dnsResolverPolicyName -ResourceGroupName $resourceGroupName -Location $location -DnsResolverDomainList @{id = $domainList.Id;} -DnsSecurityRuleState "Enabled" -ActionType "Block" -Priority 100

        # ASSERT
        {Get-AzDnsResolverPolicyDnsSecurityRule -DnsResolverPolicyName $dnsResolverPolicyName -DnsSecurityRuleName $dnsSecurityRuleName -ResourceGroupName $resourceGroupName } | Should -Not -Throw
    }

    It 'Create DNS security rule with DisableCnameChainValidation' {
        # ARRANGE
        $dnsResolverPolicyName = "psdnsresolverpolicyforrulenamedcv1";
        $dnsSecurityRuleName = "psdnssecurityrulenamedcv1";
        $dnsResolverDomainListName = "psdnsresolverdomainlistforrulenamedcv1";
        $resourceGroupName = "powershell-test-rg-debug-new";
        $location = "westus2";
        $resolverPolicy = New-AzDnsResolverPolicy -Name $dnsResolverPolicyName -ResourceGroupName $resourceGroupName -Location $location
        $domainList = New-AzDnsResolverDomainList -Name $dnsResolverDomainListName -ResourceGroupName $resourceGroupName -Location $location -Domain @("contoso.com.", "example.com.")

        # ACT
        $securityRule = New-AzDnsResolverPolicyDnsSecurityRule -Name $dnsSecurityRuleName -DnsResolverPolicyName $dnsResolverPolicyName -ResourceGroupName $resourceGroupName -Location $location -DnsResolverDomainList @{id = $domainList.Id;} -DnsSecurityRuleState "Enabled" -ActionType "Block" -Priority 100 -DisableCnameChainValidation

        # ASSERT
        $securityRule.DisableCnameChainValidation | Should -Be $true
        $retrievedRule = Get-AzDnsResolverPolicyDnsSecurityRule -Name $dnsSecurityRuleName -DnsResolverPolicyName $dnsResolverPolicyName -ResourceGroupName $resourceGroupName
        $retrievedRule.DisableCnameChainValidation | Should -Be $true
    }
}
