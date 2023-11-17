if(($null -eq $TestName) -or ($TestName -contains 'Restart-AzContainerGroup'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Restart-AzContainerGroupSpotPriority.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Restart-AzContainerGroupSpotPriority' {
    It 'Restart' {
        { Restart-AzContainerGroup -Name $env.spotContainerGroupName -ResourceGroupName $env.resourceGroupName } | Should -Not -Throw
    }

    It 'RestartViaIdentity' {
        { 
            $restart = Get-AzContainerGroup -ResourceGroupName $env.resourceGroupName -Name $env.spotContainerGroupName
            Restart-AzContainerGroup -InputObject $restart
        } | Should -Not -Throw
    }
}
