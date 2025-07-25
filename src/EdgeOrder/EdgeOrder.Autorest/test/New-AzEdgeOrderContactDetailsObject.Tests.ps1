if(($null -eq $TestName) -or ($TestName -contains 'New-AzEdgeOrderContactDetailsObject'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzEdgeOrderContactDetailsObject.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzEdgeOrderContactDetailsObject' {
    It '__AllParameterSets'{
        $contactDetail = New-AzEdgeOrderContactDetailsObject -ContactName $env.ContactName -EmailList $env.EmailList -Phone $env.Phone
        $contactDetail.ContactName | Should -Be $env.ContactName
    }
}
