if(($null -eq $TestName) -or ($TestName -contains 'Restart-AzPostgreSqlFlexibleServer'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Restart-AzPostgreSqlFlexibleServer.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Restart-AzPostgreSqlFlexibleServer' {
    BeforeAll {
        # Ensure server is ready before tests
        $server = Get-AzPostgreSqlFlexibleServer -ResourceGroupName $env.resourceGroup -Name $env.flexibleServerName
        if ($server.State -ne 'Ready') {
            Start-AzPostgreSqlFlexibleServer -ResourceGroupName $env.resourceGroup -Name $env.flexibleServerName
            do {
                Start-Sleep -Seconds 30
                $server = Get-AzPostgreSqlFlexibleServer -ResourceGroupName $env.resourceGroup -Name $env.flexibleServerName
            } while ($server.State -ne 'Ready')
        }
    }

    It 'RestartExpanded' {
        # Test restart with expanded parameters
        $server = Get-AzPostgreSqlFlexibleServer -ResourceGroupName $env.resourceGroup -Name $env.flexibleServerName
        $server.State | Should -Be 'Ready'
        
        Restart-AzPostgreSqlFlexibleServer -ResourceGroupName $env.resourceGroup -Name $env.flexibleServerName -RestartWithFailover $false
        
        # Wait for restart to complete
        do {
            Start-Sleep -Seconds 30
            $server = Get-AzPostgreSqlFlexibleServer -ResourceGroupName $env.resourceGroup -Name $env.flexibleServerName
        } while ($server.State -ne 'Ready')
        
        $server.State | Should -Be 'Ready'
    }

    It 'RestartViaJsonString' {
        $json = @"
{
  "restartWithFailover": false
}
"@
        $server = Get-AzPostgreSqlFlexibleServer -ResourceGroupName $env.resourceGroup -Name $env.flexibleServerName
        Restart-AzPostgreSqlFlexibleServer -ResourceGroupName $env.resourceGroup -Name $env.flexibleServerName -JsonString $json
        
        # Wait for restart to complete
        do {
            Start-Sleep -Seconds 30
            $server = Get-AzPostgreSqlFlexibleServer -ResourceGroupName $env.resourceGroup -Name $env.flexibleServerName
        } while ($server.State -ne 'Ready')
        
        $server.State | Should -Be 'Ready'
    }

    It 'RestartViaJsonFilePath' -Skip {
        # Skip this test as it requires file operations
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'Restart' {
        $server = Get-AzPostgreSqlFlexibleServer -ResourceGroupName $env.resourceGroup -Name $env.flexibleServerName
        $server.State | Should -Be 'Ready'
        
        Restart-AzPostgreSqlFlexibleServer -ResourceGroupName $env.resourceGroup -Name $env.flexibleServerName
        
        # Wait for restart to complete
        do {
            Start-Sleep -Seconds 30
            $server = Get-AzPostgreSqlFlexibleServer -ResourceGroupName $env.resourceGroup -Name $env.flexibleServerName
        } while ($server.State -ne 'Ready')
        
        $server.State | Should -Be 'Ready'
    }

    It 'RestartViaIdentityExpanded' {
        $server = Get-AzPostgreSqlFlexibleServer -ResourceGroupName $env.resourceGroup -Name $env.flexibleServerName
        Restart-AzPostgreSqlFlexibleServer -InputObject $server -RestartWithFailover $false
        
        # Wait for restart to complete
        do {
            Start-Sleep -Seconds 30
            $server = Get-AzPostgreSqlFlexibleServer -ResourceGroupName $env.resourceGroup -Name $env.flexibleServerName
        } while ($server.State -ne 'Ready')
        
        $server.State | Should -Be 'Ready'
    }

    It 'RestartViaIdentity' {
        $server = Get-AzPostgreSqlFlexibleServer -ResourceGroupName $env.resourceGroup -Name $env.flexibleServerName
        Restart-AzPostgreSqlFlexibleServer -InputObject $server
        
        # Wait for restart to complete
        do {
            Start-Sleep -Seconds 30
            $server = Get-AzPostgreSqlFlexibleServer -ResourceGroupName $env.resourceGroup -Name $env.flexibleServerName
        } while ($server.State -ne 'Ready')
        
        $server.State | Should -Be 'Ready'
    }
}
