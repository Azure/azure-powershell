if(($null -eq $TestName) -or ($TestName -contains 'Remove-AzPostgreSqlFlexibleServerFirewallRule'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzPostgreSqlFlexibleServerFirewallRule.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Remove-AzPostgreSqlFlexibleServerFirewallRule' {
    It 'Delete' {
        # Create a test firewall rule first
        $ruleName = "test-rule-$(Get-Random)"
        New-AzPostgreSqlFlexibleServerFirewallRule -ResourceGroupName $env.resourceGroup -ServerName $env.flexibleServerName -Name $ruleName -StartIPAddress '192.168.1.1' -EndIPAddress '192.168.1.255'
        
        # Verify it exists
        $rule = Get-AzPostgreSqlFlexibleServerFirewallRule -ResourceGroupName $env.resourceGroup -ServerName $env.flexibleServerName -Name $ruleName
        $rule | Should -Not -BeNullOrEmpty
        
        # Remove it
        Remove-AzPostgreSqlFlexibleServerFirewallRule -ResourceGroupName $env.resourceGroup -ServerName $env.flexibleServerName -Name $ruleName -Force
        
        # Verify it's gone
        { Get-AzPostgreSqlFlexibleServerFirewallRule -ResourceGroupName $env.resourceGroup -ServerName $env.flexibleServerName -Name $ruleName } | Should -Throw
    }

    It 'DeleteViaIdentity' {
        # Create a test firewall rule first
        $ruleName = "test-rule-$(Get-Random)"
        $rule = New-AzPostgreSqlFlexibleServerFirewallRule -ResourceGroupName $env.resourceGroup -ServerName $env.flexibleServerName -Name $ruleName -StartIPAddress '10.0.1.1' -EndIPAddress '10.0.1.255'
        
        # Remove via identity
        Remove-AzPostgreSqlFlexibleServerFirewallRule -InputObject $rule -Force
        
        # Verify it's gone
        { Get-AzPostgreSqlFlexibleServerFirewallRule -ResourceGroupName $env.resourceGroup -ServerName $env.flexibleServerName -Name $ruleName } | Should -Throw
    }

    It 'DeleteViaIdentityFlexibleServer' {
        # Create a test firewall rule first
        $ruleName = "test-rule-$(Get-Random)"
        New-AzPostgreSqlFlexibleServerFirewallRule -ResourceGroupName $env.resourceGroup -ServerName $env.flexibleServerName -Name $ruleName -StartIPAddress '172.16.1.1' -EndIPAddress '172.16.1.255'
        
        # Get server object
        $server = Get-AzPostgreSqlFlexibleServer -ResourceGroupName $env.resourceGroup -Name $env.flexibleServerName
        
        # Remove via server identity
        Remove-AzPostgreSqlFlexibleServerFirewallRule -FlexibleServerInputObject $server -Name $ruleName -Force
        
        # Verify it's gone
        { Get-AzPostgreSqlFlexibleServerFirewallRule -ResourceGroupName $env.resourceGroup -ServerName $env.flexibleServerName -Name $ruleName } | Should -Throw
    }
}
