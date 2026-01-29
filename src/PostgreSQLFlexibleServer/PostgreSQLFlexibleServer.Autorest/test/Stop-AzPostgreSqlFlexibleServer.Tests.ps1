if(($null -eq $TestName) -or ($TestName -contains 'Stop-AzPostgreSqlFlexibleServer'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Stop-AzPostgreSqlFlexibleServer.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Stop-AzPostgreSqlFlexibleServer' {
    BeforeAll {
        # Ensure server is started before tests
        $server = Get-AzPostgreSqlFlexibleServer -ResourceGroupName $env.resourceGroup -Name $env.flexibleServerName
        if ($server.State -ne 'Ready') {
            Start-AzPostgreSqlFlexibleServer -ResourceGroupName $env.resourceGroup -Name $env.flexibleServerName
            do {
                Start-Sleep -Seconds 30
                $server = Get-AzPostgreSqlFlexibleServer -ResourceGroupName $env.resourceGroup -Name $env.flexibleServerName
            } while ($server.State -ne 'Ready')
        }
    }

    AfterAll {
        # Ensure server is started after tests
        Start-AzPostgreSqlFlexibleServer -ResourceGroupName $env.resourceGroup -Name $env.flexibleServerName
    }

    It 'Stop' {
        # Verify server is ready
        $server = Get-AzPostgreSqlFlexibleServer -ResourceGroupName $env.resourceGroup -Name $env.flexibleServerName
        $server.State | Should -Be 'Ready'
        
        # Stop the server
        Stop-AzPostgreSqlFlexibleServer -ResourceGroupName $env.resourceGroup -Name $env.flexibleServerName
        
        # Wait and verify it's stopping/stopped
        do {
            Start-Sleep -Seconds 30
            $server = Get-AzPostgreSqlFlexibleServer -ResourceGroupName $env.resourceGroup -Name $env.flexibleServerName
        } while ($server.State -notin @('Stopping', 'Stopped'))
        
        $server.State | Should -BeIn @('Stopping', 'Stopped')
    }

    It 'StopViaIdentity' {
        # Start the server first if needed
        $server = Get-AzPostgreSqlFlexibleServer -ResourceGroupName $env.resourceGroup -Name $env.flexibleServerName
        if ($server.State -eq 'Stopped') {
            Start-AzPostgreSqlFlexibleServer -ResourceGroupName $env.resourceGroup -Name $env.flexibleServerName
            do {
                Start-Sleep -Seconds 30
                $server = Get-AzPostgreSqlFlexibleServer -ResourceGroupName $env.resourceGroup -Name $env.flexibleServerName
            } while ($server.State -ne 'Ready')
        }
        
        # Stop via identity
        Stop-AzPostgreSqlFlexibleServer -InputObject $server
        
        # Verify it's stopping
        do {
            Start-Sleep -Seconds 30
            $server = Get-AzPostgreSqlFlexibleServer -ResourceGroupName $env.resourceGroup -Name $env.flexibleServerName
        } while ($server.State -notin @('Stopping', 'Stopped'))
        
        $server.State | Should -BeIn @('Stopping', 'Stopped')
    }
