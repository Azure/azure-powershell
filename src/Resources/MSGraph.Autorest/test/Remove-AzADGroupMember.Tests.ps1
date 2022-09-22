if(($null -eq $TestName) -or ($TestName -contains 'Remove-AzADGroupMember'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzADGroupMember.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Remove-AzADGroupMember' {
    It 'ExplicitParameterSet ' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'MemberObjectIdWithGroupObjectId' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'MemberUPNWithGroupObjectIdParameterSet' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'MemberUPNWithGroupObjectParameterSet' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'MemberUPNWithGroupDisplayNameParameterSet' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'MemberObjectIdWithGroupObject' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'MemberObjectIdWithGroupDisplayName' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
