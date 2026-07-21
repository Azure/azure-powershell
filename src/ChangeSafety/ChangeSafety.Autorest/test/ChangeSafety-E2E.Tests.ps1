if(($null -eq $TestName) -or ($TestName -contains 'ChangeSafety-E2E'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'ChangeSafety-E2E.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

# E2E tests are skipped by default as they require live Azure interaction
# They use Get-Random for resource names which won't match recordings in playback mode
# To run these tests, use -Record mode: .\test-module.ps1 -Record

# Skip entire E2E file - these tests are for manual verification only
# They use Get-Random which makes recordings unreproducible
return

Describe 'ChangeSafety E2E - Stageless Flow' {
    # Simple flow: ChangeRecord without stage maps
    # Based on gasoE2E.http test flow
    
    BeforeAll {
        $script:stagelessChangeRecord = "stageless-e2e-" + (Get-Random)
    }
    
    AfterAll {
        # Cleanup
        Remove-AzChangeSafetyChangeRecord -Name $script:stagelessChangeRecord `
            -ResourceGroupName $env.ResourceGroupName -ErrorAction SilentlyContinue
    }
    
    It 'Step 1: Create stageless ChangeRecord' {
        # Target must have either resourceId OR subscriptionId per API spec
        $targets = @(
            @{
                resourceId = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.ResourceGroupName)/providers/Microsoft.Compute/virtualMachines/e2e-vm-001"
            }
            @{
                resourceId = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.ResourceGroupName)/providers/Microsoft.Compute/virtualMachines/e2e-vm-002"
            }
        )
        
        $result = New-AzChangeSafetyChangeRecord -Name $script:stagelessChangeRecord `
            -ResourceGroupName $env.ResourceGroupName `
            -Targets $targets
        
        $result | Should -Not -Be $null
        $result.Name | Should -Be $script:stagelessChangeRecord
    }
    
    It 'Step 2: Verify ChangeRecord was created' {
        $result = Get-AzChangeSafetyChangeRecord -Name $script:stagelessChangeRecord `
            -ResourceGroupName $env.ResourceGroupName
        
        $result | Should -Not -Be $null
        $result.Name | Should -Be $script:stagelessChangeRecord
    }
    
    It 'Step 3: Update ChangeRecord with additional target' {
        $targets = @(
            @{
                resourceId = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.ResourceGroupName)/providers/Microsoft.Compute/virtualMachines/e2e-vm-001"
            }
            @{
                resourceId = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.ResourceGroupName)/providers/Microsoft.Compute/virtualMachines/e2e-vm-002"
            }
            @{
                resourceId = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.ResourceGroupName)/providers/Microsoft.Compute/virtualMachines/e2e-vm-003"
            }
        )
        
        $result = Update-AzChangeSafetyChangeRecord -Name $script:stagelessChangeRecord `
            -ResourceGroupName $env.ResourceGroupName `
            -Targets $targets
        
        $result | Should -Not -Be $null
    }
    
    It 'Step 4: Delete ChangeRecord' {
        Remove-AzChangeSafetyChangeRecord -Name $script:stagelessChangeRecord `
            -ResourceGroupName $env.ResourceGroupName
        
        # Verify deletion
        { Get-AzChangeSafetyChangeRecord -Name $script:stagelessChangeRecord `
            -ResourceGroupName $env.ResourceGroupName } | Should -Throw
    }
}

Describe 'ChangeSafety E2E - Staged Rollout Flow' {
    # Complex flow: ChangeRecord with StageMap and StageProgressions
    # Based on gasoE2E.http and retrieveNextStagesBug.http test flows
    
    BeforeAll {
        $script:stageMapName = "e2e-stagemap-" + (Get-Random)
        $script:stagedChangeRecord = "staged-e2e-" + (Get-Random)
        $script:stageProgressionCanary = "canary-prog-" + (Get-Random)
        $script:stageProgressionProd = "prod-prog-" + (Get-Random)
    }
    
    AfterAll {
        # Cleanup in reverse order
        Remove-AzChangeSafetyStageProgression -StageProgressionName $script:stageProgressionProd `
            -ChangeRecordName $script:stagedChangeRecord `
            -ResourceGroupName $env.ResourceGroupName -ErrorAction SilentlyContinue
        Remove-AzChangeSafetyStageProgression -StageProgressionName $script:stageProgressionCanary `
            -ChangeRecordName $script:stagedChangeRecord `
            -ResourceGroupName $env.ResourceGroupName -ErrorAction SilentlyContinue
        Remove-AzChangeSafetyChangeRecord -Name $script:stagedChangeRecord `
            -ResourceGroupName $env.ResourceGroupName -ErrorAction SilentlyContinue
        Remove-AzChangeSafetyStageMap -Name $script:stageMapName `
            -ResourceGroupName $env.ResourceGroupName -ErrorAction SilentlyContinue
    }
    
    It 'Step 1: Create StageMap with two stages' {
        $stages = @(
            @{ 
                name = "canary"
                sequence = 1
                description = "Canary deployment - 5% of traffic"
            }
            @{
                name = "production"
                sequence = 2
                description = "Production deployment - 100% of traffic"
            }
        )
        
        $result = New-AzChangeSafetyStageMap -Name $script:stageMapName `
            -ResourceGroupName $env.ResourceGroupName `
            -Stage $stages
        
        $result | Should -Not -Be $null
        $result.Name | Should -Be $script:stageMapName
        
        $script:stageMapId = $result.Id
    }
    
    It 'Step 2: Create ChangeRecord with StageMap reference' {
        $targets = @(
            @{
                resourceId = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.ResourceGroupName)/providers/Microsoft.Compute/virtualMachines/staged-vm-001"
            }
        )
        
        $result = New-AzChangeSafetyChangeRecord -Name $script:stagedChangeRecord `
            -ResourceGroupName $env.ResourceGroupName `
            -Targets $targets `
            -StageMapResourceId $script:stageMapId
        
        $result | Should -Not -Be $null
    }
    
    It 'Step 3: Start canary stage - Create InProgress StageProgression' {
        $result = New-AzChangeSafetyStageProgression -StageProgressionName $script:stageProgressionCanary `
            -ChangeRecordName $script:stagedChangeRecord `
            -ResourceGroupName $env.ResourceGroupName `
            -Status "InProgress" `
            -StageReference "canary"
        
        $result | Should -Not -Be $null
    }
    
    It 'Step 4: Complete canary stage' {
        $result = Update-AzChangeSafetyStageProgression -StageProgressionName $script:stageProgressionCanary `
            -ChangeRecordName $script:stagedChangeRecord `
            -ResourceGroupName $env.ResourceGroupName `
            -Status "Completed"
        
        $result | Should -Not -Be $null
    }
    
    It 'Step 5: Start production stage' {
        $result = New-AzChangeSafetyStageProgression -StageProgressionName $script:stageProgressionProd `
            -ChangeRecordName $script:stagedChangeRecord `
            -ResourceGroupName $env.ResourceGroupName `
            -Status "InProgress" `
            -StageReference "production"
        
        $result | Should -Not -Be $null
    }
    
    It 'Step 6: List all StageProgressions for ChangeRecord' {
        $result = Get-AzChangeSafetyStageProgression `
            -ChangeRecordName $script:stagedChangeRecord `
            -ResourceGroupName $env.ResourceGroupName
        
        $result.Count | Should -BeGreaterOrEqual 2
    }
    
    It 'Step 7: Complete production stage' {
        $result = Update-AzChangeSafetyStageProgression -StageProgressionName $script:stageProgressionProd `
            -ChangeRecordName $script:stagedChangeRecord `
            -ResourceGroupName $env.ResourceGroupName `
            -Status "Completed"
        
        $result | Should -Not -Be $null
    }
    
    It 'Step 8: Cleanup - Delete StageProgressions' {
        Remove-AzChangeSafetyStageProgression -StageProgressionName $script:stageProgressionProd `
            -ChangeRecordName $script:stagedChangeRecord `
            -ResourceGroupName $env.ResourceGroupName
        
        Remove-AzChangeSafetyStageProgression -StageProgressionName $script:stageProgressionCanary `
            -ChangeRecordName $script:stagedChangeRecord `
            -ResourceGroupName $env.ResourceGroupName
    }
    
    It 'Step 9: Cleanup - Delete ChangeRecord' {
        Remove-AzChangeSafetyChangeRecord -Name $script:stagedChangeRecord `
            -ResourceGroupName $env.ResourceGroupName
    }
    
    It 'Step 10: Cleanup - Delete StageMap' {
        Remove-AzChangeSafetyStageMap -Name $script:stageMapName `
            -ResourceGroupName $env.ResourceGroupName
    }
}

Describe 'ChangeSafety E2E - Nested StageMap Flow' {
    # Advanced flow: Nested StageMaps with references
    # Based on retrieveNextStagesBug.http test flow
    
    BeforeAll {
        $script:leafStageMap = "leaf-stagemap-" + (Get-Random)
        $script:midStageMap = "mid-stagemap-" + (Get-Random)
        $script:rootStageMap = "root-stagemap-" + (Get-Random)
        $script:nestedChangeRecord = "nested-e2e-" + (Get-Random)
    }
    
    AfterAll {
        # Cleanup in dependency order
        Remove-AzChangeSafetyChangeRecord -Name $script:nestedChangeRecord `
            -ResourceGroupName $env.ResourceGroupName -ErrorAction SilentlyContinue
        Remove-AzChangeSafetyStageMap -Name $script:rootStageMap `
            -ResourceGroupName $env.ResourceGroupName -ErrorAction SilentlyContinue
        Remove-AzChangeSafetyStageMap -Name $script:midStageMap `
            -ResourceGroupName $env.ResourceGroupName -ErrorAction SilentlyContinue
        Remove-AzChangeSafetyStageMap -Name $script:leafStageMap `
            -ResourceGroupName $env.ResourceGroupName -ErrorAction SilentlyContinue
    }
    
    It 'Step 1: Create leaf StageMap (innermost)' {
        $stages = @(
            @{ name = "leaf-stage-1"; sequence = 1 }
            @{ name = "leaf-stage-2"; sequence = 2 }
        )
        
        $result = New-AzChangeSafetyStageMap -Name $script:leafStageMap `
            -ResourceGroupName $env.ResourceGroupName `
            -Stage $stages
        
        $result | Should -Not -Be $null
        $script:leafStageMapId = $result.Id
    }
    
    It 'Step 2: Create mid StageMap (references leaf)' {
        $stages = @(
            @{ name = "mid-stage-1"; sequence = 1 }
            @{ 
                name = "mid-nested"
                sequence = 2
                stageMapId = $script:leafStageMapId
            }
            @{ name = "mid-stage-2"; sequence = 3 }
        )
        
        $result = New-AzChangeSafetyStageMap -Name $script:midStageMap `
            -ResourceGroupName $env.ResourceGroupName `
            -Stage $stages
        
        $result | Should -Not -Be $null
        $script:midStageMapId = $result.Id
    }
    
    It 'Step 3: Create root StageMap (references mid)' {
        $stages = @(
            @{ name = "canary"; sequence = 1 }
            @{ 
                name = "regional-rollout"
                sequence = 2
                stageMapId = $script:midStageMapId
            }
            @{ name = "global"; sequence = 3 }
        )
        
        $result = New-AzChangeSafetyStageMap -Name $script:rootStageMap `
            -ResourceGroupName $env.ResourceGroupName `
            -Stage $stages
        
        $result | Should -Not -Be $null
        $script:rootStageMapId = $result.Id
    }
    
    It 'Step 4: Create ChangeRecord with nested StageMap' {
        $targets = @(
            @{
                resourceId = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.ResourceGroupName)/providers/Microsoft.Compute/virtualMachines/nested-vm-001"
            }
        )
        
        $result = New-AzChangeSafetyChangeRecord -Name $script:nestedChangeRecord `
            -ResourceGroupName $env.ResourceGroupName `
            -Targets $targets `
            -StageMapResourceId $script:rootStageMapId
        
        $result | Should -Not -Be $null
    }
    
    It 'Step 5: Retrieve and verify nested StageMap structure' {
        $result = Get-AzChangeSafetyStageMap -Name $script:rootStageMap `
            -ResourceGroupName $env.ResourceGroupName
        
        $result | Should -Not -Be $null
    }
    
    It 'Step 6: Cleanup' {
        Remove-AzChangeSafetyChangeRecord -Name $script:nestedChangeRecord `
            -ResourceGroupName $env.ResourceGroupName
        
        Remove-AzChangeSafetyStageMap -Name $script:rootStageMap `
            -ResourceGroupName $env.ResourceGroupName
        
        Remove-AzChangeSafetyStageMap -Name $script:midStageMap `
            -ResourceGroupName $env.ResourceGroupName
        
        Remove-AzChangeSafetyStageMap -Name $script:leafStageMap `
            -ResourceGroupName $env.ResourceGroupName
    }
}
