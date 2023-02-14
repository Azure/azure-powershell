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
Testing RestorePoints commands
#>
function Test-RestorePoints
{
    # Setup
    $rgname = Get-ComputeTestResourceName;
    $restorePointCollectionName = 'rpc123' ;
    $restorePointName = 'rp123' ;
    $vmname = 'vm123' 

    try
    {
        # Common
        $loc = Get-ComputeVMLocation;
        New-AzResourceGroup -Name $rgname -Location $loc -Force;

        #create a new vm
        $user = "Foo12";
        $password = "temppass12345T";
        $securePassword = ConvertTo-SecureString $password -AsPlainText -Force;
        $cred = New-Object System.Management.Automation.PSCredential ($user, $securePassword);
        [string]$domainNameLabel = "$vmname-$vmname".tolower();
        New-Azvm -ResourceGroupName $rgname -Name $vmname -Image Win2012R2Datacenter -Location $loc -Credential $cred -DomainNameLabel $domainNameLabel
        

        $vm1 = Get-AzVM -Name $vmname -ResourceGroupName $rgname -DisplayHint Expand;
        $tags = $tags = @{test1 = "testval1"; test2 = "testval2" };

        #restorepoint
        New-AzRestorePointCollection -ResourceGroupName $rgname -Name $restorePointCollectionName -VmId $vm1.Id -Location "eastus"
        Get-AzRestorePointCollection -ResourceGroupName $rgname -Name $restorePointCollectionName
        Update-AzRestorePointCollection -ResourceGroupName $rgname -Name $restorePointCollectionName -Tag $tags

        #restorepointcollection
        New-AzRestorePoint -ResourceGroupName $rgname -RestorePointCollectionName $restorePointCollectionName -Name $restorePointName
        Get-AzRestorePoint -ResourceGroupName $rgname -RestorePointCollectionName $restorePointCollectionName -Name $restorePointName

        Remove-AzRestorePoint -ResourceGroupName $rgname -RestorePointCollectionName $restorePointCollectionName -Name $restorePointName
        
        Remove-AzRestorePointCollection -ResourceGroupName $rgname -Name $restorePointCollectionName

    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

