if(($null -eq $TestName) -or ($TestName -contains 'AzMixedRealitySpatialAnchorAccount'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'AzMixedRealitySpatialAnchorAccount.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'AzMixedRealitySpatialAnchorAccount' {
    It 'CreateExpanded' {
        {
            $config = New-AzMixedRealitySpatialAnchorAccount -Name $env.spatialAnchorsAccount1 -ResourceGroupName $env.resourceGroup -Location eastus
            $config.Name | Should -Be $env.spatialAnchorsAccount1

            $config = New-AzMixedRealitySpatialAnchorAccount -Name $env.spatialAnchorsAccount2 -ResourceGroupName $env.resourceGroup -Location eastus
            $config.Name | Should -Be $env.spatialAnchorsAccount2
        } | Should -Not -Throw
    }

    It 'KeyRegenerateExpanded' {
        {
            $config = New-AzMixedRealitySpatialAnchorAccountKey -AccountName $env.spatialAnchorsAccount1 -ResourceGroupName $env.resourceGroup -Serial 1
            $config.Count | Should -BeGreaterThan 0
        } | Should -Not -Throw
    }

    It 'List' {
        {
            $config = Get-AzMixedRealitySpatialAnchorAccount
            $config.Count | Should -BeGreaterThan 0
        } | Should -Not -Throw
    }

    It 'List1' {
        {
            $config = Get-AzMixedRealitySpatialAnchorAccount -ResourceGroupName $env.resourceGroup
            $config.Count | Should -BeGreaterThan 0
        } | Should -Not -Throw
    }

    It 'Get' {
        {
            $config = Get-AzMixedRealitySpatialAnchorAccount -Name $env.spatialAnchorsAccount1 -ResourceGroupName $env.resourceGroup
            $config.Name | Should -Be $env.spatialAnchorsAccount1
        } | Should -Not -Throw
    }

    It 'KeyRegenerateViaIdentityExpanded' {
        {
            $config = Get-AzMixedRealitySpatialAnchorAccount -Name $env.spatialAnchorsAccount2 -ResourceGroupName $env.resourceGroup
            $config = New-AzMixedRealitySpatialAnchorAccountKey -InputObject $config -Serial 1
            $config.Count | Should -BeGreaterThan 0
        } | Should -Not -Throw
    }

    It 'KeyList' {
        {
            $config = Get-AzMixedRealitySpatialAnchorAccountKey -AccountName $env.spatialAnchorsAccount1 -ResourceGroupName $env.resourceGroup
            $config.Count | Should -BeGreaterThan 0
        } | Should -Not -Throw
    }

    It 'UpdateExpanded' {
        {
            $config = Update-AzMixedRealitySpatialAnchorAccount -Name $env.spatialAnchorsAccount1 -ResourceGroupName $env.resourceGroup -Location eastus -Tag @{"a"="1"}
            $config.Name | Should -Be $env.spatialAnchorsAccount1
        } | Should -Not -Throw
    }

    It 'UpdateViaIdentityExpanded' {
        {
            $config = Get-AzMixedRealitySpatialAnchorAccount -Name $env.spatialAnchorsAccount2 -ResourceGroupName $env.resourceGroup
            $config = Update-AzMixedRealitySpatialAnchorAccount -InputObject $config -Location eastus -Tag @{"a"="1"}
            $config.Name | Should -Be $env.spatialAnchorsAccount2
        } | Should -Not -Throw
    }

    It 'Delete' {
        {
            Remove-AzMixedRealitySpatialAnchorAccount -Name $env.spatialAnchorsAccount1 -ResourceGroupName $env.resourceGroup
        } | Should -Not -Throw
    }

    It 'DeleteViaIdentity' {
        {
            $config = Get-AzMixedRealitySpatialAnchorAccount -Name $env.spatialAnchorsAccount2 -ResourceGroupName $env.resourceGroup
            Remove-AzMixedRealitySpatialAnchorAccount -InputObject $config
        } | Should -Not -Throw
    }
}
