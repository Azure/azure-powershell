if(($null -eq $TestName) -or ($TestName -contains 'Start-AzStorageMoverJobDefinition'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Start-AzStorageMoverJobDefinition.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Start-AzStorageMoverJobDefinition' {
    It 'Start' {
        # Create a dedicated storage mover for this test
        $storageMoverName = "startTestC2C" + $env.RandomString
        New-AzStorageMover -ResourceGroupName $env.ResourceGroupName -Name $storageMoverName -Location $env.Location

        # Create a MultiCloudConnector endpoint as CloudToCloud source
        $endpointName = "startTestC2CSource" + $env.RandomString
        $endpoint = New-AzStorageMoverMultiCloudConnectorEndpoint -Name $endpointName -ResourceGroupName $env.ResourceGroupName -StorageMoverName $storageMoverName -MultiCloudConnectorId $env.MultiCloudConnectorId -AWSS3BucketId $env.AwsS3BucketId -Description "CloudToCloud source for Start test"
        $endpoint.Name | Should -Be $endpointName

        # Create a container endpoint as target
        $targetEndpointName = "startTestC2CTarget" + $env.RandomString
        $targetEndpoint = New-AzStorageMoverAzStorageContainerEndpoint -Name $targetEndpointName -ResourceGroupName $env.ResourceGroupName -StorageMoverName $storageMoverName -BlobContainerName $env.ContainerName -StorageAccountResourceId $env.StoraccId
        $targetEndpoint.IdentityPrincipalId | Should -Not -BeNullOrEmpty

        # Assign Storage Blob Data Contributor role to the container endpoint's managed identity on the storage account
        # Only needed in record/live mode; Az.Resources is not loaded in playback
        if ($TestMode -ne 'playback') {
            $maxRetries = 5
            for ($r = 0; $r -lt $maxRetries; $r++) {
                try {
                    New-AzRoleAssignment -ObjectId $targetEndpoint.IdentityPrincipalId -RoleDefinitionName "Storage Blob Data Contributor" -Scope $env.StoraccId -ErrorAction Stop
                    break
                } catch {
                    if ($r -eq ($maxRetries - 1)) { throw }
                    Start-Sleep -Seconds 10
                }
            }
            Start-Sleep -Seconds 60
        }

        # Create a project
        $projectName = "startTestC2CProj" + $env.RandomString
        New-AzStorageMoverProject -Name $projectName -ResourceGroupName $env.ResourceGroupName -StorageMoverName $storageMoverName

        # Create a CloudToCloud job definition (no agent needed for CloudToCloud)
        $jobName = "startTestC2CJob" + $env.RandomString
        $job = New-AzStorageMoverJobDefinition -Name $jobName -ProjectName $projectName -ResourceGroupName $env.ResourceGroupName -StorageMoverName $storageMoverName -SourceName $endpointName -TargetName $targetEndpointName -CopyMode "Additive" -JobType "CloudToCloud"
        $job.Name | Should -Be $jobName

        # Start the job
        $startResult = Start-AzStorageMoverJobDefinition -JobDefinitionName $jobName -ProjectName $projectName -ResourceGroupName $env.ResourceGroupName -StorageMoverName $storageMoverName
        $startResult | Should -Not -Be $null
        $startResult.JobRunResourceId1 | Should -Not -BeNullOrEmpty

        # Poll the job run status until terminal state
        $jobRunName = $startResult.JobRunResourceId1.Split("/")[-1]
        $maxPolls = 60
        $pollInterval = 30
        $terminalStates = @("Succeeded", "Failed", "Canceled")
        for ($i = 0; $i -lt $maxPolls; $i++) {
            $jobRun = Get-AzStorageMoverJobRun -Name $jobRunName -JobDefinitionName $jobName -ProjectName $projectName -ResourceGroupName $env.ResourceGroupName -StorageMoverName $storageMoverName
            if ($jobRun.Status -in $terminalStates) {
                break
            }
            Start-TestSleep -Seconds $pollInterval
        }
        $jobRun.Status | Should -BeIn @("Succeeded", "Failed", "Canceled")

        # Cleanup by deleting the storage mover
        Remove-AzStorageMover -ResourceGroupName $env.ResourceGroupName -Name $storageMoverName -Force
    }
}
