if(($null -eq $TestName) -or ($TestName -contains 'New-AzStorageMoverJobDefinition'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzStorageMoverJobDefinition.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzStorageMoverJobDefinition' {
    It 'CreateExpanded' {
        $jobName = "testJob1" + $env.RandomString
        $job1 = New-AzStorageMoverJobDefinition -Name $jobName -ProjectName $env.ProjectName -ResourceGroupName $env.ResourceGroupName -StorageMoverName $env.StorageMoverNameWithAgent -AgentName $env.AgentName -SourceName $env.NfsEndpointName -TargetName $env.ContainerEndpointName -CopyMode "Additive"
        $job1.Name | Should -Be $jobName 
        $job1.CopyMode | Should -Be "Additive"
        $job1.SourceName | Should -Be $env.NfsEndpointName
        $job1.TargetName | Should -Be $env.ContainerEndpointName
        
        $job1 = Get-AzStorageMoverJobDefinition -ProjectName $env.ProjectName -ResourceGroupName $env.ResourceGroupName -StorageMoverName $env.StorageMoverNameWithAgent -Name $jobName
        $job1.Name | Should -Be $jobName 
        $job1.CopyMode | Should -Be "Additive"
        $job1.SourceName | Should -Be $env.NfsEndpointName
        $job1.TargetName | Should -Be $env.ContainerEndpointName
    }
}
