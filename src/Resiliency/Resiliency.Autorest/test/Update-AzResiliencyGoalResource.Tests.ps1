if(($null -eq $TestName) -or ($TestName -contains 'Update-AzResiliencyGoalResource'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzResiliencyGoalResource.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzResiliencyGoalResource' {
    BeforeAll {
        $goalParameters = @{ ServiceGroupName = $env.serviceGroupName; GoalAssignmentName = $env.goalAssignmentName }
        $goalIdentity = @{ ServiceGroupName = $env.serviceGroupName; GoalAssignmentName = $env.goalAssignmentName }
        $serviceGroupIdentity = @{ ServiceGroupName = $env.serviceGroupName }
        function Get-ResourceUpdate([string]$Participation) {
            return @{ ResourceArmId = $env.vmId; ZonalResiliencyGoalParticipation = $Participation }
        }
        function Get-UpdateJson([string]$Participation) {
            return @{ resources = @(@{ properties = @{ resourceArmId = $env.vmId; zonalResiliency = @{ goalParticipation = $Participation } } }) } | ConvertTo-Json -Depth 10
        }
        # Every scenario toggles the VM's participation. The updateGoal operation can stay in progress for a long time,
        # so updates are sent with -NoWait (retrying while a previous POST is still active) and the goal resource is polled.
        function Invoke-GoalResourceUpdate([scriptblock]$Command) {
            $null = Invoke-ResiliencyWithRetry -AlsoRetryOn 'InvalidResourceOperation|Conflict' $Command
        }
        function Assert-Participation([string]$Participation) {
            $deadline = (Get-Date).AddMinutes(20)
            do {
                $resource = Invoke-ResiliencyWithRetry { Get-AzResiliencyGoalResource @goalParameters -Name $env.goalResourceName }
                if ($resource.ZonalResiliencyGoalParticipation -eq $Participation) {
                    break
                }
                Start-TestSleep -Seconds 30
            } while ((Get-Date) -lt $deadline)
            $resource.ResourceArmId | Should -Be $env.vmId
            $resource.ZonalResiliencyGoalParticipation | Should -Be $Participation
        }
    }

    # Skipped: goal-assignment POST LROs (refreshGoalResources/updateGoal) on the fixture goal stay 'Accepted' for 85+ min and block further POSTs with 409 InvalidResourceOperation (correlation 745784c7-64ba-4294-bf0b-362178823ae2); cannot be recorded until the service fixes this.
    It 'UpdateViaIdentity' -skip {
        Invoke-GoalResourceUpdate { Update-AzResiliencyGoalResource -InputObject $goalIdentity -Body @{ Resource = @(Get-ResourceUpdate 'Excluded') } -NoWait }
        Assert-Participation 'Excluded'
    }

    # Skipped: goal-assignment POST LROs (refreshGoalResources/updateGoal) on the fixture goal stay 'Accepted' for 85+ min and block further POSTs with 409 InvalidResourceOperation (correlation 745784c7-64ba-4294-bf0b-362178823ae2); cannot be recorded until the service fixes this.
    It 'UpdateViaJsonString' -skip {
        Invoke-GoalResourceUpdate { Update-AzResiliencyGoalResource @goalParameters -JsonString (Get-UpdateJson 'Included') -NoWait }
        Assert-Participation 'Included'
    }

    # Skipped: goal-assignment POST LROs (refreshGoalResources/updateGoal) on the fixture goal stay 'Accepted' for 85+ min and block further POSTs with 409 InvalidResourceOperation (correlation 745784c7-64ba-4294-bf0b-362178823ae2); cannot be recorded until the service fixes this.
    It 'UpdateViaJsonFilePath' -skip {
        $jsonFilePath = Join-Path $TestDrive 'goalResources.json'
        Get-UpdateJson 'Excluded' | Set-Content $jsonFilePath
        Invoke-GoalResourceUpdate { Update-AzResiliencyGoalResource @goalParameters -JsonFilePath $jsonFilePath -NoWait }
        Assert-Participation 'Excluded'
    }

    # Skipped: goal-assignment POST LROs (refreshGoalResources/updateGoal) on the fixture goal stay 'Accepted' for 85+ min and block further POSTs with 409 InvalidResourceOperation (correlation 745784c7-64ba-4294-bf0b-362178823ae2); cannot be recorded until the service fixes this.
    It 'UpdateViaIdentityServiceGroupExpanded' -skip {
        Invoke-GoalResourceUpdate { Update-AzResiliencyGoalResource -ServiceGroupInputObject $serviceGroupIdentity -GoalAssignmentName $env.goalAssignmentName -Resource @(Get-ResourceUpdate 'Included') -NoWait }
        Assert-Participation 'Included'
    }

    # Skipped: goal-assignment POST LROs (refreshGoalResources/updateGoal) on the fixture goal stay 'Accepted' for 85+ min and block further POSTs with 409 InvalidResourceOperation (correlation 745784c7-64ba-4294-bf0b-362178823ae2); cannot be recorded until the service fixes this.
    It 'UpdateViaIdentityServiceGroup' -skip {
        Invoke-GoalResourceUpdate { Update-AzResiliencyGoalResource -ServiceGroupInputObject $serviceGroupIdentity -GoalAssignmentName $env.goalAssignmentName -Body @{ Resource = @(Get-ResourceUpdate 'Excluded') } -NoWait }
        Assert-Participation 'Excluded'
    }

    # Skipped: goal-assignment POST LROs (refreshGoalResources/updateGoal) on the fixture goal stay 'Accepted' for 85+ min and block further POSTs with 409 InvalidResourceOperation (correlation 745784c7-64ba-4294-bf0b-362178823ae2); cannot be recorded until the service fixes this.
    It 'UpdateExpanded' -skip {
        Invoke-GoalResourceUpdate { Update-AzResiliencyGoalResource @goalParameters -Resource @(Get-ResourceUpdate 'Included') -NoWait }
        Assert-Participation 'Included'
    }

    # Skipped: goal-assignment POST LROs (refreshGoalResources/updateGoal) on the fixture goal stay 'Accepted' for 85+ min and block further POSTs with 409 InvalidResourceOperation (correlation 745784c7-64ba-4294-bf0b-362178823ae2); cannot be recorded until the service fixes this.
    It 'Update' -skip {
        Invoke-GoalResourceUpdate { Update-AzResiliencyGoalResource @goalParameters -Body @{ Resource = @(Get-ResourceUpdate 'Excluded') } -NoWait }
        Assert-Participation 'Excluded'
    }

    # Skipped: goal-assignment POST LROs (refreshGoalResources/updateGoal) on the fixture goal stay 'Accepted' for 85+ min and block further POSTs with 409 InvalidResourceOperation (correlation 745784c7-64ba-4294-bf0b-362178823ae2); cannot be recorded until the service fixes this.
    It 'UpdateViaIdentityExpanded' -skip {
        Invoke-GoalResourceUpdate { Update-AzResiliencyGoalResource -InputObject $goalIdentity -Resource @(Get-ResourceUpdate 'Included') -NoWait }
        Assert-Participation 'Included'
    }
}
