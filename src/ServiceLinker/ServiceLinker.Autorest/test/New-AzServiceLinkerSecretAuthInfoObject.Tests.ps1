if(($null -eq $TestName) -or ($TestName -contains 'New-AzServiceLinkerSecretAuthInfoObject'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzServiceLinkerSecretAuthInfoObject.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzServiceLinkerSecretAuthInfoObject' {
    It 'New rawValue secretAuthInfo' {
        $authInfo = New-AzServiceLinkerSecretAuthInfoObject -Name testUsert -SecretValue 123
        $authInfo.SecretInfo.SecretType | Should -Be "rawValue"
        $authInfo.SecretInfo.Value | Should -Be 123
    }

    It 'New keyVaultSecretUri secretAuthInfo' {
        $authInfo = New-AzServiceLinkerSecretAuthInfoObject -Name testUsert -SecretKeyVaultUri $env.secretUri
        $authInfo.SecretInfo.SecretType | Should -Be "keyVaultSecretUri"
        $authInfo.SecretInfo.Value | Should -Be $env.secretUri
    }

    It 'New keyVaultSecretUri secretAuthInfo' {
        $authInfo = New-AzServiceLinkerSecretAuthInfoObject -Name testUsert -SecretNameInKeyVault "name"
        $authInfo.SecretInfo.SecretType | Should -Be "keyVaultSecretReference"
        $authInfo.SecretInfo.Name | Should -Be "name"
    }
}
