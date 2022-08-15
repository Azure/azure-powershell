if(($null -eq $TestName) -or ($TestName -contains 'Update-AzStorageMover'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzStorageMover.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzStorageMover' {
    It 'UpdateExpanded' {
        $storageMoverName = "testStorageMover" + "k3pmhtl9"
        $description = "test Storage mover description" 
        $updateDescription = "update storage mover description"
        $newStorageMover = New-AzStorageMover -ResourceGroupName $env.ResourceGroupName -Name $storageMoverName -Location $env.Location -Description $description
        $newStorageMover.Name | Should -Be $storageMoverName
        $newStorageMover.Location | Should -Be $env.Location
        $newStorageMover.Description | Should -Be $description 

        $updatedStorageMover = Update-AzStorageMover -ResourceGroupName $env.ResourceGroupName -Name $storageMoverName -Description $updateDescription
        $updatedStorageMover.Name | Should -Be $storageMoverName
        $updatedStorageMover.Location | Should -Be $env.Location
        $updatedStorageMover.Description | Should -Be $updateDescription

        $updatedStorageMover = Get-AzStorageMover -ResourceGroupName $env.ResourceGroupName -Name $storageMoverName
        $updatedStorageMover.Name | Should -Be $storageMoverName
        $updatedStorageMover.Location | Should -Be $env.Location
        $updatedStorageMover.Description | Should -Be $updateDescription

    }
}
