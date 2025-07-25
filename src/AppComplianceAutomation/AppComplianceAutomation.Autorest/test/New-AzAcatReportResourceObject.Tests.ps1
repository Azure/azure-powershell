if(($null -eq $TestName) -or ($TestName -contains 'New-AzAcatReportResourceObject'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzAcatReportResourceObject.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzAcatReportResourceObject' {
    It '__AllParameterSets' {
        $resourceObj = New-AzAcatReportResourceObject -Resource @(@{ResourceId = $env.ResourceId})
        $resourceObj.Resource.Count | Should -Be 1
        $resourceObj.TimeZone | Should -Not -BeNullOrEmpty
        $resourceObj.TriggerTime | Should -Not -BeNullOrEmpty
    }
}
