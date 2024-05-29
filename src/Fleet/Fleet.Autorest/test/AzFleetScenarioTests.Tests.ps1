if(($null -eq $TestName) -or ($TestName -contains 'AzFleetScenario'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'AzFleetScenarioTests.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'AzFleet' {
    It 'Fleet-CreateExpanded' {
        {
            #Create
            $key = "abc"
            $val = "123"
            $tag = @{$key=$val}

            $testf1 = New-AzFleet -Name $env.testFleet1 -ResourceGroupName $env.resourceGroup -Location $env.Location -Tag $tag
            $testf1.Name | Should -Be $env.testFleet1
            $testf1.IdentityType | Should -Be $null
            $testf1.Tag.ContainsKey($key) | Should -BeTrue
            $testf1.Tag["$key"] | Should -Be $val
            
            $testf2 = New-AzFleet -Name $env.testFleet2 -ResourceGroupName $env.resourceGroup -Location $env.Location -EnableSystemAssignedIdentity -Tag $tag
            $testf2.Name | Should -Be $env.testFleet2
            $testf2.IdentityType | Should -Be "SystemAssigned"
            $testf2.Tag.ContainsKey($key) | Should -BeTrue
            $testf2.Tag["$key"] | Should -Be $val

            $testf3 = New-AzFleet -Name $env.testFleet3 -ResourceGroupName $env.resourceGroup2 -Location $env.Location -UserAssignedIdentity $env.managementIdenetityID
            $testf3.Name | Should -Be $env.testFleet3
            $testf3.IdentityType | Should -Be "UserAssigned"
        } | Should -Not -Throw
    }

    It 'Fleet-List' {
        {
            $fleetList = Get-AzFleet -SubscriptionId $env.SubscriptionId
            $fleetList.Count | Should -Be 3
        } | Should -Not -Throw
    }

    It 'Fleet-List1' {
        {
            $fleetList2 = Get-AzFleet -ResourceGroupName $env.resourceGroup
            $fleetList2.Count | Should -Be 2
        } | Should -Not -Throw
    }

    It 'Fleet-UpdateExpanded' {
        {
            $key = "123"
            $val = "abc"
            $tag = @{$key=$val}

            $update = Update-AzFleet -Name $env.testFleet1 -ResourceGroupName $env.resourceGroup -Tag $tag -EnableSystemAssignedIdentity 1
            $update.Name | Should -Be $env.testFleet1
            $update.IdentityType | Should -Be "SystemAssigned"
            $update.Tag.ContainsKey($key) | Should -BeTrue
            $update.Tag["$key"] | Should -Be $val
        } | Should -Not -Throw
    }

    It 'Fleet-Get-UpdateViaIdentityExpanded' {
        {
            $key = "456"
            $val = "abc"
            $tag = @{$key=$val}

            $fleet2 = Get-AzFleet -Name $env.testFleet2 -ResourceGroupName $env.resourceGroup
            $update = Update-AzFleet -InputObject $fleet2 -Tag $tag
            $update.Name | Should -Be $env.testFleet2
            $update.IdentityType | Should -Be "SystemAssigned"
            $update.Tag.ContainsKey($key) | Should -BeTrue
            $update.Tag["$key"] | Should -Be $val
        } | Should -Not -Throw
    }

    It 'FleetMember-CreateExpanded-GetViaIdentity' {
        {
            $fleetMember12 = New-AzFleetMember -FleetName $env.testFleet1 -Name $env.testFleetMember2 -ResourceGroupName $env.resourceGroup -ClusterResourceId $env.clusterID12 -Group $env.testGroup1
            New-AzFleetMember -FleetName $env.testFleet3 -Name $env.testFleetMember3 -ResourceGroupName $env.resourceGroup2 -ClusterResourceId $env.clusterID21 -Group $env.testGroup2
            New-AzFleetMember -FleetName $env.testFleet3 -Name $env.testFleetMember4 -ResourceGroupName $env.resourceGroup2 -ClusterResourceId $env.clusterID22 -Group $env.testGroup2

            $getFleetMember = Get-AzFleetMember -InputObject $fleetMember12
            $getFleetMember.Name | Should -Be $env.testFleetMember2
        } | Should -Not -Throw
    }

    It 'FleetMember-CreateViaIdentityExpanded-GetViaIdentityFleet' {
        {
            $fleet = Get-AzFleet -Name $env.testFleet1 -ResourceGroupName $env.resourceGroup
            New-AzFleetMember -FleetInputObject $fleet -Name $env.testFleetMember1 -ClusterResourceId $env.clusterID11 -Group $env.testGroup1

            $getListFleetMember = Get-AzFleetMember -FleetInputObject $fleet -Name $env.testFleetMember1
            $getListFleetMember.Name | Should -Be $env.testfleetMember1
        } | Should -Not -Throw
    }

    It 'FleetMember-List' {
        {
            $listFleetMember = Get-AzFleetMember -FleetName $env.testFleet1 -ResourceGroupName $env.resourceGroup
            $listFleetMember.Count | Should -Be 2

            $listFleetMember2 = Get-AzFleetMember -FleetName $env.testFleet3 -ResourceGroupName $env.resourceGroup2
            $listFleetMember2.Count | Should -Be 2
        } | Should -Not -Throw
    }

    It 'UpdateRun-CreateExpanded' {
        {
            $updaterun = New-AzFleetUpdateRun -FleetName $env.testFleet1 -Name $env.testUpdateRun1 -ResourceGroupName $env.resourceGroup -UpgradeType NodeImageOnly
            $updaterun.Name | Should -Be $env.testUpdateRun1
        } | Should -Not -Throw
    }

    It 'UpdateRun-CreateViaIdentityFleetExpanded' {
        {
            $fleet3 = Get-AzFleet -Name $env.testFleet3 -ResourceGroupName $env.resourceGroup2
            $updateRun = New-AzFleetUpdateRun -FleetInputObject $fleet3 -Name $env.testUpdateRun2 -UpgradeType Full -UpgradeKubernetesVersion $env.UpgradeKubernetesVersion
            $updateRun.Name | Should -Be $env.testUpdateRun2
        } | Should -Not -Throw
    }

    It 'UpdateRun-List' {
        {
            $updateRun = Get-AzFleetUpdateRun -FleetName $env.testFleet1 -ResourceGroupName $env.resourceGroup
            $updateRun.Name | Should -Be $env.testUpdateRun1
        } | Should -Not -Throw
    }

    It 'UpdateRun-Get' {
        {
            $updateRun12 = Get-AzFleetUpdateRun -FleetName $env.testFleet1 -ResourceGroupName $env.resourceGroup -Name $env.testUpdateRun1
            $updateRun12.Name | Should -Be $env.testUpdateRun1
        } | Should -Not -Throw
    }

    It 'UpdateRun-Start' {
        {
            Start-AzFleetUpdateRun -FleetName $env.testFleet3 -ResourceGroupName $env.resourceGroup2 -Name $env.testUpdateRun2
            $updateRun = Get-AzFleetUpdateRun -FleetName $env.testFleet3 -ResourceGroupName $env.resourceGroup2 -Name $env.testUpdateRun2
            $updateRun.StatusState | Should -Not -Be "Stopping"
        } | Should -Not -Throw
    }

    It 'UpdateRun-UpdateExpanded' {
        {
            $a = New-AzFleetUpdateGroupObject -Name $env.testGroup1
            $b = New-AzFleetUpdateGroupObject -Name $env.testGroup2
            $stage = New-AzFleetUpdateStageObject -Name stage1 -Group $a,$b -AfterStageWaitInSecond 600
            
            $updateRun13 = Update-AzFleetUpdateRun -FleetName $env.testFleet1 -ResourceGroupName $env.resourceGroup -Name $env.testUpdateRun1 -UpgradeType Full -UpgradeKubernetesVersion $env.UpgradeKubernetesVersion -StrategyStage $stage
            $updateRun13.UpgradeType | Should -Be 'Full'
            $updateRun13.UpgradeKubernetesVersion | Should -Be $env.UpgradeKubernetesVersion
        } | Should -Not -Throw
    }
    
    It 'UpdateRun-Stop' {
        {
            Start-AzFleetUpdateRun -FleetName $env.testFleet1 -ResourceGroupName $env.resourceGroup -Name $env.testUpdateRun1
            $updateRun = Stop-AzFleetUpdateRun -FleetName $env.testFleet1 -ResourceGroupName $env.resourceGroup -Name $env.testUpdateRun1
            $updateRun.StatusState | Should -Not -Be "NotStarted"
        } | Should -Not -Throw
    }
    
    It 'UpdateRun-Delete' {
        {
            $result = Remove-AzFleetUpdateRun -FleetName $env.testFleet3 -ResourceGroupName $env.resourceGroup2 -Name $env.testUpdateRun2 -PassThru
            $result | Should -Be $true
        } | Should -Not -Throw
    }

    It 'UpdateRun-DeleteViaIdentity' {
        {
            $updateRun3 = Get-AzFleetUpdateRun -FleetName $env.testFleet1 -ResourceGroupName $env.resourceGroup -Name $env.testUpdateRun1
            $result = Remove-AzFleetUpdateRun -InputObject $updateRun3 -PassThru
            $result | Should -Be $true
        } | Should -Not -Throw
    }

    It 'UpdateStrategy-CreateExpanded' {
        {
            $a = New-AzFleetUpdateGroupObject -Name $env.testGroup1
            $b = New-AzFleetUpdateGroupObject -Name $env.testGroup2
            $stage = New-AzFleetUpdateStageObject -Name stage1 -Group $a,$b -AfterStageWaitInSecond 600
            New-AzFleetUpdateStrategy -FleetName $env.testFleet1 -ResourceGroupName $env.resourceGroup -Name $env.testUpdateStrategy1 -StrategyStage $stage
            # TODO: Add assert
        } | Should -Not -Throw
    }

    It 'UpdateStrategy-CreateViaIdentityFleetExpanded' {
        {
            $b = New-AzFleetUpdateGroupObject -Name $env.testGroup2
            $stage2 = New-AzFleetUpdateStageObject -Name stage1 -Group $b -AfterStageWaitInSecond 120
            $fleet3 = Get-AzFleet -Name $env.testFleet3 -ResourceGroupName $env.resourceGroup2
            New-AzFleetUpdateStrategy -FleetInputObject $fleet3 -Name $env.testUpdateStrategy2 -StrategyStage $stage2
            # TODO: Add assert
        } | Should -Not -Throw
    }
    
    It 'UpdateStrategy-List' {
        {
            $strategyList = Get-AzFleetUpdateStrategy -FleetName $env.testFleet1 -ResourceGroupName $env.resourceGroup
            $strategyList.Count | Should -Be 1
        } | Should -Not -Throw
    }

    It 'FleetMember-UpdateExpanded' {
        {
            $fleetMember3 = Update-AzFleetMember -FleetName $env.testFleet3 -Name $env.testFleetMember3 -ResourceGroupName $env.resourceGroup2 -Group $env.testGroup1
            $fleetMember3.Group | Should -Be $env.testGroup1
        } | Should -Not -Throw
    }

    It 'FleetMember-Get-UpdateViaIdentityExpanded' {
        {
            $fleetMember4 = Get-AzFleetMember -FleetName $env.testFleet3 -Name $env.testFleetMember3 -ResourceGroupName $env.resourceGroup2

            $fleetMember5 = Update-AzFleetMember -InputObject $fleetMember4 -Group $env.testGroup1
            $fleetMember5.Group | Should -Be $env.testGroup1
        } | Should -Not -Throw
    }
    
    It 'UpdateStrategy-Get-UpdateViaIdentityExpanded-DeleteViaIdentity' {
        {
            $strategy = Get-AzFleetUpdateStrategy -FleetName $env.testFleet1 -ResourceGroupName $env.resourceGroup -Name $env.testUpdateStrategy1
            
            $b = New-AzFleetUpdateGroupObject -Name $env.testGroup2
            $stage3 = New-AzFleetUpdateStageObject -Name stage3 -Group $b -AfterStageWaitInSecond 60
            $strategy = Update-AzFleetUpdateStrategy -InputObject $strategy -StrategyStage $stage3
            $strategy.StrategyStage.Name | Should -Be $stage3.Name

            $result = Remove-AzFleetUpdateStrategy -InputObject $strategy -PassThru
            $result | Should -Be $true
        } | Should -Not -Throw
    }

    It 'UpdateStrategy-UpdateExpanded-DeleteViaIdentity' {
        {
            $a = New-AzFleetUpdateGroupObject -Name $env.testGroup1
            $b = New-AzFleetUpdateGroupObject -Name $env.testGroup2
            $stage4 = New-AzFleetUpdateStageObject -Name stage4 -Group $a,$b -AfterStageWaitInSecond 60
            $strategy2 = Update-AzFleetUpdateStrategy -FleetName $env.testFleet3 -ResourceGroupName $env.resourceGroup2 -Name $env.testUpdateStrategy2 -StrategyStage $stage4
            $strategy2.StrategyStage.Name | Should -Be $stage4.Name

            $result = Remove-AzFleetUpdateStrategy -InputObject $strategy2 -PassThru
            $result | Should -Be $true
        } | Should -Not -Throw
    }

    It 'UpdateStrategy-Delete' {
        {
            $result = Remove-AzFleetUpdateStrategy -FleetName $env.testFleet1 -ResourceGroupName $env.resourceGroup -Name $env.testUpdateStrategy2 -PassThru
            $result | Should -Be $true
        } | Should -Not -Throw
    }

    It 'FleetMember-DeleteViaIdentity' {
        {
            $fleetmember6 = Get-AzFleetMember -FleetName $env.testFleet3 -Name $env.testFleetMember4 -ResourceGroupName $env.resourceGroup2
            $result = Remove-AzFleetMember -InputObject $fleetmember6 -PassThru
            $result | Should -Be $true
        } | Should -Not -Throw
    }

    It 'FleetMember-Delete' {
        {
            $result = Remove-AzFleetMember -FleetName $env.testFleet3 -Name $env.testFleetMember3 -ResourceGroupName $env.resourceGroup2 -PassThru
            $result | Should -Be $true
        } | Should -Not -Throw
    }
}

