if(($null -eq $TestName) -or ($TestName -contains 'New-AzFederatedIdentityCredentials'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzFederatedIdentityCredentials.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzFederatedIdentityCredentials' {
    It 'CreateExpanded' {
        $fic = New-AzFederatedIdentityCredentials -ResourceGroupName $env.ficResourceGroup -IdentityName $env.ficUserIdentityName -Name $env.ficName02 -Issuer $env.Issuer02 -Subject $env.Subject02
        $fic.Name | Should -Be $env.ficName02
        $fic.Issuer | Should -Be $env.Issuer02
        $fic.Subject | Should -Be $env.Subject02
        $fic.Audience | Should -Be $env.ficAudience
    }
}