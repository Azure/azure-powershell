if(($null -eq $TestName) -or ($TestName -contains 'New-AzStorageMover'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzStorageMover.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzStorageMover' {
    It 'CreateExpanded' {
        $storageMoverName = "testStoMover2" + $env.RandomString
        $description = "test Storage mover description"
        $newStorageMover = New-AzStorageMover -ResourceGroupName $env.ResourceGroupName -Name $storageMoverName -Location $env.Location -Description $description
        $newStorageMover.Name | Should -Be $storageMoverName
        $newStorageMover.Location | Should -Be $env.Location
        $newStorageMover.Description | Should -Be $description 

        $newStorageMover = Get-AzStorageMover -ResourceGroupName $env.ResourceGroupName -Name $storageMoverName
        $newStorageMover.Name | Should -Be $storageMoverName
        $newStorageMover.Location | Should -Be $env.Location
        $newStorageMover.Description | Should -Be $description 
    }
}
