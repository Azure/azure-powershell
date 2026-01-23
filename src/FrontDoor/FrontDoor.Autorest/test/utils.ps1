function RandomString([bool]$allChars, [int32]$len) {
    if ($allChars) {
        return -join ((33..126) | Get-Random -Count $len | % {[char]$_})
    } else {
        return -join ((48..57) + (97..122) | Get-Random -Count $len | % {[char]$_})
    }
}
function Start-TestSleep {
    [CmdletBinding(DefaultParameterSetName = 'SleepBySeconds')]
    param(
        [parameter(Mandatory = $true, Position = 0, ParameterSetName = 'SleepBySeconds')]
        [ValidateRange(0.0, 2147483.0)]
        [double] $Seconds,

        [parameter(Mandatory = $true, ParameterSetName = 'SleepByMilliseconds')]
        [ValidateRange('NonNegative')]
        [Alias('ms')]
        [int] $Milliseconds
    )

    if ($TestMode -ne 'playback') {
        switch ($PSCmdlet.ParameterSetName) {
            'SleepBySeconds' {
                Start-Sleep -Seconds $Seconds
            }
            'SleepByMilliseconds' {
                Start-Sleep -Milliseconds $Milliseconds
            }
        }
    }
}

$env = @{}
if ($UsePreviousConfigForRecord) {
    $previousEnv = Get-Content (Join-Path $PSScriptRoot 'env.json') | ConvertFrom-Json
    $previousEnv.psobject.properties | Foreach-Object { $env[$_.Name] = $_.Value }
}
# Add script method called AddWithCache to $env, when useCache is set true, it will try to get the value from the $env first.
# example: $val = $env.AddWithCache('key', $val, $true)
$env | Add-Member -Type ScriptMethod -Value { param( [string]$key, [object]$val, [bool]$useCache) if ($this.Contains($key) -and $useCache) { return $this[$key] } else { $this[$key] = $val; return $val } } -Name 'AddWithCache'
function setupEnv() {
    Write-Host -ForegroundColor Green "Start to import module."
    Import-Module -Name Az.Cdn

    $env.SubscriptionId = (Get-AzContext).Subscription.Id
    $env.Tenant = $res.Tenant.Id
    $env.location = 'westus'
    $resourceGroupName = 'testps-rg-' + (RandomString -allChars $false -len 4)
    Write-Host -ForegroundColor Green "Start to create test group $($resourceGroupName)"
    New-AzResourceGroup -Name $resourceGroupName -Location $env.location
    $env.Add("ResourceGroupName", $resourceGroupName)

    Write-Host -ForegroundColor Green "Start to create test frontdoor."
    $frontDoorName = 'testps-fd-' + (RandomString -allChars $false -len 4)
    $tags = @{"tag1" = "value1"; "tag2" = "value2"}
    $hostName = "$frontDoorName.azurefd.net"
    $routingrule1 = New-AzFrontDoorRoutingRuleObject -Name "routingrule1" -FrontDoorName $frontDoorName -ResourceGroupName $resourceGroupName -FrontendEndpointName "frontendEndpoint1" -BackendPoolName "backendPool1"
    $backend1 = New-AzFrontDoorBackendObject -Address "contoso1.azurewebsites.net" 
    $healthProbeSetting1 = New-AzFrontDoorHealthProbeSettingObject -Name "healthProbeSetting1" -HealthProbeMethod "Head" -EnabledState "Disabled"
    $loadBalancingSetting1 = New-AzFrontDoorLoadBalancingSettingObject -Name "loadbalancingsetting1" 
    $frontendEndpoint1 = New-AzFrontDoorFrontendEndpointObject -Name "frontendendpoint1" -HostName $hostName
    $backendpool1 = New-AzFrontDoorBackendPoolObject -Name "backendpool1" -FrontDoorName $frontDoorName -ResourceGroupName $resourceGroupName -Backend $backend1 -HealthProbeSettingsName "healthProbeSetting1" -LoadBalancingSettingsName "loadBalancingSetting1"
    $backendPoolsSetting1 = New-AzFrontDoorBackendPoolsSettingObject -SendRecvTimeoutInSeconds 33 -EnforceCertificateNameCheck "Enabled"
    New-AzFrontDoor -Name $frontDoorName -ResourceGroupName $resourceGroupName -RoutingRule $routingrule1 -BackendPool $backendpool1 -BackendPoolsSetting $backendPoolsSetting1 -FrontendEndpoint $frontendEndpoint1 -LoadBalancingSetting $loadBalancingSetting1 -HealthProbeSetting $healthProbeSetting1 -Tag $tags
    $env.Add("FrontDoorName", $frontDoorName)

    Write-Host -ForegroundColor Green "Successfully created frontdoor $($frontDoorName)."

    Write-Host -ForegroundColor Green "Start to create test rules engine."

    $conditions = New-AzFrontDoorRulesEngineMatchConditionObject -MatchVariable "RequestHeader" -Operator "Equal" -MatchValue "forward" -Transform "Lowercase" -Selector "Rules-Engine-Route-Forward" -NegateCondition $false
	$headerActions = New-AzFrontDoorHeaderActionObject -HeaderActionType "Append" -HeaderName "X-Content-Type-Options" -Value "nosniff"
	$ruleEngineResponseHeaderAction = New-AzFrontDoorRulesEngineActionObject -ResponseHeaderAction $headerActions	
	$ruleEngineResponseHeaderRule = New-AzFrontDoorRulesEngineRuleObject -Name "rule101" -Priority 1 -Action $ruleEngineResponseHeaderAction -MatchCondition $conditions

	$ruleEngineForwardAction = New-AzFrontDoorRulesEngineActionObject -ForwardingProtocol "HttpsOnly" -BackendPoolName "backendpool1" -ResourceGroupName $resourceGroupName -FrontDoorName $frontDoorName -QueryParameterStripDirective "StripNone" -DynamicCompression "Disabled" -EnableCaching $true
	$ruleEngineForwardRule = New-AzFrontDoorRulesEngineRuleObject -Name "rule102" -Priority 2 -Action $ruleEngineForwardAction -MatchCondition $conditions

	$redirectConditions = New-AzFrontDoorRulesEngineMatchConditionObject -MatchVariable "RequestHeader" -Operator Equal -MatchValue "redirect" -Transform "Lowercase" -Selector "Rules-Engine-Route-Forward" -NegateCondition $false
	$ruleEngineRedirectAction = New-AzFrontDoorRulesEngineActionObject -RedirectProtocol "MatchRequest" -CustomHost "www.contoso.com" -RedirectType "Moved"
	$ruleEngineRedirectRule = New-AzFrontDoorRulesEngineRuleObject -Name "rule103" -Priority 3 -Action $ruleEngineRedirectAction -MatchCondition $redirectConditions

	New-AzFrontDoorRulesEngine -ResourceGroupName $resourceGroupName -Rule $ruleEngineResponseHeaderRule,$ruleEngineForwardRule,$ruleEngineRedirectRule -FrontDoorName $frontDoorName -Name "engine101"
    $env.Add("RuleEngineName", "engine101")

    Write-Host -ForegroundColor Green "Successfully created rules engine engine101."

    Write-Host -ForegroundColor Green "Start to create test waf policy."
 
    $wafName = 'testpsWaf' + (RandomString -allChars $false -len 4)
    $matchCondition1 = New-AzFrontDoorWafMatchConditionObject -MatchVariable "RequestHeader" -OperatorProperty "Contains" -Selector "UserAgent" -MatchValue "WINDOWS" -Transform "Uppercase"
    $customRule1 = New-AzFrontDoorWafCustomRuleObject -Name "Rule1" -RuleType "MatchRule" -MatchCondition $matchCondition1 -Action Block -Priority 2

    # Create exclusion objects
    $exclusionRule = New-AzFrontDoorWafManagedRuleExclusionObject -Variable "QueryStringArgNames" -Operator "Equals" -Selector "ExcludeInRule"
    $exclusionGroup = New-AzFrontDoorWafManagedRuleExclusionObject -Variable "QueryStringArgNames" -Operator "Equals" -Selector "ExcludeInGroup"
    $exclusionSet = New-AzFrontDoorWafManagedRuleExclusionObject -Variable "QueryStringArgNames" -Operator "Equals" -Selector "ExcludeInSet"

    $ruleOverride = New-AzFrontDoorWafManagedRuleOverrideObject -RuleId "942100" -Action "Log" -Exclusion $exclusionRule
    $override1 = New-AzFrontDoorWafRuleGroupOverrideObject -RuleGroupName "SQLI" -ManagedRuleOverride $ruleOverride -Exclusion $exclusionGroup
    $managedRule1 = New-AzFrontDoorWafManagedRuleObject -Type "DefaultRuleSet" -Version "1.0" -RuleGroupOverride $override1 -Exclusion $exclusionSet
    $managedRule2 = New-AzFrontDoorWafManagedRuleObject -Type "BotProtection" -Version "preview-0.1"

    $logScrubbingRule = New-AzFrontDoorWafLogScrubbingRuleObject -MatchVariable "RequestHeaderNames" -SelectorMatchOperator "EqualsAny" -State "Enabled"
    $logscrubbingSetting = New-AzFrontDoorWafLogScrubbingSettingObject -State "Enabled" -ScrubbingRule @($logScrubbingRule)

    New-AzFrontDoorWafPolicy -Name $wafName -ResourceGroupName $resourceGroupName -Sku "Premium_AzureFrontDoor" -Customrule $customRule1 -ManagedRule $managedRule1,$managedRule2 -EnabledState "Enabled" -Mode "Prevention" -RequestBodyCheck "Disabled" -LogScrubbingSetting $logscrubbingSetting -JavascriptChallengeExpirationInMinutes 30  

    $env.Add("WafPolicyName", $wafName)

    # Generate names for other tests
    $wafNameForCreate = 'testpsWaf' + (RandomString -allChars $false -len 4)
    $env.Add("WafPolicyNameForCreate", $wafNameForCreate)
    
    $wafNameForDelete = 'testpsWaf' + (RandomString -allChars $false -len 4)
    $env.Add("WafPolicyNameForDelete", $wafNameForDelete)
    
    $frontDoorNameForDelete = 'testps-fd-' + (RandomString -allChars $false -len 4)
    $env.Add("FrontDoorNameForDelete", $frontDoorNameForDelete)
    
    $frontDoorNameForUpdate = 'testps-fd-' + (RandomString -allChars $false -len 4)
    $env.Add("FrontDoorNameForUpdate", $frontDoorNameForUpdate)

    # Preload subscriptionId and tenant from context, which will be used in test
    # as default. You could change them if needed.
    $env.SubscriptionId = (Get-AzContext).Subscription.Id
    $env.Tenant = (Get-AzContext).Tenant.Id
    # For any resources you created for test, you should add it to $env here.
    $envFile = 'env.json'
    if ($TestMode -eq 'live') {
        $envFile = 'localEnv.json'
    }
    set-content -Path (Join-Path $PSScriptRoot $envFile) -Value (ConvertTo-Json $env)
}
function cleanupEnv() {
    # Clean resources you create for testing
    Write-Host -ForegroundColor Green "Clean resources created for testing."
    Remove-AzResourceGroup -Name $env.ResourceGroupName
}

