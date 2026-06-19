if(($null -eq $TestName) -or ($TestName -contains 'Get-AzFrontDoorCdnProfile'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzFrontDoorCdnProfile.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzFrontDoorCdnProfile' {
    BeforeAll {
        $script:profileName = 'fdp-pstest-get'
        New-AzFrontDoorCdnProfile -SkuName 'Standard_AzureFrontDoor' -Name $script:profileName -ResourceGroupName $env.ResourceGroupName -Location Global | Out-Null
    }

    AfterAll {
        Remove-AzFrontDoorCdnProfile -Name $script:profileName -ResourceGroupName $env.ResourceGroupName -ErrorAction SilentlyContinue
    }

    It 'List' {
        $ps = Get-AzFrontDoorCdnProfile -ResourceGroupName $env.ResourceGroupName
        $ps.Count | Should -BeGreaterOrEqual 1
    }

    It 'Get' {
        $p = Get-AzFrontDoorCdnProfile -ResourceGroupName $env.ResourceGroupName -Name $script:profileName
        $p.Name | Should -Be $script:profileName
    }

    It 'GetViaIdentity' {
        $p = Get-AzFrontDoorCdnProfile -ResourceGroupName $env.ResourceGroupName -Name $script:profileName
        $p2 = Get-AzFrontDoorCdnProfile -InputObject $p
        $p2.Name | Should -Be $script:profileName
    }

    It 'List1' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
