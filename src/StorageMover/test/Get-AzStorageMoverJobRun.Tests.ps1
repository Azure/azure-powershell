if(($null -eq $TestName) -or ($TestName -contains 'Get-AzStorageMoverJobRun'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzStorageMoverJobRun.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzStorageMoverJobRun' {
    BeforeAll {
        $job = Start-AzStorageMoverJobDefinition -JobDefinitionName $env.JobDefinitionName -ProjectName $env.ProjectName -ResourceGroupName $env.ResourceGroupName -StorageMoverName $env.StorageMoverNameWithAgent
    }

    It 'List' {
        $jobRunList = Get-AzStorageMoverJobRun -JobDefinitionName $env.JobDefinitionName -ResourceGroupName $env.ResourceGroupName -StorageMoverName $env.StorageMoverNameWithAgent -ProjectName $env.ProjectName
        $jobRunList.Count | Should -BeGreaterOrEqual 1
    }

    It 'Get' {
        $jobRunName = $job.Split("/")[-1]
        $jobRun = Get-AzStorageMoverJobRun -Name $jobRunName -JobDefinitionName $env.JobDefinitionName -ResourceGroupName $env.ResourceGroupName -StorageMoverName $env.StorageMoverNameWithAgent -ProjectName $env.ProjectName
        $jobRun.AgentName | Should -Be $env.AgentName 
        $jobRun.SourceName | Should -Be $env.NfsEndpointName 
        $jobRun.TargetName | Should -Be $env.ContainerEndpointName
        $jobRun.Name | SHould -Be $jobRunName
    }
}
