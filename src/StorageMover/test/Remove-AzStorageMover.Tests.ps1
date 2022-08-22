if(($null -eq $TestName) -or ($TestName -contains 'Remove-AzStorageMover'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzStorageMover.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Remove-AzStorageMover' {
    # Adding try-catch here to record the response despite the pending fix server error.
    It 'Delete' {
        $storageMoverName = "testStoMover3" + $env.RandomString
        $StorageMover = New-AzStorageMover -ResourceGroupName $env.ResourceGroupName -Name $storageMoverName -Location $env.Location -Description $description
        Remove-AzStorageMover -ResourceGroupName $env.ResourceGroupName -Name $storageMoverName -Force
        $stoMoverList = Get-AzStorageMover
        $stoMoverList.Name | Should -Not -Contain $storageMoverName 
    }
}
