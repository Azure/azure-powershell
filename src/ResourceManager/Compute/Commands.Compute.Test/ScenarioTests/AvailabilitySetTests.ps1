﻿# ----------------------------------------------------------------------------------
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

        $job = New-AzureRmAvailabilitySet -ResourceGroupName $rgname -Name $asetName -Location $loc -PlatformUpdateDomainCount $nonDefaultUD -PlatformFaultDomainCount $nonDefaultFD -Sku 'Classic' -Tag @{"a"="b"} -AsJob;
        $result = $job | Wait-Job;
        Assert-AreEqual "Completed" $result.State;

        for($i = 0; $i -lt 200; $i++)
        {
            $avsetname = $asetName + $i;
            New-AzureRmAvailabilitySet -ResourceGroupName $rgname -Name $avsetname -Location $loc -PlatformUpdateDomainCount $nonDefaultUD -PlatformFaultDomainCount $nonDefaultFD -Sku 'Classic' -Tag @{"a"="b"};
        }

        $asets = Get-AzureRmAvailabilitySet;
        Assert-NotNull $asets;
        Assert-True {$asets.Count -gt 200}

        $asets = Get-AzureRmAvailabilitySet -ResourceGroupName $rgname;
        Assert-NotNull $asets;
        Assert-AreEqual $asetName $asets[0].Name;

        $aset = Get-AzureRmAvailabilitySet -ResourceGroupName $rgname -Name $asetName;
        Assert-NotNull $aset;
        Assert-AreEqual $aset.Name $asetName;
        Assert-AreEqual $nonDefaultUD $aset.PlatformUpdateDomainCount;
        Assert-AreEqual $nonDefaultFD $aset.PlatformFaultDomainCount;
        Assert-False {$aset.Managed};
        Assert-AreEqual 'Classic' $aset.Sku;
        Assert-AreEqual "b" $aset.Tags["a"];

        $job = $aset | Update-AzureRmAvailabilitySet -Managed -AsJob;
        $result = $job | Wait-Job;
        Assert-AreEqual "Completed" $result.State;
        $aset = Get-AzureRmAvailabilitySet -ResourceGroupName $rgname -Name $asetName;

        Assert-NotNull $aset;
        Assert-AreEqual $aset.Name $asetName;
        Assert-AreEqual $nonDefaultUD $aset.PlatformUpdateDomainCount;
        Assert-AreEqual $nonDefaultFD $aset.PlatformFaultDomainCount;
        Assert-AreEqual 'Aligned' $aset.Sku;

        $aset | Update-AzureRmAvailabilitySet -Sku 'Aligned';
        $aset = Get-AzureRmAvailabilitySet -ResourceGroupName $rgname -Name $asetName;

        Assert-NotNull $aset;
        Assert-AreEqual $aset.Name $asetName;
        Assert-AreEqual $nonDefaultUD $aset.PlatformUpdateDomainCount;
        Assert-AreEqual $nonDefaultFD $aset.PlatformFaultDomainCount;
        Assert-AreEqual 'Aligned' $aset.Sku;

        $job = Remove-AzureRmAvailabilitySet -ResourceGroupName $rgname -Name $asetName -Force -AsJob;
        $result = $job | Wait-Job;
        Assert-AreEqual "Completed" $result.State;
        $st = $job | Receive-Job;
        $id = New-Object System.Guid;
        Assert-True { [System.Guid]::TryParse($st.RequestId, [REF] $id) };
        Assert-AreEqual "OK" $st.StatusCode;
        Assert-AreEqual "OK" $st.ReasonPhrase;
        Assert-True { $st.IsSuccessStatusCode };
        
        $asets = Get-AzureRmAvailabilitySet -ResourceGroupName $rgname;
        $avset = $asets | ? {$_.Name -eq $asetName};
        Assert-Null $avset;
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}
