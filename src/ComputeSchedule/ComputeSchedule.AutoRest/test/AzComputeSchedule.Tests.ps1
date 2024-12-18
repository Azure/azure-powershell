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
            $vmId = "/subscriptions/d4d56520-234b-4f88-b067-b22abe09a843/resourceGroups/test-rg/providers/Microsoft.Compute/virtualMachines/test-vm-1"
            $location = "eastus2euap"
            $correlationId = [guid]::NewGuid().ToString()
            $subId = $env.SubscriptionId
            $retryCount = 3
            $retryWindowInMinutes = 20
            $timezone = "UTC"
            $deadlineType = "InitiateAt"
            $now = Get-Date
            $deadline = $now.AddHours(10)

            Invoke-AzComputeScheduleSubmitDeallocate -Location $location -CorrelationId $correlationId -DeadlineType $deadlineType -ResourceId $vmId -SubscriptionId $subId -Deadline $deadline -RetryCount $retryCount -RetryWindowInMinutes $retryWindowInMinutes -Timezone $timezone

        } | Should -Not -Throw
    }
    
    It 'InvokeSubmitStart' {
        {
            $vmId = "/subscriptions/d4d56520-334b-4f88-b067-b64abe09a843/resourceGroups/test-rg/providers/Microsoft.Compute/virtualMachines/test-vm-2"
            $location = "eastus2euap"
            $correlationId = [guid]::NewGuid().ToString()
            $subId = $env.SubscriptionId
            $retryCount = 3
            $retryWindowInMinutes = 20
            $timezone = "UTC"
            $deadlineType = "InitiateAt"
            $now = Get-Date
            $deadline = $now.AddHours(10)

            Invoke-AzComputeScheduleSubmitStart -Location $location -CorrelationId $correlationId -DeadlineType $deadlineType -ResourceId $vmId -SubscriptionId $subId -Deadline $deadline -RetryCount $retryCount -RetryWindowInMinutes $retryWindowInMinutes -Timezone $timezone

        } | Should -Not -Throw
    }
    
    It 'InvokeSubmitHibernate' {
        {
            $vmId = "/subscriptions/d4d56520-234b-4f99-b067-b64abe09a843/resourceGroups/test-rg/providers/Microsoft.Compute/virtualMachines/test-vm-3"
            $location = "eastus2euap"
            $correlationId = [guid]::NewGuid().ToString()
            $subId = $env.SubscriptionId
            $retryCount = 3
            $retryWindowInMinutes = 20
            $timezone = "UTC"
            $deadlineType = "InitiateAt"
            $now = Get-Date
            $deadline = $now.AddHours(10)

            Invoke-AzComputeScheduleSubmitHibernate -Location $location -CorrelationId $correlationId -DeadlineType $deadlineType -ResourceId $vmId -SubscriptionId $subId -Deadline $deadline -RetryCount $retryCount -RetryWindowInMinutes $retryWindowInMinutes -Timezone $timezone

        } | Should -Not -Throw
    }
    
    It 'InvokeExecuteDeallocate' {
        {
            $vmId = "/subscriptions/d4d56520-234b-4f88-b032-b64abe09a843/resourceGroups/test-rg/providers/Microsoft.Compute/virtualMachines/test-vm-4"
            $location = "eastus2euap"
            $correlationGuid = [guid]::NewGuid()
            $correlationId = $correlationGuid.ToString()
            $subId = $env.SubscriptionId
            $retryCount = 3
            $retryWindowInMinutes = 50

            Invoke-AzComputeScheduleExecuteDeallocate -Location $location -CorrelationId $correlationId -ResourceId $vmId -SubscriptionId $subId -RetryCount $retryCount -RetryWindowInMinutes $retryWindowInMinutes

        } | Should -Not -Throw
    }
    
    It 'InvokeExecuteHibernate' {
        {
            $vmId = "/subscriptions/d4d56520-234b-4f88-b090-b64abe09a843/resourceGroups/test-rg/providers/Microsoft.Compute/virtualMachines/test-vm-5"
            $location = "eastus2euap"
            $correlationGuid = [guid]::NewGuid()
            $correlationId = $correlationGuid.ToString()
            $subId = $env.SubscriptionId
            $retryCount = 3
            $retryWindowInMinutes = 50

            Invoke-AzComputeScheduleExecuteHibernate -Location $location -CorrelationId $correlationId -ResourceId $vmId -SubscriptionId $subId -RetryCount $retryCount -RetryWindowInMinutes $retryWindowInMinutes
            
        } | Should -Not -Throw
    }
    
    It 'InvokeExecuteStart' {
        {
            $vmId = "/subscriptions/d4d56520-234b-4f12-b067-b64abe09a843/resourceGroups/test-rg/providers/Microsoft.Compute/virtualMachines/test-vm-6"
            $location = "eastus2euap"
            $correlationGuid = [guid]::NewGuid()
            $correlationId = $correlationGuid.ToString()
            $subId = $env.SubscriptionId
            $retryCount = 3
            $retryWindowInMinutes = 50

            Invoke-AzComputeScheduleExecuteStart -Location $location -CorrelationId $correlationId -ResourceId $vmId -SubscriptionId $subId -RetryCount $retryCount -RetryWindowInMinutes $retryWindowInMinutes
        
        } | Should -Not -Throw
    }
    
    It 'GetOperationStatus' {
        {
            $operationIdList = "45609245-dfdf-4a18-88d8-283628aeab9a","e3e7b03f-03bf-4d5e-a3f3-7dca1d072a3c"
            $locationParameter = "eastus2euap"
            $correlationId = [guid]::NewGuid().ToString()
            $subId = $env.SubscriptionId

            Get-AzComputeScheduleOperationStatus -Location $locationParameter -Correlationid $correlationId -OperationId $operationIdList -SubscriptionId $subId
         } | Should -Not -Throw
    }
    
    It 'GetOperationErrors' {
        {
            $operationIdList = "854dbe77-9169-99ca-8f06-f87744483903"
            $locationParameter = "eastus2euap"
            $subId = $env.SubscriptionId

            Get-AzComputeScheduleOperationError -Location $locationParameter -OperationId $operationIdList -SubscriptionId $subId
         } | Should -Not -Throw
    }
    
    It 'StopOperation' {
        {
            $operationIdList = "30b999d3-51e5-44ad-ba7c-5f36291a1926","28118282-df29-4a72-bffe-32a0805a198c"
            $locationParameter = "eastus2euap"
            $correlationId = [guid]::NewGuid().ToString()
            $subId = $env.SubscriptionId

            Stop-AzComputeScheduleScheduledAction -Location $locationParameter -OperationId $operationIdList  -Correlationid $correlationId -SubscriptionId $subId
         } | Should -Not -Throw
    }
}
