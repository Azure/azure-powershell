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

NOTE: This feature is currently in private preview, so updated binaries are on test slice in canary only and is currently un-reacheable via the production manifest.
Testing has been done locally using the brazilus ARM endpoint and a specific subscription that has the necessary flags to run these cmdlets. 
#>
function Test-CustomIpPrefixCRUD
{
    # Setup
    $rgname = "powershell-test-rg"
    $rname = "testCustomIpPrefix"
    $location = "eastus2euap"
    $cidr = "40.40.40.0/24"

    try
    {
        # Create the resource group
        $resourceGroup = New-AzResourceGroup -Name $rgname -Location $rglocation

        # Create customIpPrefix
        $job = New-AzCustomIpPrefix -Name $rname -ResourceGroupName $rgname -location $location -Cidr $cidr -AsJob
        $job | Wait-Job
        $job | Receive-Job

        # get by name and resource group
        $actual = Get-AzCustomIpPrefix -ResourceGroupName $rgname -name $rname
        Assert-AreEqual $actual.ResourceGroupName $rgname
        Assert-AreEqual $actual.Name $rname
        Assert-AreEqual $actual.Location $location
        Assert-AreEqual $actual.Cidr $cidr
        Assert-AreEqual $actual.PublicIpPrefixes.Count 0
        Assert-NotNull  $actual.ResourceGuid
        Assert-AreEqual $actual.ProvisioningState "Succeeded"

        # get by resource id
        $actual = Get-AzCustomIpPrefix -ResourceId $actual.Id
        Assert-AreEqual $actual.ResourceGroupName $rgname
        Assert-AreEqual $actual.Name $rname
        Assert-AreEqual $actual.Location $location
        Assert-AreEqual $actual.Cidr $cidr
        Assert-AreEqual $actual.PublicIpPrefixes.Count 0
        Assert-NotNull  $actual.ResourceGuid
        Assert-AreEqual $actual.ProvisioningState "Succeeded"

        # get by input object
        $actual = Get-AzCustomIpPrefix -InputObject $actual
        Assert-AreEqual $actual.ResourceGroupName $rgname
        Assert-AreEqual $actual.Name $rname
        Assert-AreEqual $actual.Location $location
        Assert-AreEqual $actual.Cidr $cidr
        Assert-AreEqual $actual.PublicIpPrefixes.Count 0
        Assert-NotNull  $actual.ResourceGuid
        Assert-AreEqual $actual.ProvisioningState "Succeeded"

        # list
        $list = Get-AzCustomIpPrefix -ResourceGroupName $rgname
        Assert-AreEqual 1 @($list).Count
        Assert-AreEqual $list[0].ResourceGroupName $actual.ResourceGroupName
        Assert-AreEqual $list[0].Name $actual.Name
        Assert-AreEqual $list[0].Location $actual.Location
        Assert-AreEqual $list[0].Cidr $actual.Cidr
        Assert-AreEqual $list[0].PublicIpPrefixes.Count 0
        Assert-AreEqual $list[0].ProvisioningState "Succeeded"

        # delete
        $job = Remove-AzCustomIpPrefix -InputObject $actual -PassThru -Force -AsJob
        $job | Wait-Job
        $delete = $job | Receive-Job
        Assert-AreEqual true $delete

        $list = Get-AzPublicIpPrefix -ResourceGroupName $rgname
        Assert-AreEqual 0 @($list).Count

        # Try setting unexisting
        Assert-ThrowsLike { Update-AzPublicIpPrefix -PublicIpPrefix $expected } "*not found*"

        # Create one more time to test deletion with resource id parameter set
        $job = New-AzCustomIpPrefix -Name $rname -ResourceGroupName $rgname -location $location -Cidr $cidr -AsJob
        $job | Wait-Job
        $expected = $job | Receive-Job

        $job = Remove-AzPublicIpPrefix -ResourceId $expected.Id -PassThru -Force -AsJob
        $job | Wait-Job
        $delete = $job | Receive-Job
        Assert-AreEqual true $delete

        # Create one more time to test deletion with resource group and name
        $job = New-AzCustomIpPrefix -Name $rname -ResourceGroupName $rgname -location $location -Cidr $cidr -AsJob
        $job | Wait-Job
        $expected = $job | Receive-Job

        $job = Remove-AzPublicIpPrefix -Name $rname -ResourceGroupName $rgname
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