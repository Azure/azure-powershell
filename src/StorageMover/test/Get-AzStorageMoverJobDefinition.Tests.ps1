if(($null -eq $TestName) -or ($TestName -contains 'Get-AzStorageMoverJobDefinition'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzStorageMoverJobDefinition.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzStorageMoverJobDefinition' {
    It 'List' {
        $jobDefinitionList = Get-AzStorageMoverJobDefinition -ProjectName $env.ProjectName -ResourceGroupName $env.ResourceGroupName -StorageMoverName $env.StorageMoverNameWithAgent
        $jobDefinitionList.Count | Should -BeGreaterOrEqual 1 
    }

    It 'Get' {
        $jobDefinition = Get-AzStorageMoverJobDefinition -ProjectName $env.ProjectName -ResourceGroupName $env.ResourceGroupName -StorageMoverName $env.StorageMoverNameWithAgent -Name $env.JobDefinitionName
        $jobDefinition.Name | Should -Be $env.JobDefinitionName
        $jobDefinition.SourceName | Should -Be $env.NfsEndpointName
        $jobDefinition.TargetName | Should -Be $env.ContainerEndpointName
        $jobDefinition.AgentName | Should -Be $env.AgentName
        $jobDefinition.CopyMode | Should -Be "Additive"
    }
}
