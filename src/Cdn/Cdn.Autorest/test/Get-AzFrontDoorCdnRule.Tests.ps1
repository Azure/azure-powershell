if(($null -eq $TestName) -or ($TestName -contains 'Get-AzFrontDoorCdnRule'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzFrontDoorCdnRule.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzFrontDoorCdnRule' {
    BeforeAll {
        $script:rsName = 'rsNameRuleGet'
        $script:ruleName = 'ruleNameGet'
        New-AzFrontDoorCdnRuleSet -ProfileName $env.FrontDoorCdnProfileName -ResourceGroupName $env.ResourceGroupName -Name $script:rsName | Out-Null
        $uri = New-AzFrontDoorCdnRuleRequestUriConditionObject -Name 'RequestUri' -ParameterOperator 'Any'
        $ovr = New-AzFrontDoorCdnRuleRouteConfigurationOverrideActionObject -Name 'RouteConfigurationOverride' -CacheConfigurationQueryStringCachingBehavior 'IgnoreSpecifiedQueryStrings' -CacheConfigurationQueryParameter 'a=test' -CacheConfigurationIsCompressionEnabled 'Enabled' -CacheConfigurationCacheBehavior 'HonorOrigin'
        New-AzFrontDoorCdnRule -ProfileName $env.FrontDoorCdnProfileName -ResourceGroupName $env.ResourceGroupName -RuleSetName $script:rsName -Name $script:ruleName -Action @($ovr) -Condition @($uri) | Out-Null
    }

    AfterAll {
        Remove-AzFrontDoorCdnRule -ProfileName $env.FrontDoorCdnProfileName -ResourceGroupName $env.ResourceGroupName -RuleSetName $script:rsName -Name $script:ruleName -ErrorAction SilentlyContinue
        Remove-AzFrontDoorCdnRuleSet -ProfileName $env.FrontDoorCdnProfileName -ResourceGroupName $env.ResourceGroupName -Name $script:rsName -ErrorAction SilentlyContinue
    }

    It 'List' {
        $rs = Get-AzFrontDoorCdnRule -ProfileName $env.FrontDoorCdnProfileName -ResourceGroupName $env.ResourceGroupName -RuleSetName $script:rsName
        $rs.Count | Should -BeGreaterOrEqual 1
    }

    It 'Get' {
        $r = Get-AzFrontDoorCdnRule -ProfileName $env.FrontDoorCdnProfileName -ResourceGroupName $env.ResourceGroupName -RuleSetName $script:rsName -Name $script:ruleName
        $r.Name | Should -Be $script:ruleName
    }

    It 'GetViaIdentity' {
        $r = Get-AzFrontDoorCdnRule -ProfileName $env.FrontDoorCdnProfileName -ResourceGroupName $env.ResourceGroupName -RuleSetName $script:rsName -Name $script:ruleName
        $r2 = Get-AzFrontDoorCdnRule -InputObject $r
        $r2.Name | Should -Be $script:ruleName
    }

    It 'GetViaIdentityRuleSet' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'GetViaIdentityProfile' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
