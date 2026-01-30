if(($null -eq $TestName) -or ($TestName -contains 'Update-AzPostgreSqlFlexibleServerConfiguration'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzPostgreSqlFlexibleServerConfiguration.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzPostgreSqlFlexibleServerConfiguration' {
    BeforeAll {
        # Get initial configuration values for cleanup
        $global:originalMaxConnections = (Get-AzPostgreSqlFlexibleServerConfiguration -ResourceGroupName $env.resourceGroup -ServerName $env.flexibleServerName -Name 'max_connections').Value
        $global:originalLogStatement = (Get-AzPostgreSqlFlexibleServerConfiguration -ResourceGroupName $env.resourceGroup -ServerName $env.flexibleServerName -Name 'log_statement').Value
    }

    AfterAll {
        # Reset configurations to original values
        Update-AzPostgreSqlFlexibleServerConfiguration -ResourceGroupName $env.resourceGroup -ServerName $env.flexibleServerName -Name 'max_connections' -Value $global:originalMaxConnections
        Update-AzPostgreSqlFlexibleServerConfiguration -ResourceGroupName $env.resourceGroup -ServerName $env.flexibleServerName -Name 'log_statement' -Value $global:originalLogStatement
    }

    It 'UpdateExpanded' {
        $newValue = [int]$global:originalMaxConnections + 10
        $config = Update-AzPostgreSqlFlexibleServerConfiguration -ResourceGroupName $env.resourceGroup -ServerName $env.flexibleServerName -Name 'max_connections' -Value $newValue.ToString()
        $config | Should -Not -BeNullOrEmpty
        $config.Name | Should -Be 'max_connections'
        $config.Value | Should -Be $newValue.ToString()
        $config.Source | Should -Be 'user-override'
    }

    It 'UpdateViaJsonString' {
        $json = @"
{
  "properties": {
    "value": "ddl"
  }
}
"@
        $config = Update-AzPostgreSqlFlexibleServerConfiguration -ResourceGroupName $env.resourceGroup -ServerName $env.flexibleServerName -Name 'log_statement' -JsonString $json
        $config | Should -Not -BeNullOrEmpty
        $config.Name | Should -Be 'log_statement'
        $config.Value | Should -Be 'ddl'
    }

    It 'UpdateViaJsonFilePath' -Skip {
        # Skip this test as it requires file operations
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'UpdateViaIdentityFlexibleServerExpanded' {
        $server = Get-AzPostgreSqlFlexibleServer -ResourceGroupName $env.resourceGroup -Name $env.flexibleServerName
        $config = Update-AzPostgreSqlFlexibleServerConfiguration -FlexibleServerInputObject $server -Name 'log_min_duration_statement' -Value '1000'
        $config | Should -Not -BeNullOrEmpty
        $config.Name | Should -Be 'log_min_duration_statement'
        $config.Value | Should -Be '1000'
        
        # Reset to default
        Update-AzPostgreSqlFlexibleServerConfiguration -FlexibleServerInputObject $server -Name 'log_min_duration_statement' -Value '-1'
    }

    It 'UpdateViaIdentityExpanded' {
        $configObj = Get-AzPostgreSqlFlexibleServerConfiguration -ResourceGroupName $env.resourceGroup -ServerName $env.flexibleServerName -Name 'log_statement'
        $config = Update-AzPostgreSqlFlexibleServerConfiguration -InputObject $configObj -Value 'all'
        $config | Should -Not -BeNullOrEmpty
        $config.Name | Should -Be 'log_statement'
        $config.Value | Should -Be 'all'
        $config.Source | Should -Be 'user-override'
    }
}
