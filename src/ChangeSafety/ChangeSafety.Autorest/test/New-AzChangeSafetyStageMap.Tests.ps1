if(($null -eq $TestName) -or ($TestName -contains 'New-AzChangeSafetyStageMap'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzChangeSafetyStageMap.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzChangeSafetyStageMap' {
    It 'CreateExpanded - Simple two-stage map' {
        {
            $stages = @(
                @{ name = "canary"; sequence = 1 },
                @{ name = "production"; sequence = 2 }
            )
            $result = New-AzChangeSafetyStageMap -Name $env.StageMapName `
                -ResourceGroupName $env.ResourceGroupName `
                -Stage $stages
            $result | Should -Not -Be $null
            $result.Name | Should -Be $env.StageMapName
            $result.ProvisioningState | Should -Be "Succeeded"
        } | Should -Not -Throw
    }

    It 'CreateExpanded - StageMap with stage variables' {
        {
            $stages = @(
                @{ 
                    name = "firstBatch"
                    sequence = 1
                    stageVariables = @{
                        locations = "[eastus]"
                        replicas = 1
                    }
                },
                @{ 
                    name = "secondBatch"
                    sequence = 2
                    stageVariables = @{
                        locations = "[eastus,westus]"
                        replicas = 2
                    }
                },
                @{ 
                    name = "all"
                    sequence = 3
                    stageVariables = @{
                        locations = "[]"
                        replicas = 3
                    }
                }
            )
            $result = New-AzChangeSafetyStageMap -Name "$($env.StageMapName)-batches" `
                -ResourceGroupName $env.ResourceGroupName `
                -Stage $stages
            $result | Should -Not -Be $null
            $result.ProvisioningState | Should -Be "Succeeded"
        } | Should -Not -Throw
    }

    It 'CreateExpanded - StageMap with nested reference' {
        {
            $subscriptionId = (Get-AzContext).Subscription.Id
            $stages = @(
                @{ 
                    name = "auditStage"
                    sequence = 1
                    stageVariables = @{
                        enforcementMode = "default"
                        effect = "audit"
                    }
                    nestedStageMap = @{
                        resourceId = "/subscriptions/$subscriptionId/resourceGroups/$($env.ResourceGroupName)/providers/Microsoft.ChangeSafety/stageMaps/$($env.StageMapName)-batches"
                    }
                },
                @{ 
                    name = "enforceStage"
                    sequence = 2
                    stageVariables = @{
                        enforcementMode = "default"
                        effect = "deny"
                    }
                }
            )
            $result = New-AzChangeSafetyStageMap -Name $env.StageMapNameNested `
                -ResourceGroupName $env.ResourceGroupName `
                -Stage $stages
            $result | Should -Not -Be $null
            $result.ProvisioningState | Should -Be "Succeeded"
        } | Should -Not -Throw
    }
}
