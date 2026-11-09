if(($null -eq $TestName) -or ($TestName -contains 'Update-AzResiliencyRecoveryPlan'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $ROScenarioEnvironmentDirectory = Join-Path $PSScriptRoot 'RecoveryPlans\Historical'
  $env = Get-ROScenarioEnvironment $ROScenarioEnvironmentDirectory
  $PSDefaultParameterValues['*:Tenant'] = $env.Tenant
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzResiliencyRecoveryPlan.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzResiliencyRecoveryPlan' {
    It 'UpdateExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'UpdateViaIdentityServiceGroupExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'UpdateViaIdentityServiceGroup' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'Update' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'UpdateViaIdentityExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'UpdateViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'DisablesSystemIdentityWhilePreservingOmittedPlanAndActionFields' {
        $key = 'Update.SystemFalse'
        $fixture = Get-ROScenario $key
        try {
            $pre = [Microsoft.Azure.PowerShell.Cmdlets.Resiliency.Models.RecoveryGroupManualAction]::new()
            $pre.Name = $fixture.PreActionName
            $pre.Description = 'Owned identity preservation pre-action'
            $pre.TimeoutInMinute = 1
            $post = [Microsoft.Azure.PowerShell.Cmdlets.Resiliency.Models.RecoveryGroupManualAction]::new()
            $post.Name = $fixture.PostActionName
            $post.Description = 'Owned identity preservation post-action'
            $post.TimeoutInMinute = 5
            $before = New-ROScenarioPlan -Key $key -Properties @{ PreAction = @($pre); PostAction = @($post); OrderId = 0 }
            $before.IdentityType | Should -Be 'SystemAssigned'
            $before.IdentityPrincipalId | Should -Not -BeNullOrEmpty
            $updated = Update-AzResiliencyRecoveryPlan -ServiceGroupName $env.recoveryServiceGroupName `
                -Name $fixture.PlanName -EnableSystemAssignedIdentity:$false -Confirm:$false -ErrorAction Stop
            $updated.IdentityType | Should -Be 'None'
            $read = Get-AzResiliencyRecoveryPlan -ServiceGroupName $env.recoveryServiceGroupName `
                -Name $fixture.PlanName -ErrorAction Stop
            $read.IdentityType | Should -Be 'None'
            $read.IdentityPrincipalId | Should -BeNullOrEmpty
            foreach ($property in 'Id', 'GroupUniqueId', 'Description', 'PlanDescription', 'OrderId', 'PlanType') {
                $read.$property | Should -Be $before.$property
            }
            ($read.PreAction | ConvertTo-Json -Depth 20 -Compress) | Should -Be ($before.PreAction | ConvertTo-Json -Depth 20 -Compress)
            ($read.PostAction | ConvertTo-Json -Depth 20 -Compress) | Should -Be ($before.PostAction | ConvertTo-Json -Depth 20 -Compress)
        } finally {
            Remove-ROScenarioPlan -Key $key
        }
    }

    It 'EnablesSystemIdentityFromNoneWhilePreservingOmittedPlanAndActionFields' {
        $key = 'Update.SystemTrue'
        $fixture = Get-ROScenario $key
        try {
            $pre = [Microsoft.Azure.PowerShell.Cmdlets.Resiliency.Models.RecoveryGroupManualAction]::new()
            $pre.Name = $fixture.PreActionName
            $pre.Description = 'Owned identity preservation pre-action'
            $pre.TimeoutInMinute = 1
            $post = [Microsoft.Azure.PowerShell.Cmdlets.Resiliency.Models.RecoveryGroupManualAction]::new()
            $post.Name = $fixture.PostActionName
            $post.Description = 'Owned identity preservation post-action'
            $post.TimeoutInMinute = 5
            $null = New-ROScenarioPlan -Key $key -Properties @{ PreAction = @($pre); PostAction = @($post); OrderId = 0 }
            $null = Update-AzResiliencyRecoveryPlan -ServiceGroupName $env.recoveryServiceGroupName `
                -Name $fixture.PlanName -EnableSystemAssignedIdentity:$false -Confirm:$false -ErrorAction Stop
            $before = Get-AzResiliencyRecoveryPlan -ServiceGroupName $env.recoveryServiceGroupName -Name $fixture.PlanName -ErrorAction Stop
            $before.IdentityType | Should -Be 'None'
            $updated = Update-AzResiliencyRecoveryPlan -ServiceGroupName $env.recoveryServiceGroupName `
                -Name $fixture.PlanName -EnableSystemAssignedIdentity:$true -Confirm:$false -ErrorAction Stop
            $updated.IdentityType | Should -Be 'SystemAssigned'
            $updated.IdentityPrincipalId | Should -Not -BeNullOrEmpty
            $read = Get-AzResiliencyRecoveryPlan -ServiceGroupName $env.recoveryServiceGroupName -Name $fixture.PlanName -ErrorAction Stop
            $read.IdentityType | Should -Be 'SystemAssigned'
            $read.IdentityPrincipalId | Should -Be $updated.IdentityPrincipalId
            $read.IdentityTenantId | Should -Be $env.Tenant
            foreach ($property in 'Id', 'GroupUniqueId', 'Description', 'PlanDescription', 'OrderId', 'PlanType') {
                $read.$property | Should -Be $before.$property
            }
            ($read.PreAction | ConvertTo-Json -Depth 20 -Compress) | Should -Be ($before.PreAction | ConvertTo-Json -Depth 20 -Compress)
            ($read.PostAction | ConvertTo-Json -Depth 20 -Compress) | Should -Be ($before.PostAction | ConvertTo-Json -Depth 20 -Compress)
        } finally {
            Remove-ROScenarioPlan -Key $key
        }
    }
}
