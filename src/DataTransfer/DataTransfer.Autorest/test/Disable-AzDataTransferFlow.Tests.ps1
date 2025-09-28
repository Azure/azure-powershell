if(($null -eq $TestName) -or ($TestName -contains 'Disable-AzDataTransferFlow'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Disable-AzDataTransferFlow.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

$recvFlowToDisable = "test-flow-to-disable-1"
$sendFlowToDisable = "test-flow-to-disable-2"

Describe 'Disable-AzDataTransferFlow' {
    $rcvFlowParams = @{
        ResourceGroupName     = $env.ResourceGroupName
        ConnectionName        = $env.ConnectionLinked
        Name                  = $recvFlowToDisable
        Location              = $env.Location
        FlowType              = "Mission"
        DataType              = "Blob"
        StorageAccountName    = $env.StorageAccountName
        StorageContainerName  = $env.StorageContainerName
    }

    $createdRcvFlow =  New-AzDataTransferFlow @rcvFlowParams

    $sendFlowParams = @{
        ResourceGroupName     = $env.ResourceGroupName
        ConnectionName        = $env.ConnectionLinkedSend
        Name                  = $sendFlowToDisable
        Location              = $env.Location
        FlowType              = "Mission"
        DataType              = "Blob"
        StorageAccountName    = $env.StorageAccountName
        StorageContainerName  = $env.StorageContainerName
    }
    $createdSendFlow =  New-AzDataTransferFlow @sendFlowParams

    Invoke-AzDataTransferLinkPendingFlow -ResourceGroupName $env.ResourceGroupName -ConnectionName $env.ConnectionLinked -PendingFlowId $createdSendFlow.Id -FlowName $createdRcvFlow.Name -Confirm:$false

    Enable-AzDataTransferFlow -ResourceGroupName $env.ResourceGroupName -ConnectionName $env.ConnectionLinkedSend -Name $sendFlowToDisable -Confirm:$false

    It 'Disable' {
        {
            # Disable the flow
            $disabledFlow = Disable-AzDataTransferFlow -ResourceGroupName $env.ResourceGroupName -ConnectionName $env.ConnectionLinked -Name $recvFlowToDisable -Confirm:$false

            # Verify the flow is disabled
            $disabledFlow.Status | Should -Be "Disabled"
        } | Should -Not -Throw
    }

    It 'Disable when already disabled' {
        {
            # Attempt to disable the flow again
            $disabledFlow = Disable-AzDataTransferFlow -ResourceGroupName $env.ResourceGroupName -ConnectionName $env.ConnectionLinked -Name $recvFlowToDisable -Confirm:$false

            # Verify the flow is still disabled
            $disabledFlow.Status | Should -Be "Disabled"
        } | Should -Not -Throw
    }

    It 'Disable AsJob' {
        {
            # Disable the flow as a background job
            $job = Disable-AzDataTransferFlow -ResourceGroupName $env.ResourceGroupName -ConnectionName $env.ConnectionLinkedSend -Name $sendFlowToDisable -AsJob -Confirm:$false
    
            # Verify the job is created
            $job | Should -Not -BeNullOrEmpty
            ($job.State -eq "Running" -or $job.State -eq "Completed") | Should -Be $true
    
            # Wait for the job to complete
            $job | Wait-Job | Out-Null
            ($job.State -eq "Completed") | Should -Be $true
    
            # Verify the flow is disabled after the job completes
            $disabledFlow = Get-AzDataTransferFlow -ResourceGroupName $env.ResourceGroupName -ConnectionName $env.ConnectionLinkedSend -Name $sendFlowToDisable
            $disabledFlow | Should -Not -BeNullOrEmpty
            $disabledFlow.Status | Should -Be "Disabled"
        } | Should -Not -Throw
    }

    It 'DisableViaIdentityConnection' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'DisableViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    AfterAll {
        # Remove-AzDataTransferFlow -ConnectionName $env.ConnectionLinked -ResourceGroupName $env.ResourceGroupName -Name $flowToDisable -Confirm:$false
    }
}
