if(($null -eq $TestName) -or ($TestName -contains 'Update-AzStorageMoverJobDefinition'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzStorageMoverJobDefinition.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzStorageMoverJobDefinition' {
    It 'UpdateExpanded' {
        $jobName = "testUpdateJob5" + $env.RandomString
        $job = New-AzStorageMoverJobDefinition -Name $jobName -ProjectName $env.ProjectName -ResourceGroupName $env.ResourceGroupName -StorageMoverName $env.StorageMoverNameWithAgent -AgentName $env.AgentName -SourceName $env.NfsEndpointName -TargetName $env.ContainerEndpointName -CopyMode "Additive"
        $updateDescription = "update description"
        $job = Update-AzStorageMoverJobDefinition -Name $jobName -ProjectName $env.ProjectName -ResourceGroupName $env.ResourceGroupName -StorageMoverName $env.StorageMoverNameWithAgent -Description $updateDescription
        $job.Description | Should -Be $updateDescription
        $job.Name | Should -Be $jobName 
    }
}
