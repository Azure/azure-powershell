if(($null -eq $TestName) -or ($TestName -contains 'Get-AzStorageMover'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzStorageMover.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzStorageMover' {
    It 'List' {
        $StoMoverList = Get-AzStorageMover
        $StoMoverList.Count | Should -BeGreaterOrEqual 1 
    }

    It 'Get' {
        $StoMover = Get-AzStorageMover -Name $env.InitialStoMoverName -ResourceGroupName $env.ResourceGroupName
        $stoMover.Name | Should -Be $env.InitialStoMoverName
        $StoMover.Description | Should -Be $env.InitialSMDescription
        $stoMover.Location | Should -Be $env.Location
        Foreach($key in $env.InitialStoMoverTag) {
            $stoMover.Tag[$key] | Should -Be $env.InitialStoMoverTag[$key]
        }
    }

    It 'List1' {
        $StoMoverList = Get-AzStorageMover -ResourceGroupName $env.ResourceGroupName
        $StoMoverList.Count | Should -BeGreaterOrEqual 1 
    }
}
