if(($null -eq $TestName) -or ($TestName -contains 'New-AzHorizonDbFirewallRule'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzHorizonDbFirewallRule.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzHorizonDbFirewallRule' {
    It 'CreateExpanded' {
        $firewallRuleName = 'example-firewall-rule-01'
        $firewallRule = New-AzHorizonDbFirewallRule -ResourceGroupName $env.clusterResourceGroup -ClusterName $env.newClusterName -PoolName $env.newPoolName -Name $firewallRuleName -SubscriptionId $env.SubscriptionId -StartIPAddress '10.0.0.1' -EndIPAddress '10.0.0.254' -Description 'Allow access from the corporate network' -ErrorAction Stop

        $firewallRule.Name | Should -Be $firewallRuleName
        $firewallRule.ResourceGroupName | Should -Be $env.clusterResourceGroup
        $firewallRule.Id | Should -Be "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.clusterResourceGroup)/providers/Microsoft.HorizonDb/clusters/$($env.newClusterName)/pools/$($env.newPoolName)/firewallRules/$firewallRuleName"
        $firewallRule.Type | Should -Be 'Microsoft.HorizonDb/clusters/pools/firewallRules'
        $firewallRule.StartIPAddress | Should -Be '10.0.0.1'
        $firewallRule.EndIPAddress | Should -Be '10.0.0.254'
        $firewallRule.ProvisioningState | Should -Be 'Succeeded'
    }

    It 'Delete' {
        $firewallRuleName = 'example-firewall-rule-delete-01'
        $firewallRule = New-AzHorizonDbFirewallRule -ResourceGroupName $env.clusterResourceGroup -ClusterName $env.newClusterName -PoolName $env.newPoolName -Name $firewallRuleName -SubscriptionId $env.SubscriptionId -StartIPAddress '10.0.0.1' -EndIPAddress '10.0.0.254' -Description 'Allow access from the corporate network' -ErrorAction Stop
        $firewallRule.Name | Should -Be $firewallRuleName
        $firewallRule.ProvisioningState | Should -Be 'Succeeded'

        $removed = Remove-AzHorizonDbFirewallRule -ResourceGroupName $env.clusterResourceGroup -ClusterName $env.newClusterName -PoolName $env.newPoolName -Name $firewallRuleName -SubscriptionId $env.SubscriptionId -PassThru -Confirm:$false -ErrorAction Stop
        $removed | Should -Be $true

        $rules = @(Get-AzHorizonDbFirewallRule -ResourceGroupName $env.clusterResourceGroup -ClusterName $env.newClusterName -PoolName $env.newPoolName -SubscriptionId $env.SubscriptionId -ErrorAction Stop)
        @($rules | Where-Object { $_.Name -eq $firewallRuleName }).Count | Should -Be 0
    }

    It 'CreateViaJsonString' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'CreateViaJsonFilePath' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'CreateViaIdentityClusterExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'CreateViaIdentityPoolExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
