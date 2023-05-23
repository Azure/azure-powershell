function RandomString([bool]$allChars, [int32]$len) {
    if ($allChars) {
        return -join ((33..126) | Get-Random -Count $len | % {[char]$_})
    } else {
        return -join ((48..57) + (97..122) | Get-Random -Count $len | % {[char]$_})
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
    Import-Module -Name Az.FrontDoor
    Import-Module -Name Az.KeyVault
    
    # Preload subscriptionId and tenant from context, which will be used in test
    # as default. You could change them if needed.
    $env.SubscriptionId = (Get-AzContext).Subscription.Id
    $subId = $env.SubscriptionId
    $env.Tenant = $res.Tenant.Id
    $env.location = 'westus'

    # For any resources you created for test, you should add it to $env here.
    # Create the test group
    $resourceGroupName = 'testps-rg-' + (RandomString -allChars $false -len 4)
    Write-Host -ForegroundColor Green "Start to create test group $($resourceGroupName)"
    New-AzResourceGroup -Name $resourceGroupName -Location $env.location

    $env.Add("ResourceGroupName", $resourceGroupName)

    ## Create profile, Standard Verizon SKU
    $verizonCdnProfileName = 'p-' + (RandomString -allChars $false -len 6);
    Write-Host -ForegroundColor Green "Start to create Standard_Verizon SKU profile : $($verizonCdnProfileName)"    
    New-AzCdnProfile -SkuName "Standard_Verizon" -Name $verizonCdnProfileName -ResourceGroupName $resourceGroupName -Location Global | Out-Null

    # Create endpoint, Standard Verizon SKU 
    $verizonEndpointName = 'e-' + (RandomString -allChars $false -len 6);
    $origin = @{
        Name = "origin1"
        HostName = "host1.hello.com"
    };
    Write-Host -ForegroundColor Green "Start to creat endpointName : $($verizonEndpointName), origin.Name : $($origin.Name), origin.HostName : $($origin.HostName)"
    New-AzCdnEndpoint -Name $verizonEndpointName -ResourceGroupName $resourceGroupName -ProfileName $verizonCdnProfileName -IsHttpAllowed -IsHttpsAllowed `
        -Location $env.location -Origin $origin -IsCompressionEnabled -ContentTypesToCompress "text/html","text/css" `
        -OriginHostHeader "www.bing.com" -OriginPath "/photos" -QueryStringCachingBehavior "IgnoreQueryString" | Out-Null

    $env.Add("VerizonCdnProfileName", $verizonCdnProfileName)
    $env.Add("VerizonEndpointName", $verizonEndpointName)
    Write-Host -ForegroundColor Green "Standard_Verizon SKU resources have been added to the environment." 

    # Create profile, Standard Microsoft SKU
    $classicCdnProfileName = 'p-' + (RandomString -allChars $false -len 6)
    Write-Host -ForegroundColor Green "Start to create Standard_Microsoft SKU profile: $($classicCdnProfileName)"
    New-AzCdnProfile -SkuName "Standard_Microsoft" -Name $classicCdnProfileName -ResourceGroupName $resourceGroupName -Location Global | Out-Null
    
    # Hard-coding host and endpoint names due to requirement for DNS CNAME
    $classicCdnEndpointName = 'aa-powershell-20230421-oigr9w'
    $customDomainHostName = 'aa-powershell-20230421-oigr9w.cdne2e.azfdtest.xyz'
    $customDomainName = 'cd-' + (RandomString -allChars $false -len 6);
    $location = "westus"
    $origin = @{
        Name = "origin1"
        HostName = "host1.hello.com"
    };
    $originId = "/subscriptions/$subId/resourcegroups/$resourceGroupName/providers/Microsoft.Cdn/profiles/$classicCdnProfileName/endpoints/$classicCdnEndpointName/origins/$($origin.Name)"
    $healthProbeParametersObject = New-AzCdnHealthProbeParametersObject -ProbeIntervalInSecond 240 -ProbePath "/health.aspx" -ProbeProtocol "Https" -ProbeRequestType "GET" 
    $originGroup = @{
        Name = "originGroup1"
        healthProbeSetting = $healthProbeParametersObject 
        Origin = @(@{
            Id = $originId
        })
    }
    $defaultOriginGroup = "/subscriptions/$subId/resourcegroups/$resourceGroupName/providers/Microsoft.Cdn/profiles/$classicCdnProfileName/endpoints/$classicCdnEndpointName/origingroups/$($originGroup.Name)"
    
    Write-Host -ForegroundColor Green "Create endpointName : $($classicCdnEndpointName), origin.Name : $($origin.Name), origin.HostName : $($origin.HostName)"
    New-AzCdnEndpoint -Name $classicCdnEndpointName -ResourceGroupName $resourceGroupName -ProfileName $classicCdnProfileName -Location $location `
        -Origin $origin -OriginGroup $originGroup -DefaultOriginGroupId $defaultOriginGroup | Out-Null

    Write-Host -ForegroundColor Green "Create customDomainName : $($customDomainName), customDomainHostName: $($customDomainHostName)"
    New-AzCdnCustomDomain -EndpointName $classicCdnEndpointName -Name $customDomainName -ProfileName $classicCdnProfileName -ResourceGroupName $resourceGroupName -HostName $customDomainHostName | Out-Null

    $env.Add("ClassicCdnProfileName", $classicCdnProfileName)
    $env.Add("ClassicEndpointName", $classicCdnEndpointName)
    $env.Add("ClassicCustomDomainName", $customDomainName)
    $env.Add("ClassicCustomDomainHostName", $customDomainHostName)
    Write-Host -ForegroundColor Green "Standard_Microsoft Standard SKU resources have been added to the environment."    

    $frontDoorCdnProfileName = 'fdp-' + (RandomString -allChars $false -len 6);
    Write-Host -ForegroundColor Green "Start to create Stand_AzureFrontDoor SKU profile : $($frontDoorCdnProfileName)"
    New-AzFrontDoorCdnProfile -SkuName "Standard_AzureFrontDoor" -Name $frontDoorCdnProfileName -ResourceGroupName $resourceGroupName -Location Global | Out-Null

    $frontDoorCustomDomainName = "domain-" + (RandomString -allChars $false -len 6);
    Write-Host -ForegroundColor Green "Start to create Stand_AzureFrontDoor SKU custom domain : $($frontDoorCustomDomainName)"
    New-AzFrontDoorCdnCustomDomain -CustomDomainName $frontDoorCustomDomainName -ProfileName $frontDoorCdnProfileName -ResourceGroupName $resourceGroupName `
        -HostName "getdomain.dev.cdn.azure.cn" | Out-Null

    $frontDoorEndpointName = 'end-' + (RandomString -allChars $false -len 6);
    Write-Host -ForegroundColor Green "Start to create Stand_AzureFrontDoor SKU endpoint domain : $($frontDoorEndpointName)"
    New-AzFrontDoorCdnEndpoint -EndpointName $frontDoorEndpointName -ProfileName $frontDoorCdnProfileName -ResourceGroupName $ResourceGroupName -Location Global | Out-Null

    $env.Add("FrontDoorCdnProfileName", $frontDoorCdnProfileName)
    $env.Add("FrontDoorCustomDomainName", $frontDoorCustomDomainName)
    $env.Add("FrontDoorEndpointName", $frontDoorEndpointName)
    Write-Host -ForegroundColor Green "Standard_AzureFrontDoor SKU resources have been added to the environment." 
    
    $classicFDName01 = 'fdp-' + (RandomString -allChars $false -len 6);
    Write-Host -ForegroundColor Green "Use frontDoorName : $($classicFDName01)"

    $tags = @{"tag1" = "value1"; "tag2" = "value2"}
    $hostName = "$classicFDName01.azurefd.net"
    $routingrule1 = New-AzFrontDoorRoutingRuleObject -Name "routingrule1" -FrontDoorName $classicFDName01 -ResourceGroupName $env.ResourceGroupName -FrontendEndpointName "frontendEndpoint1" -BackendPoolName "backendPool1"
    $backend1 = New-AzFrontDoorBackendObject -Address "contoso1.azurewebsites.net" 
    $healthProbeSetting1 = New-AzFrontDoorHealthProbeSettingObject -Name "healthProbeSetting1" -HealthProbeMethod "Head" -EnabledState "Disabled"
    $loadBalancingSetting1 = New-AzFrontDoorLoadBalancingSettingObject -Name "loadbalancingsetting1" 
    $frontendEndpoint1 = New-AzFrontDoorFrontendEndpointObject -Name "frontendendpoint1" -HostName $hostName
    $backendpool1 = New-AzFrontDoorBackendPoolObject -Name "backendpool1" -FrontDoorName $classicFDName01 -ResourceGroupName $env.ResourceGroupName -Backend $backend1 -HealthProbeSettingsName "healthProbeSetting1" -LoadBalancingSettingsName "loadBalancingSetting1"
    $backendPoolsSetting1 = New-AzFrontDoorBackendPoolsSettingObject -SendRecvTimeoutInSeconds 33 -EnforceCertificateNameCheck "Enabled"
    
    New-AzFrontDoor -Name $classicFDName01 -ResourceGroupName $resourceGroupName -RoutingRule $routingrule1 -BackendPool $backendpool1 -BackendPoolsSetting $backendPoolsSetting1 -FrontendEndpoint $frontendEndpoint1 -LoadBalancingSetting $loadBalancingSetting1 -HealthProbeSetting $healthProbeSetting1 -Tag $tags | Out-Null
    $classicResourceId01 = "/subscriptions/$subId/resourcegroups/$resourceGroupName/providers/Microsoft.Network/Frontdoors/$classicFDName01"


    $classicFDName02 = 'fdp-' + (RandomString -allChars $false -len 6);
    Write-Host -ForegroundColor Green "Use frontDoorName : $($classicFDName02)"

    $tags = @{"tag1" = "value1"; "tag2" = "value2"}
    $hostName = "$classicFDName02.azurefd.net"
    $routingrule1 = New-AzFrontDoorRoutingRuleObject -Name "routingrule1" -FrontDoorName $classicFDName02 -ResourceGroupName $env.ResourceGroupName -FrontendEndpointName "frontendEndpoint1" -BackendPoolName "backendPool1"
    $backend1 = New-AzFrontDoorBackendObject -Address "contoso1.azurewebsites.net" 
    $healthProbeSetting1 = New-AzFrontDoorHealthProbeSettingObject -Name "healthProbeSetting1" -HealthProbeMethod "Head" -EnabledState "Disabled"
    $loadBalancingSetting1 = New-AzFrontDoorLoadBalancingSettingObject -Name "loadbalancingsetting1" 
    $frontendEndpoint1 = New-AzFrontDoorFrontendEndpointObject -Name "frontendendpoint1" -HostName $hostName
    $backendpool1 = New-AzFrontDoorBackendPoolObject -Name "backendpool1" -FrontDoorName $classicFDName02 -ResourceGroupName $env.ResourceGroupName -Backend $backend1 -HealthProbeSettingsName "healthProbeSetting1" -LoadBalancingSettingsName "loadBalancingSetting1"
    $backendPoolsSetting1 = New-AzFrontDoorBackendPoolsSettingObject -SendRecvTimeoutInSeconds 33 -EnforceCertificateNameCheck "Enabled"
    
    New-AzFrontDoor -Name $classicFDName02 -ResourceGroupName $resourceGroupName -RoutingRule $routingrule1 -BackendPool $backendpool1 -BackendPoolsSetting $backendPoolsSetting1 -FrontendEndpoint $frontendEndpoint1 -LoadBalancingSetting $loadBalancingSetting1 -HealthProbeSetting $healthProbeSetting1 -Tag $tags | Out-Null
    $classicResourceId02 = "/subscriptions/$subId/resourcegroups/$resourceGroupName/providers/Microsoft.Network/Frontdoors/$classicFDName02"

    $classicFDName03 = 'fdp-' + (RandomString -allChars $false -len 6);
    Write-Host -ForegroundColor Green "Use frontDoorName : $($classicFDName03)"

    $tags = @{"tag1" = "value1"; "tag2" = "value2"}
    $hostName = "$classicFDName03.azurefd.net"
    $routingrule1 = New-AzFrontDoorRoutingRuleObject -Name "routingrule1" -FrontDoorName $classicFDName03 -ResourceGroupName $env.ResourceGroupName -FrontendEndpointName "frontendEndpoint1" -BackendPoolName "backendPool1"
    $backend1 = New-AzFrontDoorBackendObject -Address "contoso1.azurewebsites.net" 
    $healthProbeSetting1 = New-AzFrontDoorHealthProbeSettingObject -Name "healthProbeSetting1" -HealthProbeMethod "Head" -EnabledState "Disabled"
    $loadBalancingSetting1 = New-AzFrontDoorLoadBalancingSettingObject -Name "loadbalancingsetting1" 
    $frontendEndpoint1 = New-AzFrontDoorFrontendEndpointObject -Name "frontendendpoint1" -HostName $hostName
    $backendpool1 = New-AzFrontDoorBackendPoolObject -Name "backendpool1" -FrontDoorName $classicFDName03 -ResourceGroupName $env.ResourceGroupName -Backend $backend1 -HealthProbeSettingsName "healthProbeSetting1" -LoadBalancingSettingsName "loadBalancingSetting1"
    $backendPoolsSetting1 = New-AzFrontDoorBackendPoolsSettingObject -SendRecvTimeoutInSeconds 33 -EnforceCertificateNameCheck "Enabled"
    
    New-AzFrontDoor -Name $classicFDName03 -ResourceGroupName $resourceGroupName -RoutingRule $routingrule1 -BackendPool $backendpool1 -BackendPoolsSetting $backendPoolsSetting1 -FrontendEndpoint $frontendEndpoint1 -LoadBalancingSetting $loadBalancingSetting1 -HealthProbeSetting $healthProbeSetting1 -Tag $tags | Out-Null
    $classicResourceId03 = "/subscriptions/$subId/resourcegroups/$resourceGroupName/providers/Microsoft.Network/Frontdoors/$classicFDName03"

    $env.Add("ClassicResourceId01", $classicResourceId01)
    $env.Add("ClassicResourceId02", $classicResourceId02)
    $env.Add("ClassicResourceId03", $classicResourceId03)

    Write-Host -ForegroundColor Green "Classic Afd resources have been added to the environment." 

    # Create 
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