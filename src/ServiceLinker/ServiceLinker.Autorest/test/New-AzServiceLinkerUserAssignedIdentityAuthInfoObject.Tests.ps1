if(($null -eq $TestName) -or ($TestName -contains 'New-AzServiceLinkerUserAssignedIdentityAuthInfoObject'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzServiceLinkerUserAssignedIdentityAuthInfoObject.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzServiceLinkerUserAssignedIdentityAuthInfoObject' {
    It '__AllParameterSets' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'New UserMI authInfo' {
        $cid = "00000000-0000-0000-0000-000000000000"

        $authInfo = New-AzServiceLinkerUserAssignedIdentityAuthInfoObject -ClientId $cid -SubscriptionId $env.SubscriptionId
        $authInfo.AuthType | Should -Be "userAssignedIdentity"
        $authInfo.ClientId | Should -Be $cid
        $authInfo.SubscriptionId | Should -Be $env.SubscriptionId
    }
}
