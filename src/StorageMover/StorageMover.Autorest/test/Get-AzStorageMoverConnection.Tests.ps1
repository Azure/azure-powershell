if(($null -eq $TestName) -or ($TestName -contains 'Get-AzStorageMoverConnection'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzStorageMoverConnection.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

# NOTE: Recording files for these tests do not yet exist. Remove the -skip flag
# after running `./test-module.ps1 -Record` against a live subscription with a
# valid Private Link Service.
Describe 'Get-AzStorageMoverConnection' {
    It 'List' -skip {
        $connections = Get-AzStorageMoverConnection -ResourceGroupName $env.ResourceGroupName -StorageMoverName $env.InitialStoMoverName
        $connections.Count | Should -BeGreaterOrEqual 1
        $connections.Name | Should -Contain $env.ConnectionName
    }

    It 'Get' -skip {
        $connection = Get-AzStorageMoverConnection -ResourceGroupName $env.ResourceGroupName -StorageMoverName $env.InitialStoMoverName -Name $env.ConnectionName
        $connection.Name | Should -Be $env.ConnectionName
        $connection.Type | Should -Be 'microsoft.storagemover/storagemovers/connections'
    }

    It 'GetViaIdentity' -skip {
        $connection = Get-AzStorageMoverConnection -ResourceGroupName $env.ResourceGroupName -StorageMoverName $env.InitialStoMoverName -Name $env.ConnectionName
        $result = Get-AzStorageMoverConnection -InputObject $connection
        $result.Name | Should -Be $env.ConnectionName
    }

    It 'GetViaIdentityStorageMover' -skip {
        $storageMover = Get-AzStorageMover -ResourceGroupName $env.ResourceGroupName -Name $env.InitialStoMoverName
        $connection = Get-AzStorageMoverConnection -StorageMoverInputObject $storageMover -Name $env.ConnectionName
        $connection.Name | Should -Be $env.ConnectionName
    }
}
