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
                    AvailabilityZone = $env["ServerZone$i"]
                    GeoBackup = $env["ServerGeoBackup$i"]
                    StorageType = $env["ServerStorageType$i"]
                    SkuTier = $env["ServerSkuTier$i"]
                    SkuName = $env["ServerSkuName$i"]
                    HighAvailabilityMode = $env["ServerHighAvailabilityMode$i"]
                    HighAvailabilityStandbyZone = $env["ServerHighAvailabilityStandbyZone$i"]
                }
            }
        }

        $hasAllServers = $serverTargets.Count -eq 6
    }

    It 'List1' {
        $servers = Get-AzPostgreSqlFlexibleServer -ResourceGroupName $env.ResourceGroupName1
        $servers.Count | Should -BeGreaterOrEqual 1
    }

    It 'Get' {
        $server = Get-AzPostgreSqlFlexibleServer -ResourceGroupName $env.ResourceGroupName1 -Name $env.ServerName1
        $server.Name | Should -Be $env.ServerName1
        $server.ResourceGroupName | Should -Be $env.ResourceGroupName1
    }

    It 'List' -Skip:(-not $hasAllServers) {
        $allServers = Get-AzPostgreSqlFlexibleServer
        $allServerNames = $allServers.Name
        foreach ($target in $serverTargets) {
            $allServerNames | Should -Contain $target.ServerName
        }
    }

    It 'GetViaIdentity' {
        $inputObject = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.ResourceGroupName1)/providers/Microsoft.DBforPostgreSQL/flexibleServers/$($env.ServerName1)"

        $server = Get-AzPostgreSqlFlexibleServer -InputObject $inputObject
        $server.Name | Should -Be $env.ServerName1
        $server.ResourceGroupName | Should -Be $env.ResourceGroupName1
    }

    It 'ValidateAllServersDeployedConfiguration' -Skip:(-not $hasAllServers) {
        foreach ($target in $serverTargets) {
            $server = Get-AzPostgreSqlFlexibleServer -ResourceGroupName $target.ResourceGroupName -Name $target.ServerName

            $server.Name | Should -Be $target.ServerName
            $server.ResourceGroupName | Should -Be $target.ResourceGroupName
            $server.AvailabilityZone | Should -Be $target.AvailabilityZone
            $server.AdministratorLogin | Should -Be 'azpsadmin'
            $server.BackupGeoRedundantBackup | Should -Be $target.GeoBackup
            $server.StorageType | Should -Be $target.StorageType
            $server.StorageSizeGb | Should -Be 32
            $server.SkuTier | Should -Be $target.SkuTier
            $server.SkuName | Should -Be $target.SkuName

            if ([string]::IsNullOrWhiteSpace($target.HighAvailabilityMode)) {
                @($null, '', 'Disabled') | Should -Contain $server.HighAvailabilityMode
                @($null, '') | Should -Contain $server.HighAvailabilityStandbyAvailabilityZone
            } else {
                $server.HighAvailabilityMode | Should -Be $target.HighAvailabilityMode
                $server.HighAvailabilityStandbyAvailabilityZone | Should -Be $target.HighAvailabilityStandbyZone
            }
        }
    }
}
