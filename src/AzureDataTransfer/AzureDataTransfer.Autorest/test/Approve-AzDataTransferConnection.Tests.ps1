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
    It 'Approve' {
        {
            # Approve the connection
            Approve-AzDataTransferConnection -PipelineName $env:PipelineName -ResourceGroupName $env:ResourceGroupName -ConnectionId $env:ConnectionIdToApprove -StatusReason "Approved for testing" -Confirm:$false | Should -BeNullOrEmpty

            # Verify the connection is approved
            $approvedConnection = Get-AzDataTransferConnection -ResourceGroupName $env:ResourceGroupName -Name $env:ConnectionNameToApprove
            $approvedConnection.Status | Should -Be "Approved"
        } | Should -Not -Throw
    }

    It 'Approve when already approved' {
        {
            # Ensure the connection is already approved
            Approve-AzDataTransferConnection -PipelineName $env:PipelineName -ResourceGroupName $env:ResourceGroupName -ConnectionId $env:ConnectionId -StatusReason "Approved for processing" -Confirm:$false | Should -BeNullOrEmpty

            # Attempt to approve the connection again
            Approve-AzDataTransferConnection -PipelineName $env:PipelineName -ResourceGroupName $env:ResourceGroupName -ConnectionId $env:ConnectionId -StatusReason "Approved for processing" -Confirm:$false | Should -BeNullOrEmpty

            # Verify the connection is still approved
            $approvedConnection = Get-AzDataTransferConnection -ResourceGroupName $env:ResourceGroupName -Name $env:ConnectionName
            $approvedConnection.Status | Should -Be "Approved"
        } | Should -Not -Throw
    }

    It 'Approve when already rejected' {
        {
            # Reject the connection first
            Deny-AzDataTransferConnection -PipelineName $env:PipelineName -ResourceGroupName $env:ResourceGroupName -ConnectionId $env:ConnectionId -StatusReason "Rejected for testing" -Confirm:$false | Should -BeNullOrEmpty

            # Attempt to approve the rejected connection
            Approve-AzDataTransferConnection -PipelineName $env:PipelineName -ResourceGroupName $env:ResourceGroupName -ConnectionId $env:ConnectionId -StatusReason "Approved for processing" -Confirm:$false | Should -BeNullOrEmpty

            # Verify the connection is still rejected
            $rejectedConnection = Get-AzDataTransferConnection -ResourceGroupName $env:ResourceGroupName -Name $env:ConnectionName
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
}
