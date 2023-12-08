if(($null -eq $TestName) -or ($TestName -contains 'New-AzNginxCertificate'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzNginxCertificate.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzNginxCertificate' {
    It 'CreateExpanded' {
        $cert = New-AzNginxCertificate -DeploymentName $env.nginxDeployment1 -Name $env.nginxNewCert -ResourceGroupName $env.resourceGroup -CertificateVirtualPath test.cert -KeyVirtualPath test.key -KeyVaultSecretId https://integration-tests-kv.vault.azure.net/secrets/newcert
        $cert.ProvisioningState | Should -Be 'Succeeded'
    }
}
