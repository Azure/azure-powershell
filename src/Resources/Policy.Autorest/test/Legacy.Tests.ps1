if(($null -eq $TestName) -or ($TestName -contains 'Legacy'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)

  # additional ceremony to support legacy tests
  . (Join-Path $PSScriptRoot 'ScenarioTests\PolicyTests.ps1')
  . (Join-Path $PSScriptRoot '..\..\..\..\tools\TestFx\Common.ps1')
  . (Join-Path $PSScriptRoot '..\..\..\..\tools\TestFx\Assert.ps1')
  . (Join-Path $PSScriptRoot 'ScenarioTests\Common.ps1')

  # end additional ceremony

  #$TestRecordingFile = Join-Path $PSScriptRoot 'Legacy.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Legacy' {
    It 'PolicyDefinitionCRUD' {
        { Test-PolicyDefinitionCRUD } | Should -Not -Throw
    }

    It 'PolicyDefinitionMode' {
        { Test-PolicyDefinitionMode } | Should -Not -Throw
    }

    It 'PolicyDefinitionCRUDAtManagementGroup' {
        { Test-PolicyDefinitionCRUDAtManagementGroup } | Should -Not -Throw
    }

    It 'PolicyDefinitionCRUDAtSubscription' {
        { Test-PolicyDefinitionCRUDAtSubscription } | Should -Not -Throw
    }

#    It 'PolicyAssignmentCRUD' {
#        { Test-PolicyAssignmentCRUD } | Should -Not -Throw
#    }

#    It 'PolicyAssignmentAssignIdentity' {
#        { Test-PolicyAssignmentAssignIdentity } | Should -Not -Throw
#    }

#    It 'PolicyAssignmentSystemAssignedIdentity' {
#        { Test-PolicyAssignmentSystemAssignedIdentity } | Should -Not -Throw
#    }

    # Skip as current test framework does not support recording generated cmdlets.
#    It 'PolicyAssignmentUserAssignedIdentity' -skip {
#        { Test-PolicyAssignmentUserAssignedIdentity } | Should -Not -Throw
#    }

#    It 'PolicyAssignmentEnforcementMode' {
#        { Test-PolicyAssignmentEnforcementMode } | Should -Not -Throw
#    }

    It 'PolicyDefinitionWithParameters' {
        { Test-PolicyDefinitionWithParameters } | Should -Not -Throw
    }

#    It 'PolicySetDefinitionWithParameters' {
#        { Test-PolicySetDefinitionWithParameters } | Should -Not -Throw
#    }

#    It 'PolicyAssignmentWithParameters' {
#        { Test-PolicyAssignmentWithParameters } | Should -Not -Throw
#    }

#    It 'PolicySetDefinitionCRUD' {
#        { Test-PolicySetDefinitionCRUD } | Should -Not -Throw
#    }

#    It 'PolicySetDefinitionCRUDWithGroups' {
#        { Test-PolicySetDefinitionCRUDWithGroups } | Should -Not -Throw
#    }

#    It 'PolicySetDefinitionCRUDAtManagementGroup' {
#        { Test-PolicySetDefinitionCRUDAtManagementGroup } | Should -Not -Throw
#    }

#    It 'PolicySetDefinitionCRUDAtSubscription' {
#        { Test-PolicySetDefinitionCRUDAtSubscription } | Should -Not -Throw
#    }

    # Fails on macOS. Needs investigation.
    It 'PolicyDefinitionWithUri' -skip {
        { Test-PolicyDefinitionWithUri } | Should -Not -Throw
    }

    It 'PolicyObjectPiping' {
        { Test-PolicyObjectPiping } | Should -Not -Throw
    }

    It 'PolicyDefinitionWithFullObject' {
        { Test-PolicyDefinitionWithFullObject } | Should -Not -Throw
    }

    It 'GetCmdletFilterParameter' {
        { Test-GetCmdletFilterParameter } | Should -Not -Throw
    }

    It 'GetBuiltinsByName' {
        { Test-GetBuiltinsByName } | Should -Not -Throw
    }

#    It 'GetPolicyAssignmentParameters' {
#        { Test-GetPolicyAssignmentParameters } | Should -Not -Throw
#    }

#    It 'NewPolicyAssignmentParameters' {
#        { Test-NewPolicyAssignmentParameters } | Should -Not -Throw
#    }

#    It 'RemovePolicyAssignmentParameters' {
#        { Test-RemovePolicyAssignmentParameters } | Should -Not -Throw
#    }

#    It 'SetPolicyAssignmentParameters' {
#        { Test-SetPolicyAssignmentParameters } | Should -Not -Throw
#    }

    It 'GetPolicyDefinitionParameters' {
        { Test-GetPolicyDefinitionParameters } | Should -Throw 'PolicyDefinitionNotFound : '
    }

    It 'NewPolicyDefinitionParameters' {
        { Test-NewPolicyDefinitionParameters } | Should -Throw 'Cannot process command because of one or more missing mandatory parameters:'
    }

    It 'RemovePolicyDefinitionParameters' {
        { Test-RemovePolicyDefinitionParameters } | Should -Not -Throw
    }

    It 'SetPolicyDefinitionParameters' {
        { Test-SetPolicyDefinitionParameters } | Should -Not -Throw
    }

#    It 'GetPolicySetDefinitionParameters' {
#        { Test-GetPolicySetDefinitionParameters } | Should -Throw 'PolicySetDefinitionNotFound : '
#    }

#    It 'NewPolicySetDefinitionParameters' {
#        { Test-NewPolicySetDefinitionParameters } | Should -Throw 'Cannot process command because of one or more missing mandatory parameters:'
#    }

#    It 'RemovePolicySetDefinitionParameters' {
#        { Test-RemovePolicySetDefinitionParameters } | Should -Not -Throw
#    }

#    It 'SetPolicySetDefinitionParameters' {
#        { Test-SetPolicySetDefinitionParameters } | Should -Not -Throw
#    }

#    It 'PolicyExemptionCRUD' {
#        { Test-PolicyExemptionCRUD } | Should -Not -Throw
#    }

#    It 'PolicyExemptionCRUDOnPolicySet' {
#        { Test-PolicyExemptionCRUDOnPolicySet } | Should -Not -Throw
#    }

#    It 'PolicyExemptionCRUDAtManagementGroup' {
#        { Test-PolicyExemptionCRUDAtManagementGroup } | Should -Not -Throw
#    }

#    It 'GetPolicyExemptionParameters' {
#        { Test-GetPolicyExemptionParameters } | Should -Not -Throw
#    }

#    It 'NewPolicyExemptionParameters' {
#        { Test-NewPolicyExemptionParameters } | Should -Throw 'MissingSubscription : The request did not have a subscription or a valid tenant level resource provider.'
#    }

 #   It 'RemovePolicyExemptionParameters' {
 #       { Test-RemovePolicyExemptionParameters } | Should -Not -Throw
 #   }

 #   It 'SetPolicyExemptionParameters' {
 #       { Test-SetPolicyExemptionParameters } | Should -Not -Throw
 #   }
}
