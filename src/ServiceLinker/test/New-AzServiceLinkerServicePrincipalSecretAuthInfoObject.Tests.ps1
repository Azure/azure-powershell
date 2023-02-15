if(($null -eq $TestName) -or ($TestName -contains 'New-AzServiceLinkerServicePrincipalSecretAuthInfoObject'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzServiceLinkerServicePrincipalSecretAuthInfoObject.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzServiceLinkerServicePrincipalSecretAuthInfoObject' {
    It '__AllParameterSets' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
    
    It 'New spAuthInfo' {
        $cid = "00000000-0000-0000-0000-000000000000"
        $principalId = "11111111-1111-1111-1111-111111111111"
        $authInfo = New-AzServiceLinkerServicePrincipalSecretAuthInfoObject -ClientId $cid -PrincipalId $principalId -Secret 123 
        $authInfo.ClientId | Should -Be $cid
        $authInfo.PrincipalId | Should -Be $principalId
        $authInfo.Secret | Should -Be 123
    }
}
