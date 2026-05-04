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
        $password = "*****";
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

<#
.SYNOPSIS
Testing Instant Access for RestorePoints commands
#>
function Test-RestorePointsInstantAccess
{
    # Setup
    $rgname = Get-ComputeTestResourceName;
    $restorePointCollectionName = 'rpc-ia-123' ;
    $restorePointName = 'rp-ia-123' ;
    $vmname = 'vm-ia-123'
    $ddDiskName = 'dd-disk-ia-123'

    try
    {
        # InstantAccess requires eastus2euap (canary region) and API 2025-04-01
        $loc = "eastus2euap";
        New-AzResourceGroup -Name $rgname -Location $loc -Force;

        #create a new vm in zone 2 (required for PremiumV2_LRS disk attachment)
        $user = "Foo12";
        $securePassword = ConvertTo-SecureString ("P@ss!" + [System.Guid]::NewGuid().ToString("N") + "a1") -AsPlainText -Force;
        $cred = New-Object System.Management.Automation.PSCredential ($user, $securePassword);
        [string]$domainNameLabel = "$vmname-$vmname".tolower();
        New-AzVM -ResourceGroupName $rgname -Name $vmname -Image Win2019Datacenter -Location $loc -Credential $cred -DomainNameLabel $domainNameLabel -Zone 2

        $vm1 = Get-AzVM -Name $vmname -ResourceGroupName $rgname -DisplayHint Expand;

        # Attach a Premium SSD v2 (Direct Drive) data disk — required for Instant Access on app-consistent restore points
        # PremiumV2_LRS requires an availability zone
        $ddDiskConfig = New-AzDiskConfig -Location $loc -SkuName 'PremiumV2_LRS' -DiskSizeGB 32 `
            -CreateOption Empty -DiskIOPSReadWrite 3000 -DiskMBpsReadWrite 125 -Zone '2'
        $ddDisk = New-AzDisk -ResourceGroupName $rgname -DiskName $ddDiskName -Disk $ddDiskConfig
        $vm1 = Add-AzVMDataDisk -VM $vm1 -Name $ddDiskName -ManagedDiskId $ddDisk.Id -Lun 0 -CreateOption Attach
        Update-AzVM -ResourceGroupName $rgname -VM $vm1

        # Refresh VM reference after disk attachment
        $vm1 = Get-AzVM -Name $vmname -ResourceGroupName $rgname -DisplayHint Expand;

        # Create restore point collection with InstantAccess enabled
        $collection = New-AzRestorePointCollection -ResourceGroupName $rgname -Name $restorePointCollectionName -VmId $vm1.Id -Location $loc -InstantAccess $true
        Assert-NotNull $collection
        Assert-AreEqual $true $collection.InstantAccess

        # Get collection and verify InstantAccess property
        $getCollection = Get-AzRestorePointCollection -ResourceGroupName $rgname -Name $restorePointCollectionName
        Assert-NotNull $getCollection
        Assert-AreEqual $true $getCollection.InstantAccess

        # Create restore point with InstantAccessDurationInMinutes
        $restorePoint = New-AzRestorePoint -ResourceGroupName $rgname -RestorePointCollectionName $restorePointCollectionName -Name $restorePointName -InstantAccessDurationInMinutes 120
        Assert-NotNull $restorePoint

        # Get restore point and verify InstantAccessDurationInMinutes
        $getRestorePoint = Get-AzRestorePoint -ResourceGroupName $rgname -RestorePointCollectionName $restorePointCollectionName -Name $restorePointName
        Assert-NotNull $getRestorePoint
        Assert-AreEqual 120 $getRestorePoint.InstantAccessDurationInMinutes

        # Verify snapshotAccessState is AvailableWithInstantAccess via instance view expansion
        $rpWithView = Get-AzRestorePoint -ResourceGroupName $rgname -RestorePointCollectionName $restorePointCollectionName -Name $restorePointName -InstanceView
        Assert-NotNull $rpWithView.InstanceView
        $diskRestorePoints = $rpWithView.InstanceView.DiskRestorePoints
        Assert-NotNull $diskRestorePoints
        Assert-True { $diskRestorePoints.Count -gt 0 }
        # All disk restore points should be in an Instant Access state (InstantAccess = fast restore enabled,
        # AvailableWithInstantAccess = also fully replicated for copy/download). Both confirm IA is working.
        foreach ($drp in $diskRestorePoints) {
            Assert-True { $drp.SnapshotAccessState -eq "AvailableWithInstantAccess" -or $drp.SnapshotAccessState -eq "InstantAccess" }
        }

        # Update collection to disable InstantAccess
        $updatedCollection = Update-AzRestorePointCollection -ResourceGroupName $rgname -Name $restorePointCollectionName -InstantAccess $false
        Assert-NotNull $updatedCollection
        Assert-AreEqual $false $updatedCollection.InstantAccess

        # Cleanup restore point and collection
        Remove-AzRestorePoint -ResourceGroupName $rgname -RestorePointCollectionName $restorePointCollectionName -Name $restorePointName
        Remove-AzRestorePointCollection -ResourceGroupName $rgname -Name $restorePointCollectionName
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}
