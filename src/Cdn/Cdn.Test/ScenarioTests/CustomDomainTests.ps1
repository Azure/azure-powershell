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
    $endpointName = "testAkamaiEP"
    $hostName = "testAkamai.dustydog.us"

    $customDomainName = getAssetName

    $profileName = getAssetName
    $resourceGroup = TestSetup-CreateResourceGroup
    $resourceLocation = "EastUS"
    $profileSku = "Standard_Akamai"
    $tags = @{"tag1" = "value1"; "tag2" = "value2"}
    $createdProfile = New-AzCdnProfile -ProfileName $profileName -ResourceGroupName $resourceGroup.ResourceGroupName -Location $resourceLocation -Sku $profileSku -Tag $tags

    $originName = getAssetName
    $originHostName = "www.microsoft.com"
    $createdEndpoint = New-AzCdnEndpoint -EndpointName $endpointName -ProfileName $profileName -ResourceGroupName $resourceGroup.ResourceGroupName -Location $resourceLocation -OriginName $originName -OriginHostName $originHostName

    $endpoint = Get-AzCdnEndpoint -EndpointName $endpointName -ProfileName $profileName -ResourceGroupName $resourceGroup.ResourceGroupName
    $validateResult = Test-AzCdnCustomDomain -EndpointName $endpointName -ProfileName $profileName -ResourceGroupName $resourceGroup.ResourceGroupName -CustomDomainHostName $hostName
    Assert-True{$validateResult.CustomDomainValidated}
    $validateResultbyPiping = Test-AzCdnCustomDomain -CdnEndpoint $endpoint -CustomDomainHostName $hostName
    Assert-True{$validateResultbyPiping.CustomDomainValidated}

    $createdCustomDomain = $endpoint | New-AzCdnCustomDomain -HostName $hostName -CustomDomainName $customDomainName
    Assert-AreEqual $customDomainName $createdCustomDomain.Name
    Assert-AreEqual $hostName $createdCustomDomain.HostName
    Assert-ThrowsContains { New-AzCdnCustomDomain -HostName $hostName -CustomDomainName $customDomainName -EndpointName $endpointName -ProfileName $profileName -ResourceGroupName $resourceGroup.ResourceGroupName } "existing"

    $customDomain = $endpoint | Get-AzCdnCustomDomain -CustomDomainName $customDomainName
    Assert-AreEqual $customDomainName $customDomain.Name
    Assert-AreEqual $hostName $customDomain.HostName

    $removed = $customDomain | Remove-AzCdnCustomDomain -PassThru
    Assert-True{$removed}
    Assert-ThrowsContains { Remove-AzCdnCustomDomain -CustomDomainName $customDomainName -EndpointName $endpointName -ProfileName $profileName -ResourceGroupName $resourceGroup.ResourceGroupName } "does not exist"

    Assert-ThrowsContains { Get-AzCdnCustomDomain -CustomDomainName $customDomainName -EndpointName $endpointName -ProfileName $profileName -ResourceGroupName $resourceGroup.ResourceGroupName } "NotFound"

    Remove-AzResourceGroup -Name $resourceGroup.ResourceGroupName -Force
}

<#
.SYNOPSIS
Enables custom domain with running endpoint.
#>
function Test-CustomDomainEnableDisableWithRunningEndpoint
{
    # Hard-coding host and endpoint names due to requirement for DNS CNAME
    $endpointName = "testVerizonEP"
    $hostName = "testVerizon.dustydog.us"
    
    $customDomainName = getAssetName

    $profileName = getAssetName
    $resourceGroup = TestSetup-CreateResourceGroup
    $resourceLocation = "EastUS"
    $profileSku = "Standard_Verizon"
    $tags = @{"tag1" = "value1"; "tag2" = "value2"}
    $createdProfile = New-AzCdnProfile -ProfileName $profileName -ResourceGroupName $resourceGroup.ResourceGroupName -Location $resourceLocation -Sku $profileSku -Tag $tags

    $originName = getAssetName
    $originHostName = "www.microsoft.com"
    $createdEndpoint = New-AzCdnEndpoint -EndpointName $endpointName -ProfileName $profileName -ResourceGroupName $resourceGroup.ResourceGroupName -Location $resourceLocation -OriginName $originName -OriginHostName $originHostName

    $endpoint = Get-AzCdnEndpoint -EndpointName $endpointName -ProfileName $profileName -ResourceGroupName $resourceGroup.ResourceGroupName
    $validateResult = Test-AzCdnCustomDomain -EndpointName $endpointName -ProfileName $profileName -ResourceGroupName $resourceGroup.ResourceGroupName -CustomDomainHostName $hostName
    Assert-True{$validateResult.CustomDomainValidated}
    $validateResultbyPiping = Test-AzCdnCustomDomain -CdnEndpoint $endpoint -CustomDomainHostName $hostName
    Assert-True{$validateResultbyPiping.CustomDomainValidated}

    $createdCustomDomain = $endpoint | New-AzCdnCustomDomain -HostName $hostName -CustomDomainName $customDomainName 
    Assert-AreEqual $customDomainName $createdCustomDomain.Name
    Assert-AreEqual $hostName $createdCustomDomain.HostName
    
   	$customDomain = $endpoint | Get-AzCdnCustomDomain -CustomDomainName $customDomainName 
    Assert-AreEqual $customDomainName $customDomain.Name
    Assert-AreEqual $hostName $customDomain.HostName

    $enabled = $customDomain | Enable-AzCdnCustomDomain -PassThru
    Assert-True{$enabled}
    Assert-ThrowsContains { Enable-AzCdnCustomDomain -CustomDomainName $customDomainName -EndpointName $endpointName -ProfileName $profileName -ResourceGroupName $resourceGroup.ResourceGroupName } "BadRequest"

    Assert-ThrowsContains { Disable-AzCdnCustomDomain -CustomDomainName $customDomainName -EndpointName $endpointName -ProfileName $profileName -ResourceGroupName $resourceGroup.ResourceGroupName } "BadRequest"

    Remove-AzResourceGroup -Name $resourceGroup.ResourceGroupName -Force
}


<#
.SYNOPSIS
Gets and removes custom domain with stopped endpoint
#>
function Test-CustomDomainGetRemoveWithStoppedEndpoint
{
  # Hard-coding host and endpoint names due to requirement for DNS CNAME
    $endpointName = "testAkamaiEP"
    $hostName = "testAkamai.dustydog.us"

    $customDomainName = getAssetName

    $profileName = getAssetName
    $resourceGroup = TestSetup-CreateResourceGroup
    $resourceLocation = "EastUS"
    $profileSku = "Standard_Akamai"
    $tags = @{"tag1" = "value1"; "tag2" = "value2"}
    $createdProfile = New-AzCdnProfile -ProfileName $profileName -ResourceGroupName $resourceGroup.ResourceGroupName -Location $resourceLocation -Sku $profileSku -Tag $tags

    $originName = getAssetName
    $originHostName = "www.microsoft.com"
    $createdEndpoint = New-AzCdnEndpoint -EndpointName $endpointName -ProfileName $profileName -ResourceGroupName $resourceGroup.ResourceGroupName -Location $resourceLocation -OriginName $originName -OriginHostName $originHostName

    $endpoint = Get-AzCdnEndpoint -EndpointName $endpointName -ProfileName $profileName -ResourceGroupName $resourceGroup.ResourceGroupName
    $validateResult = Test-AzCdnCustomDomain -EndpointName $endpointName -ProfileName $profileName -ResourceGroupName $resourceGroup.ResourceGroupName -CustomDomainHostName $hostName
    Assert-True{$validateResult.CustomDomainValidated}
    $validateResultbyPiping = Test-AzCdnCustomDomain -CdnEndpoint $endpoint -CustomDomainHostName $hostName
    Assert-True{$validateResultbyPiping.CustomDomainValidated}

    $createdCustomDomain = New-AzCdnCustomDomain -HostName $hostName -CustomDomainName $customDomainName -EndpointName $endpointName -ProfileName $profileName -ResourceGroupName $resourceGroup.ResourceGroupName
    Assert-AreEqual $customDomainName $createdCustomDomain.Name
    Assert-AreEqual $hostName $createdCustomDomain.HostName
    Assert-ThrowsContains { New-AzCdnCustomDomain -HostName $hostName -CustomDomainName $customDomainName -EndpointName $endpointName -ProfileName $profileName -ResourceGroupName $resourceGroup.ResourceGroupName } "existing"

    $stopped = Stop-AzCdnEndpoint -EndpointName $endpointName -ProfileName $profileName -ResourceGroupName $resourceGroup.ResourceGroupName

    $customDomain = Get-AzCdnCustomDomain -CustomDomainName $customDomainName -EndpointName $endpointName -ProfileName $profileName -ResourceGroupName $resourceGroup.ResourceGroupName
    Assert-AreEqual $customDomainName $customDomain.Name
    Assert-AreEqual $hostName $customDomain.HostName

    $removed = Remove-AzCdnCustomDomain -CustomDomainName $customDomainName -EndpointName $endpointName -ProfileName $profileName -ResourceGroupName $resourceGroup.ResourceGroupName -PassThru
    Assert-True{$removed}
    Assert-ThrowsContains { Remove-AzCdnCustomDomain -CustomDomainName $customDomainName -EndpointName $endpointName -ProfileName $profileName -ResourceGroupName $resourceGroup.ResourceGroupName } "does not exist"

    Assert-ThrowsContains { Get-AzCdnCustomDomain -CustomDomainName $customDomainName -EndpointName $endpointName -ProfileName $profileName -ResourceGroupName $resourceGroup.ResourceGroupName } "NotFound"

    Remove-AzureRmResourceGroup -Name $resourceGroup.ResourceGroupName -Force
}

<#
.SYNOPSIS
Enable Https for custom domain with running endpoint
#>
function Test-CustomDomainEnableHttpsWithRunningEndpoint
{
  # Hard-coding host and endpoint names due to requirement for DNS CNAME
    $endpointName = "testVerizonEP"
    $hostName = "testVerizon.dustydog.us"

    $customDomainName = getAssetName

    $profileName = getAssetName
    $resourceGroup = TestSetup-CreateResourceGroup
    $resourceLocation = "EastUS"
    $profileSku = "Standard_Verizon"
    $tags = @{"tag1" = "value1"; "tag2" = "value2"}
    $createdProfile = New-AzCdnProfile -ProfileName $profileName -ResourceGroupName $resourceGroup.ResourceGroupName -Location $resourceLocation -Sku $profileSku -Tag $tags

    $originName = getAssetName
    $originHostName = "www.microsoft.com"
    $createdEndpoint = New-AzCdnEndpoint -EndpointName $endpointName -ProfileName $profileName -ResourceGroupName $resourceGroup.ResourceGroupName -Location $resourceLocation -OriginName $originName -OriginHostName $originHostName

    $endpoint = Get-AzCdnEndpoint -EndpointName $endpointName -ProfileName $profileName -ResourceGroupName $resourceGroup.ResourceGroupName
    $validateResult = Test-AzCdnCustomDomain -EndpointName $endpointName -ProfileName $profileName -ResourceGroupName $resourceGroup.ResourceGroupName -CustomDomainHostName $hostName
    Assert-True{$validateResult.CustomDomainValidated}
    $validateResultbyPiping = Test-AzCdnCustomDomain -CdnEndpoint $endpoint -CustomDomainHostName $hostName
    Assert-True{$validateResultbyPiping.CustomDomainValidated}

    $createdCustomDomain = New-AzCdnCustomDomain -HostName $hostName -CustomDomainName $customDomainName -EndpointName $endpointName -ProfileName $profileName -ResourceGroupName $resourceGroup.ResourceGroupName
    Assert-AreEqual $customDomainName $createdCustomDomain.Name
    Assert-AreEqual $hostName $createdCustomDomain.HostName

    $customDomain = Get-AzCdnCustomDomain -CustomDomainName $customDomainName -EndpointName $endpointName -ProfileName $profileName -ResourceGroupName $resourceGroup.ResourceGroupName
    Assert-AreEqual $customDomainName $customDomain.Name
    Assert-AreEqual $hostName $customDomain.HostName

    $enabled = $customDomain | Enable-AzCdnCustomDomainHttps -PassThru
    Assert-True{$enabled}

    $customDomain = Get-AzCdnCustomDomain -CustomDomainName $customDomainName -EndpointName $endpointName -ProfileName $profileName -ResourceGroupName $resourceGroup.ResourceGroupName

    Assert-AreEqual $customDomain.CustomHttpsProvisioningState "Enabling"

    Assert-ThrowsContains { $customDomain | Enable-AzCdnCustomDomainHttps } "BadRequest"

    Assert-ThrowsContains {  $customDomain | Disable-AzCdnCustomDomainHttps } "BadRequest"

    [int]$counter = 0
    do {
           SleepInRecordMode 600
           $customDomain = Get-AzCdnCustomDomain -CustomDomainName $customDomainName -EndpointName $endpointName -ProfileName $profileName -ResourceGroupName $resourceGroup.ResourceGroupName
    } while ($customDomain.CustomHttpsProvisioningState -ne "Enabled" -and $counter++ -lt 50)

    $disabled = $customDomain | Disable-AzCdnCustomDomainHttps -PassThru
    Assert-True{$disabled}

    $customDomain = Get-AzCdnCustomDomain -CustomDomainName $customDomainName -EndpointName $endpointName -ProfileName $profileName -ResourceGroupName $resourceGroup.ResourceGroupName

    Assert-AreEqual $customDomain.CustomHttpsProvisioningState "Disabling"

    Assert-ThrowsContains { $customDomain | Enable-AzCdnCustomDomainHttps } "BadRequest"

    Assert-ThrowsContains {  $customDomain | Disable-AzCdnCustomDomainHttps } "BadRequest"

    Remove-AzureRmResourceGroup -Name $resourceGroup.ResourceGroupName -Force
}