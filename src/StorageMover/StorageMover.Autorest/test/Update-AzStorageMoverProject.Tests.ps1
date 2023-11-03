if(($null -eq $TestName) -or ($TestName -contains 'Update-AzStorageMoverProject'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzStorageMoverProject.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzStorageMoverProject' {
    It 'UpdateExpanded' {
        $projectName = "testProject2"+ $env.RandomString
        $description = "test Project description"
        $updatedDescription = "update Project description"
        $project = New-AzStorageMoverProject -ResourceGroupName $env.ResourceGroupName -StorageMoverName $env.InitialStoMoverName -Name $projectName -Description $description
        $project = Update-AzStorageMoverProject -ResourceGroupName $env.ResourceGroupName -StorageMoverName $env.InitialStoMoverName -Name $projectName -Description $updatedDescription
        $project.Name | Should -Be $projectName 
        $project.Description | Should -Be $updatedDescription

        $project = Get-AzStorageMoverProject -ResourceGroupName $env.ResourceGroupName -StorageMoverName $env.InitialStoMoverName -Name $projectName
        $project.Name | Should -Be $projectName 
        $project.Description | Should -Be $updatedDescription
    }
}
