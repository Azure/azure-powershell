if(($null -eq $TestName) -or ($TestName -contains 'Get-AzDevCenterAdminNetworkConnection'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzDevCenterAdminNetworkConnection.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzDevCenterAdminNetworkConnection' {
    It 'List' {
        $listOfNcs = Get-AzDevCenterAdminNetworkConnection
        $listOfNcs.Count | Should -BeGreaterOrEqual 2
    }

    It 'Get' {
        $nc = Get-AzDevCenterAdminNetworkConnection -ResourceGroupName $env.resourceGroup -Name $env.networkConnectionName
        $nc.DomainJoinType | Should -Be $env.aadJoinType
        $nc.Name | Should -Be $env.networkConnectionName
    }


    It 'List1' {
        $listOfNcs = Get-AzDevCenterAdminNetworkConnection -ResourceGroupName $env.resourceGroup
        $listOfNcs.Count | Should -BeGreaterOrEqual 2
    }

    It 'GetViaIdentity' {
        $nc = Get-AzDevCenterAdminNetworkConnection -ResourceGroupName $env.resourceGroup -Name $env.networkConnectionName
        $nc = Get-AzDevCenterAdminNetworkConnection -InputObject $nc
        $nc.DomainJoinType | Should -Be $env.aadJoinType
        $nc.Name | Should -Be $env.networkConnectionName
    }
}
