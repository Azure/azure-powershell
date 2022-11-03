if(($null -eq $TestName) -or ($TestName -contains 'AzMixedRealityObjectAnchorAccount'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'AzMixedRealityObjectAnchorAccount.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'AzMixedRealityObjectAnchorAccount' {
    It 'CreateExpanded' {
        {
            $config = New-AzMixedRealityObjectAnchorAccount -Name $env.objectAnchorsAccount1 -ResourceGroupName $env.resourceGroup -Location eastus2
            $config.Name | Should -Be $env.objectAnchorsAccount1

            $config = New-AzMixedRealityObjectAnchorAccount -Name $env.objectAnchorsAccount2 -ResourceGroupName $env.resourceGroup -Location eastus2
            $config.Name | Should -Be $env.objectAnchorsAccount2
        } | Should -Not -Throw
    }

    It 'KeyRegenerateExpanded' {
        {
            $config = New-AzMixedRealityObjectAnchorAccountKey -AccountName $env.objectAnchorsAccount1 -ResourceGroupName $env.resourceGroup -Serial 1
            $config.Count | Should -BeGreaterThan 0
        } | Should -Not -Throw
    }

    It 'List' {
        {
            $config = Get-AzMixedRealityObjectAnchorAccount
            $config.Count | Should -BeGreaterThan 0
        } | Should -Not -Throw
    }

    It 'List1' {
        {
            $config = Get-AzMixedRealityObjectAnchorAccount -ResourceGroupName $env.resourceGroup
            $config.Count | Should -BeGreaterThan 0
        } | Should -Not -Throw
    }

    It 'Get' {
        {
            $config = Get-AzMixedRealityObjectAnchorAccount -Name $env.objectAnchorsAccount1 -ResourceGroupName $env.resourceGroup
            $config.Name | Should -Be $env.objectAnchorsAccount1
        } | Should -Not -Throw
    }

    It 'KeyList' {
        {
            $config = Get-AzMixedRealityObjectAnchorAccountKey -AccountName $env.objectAnchorsAccount1 -ResourceGroupName $env.resourceGroup
            $config.Count | Should -BeGreaterThan 0
        } | Should -Not -Throw
    }

    It 'KeyRegenerateViaIdentityExpanded' {
        {
            $config = Get-AzMixedRealityObjectAnchorAccount -Name $env.objectAnchorsAccount2 -ResourceGroupName $env.resourceGroup
            $config = New-AzMixedRealityObjectAnchorAccountKey -InputObject $config -Serial 1
            $config.Count | Should -BeGreaterThan 0
        } | Should -Not -Throw
    }

    It 'UpdateExpanded' {
        {
            $config = Update-AzMixedRealityObjectAnchorAccount -Name $env.objectAnchorsAccount1 -ResourceGroupName $env.resourceGroup -Location eastus2 -Tag @{"a"="1"}
            $config.Name | Should -Be $env.objectAnchorsAccount1
        } | Should -Not -Throw
    }

    It 'UpdateViaIdentityExpanded' {
        {
            $config = Get-AzMixedRealityObjectAnchorAccount -Name $env.objectAnchorsAccount2 -ResourceGroupName $env.resourceGroup
            $config = Update-AzMixedRealityObjectAnchorAccount -InputObject $config -Location eastus2 -Tag @{"a"="1"}
            $config.Name | Should -Be $env.objectAnchorsAccount2
        } | Should -Not -Throw
    }

    It 'Delete' {
        {
            Remove-AzMixedRealityObjectAnchorAccount -Name $env.objectAnchorsAccount1 -ResourceGroupName $env.resourceGroup
        } | Should -Not -Throw
    }

    It 'DeleteViaIdentity' {
        {
            $config = Get-AzMixedRealityObjectAnchorAccount -Name $env.objectAnchorsAccount2 -ResourceGroupName $env.resourceGroup
            Remove-AzMixedRealityObjectAnchorAccount -InputObject $config
        } | Should -Not -Throw
    }
}
