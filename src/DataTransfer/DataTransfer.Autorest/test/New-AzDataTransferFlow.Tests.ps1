if(($null -eq $TestName) -or ($TestName -contains 'New-AzDataTransferFlow'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzDataTransferFlow.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

# FlowProfile-based flow test names
$testRunId = "09281740"
$flowToCreate = "test-flow-create-$testRunId"
$flowToCreateAsJob = "test-flow-create-as-job-$testRunId"
$fpBasicReceiveFlow = "test-fp-basic-recv-flow-$testRunId"
$fpBasicSendFlow = "test-fp-basic-send-flow-$testRunId"
$fpAsJobReceiveFlow = "test-fp-asjob-recv-flow-$testRunId"
$fpAsJobSendFlow = "test-fp-asjob-send-flow-$testRunId"

$testRunIdFp = "09280826"
$basicFlowProfileName = "test-basic-fp-$testRunIdFp"
$messagingFlowProfileName = "test-messaging-fp-$testRunIdFp"
$asJobFlowProfileName = "test-asjob-fp-$testRunIdFp"

$ResourceGroupName = $env.ResourceGroupName
$PipelineName = $env.PipelineName
$Pipeline = $env.PipelineName
$Location = $env.Location
$FlowProfileLocation = $env.FlowProfileLocation
$SubscriptionId = $env.SubscriptionId
$StorageAccountName = $env.StorageAccountName
$StorageContainerName = $env.StorageContainerName

Write-Host "FlowType Flow names: $flowToCreate, $flowToCreateAsJob"
Write-Host "FlowProfile Flow names - Basic: $fpBasicReceiveFlow, $fpBasicSendFlow"
Write-Host "FlowProfile Flow names - AsJob: $fpAsJobReceiveFlow, $fpAsJobSendFlow"

Describe 'New-AzDataTransferFlow' {
    $flowParams = @{
        ResourceGroupName     = $env.ResourceGroupName
        ConnectionName        = $env.ConnectionLinked
        Name                  = $flowToCreate
        Location              = $env.Location
        FlowType              = "Mission"
        DataType              = "Blob"
        StorageAccountName    = $env.StorageAccountName
        StorageContainerName  = $env.StorageContainerName
    }

    It 'CreateNewFlow' {
        {
            # Create a new flow
            $createdFlow =  New-AzDataTransferFlow @flowParams

            # Verify the flow is created
            $createdFlow | Should -Not -BeNullOrEmpty
            $createdFlow.Name | Should -Be $flowToCreate
            $createdFlow.Location | Should -Be $env.Location
            $createdFlow.FlowType | Should -Be "Mission"
            $createdFlow.DataType | Should -Be "Blob"
            $createdFlow.StorageAccountName | Should -Be $env.StorageAccountName
            $createdFlow.StorageContainerName | Should -Be $env.StorageContainerName
        } | Should -Not -Throw
    }

    It 'CreateNewFlow AsJob' {
        {
            $flowParams = @{
                ResourceGroupName     = $env.ResourceGroupName
                ConnectionName        = $env.ConnectionLinked
                Name                  = $flowToCreateAsJob
                Location              = $env.Location
                FlowType              = "Mission"
                DataType              = "Blob"
                StorageAccountName    = $env.StorageAccountName
                StorageContainerName  = $env.StorageContainerName
            }

            # Create a new flow as a background job
            $job = New-AzDataTransferFlow @flowParams -AsJob -Confirm:$false
    
            # Verify the job is created
            $job | Should -Not -BeNullOrEmpty
            ($job.State -eq "Running" -or $job.State -eq "Completed") | Should -Be $true
    
            # Wait for the job to complete
            $job | Wait-Job | Out-Null
            ($job.State -eq "Completed") | Should -Be $true
    
            # Verify the flow is created after the job completes
            $createdFlow = Get-AzDataTransferFlow -ResourceGroupName $env.ResourceGroupName -ConnectionName $env.ConnectionLinked -Name $flowToCreateAsJob
            $createdFlow | Should -Not -BeNullOrEmpty
            $createdFlow.Name | Should -Be $flowToCreateAsJob
            $createdFlow.Location | Should -Be $env.Location
            $createdFlow.FlowType | Should -Be "Mission"
            $createdFlow.DataType | Should -Be "Blob"
            $createdFlow.StorageAccountName | Should -Be $env.StorageAccountName
            $createdFlow.StorageContainerName | Should -Be $env.StorageContainerName
        } | Should -Not -Throw
    }

    It 'CreateExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'CreateViaJsonFilePath' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'CreateViaJsonString' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    # Use existing Basic connections and FlowProfile from setup scripts
    BeforeAll {
        $basicReceiveConnectionName = "test-rcv-basic-fp-conn-01"
        $basicSendConnectionName = "test-send-basic-fp-conn-01"

        Write-Host "Using existing Basic connections and FlowProfile for flow tests:"
        Write-Host "  Receive Connection: $basicReceiveConnectionName"
        Write-Host "  Send Connection: $basicSendConnectionName"
        Write-Host "  FlowProfile: $basicFlowProfileName"

        # Verify that the connections exist before proceeding with tests
        try {
            $existingReceiveConnection = Get-AzDataTransferConnection -ResourceGroupName $ResourceGroupName -Name $basicReceiveConnectionName -ErrorAction SilentlyContinue
            $existingSendConnection = Get-AzDataTransferConnection -ResourceGroupName $ResourceGroupName -Name $basicSendConnectionName -ErrorAction SilentlyContinue

            if ($existingReceiveConnection) {
                Write-Host "✅ Basic receive connection found: $($existingReceiveConnection.Name) - Status: $($existingReceiveConnection.Status)"
            } else {
                Write-Warning "❌ Basic receive connection not found: $basicReceiveConnectionName. Please run Connection-Create.ps1 first."
            }

            if ($existingSendConnection) {
                Write-Host "✅ Basic send connection found: $($existingSendConnection.Name) - Status: $($existingSendConnection.Status)"
            } else {
                Write-Warning "❌ Basic send connection not found: $basicSendConnectionName. Please run Connection-Create.ps1 first."
            }
        }
        catch {
            Write-Warning "Failed to verify existing connections: $($_.Exception.Message)"
        }

        # Verify that the BasicFlowProfile exists before proceeding with tests
        try {
            $existingFlowProfile = Get-AzDataTransferFlowProfile -PipelineName $PipelineName -ResourceGroupName $ResourceGroupName -FlowProfileName $basicFlowProfileName -ErrorAction SilentlyContinue

            if ($existingFlowProfile) {
                Write-Host "✅ Basic FlowProfile found: $($existingFlowProfile.Name) - Status: $($existingFlowProfile.Status) - Scenario: $($existingFlowProfile.ReplicationScenario)"
            } else {
                Write-Warning "❌ Basic FlowProfile not found: $basicFlowProfileName. Please run FlowProfile-Create.ps1 first."
            }
        }
        catch {
            Write-Warning "Failed to verify existing FlowProfile: $($_.Exception.Message)"
        }

        # Store connection and FlowProfile names for use in tests
        $global:BasicReceiveConnectionName = $basicReceiveConnectionName
        $global:BasicSendConnectionName = $basicSendConnectionName
        $global:BasicFlowProfileName = $basicFlowProfileName
    }

    # FlowProfile-based Flow Tests
    It 'CreateFlowWithBasicFlowProfile-Receive' {
        {
            $basicReceiveFlowParams = @{
                Name                              = $fpBasicReceiveFlow
                ConnectionName                    = $global:BasicReceiveConnectionName
                ResourceGroupName                 = $ResourceGroupName
                Location                          = $Location
                Status                            = "Enabled"
                FlowDataType                      = "Blob"
                StorageAccountName                = $StorageAccountName
                StorageContainerName              = $StorageContainerName
                FlowProfilePipeline               = $PipelineName
                FlowProfileName                   = $global:BasicFlowProfileName
                FlowProfileReplicationScenario    = "Files"
                FlowProfileStatus                 = "Enabled"
                FlowProfileDescription            = "Basic FlowProfile for Files replication"
                FlowProfileId                  = (Get-AzDataTransferFlowProfile -PipelineName $PipelineName -ResourceGroupName $ResourceGroupName -FlowProfileName $global:BasicFlowProfileName).FlowProfileId
                Confirm                           = $false
            }

            # Create the flow with Basic FlowProfile using proper syntax
            $createdFlow = New-AzDataTransferFlow @basicReceiveFlowParams

            # Verify the flow is created with correct properties
            $createdFlow | Should -Not -BeNullOrEmpty
            $createdFlow.Name | Should -Be $fpBasicReceiveFlow
            $createdFlow.Location | Should -Be $env.Location
            $createdFlow.Status | Should -Be "Enabled"
        } | Should -Not -Throw
    }

    It 'CreateFlowWithFlowProfileAsJob' {
        {
            $fpAsJobReceiveFlowParams = @{
                Name                              = $fpAsJobReceiveFlow
                ConnectionName                    = $global:BasicReceiveConnectionName
                ResourceGroupName                 = $env.ResourceGroupName
                Location                          = $env.Location
                Status                            = "Enabled"
                FlowDataType                      = "Blob"
                StorageAccountName                = $env.StorageAccountName
                StorageContainerName              = $env.StorageContainerName
                FlowProfilePipeline               = $env.PipelineName
                FlowProfileName                   = $global:BasicFlowProfileName
                FlowProfileReplicationScenario    = "Files"
                FlowProfileStatus                 = "Enabled"
                FlowProfileDescription            = "Basic FlowProfile for Files replication"
                FlowProfileId                  = (Get-AzDataTransferFlowProfile -PipelineName $PipelineName -ResourceGroupName $ResourceGroupName -FlowProfileName $global:BasicFlowProfileName).FlowProfileId
                Confirm                           = $false
            }

            # Create the flow as a background job
            $job = New-AzDataTransferFlow @fpAsJobReceiveFlowParams -AsJob

            # Verify the job is created
            $job | Should -Not -BeNullOrEmpty
            ($job.State -eq "Running" -or $job.State -eq "Completed") | Should -Be $true

            # Wait for the job to complete
            $job | Wait-Job | Out-Null
            ($job.State -eq "Completed") | Should -Be $true

            # Verify the flow is created after the job completes
            $createdFlow = Get-AzDataTransferFlow -ResourceGroupName $env.ResourceGroupName -ConnectionName $global:BasicReceiveConnectionName -Name $fpAsJobReceiveFlow
            $createdFlow | Should -Not -BeNullOrEmpty
            $createdFlow.Name | Should -Be $fpAsJobReceiveFlow
            $createdFlow.Location | Should -Be $env.Location
            $createdFlow.Status | Should -Be "Enabled"
        } | Should -Not -Throw
    }
    AfterAll {
        # Clean up the created flows (both FlowType and FlowProfile based)
        @($flowToCreate, $flowToCreateAsJob, $fpBasicReceiveFlow, $fpBasicSendFlow, $fpAsJobReceiveFlow) | ForEach-Object {
            $flowName = $_
            if ($flowName) {
                try {
                    # Determine the connection name based on flow name
                    $connectionName = if ($flowName -match "basic.*recv") { $global:BasicReceiveConnectionName } 
                                    elseif ($flowName -match "basic.*send") { $global:BasicSendConnectionName }
                                    elseif ($flowName -match "asjob.*recv") { $global:BasicReceiveConnectionName }
                                    else { $env.ConnectionLinked }
                    
                    Remove-AzDataTransferFlow -ResourceGroupName $env.ResourceGroupName -ConnectionName $connectionName -Name $flowName -Confirm:$false -ErrorAction SilentlyContinue
                    Write-Host "Cleaned up flow: $flowName"
                }
                catch {
                    Write-Warning "Failed to clean up flow ${flowName}: $($_.Exception.Message)"
                }
            }
        }
    }
}
