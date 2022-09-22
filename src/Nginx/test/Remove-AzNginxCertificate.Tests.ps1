if(($null -eq $TestName) -or ($TestName -contains 'Remove-AzNginxCertificate'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzNginxCertificate.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Remove-AzNginxCertificate' {
    It 'Delete' {
        Remove-AzNginxCertificate -DeploymentName $env.nginxDeployment1 -Name $env.nginxNewCert -ResourceGroupName $env.resourceGroup
        $certList = Get-AzNginxCertificate -DeploymentName $env.nginxDeployment1 -ResourceGroupName $env.resourceGroup
        $certList.Name | Should -Not -Contain $env.nginxNewCert
    }

    It 'DeleteViaIdentity' {
        $cert = New-AzNginxCertificate -DeploymentName $env.nginxDeployment1 -Name $env.nginxNewCert -ResourceGroupName $env.resourceGroup -CertificateVirtualPath test.cert -KeyVirtualPath test.key -KeyVaultSecretId https://integration-tests-kv.vault.azure.net/secrets/newcert
        Remove-AzNginxCertificate -InputObject $cert
        $certList = Get-AzNginxCertificate -DeploymentName $env.nginxDeployment1 -ResourceGroupName $env.resourceGroup
        $certList.Name | Should -Not -Contain $env.nginxNewCert
    }
}
