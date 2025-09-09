if(($null -eq $TestName) -or ($TestName -contains 'Get-AzQuotaGroupQuota'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzQuotaGroupQuota.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzQuotaGroupQuota' {
    It 'List' -skip {
        { Get-AzQuotaGroupQuota -ManagementGroupId "mg-demo" } | Should -Not -Throw 
    }

    # It 'Get' -skip {
    #     { throw [System.NotImplementedException] } | Should -Not -Throw
    # }

    # It 'GetViaIdentityManagementGroup' -skip {
    #     { throw [System.NotImplementedException] } | Should -Not -Throw
    # }

    # It 'GetViaIdentity' -skip {
    #     { throw [System.NotImplementedException] } | Should -Not -Throw
    # }
}
