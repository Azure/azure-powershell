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
Gets and removes custom domain with running endpoint.
#>
function Test-CustomDomainGetRemoveWithRunningEndpoint
{
    $endpointName = "sdktest-3d96e37e-79bd-440d-a84b-d71a8bb3bed6"
    $hostName = "sdktest-aef2f35e-01ca-4230-add5-5075b1506915.azureedge-test.net"
    $customDomainName = getAssetName

    $profileName = getAssetName
    $resourceGroup = TestSetup-CreateResourceGroup
    $resourceLocation = "EastUS"
    $profileSku = "Standard"
    $tags = @{"tag1" = "value1"; "tag2" = "value2"}
    $createdProfile = New-AzureRmCdnProfile -ProfileName $profileName -ResourceGroupName $resourceGroup.ResourceGroupName -Location $resourceLocation -Sku $profileSku -Tags $tags

    $originName = getAssetName
    $originHostName = "www.microsoft.com"
    $createdEndpoint = New-AzureRmCdnEndpoint -EndpointName $endpointName -ProfileName $profileName -ResourceGroupName $resourceGroup.ResourceGroupName -Location $resourceLocation -OriginName $originName -OriginHostName $originHostName

    $endpoint = Get-AzureRmCdnEndpoint -EndpointName $endpointName -ProfileName $profileName -ResourceGroupName $resourceGroup.ResourceGroupName
    $validateResult = Test-AzureRmCdnCustomDomain -EndpointName $endpointName -ProfileName $profileName -ResourceGroupName $resourceGroup.ResourceGroupName -CustomDomainHostName $hostName
    Assert-True{$validateResult.CustomDomainValidated}
    $validateResultbyPiping = Test-AzureRmCdnCustomDomain -CdnEndpoint $endpoint -CustomDomainHostName $hostName
    Assert-True{$validateResultbyPiping.CustomDomainValidated}

    $createdCustomDomain = New-AzureRmCdnCustomDomain -HostName $hostName -CustomDomainName $customDomainName -EndpointName $endpointName -ProfileName $profileName -ResourceGroupName $resourceGroup.ResourceGroupName
    Assert-AreEqual $customDomainName $createdCustomDomain.Name
    Assert-AreEqual $hostName $createdCustomDomain.HostName
    Assert-ThrowsContains { New-AzureRmCdnCustomDomain -HostName $hostName -CustomDomainName $customDomainName -EndpointName $endpointName -ProfileName $profileName -ResourceGroupName $resourceGroup.ResourceGroupName } "existing"

    $customDomain = Get-AzureRmCdnCustomDomain -CustomDomainName $customDomainName -EndpointName $endpointName -ProfileName $profileName -ResourceGroupName $resourceGroup.ResourceGroupName
    Assert-AreEqual $customDomainName $customDomain.Name
    Assert-AreEqual $hostName $customDomain.HostName

    $removed = Remove-AzureRmCdnCustomDomain -CustomDomainName $customDomainName -EndpointName $endpointName -ProfileName $profileName -ResourceGroupName $resourceGroup.ResourceGroupName -Confirm:$false -PassThru
    Assert-True{$removed}
    Assert-ThrowsContains { Remove-AzureRmCdnCustomDomain -CustomDomainName $customDomainName -EndpointName $endpointName -ProfileName $profileName -ResourceGroupName $resourceGroup.ResourceGroupName -Confirm:$false} "does not exist"

    Assert-ThrowsContains { Get-AzureRmCdnCustomDomain -CustomDomainName $customDomainName -EndpointName $endpointName -ProfileName $profileName -ResourceGroupName $resourceGroup.ResourceGroupName } "NotFound"
}

<#
.SYNOPSIS
Gets and removes custom domain with stopped endpoint
#>
function Test-CustomDomainGetRemoveWithStoppedEndpoint
{
    $endpointName = "sdktest-cee91bb1-996a-44f1-96e6-dceaa6707def"
    $hostName = "sdktest-3acbafc1-3f50-4fa4-9132-6d8c944d67e9.azureedge-test.net"    
    $customDomainName = getAssetName

    $profileName = getAssetName
    $resourceGroup = TestSetup-CreateResourceGroup
    $resourceLocation = "EastUS"
    $profileSku = "Standard"
    $tags = @{"tag1" = "value1"; "tag2" = "value2"}
    $createdProfile = New-AzureRmCdnProfile -ProfileName $profileName -ResourceGroupName $resourceGroup.ResourceGroupName -Location $resourceLocation -Sku $profileSku -Tags $tags

    $originName = getAssetName
    $originHostName = "www.microsoft.com"
    $createdEndpoint = New-AzureRmCdnEndpoint -EndpointName $endpointName -ProfileName $profileName -ResourceGroupName $resourceGroup.ResourceGroupName -Location $resourceLocation -OriginName $originName -OriginHostName $originHostName

    $endpoint = Get-AzureRmCdnEndpoint -EndpointName $endpointName -ProfileName $profileName -ResourceGroupName $resourceGroup.ResourceGroupName
    $validateResult = Test-AzureRmCdnCustomDomain -EndpointName $endpointName -ProfileName $profileName -ResourceGroupName $resourceGroup.ResourceGroupName -CustomDomainHostName $hostName
    Assert-True{$validateResult.CustomDomainValidated}
    $validateResultbyPiping = Test-AzureRmCdnCustomDomain -CdnEndpoint $endpoint -CustomDomainHostName $hostName
    Assert-True{$validateResultbyPiping.CustomDomainValidated}

    $stopped = Stop-AzureRmCdnEndpoint -EndpointName $endpointName -ProfileName $profileName -ResourceGroupName $resourceGroup.ResourceGroupName -Confirm:$false

    $createdCustomDomain = New-AzureRmCdnCustomDomain -HostName $hostName -CustomDomainName $customDomainName -EndpointName $endpointName -ProfileName $profileName -ResourceGroupName $resourceGroup.ResourceGroupName
    Assert-AreEqual $customDomainName $createdCustomDomain.Name
    Assert-AreEqual $hostName $createdCustomDomain.HostName
    Assert-ThrowsContains { New-AzureRmCdnCustomDomain -HostName $hostName -CustomDomainName $customDomainName -EndpointName $endpointName -ProfileName $profileName -ResourceGroupName $resourceGroup.ResourceGroupName } "existing"

    $customDomain = Get-AzureRmCdnCustomDomain -CustomDomainName $customDomainName -EndpointName $endpointName -ProfileName $profileName -ResourceGroupName $resourceGroup.ResourceGroupName
    Assert-AreEqual $customDomainName $customDomain.Name
    Assert-AreEqual $hostName $customDomain.HostName

    $removed = Remove-AzureRmCdnCustomDomain -CustomDomainName $customDomainName -EndpointName $endpointName -ProfileName $profileName -ResourceGroupName $resourceGroup.ResourceGroupName -Confirm:$false -PassThru
    Assert-True{$removed}
    Assert-ThrowsContains { Remove-AzureRmCdnCustomDomain -CustomDomainName $customDomainName -EndpointName $endpointName -ProfileName $profileName -ResourceGroupName $resourceGroup.ResourceGroupName -Confirm:$false} "does not exist"

    Assert-ThrowsContains { Get-AzureRmCdnCustomDomain -CustomDomainName $customDomainName -EndpointName $endpointName -ProfileName $profileName -ResourceGroupName $resourceGroup.ResourceGroupName } "NotFound"
}