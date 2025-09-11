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

Describe 'Get-AzQuotaGroupQuotaUsage' {
    It 'List' -skip {
        { 
            $groupQuotaName = "ComputeGroupQuota01"
            $location = "eastus"
            $mgId = "admintest"
            $resourceProvider = "Microsoft.Compute"
            Get-AzQuotaGroupQuotaUsage -GroupQuotaName $groupQuotaName -Location $location -ManagementGroupId $mgId -ResourceProviderName $resourceProvider
         } | Should -Not -Throw
    }
}
