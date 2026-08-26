if(($null -eq $TestName) -or ($TestName -contains 'Update-AzDocumentDbMongoCluster'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzDocumentDbMongoCluster.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzDocumentDBMongoCluster' {
    BeforeAll {
        $rg = $env.crudRg + '-props'
        $cluster = $env.crudCluster + 'p'
        $loc = $env.location
        if ($TestMode -ne 'playback') { New-AzResourceGroup -Name $rg -Location $loc | Out-Null }
    }
    AfterAll {
        if ($TestMode -ne 'playback') { Remove-AzResourceGroup -Name $rg -ErrorAction SilentlyContinue | Out-Null }
    }

    It 'MongoCluster additional properties create + update coverage' {
        # Create a cluster exercising additional create-time properties: server version,
        # public network access, tags, allowed authentication modes, and preview features.
        $password = ConvertTo-SecureString 'CliTest2026!Pw' -AsPlainText -Force
        $created = New-AzDocumentDBMongoCluster -Name $cluster -ResourceGroupName $rg -Location $loc `
            -AdministratorUserName $env.adminUser -AdministratorPassword $password `
            -ComputeTier M30 -StorageSizeGb 128 -StorageType PremiumSSD `
            -ShardingShardCount 1 -HighAvailabilityTargetMode Disabled `
            -ServerVersion 7.0 -PublicNetworkAccess Enabled `
            -AuthConfigAllowedMode NativeAuth, MicrosoftEntraID `
            -PreviewFeature GeoReplicas -Tag @{ env = 'prod'; team = 'cli' }
        $created.ProvisioningState | Should -Be 'Succeeded'
        $created.ServerVersion | Should -Be '7.0'
        $created.PublicNetworkAccess | Should -Be 'Enabled'

        # Enable the Mongo data API (only permitted once the cluster is provisioned and
        # while public network access is enabled). Mutations are wrapped in a conflict retry.
        $enabled = Invoke-DocumentDBMutation { Update-AzDocumentDBMongoCluster -Name $cluster -ResourceGroupName $rg -DataApiMode Enabled }
        $enabled.DataApiMode | Should -Be 'Enabled'
        Wait-DocumentDBClusterSucceeded -ResourceGroupName $rg -Name $cluster | Out-Null

        # Disable the data API and public network access.
        $disabled = Invoke-DocumentDBMutation { Update-AzDocumentDBMongoCluster -Name $cluster -ResourceGroupName $rg -DataApiMode Disabled -PublicNetworkAccess Disabled }
        $disabled.DataApiMode | Should -Be 'Disabled'
        $disabled.PublicNetworkAccess | Should -Be 'Disabled'
        Wait-DocumentDBClusterSucceeded -ResourceGroupName $rg -Name $cluster | Out-Null

        # Restrict authentication to Microsoft Entra ID only.
        $entraOnly = Invoke-DocumentDBMutation { Update-AzDocumentDBMongoCluster -Name $cluster -ResourceGroupName $rg -AuthConfigAllowedMode MicrosoftEntraID }
        $entraOnly | Should -Not -BeNullOrEmpty
        (Wait-DocumentDBClusterSucceeded -ResourceGroupName $rg -Name $cluster).ProvisioningState | Should -Be 'Succeeded'
    }
}
