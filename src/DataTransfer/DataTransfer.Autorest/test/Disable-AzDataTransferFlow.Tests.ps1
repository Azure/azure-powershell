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

Describe 'Disable-AzDataTransferFlow' {
    It 'Disable' {
        {
            # Disable the flow
            $disabledFlow = Disable-AzDataTransferFlow -ResourceGroupName $env.ResourceGroupName -ConnectionName $env.ConnectionLinkedSend -Name $env.SendFlow -Confirm:$false

            # Verify the flow is disabled
            $disabledFlow.Status | Should -Be "Disabled"
        } | Should -Not -Throw
    }

    It 'Disable when already disabled' {
        {
            # Attempt to disable the flow again
            $disabledFlow = Disable-AzDataTransferFlow -ResourceGroupName $env.ResourceGroupName -ConnectionName $env.ConnectionLinkedSend -Name $env.DisabledFlow -Confirm:$false

            # Verify the flow is still disabled
            $disabledFlow.Status | Should -Be "Disabled"
        } | Should -Not -Throw
    }

    It 'Disable AsJob' {
        {
            # Disable the flow as a background job
            $job = Disable-AzDataTransferFlow -ResourceGroupName $env.ResourceGroupName -ConnectionName $env.ConnectionLinkedSend -Name $env.SendFlow -AsJob -Confirm:$false
    
            # Verify the job is created
            $job | Should -Not -BeNullOrEmpty
            ($job.State -eq "Running" -or $job.State -eq "Completed") | Should -Be $true
    
            # Wait for the job to complete
            $job | Wait-Job | Out-Null
            ($job.State -eq "Completed") | Should -Be $true
    
            # Verify the flow is disabled after the job completes
            $disabledFlow = Get-AzDataTransferFlow -ResourceGroupName $env.ResourceGroupName -ConnectionName $env.ConnectionLinkedSend -Name $env.SendFlow
            $disabledFlow.Status | Should -Be "Disabled"
        } | Should -Not -Throw
    }

    It 'DisableViaIdentityConnection' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'DisableViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
