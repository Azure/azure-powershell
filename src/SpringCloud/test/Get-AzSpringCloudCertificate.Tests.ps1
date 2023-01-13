if(($null -eq $TestName) -or ($TestName -contains 'Get-AzSpringCloudCertificate'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzSpringCloudCertificate.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzSpringCloudCertificate' {
    It 'List' {
        { Get-AzSpringCloudCertificate -ResourceGroupName $env.resourceGroup -ServiceName $env.standardSpringName01 } | Should -Not -Throw
    }

    It 'CRUD' {
        { 
            $cert = New-AzSpringCloudKeyVaultCertificateObject -Name "springcert" -VaultUri "https://springcloudkv.vault.azure.net" -Version "3e0a7f95f2264f568b6219ae43a131f2" -ExcludePrivateKey $false
            New-AzSpringCloudCertificate -ResourceGroupName $env.resourceGroup -ServiceName $env.standardSpringName01 -Name springcert -Property $cert
            Get-AzSpringCloudCertificate -ResourceGroupName $env.resourceGroup -ServiceName $env.standardSpringName01 -Name springcert
            Remove-AzSpringCloudCertificate -ResourceGroupName $env.resourceGroup -ServiceName $env.standardSpringName01 -Name springcert
        } | Should -Not -Throw
    }
}
