if(($null -eq $TestName) -or ($TestName -contains 'Get-AzPostgreSqlFlexibleServerFirewallRule'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzPostgreSqlFlexibleServerFirewallRule.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzPostgreSqlFlexibleServerFirewallRule' {
    BeforeAll {
        $global:firewallRuleName = "test-firewall-$(Get-Random)"
        New-AzPostgreSqlFlexibleServerFirewallRule -ResourceGroupName $env.resourceGroup -ServerName $env.flexibleServerName -Name $global:firewallRuleName -StartIPAddress '192.168.1.1' -EndIPAddress '192.168.1.255'
    }

    AfterAll {
        Remove-AzPostgreSqlFlexibleServerFirewallRule -ResourceGroupName $env.resourceGroup -ServerName $env.flexibleServerName -Name $global:firewallRuleName -Force
    }

    It 'List' {
        $rules = Get-AzPostgreSqlFlexibleServerFirewallRule -ResourceGroupName $env.resourceGroup -ServerName $env.flexibleServerName
        $rules | Should -Not -BeNullOrEmpty
        $rules.Count | Should -BeGreaterOrEqual 1
        $testRule = $rules | Where-Object { $_.Name -eq $global:firewallRuleName }
        $testRule | Should -Not -BeNullOrEmpty
    }

    It 'Get' {
        $rule = Get-AzPostgreSqlFlexibleServerFirewallRule -ResourceGroupName $env.resourceGroup -ServerName $env.flexibleServerName -Name $global:firewallRuleName
        $rule | Should -Not -BeNullOrEmpty
        $rule.Name | Should -Be $global:firewallRuleName
        $rule.StartIPAddress | Should -Be '192.168.1.1'
        $rule.EndIPAddress | Should -Be '192.168.1.255'
    }

    It 'GetViaIdentity' {
        $rule = Get-AzPostgreSqlFlexibleServerFirewallRule -ResourceGroupName $env.resourceGroup -ServerName $env.flexibleServerName -Name $global:firewallRuleName
        $ruleViaIdentity = Get-AzPostgreSqlFlexibleServerFirewallRule -InputObject $rule
        $ruleViaIdentity | Should -Not -BeNullOrEmpty
        $ruleViaIdentity.Name | Should -Be $rule.Name
    }

    It 'GetViaIdentityFlexibleServer' {
        $server = Get-AzPostgreSqlFlexibleServer -ResourceGroupName $env.resourceGroup -Name $env.flexibleServerName
        $rule = Get-AzPostgreSqlFlexibleServerFirewallRule -FlexibleServerInputObject $server -Name $global:firewallRuleName
        $rule | Should -Not -BeNullOrEmpty
        $rule.Name | Should -Be $global:firewallRuleName
    }
}
