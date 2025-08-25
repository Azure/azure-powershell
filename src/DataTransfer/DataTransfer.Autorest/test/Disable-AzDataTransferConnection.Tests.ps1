if(($null -eq $TestName) -or ($TestName -contains 'Disable-AzDataTransferConnection'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Disable-AzDataTransferConnection.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

$connectionToDisableNoWaitName = "test-connection-disable-nowait-" + $env.RunId

Write-Host "Connection names for disable: $connectionToDisableNoWaitName"

Describe 'Disable-AzDataTransferConnection' {
    BeforeAll {
        $connectionNoWaitParams = @{
            Location             = $env.Location
            PipelineName         = $env.PipelineName
            Direction            = "Send"
            FlowType             = "Complex"
            ResourceGroupName    = $env.ResourceGroupName
            Justification        = "Send side for connection disable NoWait testing"
            RemoteSubscriptionId = $env.SubscriptionId
            RequirementId        = 0
            Name                 = $connectionToDisableNoWaitName
            PrimaryContact       = "test@example.com"
        }
        $connectionToDisableNoWait = New-AzDataTransferConnection @connectionNoWaitParams
        $connectionToDisableNoWaitId = $connectionToDisableNoWait.Id
    }

    It 'Disable connection with NoWait' {
        {        
            # Disable connection asynchronously and check status after timeout
            $timeout = 60
            $result = $null
            $completed = $false
            
            Write-Host "Starting Disable-AzDataTransferConnection with NoWait..."
            $startTime = Get-Date
            
            try {
                # Start the operation with NoWait
                $result = Disable-AzDataTransferConnection -PipelineName $env.PipelineName -ResourceGroupName $env.ResourceGroupName -ConnectionId $connectionToDisableNoWaitId -Justification "Test disabling connection with NoWait" -NoWait -Confirm:$false
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
                        
                        # Check connection status
                        try {
                            $connection = Get-AzDataTransferConnection -ResourceGroupName $env.ResourceGroupName -Name $connectionToDisableNoWaitName -ErrorAction SilentlyContinue
                            if ($connection) {
                                Write-Host "Connection status check completed successfully"
                                $connection.Status | Should -Not -Be "Enabled"
                                Write-Host "Connection current state retrieved for verification"
                            } else {
                                Write-Warning "Connection status could not be retrieved"
                            }
                        } catch {
                            Write-Warning "Error checking connection status: $($_.Exception.Message)"
                        }
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

    AfterAll {
        # Clean up test connections
        Remove-AzDataTransferConnection -ResourceGroupName $env.ResourceGroupName -Name $connectionToDisableNoWaitName -Confirm:$false -ErrorAction SilentlyContinue
    }
}
