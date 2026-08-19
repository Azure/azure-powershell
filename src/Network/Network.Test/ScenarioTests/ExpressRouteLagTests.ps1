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

function Check-CmdletReturnType
{
    param($cmdletName, $cmdletReturn)

    $cmdletData = Get-Command $cmdletName
    Assert-NotNull $cmdletData
    [array]$cmdletReturnTypes = $cmdletData.OutputType.Name | Foreach-Object { return ($_ -replace "Microsoft.Azure.Commands.Network.Models.","") }
    [array]$cmdletReturnTypes = $cmdletReturnTypes | Foreach-Object { return ($_ -replace "System.","") }
    $realReturnType = $cmdletReturn.GetType().Name -replace "Microsoft.Azure.Commands.Network.Models.",""
    return $cmdletReturnTypes -contains $realReturnType
}

<#
.SYNOPSIS
Test ExpressRouteLag CRUD (Create, Get, Update, Remove).
#>
function Test-ExpressRouteLagCRUD
{
    # Setup
    $rgname = Get-ResourceGroupName
    $rglocation = Get-ProviderLocation ResourceManagement
    $rname = Get-ResourceName
    $resourceTypeParent = "Microsoft.Network/expressRouteLags"
    $location = Get-ProviderLocation $resourceTypeParent
    $peeringLocation = "Cheyenne-ERDirect"
    $encapsulation = "QinQ"
    $bandwidthInGbps = 100

    try
    {
        $resourceGroup = New-AzResourceGroup -Name $rgname -Location $rglocation

        # Create ExpressRouteLag
        $vExpressRouteLag = New-AzExpressRouteLag -ResourceGroupName $rgname -Name $rname -Location $location -PeeringLocation $peeringLocation -Encapsulation $encapsulation -BandwidthInGbps $bandwidthInGbps
        Assert-NotNull $vExpressRouteLag
        Assert-True { Check-CmdletReturnType "New-AzExpressRouteLag" $vExpressRouteLag }
        Assert-AreEqual $rname $vExpressRouteLag.Name
        Assert-AreEqual $peeringLocation $vExpressRouteLag.PeeringLocation
        Assert-AreEqual $bandwidthInGbps $vExpressRouteLag.BandwidthInGbps

        # Get ExpressRouteLag by name
        $vExpressRouteLag = Get-AzExpressRouteLag -ResourceGroupName $rgname -Name $rname
        Assert-NotNull $vExpressRouteLag
        Assert-True { Check-CmdletReturnType "Get-AzExpressRouteLag" $vExpressRouteLag }
        Assert-AreEqual $rname $vExpressRouteLag.Name

        # Get ExpressRouteLag with wildcards
        $vExpressRouteLagAll = Get-AzExpressRouteLag -ResourceGroupName "*"
        Assert-NotNull $vExpressRouteLagAll
        Assert-True { $vExpressRouteLagAll.Count -ge 0 }

        $vExpressRouteLagAll = Get-AzExpressRouteLag -Name "*"
        Assert-NotNull $vExpressRouteLagAll
        Assert-True { $vExpressRouteLagAll.Count -ge 0 }

        # Get ExpressRouteLag by resource id
        $vExpressRouteLag = Get-AzExpressRouteLag -ResourceId $vExpressRouteLag.Id
        Assert-NotNull $vExpressRouteLag
        Assert-AreEqual $rname $vExpressRouteLag.Name

        # List ExpressRouteLags in resource group
        $vExpressRouteLags = Get-AzExpressRouteLag -ResourceGroupName $rgname
        Assert-NotNull $vExpressRouteLags

        # List all ExpressRouteLags
        $vExpressRouteLagsAll = Get-AzExpressRouteLag
        Assert-NotNull $vExpressRouteLagsAll

        # Update ExpressRouteLag
        $vExpressRouteLag.Tag = @{ environment = "test" }
        $vExpressRouteLag = Set-AzExpressRouteLag -ExpressRouteLag $vExpressRouteLag
        Assert-NotNull $vExpressRouteLag
        Assert-True { Check-CmdletReturnType "Set-AzExpressRouteLag" $vExpressRouteLag }

        # Remove ExpressRouteLag
        $removeExpressRouteLag = Remove-AzExpressRouteLag -ResourceGroupName $rgname -Name $rname -PassThru -Force
        Assert-AreEqual $true $removeExpressRouteLag
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Test getting ExpressRouteLag links and members.
#>
function Test-ExpressRouteLagLinkAndMember
{
    # Setup
    $rgname = Get-ResourceGroupName
    $rglocation = Get-ProviderLocation ResourceManagement
    $rname = Get-ResourceName
    $resourceTypeParent = "Microsoft.Network/expressRouteLags"
    $location = Get-ProviderLocation $resourceTypeParent
    $peeringLocation = "Cheyenne-ERDirect"
    $encapsulation = "QinQ"
    $bandwidthInGbps = 100

    try
    {
        $resourceGroup = New-AzResourceGroup -Name $rgname -Location $rglocation

        # Create ExpressRouteLag
        $vExpressRouteLag = New-AzExpressRouteLag -ResourceGroupName $rgname -Name $rname -Location $location -PeeringLocation $peeringLocation -Encapsulation $encapsulation -BandwidthInGbps $bandwidthInGbps
        Assert-NotNull $vExpressRouteLag

        # List links of the ExpressRouteLag
        $vLinks = Get-AzExpressRouteLagLink -ResourceGroupName $rgname -ExpressRouteLagName $rname
        Assert-NotNull $vLinks
        Assert-True { $vLinks.Count -ge 1 }

        $firstLink = $vLinks[0]

        # Get a single link by name
        $vLink = Get-AzExpressRouteLagLink -ResourceGroupName $rgname -ExpressRouteLagName $rname -Name $firstLink.Name
        Assert-NotNull $vLink
        Assert-True { Check-CmdletReturnType "Get-AzExpressRouteLagLink" $vLink }
        Assert-AreEqual $firstLink.Name $vLink.Name

        # List members of the link
        $vMembers = Get-AzExpressRouteLagMember -ResourceGroupName $rgname -ExpressRouteLagName $rname -LinkName $firstLink.Name
        Assert-NotNull $vMembers
        Assert-True { $vMembers.Count -ge 1 }

        # Get a single member by name
        $firstMember = $vMembers[0]
        $vMember = Get-AzExpressRouteLagMember -ResourceGroupName $rgname -ExpressRouteLagName $rname -LinkName $firstLink.Name -Name $firstMember.Name
        Assert-NotNull $vMember
        Assert-True { Check-CmdletReturnType "Get-AzExpressRouteLagMember" $vMember }
        Assert-AreEqual $firstMember.Name $vMember.Name

        # Remove ExpressRouteLag
        $removeExpressRouteLag = Remove-AzExpressRouteLag -ResourceGroupName $rgname -Name $rname -PassThru -Force
        Assert-AreEqual $true $removeExpressRouteLag
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Test generating a Letter of Authorization for an ExpressRouteLag.
#>
function Test-ExpressRouteLagGenerateLOA
{
    # Setup
    $rgname = Get-ResourceGroupName
    $rglocation = Get-ProviderLocation ResourceManagement
    $rname = Get-ResourceName
    $resourceTypeParent = "Microsoft.Network/expressRouteLags"
    $location = Get-ProviderLocation $resourceTypeParent
    $peeringLocation = "Cheyenne-ERDirect"
    $encapsulation = "QinQ"
    $bandwidthInGbps = 100
    $customerName = "someCustomer"
    $destination = "$env:TEMP\ExpressRouteLagLOA.pdf"

    try
    {
        $resourceGroup = New-AzResourceGroup -Name $rgname -Location $rglocation

        # Create ExpressRouteLag
        $vExpressRouteLag = New-AzExpressRouteLag -ResourceGroupName $rgname -Name $rname -Location $location -PeeringLocation $peeringLocation -Encapsulation $encapsulation -BandwidthInGbps $bandwidthInGbps
        Assert-NotNull $vExpressRouteLag

        # Generate LOA
        New-AzExpressRouteLagLOA -ResourceGroupName $rgname -LagName $rname -CustomerName $customerName -Destination $destination
        Assert-True { Test-Path $destination }

        # Remove ExpressRouteLag
        $removeExpressRouteLag = Remove-AzExpressRouteLag -ResourceGroupName $rgname -Name $rname -PassThru -Force
        Assert-AreEqual $true $removeExpressRouteLag
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}
