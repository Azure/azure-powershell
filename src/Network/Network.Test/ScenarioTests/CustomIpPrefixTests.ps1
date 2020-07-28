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
Tests CRUD operations on a simple customIpPrefix.
#>
function Test-CustomIpPrefixCRUD
{
    # Setup
    $rgname = "powershell-test-rg"
    $rname = "testCip"

    # currently in private preview, updated binaries are on test slice in canary only
    $location = "eastus2euap"

    try
    {
        # Create the resource group
        $resourceGroup = New-AzResourceGroup -Name $rgname -Location $rglocation -Tags @{ testtag = "testval" }

        # Create the masterCustomIpPrefix
        $job = New-AzMasterCustomIpPrefix -Name $rname -ResourceGroupName $rgname -Cidr "40.40.40.0/22" -ValidationMessage "123" -SignedValidationMessage "456" -Location $location -AsJob
        $job | Wait-Job
        $mcip = $job | Receive-Job

        # Create customIpPrefix
        $job = New-AzCustomIpPrefix -Name $rname -ResourceGroupName $rgname -location $location -Cidr "40.40.40.0/24" -MasterCustomIpPrefix $mcip -AsJob
        $job | Wait-Job
        $actual = $job | Receive-Job
        $expected = Get-AzCustomIpPrefix -ResourceGroupName $rgname -name $rname
        Assert-AreEqual $expected.ResourceGroupName $actual.ResourceGroupName
        Assert-AreEqual $expected.Name $actual.Name
        Assert-AreEqual $expected.Location $actual.Location
        Assert-AreEqual $expected.Cidr $actual.Cidr
        Assert-AreEqual 0 $expected.PublicIpPrefixes.Count
        Assert-NotNull $expected.ResourceGuid
        Assert-AreEqual "Succeeded" $expected.ProvisioningState

        # list
        $list = Get-AzCustomIpPrefix -ResourceGroupName $rgname
        Assert-AreEqual 1 @($list).Count
        Assert-AreEqual $list[0].ResourceGroupName $actual.ResourceGroupName
        Assert-AreEqual $list[0].Name $actual.Name
        Assert-AreEqual $list[0].Location $actual.Location
        Assert-AreEqual $list[0].Cidr $actual.Cidr
        Assert-AreEqual $list[0].PublicIpPrefixes.Count 0
        Assert-AreEqual "Succeeded" $list[0].ProvisioningState

        $list = Get-AzCustomIpPrefix -ResourceId $actual.Id
        Assert-AreEqual 1 @($list).Count
        Assert-AreEqual $list[0].ResourceGroupName $actual.ResourceGroupName
        Assert-AreEqual $list[0].Name $actual.Name
        Assert-AreEqual $list[0].Location $actual.Location
        Assert-AreEqual $list[0].Cidr $actual.Cidr
        Assert-AreEqual $list[0].PublicIpPrefixes.Count 0
        Assert-AreEqual "Succeeded" $list[0].ProvisioningState

        # delete
        $job = Remove-AzCustomIpPrefix -InputObject $actual -PassThru -Force -AsJob
        $job | Wait-Job
        $delete = $job | Receive-Job
        Assert-AreEqual true $delete

        $list = Get-AzPublicIpPrefix -ResourceGroupName $actual.ResourceGroupName
        Assert-AreEqual 0 @($list).Count

        # Try setting unexisting
        Assert-ThrowsLike { Set-AzPublicIpPrefix -PublicIpPrefix $expected } "*not found*"

        # Create one more time to test deletion with another parameter set
        $job = New-AzPublicIpPrefix -ResourceGroupName $rgname -name $rname -location $location -Sku Standard -PrefixLength 30 -AsJob
        $job | Wait-Job
        $actual = $job | Receive-Job

        $job = Remove-AzPublicIpPrefix -ResourceId $actual.Id -PassThru -Force -AsJob
        $job | Wait-Job
        $delete = $job | Receive-Job
        Assert-AreEqual true $delete
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}