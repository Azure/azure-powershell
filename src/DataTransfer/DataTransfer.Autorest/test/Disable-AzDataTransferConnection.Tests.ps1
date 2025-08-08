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

$connectionToDisableName = "test-connection-disable-" + $env.RunId
$connectionToDisableAsJobName = "test-connection-disable-asjob-" + $env.RunId
$connectionToDisableNoWaitName = "test-connection-disable-nowait-" + $env.RunId

Write-Host "Connection names for disable: $connectionToDisableName, $connectionToDisableAsJobName, $connectionToDisableNoWaitName"

Describe 'Disable-AzDataTransferConnection' {
    BeforeAll {
        # Create test connections
        $connectionParams = @{
            Location             = $env.Location
            PipelineName         = $env.PipelineName
            Direction            = "Send"
            FlowType             = "Mission"
            ResourceGroupName    = $env.ResourceGroupName
            Justification        = "Send side for connection disable testing"
            RemoteSubscriptionId = $env.SubscriptionId
            RequirementId        = 0
            Name                 = $connectionToDisableName
            PrimaryContact       = "test@example.com"
        }
        $connectionToDisable = New-AzDataTransferConnection @connectionParams
        $connectionToDisableId = $connectionToDisable.Id
        
        $connectionAsJobParams = @{
            Location             = $env.Location
            PipelineName         = $env.PipelineName
            Direction            = "Send"
            FlowType             = "Mission"
            ResourceGroupName    = $env.ResourceGroupName
            Justification        = "Send side for connection disable AsJob testing"
            RemoteSubscriptionId = $env.SubscriptionId
            RequirementId        = 0
            Name                 = $connectionToDisableAsJobName
            PrimaryContact       = "test@example.com"
        }
        $connectionToDisableAsJob = New-AzDataTransferConnection @connectionAsJobParams
        $connectionToDisableAsJobId = $connectionToDisableAsJob.Id
        
        $connectionNoWaitParams = @{
            Location             = $env.Location
            PipelineName         = $env.PipelineName
            Direction            = "Send"
            FlowType             = "Mission"
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

    It 'Disable single connection' {
        {
            # Disable a single connection
            $result = Disable-AzDataTransferConnection -PipelineName $env.PipelineName -ResourceGroupName $env.ResourceGroupName -ConnectionId $connectionToDisableId -Justification "Test disabling connection" -Confirm:$false
            
            # Verify the operation was successful
            $result | Should -Not -BeNullOrEmpty
        } | Should -Not -Throw
    }

    It 'Disable multiple connections' {
        {
            # Disable multiple connections
            $connectionIds = @($connectionToDisableAsJobId, $connectionToDisableNoWaitId)
            $result = Disable-AzDataTransferConnection -PipelineName $env.PipelineName -ResourceGroupName $env.ResourceGroupName -ConnectionId $connectionIds -Justification "Test disabling multiple connections" -Confirm:$false
            
            # Verify the operation was successful
            $result | Should -Not -BeNullOrEmpty
        } | Should -Not -Throw
    }

    It 'Disable connection with AsJob' {
        {
            # Re-create connection for AsJob test
            $connectionAsJobParams = @{
                Location             = $env.Location
                PipelineName         = $env.PipelineName
                Direction            = "Send"
                FlowType             = "Mission"
                ResourceGroupName    = $env.ResourceGroupName
                Justification        = "Send side for connection disable AsJob testing"
                RemoteSubscriptionId = $env.SubscriptionId
                RequirementId        = 0
                Name                 = $connectionToDisableAsJobName + "-new"
                PrimaryContact       = "test@example.com"
            }
            $newConnection = New-AzDataTransferConnection @connectionAsJobParams
            $newConnectionId = $newConnection.Id
            
            # Disable connection as a background job
            $job = Disable-AzDataTransferConnection -PipelineName $env.PipelineName -ResourceGroupName $env.ResourceGroupName -ConnectionId $newConnectionId -Justification "Test disabling connection as job" -AsJob -Confirm:$false
            
            # Verify the job is created
            $job | Should -Not -BeNullOrEmpty
            ($job.State -eq "Running" -or $job.State -eq "Completed") | Should -Be $true
            
            # Wait for the job to complete
            $job | Wait-Job | Out-Null
            ($job.State -eq "Completed") | Should -Be $true
            
            # Clean up
            Remove-AzDataTransferConnection -ResourceGroupName $env.ResourceGroupName -Name ($connectionToDisableAsJobName + "-new") -Confirm:$false -ErrorAction SilentlyContinue
        } | Should -Not -Throw
    }

    It 'Disable connection with NoWait' {
        {
            # Re-create connection for NoWait test
            $connectionNoWaitParams = @{
                Location             = $env.Location
                PipelineName         = $env.PipelineName
                Direction            = "Send"
                FlowType             = "Mission"
                ResourceGroupName    = $env.ResourceGroupName
                Justification        = "Send side for connection disable NoWait testing"
                RemoteSubscriptionId = $env.SubscriptionId
                RequirementId        = 0
                Name                 = $connectionToDisableNoWaitName + "-new"
                PrimaryContact       = "test@example.com"
            }
            $newConnection = New-AzDataTransferConnection @connectionNoWaitParams
            $newConnectionId = $newConnection.Id
            
            # Disable connection asynchronously
            $result = Disable-AzDataTransferConnection -PipelineName $env.PipelineName -ResourceGroupName $env.ResourceGroupName -ConnectionId $newConnectionId -Justification "Test disabling connection with NoWait" -NoWait -Confirm:$false
            
            # NoWait should return immediately
            $result | Should -Not -BeNullOrEmpty
            
            # Clean up
            Remove-AzDataTransferConnection -ResourceGroupName $env.ResourceGroupName -Name ($connectionToDisableNoWaitName + "-new") -Confirm:$false -ErrorAction SilentlyContinue
        } | Should -Not -Throw
    }

    It 'Disable connection with WhatIf' {
        {
            # Test WhatIf functionality using existing connection
            $result = Disable-AzDataTransferConnection -PipelineName $env.PipelineName -ResourceGroupName $env.ResourceGroupName -ConnectionId $env.ConnectionLinkedId -Justification "Test WhatIf" -WhatIf
            
            # WhatIf should not throw and should not perform actual operation
        } | Should -Not -Throw
    }

    AfterAll {
        # Clean up test connections
        Remove-AzDataTransferConnection -ResourceGroupName $env.ResourceGroupName -Name $connectionToDisableName -Confirm:$false -ErrorAction SilentlyContinue
        Remove-AzDataTransferConnection -ResourceGroupName $env.ResourceGroupName -Name $connectionToDisableAsJobName -Confirm:$false -ErrorAction SilentlyContinue
        Remove-AzDataTransferConnection -ResourceGroupName $env.ResourceGroupName -Name $connectionToDisableNoWaitName -Confirm:$false -ErrorAction SilentlyContinue
    }
}

Describe 'Disable-AzDataTransferConnection' {
    It '__AllParameterSets' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
