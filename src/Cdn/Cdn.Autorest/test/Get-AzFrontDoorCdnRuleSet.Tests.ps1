if(($null -eq $TestName) -or ($TestName -contains 'Get-AzFrontDoorCdnRuleSet'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzFrontDoorCdnRuleSet.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzFrontDoorCdnRuleSet' {
    BeforeAll {
        $script:rsName = 'rsNameGet'
        New-AzFrontDoorCdnRuleSet -ProfileName $env.FrontDoorCdnProfileName -ResourceGroupName $env.ResourceGroupName -Name $script:rsName | Out-Null
    }

    AfterAll {
        Remove-AzFrontDoorCdnRuleSet -ProfileName $env.FrontDoorCdnProfileName -ResourceGroupName $env.ResourceGroupName -Name $script:rsName -ErrorAction SilentlyContinue
    }

    It 'List' {
        $rss = Get-AzFrontDoorCdnRuleSet -ProfileName $env.FrontDoorCdnProfileName -ResourceGroupName $env.ResourceGroupName
        $rss.Count | Should -BeGreaterOrEqual 1
    }

    It 'Get' {
        $rs = Get-AzFrontDoorCdnRuleSet -ProfileName $env.FrontDoorCdnProfileName -ResourceGroupName $env.ResourceGroupName -Name $script:rsName
        $rs.Name | Should -Be $script:rsName
    }

    It 'GetViaIdentity' {
        $rs = Get-AzFrontDoorCdnRuleSet -ProfileName $env.FrontDoorCdnProfileName -ResourceGroupName $env.ResourceGroupName -Name $script:rsName
        $rs2 = Get-AzFrontDoorCdnRuleSet -InputObject $rs
        $rs2.Name | Should -Be $script:rsName
    }

    It 'GetViaIdentityProfile' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
