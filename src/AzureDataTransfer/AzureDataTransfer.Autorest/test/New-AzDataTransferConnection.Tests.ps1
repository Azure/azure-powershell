if(($null -eq $TestName) -or ($TestName -contains 'New-AzDataTransferConnection'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzDataTransferConnection.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

$connectionToCreate = "test-connection-create-" + $env.RunId
$connectionToCreateAsJob = "test-connection-create-as-job-" + $env.RunId

Write-Host "Connection names - $connectionToCreate, $connectionToCreateAsJob"

Describe 'New-AzDataTransferConnection' {
    $connectionParams = @{
        Location             = $env.Location
        PipelineName         = $env.PipelineName
        Direction            = "Receive"
        FlowType             = "Mission"
        ResourceGroupName    = $env.ResourceGroupName
        Justification        = "Receive side for PS testing"
        RemoteSubscriptionId = $env.SubscriptionId
        RequirementId        = 0
        Name                 = $connectionToCreate
        PrimaryContact       = "faikh@microsoft.com"
    }

    It 'CreateNewConnection' {
        {
            # Create a new connection
            $createdConnection = New-AzDataTransferConnection @connectionParams

            # Verify the connection is created
            $createdConnection | Should -Not -BeNullOrEmpty
            $createdConnection.Name | Should -Be $connectionToCreate
            $createdConnection.Location | Should -Be $env.Location
            $createdConnection.Pipeline | Should -Be $env.PipelineName
            $createdConnection.Direction | Should -Be "Receive"
            $createdConnection.FlowType | Should -Be "Mission"
            $createdConnection.ResourceGroupName | Should -Be $env.ResourceGroupName
            $createdConnection.RemoteSubscriptionId | Should -Be $env.SubscriptionId
            $createdConnection.RequirementId | Should -Be 0
        } | Should -Not -Throw
    }

    It 'CreateExistingConnection' {
        {
            # Ensure the connection already exists
            { New-AzDataTransferConnection @connectionParams } | Should -Throw -ErrorId "ConnectionAlreadyExists"
    
            # Verify the connection still exists and no duplicate is created
            $existingConnection = Get-AzDataTransferConnection -ResourceGroupName $env.ResourceGroupName -Name $connectionToCreate
            $existingConnection | Should -Not -BeNullOrEmpty
            $existingConnection.Name | Should -Be $connectionToCreate
        } | Should -Not -Throw
    }

    It 'CreateNewConnection AsJob' {
        {
            $connectionParams = @{
                Location             = $env.Location
                PipelineName         = $env.PipelineName
                Direction            = "Receive"
                FlowType             = "Mission"
                ResourceGroupName    = $env.ResourceGroupName
                Justification        = "Receive side for PS testing"
                RemoteSubscriptionId = $env.SubscriptionId
                RequirementId        = 0
                Name                 = $connectionToCreateAsJob
                PrimaryContact       = "faikh@microsoft.com"
            }

            # Create a new connection as a background job
            $job = New-AzDataTransferConnection @connectionParams -AsJob -Confirm:$false
    
            # Verify the job is created
            $job | Should -Not -BeNullOrEmpty
            ($job.State -eq "Running" -or $job.State -eq "Completed") | Should -Be $true
    
            # Wait for the job to complete
            $job | Wait-Job | Out-Null
            ($job.State -eq "Completed") | Should -Be $true
    
            # Verify the connection is created after the job completes
            $createdConnection = Get-AzDataTransferConnection -ResourceGroupName $env.ResourceGroupName -Name $connectionToCreateAsJob
            $createdConnection | Should -Not -BeNullOrEmpty
            $createdConnection.Name | Should -Be $connectionToCreateAsJob
            $createdConnection.Location | Should -Be $env.Location
            $createdConnection.Pipeline | Should -Be $env.PipelineName
            $createdConnection.Direction | Should -Be "Receive"
            $createdConnection.FlowType | Should -Be "Mission"
            $createdConnection.ResourceGroupName | Should -Be $env.ResourceGroupName
            $createdConnection.RemoteSubscriptionId | Should -Be $env.SubscriptionId
            $createdConnection.RequirementId | Should -Be 0
        } | Should -Not -Throw
    }

    It 'CreateViaJsonFilePath' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'CreateViaJsonString' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    AfterAll {
        # Clean up the created connection
        Remove-AzDataTransferConnection -ResourceGroupName $env.ResourceGroupName -Name $connectionToCreate
        Remove-AzDataTransferConnection -ResourceGroupName $env.ResourceGroupName -Name $connectionToCreateAsJob
    }
}
