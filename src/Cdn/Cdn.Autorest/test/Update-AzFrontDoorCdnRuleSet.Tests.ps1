if(($null -eq $TestName) -or ($TestName -contains 'Update-AzFrontDoorCdnRuleSet'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzFrontDoorCdnRuleSet.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzFrontDoorCdnRuleSet' {
    BeforeAll {
        $script:rsName = 'rsNameBatchUpd2'
        New-AzFrontDoorCdnRuleSet -ProfileName $env.FrontDoorCdnProfileName -ResourceGroupName $env.ResourceGroupName -Name $script:rsName -BatchMode | Out-Null
    }

    AfterAll {
        Remove-AzFrontDoorCdnRuleSet -ProfileName $env.FrontDoorCdnProfileName -ResourceGroupName $env.ResourceGroupName -Name $script:rsName -ErrorAction SilentlyContinue
    }

    It 'UpdateExpanded' {
        $action = New-AzFrontDoorCdnRuleRouteConfigurationOverrideActionObject -Name 'RouteConfigurationOverride' -CacheConfigurationQueryStringCachingBehavior 'IgnoreSpecifiedQueryStrings' -CacheConfigurationQueryParameter 'a=test1' -CacheConfigurationIsCompressionEnabled 'Enabled' -CacheConfigurationCacheBehavior 'HonorOrigin'
        $rule = @{
            RuleName = 'rule1'
            Order = 0
            Action = @($action)
            MatchProcessingBehavior = 'Continue'
        }
        $rs = Update-AzFrontDoorCdnRuleSet -ProfileName $env.FrontDoorCdnProfileName -ResourceGroupName $env.ResourceGroupName -Name $script:rsName -Rule @($rule)
        $rs.Name | Should -Be $script:rsName
        $rs.Rule[0].RuleName | Should -Be $rule.RuleName
    }

    It 'UpdateViaIdentityExpanded' {
        $action = New-AzFrontDoorCdnRuleRouteConfigurationOverrideActionObject -Name 'RouteConfigurationOverride' -CacheConfigurationQueryStringCachingBehavior 'IgnoreSpecifiedQueryStrings' -CacheConfigurationQueryParameter 'a=test2' -CacheConfigurationIsCompressionEnabled 'Enabled' -CacheConfigurationCacheBehavior 'HonorOrigin'
        $rule = @{
            RuleName = 'rule2'
            Order = 0
            Action = @($action)
            MatchProcessingBehavior = 'Continue'
        }
        $rs = Get-AzFrontDoorCdnRuleSet -ProfileName $env.FrontDoorCdnProfileName -ResourceGroupName $env.ResourceGroupName -Name $script:rsName
        $updated = Update-AzFrontDoorCdnRuleSet -InputObject $rs -Rule @($rule)
        $updated.Name | Should -Be $script:rsName
        $updated.Rule[0].RuleName | Should -Be $rule.RuleName
    }

    It 'UpdateViaIdentityProfileExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'UpdateViaIdentityProfile' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
