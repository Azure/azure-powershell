if(($null -eq $TestName) -or ($TestName -contains 'Get-AzPostgreSqlFlexibleServerDatabase'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzPostgreSqlFlexibleServerDatabase.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzPostgreSqlFlexibleServerDatabase' {
    It 'List' {
        $databases = Get-AzPostgreSqlFlexibleServerDatabase -ResourceGroupName $env.resourceGroup -ServerName $env.flexibleServerName
        $databases | Should -Not -BeNullOrEmpty
        $databases.Count | Should -BeGreaterOrEqual 1
        $databases[0].Name | Should -Not -BeNullOrEmpty
    }

    It 'Get' {
        $database = Get-AzPostgreSqlFlexibleServerDatabase -ResourceGroupName $env.resourceGroup -ServerName $env.flexibleServerName -Name 'postgres'
        $database | Should -Not -BeNullOrEmpty
        $database.Name | Should -Be 'postgres'
        $database.Charset | Should -Not -BeNullOrEmpty
        $database.Collation | Should -Not -BeNullOrEmpty
    }

    It 'GetViaIdentity' {
        $database = Get-AzPostgreSqlFlexibleServerDatabase -ResourceGroupName $env.resourceGroup -ServerName $env.flexibleServerName -Name 'postgres'
        $databaseViaIdentity = Get-AzPostgreSqlFlexibleServerDatabase -InputObject $database
        $databaseViaIdentity | Should -Not -BeNullOrEmpty
        $databaseViaIdentity.Name | Should -Be $database.Name
    }

    It 'GetViaIdentityFlexibleServer' {
        $server = Get-AzPostgreSqlFlexibleServer -ResourceGroupName $env.resourceGroup -Name $env.flexibleServerName
        $database = Get-AzPostgreSqlFlexibleServerDatabase -FlexibleServerInputObject $server -Name 'postgres'
        $database | Should -Not -BeNullOrEmpty
        $database.Name | Should -Be 'postgres'
    }
}
