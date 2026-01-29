if(($null -eq $TestName) -or ($TestName -contains 'Get-AzPostgreSqlFlexibleServerConfiguration'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzPostgreSqlFlexibleServerConfiguration.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzPostgreSqlFlexibleServerConfiguration' {
    It 'List' {
        $configurations = Get-AzPostgreSqlFlexibleServerConfiguration -ResourceGroupName $env.resourceGroup -ServerName $env.flexibleServerName
        $configurations | Should -Not -BeNullOrEmpty
        $configurations.Count | Should -BeGreaterThan 50
        $maxConnections = $configurations | Where-Object { $_.Name -eq 'max_connections' }
        $maxConnections | Should -Not -BeNullOrEmpty
        $maxConnections.Value | Should -Not -BeNullOrEmpty
    }

    It 'Get' {
        $config = Get-AzPostgreSqlFlexibleServerConfiguration -ResourceGroupName $env.resourceGroup -ServerName $env.flexibleServerName -Name 'max_connections'
        $config | Should -Not -BeNullOrEmpty
        $config.Name | Should -Be 'max_connections'
        $config.Value | Should -Not -BeNullOrEmpty
        $config.DefaultValue | Should -Not -BeNullOrEmpty
        $config.DataType | Should -Be 'Integer'
        $config.AllowedValues | Should -Not -BeNullOrEmpty
    }

    It 'GetViaIdentity' {
        $config = Get-AzPostgreSqlFlexibleServerConfiguration -ResourceGroupName $env.resourceGroup -ServerName $env.flexibleServerName -Name 'shared_buffers'
        $configViaIdentity = Get-AzPostgreSqlFlexibleServerConfiguration -InputObject $config
        $configViaIdentity | Should -Not -BeNullOrEmpty
        $configViaIdentity.Name | Should -Be $config.Name
        $configViaIdentity.Value | Should -Be $config.Value
    }

    It 'GetViaIdentityFlexibleServer' {
        $server = Get-AzPostgreSqlFlexibleServer -ResourceGroupName $env.resourceGroup -Name $env.flexibleServerName
        $config = Get-AzPostgreSqlFlexibleServerConfiguration -FlexibleServerInputObject $server -Name 'log_statement'
        $config | Should -Not -BeNullOrEmpty
        $config.Name | Should -Be 'log_statement'
        $config.DataType | Should -Be 'Enumeration'
    }

    It 'GetSpecificConfigurations' {
        $commonConfigs = @('shared_preload_libraries', 'log_min_duration_statement', 'checkpoint_completion_target')
        foreach ($configName in $commonConfigs) {
            $config = Get-AzPostgreSqlFlexibleServerConfiguration -ResourceGroupName $env.resourceGroup -ServerName $env.flexibleServerName -Name $configName
            $config | Should -Not -BeNullOrEmpty
            $config.Name | Should -Be $configName
        }
    }
}
