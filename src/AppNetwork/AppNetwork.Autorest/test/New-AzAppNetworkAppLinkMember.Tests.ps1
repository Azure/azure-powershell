if(($null -eq $TestName) -or ($TestName -contains 'New-AzAppNetworkAppLinkMember'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzAppNetworkAppLinkMember.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzAppNetworkAppLinkMember' {
    It 'CreateExpanded' {
        {
            $member = New-AzAppNetworkAppLinkMember -Name $env.memberName -AppLinkName $env.appLinkName -ResourceGroupName $env.resourceGroup -Location $env.location `
                -ClusterType AKS -MetadataResourceId $env.aksClusterId `
                -UpgradeProfileMode FullyManaged -FullyManagedUpgradeProfileReleaseChannel Stable
            $member.Name | Should -Be $env.memberName
            $member.ClusterType | Should -Be 'AKS'
            $member.MetadataResourceId | Should -Be $env.aksClusterId
            $member.ProvisioningState | Should -Be 'Succeeded'
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
