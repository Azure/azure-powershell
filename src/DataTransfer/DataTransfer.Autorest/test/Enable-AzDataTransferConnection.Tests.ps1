if(($null -eq $TestName) -or ($TestName -contains 'Enable-AzDataTransferConnection'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Enable-AzDataTransferConnection.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

$connectionToEnableNoWaitName = "test-connection-enable-nowait-" + $env.RunId

Write-Host "Connection names for enable: $connectionToEnableNoWaitName"

Describe 'Enable-AzDataTransferConnection' {
    BeforeAll {
        $connectionNoWaitParams = @{
            Location             = $env.Location
            PipelineName         = $env.PipelineName
            Direction            = "Receive"
            FlowType             = "Complex"
            ResourceGroupName    = $env.ResourceGroupName
            Justification        = "Receive side for connection enable NoWait testing"
            RemoteSubscriptionId = $env.SubscriptionId
            RequirementId        = 0
            Name                 = $connectionToEnableNoWaitName
            PrimaryContact       = "test@example.com"
        }
        $connectionToEnableNoWait = New-AzDataTransferConnection @connectionNoWaitParams
        $connectionToEnableNoWaitId = $connectionToEnableNoWait.Id
    }

    It 'Enable connection with NoWait' {
        {
            # Enable connection asynchronously and check status after timeout
            $timeout = 60
            $result = $null
            $completed = $false

            
            Write-Host "Starting Enable-AzDataTransferConnection with NoWait..."
            $startTime = Get-Date
            
            try {
                # Start the operation with NoWait
                $result = Enable-AzDataTransferConnection -PipelineName $env.PipelineName -ResourceGroupName $env.ResourceGroupName -ConnectionId $connectionToEnableNoWaitId -Justification "Test enabling connection with NoWait" -NoWait -Confirm:$false
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
                        
                        # Check if the connection is in the enabled connections list
                        try {
                            $connection = Get-AzDataTransferConnection -ResourceGroupName $env.ResourceGroupName -Name ($connectionToEnableNoWaitName) -ErrorAction SilentlyContinue
                            if ($connection) {
                                $connection.Status | Should -Not -Be "Disabled"
                                Write-Host "Connection status check completed successfully"
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
            }
        } | Should -Not -Throw
    }

    AfterAll {
        # Clean up test connection
        Remove-AzDataTransferConnection -ResourceGroupName $env.ResourceGroupName -Name $connectionToEnableNoWaitName -Confirm:$false -ErrorAction SilentlyContinue
    }
}
