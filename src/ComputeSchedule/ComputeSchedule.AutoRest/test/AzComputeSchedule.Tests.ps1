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
    It 'InvokeSubmitDeallocate' -skip {
        {
            $vmId = "/subscriptions/d4d56520-234b-4f88-b067-b64abe09a843/resourceGroups/test-rg/providers/Microsoft.Compute/virtualMachines/test-vm-1"
            $location = $env.Location
            $correlationId = [guid]::NewGuid().ToString()
            $subId = $env.SubscriptionId
            $retryCount = 3
            $retryWindowInMinutes = 20
            $timezone = "UTC"
            $deadlineType = "InitiateAt"
            $now = Get-Date
            $deadline = $now.AddHours(6)

            $submitDeallocateReq = Invoke-AzComputeScheduleSubmitDeallocate -Location $location -CorrelationId $correlationId -DeadlineType $deadlineType -ResourceId $vmId -SubscriptionId $subId -Deadline $deadline -RetryCount $retryCount -RetryWindowInMinutes $retryWindowInMinutes -Timezone $timezone
            $submitDeallocateReq.Count | Should -BeGreaterOrEqual 1

        } | Should -Not -Throw
    }
    
    It 'InvokeSubmitStart' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
    
    It 'InvokeSubmitHibernate' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
    
    It 'InvokeExecuteDeallocate' {
        {
            $vmId = "/subscriptions/d4d56520-234b-4f88-b067-b64abe09a843/resourceGroups/test-rg/providers/Microsoft.Compute/virtualMachines/test-vm-0"
            $location = "eastus2euap"
            $correlationId = "5e047015-76af-4b93-87a1-14714c670a9t"
            $subId = $env.SubscriptionId
            $retryCount = 3
            $retryWindowInMinutes = 50

            $executeDeallocateReq = Invoke-AzComputeScheduleExecuteDeallocate -Location $location -CorrelationId $correlationId -ResourceId $vmId -SubscriptionId $subId -RetryCount $retryCount -RetryWindowInMinutes $retryWindowInMinutes
            $executeDeallocateReq.Results.Count | Should -BeGreaterOrEqual 1

            foreach ($item in $executeDeallocateReq.Results) {
                $item.ErrorCode | Should -NotBeNull 
                }

        } | Should -Not -Throw
    }
    
    It 'InvokeExecuteHibernate' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
    
    It 'InvokeExecuteStart' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
    
    It 'GetOperationsStatus' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
    
    It 'GetOperationsErrors' -skip {
        {
            $mockOperationId = "854dbe77-9169-44ca-8f06-f87701183903"
            $mockCorrelationId = "5e047015-76af-4b93-87a1-14714c670a9e"
            $locationParameter = "eastus2euap"
            $request = Get-AzComputeScheduleOperationsErrors -Locationparameter $locationParameter -OperationIds $mockOperationId -SubscriptionId $env.SubscriptionId
         } | Should -Not -Throw
    }
    
    It 'StopOperations' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
