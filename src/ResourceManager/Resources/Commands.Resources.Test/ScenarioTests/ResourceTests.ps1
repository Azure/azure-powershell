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
Tests creating new resource group and a simple resource.
.DESCRIPTION
Smoke[Broken]Test
#>
function Test-CreatesNewSimpleResource
{
    # Setup
    $rgname = Get-ResourceGroupName
    $rname = Get-ResourceName
    $rglocation = Get-Location "Microsoft.Resources" "resourceGroups" "West US"
    $location = Get-Location "Microsoft.Sql" "servers" "West US"
    $apiversion = "2014-04-01"
    $resourceType = "Microsoft.Sql/servers"

    # Test
    New-AzureRmResourceGroup -Name $rgname -Location $rglocation
        #[SuppressMessage("Microsoft.Security", "CS002:SecretInNextLine")]
        $actual = New-AzureRmResource -Name $rname -Location $location -Tags @{ testtag = "testval"} -ResourceGroupName $rgname -ResourceType $resourceType -PropertyObject @{"administratorLogin" = "adminuser"; "administratorLoginPassword" = "P@ssword1"} -SkuObject @{ Name = "A0" } -ApiVersion $apiversion
    $expected = Get-AzureRmResource -Name $rname -ResourceGroupName $rgname -ResourceType $resourceType -ApiVersion $apiversion

    $list = Get-AzureRmResource -ResourceGroupName $rgname

    # Assert
    Assert-AreEqual $expected.Name $actual.Name
    Assert-AreEqual $expected.ResourceGroupName $actual.ResourceGroupName
    Assert-AreEqual $expected.ResourceType $actual.ResourceType
    Assert-AreEqual 1 @($list).Count
    Assert-AreEqual $expected.Name $list[0].Name
    Assert-AreEqual $expected.Sku $actual.Sku
}

<#
.SYNOPSIS
Tests creating new resource group and parent and child resources.
.DESCRIPTION
Smoke[Broken]Test
#>
function Test-CreatesNewComplexResource
{
    # Setup
    $rgname = Get-ResourceGroupName
    $rnameParent = Get-ResourceName
    $rnameChild = Get-ResourceName
    $resourceTypeChild = "Microsoft.Sql/servers/databases"
    $rglocation = Get-Location "Microsoft.Resources" "resourceGroups" "West US"
    $location = Get-Location "Microsoft.Sql" "servers" "West US"
    $apiversion = "2014-04-01"

    # Test
    New-AzureRmResourceGroup -Name $rgname -Location $rglocation
        #[SuppressMessage("Microsoft.Security", "CS002:SecretInNextLine")]
    $actualParent = New-AzureRmResource -Name $rnameParent -Location $location -ResourceGroupName $rgname -ResourceType $resourceTypeParent -PropertyObject @{"administratorLogin" = "adminuser"; "administratorLoginPassword" = "P@ssword1"} -ApiVersion $apiversion
    $expectedParent = Get-AzureRmResource -Name $rnameParent -ResourceGroupName $rgname -ResourceType $resourceTypeParent -ApiVersion $apiversion

    $actualChild = New-AzureRmResource -Name $rnameChild -Location $location -ResourceGroupName $rgname -ResourceType $resourceTypeChild -ParentResource servers/$rnameParent -PropertyObject @{"edition" = "Web"; "collation" = "SQL_Latin1_General_CP1_CI_AS"; "maxSizeBytes" = "1073741824"} -ApiVersion $apiversion
    $expectedChild = Get-AzureRmResource -Name $rnameChild -ResourceGroupName $rgname -ResourceType $resourceTypeChild -ParentResource servers/$rnameParent -ApiVersion $apiversion

    $list = Get-AzureRmResource -ResourceGroupName $rgname

    $parentFromList = $list | where {$_.ResourceType -eq $resourceTypeParent} | Select-Object -First 1
    $childFromList = $list | where {$_.ResourceType -eq $resourceTypeChild} | Select-Object -First 1

    $listOfServers = Get-AzureRmResource -ResourceType $resourceTypeParent -ResourceGroupName $rgname
    $listOfDatabases = Get-AzureRmResource -ResourceType $resourceTypeChild -ResourceGroupName $rgname

    # Assert
    Assert-AreEqual $expectedParent.Name $actualParent.Name
    Assert-AreEqual $expectedChild.Name $actualChild.Name
    Assert-AreEqual $expectedParent.ResourceType $actualParent.ResourceType
    Assert-AreEqual $expectedChild.ResourceType $actualChild.ResourceType

    Assert-AreEqual 2 @($list).Count
    Assert-AreEqual $expectedParent.Name $parentFromList.Name
    Assert-AreEqual $expectedChild.Name $childFromList.Name
    Assert-AreEqual $expectedParent.ResourceType $parentFromList.ResourceType
    Assert-AreEqual $expectedChild.ResourceType $childFromList.ResourceType

    Assert-AreEqual 1 @($listOfServers).Count
    Assert-AreEqual 1 @($listOfDatabases).Count
}

<#
.SYNOPSIS
Tests get resources via piping from resource group
.DESCRIPTION
Smoke[Broken]Test
#>
function Test-GetResourcesViaPiping
{
    # Setup
    $rgname = Get-ResourceGroupName
    $rnameParent = Get-ResourceName
    $rnameChild = Get-ResourceName
    $resourceTypeChild = "Microsoft.Sql/servers/databases"
    $rglocation = Get-Location "Microsoft.Resources" "resourceGroups" "West US"
    $location = Get-Location "Microsoft.Sql" "servers" "West US"
    $apiversion = "2014-04-01"

    # Test
    New-AzureRmResourceGroup -Name $rgname -Location $rglocation
        #[SuppressMessage("Microsoft.Security", "CS002:SecretInNextLine")]
    New-AzureRmResource -Name $rnameParent -Location $location -ResourceGroupName $rgname -ResourceType $resourceTypeParent -PropertyObject @{"administratorLogin" = "adminuser"; "administratorLoginPassword" = "P@ssword1"} -ApiVersion $apiversion
    New-AzureRmResource -Name $rnameChild -Location $location -ResourceGroupName $rgname -ResourceType $resourceTypeChild -ParentResource servers/$rnameParent -PropertyObject @{"edition" = "Web"; "collation" = "SQL_Latin1_General_CP1_CI_AS"; "maxSizeBytes" = "1073741824"} -ApiVersion $apiversion

    $list = Get-AzureRmResourceGroup -Name $rgname | Get-AzureRmResource
    $serverFromList = $list | where {$_.ResourceType -eq $resourceTypeParent} | Select-Object -First 1
    $databaseFromList = $list | where {$_.ResourceType -eq $resourceTypeChild} | Select-Object -First 1

    # Assert
    Assert-AreEqual 2 @($list).Count
    Assert-AreEqual $rnameParent $serverFromList.Name
    Assert-AreEqual $rnameChild $databaseFromList.Name
    Assert-AreEqual $resourceTypeParent $serverFromList.ResourceType
    Assert-AreEqual $resourceTypeChild $databaseFromList.ResourceType
}

<#
.SYNOPSIS
Nagative test. Get resources from an empty group.
#>
function Test-GetResourcesFromEmptyGroup
{
    # Setup
    $rgname = Get-ResourceGroupName
    $location = Get-Location "Microsoft.Resources" "resourceGroups" "West US"

    # Test
    New-AzureRmResourceGroup -Name $rgname -Location $location
    $listViaPiping = Get-AzureRmResourceGroup -Name $rgname | Get-AzureRmResource
    $listViaDirect = Get-AzureRmResource -ResourceGroupName $rgname

    # Assert
    Assert-AreEqual 0 @($listViaPiping).Count
    Assert-AreEqual 0 @($listViaDirect).Count
}

<#
.SYNOPSIS
Nagative test. Get resources from an non-existing empty group.
#>
function Test-GetResourcesFromNonExisingGroup
{
    # Setup
    $rgname = Get-ResourceGroupName

    # Test
    Assert-Throws { Get-AzureRmResource -ResourceGroupName $rgname } "Provided resource group does not exist."
}

<#
.SYNOPSIS
Nagative test. Get resources from non-existing type.
#>
function Test-GetResourcesForNonExisingType
{
    # Test
    $list = Get-AzureRmResource -ResourceType 'Non-Existing'

    # Assert
    Assert-AreEqual 0 @($list).Count
}

<#
.SYNOPSIS
Nagative test. Get non-existing resource.
#>
function Test-GetResourceForNonExisingResource
{
    # Setup
    $rgname = Get-ResourceGroupName
    $rname = Get-ResourceGroupName
    $location = Get-Location "Microsoft.Resources" "resourceGroups" "West US"
    $resourceTypeWeb = "Microsoft.Web/sites"
    $resourceTypeSql = "Microsoft.Sql/servers"
    $apiversion = "2014-04-01"

    # Test
    New-AzureRmResourceGroup -Name $rgname -Location $location
    Assert-Throws { Get-AzureRmResource -Name $rname -ResourceGroupName $rgname -ResourceType $resourceTypeWeb -ApiVersion $apiversion } "Provided resource does not exist."
    Assert-Throws { Get-AzureRmResource -Name $rname -ResourceGroupName $rgname -ResourceType $resourceTypeSql -ApiVersion $apiversion } "Provided resource does not exist."
    Assert-Throws { Get-AzureRmResource -Name $rname -ResourceGroupName $rgname -ResourceType 'Microsoft.Fake/nonexisting' -ApiVersion $apiversion } "Provided resource does not exist."
}

<#
.SYNOPSIS
Tests get resources via piping from resource group
.DESCRIPTION
Smoke[Broken]Test
#>
function Test-GetResourcesViaPipingFromAnotherResource
{
    # Setup
    $rgname = Get-ResourceGroupName
    $rnameParent = Get-ResourceName
    $rnameChild = Get-ResourceName
    $resourceTypeChild = "Microsoft.Sql/servers/databases"
    $rglocation = Get-Location "Microsoft.Resources" "resourceGroups" "West US"
    $location = Get-Location "Microsoft.Sql" "servers" "West US"
    $apiversion = "2014-04-01"

    # Test
    New-AzureRmResourceGroup -Name $rgname -Location $rglocation
        #[SuppressMessage("Microsoft.Security", "CS002:SecretInNextLine")]
    New-AzureRmResource -Name $rnameParent -Location $location -ResourceGroupName $rgname -ResourceType $resourceTypeParent -PropertyObject @{"administratorLogin" = "adminuser"; "administratorLoginPassword" = "P@ssword1"} -ApiVersion $apiversion
    New-AzureRmResource -Name $rnameChild -Location $location -ResourceGroupName $rgname -ResourceType $resourceTypeChild -ParentResource servers/$rnameParent -PropertyObject @{"edition" = "Web"; "collation" = "SQL_Latin1_General_CP1_CI_AS"; "maxSizeBytes" = "1073741824"} -ApiVersion $apiversion

    $list = Get-AzureRmResource -ResourceGroupName $rgname | Get-AzureRmResource -ApiVersion $apiversion

    # Assert
    Assert-AreEqual 2 @($list).Count
}

<#
.SYNOPSIS
Tests moving a resource.
.DESCRIPTION
SmokeTest
#>
function Test-MoveAResource
{
    # Setup
    $rgname = Get-ResourceGroupName
    $rgname2 = Get-ResourceGroupName + "test3"
    $rname = Get-ResourceName
    $rglocation = Get-Location "Microsoft.Resources" "resourceGroups" "West US"
    $apiversion = "2014-04-01"
    $resourceType = "Providers.Test/statefulResources"

    try
    {
        # Test
        New-AzureRmResourceGroup -Name $rgname -Location $rglocation
        New-AzureRmResourceGroup -Name $rgname2 -Location $rglocation
        $resource = New-AzureRmResource -Name $rname -Location $rglocation -Tags @{testtag = "testval"} -ResourceGroupName $rgname -ResourceType $resourceType -PropertyObject @{"key" = "value"} -ApiVersion $apiversion -Force
        Move-AzureRmResource -ResourceId $resource.ResourceId -DestinationResourceGroupName $rgname2 -Force

        $movedResource = Get-AzureRmResource -ResourceGroupName $rgname2 -ResourceName $rname -ResourceType $resourceType

        # Assert
        Assert-AreEqual $movedResource.Name $resource.Name
        Assert-AreEqual $movedResource.ResourceGroupName $rgname2
        Assert-AreEqual $movedResource.ResourceType $resource.ResourceType
    }
    finally
    {
        Clean-ResourceGroup $rgname
        Clean-ResourceGroup $rgname2
    }
}

<#
.SYNOPSIS
Tests moving a resource but failed.
#>
function Test-MoveResourceFailed
{
    #Move a resource through pipeline while no resource is sent
    $exceptionMessage = "At least one valid resource Id must be provided.";
    Assert-Throws { Get-AzureRmResource | Where-Object { $PSItem.Name -eq "NonExistingResource" } | Move-AzureRmResource -DestinationResourceGroupName "AnyResourceGroup" } $exceptionMessage

    #Move two resources from two resource groups
    $resourceId1 = "/subscriptions/fb3a3d6b-44c8-44f5-88c9-b20917c9b96b/resourceGroups/tianorg1/providers/Microsoft.Storage/storageAccounts/temp1"
    $resourceId2 = "/subscriptions/fb3a3d6b-44c8-44f5-88c9-b20917c9b96b/resourceGroups/tianorg2/providers/Microsoft.Storage/storageAccounts/temp1"
    $exceptionMessage = "The resources being moved must all reside in the same resource group. The resources: *"
    Assert-ThrowsLike { Move-AzureRmResource -DestinationResourceGroupName "AnyGroup" -ResourceId @($resourceId1, $resourceId2) } $exceptionMessage
}

<#
.SYNOPSIS
Tests setting a resource.
.DESCRIPTION
SmokeTest
#>
function Test-SetAResource
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
        New-AzureRmResourceGroup -Name $rgname -Location $rglocation
        $resource = New-AzureRmResource -Name $rname -Location $rglocation -Tags @{testtag = "testval"} -ResourceGroupName $rgname -ResourceType $resourceType -PropertyObject @{"key" = "value"} -SkuObject @{ Name = "A0" } -ApiVersion $apiversion -Force

        # Verify original value
        $oldSku = $resource.Sku.psobject
        $oldSkuNameProperty = $oldSku.Properties
        Assert-AreEqual $oldSkuNameProperty.Name "name"
        Assert-AreEqual $resource.SKu.Name "A0"

        # Set resource
        Set-AzureRmResource -ResourceGroupName $rgname -ResourceName $rname -ResourceType $resourceType -Properties @{"key2" = "value2"} -Force
        $job = Set-AzureRmResource -ResourceGroupName $rgname -ResourceName $rname -ResourceType $resourceType -SkuObject @{ Name = "A1" }  -Force -AsJob
        $job | Wait-Job

        $modifiedResource = Get-AzureRmResource -ResourceGroupName $rgname -ResourceName $rname -ResourceType $resourceType

        # Assert
        Assert-AreEqual $modifiedResource.Properties.key2 "value2"
        Assert-AreEqual $modifiedResource.Sku.Name "A1"
    }
    finally
    {
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Tests setting a resource using patch.
#>
function Test-SetAResourceWithPatch
{
    # Setup
    $rgname = Get-ResourceGroupName
    $rname = Get-ResourceName
    $rglocation = Get-Location "Microsoft.Resources" "resourceGroups" "West US"
    $apiversion = "2014-04-01"
    $resourceType = "Providers.Test/statefulResources"

    # Test
    New-AzureRmResourceGroup -Name $rgname -Location $rglocation
    $resource = New-AzureRmResource -Name $rname -Location $rglocation -Tags @{testtag = "testval"} -ResourceGroupName $rgname -ResourceType $resourceType -PropertyObject @{"key" = "value"} -SkuObject @{ Name = "A0" } -ApiVersion $apiversion -Force
    Set-AzureRmResource -ResourceGroupName $rgname -ResourceName $rname -ResourceType $resourceType -Properties @{"key2" = "value2"} -Force
    Set-AzureRmResource -ResourceGroupName $rgname -ResourceName $rname -ResourceType $resourceType -SkuObject @{ Name = "A1" } -UsePatchSemantics -Force

    $modifiedResource = Get-AzureRmResource -ResourceGroupName $rgname -ResourceName $rname -ResourceType $resourceType

    # Assert patch didn't overwrite existing properties
    Assert-AreEqual $modifiedResource.Properties.key2 "value2"
    Assert-AreEqual $modifiedResource.Sku.Name "A1"
}

<#
.SYNOPSIS
Tests finding a resource.
.DESCRIPTION
SmokeTest
#>
function Test-FindAResource
{
    # Setup
    $rgname = Get-ResourceGroupName
    $rname = "testname"
    $rname2 = "test2name"
    $rglocation = Get-Location "Microsoft.Resources" "resourceGroups" "West US"
    $apiversion = "2014-04-01"
    $resourceType = "Providers.Test/statefulResources"

    try
    {
        # Test
        New-AzureRmResourceGroup -Name $rgname -Location $rglocation
        $actual = New-AzureRmResource -Name $rname -Location $rglocation -Tags @{testtag = "testval"} -ResourceGroupName $rgname -ResourceType $resourceType -PropertyObject @{"key" = "value"} -SkuObject @{ Name = "A0" } -ApiVersion $apiversion -Force
        $expected = Get-AzureRmResource -ResourceName "*test*" -ResourceGroupName "*$rgname*"
        Assert-NotNull $expected
        Assert-AreEqual $actual.ResourceId $expected[0].ResourceId

        $expected = Get-AzureRmResource -ResourceType $resourceType -ResourceGroupName "*$rgName*"
        Assert-NotNull $expected
        Assert-AreEqual $actual.ResourceId $expected[0].ResourceId

        New-AzureRmResource -Name $rname2 -Location $rglocation -Tags @{testtag = "testval"} -ResourceGroupName $rgname -ResourceType $resourceType -PropertyObject @{"key" = "value"} -SkuObject @{ Name = "A0" } -ApiVersion $apiversion -Force
        $expected = Get-AzureRmResource -ResourceName "*test*" -ResourceGroupName "*$rgname*"
        Assert-AreEqual 2 @($expected).Count

        $expected = Get-AzureRmResource -ResourceGroupName $rgname -ResourceName $rname
        Assert-NotNull $expected
        Assert-AreEqual $actual.ResourceId $expected[0].ResourceId
    }
    finally
    {
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Tests finding a resource by tag.
.DESCRIPTION
Smoke[Broken]Test
#>
function Test-FindAResource-ByTag
{
    # Setup
    $rgname = Get-ResourceGroupName
    $rname = "testname"
    $rname2 = "test2name"
    $rglocation = Get-Location "Microsoft.Resources" "resourceGroups" "West US"
    $apiversion = "2014-04-01"
    $resourceType = "Providers.Test/statefulResources"

    try
    {
        # Test
        New-AzureRmResourceGroup -Name $rgname -Location $rglocation
        $actual = New-AzureRmResource -Name $rname -Location $rglocation -Tags @{ScenarioTestTag = "ScenarioTestVal"} -ResourceGroupName $rgname -ResourceType $resourceType -PropertyObject @{"key" = "value"} -SkuObject @{ Name = "A0" } -ApiVersion $apiversion -Force
        $expected = Get-AzureRmResource -Tag @{ScenarioTestTag = "ScenarioTestVal"}
        Assert-NotNull $expected
        Assert-AreEqual $actual.ResourceId $expected[0].ResourceId

        $expected = Get-AzureRmResource -Tag @{ScenarioTestTag = $null}
        Assert-NotNull $expected
        Assert-AreEqual $actual.ResourceId $expected[0].ResourceId

        $expected = Get-AzureRmResource -TagName "ScenarioTestTag"
        Assert-NotNull $expected
        Assert-AreEqual $actual.ResourceId $expected[0].ResourceId

        $expected = Get-AzureRmResource -TagName "ScenarioTestTag" -TagValue "ScenarioTestVal"
        Assert-NotNull $expected
        Assert-AreEqual $actual.ResourceId $expected[0].ResourceId
    }
    finally
    {
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Tests getting a resource with properties expanded
.DESCRIPTION
SmokeTest
#>
function Test-GetResourceExpandProperties
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
        New-AzureRmResourceGroup -Name $rgname -Location $rglocation
        $resource = New-AzureRmResource -Name $rname -Location $rglocation -Tags @{testtag = "testval"} -ResourceGroupName $rgname -ResourceType $resourceType -PropertyObject @{"key" = "value"} -SkuObject @{ Name = "A0" } -ApiVersion $apiversion -Force
        $resourceGet = Get-AzureRmResource -ResourceName $rname -ResourceGroupName $rgname -ExpandProperties

        # Assert
        $properties = $resourceGet.Properties.psobject
        $keyProperty = $properties.Properties
        Assert-AreEqual $keyProperty.Name "key"
        Assert-AreEqual $resourceGet.Properties.key "value"
    }
    finally
    {
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Tests managing resource with zones.
#>
function Test-ManageResourceWithZones
{
    # Setup
    $rgname = Get-ResourceGroupName
    $rname = Get-ResourceName
    $rglocation = Get-Location "Microsoft.Resources" "resourceGroups" "West US"
    $location = "Central US"
    $apiversion = "2014-04-01"
    $resourceType = "Providers.Test/statefulResources"

    # Test
    New-AzureRmResourceGroup -Name $rgname -Location $rglocation
    $created = New-AzureRmResource -Name $rname -Location $location -Tags @{ testtag = "testval"} -ResourceGroupName $rgname -ResourceType $resourceType -Zones @("2") -Force

    # Assert
    Assert-NotNull $created
    Assert-AreEqual $created.Zones.Length 1
    Assert-AreEqual $created.Zones[0] "2"

    $resourceGet = Get-AzureRmResource -Name $rname -ResourceGroupName $rgname -ResourceType $resourceType

    # Assert
    Assert-NotNull $resourceGet
    Assert-AreEqual $resourceGet.Zones.Length 1
    Assert-AreEqual $resourceGet.Zones[0] "2"

    $resourceSet = set-AzureRmResource -Name $rname -ResourceGroupName $rgname -ResourceType $resourceType -Zones @("3") -Force

    # Assert
    Assert-NotNull $resourceSet
    Assert-AreEqual $resourceSet.Zones.Length 1
    Assert-AreEqual $resourceSet.Zones[0] "3"

    $resourceGet = Get-AzureRmResource -Name $rname -ResourceGroupName $rgname -ResourceType $resourceType

    # Assert
    Assert-NotNull $resourceGet
    Assert-AreEqual $resourceGet.Zones.Length 1
    Assert-AreEqual $resourceGet.Zones[0] "3"
}

<#
.SYNOPSIS
Tests removing a resource.
.DESCRIPTION
SmokeTest
#>
function Test-RemoveAResource
{
    # Setup
    $rgname = Get-ResourceGroupName
    $rname = "testname"
    $rglocation = Get-Location "Microsoft.Resources" "resourceGroups" "West US"
    $apiversion = "2014-04-01"
    $resourceType = "Providers.Test/statefulResources"

    # Test
    New-AzureRmResourceGroup -Name $rgname -Location $rglocation
    $job = New-AzureRmResource -Name $rname -Location $rglocation -Tags @{testtag = "testval"} -ResourceGroupName $rgname -ResourceType $resourceType -PropertyObject @{"key" = "value"} -SkuObject @{ Name = "A0" } -ApiVersion $apiversion -Force -AsJob
    $job | Wait-Job
    $actual = $job | Receive-Job
    # Intermittently, Find-AzureRmResource does not immediately get the resource
    Wait-Seconds 2
    $expected = Get-AzureRmResource -ResourceName $rname -ResourceGroupName $rgname
    Assert-NotNull $expected
    Assert-AreEqual $actual.ResourceId $expected[0].ResourceId

    $job = Remove-AzureRmResource -ResourceId $expected[0].ResourceId -Force -AsJob
    $job | Wait-Job

    $expected = Get-AzureRmResource -ResourceName $rname -ResourceGroupName $rgname
    Assert-Null $expected
}

<#
.SYNOPSIS
Tests removing a set of resources.
#>
function Test-RemoveASetOfResources
{
    # Setup
    $rgname = Get-ResourceGroupName
    $rname = "testname"
    $rname2 = "test2name"
    $rglocation = Get-Location "Microsoft.Resources" "resourceGroups" "West US"
    $apiversion = "2014-04-01"
    $resourceType = "Providers.Test/statefulResources"

    # Test
    New-AzureRmResourceGroup -Name $rgname -Location $rglocation
    $actual = New-AzureRmResource -Name $rname -Location $rglocation -Tags @{testtag = "testval"} -ResourceGroupName $rgname -ResourceType $resourceType -PropertyObject @{"key" = "value"} -SkuObject @{ Name = "A0" } -ApiVersion $apiversion -Force
    $expected = Get-AzureRmResource -ResourceName "*test*" -ResourceGroupName "*$rgname*"
    Assert-NotNull $expected
    Assert-AreEqual $actual.ResourceId $expected[0].ResourceId

    $expected = Get-AzureRmResource -ResourceType $resourceType -ResourceGroupName "*$rgName*"
    Assert-NotNull $expected
    Assert-AreEqual $actual.ResourceId $expected[0].ResourceId

    New-AzureRmResource -Name $rname2 -Location $rglocation -Tags @{testtag = "testval"} -ResourceGroupName $rgname -ResourceType $resourceType -PropertyObject @{"key" = "value"} -SkuObject @{ Name = "A0" } -ApiVersion $apiversion -Force
    $expected = Get-AzureRmResource -ResourceName "*test*" -ResourceGroupName "*$rgname*"
    Assert-AreEqual 2 @($expected).Count

    Get-AzureRmResource -ResourceName "*test*" -ResourceGroupName "*$rgname*" | Remove-AzureRmResource -Force
    $expected = Get-AzureRmResource -ResourceName "*test*" -ResourceGroupName "*$rgname*"
    Assert-Null $expected
}