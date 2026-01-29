if(($null -eq $TestName) -or ($TestName -contains 'Start-AzPostgreSqlFlexibleServer'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Start-AzPostgreSqlFlexibleServer.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Start-AzPostgreSqlFlexibleServer' {
    BeforeAll {
        # Stop the server first to test starting
        Stop-AzPostgreSqlFlexibleServer -ResourceGroupName $env.resourceGroup -Name $env.flexibleServerName
        # Wait for stop operation to complete
        do {
            Start-Sleep -Seconds 30
            $server = Get-AzPostgreSqlFlexibleServer -ResourceGroupName $env.resourceGroup -Name $env.flexibleServerName
        } while ($server.State -ne 'Stopped')
    }

    AfterAll {
        # Ensure server is started after tests
        $server = Get-AzPostgreSqlFlexibleServer -ResourceGroupName $env.resourceGroup -Name $env.flexibleServerName
        if ($server.State -ne 'Ready') {
            Start-AzPostgreSqlFlexibleServer -ResourceGroupName $env.resourceGroup -Name $env.flexibleServerName
        }
    }

    It 'Start' {
        # Verify server is stopped
        $server = Get-AzPostgreSqlFlexibleServer -ResourceGroupName $env.resourceGroup -Name $env.flexibleServerName
        $server.State | Should -Be 'Stopped'
        
        # Start the server
        Start-AzPostgreSqlFlexibleServer -ResourceGroupName $env.resourceGroup -Name $env.flexibleServerName
        
        # Wait and verify it's starting/started
        do {
            Start-Sleep -Seconds 30
            $server = Get-AzPostgreSqlFlexibleServer -ResourceGroupName $env.resourceGroup -Name $env.flexibleServerName
        } while ($server.State -notin @('Starting', 'Ready'))
        
        $server.State | Should -BeIn @('Starting', 'Ready')
    }

    It 'StartViaIdentity' {
        # Stop the server first
        Stop-AzPostgreSqlFlexibleServer -ResourceGroupName $env.resourceGroup -Name $env.flexibleServerName
        
        # Wait for stop operation to complete
        do {
            Start-Sleep -Seconds 30
            $server = Get-AzPostgreSqlFlexibleServer -ResourceGroupName $env.resourceGroup -Name $env.flexibleServerName
        } while ($server.State -ne 'Stopped')
        
        # Start via identity
        Start-AzPostgreSqlFlexibleServer -InputObject $server
        
        # Verify it's starting
        do {
            Start-Sleep -Seconds 30
            $server = Get-AzPostgreSqlFlexibleServer -ResourceGroupName $env.resourceGroup -Name $env.flexibleServerName
        } while ($server.State -notin @('Starting', 'Ready'))
        
        $server.State | Should -BeIn @('Starting', 'Ready')
    }
