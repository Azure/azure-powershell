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
        # The goal resource ID is assigned by the service when the VM is discovered, so look it up by the VM's ARM ID.
        $goalResource = @(Invoke-ResiliencyWithRetry { Get-AzResiliencyGoalResource @goalParameters }) | Where-Object { $_.ResourceArmId -eq $env.vmId } | Select-Object -First 1
        $goalResourceId = $goalResource.Id
        $goalResourceName = $goalResource.Name
        # The service identifies each updated item by the goal resource's own ARM ID, so every update carries Id.
        function Get-ResourceUpdate([string]$Participation) {
            return @{ Id = $goalResourceId; ResourceArmId = $env.vmId; ZonalResiliencyGoalParticipation = $Participation }
        }
        function Get-UpdateJson([string]$Participation) {
            return @{ resources = @(@{ id = $goalResourceId; properties = @{ resourceArmId = $env.vmId; zonalResiliency = @{ goalParticipation = $Participation } } }) } | ConvertTo-Json -Depth 10
        }
        # Every scenario toggles the VM's participation. Updates are sent with -NoWait (retrying while a previous POST on
        # the goal assignment is still active) and the goal resource is polled until it reflects the change.
        function Invoke-GoalResourceUpdate([scriptblock]$Command) {
            $null = Invoke-ResiliencyWithRetry -AlsoRetryOn 'InvalidResourceOperation|Conflict' $Command
        }
        function Assert-Participation([string]$Participation) {
            $deadline = (Get-Date).AddMinutes(20)
            do {
                $resource = Invoke-ResiliencyWithRetry { Get-AzResiliencyGoalResource @goalParameters -Name $goalResourceName }
                if ($resource.ZonalResiliencyGoalParticipation -eq $Participation) {
                    break
                }
                Start-TestSleep -Seconds 30
            } while ((Get-Date) -lt $deadline)
            $resource.ResourceArmId | Should -Be $env.vmId
            $resource.ZonalResiliencyGoalParticipation | Should -Be $Participation
        }
    }

    It 'UpdateViaIdentity' {
        Invoke-GoalResourceUpdate { Update-AzResiliencyGoalResource -InputObject $goalIdentity -Body @{ Resource = @(Get-ResourceUpdate 'Excluded') } -NoWait }
        Assert-Participation 'Excluded'
    }

    It 'UpdateViaJsonString' {
        Invoke-GoalResourceUpdate { Update-AzResiliencyGoalResource @goalParameters -JsonString (Get-UpdateJson 'Included') -NoWait }
        Assert-Participation 'Included'
    }

    It 'UpdateViaJsonFilePath' {
        $jsonFilePath = Join-Path $TestDrive 'goalResources.json'
        Get-UpdateJson 'Excluded' | Set-Content $jsonFilePath
        Invoke-GoalResourceUpdate { Update-AzResiliencyGoalResource @goalParameters -JsonFilePath $jsonFilePath -NoWait }
        Assert-Participation 'Excluded'
    }

    It 'UpdateViaIdentityServiceGroupExpanded' {
        Invoke-GoalResourceUpdate { Update-AzResiliencyGoalResource -ServiceGroupInputObject $serviceGroupIdentity -GoalAssignmentName $env.goalAssignmentName -Resource @(Get-ResourceUpdate 'Included') -NoWait }
        Assert-Participation 'Included'
    }

    It 'UpdateViaIdentityServiceGroup' {
        Invoke-GoalResourceUpdate { Update-AzResiliencyGoalResource -ServiceGroupInputObject $serviceGroupIdentity -GoalAssignmentName $env.goalAssignmentName -Body @{ Resource = @(Get-ResourceUpdate 'Excluded') } -NoWait }
        Assert-Participation 'Excluded'
    }

    It 'UpdateExpanded' {
        Invoke-GoalResourceUpdate { Update-AzResiliencyGoalResource @goalParameters -Resource @(Get-ResourceUpdate 'Included') -NoWait }
        Assert-Participation 'Included'
    }

    It 'Update' {
        Invoke-GoalResourceUpdate { Update-AzResiliencyGoalResource @goalParameters -Body @{ Resource = @(Get-ResourceUpdate 'Excluded') } -NoWait }
        Assert-Participation 'Excluded'
    }

    It 'UpdateViaIdentityExpanded' {
        Invoke-GoalResourceUpdate { Update-AzResiliencyGoalResource -InputObject $goalIdentity -Resource @(Get-ResourceUpdate 'Included') -NoWait }
        Assert-Participation 'Included'
    }
}
