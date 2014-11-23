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
Tests creating new public ip addresses and check
#>
function Test-PublicIPAddress
{
    # Setup
    $rgname = Get-ResourceGroupName

    try
    {
        # Setup
        $location = "East US";
        New-AzureResourceGroup -Name $rgname -Location $location;

        $ipName1 = "publicip1";
        $ipName2 = "publicip2";
        $ipName3 = "staticpublicip1";
        $ipName4 = "staticpublicip2";
        $staticip1 = "100.100.100.100";
        $staticip2 = "200.200.200.200";

        # Test
        New-AzurePublicIPAddress -ResourceGroupName $rgname -Name $ipName1 -AllocationMethod Dynamic -Location $location;
        Wait-Seconds 30;
        $getresult1 = Get-AzurePublicIPAddress -ResourceGroupName $rgname -Name $ipName1;
        New-AzurePublicIPAddress -ResourceGroupName $rgname -Name $ipName2 -Location $location -AllocationMethod Dynamic;
        Wait-Seconds 30;
        $getresult2 = Get-AzurePublicIPAddress -ResourceGroupName $rgname -Name $ipName2;
        New-AzurePublicIPAddress -ResourceGroupName $rgname -Name $ipName3 -AllocationMethod Static -IPAddress $staticip1 -Location $location;
        Wait-Seconds 30;
        $getresult3 = Get-AzurePublicIPAddress -ResourceGroupName $rgname -Name $ipName3;
        New-AzurePublicIPAddress -ResourceGroupName $rgname -Name $ipName4 -Location $location -AllocationMethod Static -IPAddress $staticip2;
        Wait-Seconds 30;
        $getresult4 = Get-AzurePublicIPAddress -ResourceGroupName $rgname -Name $ipName4;

        $getresult5=Get-AzurePublicIPAddress -ResourceGroupName $rgname;
        Remove-AzurePublicIPAddress -ResourceGroupName $rgname -Name $ipName1;
        Wait-Seconds 30;
        $getresult6=Get-AzurePublicIPAddress -ResourceGroupName $rgname;

        Get-AzurePublicIPAddress -ResourceGroupName $rgname | Remove-AzurePublicIPAddress -ResourceGroupName $rgname;
        Wait-Seconds 30;
        $getresult7=Get-AzurePublicIPAddress -ResourceGroupName $rgname

        # Assert
        Assert-AreEqual $ipName1 $getresult1.Name
        Assert-AreEqual "Dynamic" $getresult1.properties.publicIPAllocationMethod

        Assert-AreEqual $ipName2 $getresult2.Name
        Assert-AreEqual "Dynamic" $getresult2.properties.publicIPAllocationMethod
        Assert-AreEqual $location $getresult2.Location

        Assert-AreEqual $ipName3 $getresult3.Name
        Assert-AreEqual "Static" $getresult3.properties.publicIPAllocationMethod
        Assert-AreEqual $staticip1 $getresult3.properties.ipAddress

        Assert-AreEqual $ipName4 $getresult4.Name
        Assert-AreEqual "Static" $getresult4.properties.publicIPAllocationMethod
        Assert-AreEqual $location $getresult4.Location
        Assert-AreEqual $staticip2 $getresult4.properties.ipAddress

        Assert-AreEqual 4 $getresult5.Count
        Assert-AreEqual 3 $getresult6.Count
        Assert-AreEqual 0 $getresult7.Count
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

