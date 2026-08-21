if(($null -eq $TestName) -or ($TestName -contains 'Update-AzStorageMoverS3WithHmacEndpoint'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzStorageMoverS3WithHmacEndpoint.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzStorageMoverS3WithHmacEndpoint' {
    It 'UpdateExpanded' {
        $endpointName = "tests3ep3" + $env.RandomString
        $s3endpoint = New-AzStorageMoverS3WithHmacEndpoint -Name $endpointName -ResourceGroupName $env.ResourceGroupName -StorageMoverName $env.InitialStoMoverName -SourceUri "https://s3.example.com/bucket" -SourceType "MINIO" -CredentialsAccessKeyUri "https://examples-azureKeyVault.vault.azure.net/secrets/examples-accesskey" -CredentialsSecretKeyUri "https://examples-azureKeyVault.vault.azure.net/secrets/examples-secretkey" -Description "new s3 endpoint"
        $s3endpoint = Update-AzStorageMoverS3WithHmacEndpoint -Name $endpointName -ResourceGroupName $env.ResourceGroupName -StorageMoverName $env.InitialStoMoverName -CredentialsAccessKeyUri "https://examples-azureKeyVault.vault.azure.net/secrets/examples-accesskey2" -CredentialsSecretKeyUri "https://examples-azureKeyVault.vault.azure.net/secrets/examples-secretkey2" -Description "update s3 endpoint"
        $s3endpoint.Name | Should -Be $endpointName
        $s3endpoint.Property.CredentialsType | Should -Be "AzureKeyVaultS3WithHMAC"
        $s3endpoint.Property.CredentialsAccessKeyUri | Should -Be "https://examples-azureKeyVault.vault.azure.net/secrets/examples-accesskey2"
        $s3endpoint.Property.CredentialsSecretKeyUri | Should -Be "https://examples-azureKeyVault.vault.azure.net/secrets/examples-secretkey2"
        $s3endpoint.Property.EndpointType | Should -Be "S3WithHMAC"
        $s3endpoint.Property.Description | Should -Be "update s3 endpoint"

        $s3endpoint = Get-AzStorageMoverEndpoint -Name $endpointName -ResourceGroupName $env.ResourceGroupName -StorageMoverName $env.InitialStoMoverName
        $s3endpoint.Name | Should -Be $endpointName
        $s3endpoint.Property.CredentialsType | Should -Be "AzureKeyVaultS3WithHMAC"
        $s3endpoint.Property.CredentialsAccessKeyUri | Should -Be "https://examples-azureKeyVault.vault.azure.net/secrets/examples-accesskey2"
        $s3endpoint.Property.CredentialsSecretKeyUri | Should -Be "https://examples-azureKeyVault.vault.azure.net/secrets/examples-secretkey2"
        $s3endpoint.Property.EndpointType | Should -Be "S3WithHMAC"
        $s3endpoint.Property.Description | Should -Be "update s3 endpoint"
    }
}
