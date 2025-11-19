if(($null -eq $TestName) -or ($TestName -contains 'Get-AzQuotaGroupQuotaUsage'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzQuotaGroupQuotaUsage.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

##TODO## Address error: Expected '{' or '['. Was String: Get.

Describe 'Get-AzQuotaGroupQuotaUsage' {
    It 'List' {
        $managementGroupId = "mg-demo"
        $groupQuotaName = "testlocation"
        
        # This command fails with JSON parsing error
        $result = Get-AzQuotaGroupQuotaUsage -ManagementGroupId $managementGroupId -GroupQuotaName $groupQuotaName -ResourceProviderName "Microsoft.Compute" -Location "eastus"
        $result | Should -Not -BeNull
    }
}
