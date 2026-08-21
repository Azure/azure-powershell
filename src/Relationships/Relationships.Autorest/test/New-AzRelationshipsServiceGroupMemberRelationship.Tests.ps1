if(($null -eq $TestName) -or ($TestName -contains 'New-AzRelationshipsServiceGroupMemberRelationship'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzRelationshipsServiceGroupMemberRelationship.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzRelationshipsServiceGroupMemberRelationship' {
    # ResourceGroup source → ServiceGroup target
    It 'CreateExpanded' {
        $relationship = New-AzRelationshipsServiceGroupMemberRelationship -ResourceUri $env.SgmResourceGroupResourceUri -Name $env.SgmRelNameForNew -TargetId $env.SgmTargetId
        $relationship | Should -Not -BeNullOrEmpty
        $relationship.Name | Should -Be $env.SgmRelNameForNew
    }

    # Subscription source → ServiceGroup target
    It 'CreateExpanded_OnSubscription' {
        $relationship = New-AzRelationshipsServiceGroupMemberRelationship -ResourceUri $env.SubscriptionResourceUri -Name $env.SgmRelNameForNewSub -TargetId $env.SgmTargetId
        $relationship | Should -Not -BeNullOrEmpty
        $relationship.Name | Should -Be $env.SgmRelNameForNewSub
    }

    It 'CreateViaJsonString' {
        $jsonString = '{"properties":{"targetId":"' + $env.SgmTargetId + '"}}'
        $relationship = New-AzRelationshipsServiceGroupMemberRelationship -ResourceUri $env.SgmResourceGroupResourceUri -Name $env.SgmRelNameForNewJson -JsonString $jsonString
        $relationship | Should -Not -BeNullOrEmpty
        $relationship.Name | Should -Be $env.SgmRelNameForNewJson
    }

    It 'CreateViaJsonFilePath' {
        $jsonContent = '{"properties":{"targetId":"' + $env.SgmTargetId + '"}}'
        $jsonFilePath = Join-Path -Path $PSScriptRoot -ChildPath 'New-AzRelationshipsServiceGroupMemberRelationship-Params.json'
        $jsonContent | Out-File -FilePath $jsonFilePath -Encoding utf8
        try {
            $relationship = New-AzRelationshipsServiceGroupMemberRelationship -ResourceUri $env.SgmResourceGroupResourceUri -Name $env.SgmRelNameForNewJsonFile -JsonFilePath $jsonFilePath
            $relationship | Should -Not -BeNullOrEmpty
            $relationship.Name | Should -Be $env.SgmRelNameForNewJsonFile
        } finally {
            Remove-Item -Path $jsonFilePath -Force -ErrorAction SilentlyContinue
        }
    }

    # Error: ServiceGroupMember target must be a Service Group, not a resource group
    It 'CreateExpanded_WithInvalidTarget_ShouldFail' {
        { New-AzRelationshipsServiceGroupMemberRelationship -ResourceUri $env.SgmResourceGroupResourceUri -Name 'sgmbadtarget' -TargetId $env.SgmResourceGroupResourceUri } | Should -Throw
    }

    # Error: ServiceGroupMember target Service Group must exist
    It 'CreateExpanded_WithNonExistentServiceGroup_ShouldFail' {
        { New-AzRelationshipsServiceGroupMemberRelationship -ResourceUri $env.SgmResourceGroupResourceUri -Name 'sgmnosg' -TargetId '/providers/Microsoft.Management/serviceGroups/nonexistentsg' } | Should -Throw
    }
}
