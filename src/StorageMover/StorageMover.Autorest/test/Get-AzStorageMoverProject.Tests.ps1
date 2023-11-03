if(($null -eq $TestName) -or ($TestName -contains 'Get-AzStorageMoverProject'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzStorageMoverProject.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzStorageMoverProject' {
    It 'List' {
        $projectList = Get-AzStorageMoverProject -ResourceGroupName $env.ResourceGroupName -StorageMoverName $env.InitialStoMoverName
        $projectList.Count | Should -BeGreaterOrEqual 1
    }

    It 'Get' {
        $project = Get-AzStorageMoverProject -ResourceGroupName $env.ResourceGroupName -StorageMoverName $env.InitialStoMoverName -Name $env.ProjectName
        $project.Name | Should -Be $env.ProjectName
    }
}
