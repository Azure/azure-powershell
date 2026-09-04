if(($null -eq $TestName) -or ($TestName -contains 'New-AzDocumentDbFirewallRule'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzDocumentDbFirewallRule.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzDocumentDBFirewallRule' {
    BeforeAll {
        $rg = $env.firewallRg
        $cluster = $env.firewallCluster
        $rule = $env.firewallRule
        $loc = $env.location
        if ($TestMode -ne 'playback') { New-AzResourceGroup -Name $rg -Location $loc | Out-Null }
        New-DocumentDBTestCluster -ResourceGroupName $rg -Name $cluster -Location $loc | Out-Null
    }
    AfterAll {
        if ($TestMode -ne 'playback') { Remove-AzResourceGroup -Name $rg -ErrorAction SilentlyContinue | Out-Null }
    }

    It 'FirewallRule lifecycle' {
        # Add a firewall rule. 0.0.0.0-0.0.0.0 is the convention that allows all Azure services.
        $created = New-AzDocumentDBFirewallRule -Name $rule -MongoClusterName $cluster -ResourceGroupName $rg `
            -StartIPAddress '0.0.0.0' -EndIPAddress '0.0.0.0'
        $created.Name | Should -Be $rule
        $created.StartIPAddress | Should -Be '0.0.0.0'
        $created.EndIPAddress | Should -Be '0.0.0.0'
        $created.ProvisioningState | Should -Be 'Succeeded'

        # Read the rule back.
        $show = Get-AzDocumentDBFirewallRule -Name $rule -MongoClusterName $cluster -ResourceGroupName $rg
        $show.Name | Should -Be $rule
        $show.ProvisioningState | Should -Be 'Succeeded'

        # Update the rule to allow the whole IPv4 range.
        $updated = Update-AzDocumentDBFirewallRule -Name $rule -MongoClusterName $cluster -ResourceGroupName $rg `
            -StartIPAddress '0.0.0.0' -EndIPAddress '255.255.255.255'
        $updated.StartIPAddress | Should -Be '0.0.0.0'
        $updated.EndIPAddress | Should -Be '255.255.255.255'

        # The rule shows up in the cluster's firewall-rule listing.
        @(Get-AzDocumentDBFirewallRule -MongoClusterName $cluster -ResourceGroupName $rg | Where-Object { $_.Name -eq $rule }).Count | Should -Be 1

        # Delete the rule.
        { Remove-AzDocumentDBFirewallRule -Name $rule -MongoClusterName $cluster -ResourceGroupName $rg } | Should -Not -Throw
    }
}
