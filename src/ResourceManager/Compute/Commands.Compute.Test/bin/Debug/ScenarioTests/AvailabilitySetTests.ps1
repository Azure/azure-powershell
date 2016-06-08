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
Test Availability Set
#>
function Test-AvailabilitySet
{
    # Setup
    $rgname = Get-ComputeTestResourceName

    try
    {
        # Common
        $loc = Get-ComputeVMLocation;
        New-AzureRmResourceGroup -Name $rgname -Location $loc -Force;

        $asetName = 'avs' + $rgname;
        $nonDefaultUD = 2;
        $nonDefaultFD = 3;

        New-AzureRmAvailabilitySet -ResourceGroupName $rgname -Name $asetName -Location $loc -PlatformUpdateDomainCount $nonDefaultUD -PlatformFaultDomainCount $nonDefaultFD;

        $asets = Get-AzureRmAvailabilitySet -ResourceGroupName $rgname;
        Assert-NotNull $asets;
        Assert-AreEqual $asetName $asets[0].Name;

        $aset = Get-AzureRmAvailabilitySet -ResourceGroupName $rgname -Name $asetName;
        Assert-NotNull $aset;
        Assert-AreEqual $asetName $aset.Name;
        Assert-AreEqual $aset.PlatformUpdateDomainCount $nonDefaultUD;
        Assert-AreEqual $aset.PlatformFaultDomainCount $nonDefaultFD;

        Remove-AzureRmAvailabilitySet -ResourceGroupName $rgname -Name $asetName -Force;
        
        $asets = Get-AzureRmAvailabilitySet -ResourceGroupName $rgname;
        Assert-AreEqual $asets $null;
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}
