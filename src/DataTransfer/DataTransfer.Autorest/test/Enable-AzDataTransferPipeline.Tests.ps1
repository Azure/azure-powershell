if(($null -eq $TestName) -or ($TestName -contains 'Enable-AzDataTransferPipeline'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Enable-AzDataTransferPipeline.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Enable-AzDataTransferPipeline' {
    It 'Enable pipeline' {
        {
            # Enable the pipeline
            $result = Enable-AzDataTransferPipeline -PipelineName $env.PipelineName -ResourceGroupName $env.ResourceGroupName -Justification "Test enabling pipeline" -Confirm:$false
            
            # Verify the operation was successful
            $result | Should -Not -BeNullOrEmpty
        } | Should -Not -Throw
    }

    It 'Enable pipeline with AsJob' {
        {
            # Enable pipeline as a background job
            $job = Enable-AzDataTransferPipeline -PipelineName $env.PipelineName -ResourceGroupName $env.ResourceGroupName -Justification "Test enabling pipeline as job" -AsJob -Confirm:$false
            
            # Verify the job is created
            $job | Should -Not -BeNullOrEmpty
            ($job.State -eq "Running" -or $job.State -eq "Completed") | Should -Be $true
            
            # Wait for the job to complete
            $job | Wait-Job | Out-Null
            ($job.State -eq "Completed") | Should -Be $true
        } | Should -Not -Throw
    }

    It 'Enable pipeline with NoWait' {
        {
            # Enable pipeline asynchronously
            $result = Enable-AzDataTransferPipeline -PipelineName $env.PipelineName -ResourceGroupName $env.ResourceGroupName -Justification "Test enabling pipeline with NoWait" -NoWait -Confirm:$false
            
            # NoWait should return immediately
            $result | Should -Not -BeNullOrEmpty
        } | Should -Not -Throw
    }

    It 'Enable pipeline with WhatIf' {
        {
            # Test WhatIf functionality
            $result = Enable-AzDataTransferPipeline -PipelineName $env.PipelineName -ResourceGroupName $env.ResourceGroupName -Justification "Test WhatIf" -WhatIf
            
            # WhatIf should not throw and should not perform actual operation
        } | Should -Not -Throw
    }
}

Describe 'Enable-AzDataTransferPipeline' {
    It '__AllParameterSets' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
