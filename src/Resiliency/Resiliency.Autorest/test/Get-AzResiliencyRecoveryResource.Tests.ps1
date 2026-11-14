if(($null -eq $TestName) -or ($TestName -contains 'Get-AzResiliencyRecoveryResource'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $ROScenarioEnvironmentDirectory = Join-Path $PSScriptRoot 'RecoveryPlans\Historical'
  $env = Get-ROScenarioEnvironment $ROScenarioEnvironmentDirectory
  $PSDefaultParameterValues['*:Tenant'] = $env.Tenant
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzResiliencyRecoveryResource.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzResiliencyRecoveryResource' {
    It 'List' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'GetViaIdentityServiceGroup' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'GetViaIdentityRecoveryPlan' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'Get' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'GetViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'ListsAndGetsNativeStorageMemberOnItsOwnFreshPlan' {
        $key = 'Get.Resource'
        $fixture = Get-ROScenario $key
        $listed = $null
        $read = $null
        $failure = $null
        $stage = 'CreateOwnedPlan'
        try {
            $plan = New-ROScenarioPlan -Key $key
            $plan.Name | Should -Be $fixture.PlanName
            $plan.GroupUniqueId | Should -Be $fixture.GroupId
            $stage = 'NativeResourceList'
            $resources = @(Get-AzResiliencyRecoveryResource -ServiceGroupName $env.recoveryServiceGroupName `
                -RecoveryPlanName $fixture.PlanName -ErrorAction Stop)
            # Membership discovery is read-only. Do not substitute fixture manifests or guessed IDs.
            $storage = @($resources | Where-Object ResourceId -Match '/providers/Microsoft.Storage/storageAccounts/[^/]+$' |
                Sort-Object ResourceId, Name)
            $storage.Count | Should -BeGreaterThan 0
            $listed = $storage[0]
            foreach ($property in 'Id', 'Name', 'ResourceId', 'UniqueId', 'ResourceLocation') {
                $listed.$property | Should -Not -BeNullOrEmpty
            }
            $listed.ProvisioningState | Should -Be 'Succeeded'
            $listed.SelectedProtectionSolutionType | Should -Be 'None'
            $listed.ProtectionStatus | Should -Be 'NotProtected'
            $listed.Id | Should -Be "$($fixture.PlanId)/recoveryResources/$($listed.Name)"
            @($resources | Where-Object Id -EQ $listed.Id).Count | Should -Be 1
            Save-ROResourceEvidence -Key $key -Stage $stage -ListResource $listed
            $stage = 'NativeResourceGet'
            $result = @(Get-AzResiliencyRecoveryResource -ServiceGroupName $env.recoveryServiceGroupName `
                -RecoveryPlanName $fixture.PlanName -Name $listed.Name -ErrorAction Stop)
            $result.Count | Should -Be 1
            $read = $result[0]
            foreach ($property in 'Id', 'Name', 'ResourceId', 'UniqueId', 'RecoveryGroupId', 'ResourceLocation',
                'InclusionState', 'AssociatedIdentityType', 'AssociatedIdentityUserAssignedIdentity',
                'SelectedProtectionSolutionType', 'SelectedProtectionSolutionSettingProtectionSolutionType') {
                $read.$property | Should -Be $listed.$property
            }
            # Compare the native custom settings too, including the valid both-absent case.
            ($read.SelectedProtectionSolutionSetting | ConvertTo-Json -Depth 20 -Compress) |
                Should -Be ($listed.SelectedProtectionSolutionSetting | ConvertTo-Json -Depth 20 -Compress)
            ($read.ResourceProtectionSolution | ConvertTo-Json -Depth 20 -Compress) |
                Should -Be ($listed.ResourceProtectionSolution | ConvertTo-Json -Depth 20 -Compress)
            if ($TestMode -ne 'playback') {
                $env | Add-Member -NotePropertyName discoveredStorageMember -NotePropertyValue $read -Force
                Save-ROScenarioEnv
            }
            $stage = 'NativeListGetPassed'
        } catch {
            $failure = $_.Exception.Message
            throw
        } finally {
            try {
                Remove-ROScenarioPlan -Key $key
            } finally {
                Save-ROResourceEvidence -Key $key -Stage $stage -ListResource $listed -GetResource $read -Failure $failure
            }
        }
    }
}
