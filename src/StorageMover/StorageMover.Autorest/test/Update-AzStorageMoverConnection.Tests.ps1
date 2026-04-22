if(($null -eq $TestName) -or ($TestName -contains 'Update-AzStorageMoverConnection'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzStorageMoverConnection.Recording.json'
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
Describe 'Update-AzStorageMoverConnection' {
    It 'UpdateExpanded' -skip {
        $updatedDescription = 'updated connection description'
        $connection = Update-AzStorageMoverConnection -ResourceGroupName $env.ResourceGroupName -StorageMoverName $env.InitialStoMoverName -Name $env.ConnectionName -Description $updatedDescription
        $connection.Name | Should -Be $env.ConnectionName
        $connection.Property.Description | Should -Be $updatedDescription

        $connection = Get-AzStorageMoverConnection -ResourceGroupName $env.ResourceGroupName -StorageMoverName $env.InitialStoMoverName -Name $env.ConnectionName
        $connection.Property.Description | Should -Be $updatedDescription
    }

    It 'UpdateViaIdentityExpanded' -skip {
        $updatedDescription = 'updated via identity'
        $connection = Get-AzStorageMoverConnection -ResourceGroupName $env.ResourceGroupName -StorageMoverName $env.InitialStoMoverName -Name $env.ConnectionName
        $result = Update-AzStorageMoverConnection -InputObject $connection -Description $updatedDescription
        $result.Property.Description | Should -Be $updatedDescription
    }

    It 'UpdateViaIdentityStorageMoverExpanded' -skip {
        $updatedDescription = 'updated via storage mover identity'
        $storageMover = Get-AzStorageMover -ResourceGroupName $env.ResourceGroupName -Name $env.InitialStoMoverName
        $result = Update-AzStorageMoverConnection -StorageMoverInputObject $storageMover -Name $env.ConnectionName -Description $updatedDescription
        $result.Property.Description | Should -Be $updatedDescription
    }
}
