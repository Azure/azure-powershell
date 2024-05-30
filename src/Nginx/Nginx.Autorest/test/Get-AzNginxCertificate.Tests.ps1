if(($null -eq $TestName) -or ($TestName -contains 'Get-AzNginxCertificate'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzNginxCertificate.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzNginxCertificate' {
    It 'CreateExpanded' {
        $cert = New-AzNginxCertificate -DeploymentName $env.nginxDeployment1 -Name $env.nginxCert -ResourceGroupName $env.resourceGroup -CertificateVirtualPath /etc/nginx/certs/test.cert -KeyVirtualPath /etc/nginx/certs/test.key -KeyVaultSecretId https://integration-tests-kv.vault.azure.net/secrets/newcert
        $cert.ProvisioningState | Should -Be 'Succeeded'
    }

    It 'List' {
        $certList = Get-AzNginxCertificate -DeploymentName $env.nginxDeployment1 -ResourceGroupName $env.resourceGroup
        $certList.Count | Should -Be 2
    }

    It 'Get' {
        $cert = Get-AzNginxCertificate -DeploymentName $env.nginxDeployment1 -Name $env.nginxCert -ResourceGroupName $env.resourceGroup
        $cert.Name | Should -Be $env.nginxCert
    }

    It 'GetViaIdentity' {
        $cert = Get-AzNginxCertificate -DeploymentName $env.nginxDeployment1 -Name $env.nginxCert -ResourceGroupName $env.resourceGroup
        $cert = Get-AzNginxCertificate -InputObject  $cert
        $cert.Name | Should -Be $env.nginxCert
    }
}
