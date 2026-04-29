if(($null -eq $TestName) -or ($TestName -contains 'New-AzRelationshipsDependencyOfRelationship'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzRelationshipsDependencyOfRelationship.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzRelationshipsDependencyOfRelationship' {
    # ResourceGroup source → ResourceGroup target (source ≠ target)
    It 'CreateExpanded' {
        $relationship = New-AzRelationshipsDependencyOfRelationship -ResourceUri $env.DepResourceGroupResourceUri -Name $env.DepRelNameForNew -TargetId $env.DepTargetId
        $relationship | Should -Not -BeNullOrEmpty
        $relationship.Name | Should -Be $env.DepRelNameForNew
    }

    # Subscription source → ResourceGroup target
    It 'CreateExpanded_OnSubscription' {
        $relationship = New-AzRelationshipsDependencyOfRelationship -ResourceUri $env.SubscriptionResourceUri -Name $env.DepRelNameForNewSub -TargetId $env.DepTargetIdForSub
        $relationship | Should -Not -BeNullOrEmpty
        $relationship.Name | Should -Be $env.DepRelNameForNewSub
    }

    # ResourceGroup source → ServiceGroup target (primary real-world scenario)
    It 'CreateExpanded_WithServiceGroupTarget' {
        $relationship = New-AzRelationshipsDependencyOfRelationship -ResourceUri $env.DepResourceGroupResourceUri -Name $env.DepRelNameForNewSgTarget -TargetId $env.DepTargetServiceGroupId
        $relationship | Should -Not -BeNullOrEmpty
        $relationship.Name | Should -Be $env.DepRelNameForNewSgTarget
    }

    # Subscription source → ServiceGroup target
    It 'CreateExpanded_SubscriptionToServiceGroup' {
        $relationship = New-AzRelationshipsDependencyOfRelationship -ResourceUri $env.SubscriptionResourceUri -Name $env.DepRelNameForNewSubToSg -TargetId $env.DepTargetServiceGroupId
        $relationship | Should -Not -BeNullOrEmpty
        $relationship.Name | Should -Be $env.DepRelNameForNewSubToSg
    }

    It 'CreateViaJsonString' {
        $jsonString = '{"properties":{"targetId":"' + $env.DepTargetId + '"}}'
        $relationship = New-AzRelationshipsDependencyOfRelationship -ResourceUri $env.DepResourceGroupResourceUri -Name $env.DepRelNameForNewJson -JsonString $jsonString
        $relationship | Should -Not -BeNullOrEmpty
        $relationship.Name | Should -Be $env.DepRelNameForNewJson
    }

    # Error: source and target cannot be the same resource
    It 'CreateExpanded_SameSourceAndTarget_ShouldFail' {
        { New-AzRelationshipsDependencyOfRelationship -ResourceUri $env.DepResourceGroupResourceUri -Name $env.DepRelNameForSameTarget -TargetId $env.DepResourceGroupResourceUri } | Should -Throw
    }
}
