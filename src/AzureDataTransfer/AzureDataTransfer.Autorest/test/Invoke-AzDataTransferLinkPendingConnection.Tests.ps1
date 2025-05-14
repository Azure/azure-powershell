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

Describe 'Invoke-AzDataTransferLinkPendingConnection' {
    It 'LinkPendingConnection' {
        {
            # Link the pending connection
            Invoke-AzDataTransferLinkPendingConnection -ResourceGroupName $env:ResourceGroupName -ConnectionName $env:ConnectionName -PendingConnectionId $env:PendingConnectionId -StatusReason "Linking approved" -Confirm:$false | Should -BeNullOrEmpty

            # Verify the connection is linked
            $linkedConnection = Get-AzDataTransferConnection -ResourceGroupName $env:ResourceGroupName -Name $env:ConnectionName
            $linkedConnection.Status | Should -Be "Linked"
        } | Should -Not -Throw
    }

    It 'LinkPendingConnection when already linked' {
        {
            # Ensure the connection is already linked
            Invoke-AzDataTransferLinkPendingConnection -ResourceGroupName $env:ResourceGroupName -ConnectionName $env:ConnectionName -PendingConnectionId $env:PendingConnectionId -StatusReason "Linking approved" -Confirm:$false | Should -BeNullOrEmpty

            # Attempt to link the connection again
            Invoke-AzDataTransferLinkPendingConnection -ResourceGroupName $env:ResourceGroupName -ConnectionName $env:ConnectionName -PendingConnectionId $env:PendingConnectionId -StatusReason "Linking approved" -Confirm:$false | Should -BeNullOrEmpty

            # Verify the connection is still linked
            $linkedConnection = Get-AzDataTransferConnection -ResourceGroupName $env:ResourceGroupName -Name $env:ConnectionName
            $linkedConnection.Status | Should -Be "Linked"
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
}
