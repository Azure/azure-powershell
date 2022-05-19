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

Describe 'New-AzFrontDoorCdnRule' -Tag 'LiveOnly' {
    It 'CreateExpanded' {
        $ResourceGroupName = 'testps-rg-' + (RandomString -allChars $false -len 6)
        try
        {
            Write-Host -ForegroundColor Green "Create test group $($ResourceGroupName)"
            New-AzResourceGroup -Name $ResourceGroupName -Location $env.location
            $frontDoorCdnProfileName = 'fdp-' + (RandomString -allChars $false -len 6);
            Write-Host -ForegroundColor Green "Use frontDoorCdnProfileName : $($frontDoorCdnProfileName)"
            $profileSku = "Standard_AzureFrontDoor";
            New-AzFrontDoorCdnProfile -SkuName $profileSku -Name $frontDoorCdnProfileName -ResourceGroupName $ResourceGroupName -Location Global
            $rulesetName = 'rs' + (RandomString -allChars $false -len 6);
            Write-Host -ForegroundColor Green "Use rulesetName : $($rulesetName)"
            New-AzFrontDoorCdnRuleSet -ProfileName $frontDoorCdnProfileName -ResourceGroupName $ResourceGroupName -Name $rulesetName
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
            New-AzFrontDoorCdnRule -ProfileName $frontDoorCdnProfileName -ResourceGroupName $ResourceGroupName -RuleSetName $rulesetName -Name $ruleName `
            -Action $actions -Condition $conditions
        } Finally
        {
            Remove-AzResourceGroup -Name $ResourceGroupName -NoWait
        }
    }
}
