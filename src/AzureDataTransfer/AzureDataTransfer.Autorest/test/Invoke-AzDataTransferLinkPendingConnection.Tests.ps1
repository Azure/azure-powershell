if(($null -eq $TestName) -or ($TestName -contains 'Invoke-AzDataTransferLinkPendingConnection'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Invoke-AzDataTransferLinkPendingConnection.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

$connectionRecvName = 'test-connection-receive-' + $env.RunId
$connectionSendName = 'test-connection-send-' + $env.RunId

Write-Host "Connection names: $connectionRecvName, $connectionSendName"

$connectionRecvAsJobName = 'test-connection-receive-asjob-' + $env.RunId
$connectionSendAsJobName = 'test-connection-send-asjob-' + $env.RunId

Write-Host "Connection names for AsJob: $connectionRecvAsJobName, $connectionSendAsJobName"

Describe 'Invoke-AzDataTransferLinkPendingConnection' {
    $connectionRecvParams = @{
        Location             = $env.Location
        PipelineName         = $env.PipelineName
        Direction            = "Receive"
        FlowType             = "Mission"
        ResourceGroupName    = $env.ResourceGroupName
        Justification        = "Receive side for PS testing"
        RemoteSubscriptionId = $env.SubscriptionId
        RequirementId        = 0
        Name                 = $connectionRecvName
        PrimaryContact       = "faikh@microsoft.com"
    }
    
    $connectionRecv = New-AzDataTransferConnection @connectionRecvParams
    $connectionRecvApproved = Approve-AzDataTransferConnection -ConnectionId $connectionRecv.Id -StatusReason "Approving for PS testing" -ResourceGroupName  $env.ResourceGroupName -PipelineName  $env.PipelineName
    
    $connectionSendParams = @{
        Location             =  $env.Location
        PipelineName         =  $env.PipelineName
        Direction            = "Send"
        FlowType             = "Mission"
        ResourceGroupName    =  $env.ResourceGroupName
        Justification        = "Send side for PS testing"
        Name                 = $connectionSendName
        PrimaryContact       = "faikh@microsoft.com"
        PIN                  = $connectionRecvApproved.PIN
    }
    $connectionSend = New-AzDataTransferConnection @connectionSendParams
    $connectionSendId = $connectionSend.Id

    It 'LinkPendingConnection' {
        {
            # Link the pending connection
            Invoke-AzDataTransferLinkPendingConnection -ResourceGroupName $env.ResourceGroupName -ConnectionName $connectionRecvName -PendingConnectionId $connectionSendId -StatusReason "Linking for testing" -Confirm:$false

            # Verify the connection is linked
            $linkedConnection = Get-AzDataTransferConnection -ResourceGroupName $env.ResourceGroupName -Name $connectionRecvName
            $linkedConnection.LinkStatus | Should -Be "Linked"
        } | Should -Not -Throw
    }

    It 'LinkPendingConnection when already linked' {
        {
            # Attempt to link the connection again
            { Invoke-AzDataTransferLinkPendingConnection -ResourceGroupName $env.ResourceGroupName -ConnectionName $connectionRecvName -PendingConnectionId $connectionSendId -StatusReason "Linking for testing" -Confirm:$false } | Should -Throw -ErrorId "PendingConnectionAlreadyLinked"

            # Verify the connection is still linked
            $linkedConnection = Get-AzDataTransferConnection -ResourceGroupName $env.ResourceGroupName -Name $connectionRecvName
            $linkedConnection.LinkStatus | Should -Be "Linked"
        } | Should -Not -Throw
    }

    It 'LinkPendingConnection AsJob' {
        {
            $connectionRecvParams = @{
                Location             = $env.Location
                PipelineName         = $env.PipelineName
                Direction            = "Receive"
                FlowType             = "Mission"
                ResourceGroupName    = $env.ResourceGroupName
                Justification        = "Receive side for PS testing"
                RemoteSubscriptionId = $env.SubscriptionId
                RequirementId        = 0
                Name                 = $connectionRecvAsJobName
                PrimaryContact       = "faikh@microsoft.com"
            }
            
            $connectionRecv = New-AzDataTransferConnection @connectionRecvParams
            $connectionRecvApproved = Approve-AzDataTransferConnection -ConnectionId $connectionRecv.Id -StatusReason "Approving for PS testing" -ResourceGroupName  $env.ResourceGroupName -PipelineName  $env.PipelineName
            
            $connectionSendParams = @{
                Location             = $env.Location
                PipelineName         = $env.PipelineName
                Direction            = "Send"
                FlowType             = "Mission"
                ResourceGroupName    = $env.ResourceGroupName
                Justification        = "Send side for PS testing"
                Name                 = $connectionSendAsJobName
                PrimaryContact       = "faikh@microsoft.com"
                PIN                  = $connectionRecvApproved.PIN
            }
            $connectionSend = New-AzDataTransferConnection @connectionSendParams
            $connectionSendId = $connectionSend.Id

            # Link the pending connection as a background job
            $job = Invoke-AzDataTransferLinkPendingConnection -ResourceGroupName $env.ResourceGroupName -ConnectionName $connectionRecvAsJobName -PendingConnectionId $connectionSendId -StatusReason "Linking for testing as a job" -AsJob -Confirm:$false
    
            # Verify the job is created
            $job | Should -Not -BeNullOrEmpty
            ($job.State -eq "Running" -or $job.State -eq "Completed") | Should -Be $true
    
            # Wait for the job to complete
            $job | Wait-Job | Out-Null
            ($job.State -eq "Completed") | Should -Be $true
    
            # Verify the connection is linked after the job completes
            $linkedConnection = Get-AzDataTransferConnection -ResourceGroupName $env.ResourceGroupName -Name $connectionRecvAsJobName
            $linkedConnection.LinkStatus | Should -Be "Linked"
        } | Should -Not -Throw
    }

    It 'LinkViaJsonString' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'LinkViaJsonFilePath' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'Link' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'LinkViaIdentityExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'LinkViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    AfterAll {
        # Clean up the connections
        Remove-AzDataTransferConnection -ResourceGroupName $env.ResourceGroupName -Name $connectionRecvName
        Remove-AzDataTransferConnection -ResourceGroupName $env.ResourceGroupName -Name $connectionSendName
        Remove-AzDataTransferConnection -ResourceGroupName $env.ResourceGroupName -Name $connectionRecvAsJobName
        Remove-AzDataTransferConnection -ResourceGroupName $env.ResourceGroupName -Name $connectionSendAsJobName
    }
}
