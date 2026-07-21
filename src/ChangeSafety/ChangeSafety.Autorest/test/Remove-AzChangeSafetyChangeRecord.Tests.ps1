if(($null -eq $TestName) -or ($TestName -contains 'Remove-AzChangeSafetyChangeRecord'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzChangeSafetyChangeRecord.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Remove-AzChangeSafetyChangeRecord' {
    It 'Delete - By name' {
        {
            # Use hardcoded deterministic name
            $changeRecordName = "test-changerecord-delete-r9t4jl"
            
            # Create a ChangeRecord to delete
            # API requires multiple targets based on working New-ChangeRecord test
            $targets = @(
                @{
                    resourceId = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.ResourceGroupName)/providers/Microsoft.Compute/virtualMachines/delete-test-vm-001"
                }
                @{
                    resourceId = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.ResourceGroupName)/providers/Microsoft.Compute/virtualMachines/delete-test-vm-002"
                }
            )
            
            New-AzChangeSafetyChangeRecord -Name $changeRecordName `
                -ResourceGroupName $env.ResourceGroupName `
                -Targets $targets
            
            # Delete it
            Remove-AzChangeSafetyChangeRecord -Name $changeRecordName `
                -ResourceGroupName $env.ResourceGroupName
            
            # Verify deletion - should throw
            { Get-AzChangeSafetyChangeRecord -Name $changeRecordName `
                -ResourceGroupName $env.ResourceGroupName } | Should -Throw
        } | Should -Not -Throw
    }

    It 'Delete - ChangeRecord with StageMap reference' {
        {
            # Hardcoded deterministic name for recording/playback
            $changeRecordName = "test-changerecord-staged-delete-01"
            
            # Create StageMap if needed
            $stageMapName = "stagemap-for-delete-test"
            $stagemap = Get-AzChangeSafetyStageMap -Name $stageMapName `
                -ResourceGroupName $env.ResourceGroupName -ErrorAction SilentlyContinue
            
            if (-not $stagemap) {
                $stages = @(
                    @{ name = "canary"; sequence = 1 }
                    @{ name = "production"; sequence = 2 }
                )
                $stagemap = New-AzChangeSafetyStageMap -Name $stageMapName `
                    -ResourceGroupName $env.ResourceGroupName `
                    -Stage $stages
            }
            
            # Must have multiple targets (API requirement)
            $targets = @(
                @{
                    resourceId = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.ResourceGroupName)/providers/Microsoft.Storage/storageAccounts/deleteteststorage001"
                }
                @{
                    resourceId = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.ResourceGroupName)/providers/Microsoft.Storage/storageAccounts/deleteteststorage002"
                }
            )
            
            # Create ChangeRecord with StageMap
            $startTime = (Get-Date).AddMinutes(-5)
            $endTime = (Get-Date).AddHours(2)
            
            $cr = New-AzChangeSafetyChangeRecord -Name $changeRecordName `
                -ResourceGroupName $env.ResourceGroupName `
                -Targets $targets `
                -StageMapResourceId $stagemap.Id `
                -AnticipatedStartTime $startTime `
                -AnticipatedEndTime $endTime
            
            $cr | Should -Not -Be $null
            
            # Delete the staged ChangeRecord
            Remove-AzChangeSafetyChangeRecord -Name $changeRecordName `
                -ResourceGroupName $env.ResourceGroupName
            
            # Verify deletion
            { Get-AzChangeSafetyChangeRecord -Name $changeRecordName `
                -ResourceGroupName $env.ResourceGroupName } | Should -Throw
        } | Should -Not -Throw
    }
}
