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

$testRecvFlowName = "test-receive-flow-" + -join ((65..90) + (97..122) | Get-Random -Count 6 | ForEach-Object {[char]$_})
$testSendFlowName = "test-send-flow-" + -join ((65..90) + (97..122) | Get-Random -Count 6 | ForEach-Object {[char]$_})

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

Describe 'Invoke-AzDataTransferLinkPendingFlow' {
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
    }
}
