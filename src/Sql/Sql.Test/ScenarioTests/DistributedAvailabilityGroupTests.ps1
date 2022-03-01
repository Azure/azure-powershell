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

# Location to use for provisioning test managed instances
$instanceLocation = "westcentralus"

# Test constants
$linkName = "TestDAG"
$invalidLinkName1 = "invalidDAG1"
$targetDatabase = "testdb"
$sourceEndpoint = "TCP://SERVER:7022"
$primaryAGName = "BoxLocalAg1"
$secondaryAGName = "testcl"
$linkType = "Microsoft.Sql/managedInstances/distributedAvailabilityGroups"
$rgName = "CustomerExperienceTeam_RG"
$miName = "chimera-ps-cli-v2"
  

<#
	.SYNOPSIS
	Tests basic Managed Instance Link operations
#>
function Test-ManagedInstanceLink
{
	try
	{
		#temp cleanup
		try { Remove-AzSqlInstanceLink -ResourceGroupName $rgName -InstanceName $miName -LinkName $linkName } catch { }
		try { Remove-AzSqlInstanceLink -ResourceGroupName $rgName -InstanceName $miName -LinkName $invalidLinkName1 } catch { }

		# List 0 links
		$listLinksZero = Get-AzSqlInstanceLink -ResourceGroupName $rgName -InstanceName $miName
		Write-Debug ('$listLinksZero is ' + (ConvertTo-Json $listLinksZero))
		Assert-Null $listLinksZero

		$upsertJ = New-AzSqlInstanceLink -ResourceGroupName $rgName -InstanceName $miName -LinkName $linkName -PrimaryAvailabilityGroupName $primaryAGName -SecondaryAvailabilityGroupName $secondaryAGName -TargetDatabase $targetDatabase -SourceEndpoint $sourceEndpoint -AsJob
		$listResp = Get-AzSqlInstanceLink -ResourceGroupName $rgName -InstanceName $miName
		$tries = 1
		while ($listResp.Count -eq 0 -And $tries -le 5) {
			$tries = $tries + 1
			Wait-Seconds 30
			$listResp = Get-AzSqlInstanceLink -ResourceGroupName $rgName -InstanceName $miName
		}

		# Link is created
		$getLink = Get-AzSqlInstanceLink -ResourceGroupName $rgName -InstanceName $miName -LinkName $linkName
		Write-Debug ('$getLink is ' + (ConvertTo-Json $getLink))
		Assert-NotNull $getLink
        Assert-AreEqual $getLink.ResourceGroupName $rgName
        Assert-AreEqual $getLink.InstanceName $miName
		Assert-AreEqual $getLink.Type $linkType
        Assert-AreEqual $getLink.LinkName $linkName
        Assert-AreEqual $getLink.TargetDatabase $targetDatabase
        Assert-AreEqual $getLink.SourceEndpoint $sourceEndpoint
        Assert-AreEqual $getLink.ReplicationMode Async
		# "Id": "/subscriptions/8313371e-0879-428e-b1da-6353575a9192/resourceGroups/CustomerExperienceTeam_RG/providers/Microsoft.Sql/managedInstances/chimera-ps-cli-v2/distributedAvailabilityGroups/TestDAG",

		# List all links on instance
		$listLink = Get-AzSqlInstanceLink -ResourceGroupName $rgName -InstanceName $miName
		Write-Debug ('$listLink is ' + (ConvertTo-Json $listLink))
		Assert-NotNull $listLink
		Assert-AreEqual	$listLink.Count 1

		# Remove the Link
		$rmLink = Remove-AzSqlInstanceLink -ResourceGroupName $rgName -InstanceName $miName -LinkName $linkName
		Write-Debug ('$rmLink is ' + (ConvertTo-Json $rmLink))
		Assert-NotNull $rmLink
        Assert-AreEqual $rmLink.ResourceGroupName $rgName
        Assert-AreEqual $rmLink.InstanceName $miName
		Assert-AreEqual $rmLink.Type $linkType
        Assert-AreEqual $rmLink.LinkName $linkName
        Assert-AreEqual $rmLink.TargetDatabase $targetDatabase
        Assert-AreEqual $rmLink.SourceEndpoint $sourceEndpoint
        Assert-AreEqual $rmLink.ReplicationMode Async

		# List 0 links
		$listLinksZero = Get-AzSqlInstanceLink -ResourceGroupName $rgName -InstanceName $miName
		Write-Debug ('$listLinksZero is ' + (ConvertTo-Json $listLinksZero))
		Assert-Null $listLinksZero
	}
	finally
	{
		Remove-ResourceGroupForTest $rg
	}
}

<#
	.SYNOPSIS
	Tests basic Managed Instance Link operations
#>
function Test-ManagedInstanceLinkErrHandling
{
	try
	{
		#temp cleanup
		try { Remove-AzSqlInstanceLink -ResourceGroupName $rgName -InstanceName $miName -LinkName $linkName } catch { }
		try { Remove-AzSqlInstanceLink -ResourceGroupName $rgName -InstanceName $miName -LinkName $invalidLinkName1 } catch { }
		
		# List 0 links
		$listLinksZero = Get-AzSqlInstanceLink -ResourceGroupName $rgName -InstanceName $miName
		Write-Debug ('$listLinksZero is ' + (ConvertTo-Json $listLinksZero))
		Assert-Null $listLinksZero

		# Test required args validation
		$msgExc = "Cannot validate argument on parameter"
		Assert-ThrowsContains { New-AzSqlInstanceLink -ResourceGroupName $rgName -InstanceName $miName -LinkName $invalidLinkName1 -PrimaryAvailabilityGroupName $primaryAGName -SecondaryAvailabilityGroupName $secondaryAGName -TargetDatabase $targetDatabase -SourceEndpoint ""  } $msgExc
		Assert-ThrowsContains { New-AzSqlInstanceLink -ResourceGroupName $rgName -InstanceName $miName -LinkName $invalidLinkName1 -PrimaryAvailabilityGroupName $primaryAGName -SecondaryAvailabilityGroupName $secondaryAGName -TargetDatabase "" -SourceEndpoint $sourceEndpoint  } $msgExc
		Assert-ThrowsContains { New-AzSqlInstanceLink -ResourceGroupName $rgName -InstanceName $miName -LinkName $invalidLinkName1 -PrimaryAvailabilityGroupName $primaryAGName -SecondaryAvailabilityGroupName "" -TargetDatabase $targetDatabase -SourceEndpoint $sourceEndpoint 	 } $msgExc
		Assert-ThrowsContains { New-AzSqlInstanceLink -ResourceGroupName $rgName -InstanceName $miName -LinkName $invalidLinkName1 -PrimaryAvailabilityGroupName "" -SecondaryAvailabilityGroupName $secondaryAGName -TargetDatabase $targetDatabase -SourceEndpoint $sourceEndpoint } $msgExc 
		Assert-ThrowsContains { New-AzSqlInstanceLink -ResourceGroupName $rgName -InstanceName $miName -LinkName "" -PrimaryAvailabilityGroupName $primaryAGName -SecondaryAvailabilityGroupName $secondaryAGName -TargetDatabase $targetDatabase -SourceEndpoint $sourceEndpoint 	 } $msgExc
		
		# Should throw when source endpoint is not in proper format
		$msgExcInvalid = "Invalid value"
		Assert-ThrowsContains { New-AzSqlInstanceLink -ResourceGroupName $rgName -InstanceName $miName -LinkName $invalidLinkName1 -PrimaryAvailabilityGroupName $primaryAGName -SecondaryAvailabilityGroupName $secondaryAGName -TargetDatabase $targetDatabase -SourceEndpoint "invalid_value"  } $msgExcInvalid
		
		# Should throw when deleting non existant mi link
		$msgExcNotFound = "The requested resource of type 'Microsoft.Sql/managedInstances/distributedAvailabilityGroups' with name '" + $invalidLinkName1 + "' was not found."
		Assert-ThrowsContains { Remove-AzSqlInstanceLink -ResourceGroupName $rgName -InstanceName $miName -LinkName $invalidLinkName1 } $msgExcNotFound
		
		# Should throw when getting non existant mi link
		$msgExcNotFound = "The requested resource of type 'Microsoft.Sql/managedInstances/distributedAvailabilityGroups' with name '" + $invalidLinkName1 + "' was not found."
		Assert-ThrowsContains { Get-AzSqlInstanceLink -ResourceGroupName $rgName -InstanceName $miName -LinkName $invalidLinkName1 } $msgExcNotFound

		# Should throw when setting non existant mi link
		$msgExcNotFound = "The requested resource of type 'Microsoft.Sql/managedInstances/distributedAvailabilityGroups' with name '" + $invalidLinkName1 + "' was not found."
		Assert-ThrowsContains { Set-AzSqlInstanceLink -ResourceGroupName $rgName -InstanceName $miName -LinkName $invalidLinkName1 -ReplicationMode sync } $msgExcNotFound
				
		# List 0 links
		$listLinksZero = Get-AzSqlInstanceLink -ResourceGroupName $rgName -InstanceName $miName
		Write-Debug ('$listLinksZero is ' + (ConvertTo-Json $listLinksZero))
		Assert-Null $listLinksZero

		$upsertJ = New-AzSqlInstanceLink -ResourceGroupName $rgName -InstanceName $miName -LinkName $linkName -PrimaryAvailabilityGroupName $primaryAGName -SecondaryAvailabilityGroupName $secondaryAGName -TargetDatabase $targetDatabase -SourceEndpoint $sourceEndpoint -AsJob
		$listResp = Get-AzSqlInstanceLink -ResourceGroupName $rgName -InstanceName $miName
		$tries = 1
		while ($listResp.Count -eq 0 -And $tries -le 3) {
			$tries = $tries + 1
			Wait-Seconds 30
			$listResp = Get-AzSqlInstanceLink -ResourceGroupName $rgName -InstanceName $miName
		}

		# Link is created
		$getLink = Get-AzSqlInstanceLink -ResourceGroupName $rgName -InstanceName $miName -LinkName $linkName
		Write-Debug ('$getLink is ' + (ConvertTo-Json $getLink))
		Assert-NotNull $getLink
        Assert-AreEqual $getLink.ResourceGroupName $rgName
        Assert-AreEqual $getLink.InstanceName $miName
		Assert-AreEqual $getLink.Type $linkType
        Assert-AreEqual $getLink.LinkName $linkName
        Assert-AreEqual $getLink.TargetDatabase $targetDatabase
        Assert-AreEqual $getLink.SourceEndpoint $sourceEndpoint
        Assert-AreEqual $getLink.ReplicationMode Async
		# "Id": "/subscriptions/8313371e-0879-428e-b1da-6353575a9192/resourceGroups/CustomerExperienceTeam_RG/providers/Microsoft.Sql/managedInstances/chimera-ps-cli-v2/distributedAvailabilityGroups/TestDAG",
  
		# validate forbidden updates in current link state
		$exSet1 = "The 'parameters.properties.replicationMode' segment in the url is invalid."
		Assert-ThrowsContains { Set-AzSqlInstanceLink -ResourceGroupName $rgName -InstanceName $miName -LinkName $linkName -ReplicationMode RandomValue } $exSet1
		$exSet2 = "The operation cannot be performed since the database '" + $targetDatabase +"' is in a replication relationship."
		Assert-ThrowsContains { Set-AzSqlInstanceLink -ResourceGroupName $rgName -InstanceName $miName -LinkName $linkName -ReplicationMode Sync } $exSet2
		Assert-ThrowsContains { Set-AzSqlInstanceLink -ResourceGroupName $rgName -InstanceName $miName -LinkName $linkName -ReplicationMode Async } $exSet2

		# Cleanup link
		$rmLink = Remove-AzSqlInstanceLink -ResourceGroupName $rgName -InstanceName $miName -LinkName $linkName
		Write-Debug ('$rmLink is ' + (ConvertTo-Json $rmLink))
		Assert-NotNull $rmLink
        Assert-AreEqual $rmLink.ResourceGroupName $rgName
        Assert-AreEqual $rmLink.InstanceName $miName
		Assert-AreEqual $rmLink.Type $linkType
        Assert-AreEqual $rmLink.LinkName $linkName
        Assert-AreEqual $rmLink.TargetDatabase $targetDatabase
        Assert-AreEqual $rmLink.SourceEndpoint $sourceEndpoint
        Assert-AreEqual $rmLink.ReplicationMode Async
		
		# List 0 links
		$listLinksZero = Get-AzSqlInstanceLink -ResourceGroupName $rgName -InstanceName $miName
		Write-Debug ('$listLinksZero is ' + (ConvertTo-Json $listLinksZero))
		Assert-Null $listLinksZero
	}
	finally
	{
		Remove-ResourceGroupForTest $rg
	}
}