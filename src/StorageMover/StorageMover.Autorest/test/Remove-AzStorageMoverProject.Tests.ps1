if(($null -eq $TestName) -or ($TestName -contains 'Remove-AzStorageMoverProject'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzStorageMoverProject.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Remove-AzStorageMoverProject' {
    It 'Delete' {
        $projectName = "testProject" + $env.RandomString
        $project = New-AzStorageMoverProject -ResourceGroupName $env.ResourceGroupName -StorageMoverName $env.InitialStoMoverName -Name $projectName -Description $description
        
        Remove-AzStorageMoverProject -ResourceGroupName $env.ResourceGroupName -StorageMoverName $env.InitialStoMoverName -Name $projectName
        $projectList = Get-AzStorageMoverProject -ResourceGroupName $env.ResourceGroupName -StorageMoverName $env.InitialStoMoverName 
        $projectList.Name | Should -Not -Contain $projectName
    }
}
