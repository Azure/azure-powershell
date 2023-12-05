if(($null -eq $TestName) -or ($TestName -contains 'Remove-AzFederatedIdentityCredential'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzFederatedIdentityCredential.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Remove-AzFederatedIdentityCredential' {
    It 'Delete' {
        Remove-AzFederatedIdentityCredential -ResourceGroupName $env.ficResourceGroup -IdentityName $env.ficUserIdentityName -Name $env.ficName02
        $ficList = Get-AzFederatedIdentityCredential -ResourceGroupName $env.ficResourceGroup -IdentityName $env.ficUserIdentityName
        $ficList.Name | Should -Not -Contain $env.ficName02
    }

    It 'DeleteViaIdentityAlias' {
        $fic = New-AzFederatedIdentityCredentials -ResourceGroupName $env.ficResourceGroup -IdentityName $env.ficUserIdentityName -Name $env.ficName03 -Issuer $env.Issuer03 -Subject $env.Subject03
        Remove-AzFederatedIdentityCredentials -InputObject $fic
        $ficList = Get-AzFederatedIdentityCredentials -ResourceGroupName $env.ficResourceGroup -IdentityName $env.ficUserIdentityName
        $ficList.Name | Should -Not -Contain $env.ficName03
    }
}
