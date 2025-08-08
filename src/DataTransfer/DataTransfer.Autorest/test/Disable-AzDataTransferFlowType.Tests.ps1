if(($null -eq $TestName) -or ($TestName -contains 'Disable-AzDataTransferFlowType'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Disable-AzDataTransferFlowType.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

$connectionToDisableFlowTypeName = "test-connection-flowtype-disable-" + $env.RunId
$connectionToDisableFlowTypeAsJobName = "test-connection-flowtype-disable-asjob-" + $env.RunId
$connectionToDisableFlowTypeNoWaitName = "test-connection-flowtype-disable-nowait-" + $env.RunId

Write-Host "Connection names for FlowType disable: $connectionToDisableFlowTypeName, $connectionToDisableFlowTypeAsJobName, $connectionToDisableFlowTypeNoWaitName"

Describe 'Disable-AzDataTransferFlowType' {
    BeforeAll {
        # Create test connections with flows
        $connectionParams = @{
            Location             = $env.Location
            PipelineName         = $env.PipelineName
            Direction            = "Send"
            FlowType             = "Mission"
            ResourceGroupName    = $env.ResourceGroupName
            Justification        = "Send side for FlowType disable testing"
            RemoteSubscriptionId = $env.SubscriptionId
            RequirementId        = 0
            Name                 = $connectionToDisableFlowTypeName
            PrimaryContact       = "test@example.com"
        }
        $connectionToDisableFlowType = New-AzDataTransferConnection @connectionParams
        
        $connectionAsJobParams = @{
            Location             = $env.Location
            PipelineName         = $env.PipelineName
            Direction            = "Send"
            FlowType             = "Mission"
            ResourceGroupName    = $env.ResourceGroupName
            Justification        = "Send side for FlowType disable AsJob testing"
            RemoteSubscriptionId = $env.SubscriptionId
            RequirementId        = 0
            Name                 = $connectionToDisableFlowTypeAsJobName
            PrimaryContact       = "test@example.com"
        }
        $connectionToDisableFlowTypeAsJob = New-AzDataTransferConnection @connectionAsJobParams
        
        $connectionNoWaitParams = @{
            Location             = $env.Location
            PipelineName         = $env.PipelineName
            Direction            = "Send"
            FlowType             = "Mission"
            ResourceGroupName    = $env.ResourceGroupName
            Justification        = "Send side for FlowType disable NoWait testing"
            RemoteSubscriptionId = $env.SubscriptionId
            RequirementId        = 0
            Name                 = $connectionToDisableFlowTypeNoWaitName
            PrimaryContact       = "test@example.com"
        }
        $connectionToDisableFlowTypeNoWait = New-AzDataTransferConnection @connectionNoWaitParams
    }

    It 'Disable single flow type' {
        {
            # Disable a single flow type
            $result = Disable-AzDataTransferFlowType -PipelineName $env.PipelineName -ResourceGroupName $env.ResourceGroupName -FlowType "Mission" -Justification "Test disabling flow type" -Confirm:$false
            
            # Verify the operation was successful
            $result | Should -Not -BeNullOrEmpty
        } | Should -Not -Throw
    }

    It 'Disable multiple flow types' {
        {
            # Disable multiple flow types
            $result = Disable-AzDataTransferFlowType -PipelineName $env.PipelineName -ResourceGroupName $env.ResourceGroupName -FlowType @("Mission", "Complex") -Justification "Test disabling multiple flow types" -Confirm:$false
            
            # Verify the operation was successful
            $result | Should -Not -BeNullOrEmpty
        } | Should -Not -Throw
    }

    It 'Disable flow type with AsJob' {
        {
            # Disable flow type as a background job
            $job = Disable-AzDataTransferFlowType -PipelineName $env.PipelineName -ResourceGroupName $env.ResourceGroupName -FlowType "Mission" -Justification "Test disabling flow type as job" -AsJob -Confirm:$false
            
            # Verify the job is created
            $job | Should -Not -BeNullOrEmpty
            ($job.State -eq "Running" -or $job.State -eq "Completed") | Should -Be $true
            
            # Wait for the job to complete
            $job | Wait-Job | Out-Null
            ($job.State -eq "Completed") | Should -Be $true
        } | Should -Not -Throw
    }

    It 'Disable flow type with NoWait' {
        {
            # Disable flow type asynchronously
            $result = Disable-AzDataTransferFlowType -PipelineName $env.PipelineName -ResourceGroupName $env.ResourceGroupName -FlowType "Mission" -Justification "Test disabling flow type with NoWait" -NoWait -Confirm:$false
            
            # NoWait should return immediately
            $result | Should -Not -BeNullOrEmpty
        } | Should -Not -Throw
    }

    It 'Disable flow type with WhatIf' {
        {
            # Test WhatIf functionality
            $result = Disable-AzDataTransferFlowType -PipelineName $env.PipelineName -ResourceGroupName $env.ResourceGroupName -FlowType "Mission" -Justification "Test WhatIf" -WhatIf
            
            # WhatIf should not throw and should not perform actual operation
        } | Should -Not -Throw
    }

    AfterAll {
        # Clean up test connections
        Remove-AzDataTransferConnection -ResourceGroupName $env.ResourceGroupName -Name $connectionToDisableFlowTypeName -Confirm:$false -ErrorAction SilentlyContinue
        Remove-AzDataTransferConnection -ResourceGroupName $env.ResourceGroupName -Name $connectionToDisableFlowTypeAsJobName -Confirm:$false -ErrorAction SilentlyContinue
        Remove-AzDataTransferConnection -ResourceGroupName $env.ResourceGroupName -Name $connectionToDisableFlowTypeNoWaitName -Confirm:$false -ErrorAction SilentlyContinue
    }
}

Describe 'Disable-AzDataTransferFlowType' {
    It '__AllParameterSets' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
