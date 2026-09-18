if(($null -eq $TestName) -or ($TestName -contains 'Invoke-AzDataTransferLinkPendingFlow'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Invoke-AzDataTransferLinkPendingFlow.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

$testRecvFlowName = "test-receive-flow-" + $env.RunId
$testSendFlowName = "test-send-flow-" + $env.RunId

Write-Host "Flow names: $testRecvFlowName, $testSendFlowName"

$testRecvFlowAsJobName = "test-receive-flow-asjob-" + $env.RunId
$testSendFlowAsJobName = "test-send-flow-asjob-" + $env.RunId

Write-Host "Flow names for AsJob: $testRecvFlowAsJobName, $testSendFlowAsJobName"

Describe 'Invoke-AzDataTransferLinkPendingFlow' {
    $recvFlowParams = @{
        ResourceGroupName     = $env.ResourceGroupName
        ConnectionName        = $env.ConnectionLinked
        Name                  = $testRecvFlowName
        Location              = $env.Location
        FlowType              = "Mission"
        DataType              = "Blob"
        StorageAccountName    = $env.StorageAccountName
        StorageContainerName  = $env.StorageContainerName
     }
     
    $testRecvFlow = New-AzDataTransferFlow @recvFlowParams
    
    $sendFlowParams = @{
        ResourceGroupName     = $env.ResourceGroupName
        ConnectionName        = $env.ConnectionLinkedSend
        Name                  = $testSendFlowName
        Location              = $env.Location
        FlowType              = "Mission"
        DataType              = "Blob"
        StorageAccountName    = $env.StorageAccountName
        StorageContainerName  = $env.StorageContainerName
    }
    
    $testSendFlow = New-AzDataTransferFlow @sendFlowParams
    It 'LinkPendingFlow' {
        {
            # Link the pending flow
            Invoke-AzDataTransferLinkPendingFlow -ResourceGroupName $env.ResourceGroupName -ConnectionName $env.ConnectionLinked -FlowName $testRecvFlowName -PendingFlowId $testSendFlow.Id -StatusReason "Linking for testing" -Confirm:$false

            # Verify the flow is linked
            $linkedFlow = Get-AzDataTransferFlow -ResourceGroupName $env.ResourceGroupName -ConnectionName $env.ConnectionLinked -Name $testRecvFlowName
            $linkedFlow.LinkStatus | Should -Be "Linked"
        } | Should -Not -Throw
    }

    It 'LinkPendingFlow when already linked' {
        {
            # Link the pending flow
            { Invoke-AzDataTransferLinkPendingFlow -ResourceGroupName $env.ResourceGroupName -ConnectionName $env.ConnectionLinked -FlowName $testRecvFlowName -PendingFlowId $testSendFlow.Id -StatusReason "Linking for testing" -Confirm:$false } | Should -Throw -ErrorId "AlreadyLinked"

            # Verify the flow is linked
            $linkedFlow = Get-AzDataTransferFlow -ResourceGroupName $env.ResourceGroupName -ConnectionName $env.ConnectionLinked -Name $testRecvFlowName
            $linkedFlow.LinkStatus | Should -Be "Linked"
        } | Should -Not -Throw
    }

    It 'LinkPendingFlow AsJob' {
        {
            $recvFlowParams = @{
                ResourceGroupName     = $env.ResourceGroupName
                ConnectionName        = $env.ConnectionLinked
                Name                  = $testRecvFlowAsJobName
                Location              = $env.Location
                FlowType              = "Mission"
                DataType              = "Blob"
                StorageAccountName    = $env.StorageAccountName
                StorageContainerName  = $env.StorageContainerName
             }
             
            $testRecvFlowAsJob = New-AzDataTransferFlow @recvFlowParams
            
            $sendFlowParams = @{
                ResourceGroupName     = $env.ResourceGroupName
                ConnectionName        = $env.ConnectionLinkedSend
                Name                  = $testSendFlowAsJobName
                Location              = $env.Location
                FlowType              = "Mission"
                DataType              = "Blob"
                StorageAccountName    = $env.StorageAccountName
                StorageContainerName  = $env.StorageContainerName
            }
            
            $testSendFlowAsJob = New-AzDataTransferFlow @sendFlowParams

            # Link the pending flow as a background job
            $job = Invoke-AzDataTransferLinkPendingFlow -ResourceGroupName $env.ResourceGroupName -ConnectionName $env.ConnectionLinked -FlowName $testRecvFlowAsJobName -PendingFlowId $testSendFlowAsJob.Id -StatusReason "Linking for testing as a job" -AsJob -Confirm:$false
    
            # Verify the job is created
            $job | Should -Not -BeNullOrEmpty
            ($job.State -eq "Running" -or $job.State -eq "Completed") | Should -Be $true
    
            # Wait for the job to complete
            $job | Wait-Job | Out-Null
            ($job.State -eq "Completed") | Should -Be $true
    
            # Verify the flow is linked after the job completes
            $linkedFlow = Get-AzDataTransferFlow -ResourceGroupName $env.ResourceGroupName -ConnectionName $env.ConnectionLinked -Name $testRecvFlowAsJobName
            $linkedFlow.LinkStatus | Should -Be "Linked"
        } | Should -Not -Throw
    }

    It 'LinkViaJsonString' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'LinkViaJsonFilePath' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'LinkViaIdentityConnectionExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'LinkViaIdentityConnection' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'LinkViaIdentityExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'LinkViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    AfterAll {
        # Clean up the flows
        Remove-AzDataTransferFlow -ResourceGroupName $env.ResourceGroupName -ConnectionName $env.ConnectionLinked -Name $testRecvFlowName
        Remove-AzDataTransferFlow -ResourceGroupName $env.ResourceGroupName -ConnectionName $env.ConnectionLinkedSend -Name $testSendFlowName
        Remove-AzDataTransferFlow -ResourceGroupName $env.ResourceGroupName -ConnectionName $env.ConnectionLinked -Name $testRecvFlowAsJobName
        Remove-AzDataTransferFlow -ResourceGroupName $env.ResourceGroupName -ConnectionName $env.ConnectionLinkedSend -Name $testSendFlowAsJobName
    }
}
