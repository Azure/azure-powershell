if(($null -eq $TestName) -or ($TestName -contains 'Get-AzAppNetworkMember'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzAppNetworkMember.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzAppNetworkMember' {
    # Get/List coverage lives in the consolidated New-AzAppNetworkMember lifecycle test,
    # which creates a member, reads it, then deletes it (one live member per AKS cluster).
    It 'List' -skip {
        {
            $members = Get-AzAppNetworkMember -AppLinkName $env.appLinkName -ResourceGroupName $env.resourceGroup
            $members.Name | Should -Contain $env.memberName
        } | Should -Not -Throw
    }

    It 'Get' -skip {
        {
            $member = Get-AzAppNetworkMember -Name $env.memberName -AppLinkName $env.appLinkName -ResourceGroupName $env.resourceGroup
            $member.Name | Should -Be $env.memberName
        } | Should -Not -Throw
    }

    It 'GetViaIdentityAppLink' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'GetViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
