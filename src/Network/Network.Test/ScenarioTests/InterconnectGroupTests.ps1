# ----------------------------------------------------------------------------------
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
Test InterconnectGroup create, read, update and delete operations
#>
function Test-InterconnectGroupCRUD
{
    $rgLocation = Get-ProviderLocation ResourceManagement "eastus2euap"
    $resourceTypeParent = "Microsoft.Network/interconnectGroups"
    $location = Get-ProviderLocation $resourceTypeParent "eastus2euap"

    $rgName = Get-ResourceGroupName
    $interconnectGroupName = Get-ResourceName
    $vmSize = "Standard_ND128isr_GB300_v6"

    try
    {
        New-AzResourceGroup -Name $rgName -Location $rgLocation

        $interconnectGroupNew = New-AzInterconnectGroup -ResourceGroupName $rgName -Name $interconnectGroupName `
            -Location $location -VMSize $vmSize

        Assert-AreEqual $rgName $interconnectGroupNew.ResourceGroupName
        Assert-AreEqual $interconnectGroupName $interconnectGroupNew.Name
        Assert-NotNull $interconnectGroupNew.Location
        Assert-NotNull $interconnectGroupNew.Etag
        Assert-AreEqual "Succeeded" $interconnectGroupNew.ProvisioningState
        Assert-NotNull $interconnectGroupNew.SubgroupProfile
        Assert-AreEqual $vmSize $interconnectGroupNew.SubgroupProfile.VMSize

        $interconnectGroupGet = Get-AzInterconnectGroup -ResourceGroupName $rgName -Name $interconnectGroupName
        Assert-AreEqual $rgName $interconnectGroupGet.ResourceGroupName
        Assert-AreEqual $interconnectGroupName $interconnectGroupGet.Name
        Assert-AreEqual $interconnectGroupNew.Etag $interconnectGroupGet.Etag
        Assert-AreEqual $vmSize $interconnectGroupGet.SubgroupProfile.VMSize

        $list = Get-AzInterconnectGroup -ResourceGroupName $rgName
        Assert-AreEqual 1 @($list).Count
        Assert-AreEqual $interconnectGroupName $list[0].Name

        $delete = Remove-AzInterconnectGroup -ResourceGroupName $rgName -Name $interconnectGroupName -PassThru -Force
        Assert-AreEqual $true $delete

        $list = Get-AzInterconnectGroup -ResourceGroupName $rgName
        Assert-AreEqual 0 @($list).Count
    }
    finally
    {
        Clean-ResourceGroup $rgName
    }
}

<#
.SYNOPSIS
Test InterconnectGroup CRUD with tags
#>
function Test-InterconnectGroupCRUDWithTags
{
    $rgLocation = Get-ProviderLocation ResourceManagement "eastus2euap"
    $resourceTypeParent = "Microsoft.Network/interconnectGroups"
    $location = Get-ProviderLocation $resourceTypeParent "eastus2euap"

    $rgName = Get-ResourceGroupName
    $interconnectGroupName = Get-ResourceName
    $vmSize = "Standard_ND128isr_GB300_v6"

    try
    {
        New-AzResourceGroup -Name $rgName -Location $rgLocation

        $interconnectGroupNew = New-AzInterconnectGroup -ResourceGroupName $rgName -Name $interconnectGroupName `
            -Location $location -VMSize $vmSize -Tag @{ testtag = "interconnectGroup tag"; environment = "test" }

        Assert-NotNull $interconnectGroupNew.Tag
        Assert-AreEqual "interconnectGroup tag" $interconnectGroupNew.Tag["testtag"]
        Assert-AreEqual "test" $interconnectGroupNew.Tag["environment"]

        $interconnectGroupGet = Get-AzInterconnectGroup -ResourceGroupName $rgName -Name $interconnectGroupName
        Assert-NotNull $interconnectGroupGet.Tag
        Assert-AreEqual "interconnectGroup tag" $interconnectGroupGet.Tag["testtag"]

        Remove-AzInterconnectGroup -ResourceGroupName $rgName -Name $interconnectGroupName -Force
    }
    finally
    {
        Clean-ResourceGroup $rgName
    }
}

<#
.SYNOPSIS
Test InterconnectGroup creation with a fully specified subgroup profile and scope
#>
function Test-InterconnectGroupCRUDWithSubgroupProfile
{
    $rgLocation = Get-ProviderLocation ResourceManagement "eastus2euap"
    $resourceTypeParent = "Microsoft.Network/interconnectGroups"
    $location = Get-ProviderLocation $resourceTypeParent "eastus2euap"

    $rgName = Get-ResourceGroupName
    $interconnectGroupName = Get-ResourceName
    $vmSize = "Standard_ND128isr_GB300_v6"

    try
    {
        New-AzResourceGroup -Name $rgName -Location $rgLocation

        $interconnectGroupNew = New-AzInterconnectGroup -ResourceGroupName $rgName -Name $interconnectGroupName `
            -Location $location -VMSize $vmSize -Scope "InfiniBand" -SubgroupScope "VerticalConnect" -SubgroupSize 18

        Assert-AreEqual "InfiniBand" $interconnectGroupNew.Scope
        Assert-NotNull $interconnectGroupNew.SubgroupProfile
        Assert-AreEqual $vmSize $interconnectGroupNew.SubgroupProfile.VMSize
        Assert-AreEqual "VerticalConnect" $interconnectGroupNew.SubgroupProfile.Scope
        Assert-AreEqual 18 $interconnectGroupNew.SubgroupProfile.Size

        $interconnectGroupGet = Get-AzInterconnectGroup -ResourceGroupName $rgName -Name $interconnectGroupName
        Assert-AreEqual "InfiniBand" $interconnectGroupGet.Scope
        Assert-AreEqual "VerticalConnect" $interconnectGroupGet.SubgroupProfile.Scope
        Assert-AreEqual 18 $interconnectGroupGet.SubgroupProfile.Size

        Remove-AzInterconnectGroup -ResourceGroupName $rgName -Name $interconnectGroupName -Force
    }
    finally
    {
        Clean-ResourceGroup $rgName
    }
}

<#
.SYNOPSIS
Test getting and removing an InterconnectGroup by resource id
#>
function Test-InterconnectGroupGetByResourceId
{
    $rgLocation = Get-ProviderLocation ResourceManagement "eastus2euap"
    $resourceTypeParent = "Microsoft.Network/interconnectGroups"
    $location = Get-ProviderLocation $resourceTypeParent "eastus2euap"

    $rgName = Get-ResourceGroupName
    $interconnectGroupName = Get-ResourceName
    $vmSize = "Standard_ND128isr_GB300_v6"

    try
    {
        New-AzResourceGroup -Name $rgName -Location $rgLocation

        $interconnectGroupNew = New-AzInterconnectGroup -ResourceGroupName $rgName -Name $interconnectGroupName `
            -Location $location -VMSize $vmSize

        Assert-NotNull $interconnectGroupNew.Id

        $interconnectGroupGet = Get-AzInterconnectGroup -ResourceId $interconnectGroupNew.Id
        Assert-AreEqual $interconnectGroupName $interconnectGroupGet.Name
        Assert-AreEqual $rgName $interconnectGroupGet.ResourceGroupName

        $delete = Remove-AzInterconnectGroup -ResourceId $interconnectGroupNew.Id -PassThru -Force
        Assert-AreEqual $true $delete
    }
    finally
    {
        Clean-ResourceGroup $rgName
    }
}

<#
.SYNOPSIS
Test listing InterconnectGroups in a resource group and in the subscription
#>
function Test-InterconnectGroupList
{
    $rgLocation = Get-ProviderLocation ResourceManagement "eastus2euap"
    $resourceTypeParent = "Microsoft.Network/interconnectGroups"
    $location = Get-ProviderLocation $resourceTypeParent "eastus2euap"

    $rgName = Get-ResourceGroupName
    $interconnectGroupName1 = Get-ResourceName
    $interconnectGroupName2 = Get-ResourceName
    $vmSize = "Standard_ND128isr_GB300_v6"

    try
    {
        New-AzResourceGroup -Name $rgName -Location $rgLocation

        New-AzInterconnectGroup -ResourceGroupName $rgName -Name $interconnectGroupName1 -Location $location -VMSize $vmSize
        New-AzInterconnectGroup -ResourceGroupName $rgName -Name $interconnectGroupName2 -Location $location -VMSize $vmSize

        $list = Get-AzInterconnectGroup -ResourceGroupName $rgName
        Assert-AreEqual 2 @($list).Count

        $listAll = Get-AzInterconnectGroup
        Assert-True { @($listAll).Count -ge 2 }

        $list = Get-AzInterconnectGroup -ResourceGroupName "*" -Name "*"
        Assert-True { $list.Count -ge 0 }

        $list = Get-AzInterconnectGroup -Name "*"
        Assert-True { $list.Count -ge 0 }

        $list = Get-AzInterconnectGroup -ResourceGroupName "*"
        Assert-True { $list.Count -ge 0 }

        $filtered = Get-AzInterconnectGroup -ResourceGroupName $rgName -Name $interconnectGroupName1
        Assert-AreEqual 1 @($filtered).Count
        Assert-AreEqual $interconnectGroupName1 $filtered[0].Name

        # Wildcard pattern matching only the first group exercises TopLevelWildcardFilter
        $wildcardFiltered = Get-AzInterconnectGroup -ResourceGroupName $rgName -Name "$interconnectGroupName1*"
        Assert-AreEqual 1 @($wildcardFiltered).Count
        Assert-AreEqual $interconnectGroupName1 $wildcardFiltered[0].Name

        Remove-AzInterconnectGroup -ResourceGroupName $rgName -Name $interconnectGroupName1 -Force
        Remove-AzInterconnectGroup -ResourceGroupName $rgName -Name $interconnectGroupName2 -Force
    }
    finally
    {
        Clean-ResourceGroup $rgName
    }
}

<#
.SYNOPSIS
Test updating an InterconnectGroup with Set-AzInterconnectGroup
#>
function Test-InterconnectGroupSet
{
    $rgLocation = Get-ProviderLocation ResourceManagement "eastus2euap"
    $resourceTypeParent = "Microsoft.Network/interconnectGroups"
    $location = Get-ProviderLocation $resourceTypeParent "eastus2euap"

    $rgName = Get-ResourceGroupName
    $interconnectGroupName = Get-ResourceName
    $vmSize = "Standard_ND128isr_GB300_v6"

    try
    {
        New-AzResourceGroup -Name $rgName -Location $rgLocation

        $interconnectGroupNew = New-AzInterconnectGroup -ResourceGroupName $rgName -Name $interconnectGroupName `
            -Location $location -VMSize $vmSize -Tag @{ stage = "initial" }

        $interconnectGroupNew.Tag["stage"] = "updated"
        $interconnectGroupSet = Set-AzInterconnectGroup -InterconnectGroup $interconnectGroupNew

        Assert-AreEqual $interconnectGroupName $interconnectGroupSet.Name
        Assert-AreEqual "updated" $interconnectGroupSet.Tag["stage"]

        $interconnectGroupGet = Get-AzInterconnectGroup -ResourceGroupName $rgName -Name $interconnectGroupName
        Assert-AreEqual "updated" $interconnectGroupGet.Tag["stage"]

        $interconnectGroupGet.Tag["stage"] = "piped"
        $piped = $interconnectGroupGet | Set-AzInterconnectGroup
        Assert-AreEqual "piped" $piped.Tag["stage"]

        Remove-AzInterconnectGroup -ResourceGroupName $rgName -Name $interconnectGroupName -Force
    }
    finally
    {
        Clean-ResourceGroup $rgName
    }
}

<#
.SYNOPSIS
Test removing an InterconnectGroup through the pipeline
#>
function Test-InterconnectGroupRemoveByPipeline
{
    $rgLocation = Get-ProviderLocation ResourceManagement "eastus2euap"
    $resourceTypeParent = "Microsoft.Network/interconnectGroups"
    $location = Get-ProviderLocation $resourceTypeParent "eastus2euap"

    $rgName = Get-ResourceGroupName
    $interconnectGroupName = Get-ResourceName
    $vmSize = "Standard_ND128isr_GB300_v6"

    try
    {
        New-AzResourceGroup -Name $rgName -Location $rgLocation

        New-AzInterconnectGroup -ResourceGroupName $rgName -Name $interconnectGroupName -Location $location -VMSize $vmSize

        $delete = Get-AzInterconnectGroup -ResourceGroupName $rgName -Name $interconnectGroupName | `
            Remove-AzInterconnectGroup -PassThru -Force
        Assert-AreEqual $true $delete

        Assert-ThrowsContains { Get-AzInterconnectGroup -ResourceGroupName $rgName -Name $interconnectGroupName } "not found"
    }
    finally
    {
        Clean-ResourceGroup $rgName
    }
}

<#
.SYNOPSIS
Test listing and getting subgroups of an InterconnectGroup
#>
function Test-InterconnectGroupSubgroupGet
{
    $rgLocation = Get-ProviderLocation ResourceManagement "eastus2euap"
    $resourceTypeParent = "Microsoft.Network/interconnectGroups"
    $location = Get-ProviderLocation $resourceTypeParent "eastus2euap"

    $rgName = Get-ResourceGroupName
    $interconnectGroupName = Get-ResourceName
    $vmSize = "Standard_ND128isr_GB300_v6"

    try
    {
        New-AzResourceGroup -Name $rgName -Location $rgLocation

        New-AzInterconnectGroup -ResourceGroupName $rgName -Name $interconnectGroupName `
            -Location $location -VMSize $vmSize -SubgroupScope "VerticalConnect" -SubgroupSize 18

        $subgroups = @(Get-AzInterconnectGroupSubgroup -ResourceGroupName $rgName -InterconnectGroupName $interconnectGroupName)
        Assert-NotNull $subgroups

        # Wildcard name exercises SubResourceWildcardFilter regardless of subgroup count
        $wildcardSubgroups = @(Get-AzInterconnectGroupSubgroup -ResourceGroupName $rgName -InterconnectGroupName $interconnectGroupName -Name "*")
        Assert-AreEqual $subgroups.Count $wildcardSubgroups.Count

        if ($subgroups.Count -gt 0)
        {
            $subgroupName = $subgroups[0].Name
            $subgroupGet = Get-AzInterconnectGroupSubgroup -ResourceGroupName $rgName `
                -InterconnectGroupName $interconnectGroupName -Name $subgroupName
            Assert-AreEqual $subgroupName $subgroupGet.Name
            Assert-NotNull $subgroupGet.Id

            $subgroupById = Get-AzInterconnectGroupSubgroup -ResourceId $subgroupGet.Id
            Assert-AreEqual $subgroupName $subgroupById.Name
        }

        Remove-AzInterconnectGroup -ResourceGroupName $rgName -Name $interconnectGroupName -Force
    }
    finally
    {
        Clean-ResourceGroup $rgName
    }
}

<#
.SYNOPSIS
Test retrieving node availability for an InterconnectGroup
#>
function Test-InterconnectGroupNodeAvailability
{
    $rgLocation = Get-ProviderLocation ResourceManagement "eastus2euap"
    $resourceTypeParent = "Microsoft.Network/interconnectGroups"
    $location = Get-ProviderLocation $resourceTypeParent "eastus2euap"

    $rgName = Get-ResourceGroupName
    $interconnectGroupName = Get-ResourceName
    $vmSize = "Standard_ND128isr_GB300_v6"

    try
    {
        New-AzResourceGroup -Name $rgName -Location $rgLocation

        $interconnectGroupNew = New-AzInterconnectGroup -ResourceGroupName $rgName -Name $interconnectGroupName `
            -Location $location -VMSize $vmSize

        $availability = Get-AzInterconnectGroupNodeAvailability -ResourceGroupName $rgName -Name $interconnectGroupName
        Assert-NotNull $availability

        $availabilityById = Get-AzInterconnectGroupNodeAvailability -ResourceId $interconnectGroupNew.Id
        Assert-NotNull $availabilityById

        $availabilityPiped = $interconnectGroupNew | Get-AzInterconnectGroupNodeAvailability
        Assert-NotNull $availabilityPiped

        Remove-AzInterconnectGroup -ResourceGroupName $rgName -Name $interconnectGroupName -Force
    }
    finally
    {
        Clean-ResourceGroup $rgName
    }
}
