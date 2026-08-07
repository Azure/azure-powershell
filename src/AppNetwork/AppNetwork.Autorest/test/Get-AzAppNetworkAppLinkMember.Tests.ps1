if(($null -eq $TestName) -or ($TestName -contains 'Get-AzAppNetworkAppLinkMember'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzAppNetworkAppLinkMember.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzAppNetworkAppLinkMember' {
    It 'List' {
        {
            $members = Get-AzAppNetworkAppLinkMember -AppLinkName $env.appLinkName -ResourceGroupName $env.resourceGroup
            $members.Name | Should -Contain $env.memberName
        } | Should -Not -Throw
    }

    It 'Get' {
        {
            $member = Get-AzAppNetworkAppLinkMember -Name $env.memberName -AppLinkName $env.appLinkName -ResourceGroupName $env.resourceGroup
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
