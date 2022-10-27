if(($null -eq $TestName) -or ($TestName -contains 'AzMixedRealitySpatialAnchorsAccount'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'AzMixedRealitySpatialAnchorsAccount.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'AzMixedRealitySpatialAnchorsAccount' {
    It 'CreateExpanded' {
        {
            $config = New-AzMixedRealitySpatialAnchorsAccount -AccountName $env.spatialAnchorsAccount1 -ResourceGroupName $env.resourceGroup -Location eastus
            $config.Name | Should -Be $env.spatialAnchorsAccount1

            $config = New-AzMixedRealitySpatialAnchorsAccount -AccountName $env.spatialAnchorsAccount2 -ResourceGroupName $env.resourceGroup -Location eastus
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
            $config = Get-AzMixedRealitySpatialAnchorsAccount -AccountName $env.spatialAnchorsAccount1 -ResourceGroupName $env.resourceGroup
            $config.Name | Should -Be $env.spatialAnchorsAccount1
        } | Should -Not -Throw
    }

    It 'KeyRegenerateViaIdentityExpanded' {
        {
            $config = Get-AzMixedRealitySpatialAnchorsAccount -AccountName $env.spatialAnchorsAccount2 -ResourceGroupName $env.resourceGroup
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
            $config = Update-AzMixedRealitySpatialAnchorsAccount -AccountName $env.spatialAnchorsAccount1 -ResourceGroupName $env.resourceGroup -Location eastus -Tag @{"a"="1"}
            $config.Name | Should -Be $env.spatialAnchorsAccount1
        } | Should -Not -Throw
    }

    It 'UpdateViaIdentityExpanded' {
        {
            $config = Get-AzMixedRealitySpatialAnchorsAccount -AccountName $env.spatialAnchorsAccount2 -ResourceGroupName $env.resourceGroup
            $config = Update-AzMixedRealitySpatialAnchorsAccount -InputObject $config -Location eastus -Tag @{"a"="1"}
            $config.Name | Should -Be $env.spatialAnchorsAccount2
        } | Should -Not -Throw
    }

    It 'Delete' {
        {
            Remove-AzMixedRealitySpatialAnchorsAccount -AccountName $env.spatialAnchorsAccount1 -ResourceGroupName $env.resourceGroup
        } | Should -Not -Throw
    }

    It 'DeleteViaIdentity' {
        {
            $config = Get-AzMixedRealitySpatialAnchorsAccount -AccountName $env.spatialAnchorsAccount2 -ResourceGroupName $env.resourceGroup
            Remove-AzMixedRealitySpatialAnchorsAccount -InputObject $config
        } | Should -Not -Throw
    }
}
