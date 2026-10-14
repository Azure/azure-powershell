if(($null -eq $TestName) -or ($TestName -contains 'Update-AzChangeSafetyStageMap'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzChangeSafetyStageMap.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzChangeSafetyStageMap' {
    It 'Update - Add stage to existing StageMap' {
        {
            # Use hardcoded deterministic name
            $stageMapName = "test-stagemap-update-k3p8wy"
            
            # First create a StageMap to update
            $stages = @(
                @{ name = "canary"; sequence = 1 }
                @{ name = "staging"; sequence = 2 }
            )
            New-AzChangeSafetyStageMap -Name $stageMapName `
                -ResourceGroupName $env.ResourceGroupName `
                -Stage $stages -ErrorAction SilentlyContinue
            
            # Update to add a third stage
            $updatedStages = @(
                @{ name = "canary"; sequence = 1 }
                @{ name = "staging"; sequence = 2 }
                @{ name = "production"; sequence = 3 }
            )
            
            $result = Update-AzChangeSafetyStageMap -Name $stageMapName `
                -ResourceGroupName $env.ResourceGroupName `
                -Stage $updatedStages
            
            $result | Should -Not -Be $null
            $result.Stage.Count | Should -Be 3
        } | Should -Not -Throw
    }

    It 'Update - Modify stage variables' {
        {
            # Use same hardcoded name from previous test
            $stageMapName = "test-stagemap-update-k3p8wy"
            
            # Update stage variables of the existing StageMap
            $stages = @(
                @{ name = "canary"; sequence = 1 }
                @{ name = "production"; sequence = 2 }
            )
            $result = Update-AzChangeSafetyStageMap -Name $stageMapName `
                -ResourceGroupName $env.ResourceGroupName `
                -Stage $stages
            
            $result | Should -Not -Be $null
            $result.Stage.Count | Should -Be 2
        } | Should -Not -Throw
    }
}
