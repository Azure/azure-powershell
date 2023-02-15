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

Describe 'Update-AzFrontDoorCdnRoute' -Tag 'LiveOnly' {
    It 'UpdateExpanded' {
        { 
            $PSDefaultParameterValues['Disabled'] = $true
            $ResourceGroupName = 'testps-rg-' + (RandomString -allChars $false -len 6)
            try
            {
                Write-Host -ForegroundColor Green "Create test group $($ResourceGroupName)"
                New-AzResourceGroup -Name $ResourceGroupName -Location $env.location

                $frontDoorCdnProfileName = 'fdp-' + (RandomString -allChars $false -len 6);
                Write-Host -ForegroundColor Green "Use frontDoorCdnProfileName : $($frontDoorCdnProfileName)"

                $profileSku = "Standard_AzureFrontDoor";
                New-AzFrontDoorCdnProfile -SkuName $profileSku -Name $frontDoorCdnProfileName -ResourceGroupName $ResourceGroupName -Location Global

                $endpointName = 'end-' + (RandomString -allChars $false -len 6);
                Write-Host -ForegroundColor Green "Use frontDoorCdnEndpointName : $($endpointName)"
                $endpoint = New-AzFrontDoorCdnEndpoint -EndpointName $endpointName -ProfileName $frontDoorCdnProfileName -ResourceGroupName $ResourceGroupName -Location Global

                $originGroupName = 'org' + (RandomString -allChars $false -len 6);
                $healthProbeSetting = New-AzFrontDoorCdnOriginGroupHealthProbeSettingObject -ProbeIntervalInSecond 1 -ProbePath "/" `
                -ProbeProtocol "Https" -ProbeRequestType "GET"
                $loadBalancingSetting = New-AzFrontDoorCdnOriginGroupLoadBalancingSettingObject -AdditionalLatencyInMillisecond 200 `
                -SampleSize 5 -SuccessfulSamplesRequired 4
                $originGroup = New-AzFrontDoorCdnOriginGroup -OriginGroupName $originGroupName -ProfileName $frontDoorCdnProfileName -ResourceGroupName $ResourceGroupName `
                -LoadBalancingSetting $loadBalancingSetting -HealthProbeSetting $healthProbeSetting

                Get-AzFrontDoorCdnOriginGroup -ResourceGroupName $ResourceGroupName -ProfileName $frontDoorCdnProfileName -OriginGroupName $originGroupName

                $hostName = "en.wikipedia.org";
                $originName = 'ori' + (RandomString -allChars $false -len 6);
                New-AzFrontDoorCdnOrigin -ResourceGroupName $ResourceGroupName -ProfileName $frontDoorCdnProfileName -OriginGroupName $originGroupName `
                -OriginName $originName -OriginHostHeader $hostName -HostName $hostName `
                -HttpPort 80 -HttpsPort 443 -Priority 1 -Weight 1000

                $rulesetName = 'rs' + (RandomString -allChars $false -len 6);
                Write-Host -ForegroundColor Green "Use rulesetName : $($rulesetName)"
                $ruleSet = New-AzFrontDoorCdnRuleSet -ProfileName $frontDoorCdnProfileName -ResourceGroupName $ResourceGroupName -Name $rulesetName
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

                $ruleSetResoure = New-AzFrontDoorCdnResourceReferenceObject -Id $ruleSet.Id

                $routeName = 'route' + (RandomString -allChars $false -len 6);
                New-AzFrontDoorCdnRoute -Name $routeName -EndpointName $endpointName -ProfileName $frontDoorCdnProfileName -ResourceGroupName $ResourceGroupName `
                -OriginGroupId $originGroup.Id -RuleSet @($ruleSetResoure) -PatternsToMatch "/*" -LinkToDefaultDomain "Enabled" -EnabledState "Enabled"
            
                Update-AzFrontDoorCdnRoute -ResourceGroupName $ResourceGroupName -ProfileName $frontDoorCdnProfileName -EndpointName $endpointName -Name $routeName `
                -EnabledState "Disabled"
            } Finally
            {
                Remove-AzResourceGroup -Name $ResourceGroupName -NoWait
            }
        } | Should -Not -Throw
    }

    It 'UpdateViaIdentityExpanded' {
        { 
            $PSDefaultParameterValues['Disabled'] = $true
            $ResourceGroupName = 'testps-rg-' + (RandomString -allChars $false -len 6)
            try
            {
                Write-Host -ForegroundColor Green "Create test group $($ResourceGroupName)"
                New-AzResourceGroup -Name $ResourceGroupName -Location $env.location

                $frontDoorCdnProfileName = 'fdp-' + (RandomString -allChars $false -len 6);
                Write-Host -ForegroundColor Green "Use frontDoorCdnProfileName : $($frontDoorCdnProfileName)"

                $profileSku = "Standard_AzureFrontDoor";
                New-AzFrontDoorCdnProfile -SkuName $profileSku -Name $frontDoorCdnProfileName -ResourceGroupName $ResourceGroupName -Location Global

                $endpointName = 'end-' + (RandomString -allChars $false -len 6);
                Write-Host -ForegroundColor Green "Use frontDoorCdnEndpointName : $($endpointName)"
                $endpoint = New-AzFrontDoorCdnEndpoint -EndpointName $endpointName -ProfileName $frontDoorCdnProfileName -ResourceGroupName $ResourceGroupName -Location Global

                $originGroupName = 'org' + (RandomString -allChars $false -len 6);
                $healthProbeSetting = New-AzFrontDoorCdnOriginGroupHealthProbeSettingObject -ProbeIntervalInSecond 1 -ProbePath "/" `
                -ProbeProtocol "Https" -ProbeRequestType "GET"
                $loadBalancingSetting = New-AzFrontDoorCdnOriginGroupLoadBalancingSettingObject -AdditionalLatencyInMillisecond 200 `
                -SampleSize 5 -SuccessfulSamplesRequired 4
                $originGroup = New-AzFrontDoorCdnOriginGroup -OriginGroupName $originGroupName -ProfileName $frontDoorCdnProfileName -ResourceGroupName $ResourceGroupName `
                -LoadBalancingSetting $loadBalancingSetting -HealthProbeSetting $healthProbeSetting

                Get-AzFrontDoorCdnOriginGroup -ResourceGroupName $ResourceGroupName -ProfileName $frontDoorCdnProfileName -OriginGroupName $originGroupName

                $hostName = "en.wikipedia.org";
                $originName = 'ori' + (RandomString -allChars $false -len 6);
                New-AzFrontDoorCdnOrigin -ResourceGroupName $ResourceGroupName -ProfileName $frontDoorCdnProfileName -OriginGroupName $originGroupName `
                -OriginName $originName -OriginHostHeader $hostName -HostName $hostName `
                -HttpPort 80 -HttpsPort 443 -Priority 1 -Weight 1000

                $rulesetName = 'rs' + (RandomString -allChars $false -len 6);
                Write-Host -ForegroundColor Green "Use rulesetName : $($rulesetName)"
                $ruleSet = New-AzFrontDoorCdnRuleSet -ProfileName $frontDoorCdnProfileName -ResourceGroupName $ResourceGroupName -Name $rulesetName
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

                $ruleSetResoure = New-AzFrontDoorCdnResourceReferenceObject -Id $ruleSet.Id

                $routeName = 'route' + (RandomString -allChars $false -len 6);
                New-AzFrontDoorCdnRoute -Name $routeName -EndpointName $endpointName -ProfileName $frontDoorCdnProfileName -ResourceGroupName $ResourceGroupName `
                -OriginGroupId $originGroup.Id -RuleSet @($ruleSetResoure) -PatternsToMatch "/*" -LinkToDefaultDomain "Enabled" -EnabledState "Enabled"
            
                Get-AzFrontDoorCdnRoute -ResourceGroupName $ResourceGroupName -ProfileName $frontDoorCdnProfileName -EndpointName $endpointName -Name $routeName `
                | Update-AzFrontDoorCdnRoute -EnabledState "Disabled"
            } Finally
            {
                Remove-AzResourceGroup -Name $ResourceGroupName -NoWait
            }
        } | Should -Not -Throw
    }
}
