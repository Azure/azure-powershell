if(($null -eq $TestName) -or ($TestName -contains 'Get-AzChangeSafetyStageProgression'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzChangeSafetyStageProgression.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzChangeSafetyStageProgression' {
    BeforeAll {
        # Use hardcoded deterministic names for recording/playback
        $script:stageMapName = "stagemap-for-get-prog-tests"
        $script:changeRecordName = "cr-get-progression-tests"
        $script:progressionName = "get-progression-test-01"
        
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
                resourceId = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.ResourceGroupName)/providers/Microsoft.Compute/virtualMachines/get-prog-vm-001"
            }
            @{
                resourceId = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.ResourceGroupName)/providers/Microsoft.Compute/virtualMachines/get-prog-vm-002"
            }
        )
        $startTime = (Get-Date).AddMinutes(-5)
        $endTime = (Get-Date).AddHours(2)
        
        # Clean up and create fresh ChangeRecord
        Remove-AzChangeSafetyChangeRecord -Name $script:changeRecordName `
            -ResourceGroupName $env.ResourceGroupName -ErrorAction SilentlyContinue
        $script:changeRecord = New-AzChangeSafetyChangeRecord -Name $script:changeRecordName `
            -ResourceGroupName $env.ResourceGroupName `
            -Targets $targets `
            -StageMapResourceId $script:stagemap.Id `
            -AnticipatedStartTime $startTime `
            -AnticipatedEndTime $endTime
        
        # Create a progression for testing
        New-AzChangeSafetyStageProgression -StageProgressionName $script:progressionName `
            -ChangeRecordName $script:changeRecordName `
            -ResourceGroupName $env.ResourceGroupName `
            -Status "InProgress" `
            -StageReference "canary" -ErrorAction SilentlyContinue
    }

    It 'Get - By name' {
        {
            $result = Get-AzChangeSafetyStageProgression -StageProgressionName $script:progressionName `
                -ChangeRecordName $script:changeRecordName `
                -ResourceGroupName $env.ResourceGroupName
            
            $result | Should -Not -Be $null
            $result.Name | Should -Be $script:progressionName
        } | Should -Not -Throw
    }

    It 'List - All progressions for a ChangeRecord' {
        {
            $result = Get-AzChangeSafetyStageProgression `
                -ChangeRecordName $script:changeRecordName `
                -ResourceGroupName $env.ResourceGroupName
            
            $result | Should -Not -Be $null
        } | Should -Not -Throw
    }

    AfterAll {
        # Cleanup
        Remove-AzChangeSafetyStageProgression -StageProgressionName $script:progressionName `
            -ChangeRecordName $script:changeRecordName `
            -ResourceGroupName $env.ResourceGroupName -ErrorAction SilentlyContinue
        Remove-AzChangeSafetyChangeRecord -Name $script:changeRecordName `
            -ResourceGroupName $env.ResourceGroupName -ErrorAction SilentlyContinue
    }
}
