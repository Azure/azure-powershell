if (($null -eq $TestName) -or ($TestName -contains 'AzChaosExperiment')) {
    $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
    if (-Not (Test-Path -Path $loadEnvPath)) {
        $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
    }
    . ($loadEnvPath)
    $TestRecordingFile = Join-Path $PSScriptRoot 'AzChaosExperiment.Recording.json'
    $currentPath = $PSScriptRoot
    while (-not $mockingPath) {
        $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
        $currentPath = Split-Path -Path $currentPath -Parent
    }
    . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'AzChaosExperiment' {
    It 'NewAzChaosExperiment-CreateViaJsonString' {
        {
            $jsonStr = '
            {
                "location": "eastus",
                "identity": {
                    "type": "SystemAssigned"
                },
                "properties": {
                    "steps": [
                        {
                            "name": "step1",
                            "branches": [
                                {
                                    "name": "branch1",
                                    "actions": [
                                        {
                                            "type": "continuous",
                                            "name": "urn:csci:microsoft:virtualMachine:shutdown/1.0",
                                            "selectorId": "selector1",
                                            "duration": "PT10M",
                                            "parameters": [
                                                {
                                                    "key": "abruptShutdown",
                                                    "value": "false"
                                                }
                                            ]
                                        }
                                    ]
                                }
                            ]
                        }
                    ],
                    "selectors": [
                        {
                            "type": "List",
                            "id": "selector1",
                            "targets": [
                                {
                                    "type": "ChaosTarget",
                                    "id": "/subscriptions/' + $env.SubscriptionId + '/resourceGroups/' + $env.resourceGroup + '/providers/Microsoft.Compute/virtualMachines/' + $env.virtualMachine2 + '/providers/Microsoft.Chaos/targets/' + $env.targetName2 + '"
                                }
                            ]
                        }
                    ]
                }
            }'

            $config = New-AzChaosExperiment -Name $env.experimentName2 -ResourceGroupName $env.resourceGroup -JsonString $jsonStr
            $config.Name | Should -Be $env.experimentName2
        } | Should -Not -Throw
    }

    It 'GetAzChaosExperiment-List' {
        {
            $config = Get-AzChaosExperiment
            $config.Count | Should -BeGreaterThan 0
        } | Should -Not -Throw
    }

    It 'GetAzChaosExperiment-List1' {
        {
            $config = Get-AzChaosExperiment -ResourceGroupName $env.resourceGroup
            $config.Count | Should -BeGreaterThan 0
        } | Should -Not -Throw
    }

    It 'GetAzChaosExperiment-Get' {
        {
            $config = Get-AzChaosExperiment -ResourceGroupName $env.resourceGroup -Name $env.experimentName2
            $config.Name | Should -Be $env.experimentName2
        } | Should -Not -Throw
    }

    It 'StartAzChaosExperiment-Start' {
        {
            $config = Start-AzChaosExperiment -ResourceGroupName $env.resourceGroup -Name $env.experimentName1
            $config.Name | Should -Be $env.experimentName1
        } | Should -Not -Throw
    }

    It 'GetAzChaosExperimentExecution-List' {
        {
            $config = Get-AzChaosExperimentExecution -ResourceGroupName $env.resourceGroup -ExperimentName $env.experimentName1
            $config.Count | Should -BeGreaterThan 0
        } | Should -Not -Throw
    }

    It 'GetAzChaosExperimentExecution-Get' {
        {
            $config = Get-AzChaosExperimentExecution -ResourceGroupName $env.resourceGroup -ExperimentName $env.experimentName1 -ExecutionId $env.executionId
            $config.Name | Should -Be $env.executionId
        } | Should -Not -Throw
    }

    It 'GetAzChaosExecutionExperimentDetail-Execution' {
        {
            $config = Get-AzChaosExecutionExperimentDetail -ResourceGroupName $env.resourceGroup -ExperimentName $env.experimentName1 -ExecutionId $env.executionId
            $config.Name | Should -Be $env.executionId
        } | Should -Not -Throw
    }

    It 'StopAzChaosExperiment-Cancel' {
        {
            $config = Stop-AzChaosExperiment -ResourceGroupName $env.resourceGroup -Name $env.experimentName1
            $config.Count | Should -BeGreaterThan 0
        } | Should -Not -Throw
    }

    It 'UpdateAzChaosExperiment-UpdateExpanded' {
        {
            $config = Update-AzChaosExperiment -ResourceGroupName $env.resourceGroup -Name $env.experimentName2 -Location $env.location -Tag @{"a" = "1" }
            $config.Name | Should -Be $env.experimentName2
        } | Should -Not -Throw
    }

    It 'RemoveAzChaosExperiment-Delete' {
        {
            Remove-AzChaosExperiment -ResourceGroupName $env.resourceGroup -Name $env.experimentName2
        } | Should -Not -Throw
    }
}
