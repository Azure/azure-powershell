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
    # Hard-coding host and endpoint names due to requirement for DNS CNAME
    $endpointName = "sdktest-c83c1e8f-343e-4ce8-873b-f6e5ddcdc53f"
    $hostName = "sdktest-716d4572-627f-4dfe-8128-1df163647ae2.azureedge-test.net"

    $customDomainName = getAssetName

    $profileName = getAssetName
    $resourceGroup = TestSetup-CreateResourceGroup
    $resourceLocation = "EastUS"
    $profileSku = "Standard_Verizon"
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

    $createdCustomDomain = $endpoint | New-AzureRmCdnCustomDomain -HostName $hostName -CustomDomainName $customDomainName 
    Assert-AreEqual $customDomainName $createdCustomDomain.Name
    Assert-AreEqual $hostName $createdCustomDomain.HostName
    Assert-ThrowsContains { New-AzureRmCdnCustomDomain -HostName $hostName -CustomDomainName $customDomainName -EndpointName $endpointName -ProfileName $profileName -ResourceGroupName $resourceGroup.ResourceGroupName } "existing"

    $customDomain = $endpoint | Get-AzureRmCdnCustomDomain -CustomDomainName $customDomainName 
    Assert-AreEqual $customDomainName $customDomain.Name
    Assert-AreEqual $hostName $customDomain.HostName

    $removed = $customDomain | Remove-AzureRmCdnCustomDomain -PassThru
    Assert-True{$removed}
    Assert-ThrowsContains { Remove-AzureRmCdnCustomDomain -CustomDomainName $customDomainName -EndpointName $endpointName -ProfileName $profileName -ResourceGroupName $resourceGroup.ResourceGroupName } "does not exist"

    Assert-ThrowsContains { Get-AzureRmCdnCustomDomain -CustomDomainName $customDomainName -EndpointName $endpointName -ProfileName $profileName -ResourceGroupName $resourceGroup.ResourceGroupName } "NotFound"

    Remove-AzureRmResourceGroup -Name $resourceGroup.ResourceGroupName -Force
}

<#
.SYNOPSIS
Gets and removes custom domain with stopped endpoint
#>
function Test-CustomDomainGetRemoveWithStoppedEndpoint
{
    # Hard-coding host and endpoint names due to requirement for DNS CNAME
    $endpointName = "sdktest-cbc4e6fa-da15-4f37-9511-6b7df122c1de" 
    $hostName = "sdktest-34a59412-9044-4166-b055-d777e111e810.azureedge-test.net"  

	$customDomainName = getAssetName

    $profileName = getAssetName
    $resourceGroup = TestSetup-CreateResourceGroup
    $resourceLocation = "EastUS"
    $profileSku = "Standard_Verizon"
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

    $stopped = Stop-AzureRmCdnEndpoint -EndpointName $endpointName -ProfileName $profileName -ResourceGroupName $resourceGroup.ResourceGroupName

    $createdCustomDomain = New-AzureRmCdnCustomDomain -HostName $hostName -CustomDomainName $customDomainName -EndpointName $endpointName -ProfileName $profileName -ResourceGroupName $resourceGroup.ResourceGroupName
    Assert-AreEqual $customDomainName $createdCustomDomain.Name
    Assert-AreEqual $hostName $createdCustomDomain.HostName
    Assert-ThrowsContains { New-AzureRmCdnCustomDomain -HostName $hostName -CustomDomainName $customDomainName -EndpointName $endpointName -ProfileName $profileName -ResourceGroupName $resourceGroup.ResourceGroupName } "existing"

    $customDomain = Get-AzureRmCdnCustomDomain -CustomDomainName $customDomainName -EndpointName $endpointName -ProfileName $profileName -ResourceGroupName $resourceGroup.ResourceGroupName
    Assert-AreEqual $customDomainName $customDomain.Name
    Assert-AreEqual $hostName $customDomain.HostName

    $removed = Remove-AzureRmCdnCustomDomain -CustomDomainName $customDomainName -EndpointName $endpointName -ProfileName $profileName -ResourceGroupName $resourceGroup.ResourceGroupName -PassThru
    Assert-True{$removed}
    Assert-ThrowsContains { Remove-AzureRmCdnCustomDomain -CustomDomainName $customDomainName -EndpointName $endpointName -ProfileName $profileName -ResourceGroupName $resourceGroup.ResourceGroupName } "does not exist"

    Assert-ThrowsContains { Get-AzureRmCdnCustomDomain -CustomDomainName $customDomainName -EndpointName $endpointName -ProfileName $profileName -ResourceGroupName $resourceGroup.ResourceGroupName } "NotFound"

	Remove-AzureRmResourceGroup -Name $resourceGroup.ResourceGroupName -Force
}

<#
.SYNOPSIS
Enables and disable custom domain https
#>
function Test-EnableDisableCustomDomainHttps
{
    # Hard-coding host and endpoint names due to requirement for DNS CNAME
    $endpointName = "sdktest-2c9561c1-4a2d-47f6-ba90-38ebe222b77c" 
    $hostName = "sdktest-42f77f65-5921-4f50-b7ba-7b35a0f9c632.azureedge-test.net"  

	$customDomainName = getAssetName

    $profileName = getAssetName
    $resourceGroup = TestSetup-CreateResourceGroup
    $resourceLocation = "EastUS"
    $profileSku = "Standard_Verizon"
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

	Assert-ThrowsContains { Disable-AzureRmCdnCustomDomainHttps -CustomDomainName $customDomainName -EndpointName $endpointName -ProfileName $profileName -ResourceGroupName $resourceGroup.ResourceGroupName } "BadRequest"

	$enabling = Enable-AzureRmCdnCustomDomainHttps -CdnCustomDomain $createdCustomDomain -PassThru
	Assert-True{$enabling}

    $customDomain = Get-AzureRmCdnCustomDomain -CustomDomainName $customDomainName -EndpointName $endpointName -ProfileName $profileName -ResourceGroupName $resourceGroup.ResourceGroupName
    Assert-AreEqual $customDomainName $customDomain.Name
    Assert-AreEqual $hostName $customDomain.HostName
	Assert-AreEqual "Enabling" $customDomain.CustomHttpsProvisioningState

    $removed = Remove-AzureRmCdnCustomDomain -CustomDomainName $customDomainName -EndpointName $endpointName -ProfileName $profileName -ResourceGroupName $resourceGroup.ResourceGroupName -PassThru
    Assert-True{$removed}

	Remove-AzureRmResourceGroup -Name $resourceGroup.ResourceGroupName -Force
}