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

        function Wait-ServerReady {
            param(
                [Parameter(Mandatory = $true)]
                [string]$ResourceGroupName,

                [Parameter(Mandatory = $true)]
                [string]$ServerName,

                [int]$TimeoutSeconds = 1800,
                [int]$PollSeconds = 15
            )

            $timeoutAt = (Get-Date).AddSeconds($TimeoutSeconds)
            while ((Get-Date) -lt $timeoutAt) {
                $server = Get-AzPostgreSqlFlexibleServer -ResourceGroupName $ResourceGroupName -Name $ServerName
                if ($server.State -eq 'Ready') {
                    return $server
                }

                Start-TestSleep -Seconds $PollSeconds
            }

            throw "Timed out waiting for server '$ServerName' in resource group '$ResourceGroupName' to reach Ready state."
        }

        function Wait-ServerStopped {
            param(
                [Parameter(Mandatory = $true)]
                [string]$ResourceGroupName,

                [Parameter(Mandatory = $true)]
                [string]$ServerName,

                [int]$TimeoutSeconds = 1800,
                [int]$PollSeconds = 15
            )

            $timeoutAt = (Get-Date).AddSeconds($TimeoutSeconds)
            while ((Get-Date) -lt $timeoutAt) {
                $server = Get-AzPostgreSqlFlexibleServer -ResourceGroupName $ResourceGroupName -Name $ServerName
                if ($server.State -eq 'Stopped') {
                    return $server
                }

                Start-TestSleep -Seconds $PollSeconds
            }

            throw "Timed out waiting for server '$ServerName' in resource group '$ResourceGroupName' to reach Stopped state."
        }

        function Ensure-ServerStopped {
            param(
                [Parameter(Mandatory = $true)]
                [string]$ResourceGroupName,

                [Parameter(Mandatory = $true)]
                [string]$ServerName
            )

            $server = Get-AzPostgreSqlFlexibleServer -ResourceGroupName $ResourceGroupName -Name $ServerName
            if ($server.State -eq 'Stopped') {
                return $server
            }

            Stop-AzPostgreSqlFlexibleServer -ResourceGroupName $ResourceGroupName -Name $ServerName | Out-Null
            return Wait-ServerStopped -ResourceGroupName $ResourceGroupName -ServerName $ServerName
        }
    }

    It 'StartAllServersAndVerifyStateThenSecondStartFails' -Skip:(-not $hasAllServers) {
        foreach ($target in $serverTargets) {
            Ensure-ServerStopped -ResourceGroupName $target.ResourceGroupName -ServerName $target.ServerName | Out-Null

            Start-AzPostgreSqlFlexibleServer -ResourceGroupName $target.ResourceGroupName -Name $target.ServerName | Out-Null

            $readyServer = Wait-ServerReady -ResourceGroupName $target.ResourceGroupName -ServerName $target.ServerName
            $readyServer.State | Should -Be 'Ready'

            {
                Start-AzPostgreSqlFlexibleServer `
                    -ResourceGroupName $target.ResourceGroupName `
                    -Name $target.ServerName `
                    -ErrorAction Stop
            } | Should -Throw
        }
    }
}
