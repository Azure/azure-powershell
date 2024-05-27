if(($null -eq $TestName) -or ($TestName -contains 'Get-AzSpringCertificate'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzSpringCertificate.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzSpringCertificate' {
    It 'List' {
        { Get-AzSpringCertificate -ResourceGroupName $env.resourceGroup -ServiceName $env.standardSpringName01 } | Should -Not -Throw
    }

    It 'CRUD' {
        { 
            $cert = New-AzSpringKeyVaultCertificateObject -Name "springcert" -VaultUri "https://Springkv.vault.azure.net" -Version "3e0a7f95f2264f568b6219ae43a131f2" -ExcludePrivateKey $false
            New-AzSpringCertificate -ResourceGroupName $env.resourceGroup -ServiceName $env.standardSpringName01 -Name springcert -Property $cert
            Get-AzSpringCertificate -ResourceGroupName $env.resourceGroup -ServiceName $env.standardSpringName01 -Name springcert
            Remove-AzSpringCertificate -ResourceGroupName $env.resourceGroup -ServiceName $env.standardSpringName01 -Name springcert
        } | Should -Not -Throw
    }
}
