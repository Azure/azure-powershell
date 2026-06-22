if(($null -eq $TestName) -or ($TestName -contains 'New-AzFrontDoorCdnRule'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzFrontDoorCdnRule.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzFrontDoorCdnRule' {
    BeforeAll {
        $script:rsName = 'rsNameRuleNew'
        $script:ruleName = 'ruleNameNew'
        New-AzFrontDoorCdnRuleSet -ProfileName $env.FrontDoorCdnProfileName -ResourceGroupName $env.ResourceGroupName -Name $script:rsName | Out-Null
    }

    AfterAll {
        Remove-AzFrontDoorCdnRule -ProfileName $env.FrontDoorCdnProfileName -ResourceGroupName $env.ResourceGroupName -RuleSetName $script:rsName -Name $script:ruleName -ErrorAction SilentlyContinue
        Remove-AzFrontDoorCdnRuleSet -ProfileName $env.FrontDoorCdnProfileName -ResourceGroupName $env.ResourceGroupName -Name $script:rsName -ErrorAction SilentlyContinue
    }

    It 'CreateExpanded' {
        $uri = New-AzFrontDoorCdnRuleRequestUriConditionObject -Name 'RequestUri' -ParameterOperator 'Any'
        $ovr = New-AzFrontDoorCdnRuleRouteConfigurationOverrideActionObject -Name 'RouteConfigurationOverride' -CacheConfigurationQueryStringCachingBehavior 'IgnoreSpecifiedQueryStrings' -CacheConfigurationQueryParameter 'a=test' -CacheConfigurationIsCompressionEnabled 'Enabled' -CacheConfigurationCacheBehavior 'HonorOrigin'
        $r = New-AzFrontDoorCdnRule -ProfileName $env.FrontDoorCdnProfileName -ResourceGroupName $env.ResourceGroupName -RuleSetName $script:rsName -Name $script:ruleName -Action @($ovr) -Condition @($uri)
        $r.Name | Should -Be $script:ruleName
    }
}
