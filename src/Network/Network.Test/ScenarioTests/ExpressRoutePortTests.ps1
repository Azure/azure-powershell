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
Test creating new ExpressRoutePort
#>
function Test-ExpressRoutePortCRUD
{
    # Setup
    $rgname = Get-ResourceGroupName
    $rglocation = Get-ProviderLocation ResourceManagement
    $rname = Get-ResourceName
	$resourceTypeParent = "Microsoft.Network/expressRoutePorts"
    $location = Get-ProviderLocation $resourceTypeParent
	$peeringLocation = "Cheyenne-ERDirect"
	$encapsulation = "QinQ"
	$bandwidthInGbps = 100.0

    try
    {
        $resourceGroup = New-AzResourceGroup -Name $rgname -Location $rglocation

        # Create ExpressRoutePort
        $vExpressRoutePort = New-AzExpressRoutePort -ResourceGroupName $rgname -Name $rname -Location $location -PeeringLocation $peeringLocation -Encapsulation $encapsulation -BandwidthInGbps $bandwidthInGbps
        Assert-NotNull $vExpressRoutePort
        Assert-True { Check-CmdletReturnType "New-AzExpressRoutePort" $vExpressRoutePort }
        Assert-NotNull $vExpressRoutePort.Links
        Assert-True { $vExpressRoutePort.Links.Count -eq 2 }
        Assert-AreEqual $rname $vExpressRoutePort.Name

        # Get ExpressRoutePort
        $vExpressRoutePort = Get-AzExpressRoutePort -ResourceGroupName $rgname -Name $rname
        Assert-NotNull $vExpressRoutePort
        Assert-True { Check-CmdletReturnType "Get-AzExpressRoutePort" $vExpressRoutePort }
        Assert-AreEqual $rname $vExpressRoutePort.Name

        $vExpressRoutePort = Get-AzExpressRoutePort -ResourceGroupName "*"
        Assert-NotNull $vExpressRoutePort
        Assert-True {$vExpressRoutePort.Count -ge 0}

        $vExpressRoutePort = Get-AzExpressRoutePort -Name "*"
        Assert-NotNull $vExpressRoutePort
        Assert-True {$vExpressRoutePort.Count -ge 0}

        $vExpressRoutePort = Get-AzExpressRoutePort -ResourceGroupName "*" -Name "*"
        Assert-NotNull $vExpressRoutePort
        Assert-True {$vExpressRoutePort.Count -ge 0}

        # Get ExpressRoutePort
        $vExpressRoutePort = Get-AzureRmExpressRoutePort -ResourceId $vExpressRoutePort.Id
        Assert-NotNull $vExpressRoutePort
        Assert-True { Check-CmdletReturnType "Get-AzureRmExpressRoutePort" $vExpressRoutePort }
        Assert-AreEqual $rname $vExpressRoutePort.Name

        $vExpressRoutePorts = Get-AzureRmExpressRoutePort -ResourceGroupName $rgname
        Assert-NotNull $vExpressRoutePorts

        $vExpressRoutePortsAll = Get-AzureRmExpressRoutePort
        Assert-NotNull $vExpressRoutePortsAll

		# Update ExpressRoutePort
		$vExpressRoutePort.Links[0].AdminState = "Enabled"
		Set-AzExpressRoutePort -ExpressRoutePort $vExpressRoutePort

		# Get ExpressRouteLink
		$vExpressRouteLink = $vExpressRoutePort | Get-AzExpressRoutePortLinkConfig -Name "Link1"
		Assert-NotNull $vExpressRouteLink;
		Assert-AreEqual $vExpressRouteLink.AdminState "Enabled"

		# List ExpressRouteLinks
		$vExpressRouteLinksList = $vExpressRoutePort | Get-AzExpressRoutePortLinkConfig
		Assert-True { $vExpressRouteLinksList.Count -eq 2 }

        # Remove ExpressRoutePort
        $removeExpressRoutePort = Remove-AzExpressRoutePort -ResourceGroupName $rgname -Name $rname -PassThru -Force
        Assert-AreEqual $true $removeExpressRoutePort
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}
