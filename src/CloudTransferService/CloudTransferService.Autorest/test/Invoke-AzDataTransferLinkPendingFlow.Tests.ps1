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

Describe 'Invoke-AzDataTransferLinkPendingFlow' {
    It 'LinkPendingFlow' {
        {
            # Link the pending flow
            Invoke-AzDataTransferLinkPendingFlow -ResourceGroupName $env:ResourceGroupName -ConnectionName $env:ConnectionName -FlowName $env:FlowName -PendingFlowId $env:PendingFlowId -StatusReason "Linking approved" -Confirm:$false | Should -BeNullOrEmpty

            # Verify the flow is linked
            $linkedFlow = Get-AzDataTransferFlow -ResourceGroupName $env:ResourceGroupName -ConnectionName $env:ConnectionName -Name $env:FlowName
            $linkedFlow.Status | Should -Be "Linked"
        } | Should -Not -Throw
    }

    It 'LinkPendingFlow when already linked' {
        {
            # Ensure the flow is already linked
            Invoke-AzDataTransferLinkPendingFlow -ResourceGroupName $env:ResourceGroupName -ConnectionName $env:ConnectionName -FlowName $env:FlowName -PendingFlowId $env:PendingFlowId -StatusReason "Linking approved" -Confirm:$false | Should -BeNullOrEmpty

            # Attempt to link the flow again
            Invoke-AzDataTransferLinkPendingFlow -ResourceGroupName $env:ResourceGroupName -ConnectionName $env:ConnectionName -FlowName $env:FlowName -PendingFlowId $env:PendingFlowId -StatusReason "Linking approved" -Confirm:$false | Should -BeNullOrEmpty

            # Verify the flow is still linked
            $linkedFlow = Get-AzDataTransferFlow -ResourceGroupName $env:ResourceGroupName -ConnectionName $env:ConnectionName -Name $env:FlowName
            $linkedFlow.Status | Should -Be "Linked"
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
}
