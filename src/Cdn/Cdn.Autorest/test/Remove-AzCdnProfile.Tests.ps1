if(($null -eq $TestName) -or ($TestName -contains 'Remove-AzCdnProfile'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzCdnProfile.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Remove-AzCdnProfile' {
    BeforeAll {
        $script:profileName = 'cdnpps01-rm'
        New-AzCdnProfile -SkuName 'Standard_Microsoft' -Name $script:profileName -ResourceGroupName $env.ResourceGroupName -Location Global | Out-Null
    }

    It 'Delete' {
        $res = Remove-AzCdnProfile -Name $script:profileName -ResourceGroupName $env.ResourceGroupName -PassThru
        $res | Should -Be 'True'
    }

    It 'DeleteViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
