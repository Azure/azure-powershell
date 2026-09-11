if(($null -eq $TestName) -or ($TestName -contains 'Update-AzPostgreSqlFlexibleServer'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzPostgreSqlFlexibleServer.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzPostgreSqlFlexibleServer' {
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
                    HighAvailabilityMode = $env["ServerHighAvailabilityMode$i"]
                }
            }
        }

        $hasAllServers = $serverTargets.Count -eq 6
        $haTargets = @($serverTargets | Where-Object { $_.HighAvailabilityMode -eq 'SameZone' -or $_.HighAvailabilityMode -eq 'ZoneRedundant' })
        $hasHaServers = $haTargets.Count -gt 0

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

        function Ensure-ServerReady {
            param(
                [Parameter(Mandatory = $true)]
                [string]$ResourceGroupName,

                [Parameter(Mandatory = $true)]
                [string]$ServerName
            )

            $server = Get-AzPostgreSqlFlexibleServer -ResourceGroupName $ResourceGroupName -Name $ServerName
            if ($server.State -eq 'Ready') {
                return $server
            }

            Start-AzPostgreSqlFlexibleServer -ResourceGroupName $ResourceGroupName -Name $ServerName | Out-Null
            return Wait-ServerReady -ResourceGroupName $ResourceGroupName -ServerName $ServerName
        }
    }

    It 'UpdateExpandedEnableStorageAutoGrowAllServers' -Skip:(-not $hasAllServers) {
        foreach ($target in $serverTargets) {
            Ensure-ServerReady -ResourceGroupName $target.ResourceGroupName -ServerName $target.ServerName | Out-Null

            $updatedServer = Update-AzPostgreSqlFlexibleServer `
                -ResourceGroupName $target.ResourceGroupName `
                -Name $target.ServerName `
                -StorageAutoGrow Enabled

            $updatedServer.StorageAutoGrow | Should -Be 'Enabled'

            $fetchedServer = Get-AzPostgreSqlFlexibleServer -ResourceGroupName $target.ResourceGroupName -Name $target.ServerName
            $fetchedServer.StorageAutoGrow | Should -Be 'Enabled'
        }
    }

    It 'UpdateExpandedDisableStorageAutoGrowAllServers' -Skip:(-not $hasAllServers) {
        foreach ($target in $serverTargets) {
            Ensure-ServerReady -ResourceGroupName $target.ResourceGroupName -ServerName $target.ServerName | Out-Null

            $updatedServer = Update-AzPostgreSqlFlexibleServer `
                -ResourceGroupName $target.ResourceGroupName `
                -Name $target.ServerName `
                -StorageAutoGrow Disabled

            $updatedServer.StorageAutoGrow | Should -Be 'Disabled'

            $fetchedServer = Get-AzPostgreSqlFlexibleServer -ResourceGroupName $target.ResourceGroupName -Name $target.ServerName
            $fetchedServer.StorageAutoGrow | Should -Be 'Disabled'
        }
    }

    It 'UpdateExpandedResetAdministratorLoginPasswordAllServers' -Skip:(-not $hasAllServers) {
        foreach ($target in $serverTargets) {
            Ensure-ServerReady -ResourceGroupName $target.ResourceGroupName -ServerName $target.ServerName | Out-Null

            $newPassword = ConvertTo-SecureString ("AzpsReset!Pass$($target.Index)23A") -AsPlainText -Force

            $updatedServer = Update-AzPostgreSqlFlexibleServer `
                -ResourceGroupName $target.ResourceGroupName `
                -Name $target.ServerName `
                -AdministratorLoginPassword $newPassword

            $updatedServer.Name | Should -Be $target.ServerName
        }
    }

    It 'UpdateExpandedSwitchHighAvailabilityModeShouldFailForAllHaServers' -Skip:(-not $hasHaServers) {
        foreach ($target in $haTargets) {
            $server = Get-AzPostgreSqlFlexibleServer -ResourceGroupName $target.ResourceGroupName -Name $target.ServerName
            $currentMode = $server.HighAvailabilityMode
            $oppositeMode = if ($currentMode -eq 'SameZone') { 'ZoneRedundant' } else { 'SameZone' }

            {
                Update-AzPostgreSqlFlexibleServer `
                    -ResourceGroupName $target.ResourceGroupName `
                    -Name $target.ServerName `
                    -HighAvailabilityMode $oppositeMode `
                    -ErrorAction Stop
            } | Should -Throw

            $postAttemptServer = Get-AzPostgreSqlFlexibleServer -ResourceGroupName $target.ResourceGroupName -Name $target.ServerName
            $postAttemptServer.HighAvailabilityMode | Should -Be $currentMode
        }
    }
}
