if(($null -eq $TestName) -or ($TestName -contains 'New-AzChangeSafetyChangeRecord'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzChangeSafetyChangeRecord.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzChangeSafetyChangeRecord' {
    It 'Create - ChangeRecord with multiple targets using -Targets' {
        {
            # Target must have either resourceId OR subscriptionId as per API spec
            $targets = @(
                @{
                    resourceId = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.ResourceGroupName)/providers/Microsoft.Compute/virtualMachines/test-vm-001"
                }
                @{
                    resourceId = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.ResourceGroupName)/providers/Microsoft.Compute/virtualMachines/test-vm-002"
                }
            )
            $result = New-AzChangeSafetyChangeRecord -Name $env.ChangeRecordName `
                -ResourceGroupName $env.ResourceGroupName `
                -Targets $targets `
                -ChangeType "AppDeployment" `
                -RolloutType "Normal"
            
            $result | Should -Not -Be $null
            $result.Name | Should -Be $env.ChangeRecordName
        } | Should -Not -Throw
    }

    It 'Create - ChangeRecord with ChangeDefinition parameters' {
        {
            # Use hardcoded deterministic name
            $recordName = "test-changerecord-changedef-01"
            
            # Must have multiple targets (API requirement)
            $changeDetail = @{
                targets = @(
                    @{
                        resourceId = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.ResourceGroupName)/providers/Microsoft.Storage/storageAccounts/teststorageacct001"
                    }
                    @{
                        resourceId = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.ResourceGroupName)/providers/Microsoft.Storage/storageAccounts/teststorageacct002"
                    }
                )
            }
            $result = New-AzChangeSafetyChangeRecord -Name $recordName `
                -ResourceGroupName $env.ResourceGroupName `
                -ChangeDefinitionKind "Targets" `
                -ChangeDefinitionName "storage-deployment" `
                -ChangeDefinitionDetail $changeDetail `
                -ChangeType "AppDeployment" `
                -RolloutType "Normal"
            
            $result | Should -Not -Be $null
            $result.Name | Should -Be $recordName
        } | Should -Not -Throw
    }

    It 'Create - ChangeRecord with StageMap for staged rollout' {
        {
            # Use hardcoded deterministic name
            $stagedRecordName = "test-changerecord-staged-01"
            
            # First ensure a StageMap exists
            $stageMapName = "stagemap-for-staged-cr-test"
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
                    resourceId = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.ResourceGroupName)/providers/Microsoft.Web/sites/test-webapp-001"
                }
                @{
                    resourceId = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.ResourceGroupName)/providers/Microsoft.Web/sites/test-webapp-002"
                }
            )
            
            # Must have time window for StageProgression to work
            $startTime = (Get-Date).AddMinutes(5)
            $endTime = (Get-Date).AddHours(2)
            
            $result = New-AzChangeSafetyChangeRecord -Name $stagedRecordName `
                -ResourceGroupName $env.ResourceGroupName `
                -Targets $targets `
                -StageMapResourceId $stagemap.Id `
                -ChangeType "AppDeployment" `
                -RolloutType "Normal" `
                -AnticipatedStartTime $startTime `
                -AnticipatedEndTime $endTime
            
            $result | Should -Not -Be $null
            $result.Name | Should -Be $stagedRecordName
            $result.StageMapResourceId | Should -Not -BeNullOrEmpty
        } | Should -Not -Throw
    }

    It 'Create - Targets marks ChangeType and RolloutType as mandatory' {
        $command = Get-Command New-AzChangeSafetyChangeRecord
        $changeTypeAttribute = $command.Parameters['ChangeType'].Attributes |
            Where-Object { $_ -is [System.Management.Automation.ParameterAttribute] -and $_.ParameterSetName -eq 'Targets' }
        $rolloutTypeAttribute = $command.Parameters['RolloutType'].Attributes |
            Where-Object { $_ -is [System.Management.Automation.ParameterAttribute] -and $_.ParameterSetName -eq 'Targets' }

        $changeTypeAttribute.Mandatory | Should -BeTrue
        $rolloutTypeAttribute.Mandatory | Should -BeTrue
    }

    It 'Create - Rejects invalid target httpMethod' {
        $message = try {
            New-AzChangeSafetyChangeRecord -Name "validation-test-record" `
                -ResourceGroupName $env.ResourceGroupName `
                -Targets @{ subscriptionId = $env.SubscriptionId; httpMethod = "BOGUS" } `
                -ChangeType "ManualTouch" `
                -RolloutType "Normal"
        } catch {
            $_.Exception.Message
        }

        $message | Should -Match "Targets\.httpMethod"
    }

    It 'Create - Rejects past anticipated windows' {
        $message = try {
            New-AzChangeSafetyChangeRecord -Name "validation-test-record" `
                -ResourceGroupName $env.ResourceGroupName `
                -Targets @{ subscriptionId = $env.SubscriptionId } `
                -ChangeType "ManualTouch" `
                -RolloutType "Normal" `
                -AnticipatedStartTime (Get-Date).AddHours(-2) `
                -AnticipatedEndTime (Get-Date).AddHours(-1)
        } catch {
            $_.Exception.Message
        }

        $message | Should -Match "AnticipatedStartTime"
    }
}
