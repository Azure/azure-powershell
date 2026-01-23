if(($null -eq $TestName) -or ($TestName -contains 'Remove-AzChangeSafetyStageProgression'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzChangeSafetyStageProgression.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Remove-AzChangeSafetyStageProgression' {
    BeforeAll {
        # Use hardcoded deterministic names for recording/playback
        $script:stageMapName = "stagemap-for-remove-prog-tests"
        
        # Setup - ensure we have a StageMap
        $script:stagemap = Get-AzChangeSafetyStageMap -Name $script:stageMapName `
            -ResourceGroupName $env.ResourceGroupName -ErrorAction SilentlyContinue
        
        if (-not $script:stagemap) {
            $stages = @(
                @{ name = "canary"; sequence = 1 }
                @{ name = "production"; sequence = 2 }
            )
            $script:stagemap = New-AzChangeSafetyStageMap -Name $script:stageMapName `
                -ResourceGroupName $env.ResourceGroupName `
                -Stage $stages
        }
    }

    It 'Delete - By name' {
        {
            # Use hardcoded deterministic names - unique to avoid collisions
            $changeRecordName = "cr-remove-prog-v2"
            $progressionName = "remove-prog-v2"
            
            # MUST have: multiple targets AND AnticipatedStartTime/EndTime
            $targets = @(
                @{
                    resourceId = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.ResourceGroupName)/providers/Microsoft.Compute/virtualMachines/remove-prog-v2-vm-001"
                }
                @{
                    resourceId = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.ResourceGroupName)/providers/Microsoft.Compute/virtualMachines/remove-prog-v2-vm-002"
                }
            )
            $startTime = (Get-Date).AddMinutes(-5)
            $endTime = (Get-Date).AddHours(2)
            
            Remove-AzChangeSafetyChangeRecord -Name $changeRecordName `
                -ResourceGroupName $env.ResourceGroupName -ErrorAction SilentlyContinue
            New-AzChangeSafetyChangeRecord -Name $changeRecordName `
                -ResourceGroupName $env.ResourceGroupName `
                -Targets $targets `
                -StageMapResourceId $script:stagemap.Id `
                -AnticipatedStartTime $startTime `
                -AnticipatedEndTime $endTime
            
            New-AzChangeSafetyStageProgression -StageProgressionName $progressionName `
                -ChangeRecordName $changeRecordName `
                -ResourceGroupName $env.ResourceGroupName `
                -Status "InProgress" `
                -StageReference "canary"
            
            # Must complete/fail the StageProgression before deleting (can't delete InProgress)
            Update-AzChangeSafetyStageProgression -StageProgressionName $progressionName `
                -ChangeRecordName $changeRecordName `
                -ResourceGroupName $env.ResourceGroupName `
                -Status "Completed"
            
            # Delete the StageProgression
            Remove-AzChangeSafetyStageProgression -StageProgressionName $progressionName `
                -ChangeRecordName $changeRecordName `
                -ResourceGroupName $env.ResourceGroupName
            
            # Verify deletion
            { Get-AzChangeSafetyStageProgression -StageProgressionName $progressionName `
                -ChangeRecordName $changeRecordName `
                -ResourceGroupName $env.ResourceGroupName } | Should -Throw
            
            # Cleanup ChangeRecord - may fail if still has active state, that's ok
            Remove-AzChangeSafetyChangeRecord -Name $changeRecordName `
                -ResourceGroupName $env.ResourceGroupName -ErrorAction SilentlyContinue
        } | Should -Not -Throw
    }

    It 'Delete - Completed StageProgression' {
        {
            # Use hardcoded deterministic names
            $changeRecordName = "cr-remove-completed-prog-01"
            $progressionName = "remove-completed-prog-01"
            
            # MUST have: multiple targets AND AnticipatedStartTime/EndTime
            $targets = @(
                @{
                    resourceId = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.ResourceGroupName)/providers/Microsoft.Compute/virtualMachines/remove-comp-vm-001"
                }
                @{
                    resourceId = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.ResourceGroupName)/providers/Microsoft.Compute/virtualMachines/remove-comp-vm-002"
                }
            )
            $startTime = (Get-Date).AddMinutes(-5)
            $endTime = (Get-Date).AddHours(2)
            
            Remove-AzChangeSafetyChangeRecord -Name $changeRecordName `
                -ResourceGroupName $env.ResourceGroupName -ErrorAction SilentlyContinue
            New-AzChangeSafetyChangeRecord -Name $changeRecordName `
                -ResourceGroupName $env.ResourceGroupName `
                -Targets $targets `
                -StageMapResourceId $script:stagemap.Id `
                -AnticipatedStartTime $startTime `
                -AnticipatedEndTime $endTime
            
            New-AzChangeSafetyStageProgression -StageProgressionName $progressionName `
                -ChangeRecordName $changeRecordName `
                -ResourceGroupName $env.ResourceGroupName `
                -Status "InProgress" `
                -StageReference "canary"
            
            # Mark as completed
            Update-AzChangeSafetyStageProgression -StageProgressionName $progressionName `
                -ChangeRecordName $changeRecordName `
                -ResourceGroupName $env.ResourceGroupName `
                -Status "Completed"
            
            # Delete completed progression
            Remove-AzChangeSafetyStageProgression -StageProgressionName $progressionName `
                -ChangeRecordName $changeRecordName `
                -ResourceGroupName $env.ResourceGroupName
            
            # Note: ChangeRecord cleanup may fail if in non-terminal state - that's ok
            Remove-AzChangeSafetyChangeRecord -Name $changeRecordName `
                -ResourceGroupName $env.ResourceGroupName -ErrorAction SilentlyContinue
        } | Should -Not -Throw
    }
}
