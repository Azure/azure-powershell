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
    # ServiceGroup source → ResourceGroup target
    It 'CreateExpanded' {
        $relationship = New-AzRelationshipsServiceGroupMemberRelationship -ResourceUri $env.SgmTargetResourceUri -Name $env.SgmRelNameForNew -SourceId $env.SgmSourceId
        $relationship | Should -Not -BeNullOrEmpty
        $relationship.Name | Should -Be $env.SgmRelNameForNew
        $relationship.SourceId | Should -Be $env.SgmSourceId
        $relationship.TargetId | Should -Be $env.SgmTargetResourceUri
    }

    # ServiceGroup source → Subscription target
    It 'CreateExpanded_OnSubscription' {
        $relationship = New-AzRelationshipsServiceGroupMemberRelationship -ResourceUri $env.SubscriptionResourceUri -Name $env.SgmRelNameForNewSub -SourceId $env.SgmSourceId
        $relationship | Should -Not -BeNullOrEmpty
        $relationship.Name | Should -Be $env.SgmRelNameForNewSub
        $relationship.TargetId | Should -Be $env.SubscriptionResourceUri
    }

    It 'CreateViaJsonString' {
        $jsonString = '{"properties":{"sourceId":"' + $env.SgmSourceId + '"}}'
        $relationship = New-AzRelationshipsServiceGroupMemberRelationship -ResourceUri $env.SgmTargetResourceUri -Name $env.SgmRelNameForNewJson -JsonString $jsonString
        $relationship | Should -Not -BeNullOrEmpty
        $relationship.Name | Should -Be $env.SgmRelNameForNewJson
    }

    It 'CreateViaJsonFilePath' {
        $jsonContent = '{"properties":{"sourceId":"' + $env.SgmSourceId + '"}}'
        $jsonFilePath = Join-Path -Path $PSScriptRoot -ChildPath 'New-AzRelationshipsServiceGroupMemberRelationship-Params.json'
        $jsonContent | Out-File -FilePath $jsonFilePath -Encoding utf8
        try {
            $relationship = New-AzRelationshipsServiceGroupMemberRelationship -ResourceUri $env.SgmTargetResourceUri -Name $env.SgmRelNameForNewJsonFile -JsonFilePath $jsonFilePath
            $relationship | Should -Not -BeNullOrEmpty
            $relationship.Name | Should -Be $env.SgmRelNameForNewJsonFile
        } finally {
            Remove-Item -Path $jsonFilePath -Force -ErrorAction SilentlyContinue
        }
    }

    # Error: ServiceGroupMember source must be a service group resource ID.
    It 'CreateExpanded_WithInvalidSource_ShouldFail' {
        { New-AzRelationshipsServiceGroupMemberRelationship -ResourceUri $env.SgmTargetResourceUri -Name 'sgmbadsource' -SourceId '/invalid/resource/id' -ErrorAction Stop } | Should -Throw
    }

    # Error: ServiceGroupMember source Service Group must exist.
    It 'CreateExpanded_WithNonExistentServiceGroup_ShouldFail' {
        { New-AzRelationshipsServiceGroupMemberRelationship -ResourceUri $env.SgmTargetResourceUri -Name 'sgmnosg' -SourceId '/providers/Microsoft.Management/serviceGroups/nonexistentsg' -ErrorAction Stop } | Should -Throw
    }
}
