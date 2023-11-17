if(($null -eq $TestName) -or ($TestName -contains 'Update-AzFederatedIdentityCredentials'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzFederatedIdentityCredentials.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzFederatedIdentityCredentials' {
    It 'UpdateExpanded' {
        $fic = Update-AzFederatedIdentityCredentials -ResourceGroupName $env.ficResourceGroup -IdentityName $env.ficUserIdentityName -Name $env.ficName01 -Issuer $($env.Issuer01 + "-updated") -Subject $($env.Subject01 + "-updated") -Audience @("updated")
        $fic.Name | Should -Be $env.ficName01
        $fic.Issuer | Should -Be $($env.Issuer01 + "-updated")
        $fic.Subject | Should -Be $($env.Subject01 + "-updated")
        $fic.Audience | Should -Be @("updated")
    }

    It 'UpdateViaIdentityExpanded' {
        $fic = Get-AzFederatedIdentityCredentials -ResourceGroupName $env.ficResourceGroup -IdentityName $env.ficUserIdentityName -Name $env.ficName01
        $fic = Update-AzFederatedIdentityCredentials -InputObject $fic -Issuer $($env.Issuer01 + "-updated2") -Subject $($env.Subject01 + "-updated2") -Audience @("updated2")
        $fic.Name | Should -Be $env.ficName01
        $fic.Issuer | Should -Be $($env.Issuer01 + "-updated2")
        $fic.Subject | Should -Be $($env.Subject01 + "-updated2")
        $fic.Audience | Should -Be @("updated2")
    }
}