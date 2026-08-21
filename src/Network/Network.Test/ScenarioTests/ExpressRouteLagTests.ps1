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
    $peeringLocation = "Azure"
    $encapsulation = "QinQ"
    $bandwidthInGbps = 10
    $numberOfPorts = 2
    $lacpTimer = "fast"
    $minimumActivePortsRequired = 2

    try
    {
        $resourceGroup = New-AzResourceGroup -Name $rgname -Location $rglocation

        # Create ExpressRouteLag
        $vExpressRouteLag = New-AzExpressRouteLag -ResourceGroupName $rgname -Name $rname -Location $location -PeeringLocation $peeringLocation -Encapsulation $encapsulation -BandwidthInGbps $bandwidthInGbps -NumberOfPorts $numberOfPorts -MinimumActivePortsRequired $minimumActivePortsRequired -LacpTimer $lacpTimer
        Assert-NotNull $vExpressRouteLag
        Assert-True { Check-CmdletReturnType "New-AzExpressRouteLag" $vExpressRouteLag }
        Assert-AreEqual $rname $vExpressRouteLag.Name
        Assert-AreEqual $peeringLocation $vExpressRouteLag.PeeringLocation
        Assert-AreEqual $bandwidthInGbps $vExpressRouteLag.BandwidthInGbps
        Assert-AreEqual $numberOfPorts $vExpressRouteLag.NumberOfPorts
        Assert-AreEqual $minimumActivePortsRequired $vExpressRouteLag.MinimumActivePortsRequired
        Assert-AreEqual $lacpTimer $vExpressRouteLag.LacpTimer

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
        $vExpressRouteLag.NumberOfPorts = 1
        $vExpressRouteLag.MinimumActivePortsRequired = 1
        $vExpressRouteLag.LacpTimer = "slow"
        $vExpressRouteLag = Set-AzExpressRouteLag -ExpressRouteLag $vExpressRouteLag
        Assert-NotNull $vExpressRouteLag
        Assert-True { Check-CmdletReturnType "Set-AzExpressRouteLag" $vExpressRouteLag }
        Assert-AreEqual 1 $vExpressRouteLag.NumberOfPorts
        Assert-AreEqual 1 $vExpressRouteLag.MinimumActivePortsRequired
        Assert-AreEqual "slow" $vExpressRouteLag.LacpTimer

        # Refresh the ExpressRouteLag
        $vExpressRouteLag = Get-AzExpressRouteLag -ResourceId $vExpressRouteLag.Id
        Assert-NotNull $vExpressRouteLag

        # Update minimumActivePortsRequired (min links) and numberOfPorts back to 2
        $vExpressRouteLag.NumberOfPorts = 2
        $vExpressRouteLag.MinimumActivePortsRequired = 2
        $vExpressRouteLag = Set-AzExpressRouteLag -ExpressRouteLag $vExpressRouteLag
        Assert-NotNull $vExpressRouteLag
        Assert-AreEqual 2 $vExpressRouteLag.NumberOfPorts
        Assert-AreEqual 2 $vExpressRouteLag.MinimumActivePortsRequired

        # Refresh the ExpressRouteLag
        $vExpressRouteLag = Get-AzExpressRouteLag -ResourceId $vExpressRouteLag.Id
        Assert-NotNull $vExpressRouteLag

        # Update tags
        $vExpressRouteLag.Tag = @{ environment = "test" }
        $vExpressRouteLag = Set-AzExpressRouteLag -ExpressRouteLag $vExpressRouteLag
        Assert-NotNull $vExpressRouteLag

        # Refresh the ExpressRouteLag
        $vExpressRouteLag = Get-AzExpressRouteLag -ResourceId $vExpressRouteLag.Id
        Assert-NotNull $vExpressRouteLag

        # Update link and member AdminState
        Assert-NotNull $vExpressRouteLag.Links
        Assert-True { $vExpressRouteLag.Links.Count -ge 1 }
        $vExpressRouteLag.Links[0].AdminState = "Enabled"
        Assert-NotNull $vExpressRouteLag.Links[0].Members
        Assert-True { $vExpressRouteLag.Links[0].Members.Count -ge 1 }
        $vExpressRouteLag.Links[0].Members[0].AdminState = "Disabled"
        $vExpressRouteLag = Set-AzExpressRouteLag -ExpressRouteLag $vExpressRouteLag
        Assert-NotNull $vExpressRouteLag
        Assert-AreEqual "Enabled" $vExpressRouteLag.Links[0].AdminState
        Assert-AreEqual "Disabled" $vExpressRouteLag.Links[0].Members[0].AdminState
        Assert-AreEqual "Disabled" $vExpressRouteLag.Links[1].AdminState
        Assert-AreEqual "Enabled" $vExpressRouteLag.Links[1].Members[0].AdminState

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
    $peeringLocation = "Azure"
    $encapsulation = "QinQ"
    $bandwidthInGbps = 10
    $numberOfPorts = 2
    $lacpTimer = "slow"
    $minimumActivePortsRequired = 2
    $customerName = "someCustomer"
    # Use a rooted, cross-platform temp path. $env:TEMP and '\' are Windows-only; on Linux/macOS they
    # would produce an unrooted path that the cmdlet and Test-Path resolve differently, failing playback.
    $destination = Join-Path ([System.IO.Path]::GetTempPath()) "ExpressRouteLagLOA.pdf"

    try
    {
        $resourceGroup = New-AzResourceGroup -Name $rgname -Location $rglocation

        # Create ExpressRouteLag
        $vExpressRouteLag = New-AzExpressRouteLag -ResourceGroupName $rgname -Name $rname -Location $location -PeeringLocation $peeringLocation -Encapsulation $encapsulation -BandwidthInGbps $bandwidthInGbps -NumberOfPorts $numberOfPorts -MinimumActivePortsRequired $minimumActivePortsRequired -LacpTimer $lacpTimer
        Assert-NotNull $vExpressRouteLag

        # Collect the distinct member names for which the LOA should be generated.
        # Member names repeat across links (e.g. every link exposes member1/member2),
        # so the LOA request must contain each member name only once.
        $vLinks = Get-AzExpressRouteLagLink -ResourceGroupName $rgname -ExpressRouteLagName $rname
        Assert-NotNull $vLinks
        Assert-True { $vLinks.Count -ge 1 }
        $memberNames = @()
        foreach ($link in $vLinks)
        {
            $linkMembers = Get-AzExpressRouteLagMember -ResourceGroupName $rgname -ExpressRouteLagName $rname -LinkName $link.Name
            foreach ($member in $linkMembers)
            {
                if ($memberNames -notcontains $member.Name)
                {
                    $memberNames += $member.Name
                }
            }
        }
        Assert-True { $memberNames.Count -ge 1 }

        # Generate LOA
        New-AzExpressRouteLagLOA -ResourceGroupName $rgname -LagName $rname -CustomerName $customerName -Members $memberNames -Destination $destination
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

<#
.SYNOPSIS
Test assigning, getting, and removing a user-assigned identity on an ExpressRouteLag.
#>
function Test-ExpressRouteLagIdentity
{
    # Setup
    $rgname = Get-ResourceGroupName
    $rglocation = Get-ProviderLocation ResourceManagement
    $rname = Get-ResourceName
    $resourceTypeParent = "Microsoft.Network/expressRouteLags"
    $location = Get-ProviderLocation $resourceTypeParent
    $peeringLocation = "Azure"
    $encapsulation = "QinQ"
    $bandwidthInGbps = 10
    $numberOfPorts = 2
    $lacpTimer = "fast"
    $minimumActivePortsRequired = 2

    # Pre-provisioned user-assigned identity, referenced by resource id.
    # New-AzUserAssignedIdentity (Az.ManagedServiceIdentity, AutoRest) is NOT routed through the
    # TestFx HTTP mock server, so it cannot be recorded/replayed in playback. Instead we reference a
    # long-lived identity that already exists in the recording subscription (same approach as the
    # AzureFirewallPolicy UAMI tests). Replace with a real UAMI id before (re)recording.
    $userAssignedIdentityId = "/subscriptions/7d747eed-b44c-4257-8d43-df9ebd94546b/resourceGroups/ExpressRouteLagTestIdentities/providers/Microsoft.ManagedIdentity/userAssignedIdentities/expressRouteLagTestIdentity"

    try
    {
        $resourceGroup = New-AzResourceGroup -Name $rgname -Location $rglocation

        # Create ExpressRouteLag
        $vExpressRouteLag = New-AzExpressRouteLag -ResourceGroupName $rgname -Name $rname -Location $location -PeeringLocation $peeringLocation -Encapsulation $encapsulation -BandwidthInGbps $bandwidthInGbps -NumberOfPorts $numberOfPorts -MinimumActivePortsRequired $minimumActivePortsRequired -LacpTimer $lacpTimer
        Assert-NotNull $vExpressRouteLag

        # New-AzExpressRouteLagIdentity builds a local identity object
        $expressRouteLagIdentity = New-AzExpressRouteLagIdentity -UserAssignedIdentityId $userAssignedIdentityId
        Assert-NotNull $expressRouteLagIdentity
        Assert-True { Check-CmdletReturnType "New-AzExpressRouteLagIdentity" $expressRouteLagIdentity }
        Assert-AreEqual "UserAssigned" $expressRouteLagIdentity.Type.ToString()

        # Set-AzExpressRouteLagIdentity assigns the identity on the local object
        $vExpressRouteLag = Set-AzExpressRouteLagIdentity -ExpressRouteLag $vExpressRouteLag -UserAssignedIdentityId $userAssignedIdentityId
        Assert-NotNull $vExpressRouteLag
        Assert-True { Check-CmdletReturnType "Set-AzExpressRouteLagIdentity" $vExpressRouteLag }
        Assert-NotNull $vExpressRouteLag.Identity

        # Persist the identity assignment
        $vExpressRouteLag = Set-AzExpressRouteLag -ExpressRouteLag $vExpressRouteLag
        Assert-NotNull $vExpressRouteLag
        Assert-NotNull $vExpressRouteLag.Identity

        # Get-AzExpressRouteLagIdentity returns the assigned identity
        $vExpressRouteLag = Get-AzExpressRouteLag -ResourceId $vExpressRouteLag.Id
        $vIdentity = Get-AzExpressRouteLagIdentity -ExpressRouteLag $vExpressRouteLag
        Assert-NotNull $vIdentity
        Assert-True { Check-CmdletReturnType "Get-AzExpressRouteLagIdentity" $vIdentity }
        Assert-AreEqual "UserAssigned" $vIdentity.Type.ToString()

        # Remove-AzExpressRouteLagIdentity removes the identity from the local object
        $vExpressRouteLag = Remove-AzExpressRouteLagIdentity -ExpressRouteLag $vExpressRouteLag
        Assert-NotNull $vExpressRouteLag
        Assert-True { Check-CmdletReturnType "Remove-AzExpressRouteLagIdentity" $vExpressRouteLag }
        Assert-Null $vExpressRouteLag.Identity

        # Persist the identity removal
        $vExpressRouteLag = Set-AzExpressRouteLag -ExpressRouteLag $vExpressRouteLag
        Assert-NotNull $vExpressRouteLag

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
