if(($null -eq $TestName) -or ($TestName -contains 'Set-AzDataBoundary'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Set-AzDataBoundary.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Set-AzDataBoundary' {
    It 'PutExpanded' -skip {
        { $scope = "/subscriptions/" + $env.SubscriptionId
        $boundaryData = Get-AzDataBoundaryScope -scope $scope
        Assert-AreEqual $boundaryData.Properties.DataBoundary "EU" }
    }

    It 'Put' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'PutViaJsonFilePath' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'PutViaJsonString' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
