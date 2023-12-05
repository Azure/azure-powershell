if(($null -eq $TestName) -or ($TestName -contains 'Get-AzFederatedIdentityCredential'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzFederatedIdentityCredential.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzFederatedIdentityCredential' {
    It 'List' {
        $ficList = Get-AzFederatedIdentityCredential -ResourceGroupName $env.ficResourceGroup -IdentityName $env.ficUserIdentityName
        $ficList.Count | Should -BeGreaterOrEqual 1
    }
    It 'Get' {
        $fic = Get-AzFederatedIdentityCredential -ResourceGroupName $env.ficResourceGroup -IdentityName $env.ficUserIdentityName -Name $env.ficName01
        $fic.Name | Should -Be $env.ficName01
        $fic.Issuer | Should -Be $env.Issuer01
        $fic.Subject | Should -Be $env.Subject01
        $fic.Audience | Should -Be $env.ficAudience
    }

    It 'GetViaIdentity' {
        $fic = Get-AzFederatedIdentityCredential -ResourceGroupName $env.ficResourceGroup -IdentityName $env.ficUserIdentityName -Name $env.ficName01
        $fic = Get-AzFederatedIdentityCredential -InputObject $fic
        $fic.Name | Should -Be $env.ficName01
        $fic.Issuer | Should -Be $env.Issuer01
        $fic.Subject | Should -Be $env.Subject01
        $fic.Audience | Should -Be $env.ficAudience
    }

    It 'ListAlisa' {
        $ficList = Get-AzFederatedIdentityCredentials -ResourceGroupName $env.ficResourceGroup -IdentityName $env.ficUserIdentityName
        $ficList.Count | Should -BeGreaterOrEqual 1
    }
    It 'GetAlisa' {
        $fic = Get-AzFederatedIdentityCredentials -ResourceGroupName $env.ficResourceGroup -IdentityName $env.ficUserIdentityName -Name $env.ficName01
        $fic.Name | Should -Be $env.ficName01
        $fic.Issuer | Should -Be $env.Issuer01
        $fic.Subject | Should -Be $env.Subject01
        $fic.Audience | Should -Be $env.ficAudience
    }

    It 'GetViaIdentityAlisa' {
        $fic = Get-AzFederatedIdentityCredentials -ResourceGroupName $env.ficResourceGroup -IdentityName $env.ficUserIdentityName -Name $env.ficName01
        $fic = Get-AzFederatedIdentityCredentials -InputObject $fic
        $fic.Name | Should -Be $env.ficName01
        $fic.Issuer | Should -Be $env.Issuer01
        $fic.Subject | Should -Be $env.Subject01
        $fic.Audience | Should -Be $env.ficAudience
    }
}
