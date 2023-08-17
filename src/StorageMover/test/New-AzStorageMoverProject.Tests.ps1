if(($null -eq $TestName) -or ($TestName -contains 'New-AzStorageMoverProject'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzStorageMoverProject.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzStorageMoverProject' {
    It 'CreateExpanded' {
        $projectName = "testProject" + $env.RandomString
        $description = "test project description"
        $project = New-AzStorageMoverProject -ResourceGroupName $env.ResourceGroupName -StorageMoverName $env.InitialStoMoverName -Name $projectName -Description $description
        $project.Name | Should -Be $projectName 
        $project.Description | Should -Be $description
        
        $project = Get-AzStorageMoverProject -ResourceGroupName $env.ResourceGroupName -StorageMoverName $env.InitialStoMoverName -Name $projectName
        $project.Name | Should -Be $projectName 
        $project.Description | Should -Be $description
    }
}
