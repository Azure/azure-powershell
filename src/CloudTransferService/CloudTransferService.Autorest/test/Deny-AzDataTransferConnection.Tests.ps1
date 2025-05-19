if(($null -eq $TestName) -or ($TestName -contains 'Deny-AzDataTransferConnection'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Deny-AzDataTransferConnection.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Deny-AzDataTransferConnection' {
    $connectionToDeny = "test-connection-to-deny-" + -join ((65..90) + (97..122) | Get-Random -Count 6 | ForEach-Object {[char]$_})
    $connectionParams = @{
        Location             =  $env.Location
        PipelineName         =  $env.PipelineName
        Direction            = "Receive"
        FlowType             = "Mission"
        ResourceGroupName    =  $env.ResourceGroupName
        Justification        = "Receive side for PS testing"
        RemoteSubscriptionId =  $env.SubscriptionId
        RequirementId        = 0
        Name                 = $connectionToDeny
        PrimaryContact       = "faikh@microsoft.com"
    }
    New-AzDataTransferConnection @connectionParams
    $subId = $env.SubcriptionId
    $rgName = $env.ResourceGroupName
    $connectionToDenyId = "/subscriptions/$subId/resourceGroups/$rgName/providers/Private.AzureDataTransfer/connections/$connectionToDeny"

    It 'Deny' {
        {
            # Deny the connection
            $deniedConnection = Deny-AzDataTransferConnection -PipelineName $env:PipelineName -ResourceGroupName $env:ResourceGroupName -ConnectionId $connectionToDenyId -StatusReason "Rejected for testing" -Confirm:$false | Should -Not -Throw

            # Verify the connection is denied
            $deniedConnection.Status | Should -Be "Rejected"
        } | Should -Not -Throw
    }

    It 'Deny when already denied' {
        {
            # Ensure the connection is already denied
            Deny-AzDataTransferConnection -PipelineName $env:PipelineName -ResourceGroupName $env:ResourceGroupName -ConnectionId $env:ConnectionRejectedId -StatusReason "Rejected for testing" -Confirm:$false | Should -Throw

            # Verify the connection is still denied
            $deniedConnection = Get-AzDataTransferConnection -ResourceGroupName $env:ResourceGroupName -Name $env:ConnectionRejected
            $deniedConnection.Status | Should -Be "Rejected"
        } | Should -Not -Throw
    }

    It 'Deny when already approved' {
        {
            # Attempt to deny the approved connection
            Deny-AzDataTransferConnection -PipelineName $env:PipelineName -ResourceGroupName $env:ResourceGroupName -ConnectionId $env:ConnectionApprovedId -StatusReason "Rejecting for testing" -Confirm:$false | Should -Throw

            # Verify the connection is now denied
            $approvedConnection = Get-AzDataTransferConnection -ResourceGroupName $env:ResourceGroupName -Name $env:ConnectionApproved
            $deniedConnection.Status | Should -Be "Approved"
        } | Should -Not -Throw
    }
    
    It 'RejectExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'RejectViaJsonString' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'RejectViaJsonFilePath' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'RejectViaIdentityExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'RejectViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
