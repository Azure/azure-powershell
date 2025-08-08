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

$connectionToEnableName = "test-connection-enable-" + $env.RunId
$connectionToEnableAsJobName = "test-connection-enable-asjob-" + $env.RunId
$connectionToEnableNoWaitName = "test-connection-enable-nowait-" + $env.RunId

Write-Host "Connection names for enable: $connectionToEnableName, $connectionToEnableAsJobName, $connectionToEnableNoWaitName"

Describe 'Enable-AzDataTransferConnection' {
    BeforeAll {
        # Create test connections
        $connectionParams = @{
            Location             = $env.Location
            PipelineName         = $env.PipelineName
            Direction            = "Send"
            FlowType             = "Mission"
            ResourceGroupName    = $env.ResourceGroupName
            Justification        = "Send side for connection enable testing"
            RemoteSubscriptionId = $env.SubscriptionId
            RequirementId        = 0
            Name                 = $connectionToEnableName
            PrimaryContact       = "test@example.com"
        }
        $connectionToEnable = New-AzDataTransferConnection @connectionParams
        $connectionToEnableId = $connectionToEnable.Id
        
        $connectionAsJobParams = @{
            Location             = $env.Location
            PipelineName         = $env.PipelineName
            Direction            = "Send"
            FlowType             = "Mission"
            ResourceGroupName    = $env.ResourceGroupName
            Justification        = "Send side for connection enable AsJob testing"
            RemoteSubscriptionId = $env.SubscriptionId
            RequirementId        = 0
            Name                 = $connectionToEnableAsJobName
            PrimaryContact       = "test@example.com"
        }
        $connectionToEnableAsJob = New-AzDataTransferConnection @connectionAsJobParams
        $connectionToEnableAsJobId = $connectionToEnableAsJob.Id
        
        $connectionNoWaitParams = @{
            Location             = $env.Location
            PipelineName         = $env.PipelineName
            Direction            = "Send"
            FlowType             = "Mission"
            ResourceGroupName    = $env.ResourceGroupName
            Justification        = "Send side for connection enable NoWait testing"
            RemoteSubscriptionId = $env.SubscriptionId
            RequirementId        = 0
            Name                 = $connectionToEnableNoWaitName
            PrimaryContact       = "test@example.com"
        }
        $connectionToEnableNoWait = New-AzDataTransferConnection @connectionNoWaitParams
        $connectionToEnableNoWaitId = $connectionToEnableNoWait.Id
        
        # First disable the connections so we can enable them in tests
        Disable-AzDataTransferConnection -PipelineName $env.PipelineName -ResourceGroupName $env.ResourceGroupName -ConnectionId $connectionToEnableId -Justification "Disable for enable testing" -Confirm:$false -ErrorAction SilentlyContinue
        Disable-AzDataTransferConnection -PipelineName $env.PipelineName -ResourceGroupName $env.ResourceGroupName -ConnectionId $connectionToEnableAsJobId -Justification "Disable for enable testing" -Confirm:$false -ErrorAction SilentlyContinue
        Disable-AzDataTransferConnection -PipelineName $env.PipelineName -ResourceGroupName $env.ResourceGroupName -ConnectionId $connectionToEnableNoWaitId -Justification "Disable for enable testing" -Confirm:$false -ErrorAction SilentlyContinue
    }

    It 'Enable single connection' {
        {
            # Enable a single connection
            $result = Enable-AzDataTransferConnection -PipelineName $env.PipelineName -ResourceGroupName $env.ResourceGroupName -ConnectionId $connectionToEnableId -Justification "Test enabling connection" -Confirm:$false
            
            # Verify the operation was successful
            $result | Should -Not -BeNullOrEmpty
        } | Should -Not -Throw
    }

    It 'Enable multiple connections' {
        {
            # Enable multiple connections
            $connectionIds = @($connectionToEnableAsJobId, $connectionToEnableNoWaitId)
            $result = Enable-AzDataTransferConnection -PipelineName $env.PipelineName -ResourceGroupName $env.ResourceGroupName -ConnectionId $connectionIds -Justification "Test enabling multiple connections" -Confirm:$false
            
            # Verify the operation was successful
            $result | Should -Not -BeNullOrEmpty
        } | Should -Not -Throw
    }

    It 'Enable connection with AsJob' {
        {
            # Re-create and disable connection for AsJob test
            $connectionAsJobParams = @{
                Location             = $env.Location
                PipelineName         = $env.PipelineName
                Direction            = "Send"
                FlowType             = "Mission"
                ResourceGroupName    = $env.ResourceGroupName
                Justification        = "Send side for connection enable AsJob testing"
                RemoteSubscriptionId = $env.SubscriptionId
                RequirementId        = 0
                Name                 = $connectionToEnableAsJobName + "-new"
                PrimaryContact       = "test@example.com"
            }
            $newConnection = New-AzDataTransferConnection @connectionAsJobParams
            $newConnectionId = $newConnection.Id
            
            # Disable it first
            Disable-AzDataTransferConnection -PipelineName $env.PipelineName -ResourceGroupName $env.ResourceGroupName -ConnectionId $newConnectionId -Justification "Disable for enable testing" -Confirm:$false -ErrorAction SilentlyContinue
            
            # Enable connection as a background job
            $job = Enable-AzDataTransferConnection -PipelineName $env.PipelineName -ResourceGroupName $env.ResourceGroupName -ConnectionId $newConnectionId -Justification "Test enabling connection as job" -AsJob -Confirm:$false
            
            # Verify the job is created
            $job | Should -Not -BeNullOrEmpty
            ($job.State -eq "Running" -or $job.State -eq "Completed") | Should -Be $true
            
            # Wait for the job to complete
            $job | Wait-Job | Out-Null
            ($job.State -eq "Completed") | Should -Be $true
            
            # Clean up
            Remove-AzDataTransferConnection -ResourceGroupName $env.ResourceGroupName -Name ($connectionToEnableAsJobName + "-new") -Confirm:$false -ErrorAction SilentlyContinue
        } | Should -Not -Throw
    }

    It 'Enable connection with NoWait' {
        {
            # Re-create and disable connection for NoWait test
            $connectionNoWaitParams = @{
                Location             = $env.Location
                PipelineName         = $env.PipelineName
                Direction            = "Send"
                FlowType             = "Mission"
                ResourceGroupName    = $env.ResourceGroupName
                Justification        = "Send side for connection enable NoWait testing"
                RemoteSubscriptionId = $env.SubscriptionId
                RequirementId        = 0
                Name                 = $connectionToEnableNoWaitName + "-new"
                PrimaryContact       = "test@example.com"
            }
            $newConnection = New-AzDataTransferConnection @connectionNoWaitParams
            $newConnectionId = $newConnection.Id
            
            # Disable it first
            Disable-AzDataTransferConnection -PipelineName $env.PipelineName -ResourceGroupName $env.ResourceGroupName -ConnectionId $newConnectionId -Justification "Disable for enable testing" -Confirm:$false -ErrorAction SilentlyContinue
            
            # Enable connection asynchronously
            $result = Enable-AzDataTransferConnection -PipelineName $env.PipelineName -ResourceGroupName $env.ResourceGroupName -ConnectionId $newConnectionId -Justification "Test enabling connection with NoWait" -NoWait -Confirm:$false
            
            # NoWait should return immediately
            $result | Should -Not -BeNullOrEmpty
            
            # Clean up
            Remove-AzDataTransferConnection -ResourceGroupName $env.ResourceGroupName -Name ($connectionToEnableNoWaitName + "-new") -Confirm:$false -ErrorAction SilentlyContinue
        } | Should -Not -Throw
    }

    It 'Enable connection with WhatIf' {
        {
            # Test WhatIf functionality using existing connection
            $result = Enable-AzDataTransferConnection -PipelineName $env.PipelineName -ResourceGroupName $env.ResourceGroupName -ConnectionId $env.ConnectionLinkedId -Justification "Test WhatIf" -WhatIf
            
            # WhatIf should not throw and should not perform actual operation
        } | Should -Not -Throw
    }

    AfterAll {
        # Clean up test connections
        Remove-AzDataTransferConnection -ResourceGroupName $env.ResourceGroupName -Name $connectionToEnableName -Confirm:$false -ErrorAction SilentlyContinue
        Remove-AzDataTransferConnection -ResourceGroupName $env.ResourceGroupName -Name $connectionToEnableAsJobName -Confirm:$false -ErrorAction SilentlyContinue
        Remove-AzDataTransferConnection -ResourceGroupName $env.ResourceGroupName -Name $connectionToEnableNoWaitName -Confirm:$false -ErrorAction SilentlyContinue
    }
}

Describe 'Enable-AzDataTransferConnection' {
    It '__AllParameterSets' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
