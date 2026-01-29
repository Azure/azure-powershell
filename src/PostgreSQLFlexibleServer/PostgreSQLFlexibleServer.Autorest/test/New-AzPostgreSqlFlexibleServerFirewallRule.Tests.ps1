if(($null -eq $TestName) -or ($TestName -contains 'New-AzPostgreSqlFlexibleServerFirewallRule'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzPostgreSqlFlexibleServerFirewallRule.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzPostgreSqlFlexibleServerFirewallRule' {
    It 'CreateExpanded' {
        $ruleName = "test-rule-$(Get-Random)"
        $rule = New-AzPostgreSqlFlexibleServerFirewallRule -ResourceGroupName $env.resourceGroup -ServerName $env.flexibleServerName -Name $ruleName -StartIPAddress '10.0.0.1' -EndIPAddress '10.0.0.255'
        $rule | Should -Not -BeNullOrEmpty
        $rule.Name | Should -Be $ruleName
        $rule.StartIPAddress | Should -Be '10.0.0.1'
        $rule.EndIPAddress | Should -Be '10.0.0.255'
        
        # Clean up
        Remove-AzPostgreSqlFlexibleServerFirewallRule -ResourceGroupName $env.resourceGroup -ServerName $env.flexibleServerName -Name $ruleName -Force
    }

    It 'CreateViaJsonString' {
        $ruleName = "test-rule-$(Get-Random)"
        $json = @"
{
  "properties": {
    "startIpAddress": "203.0.113.1",
    "endIpAddress": "203.0.113.255"
  }
}
"@
        $rule = New-AzPostgreSqlFlexibleServerFirewallRule -ResourceGroupName $env.resourceGroup -ServerName $env.flexibleServerName -Name $ruleName -JsonString $json
        $rule | Should -Not -BeNullOrEmpty
        $rule.Name | Should -Be $ruleName
        $rule.StartIPAddress | Should -Be '203.0.113.1'
        $rule.EndIPAddress | Should -Be '203.0.113.255'
        
        # Clean up
        Remove-AzPostgreSqlFlexibleServerFirewallRule -ResourceGroupName $env.resourceGroup -ServerName $env.flexibleServerName -Name $ruleName -Force
    }

    It 'CreateViaJsonFilePath' -Skip {
        # Skip this test as it requires file operations
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'CreateViaIdentityFlexibleServerExpanded' {
        $server = Get-AzPostgreSqlFlexibleServer -ResourceGroupName $env.resourceGroup -Name $env.flexibleServerName
        $ruleName = "test-rule-$(Get-Random)"
        $rule = New-AzPostgreSqlFlexibleServerFirewallRule -FlexibleServerInputObject $server -Name $ruleName -StartIPAddress '172.16.0.1' -EndIPAddress '172.16.0.255'
        $rule | Should -Not -BeNullOrEmpty
        $rule.Name | Should -Be $ruleName
        $rule.StartIPAddress | Should -Be '172.16.0.1'
        $rule.EndIPAddress | Should -Be '172.16.0.255'
        
        # Clean up
        Remove-AzPostgreSqlFlexibleServerFirewallRule -InputObject $rule -Force
    }

    It 'CreateAllowAzureServices' {
        $ruleName = "AllowAzureServices-$(Get-Random)"
        $rule = New-AzPostgreSqlFlexibleServerFirewallRule -ResourceGroupName $env.resourceGroup -ServerName $env.flexibleServerName -Name $ruleName -StartIPAddress '0.0.0.0' -EndIPAddress '0.0.0.0'
        $rule | Should -Not -BeNullOrEmpty
        $rule.Name | Should -Be $ruleName
        $rule.StartIPAddress | Should -Be '0.0.0.0'
        $rule.EndIPAddress | Should -Be '0.0.0.0'
        
        # Clean up
        Remove-AzPostgreSqlFlexibleServerFirewallRule -ResourceGroupName $env.resourceGroup -ServerName $env.flexibleServerName -Name $ruleName -Force
    }
}
