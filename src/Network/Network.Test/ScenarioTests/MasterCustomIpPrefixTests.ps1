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
Tests CRUD operations on a simple masterCustomIpPrefix.
#>
function Test-MasterCustomIpPrefixCRUD
{
    # Setup
    $rgname = "powershell-test-rg"
    $rname = "testMcip"

    # currently in private preview, updated binaries are on test slice in canary only
    $location = "eastus2euap"

    try
    {
        # Create the resource group
        $resourceGroup = New-AzResourceGroup -Name $rgname -Location $location
        
        # Create masterCustomIpPrefix
        $job = New-AzMasterCustomIpPrefix -Name $rname -ResourceGroupName $rgname -Cidr "40.40.40.0/22" -ValidationMessage "123" -SignedValidationMessage "456" -Location $location -AsJob
        $job | Wait-Job
        $actual = $job | Receive-Job
        $expected = Get-AzMasterCustomIpPrefix -ResourceGroupName $rgname -Name $rname
        Assert-AreEqual $expected.ResourceGroupName $actual.ResourceGroupName	
        Assert-AreEqual $expected.Name $actual.Name	
        Assert-AreEqual $expected.Location $actual.Location
        Assert-AreEqual $expected.Cidr $actual.Cidr
        Assert-AreEqual $expected.ValidationMessage $actual.ValidationMessage
        Assert-AreEqual $expected.SignedValidationMessage $actual.SignedValidationMessage
        Assert-AreEqual $expected.ValidationState "Validating"
        Assert-AreEqual 0 $expected.CustomIpPrefixes.Count
        Assert-NotNull $expected.ResourceGuid
        Assert-AreEqual "Succeeded" $expected.ProvisioningState

        # list
        $list = Get-AzMasterCustomIpPrefix -ResourceGroupName $rgname
        Assert-AreEqual 1 @($list).Count
        Assert-AreEqual $list[0].ResourceGroupName $actual.ResourceGroupName  
        Assert-AreEqual $list[0].Name $actual.Name    
        Assert-AreEqual $list[0].Location $actual.Location
        Assert-AreEqual $list[0].Cidr $actual.Cidr
        Assert-AreEqual $list[0].ValidationMessage $actual.ValidationMessage
        Assert-AreEqual $list[0].SignedValidationMessage $actual.SignedValidationMessage
        Assert-AreEqual "Succeeded" $list[0].ProvisioningState
      
        # delete
        $job = Remove-AzMasterCustomIpPrefix -ResourceGroupName $actual.ResourceGroupName -name $rname -PassThru -Force -AsJob
        $job | Wait-Job
        $delete = $job | Receive-Job
        Assert-AreEqual true $delete
      
        $list = Get-AzMasterCustomIpPrefix -ResourceGroupName $actual.ResourceGroupName
        Assert-AreEqual 0 @($list).Count
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}