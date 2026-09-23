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
        Unregister-AzStorageMoverAgent -Name $env.AgentName -ResourceGroupName $env.ResourceGroupName -StorageMoverName $env.StorageMoverNameWithAgent -Force -AsJob
        $agents =  Get-AzStorageMoverAgent -ResourceGroupName $env.ResourceGroupName -StorageMoverName $env.StorageMoverNameWithAgent -Name $env.AgentName
        $agents.Name | Should -Be $env.AgentName
        Start-Sleep -Seconds 35
        $agents.AgentStatus | Should -Be "Unregistering"
        $agents.ProvisioningState | Should -Be "Deleting"
    }
}
