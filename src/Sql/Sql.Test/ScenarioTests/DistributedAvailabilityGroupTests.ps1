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
 
$linkNamePipe = "TestDAG_Pipe"
$targetDatabasePipe = "testdb_Pipe"
$sourceEndpointPipe = "TCP://SERVERPipe:7022"
$primaryAGNamePipe = "BoxLocalAg1_Pipe"
$secondaryAGNamePipe = "testcl_Pipe"

<#
    .SYNOPSIS
    Tests basic Managed Instance Link operations
#>
function Test-ManagedInstanceLink
{
    try
    {
        # Setup
        $rg = Create-ResourceGroupForTest
        $managedInstance = Create-ManagedInstanceForTest $rg
        $rgName = $rg.ResourceGroupName
        $miName = $managedInstance.ManagedInstanceName

        #temp cleanup
        #try { Get-AzSqlInstance -ResourceGroupName $rgName -Name $miName | Get-AzSqlInstanceLink | Remove-AzSqlInstanceLink -Force } catch { }
                
        # generate expected link ids
        $instance = Get-AzSqlInstance -ResourceGroupName $rgName -Name $miName
        $instanceId = $instance.Id
        $linkId = $instanceId + "/distributedAvailabilityGroups/" + $linkName

        # List 0 links
        $listLinksZero = Get-AzSqlInstanceLink -ResourceGroupName $rgName -InstanceName $miName
        Write-Debug ('$listLinksZero is ' + (ConvertTo-Json $listLinksZero))
        Assert-Null $listLinksZero

        $upsertJ = New-AzSqlInstanceLink -ResourceGroupName $rgName -InstanceName $miName -LinkName $linkName -PrimaryAvailabilityGroupName $primaryAGName -SecondaryAvailabilityGroupName $secondaryAGName -TargetDatabase $targetDatabase -SourceEndpoint $sourceEndpoint -AsJob

        # wait a little bit for the link resource to be created
        Wait-Seconds 60
        $listResp = Get-AzSqlInstanceLink -ResourceGroupName $rgName -InstanceName $miName
        Write-Debug ('$listLinksZero is ' + (ConvertTo-Json $listResp))
        Assert-AreEqual $listResp.Count 1 # if this fails during recording, please increase Wait-Seconds duration (3 lines above)
        
        # Test all 4 parameter sets for GET:
        # GetByNameParameterSet
        # GetByParentObjectParameterSet
        # GetByResourceIdParameterSet
        # GetByInstanceResourceIdParameterSet

        # Get the created link - (GetByNameParameterSet)
        $getLinkByNameParameterSet = Get-AzSqlInstanceLink -ResourceGroupName $rgName -InstanceName $miName -Name $linkName
        Write-Debug ('$getLinkByNameParameterSet is ' + (ConvertTo-Json $getLinkByNameParameterSet))
        Assert-NotNull $getLinkByNameParameterSet
        Assert-AreEqual $getLinkByNameParameterSet.ResourceGroupName $rgName
        Assert-AreEqual $getLinkByNameParameterSet.InstanceName $miName
        Assert-AreEqual $getLinkByNameParameterSet.Type $linkType
        Assert-AreEqual $getLinkByNameParameterSet.Id $linkId
        Assert-AreEqual $getLinkByNameParameterSet.Name $linkName
        Assert-AreEqual $getLinkByNameParameterSet.TargetDatabase $targetDatabase
        Assert-AreEqual $getLinkByNameParameterSet.SourceEndpoint $sourceEndpoint
        Assert-AreEqual $getLinkByNameParameterSet.ReplicationMode Async

        # Get the created link - (GetByParentObjectParameterSet)
        $getLinkByParentObjectParameterSet = Get-AzSqlInstanceLink -InstanceObject $instance -LinkName $linkName
        Write-Debug ('$getLinkByParentObjectParameterSet is ' + (ConvertTo-Json $getLinkByParentObjectParameterSet))
        Assert-NotNull $getLinkByParentObjectParameterSet
        Assert-AreEqual $getLinkByParentObjectParameterSet.ResourceGroupName $rgName
        Assert-AreEqual $getLinkByParentObjectParameterSet.InstanceName $miName
        Assert-AreEqual $getLinkByParentObjectParameterSet.Type $linkType
        Assert-AreEqual $getLinkByParentObjectParameterSet.Id $linkId
        Assert-AreEqual $getLinkByParentObjectParameterSet.Name $linkName
        Assert-AreEqual $getLinkByParentObjectParameterSet.TargetDatabase $targetDatabase
        Assert-AreEqual $getLinkByParentObjectParameterSet.SourceEndpoint $sourceEndpoint
        Assert-AreEqual $getLinkByParentObjectParameterSet.ReplicationMode Async

        # Get the created link - (GetByResourceIdParameterSet)
        $getLinkByResourceIdParameterSet = Get-AzSqlInstanceLink -ResourceId $linkId
        Write-Debug ('$getLinkByResourceIdParameterSet is ' + (ConvertTo-Json $getLinkByResourceIdParameterSet))
        Assert-NotNull $getLinkByResourceIdParameterSet
        Assert-AreEqual $getLinkByResourceIdParameterSet.ResourceGroupName $rgName
        Assert-AreEqual $getLinkByResourceIdParameterSet.InstanceName $miName
        Assert-AreEqual $getLinkByResourceIdParameterSet.Type $linkType
        Assert-AreEqual $getLinkByResourceIdParameterSet.Id $linkId
        Assert-AreEqual $getLinkByResourceIdParameterSet.Name $linkName
        Assert-AreEqual $getLinkByResourceIdParameterSet.TargetDatabase $targetDatabase
        Assert-AreEqual $getLinkByResourceIdParameterSet.SourceEndpoint $sourceEndpoint
        Assert-AreEqual $getLinkByResourceIdParameterSet.ReplicationMode Async

        # Get the created link - (GetByInstanceResourceIdParameterSet)
        $getLinkByInstanceResourceIdParameterSet = Get-AzSqlInstanceLink -InstanceResourceId $instanceId -LinkName $linkName
        Write-Debug ('$getLinkByInstanceResourceIdParameterSet is ' + (ConvertTo-Json $getLinkByInstanceResourceIdParameterSet))
        Assert-NotNull $getLinkByInstanceResourceIdParameterSet
        Assert-AreEqual $getLinkByInstanceResourceIdParameterSet.ResourceGroupName $rgName
        Assert-AreEqual $getLinkByInstanceResourceIdParameterSet.InstanceName $miName
        Assert-AreEqual $getLinkByInstanceResourceIdParameterSet.Type $linkType
        Assert-AreEqual $getLinkByInstanceResourceIdParameterSet.Id $linkId
        Assert-AreEqual $getLinkByInstanceResourceIdParameterSet.Name $linkName
        Assert-AreEqual $getLinkByInstanceResourceIdParameterSet.TargetDatabase $targetDatabase
        Assert-AreEqual $getLinkByInstanceResourceIdParameterSet.SourceEndpoint $sourceEndpoint
        Assert-AreEqual $getLinkByInstanceResourceIdParameterSet.ReplicationMode Async

        # List all links on instance
        $listLink = Get-AzSqlInstanceLink -ResourceGroupName $rgName -InstanceName $miName
        Write-Debug ('$listLink is ' + (ConvertTo-Json $listLink))
        Assert-NotNull $listLink
        Assert-AreEqual	$listLink.Count 1

        # Remove the Link
        $rmLink = Remove-AzSqlInstanceLink -ResourceGroupName $rgName -InstanceName $miName -LinkName $linkName -Force -PassThru
        Write-Debug ('$rmLink is ' + (ConvertTo-Json $rmLink))
        Assert-NotNull $rmLink
        Assert-AreEqual $rmLink.ResourceGroupName $rgName
        Assert-AreEqual $rmLink.InstanceName $miName
        Assert-AreEqual $rmLink.Type $linkType
        Assert-AreEqual $rmLink.Name $linkName
        Assert-AreEqual $rmLink.TargetDatabase $targetDatabase
        Assert-AreEqual $rmLink.SourceEndpoint $sourceEndpoint
        Assert-AreEqual $rmLink.ReplicationMode Async

        # List 0 links
        $listLinksZero = Get-AzSqlInstanceLink -ResourceGroupName $rgName -InstanceName $miName
        Write-Debug ('$listLinksZero is ' + (ConvertTo-Json $listLinksZero))
        Assert-Null $listLinksZero
        
        # Delete non existant link THROWS (via DeleteByParentObjectParameterSet)
        $msgExcDel = "The requested resource of type '" + $linkType + "' with name '" + $linkName + "' was not found."
        Assert-Throws { Remove-AzSqlInstanceLink -InstanceObject $instance -LinkName $certName1 -Force } $msgExc

        # Delete non existant link THROWS (via DeleteByInputObjectParameterSet)
        $msgExcDel = "The requested resource of type '" + $linkType + "' with name '" + $linkName + "' was not found."
        Assert-Throws { Remove-AzSqlInstanceLink -InputObject $getLinkByParentObjectParameterSet -Force } $msgExc
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
        # Setup
        $rg = Create-ResourceGroupForTest
        $managedInstance = Create-ManagedInstanceForTest $rg
        $rgName = $rg.ResourceGroupName
        $miName = $managedInstance.ManagedInstanceName

        #temp cleanup
        #try { Get-AzSqlInstance -ResourceGroupName $rgName -Name $miName | Get-AzSqlInstanceLink | Remove-AzSqlInstanceLink -Force } catch { }		

        # generate expected link ids
        $instance = Get-AzSqlInstance -ResourceGroupName $rgName -Name $miName
        $instanceId = $instance.Id
        $linkId = $instanceId + "/distributedAvailabilityGroups/" + $linkName
        
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
        Assert-ThrowsContains { Remove-AzSqlInstanceLink -ResourceGroupName $rgName -InstanceName $miName -LinkName $invalidLinkName1 -Force} $msgExcNotFound
        
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

        # upsert via CreateByParentObjectParameterSet
        $upsertJ = New-AzSqlInstanceLink -InstanceObject $instance -LinkName $linkName -PrimaryAvailabilityGroupName $primaryAGName -SecondaryAvailabilityGroupName $secondaryAGName -TargetDatabase $targetDatabase -SourceEndpoint $sourceEndpoint -AsJob

        # wait a little bit for the link resource to be created
        Wait-Seconds 60
        $listResp = Get-AzSqlInstanceLink -ResourceGroupName $rgName -InstanceName $miName
        Write-Debug ('$listLinksZero is ' + (ConvertTo-Json $listResp))
        Assert-AreEqual $listResp.Count 1 # if this fails during recording, please increase Wait-Seconds duration (3 lines above)

        # Link is created
        $getLink = Get-AzSqlInstanceLink -ResourceGroupName $rgName -InstanceName $miName -LinkName $linkName
        Write-Debug ('$getLink is ' + (ConvertTo-Json $getLink))
        Assert-NotNull $getLink
        Assert-AreEqual $getLink.ResourceGroupName $rgName
        Assert-AreEqual $getLink.InstanceName $miName
        Assert-AreEqual $getLink.Type $linkType
        Assert-AreEqual $getLink.Name $linkName
        Assert-AreEqual $getLink.TargetDatabase $targetDatabase
        Assert-AreEqual $getLink.SourceEndpoint $sourceEndpoint
        Assert-AreEqual $getLink.ReplicationMode Async
        Assert-AreEqual $getLink.Id $linkId

        # Confirm that ShouldContinue message is triggered on Remove (tests don't support user interaction so we'll validate the exception)
        $msgExcDataLoss = "may cause data loss"
        Assert-ThrowsContains { Remove-AzSqlInstanceLink -ResourceGroupName $rgName -InstanceName $miName -Name $invalidLinkName1 } $msgExcDataLoss

        # validate forbidden updates in current link state
        $exSet1 = "The 'parameters.properties.replicationMode' segment in the url is invalid."
        Assert-ThrowsContains { Set-AzSqlInstanceLink -ResourceGroupName $rgName -InstanceName $miName -LinkName $linkName -ReplicationMode RandomValue } $exSet1
        $exSet2 = "The operation cannot be performed since the database '" + $targetDatabase +"' is in a replication relationship."
        Assert-ThrowsContains { Set-AzSqlInstanceLink -ResourceGroupName $rgName -InstanceName $miName -LinkName $linkName -ReplicationMode Sync } $exSet2
        Assert-ThrowsContains { Set-AzSqlInstanceLink -ResourceGroupName $rgName -InstanceName $miName -LinkName $linkName -ReplicationMode Async } $exSet2
        # Repeat with different input sets
        $exSet1 = "The 'parameters.properties.replicationMode' segment in the url is invalid."
        Assert-ThrowsContains { Set-AzSqlInstanceLink -InstanceObject $instance -LinkName $linkName -ReplicationMode RandomValue } $exSet1
        $exSet2 = "The operation cannot be performed since the database '" + $targetDatabase +"' is in a replication relationship."
        Assert-ThrowsContains { Set-AzSqlInstanceLink -InputObject $getLink -ReplicationMode Sync } $exSet2
        Assert-ThrowsContains { Set-AzSqlInstanceLink -ResourceId $linkId -ReplicationMode Async } $exSet2

        # Cleanup link
        $rmLink = Remove-AzSqlInstanceLink -ResourceGroupName $rgName -InstanceName $miName -LinkName $linkName -Force -PassThru
        Write-Debug ('$rmLink is ' + (ConvertTo-Json $rmLink))
        Assert-NotNull $rmLink
        Assert-AreEqual $rmLink.ResourceGroupName $rgName
        Assert-AreEqual $rmLink.InstanceName $miName
        Assert-AreEqual $rmLink.Type $linkType
        Assert-AreEqual $rmLink.Name $linkName
        Assert-AreEqual $rmLink.TargetDatabase $targetDatabase
        Assert-AreEqual $rmLink.SourceEndpoint $sourceEndpoint
        Assert-AreEqual $rmLink.ReplicationMode Async
        Assert-AreEqual $rmLink.Id $linkId
        
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
    Tests creating a managed instance link
#>
function Test-ManagedInstanceLinkPiping
{
    try
    {
        # Setup
        $rg = Create-ResourceGroupForTest
        $managedInstance = Create-ManagedInstanceForTest $rg
        $rgName = $rg.ResourceGroupName
        $miName = $managedInstance.ManagedInstanceName

        $instance = Get-AzSqlInstance -ResourceGroupName $rgName -Name $miName
        #temp cleanup
        #try { $instance | Get-AzSqlInstanceLink | Remove-AzSqlInstanceLink -Force } catch { }
        
        # Upsert and get with parent instance Piping
        $upsertJ = $instance | New-AzSqlInstanceLink -LinkName $linkNamePipe -PrimaryAvailabilityGroupName $primaryAGNamePipe -SecondaryAvailabilityGroupName $secondaryAGNamePipe -TargetDatabase $targetDatabasePipe -SourceEndpoint $sourceEndpointPipe -AsJob
        
        # wait a little bit for the link resource to be created
        Wait-Seconds 60
        $listResp = $instance | Get-AzSqlInstanceLink
        Write-Debug ('$listLinksZero is ' + (ConvertTo-Json $listResp))
        Assert-AreEqual $listResp.Count 1 # if this fails during recording, please increase Wait-Seconds duration (3 lines above)

        $getLink = $instance | Get-AzSqlInstanceLink -LinkName $linkNamePipe
        Write-Debug ('$getLink is ' + (ConvertTo-Json $getLink))
        Assert-NotNull $getLink
        
        # validate forbidden updates in current link state
        $exSet2 = "The operation cannot be performed since the database '" + $targetDatabasePipe +"' is in a replication relationship."
        Assert-ThrowsContains { $getLink | Set-AzSqlInstanceLink -ReplicationMode Sync } $exSet2
        Assert-ThrowsContains { $getLink | Set-AzSqlInstanceLink -ReplicationMode Async } $exSet2

        # validate delete pipe working
        $removeCertCollectionPipe = $getLink | Remove-AzSqlInstanceLink -Force -PassThru
        Write-Debug ('$removeCertCollectionPipe is ' + (ConvertTo-Json $removeCertCollectionPipe))
        Assert-NotNull $removeCertCollectionPipe
    }
    finally
    {
        Remove-ResourceGroupForTest $rg
    }
}