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
    $profileSku = "StandardVerizon"
    $createdProfile = New-AzureRmCdnProfile -ProfileName $profileName -ResourceGroupName $resourceGroup.ResourceGroupName -Location $resourceLocation -Sku $profileSku

    $endpointName = getAssetName
    $originName = getAssetName
    $originHostName = "www.microsoft.com"

    $nameAvailability = Get-AzureRmCdnEndpointNameAvailability -EndpointName $endpointName
    Assert-True{$nameAvailability.NameAvailable}

    $createdEndpoint = New-AzureRmCdnEndpoint -EndpointName $endpointName -ProfileName $profileName -ResourceGroupName $resourceGroup.ResourceGroupName -Location $resourceLocation -OriginName $originName -OriginHostName $originHostName
    Assert-AreEqual $endpointName $createdEndpoint.Name
    Assert-AreEqual $profileName $createdEndpoint.ProfileName
    Assert-AreEqual $resourceGroup.ResourceGroupName $createdEndpoint.ResourceGroupName
    Assert-AreEqual $originName $createdEndpoint.Origins[0].Name
    Assert-AreEqual $originHostName $createdEndpoint.Origins[0].HostName

    $nameAvailability = Get-AzureRmCdnEndpointNameAvailability -EndpointName $endpointName
    Assert-False{$nameAvailability.NameAvailable}

    $stopped = Stop-AzureRmCdnEndpoint -EndpointName $endpointName -ProfileName $profileName -ResourceGroupName $resourceGroup.ResourceGroupName -Confirm:$false -PassThru
    $stoppedEndpoint = Get-AzureRmCdnEndpoint -EndpointName $endpointName -ProfileName $profileName -ResourceGroupName $resourceGroup.ResourceGroupName
    Assert-True{$stopped}
    Assert-AreEqual "Stopped" $stoppedEndpoint.ResourceState

    $started = Start-AzureRmCdnEndpoint -EndpointName $endpointName -ProfileName $profileName -ResourceGroupName $resourceGroup.ResourceGroupName -PassThru
    $startedEndpoint = Get-AzureRmCdnEndpoint -EndpointName $endpointName -ProfileName $profileName -ResourceGroupName $resourceGroup.ResourceGroupName
    Assert-True{$started}
    Assert-AreEqual "Running" $startedEndpoint.ResourceState

    $purged = Unpublish-AzureRmCdnEndpointContent -EndpointName $endpointName -ProfileName $profileName -ResourceGroupName $resourceGroup.ResourceGroupName -PurgeContent @("/pic1.jpg", "/pic2.jpg") -PassThru
    Assert-True{$purged}

    $loaded = Publish-AzureRmCdnEndpointContent -EndpointName $endpointName -ProfileName $profileName -ResourceGroupName $resourceGroup.ResourceGroupName -LoadContent @("/pic1.jpg", "/pic2.jpg") -PassThru
    Assert-True{$loaded}

    $validateResult = Test-AzureRmCdnCustomDomain -EndpointName $endpointName -ProfileName $profileName -ResourceGroupName $resourceGroup.ResourceGroupName -CustomDomainHostName "unverifiedcustomdomain.com"
    Assert-False{$validateResult.CustomDomainValidated}

    $endpointRemoved = Remove-AzureRmCdnEndpoint -EndpointName $endpointName -ProfileName $profileName -ResourceGroupName $resourceGroup.ResourceGroupName -PassThru -Force
    Assert-True{$endpointRemoved}

    Assert-ThrowsContains { Get-AzureRmCdnEndpoint -EndpointName $endpointName -ProfileName $profileName -ResourceGroupName $resourceGroup.ResourceGroupName } "NotFound"

    Remove-AzureRmResourceGroup -Name $resourceGroup.ResourceGroupName -Force
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
    $profileSku = "StandardVerizon"
    $createdProfile = New-AzureRmCdnProfile -ProfileName $profileName -ResourceGroupName $resourceGroup.ResourceGroupName -Location $resourceLocation -Sku $profileSku

    $endpointName = getAssetName
    $originName = getAssetName
    $originHostName = "www.microsoft.com"

    $nameAvailability = Get-AzureRmCdnEndpointNameAvailability -EndpointName $endpointName
    Assert-True{$nameAvailability.NameAvailable}

    $createdEndpoint = New-AzureRmCdnEndpoint -EndpointName $endpointName -ProfileName $profileName -ResourceGroupName $resourceGroup.ResourceGroupName -Location $resourceLocation -OriginName $originName -OriginHostName $originHostName
    Assert-AreEqual $endpointName $createdEndpoint.Name
    Assert-AreEqual $profileName $createdEndpoint.ProfileName
    Assert-AreEqual $resourceGroup.ResourceGroupName $createdEndpoint.ResourceGroupName
    Assert-AreEqual $originName $createdEndpoint.Origins[0].Name
    Assert-AreEqual $originHostName $createdEndpoint.Origins[0].HostName

    $nameAvailability = Get-AzureRmCdnEndpointNameAvailability -EndpointName $endpointName
    Assert-False{$nameAvailability.NameAvailable}

    $stopped = Stop-AzureRmCdnEndpoint -CdnEndpoint $createdEndpoint -Confirm:$false -PassThru
    $stoppedEndpoint = Get-AzureRmCdnEndpoint -EndpointName $endpointName -ProfileName $profileName -ResourceGroupName $resourceGroup.ResourceGroupName
    Assert-True{$stopped}
    Assert-AreEqual "Stopped" $stoppedEndpoint.ResourceState

    $started = Start-AzureRmCdnEndpoint -CdnEndpoint $createdEndpoint -PassThru
    $startedEndpoint = Get-AzureRmCdnEndpoint -EndpointName $endpointName -ProfileName $profileName -ResourceGroupName $resourceGroup.ResourceGroupName
    Assert-True{$started}
    Assert-AreEqual "Running" $startedEndpoint.ResourceState

    $purged = Unpublish-AzureRmCdnEndpointContent -CdnEndpoint $createdEndpoint -PurgeContent @("/pic1.jpg", "/pic2.jpg") -PassThru
    Assert-True{$purged}

    $loaded = Publish-AzureRmCdnEndpointContent -CdnEndpoint $createdEndpoint -LoadContent @("/pic1.jpg", "/pic2.jpg") -PassThru
    Assert-True{$loaded}

    $validateResultbyPiping = Test-AzureRmCdnCustomDomain -CdnEndpoint $createdEndpoint -CustomDomainHostName "unverifiedcustomdomain.com"
    Assert-False{$validateResultbyPiping.CustomDomainValidated}

    $startedEndpoint.OriginHostHeader = "www.microsoft.com"
    $startedEndpoint.OriginPath = "/pictures"
    $startedEndpoint.QueryStringCachingBehavior = "UseQueryString"

    $updatedEndpoint = Set-AzureRmCdnEndpoint -CdnEndpoint $startedEndpoint
    Assert-AreEqual $startedEndpoint.OriginHostHeader $updatedEndpoint.OriginHostHeader
    Assert-AreEqual $startedEndpoint.OriginPath $updatedEndpoint.OriginPath
    Assert-AreEqual $startedEndpoint.QueryStringCachingBehavior $updatedEndpoint.QueryStringCachingBehavior

    $endpointRemoved = Remove-AzureRmCdnEndpoint -CdnEndpoint $createdEndpoint -Force -PassThru
    Assert-True{$endpointRemoved}

    Assert-ThrowsContains { Get-AzureRmCdnEndpoint -EndpointName $endpointName -ProfileName $profileName -ResourceGroupName $resourceGroup.ResourceGroupName } "NotFound"

    Remove-AzureRmResourceGroup -Name $resourceGroup.ResourceGroupName -Force
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
    $profileSku = "StandardVerizon"
    $createdProfile = New-AzureRmCdnProfile -ProfileName $profileName -ResourceGroupName $resourceGroup.ResourceGroupName -Location $resourceLocation -Sku $profileSku

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

    $nameAvailability = Get-AzureRmCdnEndpointNameAvailability -EndpointName $endpointName
    Assert-True{$nameAvailability.NameAvailable}

    $createdEndpoint = New-AzureRmCdnEndpoint -EndpointName $endpointName -ProfileName $profileName -ResourceGroupName $resourceGroup.ResourceGroupName -Location $resourceLocation -OriginHostHeader $originHostHeader -OriginPath $originPath -ContentTypesToCompress $contentTypeToCompress -IsCompressionEnabled $isCompressionEnabled -IsHttpAllowed $isHttpAllowed -IsHttpsAllowed $isHttpsAllowed -QueryStringCachingBehavior $queryStringCachingBehavior -OriginName $originName -OriginHostName $originHostName -HttpPort $httpPort -HttpsPort $httpsPort -Tags $tags
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

    $nameAvailability = Get-AzureRmCdnEndpointNameAvailability -EndpointName $endpointName
    Assert-False{$nameAvailability.NameAvailable}

    $stopped = Stop-AzureRmCdnEndpoint -EndpointName $endpointName -ProfileName $profileName -ResourceGroupName $resourceGroup.ResourceGroupName -Confirm:$false -PassThru
    $stoppedEndpoint = Get-AzureRmCdnEndpoint -EndpointName $endpointName -ProfileName $profileName -ResourceGroupName $resourceGroup.ResourceGroupName
    Assert-True{$stopped}
    Assert-AreEqual "Stopped" $stoppedEndpoint.ResourceState

    $started = Start-AzureRmCdnEndpoint -EndpointName $endpointName -ProfileName $profileName -ResourceGroupName $resourceGroup.ResourceGroupName -PassThru
    $startedEndpoint = Get-AzureRmCdnEndpoint -EndpointName $endpointName -ProfileName $profileName -ResourceGroupName $resourceGroup.ResourceGroupName
    Assert-True{$started}
    Assert-AreEqual "Running" $startedEndpoint.ResourceState

    $purged = Unpublish-AzureRmCdnEndpointContent -EndpointName $endpointName -ProfileName $profileName -ResourceGroupName $resourceGroup.ResourceGroupName -PurgeContent @("/pic1.jpg", "/pic2.jpg") -PassThru
    Assert-True{$purged}

    $loaded = Publish-AzureRmCdnEndpointContent -EndpointName $endpointName -ProfileName $profileName -ResourceGroupName $resourceGroup.ResourceGroupName -LoadContent @("/pic1.jpg", "/pic2.jpg") -PassThru
    Assert-True{$loaded}

    $validateResult = Test-AzureRmCdnCustomDomain -EndpointName $endpointName -ProfileName $profileName -ResourceGroupName $resourceGroup.ResourceGroupName -CustomDomainHostName "unverifiedcustomdomain.com"
    Assert-False{$validateResult.CustomDomainValidated}

    $endpointRemoved = Remove-AzureRmCdnEndpoint -EndpointName $endpointName -ProfileName $profileName -ResourceGroupName $resourceGroup.ResourceGroupName -Force -PassThru
    Assert-True{$endpointRemoved}

    Assert-ThrowsContains { Get-AzureRmCdnEndpoint -EndpointName $endpointName -ProfileName $profileName -ResourceGroupName $resourceGroup.ResourceGroupName } "NotFound"

    Remove-AzureRmResourceGroup -Name $resourceGroup.ResourceGroupName -Force
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
    $profileSku = "StandardVerizon"
    $createdProfile = New-AzureRmCdnProfile -ProfileName $profileName -ResourceGroupName $resourceGroup.ResourceGroupName -Location $resourceLocation -Sku $profileSku

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

    $nameAvailability = Get-AzureRmCdnEndpointNameAvailability -EndpointName $endpointName
    Assert-True{$nameAvailability.NameAvailable}

    $createdEndpoint = New-AzureRmCdnEndpoint -EndpointName $endpointName -ProfileName $profileName -ResourceGroupName $resourceGroup.ResourceGroupName -Location $resourceLocation -OriginHostHeader $originHostHeader -OriginPath $originPath -ContentTypesToCompress $contentTypeToCompress -IsCompressionEnabled $isCompressionEnabled -IsHttpAllowed $isHttpAllowed -IsHttpsAllowed $isHttpsAllowed -QueryStringCachingBehavior $queryStringCachingBehavior -OriginName $originName -OriginHostName $originHostName -HttpPort $httpPort -HttpsPort $httpsPort -Tags $tags
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

    $nameAvailability = Get-AzureRmCdnEndpointNameAvailability -EndpointName $endpointName
    Assert-False{$nameAvailability.NameAvailable}

    $stopped = Stop-AzureRmCdnEndpoint -CdnEndpoint $createdEndpoint -Confirm:$false -PassThru
    $stoppedEndpoint = Get-AzureRmCdnEndpoint -EndpointName $endpointName -ProfileName $profileName -ResourceGroupName $resourceGroup.ResourceGroupName
    Assert-True{$stopped}
    Assert-AreEqual "Stopped" $stoppedEndpoint.ResourceState

    $started = Start-AzureRmCdnEndpoint -CdnEndpoint $createdEndpoint -PassThru
    $startedEndpoint = Get-AzureRmCdnEndpoint -EndpointName $endpointName -ProfileName $profileName -ResourceGroupName $resourceGroup.ResourceGroupName
    Assert-True{$started}
    Assert-AreEqual "Running" $startedEndpoint.ResourceState

    $purged = Unpublish-AzureRmCdnEndpointContent -CdnEndpoint $createdEndpoint -PurgeContent @("/pic1.jpg", "/pic2.jpg") -PassThru
    Assert-True{$purged}

    $loaded = Publish-AzureRmCdnEndpointContent -CdnEndpoint $createdEndpoint -LoadContent @("/pic1.jpg", "/pic2.jpg") -PassThru
    Assert-True{$loaded}

    $startedEndpoint.OriginHostHeader = "www.microsoft.com"
    $startedEndpoint.OriginPath = "/pictures"
    $startedEndpoint.QueryStringCachingBehavior = "UseQueryString"

    $updatedEndpoint = Set-AzureRmCdnEndpoint -CdnEndpoint $startedEndpoint
    Assert-AreEqual $startedEndpoint.OriginHostHeader $updatedEndpoint.OriginHostHeader
    Assert-AreEqual $startedEndpoint.OriginPath $updatedEndpoint.OriginPath
    Assert-AreEqual $startedEndpoint.QueryStringCachingBehavior $updatedEndpoint.QueryStringCachingBehavior

    $endpointRemoved = Remove-AzureRmCdnEndpoint -CdnEndpoint $createdEndpoint -Force -PassThru
    Assert-True{$endpointRemoved}

    Assert-ThrowsContains { Get-AzureRmCdnEndpoint -EndpointName $endpointName -ProfileName $profileName -ResourceGroupName $resourceGroup.ResourceGroupName } "NotFound"

    Remove-AzureRmResourceGroup -Name $resourceGroup.ResourceGroupName -Force
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
    $profileSku = "StandardVerizon"
    $createdProfile = New-AzureRmCdnProfile -ProfileName $profileName -ResourceGroupName $resourceGroup.ResourceGroupName -Location $resourceLocation -Sku $profileSku

    $endpointName = getAssetName
    $originName = getAssetName
    $originHostName = "www.microsoft.com"

    $nameAvailability = Get-AzureRmCdnEndpointNameAvailability -EndpointName $endpointName
    Assert-True{$nameAvailability.NameAvailable}

    $createdEndpoint = New-AzureRmCdnEndpoint -EndpointName $endpointName -ProfileName $profileName -ResourceGroupName $resourceGroup.ResourceGroupName -Location $resourceLocation -OriginName $originName -OriginHostName $originHostName
    Assert-AreEqual $endpointName $createdEndpoint.Name
    Assert-AreEqual $profileName $createdEndpoint.ProfileName
    Assert-AreEqual $resourceGroup.ResourceGroupName $createdEndpoint.ResourceGroupName
    Assert-AreEqual $originName $createdEndpoint.Origins[0].Name
    Assert-AreEqual $originHostName $createdEndpoint.Origins[0].HostName

    $nameAvailability = Get-AzureRmCdnEndpointNameAvailability -EndpointName $endpointName
    Assert-False{$nameAvailability.NameAvailable}

    $stopped = Stop-AzureRmCdnEndpoint -CdnEndpoint $createdEndpoint -Confirm:$false -PassThru
    $stoppedEndpoint = Get-AzureRmCdnEndpoint -EndpointName $endpointName -ProfileName $profileName -ResourceGroupName $resourceGroup.ResourceGroupName
    Assert-True{$stopped}
    Assert-AreEqual "Stopped" $stoppedEndpoint.ResourceState

    $purged = Unpublish-AzureRmCdnEndpointContent -CdnEndpoint $createdEndpoint -PurgeContent @("/pic1.jpg", "/pic2.jpg") -PassThru
    Assert-True{$purged}

    $loaded = Publish-AzureRmCdnEndpointContent -CdnEndpoint $createdEndpoint -LoadContent @("/pic1.jpg", "/pic2.jpg") -PassThru
    Assert-True{$loaded}

    $validateResultbyPiping = Test-AzureRmCdnCustomDomain -CdnEndpoint $endpoint -CustomDomainHostName "unverifiedcustomdomain.com"
    Assert-False{$validateResultbyPiping.CustomDomainValidated}

    $startedEndpoint.OriginHostHeader = "www.microsoft.com"
    $startedEndpoint.OriginPath = "/pictures"
    $startedEndpoint.QueryStringCachingBehavior = "UseQueryString"

    $updatedEndpoint = Set-AzureRmCdnEndpoint -CdnEndpoint $startedEndpoint
    Assert-AreEqual $startedEndpoint.OriginHostHeader $updatedEndpoint.OriginHostHeader
    Assert-AreEqual $startedEndpoint.OriginPath $updatedEndpoint.OriginPath
    Assert-AreEqual $startedEndpoint.QueryStringCachingBehavior $updatedEndpoint.QueryStringCachingBehavior

    $endpointRemoved = Remove-AzureRmCdnEndpoint -CdnEndpoint $createdEndpoint -Force -PassThru
    Assert-True{$endpointRemoved}

    Assert-ThrowsContains { Get-AzureRmCdnEndpoint -EndpointName $endpointName -ProfileName $profileName -ResourceGroupName $resourceGroup.ResourceGroupName } "NotFound"

    Remove-AzureRmResourceGroup -Name $resourceGroup.ResourceGroupName -Force
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
    $profileSku = "StandardVerizon"
    $createdProfile = New-AzureRmCdnProfile -ProfileName $profileName -ResourceGroupName $resourceGroup.ResourceGroupName -Location $resourceLocation -Sku $profileSku

    $endpointName1 = getAssetName
    $endpointName2 = getAssetName
    $originName = getAssetName
    $originHostName = "www.microsoft.com"


    $createdProfile | New-AzureRmCdnEndpoint -EndpointName $endpointName1 -OriginName $originName -OriginHostName $originHostName
    $createdProfile | New-AzureRmCdnEndpoint -EndpointName $endpointName2 -OriginName $originName -OriginHostName $originHostName

    $endpoints = Get-AzureRmCdnProfile -ProfileName $profileName -ResourceGroupName $resourceGroup.ResourceGroupName | Get-AzureRmCdnEndpoint

    Assert-True {$endpoints.Count -eq 2}

    Get-AzureRmCdnProfile -ProfileName $profileName -ResourceGroupName $resourceGroup.ResourceGroupName | Get-AzureRmCdnEndpoint | Remove-AzureRmCdnEndpoint -Force

    $deletedEndpoints = Get-AzureRmCdnProfile -ProfileName $profileName -ResourceGroupName $resourceGroup.ResourceGroupName | Get-AzureRmCdnEndpoint

    Assert-True {$deletedEndpoints.Count -eq 0}

    Remove-AzureRmResourceGroup -Name $resourceGroup.ResourceGroupName -Force
}