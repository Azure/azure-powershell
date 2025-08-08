if(($null -eq $TestName) -or ($TestName -contains 'Disable-AzDataTransferPipeline'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Disable-AzDataTransferPipeline.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Disable-AzDataTransferPipeline' {
    It 'Disable pipeline' {
        {
            # Disable the pipeline
            $result = Disable-AzDataTransferPipeline -PipelineName $env.PipelineName -ResourceGroupName $env.ResourceGroupName -Justification "Test disabling pipeline" -Confirm:$false
            
            # Verify the operation was successful
            $result | Should -Not -BeNullOrEmpty
        } | Should -Not -Throw
    }

    It 'Disable pipeline with AsJob' {
        {
            # Disable pipeline as a background job
            $job = Disable-AzDataTransferPipeline -PipelineName $env.PipelineName -ResourceGroupName $env.ResourceGroupName -Justification "Test disabling pipeline as job" -AsJob -Confirm:$false
            
            # Verify the job is created
            $job | Should -Not -BeNullOrEmpty
            ($job.State -eq "Running" -or $job.State -eq "Completed") | Should -Be $true
            
            # Wait for the job to complete
            $job | Wait-Job | Out-Null
            ($job.State -eq "Completed") | Should -Be $true
        } | Should -Not -Throw
    }

    It 'Disable pipeline with NoWait' {
        {
            # Disable pipeline asynchronously
            $result = Disable-AzDataTransferPipeline -PipelineName $env.PipelineName -ResourceGroupName $env.ResourceGroupName -Justification "Test disabling pipeline with NoWait" -NoWait -Confirm:$false
            
            # NoWait should return immediately
            $result | Should -Not -BeNullOrEmpty
        } | Should -Not -Throw
    }

    It 'Disable pipeline with WhatIf' {
        {
            # Test WhatIf functionality
            $result = Disable-AzDataTransferPipeline -PipelineName $env.PipelineName -ResourceGroupName $env.ResourceGroupName -Justification "Test WhatIf" -WhatIf
            
            # WhatIf should not throw and should not perform actual operation
        } | Should -Not -Throw
    }
}

Describe 'Disable-AzDataTransferPipeline' {
    It '__AllParameterSets' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
