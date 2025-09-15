if(($null -eq $TestName) -or ($TestName -contains 'Update-AzStorageMoverMultiCloudConnectorEndpoint'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzStorageMoverMultiCloudConnectorEndpoint.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzStorageMoverMultiCloudConnectorEndpoint' {
    It 'UpdateExpanded'  {
        $endpointName = 'testmulticloudconnector' + $env.RandomString
        $description = 'multicloud endpoint description'
        $updateDescription = 'update multicloud endpoint description'
        $multiCloudConnectorId = $env.MultiCloudConnectorId
        $awsS3BucketId = $env.AwsS3BucketId
        $endpoint = New-AzStorageMoverMultiCloudConnectorEndpoint -Name $endpointName -ResourceGroupName $env.ResourceGroupName -StorageMoverName $env.InitialStoMoverName -MultiCloudConnectorId $multiCloudConnectorId -AWSS3BucketId $awsS3BucketId -Description $description 
        $endpoint = Update-AzStorageMoverMultiCloudConnectorEndpoint -Name $endpointName -ResourceGroupName $env.ResourceGroupName -StorageMoverName $env.InitialStoMoverName  -Description $updateDescription
        $endpoint.Name | Should -Be $endpointName
        $endpoint.Property.endpointType | Should -Be "AzureMultiCloudConnector"
        $endpoint.Property.multiCloudConnectorId | Should -Be $multiCloudConnectorId 
        $endpoint.Property.aWSS3BucketId | Should -Be $awsS3BucketId

        $mcEndpoint = Get-AzStorageMoverEndpoint -Name $endpointName -ResourceGroupName $env.ResourceGroupName -StorageMoverName $env.InitialStoMoverName
        $mcEndpoint.Name | Should -Be $endpointName
        $mcEndpoint.Property.Description | Should -Be $updateDescription
    }
}
