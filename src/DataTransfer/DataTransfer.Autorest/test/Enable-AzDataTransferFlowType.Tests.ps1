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

$connectionToEnableFlowTypeName = "test-connection-flowtype-enable-" + $env.RunId
$connectionToEnableFlowTypeAsJobName = "test-connection-flowtype-enable-asjob-" + $env.RunId
$connectionToEnableFlowTypeNoWaitName = "test-connection-flowtype-enable-nowait-" + $env.RunId

Write-Host "Connection names for FlowType enable: $connectionToEnableFlowTypeName, $connectionToEnableFlowTypeAsJobName, $connectionToEnableFlowTypeNoWaitName"

Describe 'Enable-AzDataTransferFlowType' {
    BeforeAll {
        # Create test connections with flows
        $connectionParams = @{
            Location             = $env.Location
            PipelineName         = $env.PipelineName
            Direction            = "Send"
            FlowType             = "Mission"
            ResourceGroupName    = $env.ResourceGroupName
            Justification        = "Send side for FlowType enable testing"
            RemoteSubscriptionId = $env.SubscriptionId
            RequirementId        = 0
            Name                 = $connectionToEnableFlowTypeName
            PrimaryContact       = "test@example.com"
        }
        $connectionToEnableFlowType = New-AzDataTransferConnection @connectionParams
        
        $connectionAsJobParams = @{
            Location             = $env.Location
            PipelineName         = $env.PipelineName
            Direction            = "Send"
            FlowType             = "Mission"
            ResourceGroupName    = $env.ResourceGroupName
            Justification        = "Send side for FlowType enable AsJob testing"
            RemoteSubscriptionId = $env.SubscriptionId
            RequirementId        = 0
            Name                 = $connectionToEnableFlowTypeAsJobName
            PrimaryContact       = "test@example.com"
        }
        $connectionToEnableFlowTypeAsJob = New-AzDataTransferConnection @connectionAsJobParams
        
        $connectionNoWaitParams = @{
            Location             = $env.Location
            PipelineName         = $env.PipelineName
            Direction            = "Send"
            FlowType             = "Mission"
            ResourceGroupName    = $env.ResourceGroupName
            Justification        = "Send side for FlowType enable NoWait testing"
            RemoteSubscriptionId = $env.SubscriptionId
            RequirementId        = 0
            Name                 = $connectionToEnableFlowTypeNoWaitName
            PrimaryContact       = "test@example.com"
        }
        $connectionToEnableFlowTypeNoWait = New-AzDataTransferConnection @connectionNoWaitParams
    }

    It 'Enable single flow type' {
        {
            # Enable a single flow type
            $result = Enable-AzDataTransferFlowType -PipelineName $env.PipelineName -ResourceGroupName $env.ResourceGroupName -FlowType "Mission" -Justification "Test enabling flow type" -Confirm:$false
            
            # Verify the operation was successful
            $result | Should -Not -BeNullOrEmpty
        } | Should -Not -Throw
    }

    It 'Enable multiple flow types' {
        {
            # Enable multiple flow types
            $result = Enable-AzDataTransferFlowType -PipelineName $env.PipelineName -ResourceGroupName $env.ResourceGroupName -FlowType @("Mission", "Complex") -Justification "Test enabling multiple flow types" -Confirm:$false
            
            # Verify the operation was successful
            $result | Should -Not -BeNullOrEmpty
        } | Should -Not -Throw
    }

    It 'Enable flow type with AsJob' {
        {
            # Enable flow type as a background job
            $job = Enable-AzDataTransferFlowType -PipelineName $env.PipelineName -ResourceGroupName $env.ResourceGroupName -FlowType "Mission" -Justification "Test enabling flow type as job" -AsJob -Confirm:$false
            
            # Verify the job is created
            $job | Should -Not -BeNullOrEmpty
            ($job.State -eq "Running" -or $job.State -eq "Completed") | Should -Be $true
            
            # Wait for the job to complete
            $job | Wait-Job | Out-Null
            ($job.State -eq "Completed") | Should -Be $true
        } | Should -Not -Throw
    }

    It 'Enable flow type with NoWait' {
        {
            # Enable flow type asynchronously
            $result = Enable-AzDataTransferFlowType -PipelineName $env.PipelineName -ResourceGroupName $env.ResourceGroupName -FlowType "Mission" -Justification "Test enabling flow type with NoWait" -NoWait -Confirm:$false
            
            # NoWait should return immediately
            $result | Should -Not -BeNullOrEmpty
        } | Should -Not -Throw
    }

    It 'Enable flow type with WhatIf' {
        {
            # Test WhatIf functionality
            $result = Enable-AzDataTransferFlowType -PipelineName $env.PipelineName -ResourceGroupName $env.ResourceGroupName -FlowType "Mission" -Justification "Test WhatIf" -WhatIf
            
            # WhatIf should not throw and should not perform actual operation
        } | Should -Not -Throw
    }

    AfterAll {
        # Clean up test connections
        Remove-AzDataTransferConnection -ResourceGroupName $env.ResourceGroupName -Name $connectionToEnableFlowTypeName -Confirm:$false -ErrorAction SilentlyContinue
        Remove-AzDataTransferConnection -ResourceGroupName $env.ResourceGroupName -Name $connectionToEnableFlowTypeAsJobName -Confirm:$false -ErrorAction SilentlyContinue
        Remove-AzDataTransferConnection -ResourceGroupName $env.ResourceGroupName -Name $connectionToEnableFlowTypeNoWaitName -Confirm:$false -ErrorAction SilentlyContinue
    }
}

Describe 'Enable-AzDataTransferFlowType' {
    It '__AllParameterSets' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
