if(($null -eq $TestName) -or ($TestName -contains 'Get-AzPostgreSqlFlexibleServer'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzPostgreSqlFlexibleServer.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzPostgreSqlFlexibleServer' {
    It 'List' {
        $servers = Get-AzPostgreSqlFlexibleServer -ResourceGroupName $env.resourceGroup
        $servers | Should -Not -BeNullOrEmpty
        $testServer = $servers | Where-Object { $_.Name -eq $env.flexibleServerName }
        $testServer | Should -Not -BeNullOrEmpty
        $testServer.Name | Should -Be $env.flexibleServerName
        $testServer.State | Should -Be 'Ready'
    }

    It 'Get' {
        $server = Get-AzPostgreSqlFlexibleServer -ResourceGroupName $env.resourceGroup -Name $env.flexibleServerName
        $server | Should -Not -BeNullOrEmpty
        $server.Name | Should -Be $env.flexibleServerName
        $server.State | Should -Be 'Ready'
        $server.PostgreSqlVersion | Should -Not -BeNullOrEmpty
        $server.SkuName | Should -Not -BeNullOrEmpty
        $server.SkuTier | Should -Not -BeNullOrEmpty
        $server.Location | Should -Not -BeNullOrEmpty
        $server.AdministratorLogin | Should -Not -BeNullOrEmpty
    }

    It 'List1' {
        $servers = Get-AzPostgreSqlFlexibleServer
        $servers | Should -Not -BeNullOrEmpty
        $testServer = $servers | Where-Object { $_.Name -eq $env.flexibleServerName }
        $testServer | Should -Not -BeNullOrEmpty
    }

    It 'GetViaIdentity' {
        $server = Get-AzPostgreSqlFlexibleServer -ResourceGroupName $env.resourceGroup -Name $env.flexibleServerName
        $serverViaIdentity = Get-AzPostgreSqlFlexibleServer -InputObject $server
        $serverViaIdentity | Should -Not -BeNullOrEmpty
        $serverViaIdentity.Name | Should -Be $server.Name
        $serverViaIdentity.ResourceGroupName | Should -Be $server.ResourceGroupName
    }
}
