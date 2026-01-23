if(($null -eq $TestName) -or ($TestName -contains 'Remove-AzChangeSafetyStageMap'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzChangeSafetyStageMap.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Remove-AzChangeSafetyStageMap' {
    It 'Delete - By name' {
        {
            # Use hardcoded deterministic name
            $stageMapName = "test-stagemap-delete-x7m2nq"
            
            # Create a StageMap to delete
            $stages = @(
                @{ name = "stage1"; sequence = 1 }
            )
            
            New-AzChangeSafetyStageMap -Name $stageMapName `
                -ResourceGroupName $env.ResourceGroupName `
                -Stage $stages
            
            # Delete it
            Remove-AzChangeSafetyStageMap -Name $stageMapName `
                -ResourceGroupName $env.ResourceGroupName
            
            # Verify deletion - Get should throw
            { Get-AzChangeSafetyStageMap -Name $stageMapName `
                -ResourceGroupName $env.ResourceGroupName } | Should -Throw
        } | Should -Not -Throw
    }
}
