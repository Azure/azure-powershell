if(($null -eq $TestName) -or ($TestName -contains 'New-AzQuotaGroupQuota'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzQuotaGroupQuota.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzQuotaGroupQuota' {
    It 'CreateExpanded' {
        $managementGroupId = "AzureClientToolsBAMI"  
        $groupQuotaName = "testquota$(Get-Random)"
        
        $result = New-AzQuotaGroupQuota -ManagementGroupId $managementGroupId -GroupQuotaName $groupQuotaName -DisplayName "Test Quota Group"
        
        $result | Should -Not -BeNull
        $result.Name | Should -Not -BeNullOrEmpty
        
        # Get the created group quota using the original groupQuotaName to verify the display name
        $getResult = Get-AzQuotaGroupQuota -ManagementGroupId $managementGroupId -GroupQuotaName $groupQuotaName
        $getResult.Name | Should -Be $groupQuotaName
    }

}