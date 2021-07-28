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
Test Storage File Share
.DESCRIPTION
SmokeTest
#>
function Test-StorageFileShare
{
    # Setup
    $rgname = Get-StorageManagementTestResourceName;

    try
    {
        # Test
        $stoname = 'sto' + $rgname;
        $stotype = 'Standard_GRS';
        $loc = Get-ProviderLocation ResourceManagement;
        $kind = 'StorageV2'
		$shareName = "share"+ $rgname

        Write-Verbose "RGName: $rgname | Loc: $loc"
        New-AzResourceGroup -Name $rgname -Location $loc;

        New-AzStorageAccount -ResourceGroupName $rgname -Name $stoname -Location $loc -Type $stotype -Kind $kind 
        $stos = Get-AzStorageAccount -ResourceGroupName $rgname;

		New-AzRmStorageShare -ResourceGroupName $rgname -StorageAccountName $stoname -Name $shareName
		$share = Get-AzRmStorageShare -ResourceGroupName $rgname -StorageAccountName $stoname -Name $shareName
		Assert-AreEqual $rgname $share.ResourceGroupName
		Assert-AreEqual $stoname $share.StorageAccountName
		Assert-AreEqual $shareName $share.Name
		
        $quotaGiB = 100
		$metadata = @{tag0="value0";tag1="value1"} 

		Update-AzRmStorageShare -ResourceGroupName $rgname -StorageAccountName $stoname -Name $shareName -QuotaGiB $quotaGiB -Metadata $metadata
		$share = Get-AzRmStorageShare -ResourceGroupName $rgname -StorageAccountName $stoname -Name $shareName
		Assert-AreEqual $rgname $share.ResourceGroupName
		Assert-AreEqual $stoname $share.StorageAccountName
		Assert-AreEqual $shareName $share.Name
		Assert-AreEqual $quotaGiB $share.QuotaGiB
		Assert-AreEqual $metadata.Count $share.Metadata.Count		
		
        $quotaGiB = 200
		$metadata = @{tag0="value0";tag1="value1";tag2="value2"} 
		$share | Update-AzRmStorageShare -QuotaGiB $quotaGiB -Metadata $metadata
		$share = Get-AzRmStorageShare -ResourceGroupName $rgname -StorageAccountName $stoname -Name $shareName
		Assert-AreEqual $rgname $share.ResourceGroupName
		Assert-AreEqual $stoname $share.StorageAccountName
		Assert-AreEqual $shareName $share.Name
		Assert-AreEqual $quotaGiB $share.QuotaGiB
		Assert-AreEqual $metadata.Count $share.Metadata.Count
		
        $quotaGiB = 300
		$metadata = @{tag0="value0";tag1="value1";tag2="value2";tag3="value3"}
		$shareName2 = "share2"+ $rgname		
		$stos | New-AzRmStorageShare -Name $shareName2 -QuotaGiB $quotaGiB -Metadata $metadata -AccessTier Cool
		$share = $stos | Get-AzRmStorageShare -Name $shareName2
		Assert-AreEqual $rgname $share.ResourceGroupName
		Assert-AreEqual $stoname $share.StorageAccountName
		Assert-AreEqual $shareName2 $share.Name
		Assert-AreEqual $quotaGiB $share.QuotaGiB
		Assert-AreEqual $metadata.Count $share.Metadata.Count
		Assert-AreEqual "Cool" $share.Accesstier
		Update-AzRmStorageShare -ResourceGroupName $rgname -StorageAccountName $stoname -Name $shareName2 -AccessTier Hot
		$share = $stos | Get-AzRmStorageShare -Name $shareName2
		Assert-AreEqual "Hot" $share.Accesstier

		$shares = Get-AzRmStorageShare -ResourceGroupName $rgname -StorageAccountName $stoname
		Assert-AreEqual 2 $shares.Count
		Assert-AreEqual $shareName  $shares[1].Name
		Assert-AreEqual $shareName2  $shares[0].Name

		Remove-AzRmStorageShare -Force -ResourceGroupName $rgname -StorageAccountName $stoname -Name $shareName
		$shares = Get-AzRmStorageShare -ResourceGroupName $rgname -StorageAccountName $stoname
		Assert-AreEqual 1 $shares.Count
		Assert-AreEqual $shareName2  $shares[0].Name

		$stos  | Get-AzRmStorageShare -Name $shareName2 | Remove-AzRmStorageShare -Force 
		$shares = Get-AzRmStorageShare -StorageAccount $stos
		Assert-AreEqual 0 $shares.Count

        Remove-AzStorageAccount -Force -ResourceGroupName $rgname -Name $stoname;
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

function Test-StorageFileShareGetUsage
{
    # Setup
    $rgname = Get-StorageManagementTestResourceName;

    try
    {
        # Test
        $stoname = 'sto' + $rgname;
        $stotype = 'Standard_GRS';
        $loc = Get-ProviderLocation ResourceManagement;
        $kind = 'StorageV2'
		$shareName = "share"+ $rgname

        Write-Verbose "RGName: $rgname | Loc: $loc"
        New-AzResourceGroup -Name $rgname -Location $loc;

        New-AzStorageAccount -ResourceGroupName $rgname -Name $stoname -Location $loc -Type $stotype -Kind $kind 
        $stos = Get-AzStorageAccount -ResourceGroupName $rgname;

		New-AzRmStorageShare -ResourceGroupName $rgname -StorageAccountName $stoname -Name $shareName
		$share = Get-AzRmStorageShare -ResourceGroupName $rgname -StorageAccountName $stoname -Name $shareName
		Assert-AreEqual $rgname $share.ResourceGroupName
		Assert-AreEqual $stoname $share.StorageAccountName
		Assert-AreEqual $shareName $share.Name
		
        # Get share usage
		$share = Get-AzRmStorageShare -ResourceGroupName $rgname -StorageAccountName $stoname -Name $shareName -GetShareUsage
		Assert-AreEqual $shareName $share.Name
		Assert-AreEqual 0 $share.ShareUsageBytes
		Assert-AreEqual $null $share.Deleted


        Remove-AzStorageAccount -Force -ResourceGroupName $rgname -Name $stoname;
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Test Storage File Share Soft Delete
.DESCRIPTION
SmokeTest
#>
function Test-ShareSoftDelete
{
    # Setup
    $rgname = Get-StorageManagementTestResourceName;

    try
    {
        # Test
        $stoname = 'sto' + $rgname;
        $stotype = 'Standard_LRS';
        $loc = Get-ProviderLocation ResourceManagement;
        $kind = 'StorageV2'
		$shareName1 = "share1"+ $rgname
		$shareName2 = "share2"+ $rgname

        Write-Verbose "RGName: $rgname | Loc: $loc"
        New-AzResourceGroup -Name $rgname -Location $loc;
		
        $loc = Get-ProviderLocation_Stage ResourceManagement;
        New-AzStorageAccount -ResourceGroupName $rgname -Name $stoname -Location $loc -Type $stotype -Kind $kind 
        $stos = Get-AzStorageAccount -ResourceGroupName $rgname;

		# Enable Share Soft delete
		Update-AzStorageFileServiceProperty -ResourceGroupName $rgname -StorageAccountName $stoname -EnableShareDeleteRetentionPolicy $true -ShareRetentionDays 5 
		$servicePropertie = Get-AzStorageFileServiceProperty -ResourceGroupName $rgname -StorageAccountName $stoname 
		Assert-AreEqual $true $servicePropertie.ShareDeleteRetentionPolicy.Enabled
		Assert-AreEqual 5 $servicePropertie.ShareDeleteRetentionPolicy.Days

		#create Shares
		New-AzRmStorageShare -ResourceGroupName $rgname -StorageAccountName $stoname -Name $shareName1
		$share = Get-AzRmStorageShare -ResourceGroupName $rgname -StorageAccountName $stoname -Name $shareName1
		Assert-AreEqual $rgname $share.ResourceGroupName
		Assert-AreEqual $stoname $share.StorageAccountName
		Assert-AreEqual $shareName1 $share.Name
		New-AzRmStorageShare -ResourceGroupName $rgname -StorageAccountName $stoname -Name $shareName2
		
		# Get share usage
		$share = Get-AzRmStorageShare -ResourceGroupName $rgname -StorageAccountName $stoname -Name $shareName1 -GetShareUsage
		Assert-AreEqual $shareName1 $share.Name
		Assert-AreEqual 0 $share.ShareUsageBytes
		Assert-AreEqual $null $share.Deleted
		
		#delete share
		Remove-AzRmStorageShare -ResourceGroupName $rgname -StorageAccountName $stoname -Name $shareName1 -Force

		#list share check
		$share = Get-AzRmStorageShare -ResourceGroupName $rgname -StorageAccountName $stoname -IncludeDeleted
		$deletedShareVersion = $share[0].Version
		Assert-AreEqual 2 $share.Count
		Assert-AreEqual $shareName1 $share[0].Name
		Assert-AreEqual $null $share[0].ShareUsageBytes
		Assert-AreEqual $true $share[0].Deleted
		Assert-AreNotEqual $null $share[0].DeletedTime
		Assert-AreNotEqual $null $share[0].Version	
		Assert-AreEqual $shareName2 $share[1].Name
		Assert-AreEqual $null $share[1].Deleted
		Assert-AreEqual $null $share[1].DeletedTime
		Assert-AreEqual $null $share[1].Version

		$share = Get-AzRmStorageShare -ResourceGroupName $rgname -StorageAccountName $stoname
		Assert-AreEqual 1 $share.Count
		Assert-AreEqual $shareName2 $share[0].Name
		Assert-AreEqual $null $share[0].Deleted
		Assert-AreEqual $null $share[0].DeletedTime
		Assert-AreEqual $null $share[0].Version

		# restore share and check
		if ($env:AZURE_TEST_MODE -eq "Record")
		{
			# sleep 1 miniute if record. Don't need sleep in replay
			sleep 60
		}
		Restore-AzRmStorageShare -ResourceGroupName $rgname -StorageAccountName $stoname -Name $shareName1 -DeletedShareVersion $deletedShareVersion	

		$share = Get-AzRmStorageShare -ResourceGroupName $rgname -StorageAccountName $stoname 
		Assert-AreEqual 2 $share.Count
		Assert-AreEqual $shareName1 $share[0].Name
		Assert-AreEqual $null $share[0].Deleted
		Assert-AreEqual $null $share[0].DeletedTime
		Assert-AreEqual $null $share[0].Version	
		Assert-AreEqual $shareName2 $share[1].Name
		Assert-AreEqual $null $share[1].Deleted
		Assert-AreEqual $null $share[1].DeletedTime
		Assert-AreEqual $null $share[1].Version		

		$share = Get-AzRmStorageShare -ResourceGroupName $rgname -StorageAccountName $stoname -IncludeDeleted
		Assert-AreEqual 2 $share.Count

		# Disable Share Soft delete
		Update-AzStorageFileServiceProperty -ResourceGroupName $rgname -StorageAccountName $stoname -EnableShareDeleteRetentionPolicy $false
		$servicePropertie = Get-AzStorageFileServiceProperty -ResourceGroupName $rgname -StorageAccountName $stoname 
		Assert-AreEqual $false $servicePropertie.ShareDeleteRetentionPolicy.Enabled

        Remove-AzStorageAccount -Force -ResourceGroupName $rgname -Name $stoname;
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}


<#
.SYNOPSIS
Test Storage File Share Snapshot
.DESCRIPTION
SmokeTest
#>
function Test-ShareSnapshot
{
    # Setup
    $rgname = Get-StorageManagementTestResourceName;

    try
    {
        # Test
        $stoname = 'sto' + $rgname;
        $stotype = 'Standard_LRS';
        $loc = Get-ProviderLocation ResourceManagement;
        $kind = 'StorageV2'
		$shareName1 = "share1"+ $rgname
		$shareName2 = "share2"+ $rgname

        Write-Verbose "RGName: $rgname | Loc: $loc"
        New-AzResourceGroup -Name $rgname -Location $loc;
		
        $loc = Get-ProviderLocation_Stage ResourceManagement;
        New-AzStorageAccount -ResourceGroupName $rgname -Name $stoname -Location $loc -Type $stotype -Kind $kind 
        $stos = Get-AzStorageAccount -ResourceGroupName $rgname;

		# Enable Share Soft delete
		Update-AzStorageFileServiceProperty -ResourceGroupName $rgname -StorageAccountName $stoname -EnableShareDeleteRetentionPolicy $true -ShareRetentionDays 5 
		$servicePropertie = Get-AzStorageFileServiceProperty -ResourceGroupName $rgname -StorageAccountName $stoname 
		Assert-AreEqual $true $servicePropertie.ShareDeleteRetentionPolicy.Enabled
		Assert-AreEqual 5 $servicePropertie.ShareDeleteRetentionPolicy.Days

		#create Shares
		New-AzRmStorageShare -ResourceGroupName $rgname -StorageAccountName $stoname -Name $shareName1
		$share = Get-AzRmStorageShare -ResourceGroupName $rgname -StorageAccountName $stoname -Name $shareName1
		Assert-AreEqual $rgname $share.ResourceGroupName
		Assert-AreEqual $stoname $share.StorageAccountName
		Assert-AreEqual $shareName1 $share.Name
		New-AzRmStorageShare -ResourceGroupName $rgname -StorageAccountName $stoname -Name $shareName2
		
		# Create Share Snapshot
		$shareSnapshot11 = New-AzRmStorageShare -ResourceGroupName $rgname -StorageAccountName $stoname -Name $shareName1 -Snapshot
		Assert-AreEqual $shareName1 $shareSnapshot11.Name
		# Assert-AreEqual 0 $share.ShareUsageBytes
		#Assert-AreEqual $null $share.Deleted
		# Assert-AreNotEqual $null $share.SnapshotTime
		$shareSnapshot12 = New-AzRmStorageShare -ResourceGroupName $rgname -StorageAccountName $stoname -Name $shareName1 -Snapshot
		$shareSnapshot21 = New-AzRmStorageShare -ResourceGroupName $rgname -StorageAccountName $stoname -Name $shareName2 -Snapshot

		# list Shares with IncludeSnapshot
		$shares = Get-AzRmStorageShare -ResourceGroupName $rgname -StorageAccountName $stoname -IncludeSnapshot 
        # Assert-AreEqual 6 $shares.Count

		# Get single share snapshot
		$sharesp1 = Get-AzRmStorageShare -ResourceGroupName $rgname -StorageAccountName $stoname -Name  $shareName1 -SnapshotTime $shareSnapshot11.SnapshotTime
		Assert-AreEqual $shareName1 $sharesp1.Name
        # Assert-AreEqual $shareSnapshot11.SnapshotTime $shareName1.SnapshotTime
		
		#delete single share snapshot
		Remove-AzRmStorageShare -ResourceGroupName $rgname -StorageAccountName $stoname -Name $shareName1 -SnapshotTime $shareSnapshot11.SnapshotTime -Force

		# list Shares
		$shares = Get-AzRmStorageShare -ResourceGroupName $rgname -StorageAccountName $stoname -IncludeSnapshot 
        # Assert-AreEqual 5 $shares.Count
		$shares = Get-AzRmStorageShare -ResourceGroupName $rgname -StorageAccountName $stoname -IncludeSnapshot -IncludeDeleted 
        # Assert-AreEqual 6 $shares.Count
		$shares = Get-AzRmStorageShare -ResourceGroupName $rgname -StorageAccountName $stoname -IncludeDeleted 
        # Assert-AreEqual 2 $shares.Count
		
		# Delete share Default Include (None)
		$Error.Clear()
        Remove-AzRmStorageShare -ResourceGroupName $rgname -StorageAccountName $stoname -Name $shareName1 -Force -ErrorAction SilentlyContinue
		# Assert-AreEqual 1 $Error.Count 
        # Assert-AreEqual 409 $Error[0].Exception.Response.StatusCode

		# Delete share Include None
		$Error.Clear()
        Remove-AzRmStorageShare -ResourceGroupName $rgname -StorageAccountName $stoname -Name $shareName1 -Include None -Force -ErrorAction SilentlyContinue
		# Assert-AreEqual 1 $Error.Count 
        # Assert-AreEqual 409 $Error[0].Exception.Response.StatusCode

		# Delete share Include Snapshots
		$Error.Clear()
        Remove-AzRmStorageShare -ResourceGroupName $rgname -StorageAccountName $stoname -Name $shareName1 -Include Snapshots -Force

		# Delete share Include Leased-Snapshots
		$Error.Clear()
        Remove-AzRmStorageShare -ResourceGroupName $rgname -StorageAccountName $stoname -Name $shareName1 -Include Leased-Snapshots -Force
		
		# list Shares after delete
		$shares = Get-AzRmStorageShare -ResourceGroupName $rgname -StorageAccountName $stoname -IncludeSnapshot 
        # Assert-AreEqual 0 $shares.Count

        Remove-AzStorageAccount -Force -ResourceGroupName $rgname -Name $stoname;
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Test Storage File Service Properties
.DESCRIPTION
SmokeTest
#>
function Test-FileServiceProperties
{
    # Setup
    $rgname = Get-StorageManagementTestResourceName;

    try
    {
        # Test
        $stoname = 'sto' + $rgname;
        $stotype = 'Premium_LRS';
        $loc = Get-ProviderLocation_Canary2 ResourceManagement;
        $kind = 'FileStorage'

        Write-Verbose "RGName: $rgname | Loc: $loc"
        New-AzResourceGroup -Name $rgname -Location $loc;
		
        # $loc = Get-ProviderLocation_Canary ResourceManagement;
        New-AzStorageAccount -ResourceGroupName $rgname -Name $stoname -Location $loc -Type $stotype -Kind $kind 
        $stos = Get-AzStorageAccount -ResourceGroupName $rgname;
		
		# Enable MC, and set smb setting
		Update-AzStorageFileServiceProperty -ResourceGroupName $rgname -StorageAccountName $stoname -EnableSmbMultichannel $true `
					-SMBProtocolVersion SMB2.1,SMB3.0,SMB3.1.1 `
					-SMBAuthenticationMethod Kerberos,NTLMv2 `
					-SMBKerberosTicketEncryption RC4-HMAC,AES-256 `
					-SMBChannelEncryption AES-128-CCM,AES-128-GCM,AES-256-GCM
		$servicePropertie = Get-AzStorageFileServiceProperty -ResourceGroupName $rgname -StorageAccountName $stoname 
		Assert-AreEqual 3 $servicePropertie.ProtocolSettings.Smb.Versions.Count
		Assert-AreEqual 2 $servicePropertie.ProtocolSettings.Smb.AuthenticationMethods.Count
		Assert-AreEqual 2 $servicePropertie.ProtocolSettings.Smb.KerberosTicketEncryption.Count
		Assert-AreEqual 3 $servicePropertie.ProtocolSettings.Smb.ChannelEncryption.Count
		Assert-AreEqual $true $servicePropertie.ProtocolSettings.Smb.Multichannel.Enabled

		# Disable MC, update smb setting
		Update-AzStorageFileServiceProperty -ResourceGroupName $rgname -StorageAccountName $stoname -EnableSmbMultichannel $false `
					-SMBProtocolVersion SMB3.1.1 `
					-SMBAuthenticationMethod Kerberos `
					-SMBKerberosTicketEncryption AES-256 `
					-SMBChannelEncryption AES-128-CCM
		$servicePropertie = Get-AzStorageFileServiceProperty -ResourceGroupName $rgname -StorageAccountName $stoname 
		Assert-AreEqual "SMB3.1.1" $servicePropertie.ProtocolSettings.Smb.Versions[0]
		Assert-AreEqual "Kerberos" $servicePropertie.ProtocolSettings.Smb.AuthenticationMethods[0]
		Assert-AreEqual "AES-256" $servicePropertie.ProtocolSettings.Smb.KerberosTicketEncryption[0]
		Assert-AreEqual "AES-128-CCM" $servicePropertie.ProtocolSettings.Smb.ChannelEncryption[0]
		Assert-AreEqual $false $servicePropertie.ProtocolSettings.Smb.Multichannel.Enabled

		# remove smb setting
		Update-AzStorageFileServiceProperty -ResourceGroupName $rgname -StorageAccountName $stoname `
					-SMBProtocolVersion @() `
					-SMBAuthenticationMethod @()`
					-SMBKerberosTicketEncryption @() `
					-SMBChannelEncryption @()
		$servicePropertie = Get-AzStorageFileServiceProperty -ResourceGroupName $rgname -StorageAccountName $stoname 
		Assert-AreEqual $null $servicePropertie.ProtocolSettings.Smb.Versions
		Assert-AreEqual $null $servicePropertie.ProtocolSettings.Smb.AuthenticationMethods
		Assert-AreEqual $null $servicePropertie.ProtocolSettings.Smb.KerberosTicketEncryption
		Assert-AreEqual $null $servicePropertie.ProtocolSettings.Smb.ChannelEncryption

        Remove-AzStorageAccount -Force -ResourceGroupName $rgname -Name $stoname;
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Test Azure storage share with NFS
.DESCRIPTION
Smoke[Broken]Test
#>
function Test-AzureStorageShareNFS
{
    # Setup
    $rgname = Get-StorageManagementTestResourceName;

    try
    {
        # Test
        $stoname = 'sto' + $rgname;
        $stotype = 'Premium_LRS';
        $kind = 'FileStorage'

        $loc = Get-ProviderLocation ResourceManagement;
        New-AzResourceGroup -Name $rgname -Location $loc;
		
        New-AzStorageAccount -ResourceGroupName $rgname -Name $stoname -Location $loc -Type $stotype -Kind $kind;
        $sto = Get-AzStorageAccount -ResourceGroupName $rgname  -Name $stoname;
        Assert-AreEqual $stoname $sto.StorageAccountName;
        Assert-AreEqual $stotype $sto.Sku.Name;
        Assert-AreEqual $kind $sto.Kind; 

		
		$shareName = "share"+ $rgname
		$sto | New-AzRmStorageShare -Name $shareName -EnabledProtocol NFS -RootSquash RootSquash
		$share = $sto | Get-AzRmStorageShare -Name $shareName
		Assert-AreEqual $rgname $share.ResourceGroupName
		Assert-AreEqual $stoname $share.StorageAccountName
		Assert-AreEqual $shareName $share.Name
		Assert-AreEqual "NFS" $share.EnabledProtocols
		Assert-AreEqual "RootSquash" $share.RootSquash

		Update-AzRmStorageShare -ResourceGroupName $rgname -StorageAccountName $stoname -Name $shareName -RootSquash NoRootSquash 	
 		$share = $sto | Get-AzRmStorageShare -Name $shareName
 		Assert-AreEqual $rgname $share.ResourceGroupName
 		Assert-AreEqual $stoname $share.StorageAccountName
		Assert-AreEqual $shareName $share.Name
		Assert-AreEqual "NFS" $share.EnabledProtocols
		Assert-AreEqual "NoRootSquash" $share.RootSquash
        
        Retry-IfException { Remove-AzStorageAccount -Force -ResourceGroupName $rgname -Name $stoname; }
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}


