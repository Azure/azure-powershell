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
    It 'CreateExpanded' {
        $rulesetName = 'rsName060'
        New-AzFrontDoorCdnRuleSet -ProfileName $env.FrontDoorCdnProfileName -ResourceGroupName $env.ResourceGroupName -Name $rulesetName
        $uriCondition = New-AzFrontDoorCdnRuleRequestUriConditionObject -Name "RequestUri" -ParameterOperator "Any"
        $conditions = @($uriCondition)
        $overrideAction = New-AzFrontDoorCdnRuleRouteConfigurationOverrideActionObject -Name "RouteConfigurationOverride" `
            -CacheConfigurationQueryStringCachingBehavior "IgnoreSpecifiedQueryStrings" -CacheConfigurationQueryParameter "a=test" `
            -CacheConfigurationIsCompressionEnabled "Enabled" -CacheConfigurationCacheBehavior "HonorOrigin"
        $actions = @($overrideAction)

        # New
        $ruleName = 'ruleName040'
        Write-Host -ForegroundColor Green "New Rule: $($ruleName)"
        $rule = New-AzFrontDoorCdnRule -ProfileName $env.FrontDoorCdnProfileName -ResourceGroupName $env.ResourceGroupName -RuleSetName $rulesetName -Name $ruleName `
            -Action $actions -Condition $conditions
        $rule.Name | Should -Be $ruleName

        # Get - List / by name / ViaIdentity
        $rules = Get-AzFrontDoorCdnRule -ProfileName $env.FrontDoorCdnProfileName -ResourceGroupName $env.ResourceGroupName -RuleSetName $rulesetName
        $rules.Count | Should -BeGreaterOrEqual 1
        $getRule = Get-AzFrontDoorCdnRule -ProfileName $env.FrontDoorCdnProfileName -ResourceGroupName $env.ResourceGroupName -RuleSetName $rulesetName -Name $ruleName
        $getRule.Name | Should -Be $ruleName
        $getRule2 = Get-AzFrontDoorCdnRule -InputObject $getRule
        $getRule2.Name | Should -Be $ruleName

        # Update
        $updatedOverrideAction = New-AzFrontDoorCdnRuleRouteConfigurationOverrideActionObject -Name "RouteConfigurationOverride" `
            -CacheConfigurationQueryStringCachingBehavior "IgnoreSpecifiedQueryStrings" -CacheConfigurationQueryParameter "a=test1" `
            -CacheConfigurationIsCompressionEnabled "Enabled" -CacheConfigurationCacheBehavior "HonorOrigin"
        Update-AzFrontDoorCdnRule -ProfileName $env.FrontDoorCdnProfileName -ResourceGroupName $env.ResourceGroupName -RuleSetName $rulesetName -Name $ruleName `
            -Action @($updatedOverrideAction) -Condition @()

        # Update - ViaIdentity
        $ruleObject = Get-AzFrontDoorCdnRule -ProfileName $env.FrontDoorCdnProfileName -ResourceGroupName $env.ResourceGroupName -RuleSetName $rulesetName -Name $ruleName
        $updatedOverrideAction2 = New-AzFrontDoorCdnRuleRouteConfigurationOverrideActionObject -Name "RouteConfigurationOverride" `
            -CacheConfigurationQueryStringCachingBehavior "IgnoreSpecifiedQueryStrings" -CacheConfigurationQueryParameter "a=test2" `
            -CacheConfigurationIsCompressionEnabled "Enabled" -CacheConfigurationCacheBehavior "HonorOrigin"
        Update-AzFrontDoorCdnRule -Action @($updatedOverrideAction2) -Condition @() -InputObject $ruleObject

        # Remove
        Remove-AzFrontDoorCdnRule -ProfileName $env.FrontDoorCdnProfileName -ResourceGroupName $env.ResourceGroupName -RuleSetName $rulesetName -Name $ruleName
    }
}
