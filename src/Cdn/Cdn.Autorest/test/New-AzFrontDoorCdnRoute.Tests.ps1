if(($null -eq $TestName) -or ($TestName -contains 'New-AzFrontDoorCdnRoute'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzFrontDoorCdnRoute.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzFrontDoorCdnRoute' {
    It 'CreateExpanded' {
        # Setup: endpoint, origin group, origin, rule set, rule
        $endpointName = 'e-clipstest050'
        $endpoint = New-AzFrontDoorCdnEndpoint -EndpointName $endpointName -ProfileName $env.FrontDoorCdnProfileName -ResourceGroupName $env.ResourceGroupName -Location Global

        $originGroupName = 'org-pstest070'
        $healthProbeSetting = New-AzFrontDoorCdnOriginGroupHealthProbeSettingObject -ProbeIntervalInSecond 1 -ProbePath "/" -ProbeProtocol "Https" -ProbeRequestType "GET"
        $loadBalancingSetting = New-AzFrontDoorCdnOriginGroupLoadBalancingSettingObject -AdditionalLatencyInMillisecond 200 -SampleSize 5 -SuccessfulSamplesRequired 4
        $originGroup = New-AzFrontDoorCdnOriginGroup -OriginGroupName $originGroupName -ProfileName $env.FrontDoorCdnProfileName -ResourceGroupName $env.ResourceGroupName `
            -LoadBalancingSetting $loadBalancingSetting -HealthProbeSetting $healthProbeSetting

        $hostName = "en.wikipedia.org"
        New-AzFrontDoorCdnOrigin -ResourceGroupName $env.ResourceGroupName -ProfileName $env.FrontDoorCdnProfileName -OriginGroupName $originGroupName `
            -OriginName 'ori-psName040' -OriginHostHeader $hostName -HostName $hostName -HttpPort 80 -HttpsPort 443 -Priority 1 -Weight 1000

        $rulesetName = 'rsName050'
        $ruleSet = New-AzFrontDoorCdnRuleSet -ProfileName $env.FrontDoorCdnProfileName -ResourceGroupName $env.ResourceGroupName -Name $rulesetName
        $uriCondition = New-AzFrontDoorCdnRuleRequestUriConditionObject -Name "RequestUri" -ParameterOperator "Any"
        $overrideAction = New-AzFrontDoorCdnRuleRouteConfigurationOverrideActionObject -Name "RouteConfigurationOverride" `
            -CacheConfigurationQueryStringCachingBehavior "IgnoreSpecifiedQueryStrings" -CacheConfigurationQueryParameter "a=test" `
            -CacheConfigurationIsCompressionEnabled "Enabled" -CacheConfigurationCacheBehavior "HonorOrigin"
        New-AzFrontDoorCdnRule -ProfileName $env.FrontDoorCdnProfileName -ResourceGroupName $env.ResourceGroupName -RuleSetName $rulesetName -Name 'ruleName030' `
            -Action @($overrideAction) -Condition @($uriCondition)
        $ruleSetResource = New-AzFrontDoorCdnResourceReferenceObject -Id $ruleSet.Id

        # New
        $routeName = 'routeName020'
        Write-Host -ForegroundColor Green "New Route: $($routeName)"
        $route = New-AzFrontDoorCdnRoute -Name $routeName -EndpointName $endpointName -ProfileName $env.FrontDoorCdnProfileName -ResourceGroupName $env.ResourceGroupName `
            -OriginGroupId $originGroup.Id -RuleSet @($ruleSetResource) -PatternsToMatch "/*" -LinkToDefaultDomain "Enabled" -EnabledState "Enabled"
        $route.Name | Should -Be $routeName

        # Get - List / by name / ViaIdentity
        $routes = Get-AzFrontDoorCdnRoute -ResourceGroupName $env.ResourceGroupName -ProfileName $env.FrontDoorCdnProfileName -EndpointName $endpointName
        $routes.Count | Should -BeGreaterOrEqual 1
        $getRoute = Get-AzFrontDoorCdnRoute -ResourceGroupName $env.ResourceGroupName -ProfileName $env.FrontDoorCdnProfileName -EndpointName $endpointName -Name $routeName
        $getRoute.Name | Should -Be $routeName
        $getRoute2 = Get-AzFrontDoorCdnRoute -InputObject $getRoute
        $getRoute2.Name | Should -Be $routeName

        # Update + Update ViaIdentity
        Update-AzFrontDoorCdnRoute -ResourceGroupName $env.ResourceGroupName -ProfileName $env.FrontDoorCdnProfileName -EndpointName $endpointName -Name $routeName -EnabledState "Disabled"
        $updatedRoute = Get-AzFrontDoorCdnRoute -ResourceGroupName $env.ResourceGroupName -ProfileName $env.FrontDoorCdnProfileName -EndpointName $endpointName -Name $routeName
        $updatedRoute.EnabledState | Should -Be "Disabled"
        Update-AzFrontDoorCdnRoute -EnabledState "Enabled" -InputObject $updatedRoute

        # Remove
        Remove-AzFrontDoorCdnRoute -ResourceGroupName $env.ResourceGroupName -ProfileName $env.FrontDoorCdnProfileName -EndpointName $endpointName -Name $routeName
    }
}
