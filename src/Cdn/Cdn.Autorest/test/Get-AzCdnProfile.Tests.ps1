if(($null -eq $TestName) -or ($TestName -contains 'Get-AzCdnProfile'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzCdnProfile.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzCdnProfile' {
    BeforeAll {
        $script:profileName = 'cdnpps01-get'
        New-AzCdnProfile -SkuName 'Standard_Microsoft' -Name $script:profileName -ResourceGroupName $env.ResourceGroupName -Location Global | Out-Null
    }

    AfterAll {
        Remove-AzCdnProfile -Name $script:profileName -ResourceGroupName $env.ResourceGroupName -ErrorAction SilentlyContinue
    }

    It 'List' {
        $profiles = Get-AzCdnProfile -ResourceGroupName $env.ResourceGroupName
        $profiles.Count | Should -BeGreaterOrEqual 1
    }

    It 'Get' {
        $p = Get-AzCdnProfile -ResourceGroupName $env.ResourceGroupName -Name $script:profileName
        $p.Name | Should -Be $script:profileName
        $p.SkuName | Should -Be 'Standard_Microsoft'
    }

    It 'GetViaIdentity' {
        $p = Get-AzCdnProfile -ResourceGroupName $env.ResourceGroupName -Name $script:profileName
        $p2 = Get-AzCdnProfile -InputObject $p
        $p2.Name | Should -Be $script:profileName
    }

    It 'List1' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
