if(($null -eq $TestName) -or ($TestName -contains 'Get-AzDevCenterAdminPool'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzDevCenterAdminPool.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzDevCenterAdminPool' {
    It 'List' {
        $listOfPools = Get-AzDevCenterAdminPool -ResourceGroupName $env.resourceGroup -ProjectName $env.projectName
        
        $listOfPools.Count | Should -BeGreaterOrEqual 2
    }

    It 'Get' {
        $pool = Get-AzDevCenterAdminPool -ResourceGroupName $env.resourceGroup -Name $env.poolName -ProjectName $env.projectName

        $pool.Name | Should -Be $env.poolName
        $pool.DevBoxDefinitionName | Should -Be $env.devBoxDefinitionName
        $pool.LocalAdministrator | Should -Be "Enabled"
        $pool.NetworkConnectionName | Should -Be $env.attachedNetworkName
        $pool.StopOnDisconnectGracePeriodMinute | Should -Be 60
        $pool.StopOnDisconnectStatus | Should -Be "Enabled"
        $pool.LicenseType | Should -Be "Windows_Client"
    }

    It 'GetViaIdentity' {
        $pool = Get-AzDevCenterAdminPool -ResourceGroupName $env.resourceGroup -Name $env.poolName -ProjectName $env.projectName
        $pool = Get-AzDevCenterAdminPool -InputObject $pool

        $pool.Name | Should -Be $env.poolName
        $pool.DevBoxDefinitionName | Should -Be $env.devBoxDefinitionName
        $pool.LocalAdministrator | Should -Be "Enabled"
        $pool.NetworkConnectionName | Should -Be $env.attachedNetworkName
        $pool.StopOnDisconnectGracePeriodMinute | Should -Be 60
        $pool.StopOnDisconnectStatus | Should -Be "Enabled"
        $pool.LicenseType | Should -Be "Windows_Client"
    }
}
