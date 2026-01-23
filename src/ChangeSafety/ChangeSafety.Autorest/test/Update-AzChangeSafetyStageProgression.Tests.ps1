if(($null -eq $TestName) -or ($TestName -contains 'Update-AzChangeSafetyStageProgression'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzChangeSafetyStageProgression.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzChangeSafetyStageProgression' {
    BeforeAll {
        # Use hardcoded deterministic names for recording/playback - unique for this file
        $script:stageMapName = "sm-update-prog-file-v5"
        $script:changeRecordName = "cr-update-prog-file-v5"
        
        # Cleanup first to ensure clean state
        Remove-AzChangeSafetyChangeRecord -Name $script:changeRecordName `
            -ResourceGroupName $env.ResourceGroupName -ErrorAction SilentlyContinue
        
        # Force recreate StageMap to ensure it has correct stages
        Remove-AzChangeSafetyStageMap -Name $script:stageMapName `
            -ResourceGroupName $env.ResourceGroupName -ErrorAction SilentlyContinue
        
        $stages = @(
            @{ name = "canary"; sequence = 1 }
            @{ name = "production"; sequence = 2 }
        )
        $script:stagemap = New-AzChangeSafetyStageMap -Name $script:stageMapName `
            -ResourceGroupName $env.ResourceGroupName `
            -Stage $stages
        
        # MUST have: multiple targets AND AnticipatedStartTime/EndTime for StageProgression to work
        $targets = @(
            @{
                resourceId = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.ResourceGroupName)/providers/Microsoft.Compute/virtualMachines/update-prog-v5-vm-001"
            }
            @{
                resourceId = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.ResourceGroupName)/providers/Microsoft.Compute/virtualMachines/update-prog-v5-vm-002"
            }
        )
        $startTime = (Get-Date).AddMinutes(-5)
        $endTime = (Get-Date).AddHours(2)
        
        $script:changeRecord = New-AzChangeSafetyChangeRecord -Name $script:changeRecordName `
            -ResourceGroupName $env.ResourceGroupName `
            -Targets $targets `
            -StageMapResourceId $script:stagemap.Id `
            -AnticipatedStartTime $startTime `
            -AnticipatedEndTime $endTime
    }

    It 'Update - Transition from InProgress to Completed' {
        {
            $progressionName = "update-complete-prog-v2"
            New-AzChangeSafetyStageProgression -StageProgressionName $progressionName `
                -ChangeRecordName $script:changeRecordName `
                -ResourceGroupName $env.ResourceGroupName `
                -Status "InProgress" `
                -StageReference "canary"
            
            # Update to Completed
            $result = Update-AzChangeSafetyStageProgression -StageProgressionName $progressionName `
                -ChangeRecordName $script:changeRecordName `
                -ResourceGroupName $env.ResourceGroupName `
                -Status "Completed"
            
            $result | Should -Not -Be $null
            $result.Status | Should -Be "Completed"
            
            # Cleanup
            Remove-AzChangeSafetyStageProgression -StageProgressionName $progressionName `
                -ChangeRecordName $script:changeRecordName `
                -ResourceGroupName $env.ResourceGroupName -ErrorAction SilentlyContinue
        } | Should -Not -Throw
    }

    It 'Update - Set to Failed status' {
        {
            # Use a different stage (but it must exist in the StageMap)
            # The StageMap has stages: canary (seq 1), production (seq 2)
            $progressionName = "test-progression-fail-01"
            
            # Clean up any leftover progression
            Remove-AzChangeSafetyStageProgression -StageProgressionName $progressionName `
                -ChangeRecordName $script:changeRecordName `
                -ResourceGroupName $env.ResourceGroupName -ErrorAction SilentlyContinue
            
            New-AzChangeSafetyStageProgression -StageProgressionName $progressionName `
                -ChangeRecordName $script:changeRecordName `
                -ResourceGroupName $env.ResourceGroupName `
                -Status "InProgress" `
                -StageReference "canary"
            
            # Update to Failed
            $result = Update-AzChangeSafetyStageProgression -StageProgressionName $progressionName `
                -ChangeRecordName $script:changeRecordName `
                -ResourceGroupName $env.ResourceGroupName `
                -Status "Failed"
            
            $result | Should -Not -Be $null
            $result.Status | Should -Be "Failed"
            
            # Cleanup
            Remove-AzChangeSafetyStageProgression -StageProgressionName $progressionName `
                -ChangeRecordName $script:changeRecordName `
                -ResourceGroupName $env.ResourceGroupName -ErrorAction SilentlyContinue
        } | Should -Not -Throw
    }

    AfterAll {
        # Cleanup ChangeRecord
        Remove-AzChangeSafetyChangeRecord -Name $script:changeRecordName `
            -ResourceGroupName $env.ResourceGroupName -ErrorAction SilentlyContinue
    }
}
