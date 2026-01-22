if(($null -eq $TestName) -or ($TestName -contains 'Remove-AzPostgreSqlFlexibleServerDatabase'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzPostgreSqlFlexibleServerDatabase.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Remove-AzPostgreSqlFlexibleServerDatabase' {
    It 'Delete' {
        # Create a test database first
        $databaseName = "testdb$(Get-Random)"
        New-AzPostgreSqlFlexibleServerDatabase -ResourceGroupName $env.resourceGroup -ServerName $env.flexibleServerName -Name $databaseName -Charset 'UTF8'
        
        # Verify it exists
        $database = Get-AzPostgreSqlFlexibleServerDatabase -ResourceGroupName $env.resourceGroup -ServerName $env.flexibleServerName -Name $databaseName
        $database | Should -Not -BeNullOrEmpty
        
        # Remove it
        Remove-AzPostgreSqlFlexibleServerDatabase -ResourceGroupName $env.resourceGroup -ServerName $env.flexibleServerName -Name $databaseName -Force
        
        # Verify it's gone
        { Get-AzPostgreSqlFlexibleServerDatabase -ResourceGroupName $env.resourceGroup -ServerName $env.flexibleServerName -Name $databaseName } | Should -Throw
    }

    It 'DeleteViaIdentity' {
        # Create a test database first
        $databaseName = "testdb$(Get-Random)"
        $database = New-AzPostgreSqlFlexibleServerDatabase -ResourceGroupName $env.resourceGroup -ServerName $env.flexibleServerName -Name $databaseName -Charset 'UTF8'
        
        # Remove via identity
        Remove-AzPostgreSqlFlexibleServerDatabase -InputObject $database -Force
        
        # Verify it's gone
        { Get-AzPostgreSqlFlexibleServerDatabase -ResourceGroupName $env.resourceGroup -ServerName $env.flexibleServerName -Name $databaseName } | Should -Throw
    }

    It 'DeleteViaIdentityFlexibleServer' {
        # Create a test database first
        $databaseName = "testdb$(Get-Random)"
        New-AzPostgreSqlFlexibleServerDatabase -ResourceGroupName $env.resourceGroup -ServerName $env.flexibleServerName -Name $databaseName -Charset 'UTF8'
        
        # Get server object
        $server = Get-AzPostgreSqlFlexibleServer -ResourceGroupName $env.resourceGroup -Name $env.flexibleServerName
        
        # Remove via server identity
        Remove-AzPostgreSqlFlexibleServerDatabase -FlexibleServerInputObject $server -Name $databaseName -Force
        
        # Verify it's gone
        { Get-AzPostgreSqlFlexibleServerDatabase -ResourceGroupName $env.resourceGroup -ServerName $env.flexibleServerName -Name $databaseName } | Should -Throw
    }
}
