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

# Test constants 
$rgName = "DaniRG"
$boxName = "wwi-2022-sql02"
$miName = "chimera-canary-bc-01"
$linkName = "Link3"
$databaseName = "PS3"
$databases = @($databaseName)
$instanceAgName = "AG_PS3_MI"
$boxAgName = "AG_PS3"
$partnerEndpoint = "tcp://10.0.1.8:5022"
$instanceLinkRole = "Primary"
$failoverMode = "Manual"
$failoverType = "Planned"
$replicationMode = "Async"
$seedingMode = "Automatic"
$primaryRoleConst = "Primary"
$secondaryRoleConst = "Secondary"
$linkType = "Microsoft.Sql/managedInstances/distributedAvailabilityGroups"
$invalidLinkName = "invalid_link_name";
$invalidMIName = "invalid_mi_name"
$empty_database_list = @()

<#
    .SYNOPSIS
    Tests basic Managed Instance Link operations
#>
function Test-ManagedInstanceLinkMIFirstPlannedFailover
{
    try
    {
        $listLinksZero = Get-AzSqlInstanceLink -ResourceGroupName $rgName -InstanceName $miName
        Write-Debug ('Old list is of size: ' + (ConvertTo-Json $listLinksZero))
        Assert-AreEqual $listLinksZero.Count 1

        # Create link
        Write-Debug ('Creating link...')
        $instance = Get-AzSqlInstance -ResourceGroupName $rgName -Name $miName
        New-AzSqlInstanceLink -ResourceGroupName $rgName -InstanceName $miName -LinkName $linkName -Databases $databases -FailoverMode $failoverMode -InstanceAvailabilityGroupName $instanceAgName -InstanceLinkRole $instanceLinkRole -PartnerAvailabilityGroupName $boxAgName -PartnerEndpoint $partnerEndpoint -ReplicationMode $replicationMode -SeedingMode $seedingMode

        $listResp = Get-AzSqlInstanceLink -ResourceGroupName $rgName -InstanceName $miName
        Write-Debug ('$New list is of size: ' + (ConvertTo-Json $listResp))
        Assert-AreEqual $listResp.Count 2

        # Assert that box is secondary
        $linkToFailover = Get-AzSqlInstanceLink -ResourceGroupName $rgName -InstanceName $miName -Name $linkName
        Assert-AreEqual $linkToFailover.PartnerLinkRole $secondaryRoleConst

        # Perform planned failover
        Start-AzSqlInstanceLinkFailover -ResourceGroupName $rgName -InstanceName $miName -Name $linkName -FailoverType $failoverType

        # Assert that box is primary
        $linkToFailover = Get-AzSqlInstanceLink -ResourceGroupName $rgName -InstanceName $miName -Name $linkName
        Assert-AreEqual $linkToFailover.PartnerLinkRole $primaryRoleConst
    }
    finally
    {
        Remove-AzSqlInstanceLink -ResourceGroupName $rgName -InstanceName $miName -LinkName $linkName -Force -PassThru
    }
}

<#
    .SYNOPSIS
    Tests basic Managed Instance Link operations with parent object parameter set
#>
function Test-ManagedInstanceLinkMIFirstForcedFailover
{
    try
    {
        $failoverType = "ForcedAllowDataLoss"

        $instance = Get-AzSqlInstance -ResourceGroupName $rgName -Name $miName
        $listLinksZero = $instance | Get-AzSqlInstanceLink
        Write-Debug ('Old list is of size: ' + (ConvertTo-Json $listLinksZero))
        Assert-AreEqual $listLinksZero.Count 1

        # Create link
        Write-Debug ('Creating link...')
        $instance | New-AzSqlInstanceLink -LinkName $linkName -Databases $databases -FailoverMode $failoverMode -InstanceAvailabilityGroupName $instanceAgName -InstanceLinkRole $instanceLinkRole -PartnerAvailabilityGroupName $boxAgName -PartnerEndpoint $partnerEndpoint -ReplicationMode $replicationMode -SeedingMode $seedingMode

        $listResp = $instance | Get-AzSqlInstanceLink
        Write-Debug ('$New list is of size: ' + (ConvertTo-Json $listResp))
        Assert-AreEqual $listResp.Count 2

        # Assert that box is secondary
        $linkToFailover = $instance | Get-AzSqlInstanceLink -Name $linkName
        Assert-AreEqual $linkToFailover.PartnerLinkRole $secondaryRoleConst

        # Perform planned failover
        $instance | Start-AzSqlInstanceLinkFailover -Name $linkName -FailoverType $failoverType -Force

        # Assert that box is primary
        $linkToFailover = $instance | Get-AzSqlInstanceLink -Name $linkName
        Assert-AreEqual $linkToFailover.PartnerLinkRole $primaryRoleConst
    }
    finally
    {
        $linkToFailover | Remove-AzSqlInstanceLink -Force -PassThru
    }
}

<#
    .SYNOPSIS
    Tests basic Managed Instance Link operations
#>
function Test-ManagedInstanceLinkTargetDatabaseParameter
{
    try
    {
        $instance = Get-AzSqlInstance -ResourceGroupName $rgName -Name $miName
        $listLinksZero = $instance | Get-AzSqlInstanceLink
        Write-Debug ('Old list is of size: ' + (ConvertTo-Json $listLinksZero))
        Assert-AreEqual $listLinksZero.Count 1

        # Create link
        Write-Debug ('Creating link...')
        $instance | New-AzSqlInstanceLink -LinkName $linkName -TargetDatabase $databaseName -FailoverMode $failoverMode -InstanceAvailabilityGroupName $instanceAgName -InstanceLinkRole $instanceLinkRole -PartnerAvailabilityGroupName $boxAgName -PartnerEndpoint $partnerEndpoint -ReplicationMode $replicationMode -SeedingMode $seedingMode
        $instanceId = $instance.Id
        $linkId = $instanceId + "/distributedAvailabilityGroups/" + $linkName

        $listResp = $instance | Get-AzSqlInstanceLink
        Write-Debug ('$New list is of size: ' + (ConvertTo-Json $listResp))
        Assert-AreEqual $listResp.Count 2

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
        Assert-AreEqual $getLinkByNameParameterSet.Id $instanceId
        Assert-AreEqual $getLinkByNameParameterSet.Name $linkName
        Assert-AreEqual $getLinkByNameParameterSet.Databases[0].DatabaseName $databases[0]
        Assert-AreEqual $getLinkByNameParameterSet.ReplicationMode $replicationMode
        Assert-AreEqual $getLinkByNameParameterSet.InstanceLinkRole $instanceLinkRole
        Assert-AreEqual $getLinkByNameParameterSet.PartnerEndpoint $partnerEndpoint
        Assert-AreEqual $getLinkByNameParameterSet.InstanceAvailabilityGroupName $instanceAgName
        Assert-AreEqual $getLinkByNameParameterSet.PartnerAvailabilityGroupName $boxAgName
        Assert-AreEqual $getLinkByNameParameterSet.SeedingMode $seedingMode
        Assert-AreEqual $getLinkByNameParameterSet.FailoverMode $failoverMode
        Assert-AreEqual $getLinkByNameParameterSet.PartnerAvailabilityGroupName $boxAgName

        # Get the created link - (GetByParentObjectParameterSet)
        $getLinkByParentObjectParameterSet = Get-AzSqlInstanceLink -InstanceObject $instance -LinkName $linkName
        Write-Debug ('$getLinkByParentObjectParameterSet is ' + (ConvertTo-Json $getLinkByParentObjectParameterSet))
        Assert-NotNull $getLinkByParentObjectParameterSet
        Assert-AreEqual $getLinkByParentObjectParameterSet.ResourceGroupName $rgName
        Assert-AreEqual $getLinkByParentObjectParameterSet.InstanceName $miName
        Assert-AreEqual $getLinkByParentObjectParameterSet.Type $linkType
        Assert-AreEqual $getLinkByParentObjectParameterSet.Id $instanceId
        Assert-AreEqual $getLinkByParentObjectParameterSet.Name $linkName
        Assert-AreEqual $getLinkByParentObjectParameterSet.Databases[0].DatabaseName $databases[0]
        Assert-AreEqual $getLinkByParentObjectParameterSet.ReplicationMode $replicationMode
        Assert-AreEqual $getLinkByParentObjectParameterSet.InstanceLinkRole $instanceLinkRole
        Assert-AreEqual $getLinkByParentObjectParameterSet.PartnerEndpoint $partnerEndpoint
        Assert-AreEqual $getLinkByParentObjectParameterSet.InstanceAvailabilityGroupName $instanceAgName
        Assert-AreEqual $getLinkByParentObjectParameterSet.PartnerAvailabilityGroupName $boxAgName
        Assert-AreEqual $getLinkByParentObjectParameterSet.SeedingMode $seedingMode
        Assert-AreEqual $getLinkByParentObjectParameterSet.FailoverMode $failoverMode
        Assert-AreEqual $getLinkByParentObjectParameterSet.PartnerAvailabilityGroupName $boxAgName

        # Get the created link - (GetByResourceIdParameterSet)
        $getLinkByResourceIdParameterSet = Get-AzSqlInstanceLink -ResourceId $linkId
        Write-Debug ('$getLinkByResourceIdParameterSet is ' + (ConvertTo-Json $getLinkByResourceIdParameterSet))
        Assert-NotNull $getLinkByResourceIdParameterSet
        Assert-AreEqual $getLinkByResourceIdParameterSet.ResourceGroupName $rgName
        Assert-AreEqual $getLinkByResourceIdParameterSet.InstanceName $miName
        Assert-AreEqual $getLinkByResourceIdParameterSet.Type $linkType
        Assert-AreEqual $getLinkByResourceIdParameterSet.Id $instanceId
        Assert-AreEqual $getLinkByResourceIdParameterSet.Name $linkName
        Assert-AreEqual $getLinkByResourceIdParameterSet.Databases[0].DatabaseName $databases[0]
        Assert-AreEqual $getLinkByResourceIdParameterSet.ReplicationMode $replicationMode
        Assert-AreEqual $getLinkByResourceIdParameterSet.InstanceLinkRole $instanceLinkRole
        Assert-AreEqual $getLinkByResourceIdParameterSet.PartnerEndpoint $partnerEndpoint
        Assert-AreEqual $getLinkByResourceIdParameterSet.InstanceAvailabilityGroupName $instanceAgName
        Assert-AreEqual $getLinkByResourceIdParameterSet.PartnerAvailabilityGroupName $boxAgName
        Assert-AreEqual $getLinkByResourceIdParameterSet.SeedingMode $seedingMode
        Assert-AreEqual $getLinkByResourceIdParameterSet.FailoverMode $failoverMode
        Assert-AreEqual $getLinkByResourceIdParameterSet.PartnerAvailabilityGroupName $boxAgName

        # Get the created link - (GetByInstanceResourceIdParameterSet)
        $getLinkByInstanceResourceIdParameterSet = Get-AzSqlInstanceLink -InstanceResourceId $instanceId -LinkName $linkName
        Write-Debug ('$getLinkByInstanceResourceIdParameterSet is ' + (ConvertTo-Json $getLinkByInstanceResourceIdParameterSet))
        Assert-NotNull $getLinkByInstanceResourceIdParameterSet
        Assert-AreEqual $getLinkByInstanceResourceIdParameterSet.ResourceGroupName $rgName
        Assert-AreEqual $getLinkByInstanceResourceIdParameterSet.InstanceName $miName
        Assert-AreEqual $getLinkByInstanceResourceIdParameterSet.Type $linkType
        Assert-AreEqual $getLinkByInstanceResourceIdParameterSet.Id $instanceId
        Assert-AreEqual $getLinkByInstanceResourceIdParameterSet.Name $linkName
        Assert-AreEqual $getLinkByInstanceResourceIdParameterSet.Databases[0].DatabaseName $databases[0]
        Assert-AreEqual $getLinkByInstanceResourceIdParameterSet.ReplicationMode $replicationMode
        Assert-AreEqual $getLinkByInstanceResourceIdParameterSet.InstanceLinkRole $instanceLinkRole
        Assert-AreEqual $getLinkByInstanceResourceIdParameterSet.PartnerEndpoint $partnerEndpoint
        Assert-AreEqual $getLinkByInstanceResourceIdParameterSet.InstanceAvailabilityGroupName $instanceAgName
        Assert-AreEqual $getLinkByInstanceResourceIdParameterSet.PartnerAvailabilityGroupName $boxAgName
        Assert-AreEqual $getLinkByInstanceResourceIdParameterSet.SeedingMode $seedingMode
        Assert-AreEqual $getLinkByInstanceResourceIdParameterSet.FailoverMode $failoverMode
        Assert-AreEqual $getLinkByInstanceResourceIdParameterSet.PartnerAvailabilityGroupName $boxAgName
    }
    finally
    {
        $instance| Remove-AzSqlInstanceLink -LinkName $linkName -Force -PassThru
    }
}

<#
    .SYNOPSIS
    Tests basic Managed Instance Link operations box first
#>
function Test-ManagedInstanceLinkBOXFirstForcedFailover
{
    try
    {
        $instanceLinkRole = "Secondary"
        $failoverType = "ForcedAllowDataLoss"
        $linkName = "Link4"
        $databaseName = "PS4"
        $databases = @($databaseName)
        $instanceAgName = "AG_PS4_MI"
        $boxAgName = "AG_PS4"

        $instance = Get-AzSqlInstance -ResourceGroupName $rgName -Name $miName
        $listLinksZero = $instance | Get-AzSqlInstanceLink
        Write-Debug ('Old list is of size: ' + (ConvertTo-Json $listLinksZero))
        Assert-AreEqual $listLinksZero.Count 1

        # Create link
        Write-Debug ('Creating link...')
        New-AzSqlInstanceLink -ResourceGroupName $rgName -InstanceName $miName -LinkName $linkName -TargetDatabase $databaseName -FailoverMode $failoverMode -InstanceAvailabilityGroupName $instanceAgName -InstanceLinkRole $instanceLinkRole -PartnerAvailabilityGroupName $boxAgName -PartnerEndpoint $partnerEndpoint -ReplicationMode $replicationMode -SeedingMode $seedingMode

        $listResp = $instance | Get-AzSqlInstanceLink
        Write-Debug ('$New list is of size: ' + (ConvertTo-Json $listResp))
        Assert-AreEqual $listResp.Count 2

        # Assert that box is primary
        $linkToFailover = $instance | Get-AzSqlInstanceLink -Name $linkName
        Assert-AreEqual $linkToFailover.PartnerLinkRole $primaryRoleConst

        # Perform forced failover and succeed
        $instance | Start-AzSqlInstanceLinkFailover -Name $linkName -FailoverType $failoverType -Force

        # Assert that box is secondary
        $linkToFailover = $instance | Get-AzSqlInstanceLink -Name $linkName
        Assert-AreEqual $linkToFailover.PartnerLinkRole $secondaryRoleConst
    }
    finally
    {
        Remove-AzSqlInstanceLink -ResourceGroupName $rgName -InstanceName $miName -LinkName $linkName -Force -PassThru
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
        $instance = Get-AzSqlInstance -ResourceGroupName $rgName -Name $miName

        # Test required args validation
        $msgExc = "Cannot validate argument on parameter"
        Assert-ThrowsContains { New-AzSqlInstanceLink -ResourceGroupName "" -InstanceName $miName -LinkName $linkName -TargetDatabase $databaseName -FailoverMode $failoverMode -InstanceAvailabilityGroupName $instanceAgName -InstanceLinkRole $instanceLinkRole -PartnerAvailabilityGroupName $boxAgName -PartnerEndpoint $partnerEndpoint -ReplicationMode $replicationMode -SeedingMode $seedingMode  } $msgExc
        Assert-ThrowsContains { New-AzSqlInstanceLink -ResourceGroupName $rgName -InstanceName "" -LinkName $linkName -TargetDatabase $databaseName -FailoverMode $failoverMode -InstanceAvailabilityGroupName $instanceAgName -InstanceLinkRole $instanceLinkRole -PartnerAvailabilityGroupName $boxAgName -PartnerEndpoint $partnerEndpoint -ReplicationMode $replicationMode -SeedingMode $seedingMode  } $msgExc
        Assert-ThrowsContains { New-AzSqlInstanceLink -ResourceGroupName $rgName -InstanceName $miName -LinkName "" -TargetDatabase $databaseName -FailoverMode $failoverMode -InstanceAvailabilityGroupName $instanceAgName -InstanceLinkRole $instanceLinkRole -PartnerAvailabilityGroupName $boxAgName -PartnerEndpoint $partnerEndpoint -ReplicationMode $replicationMode -SeedingMode $seedingMode  } $msgExc
        Assert-ThrowsContains { New-AzSqlInstanceLink -ResourceGroupName $rgName -InstanceName $miName -LinkName $linkName -Databases $empty_database_list -FailoverMode $failoverMode -InstanceAvailabilityGroupName $instanceAgName -InstanceLinkRole $instanceLinkRole -PartnerAvailabilityGroupName $boxAgName -PartnerEndpoint $partnerEndpoint -ReplicationMode $replicationMode -SeedingMode $seedingMode  } $msgExc
        Assert-ThrowsContains { New-AzSqlInstanceLink -ResourceGroupName $rgName -InstanceName $miName -LinkName $linkName -Databases $databases -FailoverMode "" -InstanceAvailabilityGroupName $instanceAgName -InstanceLinkRole $instanceLinkRole -PartnerAvailabilityGroupName $boxAgName -PartnerEndpoint $partnerEndpoint -ReplicationMode $replicationMode -SeedingMode $seedingMode  } $msgExc
        Assert-ThrowsContains { New-AzSqlInstanceLink -ResourceGroupName $rgName -InstanceName $miName -LinkName $linkName -Databases $databases -FailoverMode $failoverMode -InstanceAvailabilityGroupName "" -InstanceLinkRole $instanceLinkRole -PartnerAvailabilityGroupName $boxAgName -PartnerEndpoint $partnerEndpoint -ReplicationMode $replicationMode -SeedingMode $seedingMode  } $msgExc
        Assert-ThrowsContains { New-AzSqlInstanceLink -ResourceGroupName $rgName -InstanceName $miName -LinkName $linkName -Databases $databases -FailoverMode $failoverMode -InstanceAvailabilityGroupName $instanceAgName -InstanceLinkRole "" -PartnerAvailabilityGroupName $boxAgName -PartnerEndpoint $partnerEndpoint -ReplicationMode $replicationMode -SeedingMode $seedingMode  } $msgExc
        Assert-ThrowsContains { New-AzSqlInstanceLink -ResourceGroupName $rgName -InstanceName $miName -LinkName $linkName -Databases $databases -FailoverMode $failoverMode -InstanceAvailabilityGroupName $instanceAgName -InstanceLinkRole $instanceLinkRole -PartnerAvailabilityGroupName "" -PartnerEndpoint $partnerEndpoint -ReplicationMode $replicationMode -SeedingMode $seedingMode  } $msgExc
        Assert-ThrowsContains { New-AzSqlInstanceLink -ResourceGroupName $rgName -InstanceName $miName -LinkName $linkName -Databases $databases -FailoverMode $failoverMode -InstanceAvailabilityGroupName $instanceAgName -InstanceLinkRole $instanceLinkRole -PartnerAvailabilityGroupName $boxAgName -PartnerEndpoint "" -ReplicationMode $replicationMode -SeedingMode $seedingMode  } $msgExc
        Assert-ThrowsContains { New-AzSqlInstanceLink -ResourceGroupName $rgName -InstanceName $miName -LinkName $linkName -Databases $databases -FailoverMode $failoverMode -InstanceAvailabilityGroupName $instanceAgName -InstanceLinkRole $instanceLinkRole -PartnerAvailabilityGroupName $boxAgName -PartnerEndpoint $partnerEndpoint -ReplicationMode "" -SeedingMode $seedingMode  } $msgExc
        Assert-ThrowsContains { New-AzSqlInstanceLink -ResourceGroupName $rgName -InstanceName $miName -LinkName $linkName -Databases $databases -FailoverMode $failoverMode -InstanceAvailabilityGroupName $instanceAgName -InstanceLinkRole $instanceLinkRole -PartnerAvailabilityGroupName $boxAgName -PartnerEndpoint $partnerEndpoint -ReplicationMode $replicationMode -SeedingMode "" } $msgExc

        # Should throw when partner endpoint is not in proper format
        $msgExcInvalid = "Invalid value"
        Assert-ThrowsContains { New-AzSqlInstanceLink -ResourceGroupName $rgName -InstanceName $miName -LinkName $linkName -Databases $databases -FailoverMode $failoverMode -InstanceAvailabilityGroupName $instanceAgName -InstanceLinkRole $instanceLinkRole -PartnerAvailabilityGroupName $boxAgName -PartnerEndpoint "invalid_value" -ReplicationMode $replicationMode -SeedingMode $seedingMode } $msgExcInvalid

        # Should throw when deleting non existant mi link
        $msgExcNotFound = "The requested resource of type 'Microsoft.Sql/managedInstances/distributedAvailabilityGroups' with name '" + $invalidLinkName + "' was not found."
        Assert-ThrowsContains { Remove-AzSqlInstanceLink -ResourceGroupName $rgName -InstanceName $miName -LinkName $invalidLinkName -Force} $msgExcNotFound
        
        # Should throw when getting non existant mi link
        Assert-ThrowsContains { Get-AzSqlInstanceLink -ResourceGroupName $rgName -InstanceName $miName -LinkName $invalidLinkName } $msgExcNotFound

        # Should throw when getting links from non-existent managed instance
        $msgInstanceExcNotFound = "The Resource 'Microsoft.Sql/managedInstances/" + $invalidMIName + "' under resource group '" + $rgName + "' was not found. For more details please go to https://aka.ms/ARMResourceNotFoundFix"
        Assert-ThrowsContains { Get-AzSqlInstanceLink -ResourceGroupName $rgName -InstanceName $invalidMIName } $msgInstanceExcNotFound

        # Create new link where BOX is primary
        $instanceLinkRole = "Secondary"
        $failoverType = "Planned"
        $linkName = "Link4"
        $linkName1 = "NewLink"
        $databaseName = "PS4"
        $databases = @($databaseName)
        $instanceAgName = "AG_PS4_MI"
        $boxAgName = "AG_PS4"

        # Create link
        Write-Debug ('Creating link...')
        New-AzSqlInstanceLink -ResourceGroupName $rgName -InstanceName $miName -LinkName $linkName -TargetDatabase $databaseName -FailoverMode $failoverMode -InstanceAvailabilityGroupName $instanceAgName -InstanceLinkRole $instanceLinkRole -PartnerAvailabilityGroupName $boxAgName -PartnerEndpoint $partnerEndpoint -ReplicationMode $replicationMode -SeedingMode $seedingMode

        # Try creating another link with same parameters
        $msgExcCreatingLink = "Choose a different database name"
        Assert-ThrowsContains { New-AzSqlInstanceLink -ResourceGroupName $rgName -InstanceName $miName -LinkName $linkName1 -TargetDatabase $databaseName -FailoverMode $failoverMode -InstanceAvailabilityGroupName $instanceAgName -InstanceLinkRole $instanceLinkRole -PartnerAvailabilityGroupName $boxAgName -PartnerEndpoint $partnerEndpoint -ReplicationMode $replicationMode -SeedingMode $seedingMode } $msgExcCreatingLink

        # Start failover and assert that the planned failover can't be invoked when MI is secondary
        $msgExcCantFailover = "Planned failover can be executed on a link in the primary role only. Current state of the specified link is secondary."
        Assert-ThrowsContains { Start-AzSqlInstanceLinkFailover -ResourceGroupName $rgName -InstanceName $miName -Name $linkName -FailoverType $failoverType -Force } $msgExcCantFailover

        # Confirm that ShouldContinue message is triggered on Remove (tests don't support user interaction so we'll validate the exception)
        $msgExcDataLoss = "may cause data loss"
        Assert-ThrowsContains { Remove-AzSqlInstanceLink -ResourceGroupName $rgName -InstanceName $miName -Name $invalidLinkName } $msgExcDataLoss

        # Should throw when setting non existant mi link
        $msgExcNotFound = "The requested resource of type 'Microsoft.Sql/managedInstances/distributedAvailabilityGroups' with name '" + $invalidLinkName + "' was not found."
        Assert-ThrowsContains { Set-AzSqlInstanceLink -ResourceGroupName $rgName -InstanceName $miName -LinkName $invalidLinkName -ReplicationMode sync } $msgExcNotFound

        # Should throw when setting non existant replication mode value
        $msgExcNotFound = "segment in the url is invalid"
        Assert-ThrowsContains { Set-AzSqlInstanceLink -ResourceGroupName $rgName -InstanceName $miName -LinkName $linkName -ReplicationMode synca } $msgExcNotFound
    }
    finally
    {
        Remove-AzSqlInstanceLink -ResourceGroupName $rgName -InstanceName $miName -LinkName $linkName -Force -PassThru
    }
}