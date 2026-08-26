if(($null -eq $TestName) -or ($TestName -contains 'New-AzDocumentDbMongoCluster'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzDocumentDbMongoCluster.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzDocumentDBMongoCluster' {
    BeforeAll {
        $rg = $env.crudRg
        $cluster = $env.crudCluster
        $loc = $env.location
        if ($TestMode -ne 'playback') { New-AzResourceGroup -Name $rg -Location $loc | Out-Null }
    }
    AfterAll {
        if ($TestMode -ne 'playback') { Remove-AzResourceGroup -Name $rg -ErrorAction SilentlyContinue | Out-Null }
    }

    It 'MongoCluster CRUD lifecycle' {
        # Name availability for a fresh cluster name.
        (Test-AzDocumentDBMongoClusterNameAvailability -Name $cluster -Location $loc -Type 'Microsoft.DocumentDB/mongoClusters').NameAvailable | Should -Be $true

        # Create and block until the cluster is provisioned.
        $created = New-DocumentDBTestCluster -ResourceGroupName $rg -Name $cluster -Location $loc
        $created.Name | Should -Be $cluster
        $created.ProvisioningState | Should -Be 'Succeeded'

        # Inspect the provisioned cluster.
        $show = Get-AzDocumentDBMongoCluster -Name $cluster -ResourceGroupName $rg
        $show.Name | Should -Be $cluster
        $show.ProvisioningState | Should -Be 'Succeeded'
        $show.AdministratorUserName | Should -Be $env.adminUser
        $show.ComputeTier | Should -Be 'M30'
        $show.StorageSizeGb | Should -Be 128
        $show.StorageType | Should -Be 'PremiumSSD'
        $show.ShardingShardCount | Should -Be 1

        # The cluster shows up in the resource-group listing.
        @(Get-AzDocumentDBMongoCluster -ResourceGroupName $rg | Where-Object { $_.Name -eq $cluster }).Count | Should -Be 1

        # Connection strings are available for the provisioned cluster.
        $cs = Get-AzDocumentDBMongoClusterConnectionString -MongoClusterName $cluster -ResourceGroupName $rg
        @($cs.ConnectionString).Count | Should -BeGreaterThan 0

        # Update the cluster (tags). The update is asynchronous and the service keeps a
        # brief internal lock even after it settles, so every mutating call is wrapped in a
        # conflict/in-progress retry.
        $updated = Invoke-DocumentDBMutation { Update-AzDocumentDBMongoCluster -Name $cluster -ResourceGroupName $rg -Tag @{ env = 'test'; owner = 'cli' } }
        $updated | Should -Not -BeNullOrEmpty
        (Wait-DocumentDBClusterSucceeded -ResourceGroupName $rg -Name $cluster).ProvisioningState | Should -Be 'Succeeded'

        # Reset the administrator password (custom wrapper).
        $newPassword = ConvertTo-SecureString 'CliReset2026!Pw' -AsPlainText -Force
        { Invoke-DocumentDBMutation { Reset-AzDocumentDBMongoClusterPassword -Name $cluster -ResourceGroupName $rg -AdministratorPassword $newPassword } } | Should -Not -Throw
        Wait-DocumentDBClusterSucceeded -ResourceGroupName $rg -Name $cluster | Out-Null

        # Delete the cluster.
        { Invoke-DocumentDBMutation { Remove-AzDocumentDBMongoCluster -Name $cluster -ResourceGroupName $rg } } | Should -Not -Throw
    }
}
