if(($null -eq $TestName) -or ($TestName -contains 'New-AzStorageMoverS3WithHmacEndpoint'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzStorageMoverS3WithHmacEndpoint.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzStorageMoverS3WithHmacEndpoint' {
    It 'CreateExpanded' {
        $endpointName = "tests3ep1" + $env.RandomString
        $s3endpoint = New-AzStorageMoverS3WithHmacEndpoint -Name $endpointName -ResourceGroupName $env.ResourceGroupName -StorageMoverName $env.InitialStoMoverName -SourceUri "https://s3.example.com/bucket" -SourceType "MINIO" -CredentialsAccessKeyUri "https://examples-azureKeyVault.vault.azure.net/secrets/examples-accesskey" -CredentialsSecretKeyUri "https://examples-azureKeyVault.vault.azure.net/secrets/examples-secretkey" -Description "new s3 endpoint"
        $s3endpoint.Name | Should -Be $endpointName
        $s3endpoint.Property.CredentialsType | Should -Be "AzureKeyVaultS3WithHMAC"
        $s3endpoint.Property.CredentialsAccessKeyUri | Should -Be "https://examples-azureKeyVault.vault.azure.net/secrets/examples-accesskey"
        $s3endpoint.Property.CredentialsSecretKeyUri | Should -Be "https://examples-azureKeyVault.vault.azure.net/secrets/examples-secretkey"
        $s3endpoint.Property.EndpointType | Should -Be "S3WithHMAC"
        $s3endpoint.Property.SourceUri | Should -Be "https://s3.example.com/bucket"
        $s3endpoint.Property.SourceType | Should -Be "MINIO"
        $s3endpoint.Property.Description | Should -Be "new s3 endpoint"

        $s3endpoint = Get-AzStorageMoverEndpoint -Name $endpointName -ResourceGroupName $env.ResourceGroupName -StorageMoverName $env.InitialStoMoverName
        $s3endpoint.Name | Should -Be $endpointName
        $s3endpoint.Property.CredentialsType | Should -Be "AzureKeyVaultS3WithHMAC"
        $s3endpoint.Property.CredentialsAccessKeyUri | Should -Be "https://examples-azureKeyVault.vault.azure.net/secrets/examples-accesskey"
        $s3endpoint.Property.CredentialsSecretKeyUri | Should -Be "https://examples-azureKeyVault.vault.azure.net/secrets/examples-secretkey"
        $s3endpoint.Property.EndpointType | Should -Be "S3WithHMAC"
        $s3endpoint.Property.SourceUri | Should -Be "https://s3.example.com/bucket"
        $s3endpoint.Property.SourceType | Should -Be "MINIO"
        $s3endpoint.Property.Description | Should -Be "new s3 endpoint"
    }

    It 'CreateWithOtherSourceType' {
        $endpointName = "tests3ep2" + $env.RandomString
        $s3endpoint = New-AzStorageMoverS3WithHmacEndpoint -Name $endpointName -ResourceGroupName $env.ResourceGroupName -StorageMoverName $env.InitialStoMoverName -SourceUri "https://s3.custom.com/bucket" -SourceType "OTHER" -OtherSourceTypeDescription "Custom S3 provider" -CredentialsAccessKeyUri "https://examples-azureKeyVault.vault.azure.net/secrets/examples-accesskey" -CredentialsSecretKeyUri "https://examples-azureKeyVault.vault.azure.net/secrets/examples-secretkey" -Description "s3 other source"
        $s3endpoint.Name | Should -Be $endpointName
        $s3endpoint.Property.EndpointType | Should -Be "S3WithHMAC"
        $s3endpoint.Property.SourceType | Should -Be "OTHER"
        $s3endpoint.Property.OtherSourceTypeDescription | Should -Be "Custom S3 provider"
        $s3endpoint.Property.Description | Should -Be "s3 other source"
    }
}
