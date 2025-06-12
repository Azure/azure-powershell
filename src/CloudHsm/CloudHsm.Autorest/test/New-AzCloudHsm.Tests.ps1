if(($null -eq $TestName) -or ($TestName -contains 'New-AzCloudHsm'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzCloudHsm.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzCloudHsm' {
    It 'CreateExpanded' {
        $cloudHsm = New-AzCloudHsm -Name $env.cloudHsmName -ResourceGroupName $env.rgName -location ukwest -Tag @{ UseMockHfc = "true"; MockHfcDelayInMs = "1"}
        $cloudHsm.name.Contains($env.cloudHsmName) | Should -Be $true
        $cloudHsm.location.Contains("ukwest") | Should -Be $true
    }

    It 'CreateViaJsonFilePath' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'CreateViaJsonString' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
