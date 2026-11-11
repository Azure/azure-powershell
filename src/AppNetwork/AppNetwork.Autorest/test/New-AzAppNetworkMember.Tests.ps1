if(($null -eq $TestName) -or ($TestName -contains 'New-AzAppNetworkMember'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzAppNetworkMember.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzAppNetworkMember' {
    # Consolidated AppLinkMember lifecycle. AppLinkMember provisioning is 1:1 with a
    # backing AKS cluster (one live member per cluster), and the AutoRest test harness
    # runs serially, so the full lifecycle is exercised inside a single ordered Describe:
    # the member is created, read (Get/List), replaced (Set = PUT), patched (Update = PATCH),
    # its upgrade history listed, then deleted - only ever one live member, satisfying the
    # 1:1 constraint with a single cluster. The standalone Get/Set/Remove-AzAppNetworkMember
    # and Update-AzAppNetworkMember and Get-AzAppNetworkMemberUpgradeHistory tests are skipped
    # because their coverage lives here. Uses $env.appLinkNameForMember so the
    # Remove-AzAppNetwork test can delete its own parent without a child cascade.
    It 'CreateExpanded' {
        {
            $member = New-AzAppNetworkMember -Name $env.memberName -AppLinkName $env.appLinkNameForMember -ResourceGroupName $env.resourceGroup -Location $env.location `
                -ClusterType AKS -MetadataResourceId $env.aksClusterId `
                -UpgradeProfileMode FullyManaged -FullyManagedUpgradeProfileReleaseChannel Stable
            $member.Name | Should -Be $env.memberName
            $member.ClusterType | Should -Be 'AKS'
            $member.MetadataResourceId | Should -Be $env.aksClusterId
            $member.FullyManagedUpgradeProfileReleaseChannel | Should -Be 'Stable'
            $member.ProvisioningState | Should -Be 'Succeeded'
        } | Should -Not -Throw
    }

    It 'List' {
        {
            $members = Get-AzAppNetworkMember -AppLinkName $env.appLinkNameForMember -ResourceGroupName $env.resourceGroup
            $members.Name | Should -Contain $env.memberName
        } | Should -Not -Throw
    }

    It 'Get' {
        {
            $member = Get-AzAppNetworkMember -Name $env.memberName -AppLinkName $env.appLinkNameForMember -ResourceGroupName $env.resourceGroup
            $member.Name | Should -Be $env.memberName
        } | Should -Not -Throw
    }

    It 'SetExpanded' {
        # Set-AzAppNetworkMember is a full-replace PUT (CreateOrUpdate). Re-PUT the member
        # switching the FullyManaged release channel Stable -> Rapid and assert the change.
        {
            $member = Set-AzAppNetworkMember -Name $env.memberName -AppLinkName $env.appLinkNameForMember -ResourceGroupName $env.resourceGroup -Location $env.location `
                -ClusterType AKS -MetadataResourceId $env.aksClusterId `
                -UpgradeProfileMode FullyManaged -FullyManagedUpgradeProfileReleaseChannel Rapid
            $member.Name | Should -Be $env.memberName
            $member.FullyManagedUpgradeProfileReleaseChannel | Should -Be 'Rapid'
            $member.ProvisioningState | Should -Be 'Succeeded'
        } | Should -Not -Throw
    }

    It 'UpdateExpanded' {
        # Update-AzAppNetworkMember is a partial-update PATCH. Patch the FullyManaged
        # release channel back Rapid -> Stable and assert the change.
        {
            $member = Update-AzAppNetworkMember -Name $env.memberName -AppLinkName $env.appLinkNameForMember -ResourceGroupName $env.resourceGroup `
                -UpgradeProfileMode FullyManaged -FullyManagedUpgradeProfileReleaseChannel Stable
            $member.Name | Should -Be $env.memberName
            $member.FullyManagedUpgradeProfileReleaseChannel | Should -Be 'Stable'
        } | Should -Not -Throw
    }

    It 'ListUpgradeHistory' {
        # List upgrade history for the member; should not throw (may be empty).
        { Get-AzAppNetworkMemberUpgradeHistory -AppLinkName $env.appLinkNameForMember -AppLinkMemberName $env.memberName -ResourceGroupName $env.resourceGroup } | Should -Not -Throw
    }

    It 'Delete' {
        {
            Remove-AzAppNetworkMember -Name $env.memberName -AppLinkName $env.appLinkNameForMember -ResourceGroupName $env.resourceGroup
            { Get-AzAppNetworkMember -Name $env.memberName -AppLinkName $env.appLinkNameForMember -ResourceGroupName $env.resourceGroup -ErrorAction Stop } | Should -Throw
        } | Should -Not -Throw
    }

    It 'CreateViaJsonString' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'CreateViaJsonFilePath' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'CreateViaIdentityAppLinkExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
