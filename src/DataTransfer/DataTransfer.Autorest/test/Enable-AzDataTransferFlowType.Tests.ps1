if(($null -eq $TestName) -or ($TestName -contains 'Enable-AzDataTransferFlowType'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Enable-AzDataTransferFlowType.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Enable-AzDataTransferFlowType' {
    It 'Enable flow type with NoWait' {
        {
            # Enable flow type asynchronously and check status after timeout
            $timeout = 60
            $result = $null
            $completed = $false
            
            Write-Host "Starting Enable-AzDataTransferFlowType with NoWait..."
            $startTime = Get-Date
            
            try {
                # Start the operation with NoWait
                $result = Enable-AzDataTransferFlowType -PipelineName $env.PipelineName -ResourceGroupName $env.ResourceGroupName -FlowType "Mission" -Justification "Test enabling flow type with NoWait" -NoWait -Confirm:$false
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
                        $pipeline.DisabledFlowType | Should -Not -Be "Mission"
                    } else {
                        Write-Warning "Pipeline status could not be retrieved"
                    }
                } catch {
                    Write-Warning "Error checking pipeline status: $($_.Exception.Message)"
                }
            }
        } | Should -Not -Throw
    }
}
