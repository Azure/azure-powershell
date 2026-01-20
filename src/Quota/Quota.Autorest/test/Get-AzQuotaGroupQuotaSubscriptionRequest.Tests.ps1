if(($null -eq $TestName) -or ($TestName -contains 'Get-AzQuotaGroupQuotaSubscriptionRequest'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzQuotaGroupQuotaSubscriptionRequest.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

##TODO## Address error: Unable to verify that the user that sent this request is the original caller of the asynchronous operation being polled. 
# Please refer to https://learn.microsoft.com/en-us/azure/azure-resource-manager/management/async-operations for more information.

Describe 'Get-AzQuotaGroupQuotaSubscriptionRequest' {
    It 'List' {
        $managementGroupId = "AzureClientToolsBAMI"  
        $groupQuotaName = "testlocation"
        
        # This command fails with async operation verification error
        $result = Get-AzQuotaGroupQuotaSubscriptionRequest -ManagementGroupId $managementGroupId -GroupQuotaName $groupQuotaName
        $result | Should -Not -BeNull
    }
}
