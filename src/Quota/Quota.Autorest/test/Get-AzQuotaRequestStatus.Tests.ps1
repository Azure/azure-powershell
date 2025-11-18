if(($null -eq $TestName) -or ($TestName -contains 'Get-AzQuotaRequestStatus'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzQuotaRequestStatus.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzQuotaRequestStatus' {
    It 'List' {
        $scope = "subscriptions/$($env.SubscriptionId)/providers/Microsoft.Compute/locations/eastus"
        $result = Get-AzQuotaRequestStatus -Scope $scope
        $result | Should -Not -BeNullOrEmpty
    }

    It 'Get' {
        # First create a quota request to ensure we have something to retrieve
        $scope = "subscriptions/$($env.SubscriptionId)/providers/Microsoft.Compute/locations/eastus"
        $quota = Get-AzQuota -Scope $scope -ResourceName "standardFSv2Family"
        $limit = New-AzQuotaLimitObject -Value ($quota.Limit.Value + 1)
        $newQuota = New-AzQuota -Scope $scope -ResourceName "standardFSv2Family" -Name "standardFSv2Family" -Limit $limit
        
        # Wait a moment for the request to be processed
        Start-Sleep -Seconds 2
        
        # Get the list of requests
        $requests = Get-AzQuotaRequestStatus -Scope $scope
        
        if ($requests -and $requests.Count -gt 0) {
            # Get the most recent request
            $requestId = $requests[0].Name
            $result = Get-AzQuotaRequestStatus -Scope $scope -Id $requestId
            $result | Should -Not -BeNullOrEmpty
            $result.Name | Should -Be $requestId
        }
    }
}
