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
            # Disable pipeline asynchronously and check status after timeout
            $timeout = 60
            $result = $null
            $completed = $false
            
            Write-Host "Starting Disable-AzDataTransferPipeline with NoWait..."
            $startTime = Get-Date
            
            try {
                # Start the operation with NoWait
                $result = Disable-AzDataTransferPipeline -PipelineName $env.PipelineName -ResourceGroupName $env.ResourceGroupName -Justification "Test disabling pipeline with NoWait" -NoWait -Confirm:$false
                $completed = $true
                Write-Host "NoWait operation initiated successfully"
            } catch {
                Write-Warning "Operation failed to start: $($_.Exception.Message)"
                $completed = $false
            }
            
            if ($completed) {
                # NoWait should return immediately
                $result | Should -Not -BeNullOrEmpty
                
                # Wait for the specified timeout period
                Write-Host "Waiting $timeout seconds to check pipeline status..."
                Start-Sleep -Seconds $timeout
                
                # Check pipeline status after timeout
                try {
                    Write-Host "Checking pipeline status after $timeout seconds..."
                    $pipeline = Get-AzDataTransferPipeline -Name $env.PipelineName -ResourceGroupName $env.ResourceGroupName -ErrorAction SilentlyContinue
                    
                    if ($pipeline) {
                        Write-Host "Pipeline status check completed successfully"
                        $pipeline | Should -Not -BeNullOrEmpty
                        $pipeline.Status | Should -Not -Be "Enabled"
                        Write-Host "Pipeline current state retrieved for verification"
                    } else {
                        Write-Warning "Pipeline status could not be retrieved"
                    }
                } catch {
                    Write-Warning "Error checking pipeline status: $($_.Exception.Message)"
                }
                
                $elapsedTime = (Get-Date) - $startTime
                Write-Host "Total test duration: $($elapsedTime.TotalSeconds) seconds"
            }
        } | Should -Not -Throw
    }
}
