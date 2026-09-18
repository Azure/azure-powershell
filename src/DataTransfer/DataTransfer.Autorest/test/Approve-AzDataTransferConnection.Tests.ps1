if(($null -eq $TestName) -or ($TestName -contains 'Approve-AzDataTransferConnection'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Approve-AzDataTransferConnection.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

$connectionToApproveName = "test-connection-to-approve-" + $env.RunId
$connectionToApproveAsJobName = "test-connection-to-approve-asjob-" + $env.RunId

Write-Host "Connection names: $connectionToApproveName, $connectionToApproveAsJobName"

Describe 'Approve-AzDataTransferConnection' {
    $connectionParams = @{
        Location             = $env.Location
        PipelineName         = $env.PipelineName
        Direction            = "Receive"
        FlowType             = "Mission"
        ResourceGroupName    = $env.ResourceGroupName
        Justification        = "Receive side for PS testing"
        RemoteSubscriptionId = $env.SubscriptionId
        RequirementId        = 0
        Name                 = $connectionToApproveName
        PrimaryContact       = "faikh@microsoft.com"
    }
    $connectionToApprove = New-AzDataTransferConnection @connectionParams
    $connectionToApproveId = $connectionToApprove.Id

    $connectionAsJobParams = @{
        Location             = $env.Location
        PipelineName         = $env.PipelineName
        Direction            = "Receive"
        FlowType             = "Mission"
        ResourceGroupName    = $env.ResourceGroupName
        Justification        = "Receive side for PS testing"
        RemoteSubscriptionId = $env.SubscriptionId
        RequirementId        = 0
        Name                 = $connectionToApproveAsJobName
        PrimaryContact       = "faikh@microsoft.com"
    }
    $connectionToApproveAsJob = New-AzDataTransferConnection @connectionAsJobParams
    $connectionToApproveAsJobId = $connectionToApproveAsJob.Id

    It 'Approve' {
        {
            # Approve the connection
            $approvedConnection = Approve-AzDataTransferConnection -PipelineName $env.PipelineName -ResourceGroupName $env.ResourceGroupName -ConnectionId $connectionToApproveId -StatusReason "Approving for testing" -Confirm:$false

            # Verify the connection is approved
            $approvedConnection.Status | Should -Be "Approved"
        } | Should -Not -Throw
    }

    It 'Approve when already approved' {
        {
            # Attempt to approve and approved connection
            { Approve-AzDataTransferConnection -PipelineName $env.PipelineName -ResourceGroupName $env.ResourceGroupName -ConnectionId $env.ConnectionApprovedId -StatusReason "Approved for processing" -Confirm:$false } | Should -Throw -ErrorId "ConnectionAlreadyReviewed"

            # Verify the connection is still approved
            $approvedConnection = Get-AzDataTransferConnection -ResourceGroupName $env.ResourceGroupName -Name $env.ConnectionApproved
            $approvedConnection.Status | Should -Be "Approved"
        } | Should -Not -Throw
    }

    It 'Approve when already rejected' {
        {
            # Attempt to approve a rejected connection
            { Approve-AzDataTransferConnection -PipelineName $env.PipelineName -ResourceGroupName $env.ResourceGroupName -ConnectionId $env.ConnectionRejectedId -StatusReason "Approving for testing" -Confirm:$false } | Should -Throw -ErrorId "ConnectionAlreadyReviewed"

            # Verify the connection is still rejected
            $rejectedConnection = Get-AzDataTransferConnection -ResourceGroupName $env.ResourceGroupName -Name $env.ConnectionRejected
            $rejectedConnection.Status | Should -Be "Rejected"
        } | Should -Not -Throw
    }

    It 'Approve AsJob' {
        {
            # Approve the connection as a background job
            $job = Approve-AzDataTransferConnection -PipelineName $env.PipelineName -ResourceGroupName $env.ResourceGroupName -ConnectionId $connectionToApproveAsJobId -StatusReason "Approving as a background job" -AsJob -Confirm:$false
    
            # Verify the job is created
            $job | Should -Not -BeNullOrEmpty
            ($job.State -eq "Running" -or $job.State -eq "Completed") | Should -Be $true
    
            # Wait for the job to complete
            $job | Wait-Job | Out-Null
            ($job.State -eq "Completed") | Should -Be $true
    
            # Verify the connection is approved after the job completes
            $approvedConnection = Get-AzDataTransferConnection -ResourceGroupName $env.ResourceGroupName -Name $connectionToApproveAsJobName
            $approvedConnection.Status | Should -Be "Approved"
        } | Should -Not -Throw
    }

    It 'ApproveExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'ApproveViaJsonString' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'ApproveViaJsonFilePath' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'ApproveViaIdentityExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'ApproveViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    AfterAll {
        # Clean up the connection
        Remove-AzDataTransferConnection -ResourceGroupName $env.ResourceGroupName -Name $connectionToApproveName -Confirm:$false
        Remove-AzDataTransferConnection -ResourceGroupName $env.ResourceGroupName -Name $connectionToApproveAsJobName -Confirm:$false
    }
}
