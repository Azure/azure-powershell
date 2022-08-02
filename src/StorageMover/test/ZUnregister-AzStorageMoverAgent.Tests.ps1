if(($null -eq $TestName) -or ($TestName -contains 'Unregister-AzStorageMoverAgent'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Unregister-AzStorageMoverAgent.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Unregister-AzStorageMoverAgent' {
    It 'Delete' {
        Unregister-AzStorageMoverAgent -Name $env.AgentName -ResourceGroupName $env.ResourceGroupName -StorageMoverName $env.StorageMoverNameWithAgent -Force
        $agents =  Get-AzStorageMoverAgent -ResourceGroupName $env.ResourceGroupName -StorageMoverName $env.StorageMoverNameWithAgent
        $agents.Name | Should -Not -Contain $env.AgentName
    }
}
