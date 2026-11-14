if(($null -eq $TestName) -or ($TestName -contains 'Update-AzResiliencyRecoveryPlanResource'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $ROScenarioEnvironmentDirectory = Join-Path $PSScriptRoot 'RecoveryPlans\Historical'
  $env = Get-ROScenarioEnvironment $ROScenarioEnvironmentDirectory
  $PSDefaultParameterValues['*:Tenant'] = $env.Tenant
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzResiliencyRecoveryPlanResource.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzResiliencyRecoveryPlanResource' {
    It 'UpdateExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'UpdateViaJsonString' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'UpdateViaJsonFilePath' -skip {
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

    It 'UpdatesNativeStorageAndExcludesOtherResourcesOnlyInItsOwnedPlan' {
        . (Join-Path $PSScriptRoot 'ROOperationScenarioHelpers.ps1')
        $key = 'Update.Resource'
        $fixture = Get-ROScenario $key
        try {
            $null = New-ROScenarioPlan -Key $key
            $resource = Get-ROOwnedStorage $key
            $updates = @(Get-ROProtectionUpdates $key $resource $env.fixtureRunbookId)
            $scope = Get-ROOperationScope $key
            $failedItems = @(Update-AzResiliencyRecoveryPlanResource @scope -OperationId $fixture.OperationIds.ResourceUpdate `
                -ResourcesToUpdate $updates -Confirm:$false)
            if (@($failedItems | Where-Object { $null -ne $_ }).Count -ne 0) {
                [ordered]@{
                    Scenario = $key
                    OutputTypes = @($failedItems | ForEach-Object { if ($null -eq $_) { 'null' } else { $_.GetType().FullName } })
                    NativeOutput = $failedItems
                } | ConvertTo-Json -Depth 60 | Set-Content (Join-Path $PSScriptRoot 'Update-Resource-output.private.json')
            }
            # The native enumerator can emit one null for an empty failed-resource
            # collection. A null is not a failed resource; verify persisted fields too.
            @($failedItems | Where-Object { $null -ne $_ }).Count | Should -Be 0
            $read = Assert-ROProtectionReadback $key $resource $env.fixtureRunbookId
            $read.UniqueId | Should -Be $resource.UniqueId
            $read.RecoveryGroupId | Should -Be $fixture.GroupId
        } finally {
            Remove-ROOperationScenario $key
        }
    }

}
