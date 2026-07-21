if(($null -eq $TestName) -or ($TestName -contains 'New-AzChangeSafetyStageProgression'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzChangeSafetyStageProgression.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzChangeSafetyStageProgression' {
    # Setup: Need a StageMap and ChangeRecord with proper time window for StageProgression to work
    
    BeforeAll {
        # Use hardcoded deterministic names for recording/playback - unique for this test file
        $script:stageMapName = "sm-new-prog-file"
        $script:changeRecordName = "cr-new-prog-file"
        
        # Cleanup first to ensure clean state
        Remove-AzChangeSafetyChangeRecord -Name $script:changeRecordName `
            -ResourceGroupName $env.ResourceGroupName -ErrorAction SilentlyContinue
        
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
        
        # MUST have: multiple targets AND AnticipatedStartTime/EndTime for StageProgression to work
        $targets = @(
            @{
                resourceId = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.ResourceGroupName)/providers/Microsoft.Compute/virtualMachines/new-prog-file-vm-001"
            }
            @{
                resourceId = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.ResourceGroupName)/providers/Microsoft.Compute/virtualMachines/new-prog-file-vm-002"
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
    
    It 'Create - Start InProgress StageProgression' {
        {
            $progressionName = "prog-new-inprogress"
            
            # Cleanup any leftover
            Remove-AzChangeSafetyStageProgression -StageProgressionName $progressionName `
                -ChangeRecordName $script:changeRecordName `
                -ResourceGroupName $env.ResourceGroupName -ErrorAction SilentlyContinue
            
            # Create StageProgression with InProgress status
            $result = New-AzChangeSafetyStageProgression -StageProgressionName $progressionName `
                -ChangeRecordName $script:changeRecordName `
                -ResourceGroupName $env.ResourceGroupName `
                -Status "InProgress" `
                -StageReference "canary"
            
            $result | Should -Not -Be $null
            $result.Status | Should -Be "InProgress"
            
            # Cleanup - must complete or fail before removing
            Update-AzChangeSafetyStageProgression -StageProgressionName $progressionName `
                -ChangeRecordName $script:changeRecordName `
                -ResourceGroupName $env.ResourceGroupName `
                -Status "Completed" -ErrorAction SilentlyContinue
            Remove-AzChangeSafetyStageProgression -StageProgressionName $progressionName `
                -ChangeRecordName $script:changeRecordName `
                -ResourceGroupName $env.ResourceGroupName -ErrorAction SilentlyContinue
        } | Should -Not -Throw
    }

    It 'Create - StageProgression and complete it' {
        {
            $progressionName = "prog-new-complete"
            
            # Cleanup any leftover
            Remove-AzChangeSafetyStageProgression -StageProgressionName $progressionName `
                -ChangeRecordName $script:changeRecordName `
                -ResourceGroupName $env.ResourceGroupName -ErrorAction SilentlyContinue
            
            $progression = New-AzChangeSafetyStageProgression -StageProgressionName $progressionName `
                -ChangeRecordName $script:changeRecordName `
                -ResourceGroupName $env.ResourceGroupName `
                -Status "InProgress" `
                -StageReference "canary"
            
            $progression | Should -Not -Be $null
            
            # Update to Completed
            $completed = Update-AzChangeSafetyStageProgression -StageProgressionName $progressionName `
                -ChangeRecordName $script:changeRecordName `
                -ResourceGroupName $env.ResourceGroupName `
                -Status "Completed"
            
            $completed | Should -Not -Be $null
            $completed.Status | Should -Be "Completed"
            
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
