if(($null -eq $TestName) -or ($TestName -contains 'Update-AzFrontDoorCdnRoute'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzFrontDoorCdnRoute.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzFrontDoorCdnRoute'  {
    BeforeAll {
        $frontDoorEndpointName = 'end-pstest020'
        Write-Host -ForegroundColor Green "Start to create Stand_AzureFrontDoor SKU endpoint domain : $($frontDoorEndpointName)"
        New-AzFrontDoorCdnEndpoint -EndpointName $frontDoorEndpointName -ProfileName $env.FrontDoorCdnProfileName -ResourceGroupName $env.ResourceGroupName -Location Global | Out-Null

        $originGroupName = 'org-pstest130' 
        $healthProbeSetting = New-AzFrontDoorCdnOriginGroupHealthProbeSettingObject -ProbeIntervalInSecond 1 -ProbePath "/" `
            -ProbeProtocol "Https" -ProbeRequestType "GET"
        $loadBalancingSetting = New-AzFrontDoorCdnOriginGroupLoadBalancingSettingObject -AdditionalLatencyInMillisecond 200 `
            -SampleSize 5 -SuccessfulSamplesRequired 4
        $originGroup = New-AzFrontDoorCdnOriginGroup -OriginGroupName $originGroupName -ProfileName $env.FrontDoorCdnProfileName -ResourceGroupName $env.ResourceGroupName `
            -LoadBalancingSetting $loadBalancingSetting -HealthProbeSetting $healthProbeSetting

        Get-AzFrontDoorCdnOriginGroup -ResourceGroupName $env.ResourceGroupName -ProfileName $env.FrontDoorCdnProfileName -OriginGroupName $originGroupName

        $hostName = "en.wikipedia.org";
        $originName = 'ori-psName080'
        New-AzFrontDoorCdnOrigin -ResourceGroupName $env.ResourceGroupName -ProfileName $env.FrontDoorCdnProfileName -OriginGroupName $originGroupName `
            -OriginName $originName -OriginHostHeader $hostName -HostName $hostName `
            -HttpPort 80 -HttpsPort 443 -Priority 1 -Weight 1000

        $rulesetName = 'rsName110'
        Write-Host -ForegroundColor Green "Use rulesetName : $($rulesetName)"
        $ruleSet = New-AzFrontDoorCdnRuleSet -ProfileName $env.FrontDoorCdnProfileName -ResourceGroupName $env.ResourceGroupName -Name $rulesetName
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
        
        $ruleName = 'ruleName070'
        Write-Host -ForegroundColor Green "Use ruleName : $($ruleName)"
        New-AzFrontDoorCdnRule -ProfileName $env.FrontDoorCdnProfileName -ResourceGroupName $env.ResourceGroupName -RuleSetName $rulesetName -Name $ruleName `
            -Action $actions -Condition $conditions

        $ruleSetResoure = New-AzFrontDoorCdnResourceReferenceObject -Id $ruleSet.Id

        $routeName = 'routeName040'
        Write-Host -ForegroundColor Green "Use routeName : $($routeName)"
        New-AzFrontDoorCdnRoute -Name $routeName -EndpointName $frontDoorEndpointName -ProfileName $env.FrontDoorCdnProfileName -ResourceGroupName $env.ResourceGroupName `
            -OriginGroupId $originGroup.Id -RuleSet @($ruleSetResoure) -PatternsToMatch "/*" -LinkToDefaultDomain "Enabled" -EnabledState "Enabled"
    }

    It 'UpdateExpanded' {
        Update-AzFrontDoorCdnRoute -ResourceGroupName $env.ResourceGroupName -ProfileName $env.FrontDoorCdnProfileName -EndpointName $frontDoorEndpointName -Name $routeName `
            -EnabledState "Disabled"
    }

    It 'UpdateViaIdentityExpanded' {
        $routeObject = Get-AzFrontDoorCdnRoute -ResourceGroupName $env.ResourceGroupName -ProfileName $env.FrontDoorCdnProfileName -EndpointName $frontDoorEndpointName -Name $routeName
        Update-AzFrontDoorCdnRoute -EnabledState "Enabled" -InputObject $routeObject
    }
}
