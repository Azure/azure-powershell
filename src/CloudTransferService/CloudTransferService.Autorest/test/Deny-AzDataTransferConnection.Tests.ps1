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
    It 'Deny' {
        {
            # Deny the connection
            Deny-AzDataTransferConnection -PipelineName $env:PipelineName -ResourceGroupName $env:ResourceGroupName -ConnectionId $env:ConnectionId -StatusReason "Rejected for testing" -Confirm:$false | Should -BeNullOrEmpty

            # Verify the connection is denied
            $deniedConnection = Get-AzDataTransferConnection -ResourceGroupName $env:ResourceGroupName -Name $env:ConnectionName
            $deniedConnection.Status | Should -Be "Rejected"
        } | Should -Not -Throw
    }

    It 'Deny when already denied' {
        {
            # Ensure the connection is already denied
            Deny-AzDataTransferConnection -PipelineName $env:PipelineName -ResourceGroupName $env:ResourceGroupName -ConnectionId $env:ConnectionId -StatusReason "Rejected for testing" -Confirm:$false | Should -BeNullOrEmpty

            # Attempt to deny the connection again
            Deny-AzDataTransferConnection -PipelineName $env:PipelineName -ResourceGroupName $env:ResourceGroupName -ConnectionId $env:ConnectionId -StatusReason "Rejected for testing" -Confirm:$false | Should -BeNullOrEmpty

            # Verify the connection is still denied
            $deniedConnection = Get-AzDataTransferConnection -ResourceGroupName $env:ResourceGroupName -Name $env:ConnectionName
            $deniedConnection.Status | Should -Be "Rejected"
        } | Should -Not -Throw
    }

    It 'Deny when already approved' {
        {
            # Approve the connection first
            Approve-AzDataTransferConnection -PipelineName $env:PipelineName -ResourceGroupName $env:ResourceGroupName -ConnectionId $env:ConnectionId -StatusReason "Approved for testing" -Confirm:$false | Should -BeNullOrEmpty

            # Attempt to deny the approved connection
            Deny-AzDataTransferConnection -PipelineName $env:PipelineName -ResourceGroupName $env:ResourceGroupName -ConnectionId $env:ConnectionId -StatusReason "Rejected for testing" -Confirm:$false | Should -BeNullOrEmpty

            # Verify the connection is now denied
            $deniedConnection = Get-AzDataTransferConnection -ResourceGroupName $env:ResourceGroupName -Name $env:ConnectionName
            $deniedConnection.Status | Should -Be "Rejected"
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
