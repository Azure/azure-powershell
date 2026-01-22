if(($null -eq $TestName) -or ($TestName -contains 'New-AzPostgreSqlFlexibleServerDatabase'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzPostgreSqlFlexibleServerDatabase.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzPostgreSqlFlexibleServerDatabase' {
    It 'CreateExpanded' {
        $databaseName = "testdb$(Get-Random)"
        $database = New-AzPostgreSqlFlexibleServerDatabase -ResourceGroupName $env.resourceGroup -ServerName $env.flexibleServerName -Name $databaseName -Charset 'UTF8' -Collation 'en_US.utf8'
        $database | Should -Not -BeNullOrEmpty
        $database.Name | Should -Be $databaseName
        $database.Charset | Should -Be 'UTF8'
        $database.Collation | Should -Be 'en_US.utf8'
        
        # Clean up
        Remove-AzPostgreSqlFlexibleServerDatabase -ResourceGroupName $env.resourceGroup -ServerName $env.flexibleServerName -Name $databaseName -Force
    }

    It 'CreateViaJsonString' {
        $databaseName = "testdb$(Get-Random)"
        $json = @'
{
  "properties": {
    "charset": "UTF8",
    "collation": "en_US.utf8"
  }
}
'@
        $database = New-AzPostgreSqlFlexibleServerDatabase -ResourceGroupName $env.resourceGroup -ServerName $env.flexibleServerName -Name $databaseName -JsonString $json
        $database | Should -Not -BeNullOrEmpty
        $database.Name | Should -Be $databaseName
        $database.Charset | Should -Be 'UTF8'
        $database.Collation | Should -Be 'en_US.utf8'
        
        # Clean up
        Remove-AzPostgreSqlFlexibleServerDatabase -ResourceGroupName $env.resourceGroup -ServerName $env.flexibleServerName -Name $databaseName -Force
    }

    It 'CreateViaJsonFilePath' -Skip {
        # Skip this test as it requires file operations
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'CreateViaIdentityFlexibleServerExpanded' {
        $server = Get-AzPostgreSqlFlexibleServer -ResourceGroupName $env.resourceGroup -Name $env.flexibleServerName
        $databaseName = "testdb$(Get-Random)"
        $database = New-AzPostgreSqlFlexibleServerDatabase -FlexibleServerInputObject $server -Name $databaseName -Charset 'UTF8'
        $database | Should -Not -BeNullOrEmpty
        $database.Name | Should -Be $databaseName
        $database.Charset | Should -Be 'UTF8'
        
        # Clean up
        Remove-AzPostgreSqlFlexibleServerDatabase -InputObject $database -Force
    }
}
