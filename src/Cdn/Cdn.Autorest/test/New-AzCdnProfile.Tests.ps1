if(($null -eq $TestName) -or ($TestName -contains 'New-AzCdnProfile'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzCdnProfile.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzCdnProfile' {
    BeforeAll {
        $script:cdnProfileName = 'cdnpps01-new'
        $script:profileSku = 'Standard_Microsoft'
    }

    AfterAll {
        Remove-AzCdnProfile -Name $script:cdnProfileName -ResourceGroupName $env.ResourceGroupName -ErrorAction SilentlyContinue
    }

    It 'CreateExpanded' {
        $cdnProfile = New-AzCdnProfile -SkuName $script:profileSku -Name $script:cdnProfileName -ResourceGroupName $env.ResourceGroupName -Location Global
        $cdnProfile.Name | Should -Be $script:cdnProfileName
        $cdnProfile.SkuName | Should -Be $script:profileSku
        $cdnProfile.Location | Should -Be 'Global'
    }
}
