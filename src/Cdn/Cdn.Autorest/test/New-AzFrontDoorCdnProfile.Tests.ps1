if(($null -eq $TestName) -or ($TestName -contains 'New-AzFrontDoorCdnProfile'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzFrontDoorCdnProfile.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzFrontDoorCdnProfile' {
    BeforeAll {
        $script:profileName = 'fdp-pstest-new'
    }

    AfterAll {
        Remove-AzFrontDoorCdnProfile -Name $script:profileName -ResourceGroupName $env.ResourceGroupName -ErrorAction SilentlyContinue
    }

    It 'CreateExpanded' {
        $rule1 = New-AzFrontDoorCdnProfileScrubbingRulesObject -MatchVariable RequestIPAddress -SelectorMatchOperator EqualsAny -State Enabled
        $rule2 = New-AzFrontDoorCdnProfileScrubbingRulesObject -MatchVariable QueryStringArgNames -SelectorMatchOperator EqualsAny -State Enabled
        $p = New-AzFrontDoorCdnProfile -SkuName 'Standard_AzureFrontDoor' -Name $script:profileName -ResourceGroupName $env.ResourceGroupName -Location Global -LogScrubbingRule @($rule1, $rule2) -LogScrubbingState Enabled
        $p.Name | Should -Be $script:profileName
        $p.SkuName | Should -Be 'Standard_AzureFrontDoor'
        $p.Location | Should -Be 'Global'
        $p.LogScrubbingState | Should -Be 'Enabled'
        $p.LogScrubbingRule.Count | Should -Be 2
    }
}
