if(($null -eq $TestName) -or ($TestName -contains 'AzMixedRealityRemoteRenderingAccount'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'AzMixedRealityRemoteRenderingAccount.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'AzMixedRealityRemoteRenderingAccount' {
    It 'CreateExpanded' {
        {
            $config = New-AzMixedRealityRemoteRenderingAccount -Name $env.remoteRenderingAccount1 -ResourceGroupName $env.resourceGroup -Location eastus -IdentityType 'SystemAssigned'
            $config.Name | Should -Be $env.remoteRenderingAccount1

            $config = New-AzMixedRealityRemoteRenderingAccount -Name $env.remoteRenderingAccount2 -ResourceGroupName $env.resourceGroup -Location eastus -IdentityType 'SystemAssigned'
            $config.Name | Should -Be $env.remoteRenderingAccount2
        } | Should -Not -Throw
    }

    It 'KeyRegenerateExpanded' {
        {
            $config = New-AzMixedRealityRemoteRenderingAccountKey -AccountName $env.remoteRenderingAccount1 -ResourceGroupName $env.resourceGroup -Serial 1
            $config.Count | Should -BeGreaterThan 0
        } | Should -Not -Throw
    }

    It 'KeyList' {
        {
            $config = Get-AzMixedRealityRemoteRenderingAccountKey -AccountName $env.remoteRenderingAccount1 -ResourceGroupName $env.resourceGroup
            $config.Count | Should -BeGreaterThan 0
        } | Should -Not -Throw
    }

    It 'List' {
        {
            $config = Get-AzMixedRealityRemoteRenderingAccount
            $config.Count | Should -BeGreaterThan 0
        } | Should -Not -Throw
    }

    It 'List1' {
        {
            $config = Get-AzMixedRealityRemoteRenderingAccount -ResourceGroupName $env.resourceGroup
            $config.Count | Should -BeGreaterThan 0
        } | Should -Not -Throw
    }

    It 'Get' {
        {
            $config = Get-AzMixedRealityRemoteRenderingAccount -ResourceGroupName $env.resourceGroup -Name $env.remoteRenderingAccount1
            $config.Name | Should -Be $env.remoteRenderingAccount1
        } | Should -Not -Throw
    }

    It 'KeyRegenerateViaIdentityExpanded' {
        {
            $config = Get-AzMixedRealityRemoteRenderingAccount -ResourceGroupName $env.resourceGroup -Name $env.remoteRenderingAccount2
            $config = New-AzMixedRealityRemoteRenderingAccountKey -InputObject $config -Serial 1
            $config.Count | Should -BeGreaterThan 0
        } | Should -Not -Throw
    }

    It 'UpdateExpanded' {
        {
            $config = Update-AzMixedRealityRemoteRenderingAccount -Name $env.remoteRenderingAccount1 -ResourceGroupName $env.resourceGroup -Location eastus -Tag @{"a"="1"}
            $config.Name | Should -Be $env.remoteRenderingAccount1
        } | Should -Not -Throw
    }

    It 'UpdateViaIdentityExpanded' {
        {
            $config = Get-AzMixedRealityRemoteRenderingAccount -ResourceGroupName $env.resourceGroup -Name $env.remoteRenderingAccount2
            $config = Update-AzMixedRealityRemoteRenderingAccount -InputObject $config -Location eastus -Tag @{"a"="1"}
            $config.Name | Should -Be $env.remoteRenderingAccount2
        } | Should -Not -Throw
    }

    It 'Delete' {
        {
            Remove-AzMixedRealityRemoteRenderingAccount -Name $env.remoteRenderingAccount1 -ResourceGroupName $env.resourceGroup
        } | Should -Not -Throw
    }

    It 'DeleteViaIdentity' {
        {
            $config = Get-AzMixedRealityRemoteRenderingAccount -ResourceGroupName $env.resourceGroup -Name $env.remoteRenderingAccount2
            Remove-AzMixedRealityRemoteRenderingAccount -InputObject $config
        } | Should -Not -Throw
    }
}
