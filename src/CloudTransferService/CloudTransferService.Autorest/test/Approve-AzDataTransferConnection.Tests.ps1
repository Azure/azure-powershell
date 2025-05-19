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

Describe 'Approve-AzDataTransferConnection' {
    $connectionToApprove = "test-connection-to-approve-" + -join ((65..90) + (97..122) | Get-Random -Count 6 | ForEach-Object {[char]$_})
    $connectionParams = @{
        Location             =  $env.Location
        PipelineName         =  $env.PipelineName
        Direction            = "Receive"
        FlowType             = "Mission"
        ResourceGroupName    =  $env.ResourceGroupName
        Justification        = "Receive side for PS testing"
        RemoteSubscriptionId =  $env.SubscriptionId
        RequirementId        = 0
        Name                 = $connectionToApprove
        PrimaryContact       = "faikh@microsoft.com"
    }
    New-AzDataTransferConnection @connectionParams
    $subId = $env.SubcriptionId
    $rgName = $env.ResourceGroupName
    $connectionToApproveId = "/subscriptions/$subId/resourceGroups/$rgName/providers/Private.AzureDataTransfer/connections/$connectionToApprove"

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
            Approve-AzDataTransferConnection -PipelineName $env.PipelineName -ResourceGroupName $env.ResourceGroupName -ConnectionId $env.ConnectionApprovedId -StatusReason "Approved for processing" -Confirm:$false | Should -Throw

            # Verify the connection is still approved
            $approvedConnection = Get-AzDataTransferConnection -ResourceGroupName $env.ResourceGroupName -Name $env.ConnectionApproved
            $approvedConnection.Status | Should -Be "Approved"
        } | Should -Not -Throw
    }

    It 'Approve when already rejected' {
        {
            $connec
            # Attempt to approve a rejected connection
            Approve-AzDataTransferConnection -PipelineName $env.PipelineName -ResourceGroupName $env.ResourceGroupName -ConnectionId $env.ConnectionRejectedId -StatusReason "Approving for testing" -Confirm:$false | Should -Throw

            # Verify the connection is still rejected
            $rejectedConnection = Get-AzDataTransferConnection -ResourceGroupName $env.ResourceGroupName -Name $env.ConnectionRejected
            $rejectedConnection.Status | Should -Be "Rejected"
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
        Remove-AzDataTransferConnection -PipelineName $env.PipelineName -ResourceGroupName $env.ResourceGroupName -Name $connectionToApprove -Confirm:$false | Should -Not -Throw
    }
}
