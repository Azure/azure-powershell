if(($null -eq $TestName) -or ($TestName -contains 'New-AzStorageMoverMultiCloudConnectorEndpoint'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzStorageMoverMultiCloudConnectorEndpoint.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzStorageMoverMultiCloudConnectorEndpoint' {
    It 'CreateExpanded' {
        $endpointName = "testMultiCloudConnectorEndpoint" + $env.RandomString
        $description = "MultiCloudConnector endpoint description"
        $multiCloudConnectorId = $env.MultiCloudConnectorId
        $awsS3BucketId = $env.AwsS3BucketId
        $endpoint = New-AzStorageMoverMultiCloudConnectorEndpoint -Name $endpointName -ResourceGroupName $env.ResourceGroupName -StorageMoverName $env.InitialStoMoverName -MultiCloudConnectorId $multiCloudConnectorId -AWSS3BucketId $awsS3BucketId -Description $description 
        $endpoint.Name | Should -Be $endpointName
        $endpoint.Property.endpointType | Should -Be "AzureMultiCloudConnector"
        $endpoint.Property.multiCloudConnectorId | Should -Be $multiCloudConnectorId 
        $endpoint.Property.aWSS3BucketId | Should -Be $awsS3BucketId

        $endpoint = Get-AzStorageMoverEndpoint -Name $endpointName -ResourceGroupName $env.ResourceGroupName -StorageMoverName $env.InitialStoMoverName
        $endpoint.Name | Should -Be $endpointName
        $endpoint.Property.endpointType | Should -Be "AzureMultiCloudConnector"
        $endpoint.Property.multiCloudConnectorId | Should -Be $multiCloudConnectorId 
        $endpoint.Property.aWSS3BucketId | Should -Be $awsS3BucketId
    }

}

Describe 'New-AzStorageMoverMultiCloudConnectorEndpoint RequestContract' -Tag @('PythonParity', 'Offline') {
    It 'CreateExpandedWithEndpointKindRequest' {
        $capture = Invoke-StorageMoverTestRequest -Response @{ properties = @{ endpointType = 'AzureMultiCloudConnector' } } -Command {
            param($pipeline)
            New-AzStorageMoverMultiCloudConnectorEndpoint -Name 'mcckind' -SubscriptionId $env.SubscriptionId -ResourceGroupName 'rg' -StorageMoverName 'mover' -MultiCloudConnectorId $env.MultiCloudConnectorId -AwsS3BucketId $env.AwsS3BucketId -EndpointKind Source -HttpPipelinePrepend $pipeline
        }
        $request = ($capture.Requests[0].Content | ConvertFrom-Json).properties
        $request.endpointKind | Should -Be 'Source'
        $request.multiCloudConnectorId | Should -Be $env.MultiCloudConnectorId
        $request.awsS3BucketId | Should -Be $env.AwsS3BucketId
    }
}

Describe 'New-AzStorageMoverMultiCloudConnectorEndpoint PythonParity' -Tag 'PythonParity' {
    It 'RejectTargetEndpointKind' {
        $context = $null
        try {
            $context = New-StorageMoverTestContext -Name 'sm-mcc-target-validation'
            Invoke-StorageMoverTestFailure -Command {
                New-AzStorageMoverMultiCloudConnectorEndpoint @context -Name 'invalid' -MultiCloudConnectorId $env.ScenarioMultiCloudConnectorId -AwsS3BucketId $env.ScenarioPublicS3BucketId -EndpointKind Target -ErrorAction Stop
            }
        } finally {
            Remove-StorageMoverTestContext -Context $context
        }
    }
}
