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
    It 'List' {
        $certList = Get-AzNginxCertificate -DeploymentName $env.nginxDeployment1 -ResourceGroupName $env.resourceGroup
        $certList.Count | Should -Be 1
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
