if(($null -eq $TestName) -or ($TestName -contains 'AzComputeSchedule'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'AzComputeSchedule.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'AzComputeSchedule' {    
    It 'InvokeSubmitDeallocate' {
        {
            $vmId = "/subscriptions/d4d56520-234b-4f88-b067-b64abe09a843/resourceGroups/rg-nneka-computeschedule-rg/providers/Microsoft.Compute/virtualMachines/exeDeall43850"
            $location = "eastus2euap"
            $correlationId = [guid]::NewGuid().ToString()
            $subId = $env.SubscriptionId
            $retryCount = 3
            $retryWindowInMinutes = 20
            $timezone = "UTC"
            $deadlineType = "InitiateAt"
            $deadline = "2024-12-25T23:00:00"

            Invoke-AzComputeScheduleSubmitDeallocate -Location $location -CorrelationId $correlationId -DeadlineType $deadlineType -ResourceId $vmId -SubscriptionId $subId -Deadline $deadline -RetryCount $retryCount -RetryWindowInMinutes $retryWindowInMinutes -Timezone $timezone | Format-List

        } | Should -Not -Throw
    }
    
    It 'InvokeSubmitStart' {
        {
            $vmId = "/subscriptions/d4d56520-234b-4f88-b067-b64abe09a843/resourceGroups/rg-nneka-computeschedule-rg/providers/Microsoft.Compute/virtualMachines/exeDeall52070"
            $location = "eastus2euap"
            $correlationId = [guid]::NewGuid().ToString()
            $subId = $env.SubscriptionId
            $retryCount = 3
            $retryWindowInMinutes = 20
            $timezone = "UTC"
            $deadlineType = "InitiateAt"
            $deadline = "2024-12-25T23:00:00"

            Invoke-AzComputeScheduleSubmitStart -Location $location -CorrelationId $correlationId -DeadlineType $deadlineType -ResourceId $vmId -SubscriptionId $subId -Deadline $deadline -RetryCount $retryCount -RetryWindowInMinutes $retryWindowInMinutes -Timezone $timezone | Format-List

        } | Should -Not -Throw
    }
    
    It 'InvokeSubmitHibernate' {
        {
            $vmId = "/subscriptions/d4d56520-234b-4f88-b067-b64abe09a843/resourceGroups/rg-nneka-computeschedule-rg/providers/Microsoft.Compute/virtualMachines/exeDeall51590"
            $location = "eastus2euap"
            $correlationId = [guid]::NewGuid().ToString()
            $subId = $env.SubscriptionId
            $retryCount = 3
            $retryWindowInMinutes = 20
            $timezone = "UTC"
            $deadlineType = "InitiateAt"
            $deadline = "2024-12-25T23:00:00"

            Invoke-AzComputeScheduleSubmitHibernate -Location $location -CorrelationId $correlationId -DeadlineType $deadlineType -ResourceId $vmId -SubscriptionId $subId -Deadline $deadline -RetryCount $retryCount -RetryWindowInMinutes $retryWindowInMinutes -Timezone $timezone | Format-List

        } | Should -Not -Throw
    }
    
    It 'InvokeExecuteDeallocate' {
        {
            $vmId = "/subscriptions/d4d56520-234b-4f88-b067-b64abe09a843/resourceGroups/rg-nneka-computeschedule-rg/providers/Microsoft.Compute/virtualMachines/exeHib30610"
            $location = "eastus2euap"
            $correlationGuid = [guid]::NewGuid()
            $correlationId = $correlationGuid.ToString()
            $subId = $env.SubscriptionId
            $retryCount = 3
            $retryWindowInMinutes = 50

            Invoke-AzComputeScheduleExecuteDeallocate -Location $location -CorrelationId $correlationId -ResourceId $vmId -SubscriptionId $subId -RetryCount $retryCount -RetryWindowInMinutes $retryWindowInMinutes | Format-List

        } | Should -Not -Throw
    }
    
    It 'InvokeExecuteHibernate' {
        {
            $vmId = "/subscriptions/d4d56520-234b-4f88-b067-b64abe09a843/resourceGroups/rg-nneka-computeschedule-rg/providers/Microsoft.Compute/virtualMachines/exeHib30440"
            $location = "eastus2euap"
            $correlationGuid = [guid]::NewGuid()
            $correlationId = $correlationGuid.ToString()
            $subId = $env.SubscriptionId
            $retryCount = 3
            $retryWindowInMinutes = 50

            Invoke-AzComputeScheduleExecuteHibernate -Location $location -CorrelationId $correlationId -ResourceId $vmId -SubscriptionId $subId -RetryCount $retryCount -RetryWindowInMinutes $retryWindowInMinutes | Format-List
            
        } | Should -Not -Throw
    }
    
    It 'InvokeExecuteStart' {
        {
            $vmId = "/subscriptions/d4d56520-234b-4f88-b067-b64abe09a843/resourceGroups/rg-nneka-computeschedule-rg/providers/Microsoft.Compute/virtualMachines/exeDeall66250"
            $location = "eastus2euap"
            $correlationGuid = [guid]::NewGuid()
            $correlationId = $correlationGuid.ToString()
            $subId = $env.SubscriptionId
            $retryCount = 3
            $retryWindowInMinutes = 50

            Invoke-AzComputeScheduleExecuteStart -Location $location -CorrelationId $correlationId -ResourceId $vmId -SubscriptionId $subId -RetryCount $retryCount -RetryWindowInMinutes $retryWindowInMinutes | Format-List
        
        } | Should -Not -Throw
    }
    
    It 'GetOperationStatus' {
        {
            $operationIdList = "1d3b8290-431b-42d4-bfb3-40845020c98b","7737b23a-8fad-4d06-bfc4-09ea995af642"
            $locationParameter = "eastus2euap"
            $correlationId = [guid]::NewGuid().ToString()
            $subId = $env.SubscriptionId

            Get-AzComputeScheduleOperationStatus -Location $locationParameter -Correlationid $correlationId -OperationId $operationIdList -SubscriptionId $subId | Format-List
         } | Should -Not -Throw
    }
    
    It 'GetOperationErrors' {
        {
            $operationIdList = "1d3b8290-431b-42d4-bfb3-40845020c98b","7737b23a-8fad-4d06-bfc4-09ea995af642"
            $locationParameter = "eastus2euap"
            $subId = $env.SubscriptionId

            Get-AzComputeScheduleOperationError -Location $locationParameter -OperationId $operationIdList -SubscriptionId $subId | Format-List
         } | Should -Not -Throw
    }
    
    It 'StopOperation' {
        {
            $operationIdList = "9d048d1c-1a63-4d11-b460-73a7099957c4"
            $locationParameter = "eastus2euap"
            $correlationId = [guid]::NewGuid().ToString()
            $subId = $env.SubscriptionId

            Stop-AzComputeScheduleScheduledAction -Location $locationParameter -OperationId $operationIdList  -Correlationid $correlationId -SubscriptionId $subId | Format-List
         } | Should -Not -Throw
    }
}
