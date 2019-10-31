# ----------------------------------------------------------------------------------
#
# Copyright Microsoft Corporation
# Licensed under the Apache License, Version 2.0 (the "License");
# you may not use this file except in compliance with the License.
# You may obtain a copy of the License at
# http://www.apache.org/licenses/LICENSE-2.0
# Unless required by applicable law or agreed to in writing, software
# distributed under the License is distributed on an "AS IS" BASIS,
# WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
# See the License for the specific language governing permissions and
# limitations under the License.
# ----------------------------------------------------------------------------------

<#
.SYNOPSIS
Full Endpoint CRUD cycle
#>
function Test-EndpointCrudAndAction
{
    $profileName = getAssetName
    $resourceGroup = TestSetup-CreateResourceGroup
    $resourceLocation = "EastUS"
    $profileSku = "Standard_Microsoft"
    $createdProfile = New-AzCdnProfile -ProfileName $profileName -ResourceGroupName $resourceGroup.ResourceGroupName -Location $resourceLocation -Sku $profileSku

    $endpointName = getAssetName
    $originName = getAssetName
    $originHostName = "www.microsoft.com"

    $nameAvailability = Get-AzCdnEndpointNameAvailability -EndpointName $endpointName
    Assert-True{$nameAvailability.NameAvailable}

	$description = 'Sample delivery policy'
    $action = New-AzCdnDeliveryRuleAction -HeaderActionType ModifyResponseHeader -Action Append -HeaderName "Access-Control-Allow-Origin" -Value "*"
    $condition = New-AzCdnDeliveryRuleCondition -MatchVariable UrlPath -Operator Contains -MatchValue "abc"
    $deliveryRule = New-AzCdnDeliveryRule -Name "Rule1" -Order 1 -Condition $condition -Action $action
    $deliveryPolicy = New-AzCdnDeliveryPolicy -Description $description -Rule $deliveryRule

    $createdEndpoint = New-AzCdnEndpoint -EndpointName $endpointName -ProfileName $profileName -ResourceGroupName $resourceGroup.ResourceGroupName -Location $resourceLocation -OriginName $originName -OriginHostName $originHostName -DeliveryPolicy $deliveryPolicy
	Assert-AreEqual $description $createdEndpoint.DeliveryPolicy.Description
    Assert-AreEqual $endpointName $createdEndpoint.Name
    Assert-AreEqual $profileName $createdEndpoint.ProfileName
    Assert-AreEqual $resourceGroup.ResourceGroupName $createdEndpoint.ResourceGroupName
    Assert-AreEqual $originName $createdEndpoint.Origins[0].Name
    Assert-AreEqual $originHostName $createdEndpoint.Origins[0].HostName


    $nameAvailability = Get-AzCdnEndpointNameAvailability -EndpointName $endpointName
    Assert-False{$nameAvailability.NameAvailable}

    $stopped = Stop-AzCdnEndpoint -EndpointName $endpointName -ProfileName $profileName -ResourceGroupName $resourceGroup.ResourceGroupName -Confirm:$false -PassThru
    $stoppedEndpoint = Get-AzCdnEndpoint -EndpointName $endpointName -ProfileName $profileName -ResourceGroupName $resourceGroup.ResourceGroupName
    Assert-True{$stopped}
    Assert-AreEqual "Stopped" $stoppedEndpoint.ResourceState

    $started = Start-AzCdnEndpoint -EndpointName $endpointName -ProfileName $profileName -ResourceGroupName $resourceGroup.ResourceGroupName -PassThru
    $startedEndpoint = Get-AzCdnEndpoint -EndpointName $endpointName -ProfileName $profileName -ResourceGroupName $resourceGroup.ResourceGroupName
    Assert-True{$started}
    Assert-AreEqual "Running" $startedEndpoint.ResourceState

    $validateResult = Test-AzCdnCustomDomain -EndpointName $endpointName -ProfileName $profileName -ResourceGroupName $resourceGroup.ResourceGroupName -CustomDomainHostName "unverifiedcustomdomain.com"
    Assert-False{$validateResult.CustomDomainValidated}

    $endpointRemoved = Remove-AzCdnEndpoint -EndpointName $endpointName -ProfileName $profileName -ResourceGroupName $resourceGroup.ResourceGroupName -PassThru -Force
    Assert-True{$endpointRemoved}

    Assert-ThrowsContains { Get-AzCdnEndpoint -EndpointName $endpointName -ProfileName $profileName -ResourceGroupName $resourceGroup.ResourceGroupName } "NotFound"

    Remove-AzResourceGroup -Name $resourceGroup.ResourceGroupName -Force
}

<#
.SYNOPSIS
Create ENdpoint with RulesEngine config
#>
function Test-EndpointCreateWithRulesEngine
{
    $profileName = getAssetName
    $resourceGroup = TestSetup-CreateResourceGroup
    $resourceLocation = "EastUS"
    $profileSku = "Standard_Microsoft"
    $createdProfile = New-AzCdnProfile -ProfileName $profileName -ResourceGroupName $resourceGroup.ResourceGroupName -Location $resourceLocation -Sku $profileSku

    $endpointName = getAssetName
    $originName = getAssetName
    $originHostName = "www.microsoft.com"

    $nameAvailability = Get-AzCdnEndpointNameAvailability -EndpointName $endpointName
    Assert-True{$nameAvailability.NameAvailable}

	$description = 'Sample delivery policy'
    $cond1 = New-AzCdnDeliveryRuleCondition -MatchVariable IsDevice -Operator Equal -MatchValue "Desktop"
    $action1 = New-AzCdnDeliveryRuleAction -SourcePattern "/abc" -Destination "/def" -PreservePath
    $action2 = New-AzCdnDeliveryRuleAction -QueryStringBehavior ExcludeAll -QueryParameter "abc","def"
    $action3 = New-AzCdnDeliveryRuleAction -QueryStringBehavior IncludeAll
    $redirect = New-AzCdnDeliveryRuleAction -RedirectType Found -DestinationProtocol MatchRequest
    $rule0 = New-AzCdnDeliveryRule -Name "EmptyCondition" -Order 0 -Action $redirect,$action3
    $rule1 = New-AzCdnDeliveryRule -Name "Rule1" -Order 1 -Condition $cond1 -Action $action1,$action2
    $deliverypolicy = New-AzCdnDeliveryPolicy -Description $description -Rule $rule0,$rule1

    $createdEndpoint = New-AzCdnEndpoint -EndpointName $endpointName -ProfileName $profileName -ResourceGroupName $resourceGroup.ResourceGroupName -Location $resourceLocation -OriginName $originName -OriginHostName $originHostName -DeliveryPolicy $deliveryPolicy
	Assert-AreEqual $description $createdEndpoint.DeliveryPolicy.Description
    Assert-AreEqual $endpointName $createdEndpoint.Name
    Assert-AreEqual $deliverypolicy.Count $createdEndpoint.DeliveryPolicy.Count
    Assert-AreEqual $profileName $createdEndpoint.ProfileName
    Assert-AreEqual $resourceGroup.ResourceGroupName $createdEndpoint.ResourceGroupName
    Assert-AreEqual $originName $createdEndpoint.Origins[0].Name
    Assert-AreEqual $originHostName $createdEndpoint.Origins[0].HostName

    $endpointRemoved = Remove-AzCdnEndpoint -EndpointName $endpointName -ProfileName $profileName -ResourceGroupName $resourceGroup.ResourceGroupName -PassThru -Force
    Assert-True{$endpointRemoved}

    Assert-ThrowsContains { Get-AzCdnEndpoint -EndpointName $endpointName -ProfileName $profileName -ResourceGroupName $resourceGroup.ResourceGroupName } "NotFound"

    Remove-AzResourceGroup -Name $resourceGroup.ResourceGroupName -Force
}


<#
.SYNOPSIS
Endpoint cycle with piping
#>
function Test-EndpointCrudAndActionWithPiping
{
    $profileName = getAssetName
    $resourceGroup = TestSetup-CreateResourceGroup
    $resourceLocation = "EastUS"
    $profileSku = "Standard_Microsoft"
    $createdProfile = New-AzCdnProfile -ProfileName $profileName -ResourceGroupName $resourceGroup.ResourceGroupName -Location $resourceLocation -Sku $profileSku

    $endpointName = getAssetName
    $originName = getAssetName
    $originHostName = "www.microsoft.com"

    $nameAvailability = Get-AzCdnEndpointNameAvailability -EndpointName $endpointName
    Assert-True{$nameAvailability.NameAvailable}
    $createdEndpoint = New-AzCdnEndpoint -EndpointName $endpointName -ProfileName $profileName -ResourceGroupName $resourceGroup.ResourceGroupName -Location $resourceLocation -OriginName $originName -OriginHostName $originHostName

    Assert-AreEqual $endpointName $createdEndpoint.Name
    Assert-AreEqual $profileName $createdEndpoint.ProfileName
    Assert-AreEqual $resourceGroup.ResourceGroupName $createdEndpoint.ResourceGroupName
    Assert-AreEqual $originName $createdEndpoint.Origins[0].Name
    Assert-AreEqual $originHostName $createdEndpoint.Origins[0].HostName

    $nameAvailability = Get-AzCdnEndpointNameAvailability -EndpointName $endpointName
    Assert-False{$nameAvailability.NameAvailable}

    $stopped = Stop-AzCdnEndpoint -CdnEndpoint $createdEndpoint -Confirm:$false -PassThru
    $stoppedEndpoint = Get-AzCdnEndpoint -EndpointName $endpointName -ProfileName $profileName -ResourceGroupName $resourceGroup.ResourceGroupName
    Assert-True{$stopped}
    Assert-AreEqual "Stopped" $stoppedEndpoint.ResourceState

    $started = Start-AzCdnEndpoint -CdnEndpoint $createdEndpoint -PassThru
    $startedEndpoint = Get-AzCdnEndpoint -EndpointName $endpointName -ProfileName $profileName -ResourceGroupName $resourceGroup.ResourceGroupName
    Assert-True{$started}
    Assert-AreEqual "Running" $startedEndpoint.ResourceState

    $validateResultbyPiping = Test-AzCdnCustomDomain -CdnEndpoint $createdEndpoint -CustomDomainHostName "unverifiedcustomdomain.com"
    Assert-False{$validateResultbyPiping.CustomDomainValidated}

    $startedEndpoint.OriginHostHeader = "www.microsoft.com"
    $startedEndpoint.OriginPath = "/pictures"
    $startedEndpoint.QueryStringCachingBehavior = "UseQueryString"

    $description = "Updated Delivery Policy"
    $action = New-AzCdnDeliveryRuleAction -HeaderActionType ModifyResponseHeader -Action Append -HeaderName "Access-Control-Allow-Origin" -Value "*"
    $condition = New-AzCdnDeliveryRuleCondition -MatchVariable UrlPath -Operator Contains -MatchValue "abc"
    $newRule = New-AzCdnDeliveryRule -Name "Rule1" -Order 1 -Condition $condition -Action $action
    $deliveryPolicy = New-AzCdnDeliveryPolicy -Description $description -Rule $newRule

	$startedEndpoint.DeliveryPolicy = $deliveryPolicy

    $updatedEndpoint = Set-AzCdnEndpoint -CdnEndpoint $startedEndpoint
    Assert-AreEqual $startedEndpoint.OriginHostHeader $updatedEndpoint.OriginHostHeader
    Assert-AreEqual $startedEndpoint.OriginPath $updatedEndpoint.OriginPath
    Assert-AreEqual $startedEndpoint.QueryStringCachingBehavior $updatedEndpoint.QueryStringCachingBehavior
	Assert-AreEqual $startedEndpoint.DeliveryPolicy.Description $updatedEndpoint.DeliveryPolicy.Description

    $endpointRemoved = Remove-AzCdnEndpoint -CdnEndpoint $createdEndpoint -Force -PassThru
    Assert-True{$endpointRemoved}

    Assert-ThrowsContains { Get-AzCdnEndpoint -EndpointName $endpointName -ProfileName $profileName -ResourceGroupName $resourceGroup.ResourceGroupName } "NotFound"

    Remove-AzResourceGroup -Name $resourceGroup.ResourceGroupName -Force
}

<#
.SYNOPSIS
Endpoint cycle with all of the properties
#>
function Test-EndpointCrudAndActionWithAllProperties
{
    $profileName = getAssetName
    $resourceGroup = TestSetup-CreateResourceGroup
    $resourceLocation = "EastUS"
    $profileSku = "Standard_Verizon"
    $createdProfile = New-AzCdnProfile -ProfileName $profileName -ResourceGroupName $resourceGroup.ResourceGroupName -Location $resourceLocation -Sku $profileSku

    $endpointName = getAssetName
    $originName = getAssetName
    $originHostHeader = "www.microsoft.com"
    $originPath = "/videos"
    $contentTypeToCompress = @("application/json", "text/html")
    $isCompressionEnabled = $true
    $isHttpAllowed = $true
    $isHttpsAllowed = $true
    $queryStringCachingBehavior = "BypassCaching"
    $httpPort = 123
    $httpsPort = 456
	$optimizationType = "GeneralWebDelivery"
    $tags = @{"tag1" = "value1"; "tag2" = "value2"}

    $originHostName = "www.microsoft.com"

    $nameAvailability = Get-AzCdnEndpointNameAvailability -EndpointName $endpointName
    Assert-True{$nameAvailability.NameAvailable}

    $createdEndpoint = New-AzCdnEndpoint -EndpointName $endpointName -ProfileName $profileName -ResourceGroupName $resourceGroup.ResourceGroupName -Location $resourceLocation -OriginHostHeader $originHostHeader -OriginPath $originPath -ContentTypesToCompress $contentTypeToCompress -IsCompressionEnabled $isCompressionEnabled -IsHttpAllowed $isHttpAllowed -IsHttpsAllowed $isHttpsAllowed -OptimizationType $optimizationType -QueryStringCachingBehavior $queryStringCachingBehavior -OriginName $originName -OriginHostName $originHostName -HttpPort $httpPort -HttpsPort $httpsPort -Tag $tags

    Assert-AreEqual $endpointName $createdEndpoint.Name
    Assert-AreEqual $profileName $createdEndpoint.ProfileName
    Assert-AreEqual $resourceGroup.ResourceGroupName $createdEndpoint.ResourceGroupName
    Assert-NotNull $createdEndpoint.HostName
    Assert-AreEqual $originHostHeader $createdEndpoint.OriginHostHeader
    Assert-AreEqual $originPath $createdEndpoint.OriginPath
    Assert-CompressionTypes $contentTypeToCompress $createdEndpoint.ContentTypesToCompress
    Assert-AreEqual $isCompressionEnabled $createdEndpoint.IsCompressionEnabled
    Assert-AreEqual $isHttpAllowed $createdEndpoint.IsHttpAllowed
    Assert-AreEqual $isHttpsAllowed $createdEndpoint.IsHttpsAllowed
	Assert-AreEqual $optimizationType $createdEndpoint.OptimizationType
    Assert-AreEqual $queryStringCachingBehavior $createdEndpoint.QueryStringCachingBehavior
    Assert-Tags $tags $createdEndpoint.Tags

    Assert-AreEqual $httpPort $createdEndpoint.Origins[0].HttpPort
    Assert-AreEqual $httpsPort $createdEndpoint.Origins[0].HttpsPort
    Assert-AreEqual $originName $createdEndpoint.Origins[0].Name
    Assert-AreEqual $originHostName $createdEndpoint.Origins[0].HostName

    $nameAvailability = Get-AzCdnEndpointNameAvailability -EndpointName $endpointName
    Assert-False{$nameAvailability.NameAvailable}

    $stopped = Stop-AzCdnEndpoint -EndpointName $endpointName -ProfileName $profileName -ResourceGroupName $resourceGroup.ResourceGroupName -Confirm:$false -PassThru
    $stoppedEndpoint = Get-AzCdnEndpoint -EndpointName $endpointName -ProfileName $profileName -ResourceGroupName $resourceGroup.ResourceGroupName
    Assert-True{$stopped}
    Assert-AreEqual "Stopped" $stoppedEndpoint.ResourceState

    $started = Start-AzCdnEndpoint -EndpointName $endpointName -ProfileName $profileName -ResourceGroupName $resourceGroup.ResourceGroupName -PassThru
    $startedEndpoint = Get-AzCdnEndpoint -EndpointName $endpointName -ProfileName $profileName -ResourceGroupName $resourceGroup.ResourceGroupName
    Assert-True{$started}
    Assert-AreEqual "Running" $startedEndpoint.ResourceState

    $purged = Unpublish-AzCdnEndpointContent -EndpointName $endpointName -ProfileName $profileName -ResourceGroupName $resourceGroup.ResourceGroupName -PurgeContent @("/pic1.jpg", "/pic2.jpg") -PassThru
    Assert-True{$purged}

    $loaded = Publish-AzCdnEndpointContent -EndpointName $endpointName -ProfileName $profileName -ResourceGroupName $resourceGroup.ResourceGroupName -LoadContent @("/pic1.jpg", "/pic2.jpg") -PassThru
    Assert-True{$loaded}

    $validateResult = Test-AzCdnCustomDomain -EndpointName $endpointName -ProfileName $profileName -ResourceGroupName $resourceGroup.ResourceGroupName -CustomDomainHostName "unverifiedcustomdomain.com"
    Assert-False{$validateResult.CustomDomainValidated}

    $endpointRemoved = Remove-AzCdnEndpoint -EndpointName $endpointName -ProfileName $profileName -ResourceGroupName $resourceGroup.ResourceGroupName -Force -PassThru
    Assert-True{$endpointRemoved}

    Assert-ThrowsContains { Get-AzCdnEndpoint -EndpointName $endpointName -ProfileName $profileName -ResourceGroupName $resourceGroup.ResourceGroupName } "NotFound"

    Remove-AzResourceGroup -Name $resourceGroup.ResourceGroupName -Force
}

<#
.SYNOPSIS
Endpoint cycle with all of the properties and piping
#>
function Test-EndpointCrudAndActionWithAllPropertiesWithPiping
{
    $profileName = getAssetName
    $resourceGroup = TestSetup-CreateResourceGroup
    $resourceLocation = "EastUS"
    $profileSku = "Standard_Verizon"
    $createdProfile = New-AzCdnProfile -ProfileName $profileName -ResourceGroupName $resourceGroup.ResourceGroupName -Location $resourceLocation -Sku $profileSku

    $endpointName = getAssetName
    $originName = getAssetName
    $originHostHeader = "www.microsoft.com"
    $originPath = "/videos"
    $contentTypeToCompress = @("application/json", "text/html")
    $isCompressionEnabled = $true
    $isHttpAllowed = $true
    $isHttpsAllowed = $true
    $queryStringCachingBehavior = "BypassCaching"
    $httpPort = 123
    $httpsPort = 456
    $tags = @{"tag1" = "value1"; "tag2" = "value2"}

    $originHostName = "www.microsoft.com"

    $nameAvailability = Get-AzCdnEndpointNameAvailability -EndpointName $endpointName
    Assert-True{$nameAvailability.NameAvailable}

    $createdEndpoint = New-AzCdnEndpoint -EndpointName $endpointName -ProfileName $profileName -ResourceGroupName $resourceGroup.ResourceGroupName -Location $resourceLocation -OriginHostHeader $originHostHeader -OriginPath $originPath -ContentTypesToCompress $contentTypeToCompress -IsCompressionEnabled $isCompressionEnabled -IsHttpAllowed $isHttpAllowed -IsHttpsAllowed $isHttpsAllowed -QueryStringCachingBehavior $queryStringCachingBehavior -OriginName $originName -OriginHostName $originHostName -HttpPort $httpPort -HttpsPort $httpsPort -Tag $tags
    Assert-AreEqual $endpointName $createdEndpoint.Name
    Assert-AreEqual $profileName $createdEndpoint.ProfileName
    Assert-AreEqual $resourceGroup.ResourceGroupName $createdEndpoint.ResourceGroupName
    Assert-NotNull $createdEndpoint.HostName
    Assert-AreEqual $originHostHeader $createdEndpoint.OriginHostHeader
    Assert-AreEqual $originPath $createdEndpoint.OriginPath
    Assert-CompressionTypes $contentTypeToCompress $createdEndpoint.ContentTypesToCompress
    Assert-AreEqual $isCompressionEnabled $createdEndpoint.IsCompressionEnabled
    Assert-AreEqual $isHttpAllowed $createdEndpoint.IsHttpAllowed
    Assert-AreEqual $isHttpsAllowed $createdEndpoint.IsHttpsAllowed
    Assert-AreEqual $queryStringCachingBehavior $createdEndpoint.QueryStringCachingBehavior
    Assert-Tags $tags $createdEndpoint.Tags

    Assert-AreEqual $httpPort $createdEndpoint.Origins[0].HttpPort
    Assert-AreEqual $httpsPort $createdEndpoint.Origins[0].HttpsPort
    Assert-AreEqual $originName $createdEndpoint.Origins[0].Name
    Assert-AreEqual $originHostName $createdEndpoint.Origins[0].HostName

    $nameAvailability = Get-AzCdnEndpointNameAvailability -EndpointName $endpointName
    Assert-False{$nameAvailability.NameAvailable}

    $stopped = Stop-AzCdnEndpoint -CdnEndpoint $createdEndpoint -Confirm:$false -PassThru
    $stoppedEndpoint = Get-AzCdnEndpoint -EndpointName $endpointName -ProfileName $profileName -ResourceGroupName $resourceGroup.ResourceGroupName
    Assert-True{$stopped}
    Assert-AreEqual "Stopped" $stoppedEndpoint.ResourceState

    $started = Start-AzCdnEndpoint -CdnEndpoint $createdEndpoint -PassThru
    $startedEndpoint = Get-AzCdnEndpoint -EndpointName $endpointName -ProfileName $profileName -ResourceGroupName $resourceGroup.ResourceGroupName
    Assert-True{$started}
    Assert-AreEqual "Running" $startedEndpoint.ResourceState

    $purged = Unpublish-AzCdnEndpointContent -CdnEndpoint $createdEndpoint -PurgeContent @("/pic1.jpg", "/pic2.jpg") -PassThru
    Assert-True{$purged}

    $loaded = Publish-AzCdnEndpointContent -CdnEndpoint $createdEndpoint -LoadContent @("/pic1.jpg", "/pic2.jpg") -PassThru
    Assert-True{$loaded}

    $startedEndpoint.OriginHostHeader = "www.microsoft.com"
    $startedEndpoint.OriginPath = "/pictures"
    $startedEndpoint.QueryStringCachingBehavior = "UseQueryString"

    $updatedEndpoint = Set-AzCdnEndpoint -CdnEndpoint $startedEndpoint
    Assert-AreEqual $startedEndpoint.OriginHostHeader $updatedEndpoint.OriginHostHeader
    Assert-AreEqual $startedEndpoint.OriginPath $updatedEndpoint.OriginPath
    Assert-AreEqual $startedEndpoint.QueryStringCachingBehavior $updatedEndpoint.QueryStringCachingBehavior

    $endpointRemoved = Remove-AzCdnEndpoint -CdnEndpoint $createdEndpoint -Force -PassThru
    Assert-True{$endpointRemoved}

    Assert-ThrowsContains { Get-AzCdnEndpoint -EndpointName $endpointName -ProfileName $profileName -ResourceGroupName $resourceGroup.ResourceGroupName } "NotFound"

    Remove-AzResourceGroup -Name $resourceGroup.ResourceGroupName -Force
}

<#
.SYNOPSIS
Endpoint cycle with stopped endpoint
#>
function Test-EndpointCrudAndActionWithStoppedEndpoint
{
    $profileName = getAssetName
    $resourceGroup = TestSetup-CreateResourceGroup
    $resourceLocation = "EastUS"
    $profileSku = "Standard_Verizon"
    $createdProfile = New-AzCdnProfile -ProfileName $profileName -ResourceGroupName $resourceGroup.ResourceGroupName -Location $resourceLocation -Sku $profileSku

    $endpointName = getAssetName
    $originName = getAssetName
    $originHostName = "www.microsoft.com"

    $nameAvailability = Get-AzCdnEndpointNameAvailability -EndpointName $endpointName
    Assert-True{$nameAvailability.NameAvailable}

    $createdEndpoint = New-AzCdnEndpoint -EndpointName $endpointName -ProfileName $profileName -ResourceGroupName $resourceGroup.ResourceGroupName -Location $resourceLocation -OriginName $originName -OriginHostName $originHostName
    Assert-AreEqual $endpointName $createdEndpoint.Name
    Assert-AreEqual $profileName $createdEndpoint.ProfileName
    Assert-AreEqual $resourceGroup.ResourceGroupName $createdEndpoint.ResourceGroupName
    Assert-AreEqual $originName $createdEndpoint.Origins[0].Name
    Assert-AreEqual $originHostName $createdEndpoint.Origins[0].HostName

    $nameAvailability = Get-AzCdnEndpointNameAvailability -EndpointName $endpointName
    Assert-False{$nameAvailability.NameAvailable}

    $stopped = Stop-AzCdnEndpoint -CdnEndpoint $createdEndpoint -Confirm:$false -PassThru
    $stoppedEndpoint = Get-AzCdnEndpoint -EndpointName $endpointName -ProfileName $profileName -ResourceGroupName $resourceGroup.ResourceGroupName
    Assert-True{$stopped}
    Assert-AreEqual "Stopped" $stoppedEndpoint.ResourceState

    $purged = Unpublish-AzCdnEndpointContent -CdnEndpoint $createdEndpoint -PurgeContent @("/pic1.jpg", "/pic2.jpg") -PassThru
    Assert-True{$purged}

    $loaded = Publish-AzCdnEndpointContent -CdnEndpoint $createdEndpoint -LoadContent @("/pic1.jpg", "/pic2.jpg") -PassThru
    Assert-True{$loaded}

    $validateResultbyPiping = Test-AzCdnCustomDomain -CdnEndpoint $endpoint -CustomDomainHostName "unverifiedcustomdomain.com"
    Assert-False{$validateResultbyPiping.CustomDomainValidated}

    $startedEndpoint.OriginHostHeader = "www.microsoft.com"
    $startedEndpoint.OriginPath = "/pictures"
    $startedEndpoint.QueryStringCachingBehavior = "UseQueryString"

    $updatedEndpoint = Set-AzCdnEndpoint -CdnEndpoint $startedEndpoint
    Assert-AreEqual $startedEndpoint.OriginHostHeader $updatedEndpoint.OriginHostHeader
    Assert-AreEqual $startedEndpoint.OriginPath $updatedEndpoint.OriginPath
    Assert-AreEqual $startedEndpoint.QueryStringCachingBehavior $updatedEndpoint.QueryStringCachingBehavior

    $endpointRemoved = Remove-AzCdnEndpoint -CdnEndpoint $createdEndpoint -Force -PassThru
    Assert-True{$endpointRemoved}

    Assert-ThrowsContains { Get-AzCdnEndpoint -EndpointName $endpointName -ProfileName $profileName -ResourceGroupName $resourceGroup.ResourceGroupName } "NotFound"

    Remove-AzResourceGroup -Name $resourceGroup.ResourceGroupName -Force
}

<#
.SYNOPSIS
Endpoint pipeline exercise
#>
function Test-EndpointPipeline
{
    $profileName = getAssetName
    $resourceGroup = TestSetup-CreateResourceGroup
    $resourceLocation = "EastUS"
    $profileSku = "Standard_Verizon"
    $createdProfile = New-AzCdnProfile -ProfileName $profileName -ResourceGroupName $resourceGroup.ResourceGroupName -Location $resourceLocation -Sku $profileSku

    $endpointName1 = getAssetName
    $endpointName2 = getAssetName
    $originName = getAssetName
    $originHostName = "www.microsoft.com"


    $createdProfile | New-AzCdnEndpoint -EndpointName $endpointName1 -OriginName $originName -OriginHostName $originHostName
    $createdProfile | New-AzCdnEndpoint -EndpointName $endpointName2 -OriginName $originName -OriginHostName $originHostName

    $endpoints = Get-AzCdnProfile -ProfileName $profileName -ResourceGroupName $resourceGroup.ResourceGroupName | Get-AzCdnEndpoint

    Assert-True {$endpoints.Count -eq 2}

    Get-AzCdnProfile -ProfileName $profileName -ResourceGroupName $resourceGroup.ResourceGroupName | Get-AzCdnEndpoint | Remove-AzCdnEndpoint -Force

    $deletedEndpoints = Get-AzCdnProfile -ProfileName $profileName -ResourceGroupName $resourceGroup.ResourceGroupName | Get-AzCdnEndpoint

    Assert-True {$deletedEndpoints.Count -eq 0}

    Remove-AzResourceGroup -Name $resourceGroup.ResourceGroupName -Force
}

<#
.SYNOPSIS
Endpoint geo filters exercise
#>
function Test-EndpointGeoFilters
{
    $profileName = getAssetName
    $resourceGroup = TestSetup-CreateResourceGroup
    $resourceLocation = "EastUS"
    $profileSku = "Standard_Akamai"
	$GeoFilter_1 = New-Object -TypeName Microsoft.Azure.Commands.Cdn.Models.Endpoint.PsGeoFilter -Prop(@{'RelativePath'="/mycar";'Action'="Block"})
	$GeoFilter_1.CountryCodes = @("GA", "AT")

    $createdProfile = New-AzCdnProfile -ProfileName $profileName -ResourceGroupName $resourceGroup.ResourceGroupName -Location $resourceLocation -Sku $profileSku

    $endpointName1 = getAssetName
    $originName = getAssetName
    $originHostName = "www.microsoft.com"

    $createdProfile | New-AzCdnEndpoint -EndpointName $endpointName1 -OriginName $originName -OriginHostName $originHostName -GeoFilters @($GeoFilter_1)

    $endpoint = Get-AzCdnEndpoint -EndpointName $endpointName1 -ProfileName $profileName -ResourceGroupName $resourceGroup.ResourceGroupName

    Assert-True {$endpoint.GeoFilters.Count -eq 1}
	Assert-True {$endpoint.GeoFilters[0].Action -eq "Block"}
	Assert-True {$endpoint.GeoFilters[0].CountryCodes.Count -eq 2}

	$GeoFilter_2 = New-Object -TypeName Microsoft.Azure.Commands.Cdn.Models.Endpoint.PsGeoFilter -Prop(@{'RelativePath'="/mypicture";'Action'="Block"})
	$GeoFilter_2.CountryCodes = @("GA", "AT")

	$endpoint.GeoFilters.Add($GeoFilter_2)

	$updatedEndpoint = Set-AzCdnEndpoint -CdnEndpoint $endpoint

	Assert-True {$updatedEndpoint.GeoFilters.Count -eq 2}

    Remove-AzResourceGroup -Name $resourceGroup.ResourceGroupName -Force
}

<#
.SYNOPSIS
Endpoint create with Dsa
#>
function Test-EndpointCreateWithDsa
{
    $profileName = getAssetName
    $resourceGroup = TestSetup-CreateResourceGroup
    $resourceLocation = "EastUS"
    $profileSku = "Standard_Verizon"
    $createdProfile = New-AzCdnProfile -ProfileName $profileName -ResourceGroupName $resourceGroup.ResourceGroupName -Location $resourceLocation -Sku $profileSku

    $endpointName = getAssetName
    $originName = getAssetName
    $originHostHeader = "azurecdn-files.azureedge.net"
    $originPath = "/dsa-test"
    $contentTypeToCompress = @()
    $isCompressionEnabled = $false
    $isHttpAllowed = $true
    $isHttpsAllowed = $true
    $queryStringCachingBehavior = "NotSet"
	$optimizationType = "DynamicSiteAcceleration"
	$probePath = "/probe-v.txt"
    
    $originHostName = "www.microsoft.com"

    $nameAvailability = Get-AzCdnEndpointNameAvailability -EndpointName $endpointName
    Assert-True{$nameAvailability.NameAvailable}

    $createdEndpoint = New-AzCdnEndpoint -EndpointName $endpointName -ProfileName $profileName -ResourceGroupName $resourceGroup.ResourceGroupName -Location $resourceLocation -OriginHostHeader $originHostHeader -OriginPath $originPath -ContentTypesToCompress $contentTypeToCompress -IsCompressionEnabled $isCompressionEnabled -IsHttpAllowed $isHttpAllowed -IsHttpsAllowed $isHttpsAllowed -OptimizationType $optimizationType -ProbePath $probePath -QueryStringCachingBehavior $queryStringCachingBehavior -OriginName $originName -OriginHostName $originHostName 
    Assert-AreEqual $endpointName $createdEndpoint.Name
    Assert-AreEqual $profileName $createdEndpoint.ProfileName
    Assert-AreEqual $resourceGroup.ResourceGroupName $createdEndpoint.ResourceGroupName
    Assert-NotNull $createdEndpoint.HostName
    Assert-AreEqual $originHostHeader $createdEndpoint.OriginHostHeader
    Assert-AreEqual $originPath $createdEndpoint.OriginPath
    Assert-CompressionTypes $contentTypeToCompress $createdEndpoint.ContentTypesToCompress
    Assert-AreEqual $isCompressionEnabled $createdEndpoint.IsCompressionEnabled
    Assert-AreEqual $isHttpAllowed $createdEndpoint.IsHttpAllowed
    Assert-AreEqual $isHttpsAllowed $createdEndpoint.IsHttpsAllowed
	Assert-AreEqual $optimizationType $createdEndpoint.OptimizationType
    Assert-AreEqual "IgnoreQueryString" $createdEndpoint.QueryStringCachingBehavior

    Remove-AzResourceGroup -Name $resourceGroup.ResourceGroupName -Force
}

<#
.SYNOPSIS
Endpoint resource usage exercise
#>
function Test-EndpointResourceUsage
{
    $profileName = getAssetName
    $resourceGroup = TestSetup-CreateResourceGroup
    $resourceLocation = "EastUS"
    $profileSku = "Standard_Akamai"

    $createdProfile = New-AzCdnProfile -ProfileName $profileName -ResourceGroupName $resourceGroup.ResourceGroupName -Location $resourceLocation -Sku $profileSku

    $endpointName1 = getAssetName
    $originName = getAssetName
    $originHostName = "www.microsoft.com"

    $createdProfile | New-AzCdnEndpoint -EndpointName $endpointName1 -OriginName $originName -OriginHostName $originHostName

    $endpointResourceUsage = Get-AzCdnEndpointResourceUsage -EndpointName $endpointName1 -ProfileName $profileName -ResourceGroupName $resourceGroup.ResourceGroupName

    Assert-True {$endpointResourceUsage.Count -eq 2}
    Assert-True {$endpointResourceUsage[0].CurrentValue -eq 0}
    Assert-True {$endpointResourceUsage[1].CurrentValue -eq 0}

    Remove-AzResourceGroup -Name $resourceGroup.ResourceGroupName -Force
}

<#
.SYNOPSIS
Endpoint validate probe url exercise
#>
function Test-EndpointValidateProbeUrl
{
	$probeUrl = "https://azurecdn-files.azureedge.net/dsa-test/probe-v.txt"	
	$validateProbeUrlResult = Confirm-AzCdnEndpointProbeURL -ProbeUrl $probeUrl

	Assert-True {$validateProbeUrlResult.IsValid}

	$probeUrl = "https://www.notexist.com/notexist/notexist.txt"
	$validateProbeUrlResult = Confirm-AzCdnEndpointProbeURL -ProbeUrl $probeUrl

	Assert-False {$validateProbeUrlResult.IsValid}
}