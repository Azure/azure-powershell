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

Describe 'New-AzFrontDoorCdnRule'  {
    It 'CreateExpanded' {
        $rulesetName = 'rs' + (RandomString -allChars $false -len 6);
        Write-Host -ForegroundColor Green "Use rulesetName : $($rulesetName)"
        New-AzFrontDoorCdnRuleSet -ProfileName $env.FrontDoorCdnProfileName -ResourceGroupName $env.ResourceGroupName -Name $rulesetName
        $uriConditon = New-AzFrontDoorCdnRuleRequestUriConditionObject -Name "RequestUri" -ParameterOperator "Any"
        $conditions = @(
            $uriConditon
        );
        $overrideAction = New-AzFrontDoorCdnRuleRouteConfigurationOverrideActionObject -Name "RouteConfigurationOverride" `
        -CacheConfigurationQueryStringCachingBehavior "IgnoreSpecifiedQueryStrings" `
        -CacheConfigurationQueryParameter "a=test" `
        -CacheConfigurationIsCompressionEnabled "Enabled" `
        -CacheConfigurationCacheBehavior "HonorOrigin"
        $actions = @($overrideAction);
        
        $ruleName = 'r' + (RandomString -allChars $false -len 6);
        Write-Host -ForegroundColor Green "Use ruleName : $($ruleName)"
        New-AzFrontDoorCdnRule -ProfileName $env.FrontDoorCdnProfileName -ResourceGroupName $env.ResourceGroupName -RuleSetName $rulesetName -Name $ruleName `
        -Action $actions -Condition $conditions
    }
}
