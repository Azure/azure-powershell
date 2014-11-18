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
Tests creating new simple resource group.
#>
function Test-CreatesNewSimpleResourceGroup
{
    # Setup
    $rgname = Get-ResourceGroupName
    $location = Get-ProviderLocation ResourceManagement

    try 
    {
        # Test
        $actual = New-AzureResourceGroup -Name $rgname -Location $location -Tags @{Name = "testtag"; Value = "testval"} 
        $expected = Get-AzureResourceGroup -Name $rgname

        # Assert
        Assert-AreEqual $expected.ResourceGroupName $actual.ResourceGroupName	
        Assert-AreEqual $expected.Tags[0]["Name"] $actual.Tags[0]["Name"]
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Tests updates existing resource group.
#>
function Test-UpdatesExistingResourceGroup
{
    # Setup
    $rgname = Get-ResourceGroupName
    $location = Get-ProviderLocation ResourceManagement

    try 
    {
        # Test update without tag
        Assert-Throws { Set-AzureResourceGroup -Name $rgname -Tags @{"testtag" = "testval"} } "ResourceGroupNotFound: Resource group '$rgname' could not be found."
        
        $new = New-AzureResourceGroup -Name $rgname -Location $location
        
        # Test update with bad tag format
        Assert-Throws { Set-AzureResourceGroup -Name $rgname -Tags @{"testtag" = "testval"} } "Invalid tag format. Expect @{Name = `"tagName`"} or @{Name = `"tagName`"; Value = `"tagValue`"}"
        # Test update with bad tag format
        Assert-Throws { Set-AzureResourceGroup -Name $rgname -Tags @{Name = "testtag"; Value = "testval"}, @{Name = "testtag"; Value = "testval2"} } "Invalid tag format. Ensure that each tag has a unique name. Example: @{Name = `"tagName1`"; Value = `"tagValue1`"}, @{Name = `"tagName2`"; Value = `"tagValue2`"}"
            
        $actual = Set-AzureResourceGroup -Name $rgname -Tags @{Name = "testtag"; Value = "testval"} 
        $expected = Get-AzureResourceGroup -Name $rgname

        # Assert
        Assert-AreEqual $expected.ResourceGroupName $actual.ResourceGroupName	
        Assert-AreEqual 0 $new.Tags.Count
        Assert-AreEqual $expected.Tags[0]["Name"] $actual.Tags[0]["Name"]
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Tests creating new simple resource group and deleting it via piping.
#>
function Test-CreatesAndRemoveResourceGroupViaPiping
{
    # Setup
    $rgname1 = Get-ResourceGroupName
    $rgname2 = Get-ResourceGroupName
    $location = Get-ProviderLocation ResourceManagement

    # Test
    New-AzureResourceGroup -Name $rgname1 -Location $location
    New-AzureResourceGroup -Name $rgname2 -Location $location

    Get-AzureResourceGroup | where {$_.ResourceGroupName -eq $rgname1 -or $_.ResourceGroupName -eq $rgname2} | Remove-AzureResourceGroup -Force

    # Assert
    Assert-Throws { Get-AzureResourceGroup -Name $rgname1 } "Provided resource group does not exist."
    Assert-Throws { Get-AzureResourceGroup -Name $rgname2 } "Provided resource group does not exist."
}

<#
.SYNOPSIS
Tests getting non-existing resource group.
#>
function Test-GetNonExistingResourceGroup
{
    # Setup
    $rgname = Get-ResourceGroupName

    Assert-Throws { Get-AzureResourceGroup -Name $rgname } "Provided resource group does not exist."
}

<#
.SYNOPSIS
Negative test. New resource group in non-existing location throws error.
#>
function Test-NewResourceGroupInNonExistingLocation
{
    # Setup
    $rgname = Get-ResourceGroupName

    Assert-Throws { New-AzureResourceGroup -Name $rgname -Location 'non-existing' }
}

<#
.SYNOPSIS
Negative test. New resource group in non-existing location throws error.
#>
function Test-RemoveNonExistingResourceGroup
{
    # Setup
    $rgname = Get-ResourceGroupName

    Assert-Throws { Remove-AzureResourceGroup $rgname -Force } "Provided resource group does not exist."
}

<#
.SYNOPSIS
Negative test. New resource group in non-existing location throws error.
#>
function Test-AzureTagsEndToEnd
{
    # Setup
    $tag1 = getAssetName
    $tag2 = getAssetName
    Clean-Tags

    # Create tag without values
    New-AzureTag $tag1

    $tag = Get-AzureTag $tag1
    Assert-AreEqual $tag1 $tag.Name

    # Add value to the tag (adding same value should pass)
    New-AzureTag $tag1 value1
    New-AzureTag $tag1 value1
    New-AzureTag $tag1 value2

    $tag = Get-AzureTag $tag1
    Assert-AreEqual 2 $tag.Values.Count

    # Create tag with values
    New-AzureTag $tag2 value1
    New-AzureTag $tag2 value2
    New-AzureTag $tag2 value3

    $tags = Get-AzureTag
    Assert-AreEqual 2 $tags.Count

    # Remove entire tag
    $tag = Remove-AzureTag $tag1 -Force -PassThru

    $tags = Get-AzureTag
    Assert-AreEqual $tag1 $tag.Name

    # Remove tag value
    $tag = Remove-AzureTag $tag2 value1 -Force -PassThru

    $tags = Get-AzureTag
    Assert-AreEqual 0 $tags.Count

    # Get a non-existing tag
    Assert-Throws { Get-AzureTag "non-existing" }

    Clean-Tags
}

<#
.SYNOPSIS
Tests registration of required template provider
#>
function Test-NewDeploymentAndProviderRegistration
{
    # Setup
    $rgname = Get-ResourceGroupName
    $rname = Get-ResourceName
    $location = Get-ProviderLocation ResourceManagement
    $template = "Microsoft.Cache.0.4.0-preview"
    $provider = "microsoft.cache"

    try 
    {
        # Unregistering microsoft.cache to have clean state
        $subscription = [Microsoft.WindowsAzure.Commands.Utilities.Common.AzureProfile]::Instance.CurrentSubscription
        $client = New-Object Microsoft.Azure.Commands.Resources.Models.ResourcesClient $subscription
         
        # Verify provider is registered
        $providers = [Microsoft.WindowsAzure.Commands.Utilities.Common.AzureProfile]::Instance.CurrentSubscription.RegisteredResourceProvidersList
        if( $providers -Contains $provider )
        {
            $client.UnregisterProvider($provider) 
        }

        # Test
        $deployment = New-AzureResourceGroup -Name $rgname -Location $location -GalleryTemplateIdentity $template -cacheName $rname -cacheLocation $location

        # Assert
        $client = New-Object Microsoft.Azure.Commands.Resources.Models.ResourcesClient $subscription
        $providers = [Microsoft.WindowsAzure.Commands.Utilities.Common.AzureProfile]::Instance.CurrentSubscription.RegisteredResourceProvidersList
        
        Assert-True { $providers -Contains $provider }

    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

function Test-NewResourceGroupWithTemplateThenGetWithAndWithoutDetails
{
    # Setup
    $rgname = Get-ResourceGroupName
    $websiteName = Get-ResourceName
    $location = Get-ProviderLocation ResourceManagement
    $templateFile = "Resources\EmptyWebsiteTemplate.json"

    try
    {
        # Test
        $actual = New-AzureResourceGroup -Name $rgname -Location $location -TemplateFile $templateFile `
                    -siteName $websiteName -hostingPlanName "test" -siteLocation "West US" `
                    -Tag @{ Name = "testtag"; Value = "testval" }

        $expected1 = Get-AzureResourceGroup -Name $rgname
        # Assert
        Assert-AreEqual $expected1.ResourceGroupName $actual.ResourceGroupName
        Assert-AreEqual $expected1.Tags[0]["Name"] $actual.Tags[0]["Name"]
        Assert-AreEqual $expected1.Resources.Count 2

        $expected2 = Get-AzureResourceGroup
        # Assert
        Assert-AreEqual $expected2[0].Resources.Count 0

        $expected3 = Get-AzureResourceGroup -Detailed
        $names = $expected3 | Select-Object -ExpandProperty ResourceGroupName
        $index = [Array]::IndexOf($names, $expected1.ResourceGroupName)
        # Assert
        Assert-AreEqual $expected3[$index].Resources.Count 2
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}