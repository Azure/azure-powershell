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
        $serverTargets = @()
        for ($i = 1; $i -le 6; $i++) {
            $resourceGroupName = $env["ResourceGroupName$i"]
            $serverName = $env["ServerName$i"]
            if ($resourceGroupName -and $serverName) {
                $serverTargets += [ordered]@{
                    Index = $i
                    ResourceGroupName = $resourceGroupName
                    ServerName = $serverName
                }
            }
        }

        $hasAllServers = $serverTargets.Count -eq 6

        function Wait-ServerState {
            param(
                [Parameter(Mandatory = $true)]
                [string]$ResourceGroupName,

                [Parameter(Mandatory = $true)]
                [string]$ServerName,

                [Parameter(Mandatory = $true)]
                [ValidateSet('Ready', 'Stopped')]
                [string]$ExpectedState,

                [int]$TimeoutSeconds = 1800,
                [int]$PollSeconds = 15
            )

            $timeoutAt = (Get-Date).AddSeconds($TimeoutSeconds)
            while ((Get-Date) -lt $timeoutAt) {
                $server = Get-AzPostgreSqlFlexibleServer -ResourceGroupName $ResourceGroupName -Name $ServerName
                if ($server.State -eq $ExpectedState) {
                    return $server
                }

                Start-TestSleep -Seconds $PollSeconds
            }

            throw "Timed out waiting for server '$ServerName' in resource group '$ResourceGroupName' to reach $ExpectedState state."
        }
    }

    It 'RestartAllServersThenRestartFailsWhenStoppedThenStartAllAgain' -Skip:(-not $hasAllServers) {
        foreach ($target in $serverTargets) {
            Restart-AzPostgreSqlFlexibleServer -ResourceGroupName $target.ResourceGroupName -Name $target.ServerName | Out-Null

            $readyServer = Wait-ServerState -ResourceGroupName $target.ResourceGroupName -ServerName $target.ServerName -ExpectedState 'Ready'
            $readyServer.State | Should -Be 'Ready'
        }

        foreach ($target in $serverTargets) {
            Stop-AzPostgreSqlFlexibleServer -ResourceGroupName $target.ResourceGroupName -Name $target.ServerName | Out-Null

            $stoppedServer = Wait-ServerState -ResourceGroupName $target.ResourceGroupName -ServerName $target.ServerName -ExpectedState 'Stopped'
            $stoppedServer.State | Should -Be 'Stopped'
        }

        try {
            foreach ($target in $serverTargets) {
                {
                    Restart-AzPostgreSqlFlexibleServer `
                        -ResourceGroupName $target.ResourceGroupName `
                        -Name $target.ServerName `
                        -ErrorAction Stop
                } | Should -Throw
            }
        }
        finally {
            foreach ($target in $serverTargets) {
                $server = Get-AzPostgreSqlFlexibleServer -ResourceGroupName $target.ResourceGroupName -Name $target.ServerName
                if ($server.State -ne 'Ready') {
                    Start-AzPostgreSqlFlexibleServer -ResourceGroupName $target.ResourceGroupName -Name $target.ServerName | Out-Null
                }

                $readyServer = Wait-ServerState -ResourceGroupName $target.ResourceGroupName -ServerName $target.ServerName -ExpectedState 'Ready'
                $readyServer.State | Should -Be 'Ready'
            }
        }
    }
}
