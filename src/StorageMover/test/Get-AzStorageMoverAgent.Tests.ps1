if(($null -eq $TestName) -or ($TestName -contains 'Get-AzStorageMoverAgent'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzStorageMoverAgent.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzStorageMoverAgent' {
    It 'List' {
        $agentList = Get-AzStorageMoverAgent -ResourceGroupName $env.ResourceGroupName -StorageMoverName $env.StorageMoverNameWithAgent
        $agentList.Count | Should -BeGreaterOrEqual 1 
    }

    It 'Get' {
        $agent =  Get-AzStorageMoverAgent -ResourceGroupName $env.ResourceGroupName -StorageMoverName $env.StorageMoverNameWithAgent -Name $env.AgentName
        $agent.Name | Should -Be $env.AgentName
    }
}
