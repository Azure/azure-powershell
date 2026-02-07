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
        # Get existing requests without creating new ones (which require manual approval)
        $scope = "subscriptions/$($env.SubscriptionId)/providers/Microsoft.Compute/locations/eastus"
        $requests = Get-AzQuotaRequestStatus -Scope $scope
        
        if ($requests -and $requests.Count -gt 0) {
            # Get the most recent request
            $requestId = $requests[0].Name
            $result = Get-AzQuotaRequestStatus -Scope $scope -Id $requestId
            $result | Should -Not -BeNullOrEmpty
            $result.Name | Should -Be $requestId
        } else {
            # No existing requests, just verify the cmdlet works
            Set-ItResult -Skipped -Because "No quota requests available in subscription"
        }
    }
}
