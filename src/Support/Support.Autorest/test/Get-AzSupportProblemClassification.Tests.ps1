if(($null -eq $TestName) -or ($TestName -contains 'Get-AzSupportProblemClassification'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzSupportProblemClassification.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzSupportProblemClassification' {
    It 'List' {
        $problemClassifications = Get-AzSupportProblemClassification -ServiceName $env.BillingServiceId
        $problemClassifications.Count | Should -BeGreaterThan 1
    }

    It 'GetViaIdentityService' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'Get' {
        $problemClassification = Get-AzSupportProblemClassification -ServiceName $env.BillingServiceId -Name $env.BillingProblemClassificationId
        $problemClassification.Count | Should -Be 1
    }

    It 'GetViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
