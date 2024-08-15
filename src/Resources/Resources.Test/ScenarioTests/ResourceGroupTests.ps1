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
    $location = Get-Location "Microsoft.Resources" "resourceGroups" "West US"

    try
    {
        # Test
        $actual = New-AzResourceGroup -Name $rgname -Location $location -Tags @{ testtag = "testval"}
        $expected = Get-AzResourceGroup -Name $rgname

        # Assert
        Assert-AreEqual $expected.ResourceGroupName $actual.ResourceGroupName
        Assert-AreEqual $expected.Tags["testtag"] $actual.Tags["testtag"]
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
    $location = Get-Location "Microsoft.Resources" "resourceGroups" "West US"

    try
    {
        # Test update without tag
        Set-AzResourceGroup -Name $rgname -Tags @{testtag = "testval"} -ErrorAction SilentlyContinue
        Assert-True { $Error[0] -like "*Provided resource group does not exist." }
        $Error.Clear()

        $new = New-AzResourceGroup -Name $rgname -Location $location

        $actual = Set-AzResourceGroup -Name $rgname -Tags @{ testtag = "testval" }
        $expected = Get-AzResourceGroup -Name $rgname

        # Assert
        Assert-AreEqual $expected.ResourceGroupName $actual.ResourceGroupName
        Assert-AreEqual 0 $new.Tags.Count
        Assert-AreEqual $expected.Tags["testtag"] $actual.Tags["testtag"]
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
    $location = Get-Location "Microsoft.Resources" "resourceGroups" "West US"

    # Test
    New-AzResourceGroup -Name $rgname1 -Location $location
    New-AzResourceGroup -Name $rgname2 -Location $location

    $job = Get-AzResourceGroup | where {$_.ResourceGroupName -eq $rgname1 -or $_.ResourceGroupName -eq $rgname2} | Remove-AzResourceGroup -Force -AsJob
	Wait-Job $job

    # Assert
    Get-AzResourceGroup -Name $rgname1 -ErrorAction SilentlyContinue
    Assert-True { $Error[0] -like "*Provided resource group does not exist." }
    $Error.Clear()

    Get-AzResourceGroup -Name $rgname2 -ErrorAction SilentlyContinue
    Assert-True { $Error[0] -like "*Provided resource group does not exist." }
    $Error.Clear()
}

<#
.SYNOPSIS
Tests getting non-existing resource group.
#>
function Test-GetNonExistingResourceGroup
{
    # Setup
    $rgname = Get-ResourceGroupName

    Get-AzResourceGroup -Name $rgname -ErrorAction SilentlyContinue
    Assert-True { $Error[0] -like "*Provided resource group does not exist." }
    $Error.Clear()
}

<#
.SYNOPSIS
Negative test. New resource group in non-existing location throws error.
#>
function Test-NewResourceGroupInNonExistingLocation
{
    # Setup
    $rgname = Get-ResourceGroupName

    Assert-Throws { New-AzResourceGroup -Name $rgname -Location 'non-existing' }
}

<#
.SYNOPSIS
Negative test. New resource group in non-existing location throws error.
#>
function Test-RemoveNonExistingResourceGroup
{
    # Setup
    $rgname = Get-ResourceGroupName

    Remove-AzResourceGroup -Name $rgname -Force -ErrorAction SilentlyContinue
    Assert-True { $Error[0] -like "*Provided resource group does not exist." }
    $Error.Clear()
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
    New-AzTag $tag1

    $tag = Get-AzTag $tag1
    Assert-AreEqual $tag1 $tag.Name

    # Add value to the tag (adding same value should pass)
    New-AzTag $tag1 value1
    New-AzTag $tag1 value1
    New-AzTag $tag1 value2

    $tag = Get-AzTag $tag1
    Assert-AreEqual 2 $tag.Values.Count

    # Create tag with values
    New-AzTag $tag2 value1
    New-AzTag $tag2 value2
    New-AzTag $tag2 value3

    $tags = Get-AzTag
    Assert-AreEqual 2 $tags.Count

    # Remove entire tag
    $tag = Remove-AzTag $tag1 -Force -PassThru

    $tags = Get-AzTag
    Assert-AreEqual $tag1 $tag.Name

    # Remove tag value
    $tag = Remove-AzTag $tag2 value1 -Force -PassThru

    $tags = Get-AzTag
    Assert-AreEqual 0 $tags.Count

    # Get a non-existing tag
    Assert-Throws { Get-AzTag "non-existing" }

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
    $location = Get-Location "Microsoft.Resources" "resourceGroups" "West US"
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
        $deployment = New-AzResourceGroup -Name $rgname -Location $location -GalleryTemplateIdentity $template -cacheName $rname -cacheLocation $location

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

<#
.SYNOPSIS
Tests delete resource group deployment 
#>
function Test-RemoveDeployment
{
    # Setup
    $deploymentName = "Test"
    $templateUri = "https://raw.githubusercontent.com/Azure/azure-quickstart-templates/b5a68ce5005bc186070506b8d42a25b865f047a6/100-blank-template/azuredeploy.json"
    $rgName = "TestSDK0123"

    try
    {
        # First create new resource group deployment
        New-AzResourceGroup -Name $rgName -Location "East US"
        $deployment = New-AzResourceGroupDeployment -ResourceGroupName $rgName -Name $deploymentName -TemplateUri $templateUri

        # Test
        $res = Remove-AzResourceGroupDeployment -ResourceGroupName $deployment.ResourceGroupName -Name $deployment.DeploymentName

        # Assert
		Assert-True { $res }

        # After deletion, try to get the given deployment should throw an error
        Get-AzResourceGroupDeployment -ResourceGroupName $rgName -Name $deploymentName -ErrorAction SilentlyContinue
        Assert-True { $Error[0] -like "*Deployment 'Test' could not be found.*" }
        $Error.Clear()
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgName
    }
}

<#
.SYNOPSIS
Tests find resource group command
#>
function Test-FindResourceGroup
{
    # Setup
    $rgname = Get-ResourceGroupName
	$rgname2 = Get-ResourceGroupName
    $location = Get-Location "Microsoft.Resources" "resourceGroups" "West US"
	$originalResorcrGroups = Get-AzResourceGroup
	$originalCount = @($originalResorcrGroups).Count

    try
    {
        # Test
        $actual = New-AzResourceGroup -Name $rgname -Location $location -Tag @{ testtag = "testval" }
        $actual2 = New-AzResourceGroup -Name $rgname2 -Location $location -Tag @{ testtag2 = "testval2"; testtag = "test_val" }

        $expected1 = Get-AzResourceGroup -Name $rgname
        # Assert
        Assert-AreEqual $expected1.ResourceGroupName $actual.ResourceGroupName
        Assert-AreEqual $expected1.Tags["testtag"] $actual.Tags["testtag"]

		$expected2 = Get-AzResourceGroup -Name $rgname2
        # Assert
        Assert-AreEqual $expected2.ResourceGroupName $actual2.ResourceGroupName
        Assert-AreEqual $expected2.Tags["testtag"] $actual2.Tags["testtag"]

		$expected2 = Get-AzResourceGroup -Name ($rgname2 + "*")
        # Assert
        Assert-AreEqual $expected2.ResourceGroupName $actual2.ResourceGroupName
        Assert-AreEqual $expected2.Tags["testtag"] $actual2.Tags["testtag"]

		$expected3 = Get-AzResourceGroup
		$expectedCount = $originalCount + 2
		# Assert
		Assert-AreEqual @($expected3).Count $expectedCount

		$expected3 = Get-AzResourceGroup -Name *
		$expectedCount = $originalCount + 2
		# Assert
		Assert-AreEqual @($expected3).Count $expectedCount

		$expected4 = Get-AzResourceGroup -Tag @{ testtag = $null}
        # Assert
        Assert-AreEqual @($expected4).Count 2

		$expected5 = Get-AzResourceGroup -Tag @{ testtag = "testval" }
        # Assert
        Assert-AreEqual @($expected5).Count 1

		$expected6 = Get-AzResourceGroup -Tag @{ testtag2 = $null }
        # Assert
        Assert-AreEqual @($expected6).Count 1

		$expected7 = Get-AzResourceGroup -Tag @{ testtag2 = "testval" }
        # Assert
        Assert-AreEqual @($expected7).Count 0

		$expected8 = Get-AzResourceGroup -Tag @{ testtagX = $null }
        # Assert
        Assert-AreEqual @($expected8).Count 0

		$expected9 = Get-AzResourceGroup -Tag @{ testtagY = "testval" }
        # Assert
        Assert-AreEqual @($expected9).Count 0
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
        Clean-ResourceGroup $rgname2
    }
}

<#
.SYNOPSIS
Tests remove non exist resource group and debug stream gets printed
#>
function Test-GetNonExistingResourceGroupWithDebugStream
{
    $ErrorActionPreference="Continue"
    $output = $(Get-AzResourceGroup -Name "InvalidNonExistRocks" -Debug) 2>&1 5>&1 | Out-String
    $ErrorActionPreference="Stop"
    Assert-True { $output -Like "*============================ HTTP RESPONSE ============================*" }
}

<#
.SYNOPSIS
Tests export resource group template file.
#>
function Test-ExportResourceGroup
{
	# Setup
	$rgname = Get-ResourceGroupName
	$rname = Get-ResourceName
	$rglocation = Get-Location "Microsoft.Resources" "resourceGroups" "West US"
	$apiversion = "2014-04-01"
	$resourceType = "Providers.Test/statefulResources"


	try
	{
		# Test
		New-AzResourceGroup -Name $rgname -Location $rglocation
        
		$r = New-AzResource -Name $rname -Location "centralus" -Tags @{ testtag = "testval" } -ResourceGroupName $rgname -ResourceType $resourceType -SkuObject @{ Name = "A0" } -ApiVersion $apiversion -Force
		Assert-AreEqual $r.ResourceGroupName $rgname

		$exportOutput = Export-AzResourceGroup -ResourceGroupName $rgname -Force
		Assert-NotNull $exportOutput
		Assert-True { $exportOutput.Path.Contains($rgname + ".json") }
	}

	finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Tests async export to export resource group template file.
#>
function Test-ExportResourceGroup-AsyncRoute
{
	# Setup
	$rgname = Get-ResourceGroupName
	$rname = Get-ResourceName
	$rnameConstant = Get-ResourceName
	$rglocation = Get-Location "Microsoft.Resources" "resourceGroups" "West US"
	$resourceType = "Providers.Test/statefulResources"

	try
	{
		# Test
		New-AzResourceGroup -Name $rgname -Location $rglocation

		$i = 0;
		while($i -lt 25)
		{
		  $rname = $rnameConstant + $i.ToString()
		  New-AzResource -Name $rname -Location "centralus" -Tags @{ testtag = "testval" } -ResourceGroupName $rgname -ResourceType $resourceType -SkuObject @{ Name = "A0" } -Force
		  $i++
		}

		$resourcesCount = (Get-AzResource -ResourceGroupName $rgname).Length
		Assert-True { $resourcesCount -gt 20 }

		$exportOutput = Export-AzResourceGroup -ResourceGroupName $rgname -Force
		Assert-NotNull $exportOutput
		Assert-True { $exportOutput.Path.Contains($rgname + ".json") }
	}

	finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Tests export resource group with resource filtering.
#>
function Test-ExportResourceGroupWithFiltering
{
    # Setup
    $rgname = Get-ResourceGroupName
    $rname1 = Get-ResourceName
    $rname2 = Get-ResourceName
    $rglocation = Get-Location "Microsoft.Resources" "resourceGroups" "West US"
    $apiversion = "2014-04-01"
    $resourceType = "Providers.Test/statefulResources"


    try
    {
        # Test
        New-AzResourceGroup -Name $rgname -Location $rglocation

        $r1 = New-AzResource -Name $rname1 -Location "centralus" -Tags @{ testtag = "testval" } -ResourceGroupName $rgname -ResourceType $resourceType -SkuObject @{ Name = "A0" } -ApiVersion $apiversion -Force
        Assert-NotNull $r1.ResourceId

        $r2 = New-AzResource -Name $rname2 -Location "centralus" -Tags @{ testtag = "testval" } -ResourceGroupName $rgname -ResourceType $resourceType -SkuObject @{ Name = "A0" } -ApiVersion $apiversion -Force
        Assert-NotNull $r2.ResourceId

        $exportOutput = Export-AzResourceGroup -ResourceGroupName $rgname -Force -Resource @($r2.ResourceId) -IncludeParameterDefaultValue -IncludeComments
        Assert-NotNull $exportOutput
        Assert-True { $exportOutput.Path.Contains($rgname + ".json") }
    }

    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Tests resource group new, get and remove using positional parameters.
#>
function Test-ResourceGroupWithPositionalParams
{
    # Setup
    $rgname = Get-ResourceGroupName
    $location = Get-Location "Microsoft.Resources" "resourceGroups" "West US"

    try
    {
        $ErrorActionPreference = "SilentlyContinue"
        $Error.Clear()
        # Test
        $actual = New-AzResourceGroup $rgname $location
        $expected = Get-AzResourceGroup $rgname

        # Assert
        Assert-AreEqual $expected.ResourceGroupName $actual.ResourceGroupName

        #Test
        Remove-AzResourceGroup $rgname -Force
    }
    catch
    {
        Assert-True { $Error[0].Contains("Provided resource group does not exist.") }
    }
}