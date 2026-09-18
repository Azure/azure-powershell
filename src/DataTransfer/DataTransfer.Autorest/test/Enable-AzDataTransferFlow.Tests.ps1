if(($null -eq $TestName) -or ($TestName -contains 'Enable-AzDataTransferFlow'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Enable-AzDataTransferFlow.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Enable-AzDataTransferFlow' {
    It 'Enable' {
        {
            # Enable the flow
            $enabledFlow = Enable-AzDataTransferFlow -ResourceGroupName $env.ResourceGroupName -ConnectionName $env.ConnectionLinked -Name $env.RecvFlow -Confirm:$false

            # Verify the flow is enabled
            $enabledFlow.Status | Should -Be "Enabled"
        } | Should -Not -Throw
    }

    It 'Enable when already enabled' {
        {
            # Attempt to enable the flow again
            $enabledFlow = Enable-AzDataTransferFlow -ResourceGroupName $env.ResourceGroupName -ConnectionName $env.ConnectionLinked -Name $env.EnabledFlow -Confirm:$false

            # Verify the flow is still enabled
            $enabledFlow.Status | Should -Be "Enabled"
        } | Should -Not -Throw
    }

    It 'Enable AsJob' {
        {
            # Enable the flow as a background job
            $job = Enable-AzDataTransferFlow -ResourceGroupName $env.ResourceGroupName -ConnectionName $env.ConnectionLinked -Name $env.RecvFlow -AsJob -Confirm:$false
    
            # Verify the job is created
            $job | Should -Not -BeNullOrEmpty
            ($job.State -eq "Running" -or $job.State -eq "Completed") | Should -Be $true
    
            # Wait for the job to complete
            $job | Wait-Job | Out-Null
            ($job.State -eq "Completed") | Should -Be $true
    
            # Verify the flow is enabled after the job completes
            $enabledFlow = Get-AzDataTransferFlow -ResourceGroupName $env.ResourceGroupName -ConnectionName $env.ConnectionLinked -Name $env.RecvFlow
            $enabledFlow.Status | Should -Be "Enabled"
        } | Should -Not -Throw
    }

    It 'EnableViaIdentityConnection' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'EnableViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
