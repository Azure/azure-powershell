if(($null -eq $TestName) -or ($TestName -contains 'Update-AzFrontDoorCdnRule'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzFrontDoorCdnRule.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzFrontDoorCdnRule' {
    BeforeAll {
        $script:rsName = 'rsNameRuleUpd'
        $script:ruleName = 'ruleNameUpd'
        New-AzFrontDoorCdnRuleSet -ProfileName $env.FrontDoorCdnProfileName -ResourceGroupName $env.ResourceGroupName -Name $script:rsName | Out-Null
        $uri = New-AzFrontDoorCdnRuleRequestUriConditionObject -Name 'RequestUri' -ParameterOperator 'Any'
        $ovr = New-AzFrontDoorCdnRuleRouteConfigurationOverrideActionObject -Name 'RouteConfigurationOverride' -CacheConfigurationQueryStringCachingBehavior 'IgnoreSpecifiedQueryStrings' -CacheConfigurationQueryParameter 'a=test' -CacheConfigurationIsCompressionEnabled 'Enabled' -CacheConfigurationCacheBehavior 'HonorOrigin'
        New-AzFrontDoorCdnRule -ProfileName $env.FrontDoorCdnProfileName -ResourceGroupName $env.ResourceGroupName -RuleSetName $script:rsName -Name $script:ruleName -Action @($ovr) -Condition @($uri) | Out-Null
    }

    AfterAll {
        Remove-AzFrontDoorCdnRule -ProfileName $env.FrontDoorCdnProfileName -ResourceGroupName $env.ResourceGroupName -RuleSetName $script:rsName -Name $script:ruleName -ErrorAction SilentlyContinue
        Remove-AzFrontDoorCdnRuleSet -ProfileName $env.FrontDoorCdnProfileName -ResourceGroupName $env.ResourceGroupName -Name $script:rsName -ErrorAction SilentlyContinue
    }

    It 'UpdateExpanded' {
        $ovr = New-AzFrontDoorCdnRuleRouteConfigurationOverrideActionObject -Name 'RouteConfigurationOverride' -CacheConfigurationQueryStringCachingBehavior 'IgnoreSpecifiedQueryStrings' -CacheConfigurationQueryParameter 'a=test1' -CacheConfigurationIsCompressionEnabled 'Enabled' -CacheConfigurationCacheBehavior 'HonorOrigin'
        $u = Update-AzFrontDoorCdnRule -ProfileName $env.FrontDoorCdnProfileName -ResourceGroupName $env.ResourceGroupName -RuleSetName $script:rsName -Name $script:ruleName -Action @($ovr) -Condition @()
        $u.Name | Should -Be $script:ruleName
    }

    It 'UpdateViaIdentityExpanded' {
        $r = Get-AzFrontDoorCdnRule -ProfileName $env.FrontDoorCdnProfileName -ResourceGroupName $env.ResourceGroupName -RuleSetName $script:rsName -Name $script:ruleName
        $ovr2 = New-AzFrontDoorCdnRuleRouteConfigurationOverrideActionObject -Name 'RouteConfigurationOverride' -CacheConfigurationQueryStringCachingBehavior 'IgnoreSpecifiedQueryStrings' -CacheConfigurationQueryParameter 'a=test2' -CacheConfigurationIsCompressionEnabled 'Enabled' -CacheConfigurationCacheBehavior 'HonorOrigin'
        $u = Update-AzFrontDoorCdnRule -Action @($ovr2) -Condition @() -InputObject $r
        $u.Name | Should -Be $script:ruleName
    }

    It 'UpdateViaJsonString' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'UpdateViaJsonFilePath' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'UpdateViaIdentityRuleSetExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'UpdateViaIdentityRuleSet' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'UpdateViaIdentityProfileExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'UpdateViaIdentityProfile' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
