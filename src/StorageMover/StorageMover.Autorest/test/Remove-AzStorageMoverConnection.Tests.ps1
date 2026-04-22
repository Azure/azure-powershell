if(($null -eq $TestName) -or ($TestName -contains 'Remove-AzStorageMoverConnection'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzStorageMoverConnection.Recording.json'
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
Describe 'Remove-AzStorageMoverConnection' {
    It 'Delete' -skip {
        $connectionName = 'testRemoveConnection1' + $env.RandomString
        New-AzStorageMoverConnection -Name $connectionName -ResourceGroupName $env.ResourceGroupName -StorageMoverName $env.InitialStoMoverName -PrivateLinkServiceId $env.PrivateLinkServiceId
        Remove-AzStorageMoverConnection -ResourceGroupName $env.ResourceGroupName -StorageMoverName $env.InitialStoMoverName -Name $connectionName
        { Get-AzStorageMoverConnection -ResourceGroupName $env.ResourceGroupName -StorageMoverName $env.InitialStoMoverName -Name $connectionName -ErrorAction Stop } | Should -Throw
    }

    It 'DeleteViaIdentity' -skip {
        $connectionName = 'testRemoveConnection2' + $env.RandomString
        $connection = New-AzStorageMoverConnection -Name $connectionName -ResourceGroupName $env.ResourceGroupName -StorageMoverName $env.InitialStoMoverName -PrivateLinkServiceId $env.PrivateLinkServiceId
        Remove-AzStorageMoverConnection -InputObject $connection
        { Get-AzStorageMoverConnection -ResourceGroupName $env.ResourceGroupName -StorageMoverName $env.InitialStoMoverName -Name $connectionName -ErrorAction Stop } | Should -Throw
    }

    It 'DeleteViaIdentityStorageMover' -skip {
        $connectionName = 'testRemoveConnection3' + $env.RandomString
        New-AzStorageMoverConnection -Name $connectionName -ResourceGroupName $env.ResourceGroupName -StorageMoverName $env.InitialStoMoverName -PrivateLinkServiceId $env.PrivateLinkServiceId
        $storageMover = Get-AzStorageMover -ResourceGroupName $env.ResourceGroupName -Name $env.InitialStoMoverName
        Remove-AzStorageMoverConnection -StorageMoverInputObject $storageMover -Name $connectionName
        { Get-AzStorageMoverConnection -ResourceGroupName $env.ResourceGroupName -StorageMoverName $env.InitialStoMoverName -Name $connectionName -ErrorAction Stop } | Should -Throw
    }
}
