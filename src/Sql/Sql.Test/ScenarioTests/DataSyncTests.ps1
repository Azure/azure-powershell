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
    Tests for creating a sync agent
#>
function Test-CreateSyncAgent
{
    # Setup
    $rg = Create-ResourceGroupForTest
    $server = Create-ServerForTest $rg "West US 2"
    $databaseName = Get-DatabaseName
    $db = New-AzSqlDatabase -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -DatabaseName $databaseName

    try
    {
        # Create a sync agent
        $saName = Get-SyncAgentName
        $sa = New-AzSqlSyncAgent -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName `
                -SyncAgentName $saName -SyncDatabaseResourceGroupName $rg.ResourceGroupName -SyncDatabaseServerName $server.ServerName `
                -SyncDatabaseName $databaseName
        Assert-NotNull $sa
        Assert-AreEqual $saName $sa.SyncAgentName
    }
    finally
    {
        Remove-ResourceGroupForTest $rg
    }
}

<# 
    .SYNOPSIS
    Tests for getting a sync agent and listing all sync agents
#>
function Test-GetAndListSyncAgents
{
    # Setup
    $rg = Create-ResourceGroupForTest
    $server = Create-ServerForTest $rg "West US 2"
    $databaseName = Get-DatabaseName
    $db = New-AzSqlDatabase -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -DatabaseName $databaseName

    # Create a sync agent
    $saName = Get-SyncAgentName
    $sa = New-AzSqlSyncAgent -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName `
            -SyncAgentName $saName -SyncDatabaseResourceGroupName $rg.ResourceGroupName -SyncDatabaseServerName $server.ServerName `
            -SyncDatabaseName $databaseName
    try
    {
        # Get a sync agent
        $sa2 = Get-AzSqlSyncAgent -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -SyncAgentName $saName
        Assert-NotNull $sa2
        Assert-AreEqual $saName $sa2.SyncAgentName

        # Get all sync agents
        $all = Get-AzSqlSyncAgent -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -SyncAgentName *
        Assert-NotNull $all
        Assert-AreEqual $all.Count 1
    }
    finally
    {
        Remove-ResourceGroupForTest $rg
    }
}

<# 
    .SYNOPSIS
    Tests for removing a sync agent
#>
function Test-RemoveSyncAgent
{
    # Setup
    $rg = Create-ResourceGroupForTest
    $server = Create-ServerForTest $rg "West US 2"
    $databaseName = Get-DatabaseName
    $db = New-AzSqlDatabase -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -DatabaseName $databaseName
    $saName = Get-SyncAgentName
    $sa = New-AzSqlSyncAgent -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName `
            -SyncAgentName $saName -SyncDatabaseResourceGroupName $rg.ResourceGroupName -SyncDatabaseServerName $server.ServerName `
            -SyncDatabaseName $databaseName
    try
    {
        # Remove the sync agent
        Remove-AzSqlSyncAgent -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName `
         -SyncAgentName $saName -Force

        $all = Get-AzSqlSyncAgent -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName
        Assert-AreEqual $all.Count 0
    }
    finally
    {
        Remove-ResourceGroupForTest $rg
    }
}

<# 
    .SYNOPSIS
    Tests for generating a sync agent key
#>
function Test-CreateSyncAgentKey
{
    # Setup
    $rg = Create-ResourceGroupForTest
    $server = Create-ServerForTest $rg "West US 2"
    $databaseName = Get-DatabaseName
    $db = New-AzSqlDatabase -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -DatabaseName $databaseName
    $saName = Get-SyncAgentName
    $sa = New-AzSqlSyncAgent -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName `
            -SyncAgentName $saName -SyncDatabaseResourceGroupName $rg.ResourceGroupName -SyncDatabaseServerName $server.ServerName `
            -SyncDatabaseName $databaseName
    try
    {
        # Create the sync agent key
        $key = New-AzSqlSyncAgentKey -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName `
         -SyncAgentName $saName

        Assert-NotNull $key
        Assert-NotNull $key.SyncAgentKey
    }
    finally
    {
        Remove-ResourceGroupForTest $rg
    }
}

<# 
    .SYNOPSIS
    Tests for getting all the databases linked with the specified sync agent
#>
function Test-ListSyncAgentLinkedDatabase
{
    # Setup
    $rg = Create-ResourceGroupForTest
    $server = Create-ServerForTest $rg "West US 2"
    $databaseName = Get-DatabaseName
    $db = New-AzSqlDatabase -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -DatabaseName $databaseName
    $saName = Get-SyncAgentName
    $sa = New-AzSqlSyncAgent -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName `
            -SyncAgentName $saName -SyncDatabaseResourceGroupName $rg.ResourceGroupName -SyncDatabaseServerName $server.ServerName `
            -SyncDatabaseName $databaseName
    try
    {
        # List the sync agent linked database
        $dbs = Get-AzSqlSyncAgentLinkedDatabase -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName `
         -SyncAgentName $saName
        Assert-Null $dbs
    }
    finally
    {
        Remove-ResourceGroupForTest $rg
    }
}

<# 
    .SYNOPSIS
    Tests for creating a sync group
#>
function Test-CreateSyncGroup
{
    # Setup
    $rg = Create-ResourceGroupForTest
    $server = Create-ServerForTest $rg "West US 2"
    $credential = Get-ServerCredential
    $databaseName = Get-DatabaseName
    $db = New-AzSqlDatabase -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -DatabaseName $databaseName
    $syncDatabaseName = Get-DatabaseName
    $syncdb = New-AzSqlDatabase -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -DatabaseName $syncDatabaseName
    $params = Get-SqlSyncGroupTestEnvironmentParameters

    try
    {
        # Create a sync group
        $sgName = Get-SyncGroupName
        $sg = New-AzSqlSyncGroup -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName `
            -DatabaseName $databaseName -SyncGroupName $sgName -IntervalInSeconds $params.intervalInSeconds `
            -ConflictResolutionPolicy $params.conflictResolutionPolicy -SyncDatabaseName $syncDatabaseName -SyncDatabaseServerName `
            $server.ServerName -SyncDatabaseResourceGroupName $rg.ResourceGroupName -DatabaseCredential $credential
        Assert-AreEqual $params.intervalInSeconds $sg.IntervalInSeconds
        Assert-AreEqual $params.conflictResolutionPolicy $sg.ConflictResolutionPolicy
    }
    finally
    {
        Remove-ResourceGroupForTest $rg
    }
}

<# 
    .SYNOPSIS
    Tests for updating a sync group
#>
function Test-UpdateSyncGroup
{
    # Setup
    $rg = Create-ResourceGroupForTest
    $server = Create-ServerForTest $rg "West US 2"
    $credential = Get-ServerCredential
    $databaseName = Get-DatabaseName
    $db = New-AzSqlDatabase -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -DatabaseName $databaseName
    $syncDatabaseName = Get-DatabaseName
    $syncdb = New-AzSqlDatabase -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -DatabaseName $syncDatabaseName
    $params = Get-SqlSyncGroupTestEnvironmentParameters
    # Create a sync group
    $sgName = Get-SyncGroupName
    $sg = New-AzSqlSyncGroup -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName `
        -DatabaseName $databaseName -SyncGroupName $sgName -IntervalInSeconds $params.intervalInSeconds `
        -ConflictResolutionPolicy $params.conflictResolutionPolicy -SyncDatabaseName $syncDatabaseName -SyncDatabaseServerName `
        $server.ServerName -SyncDatabaseResourceGroupName $rg.ResourceGroupName -DatabaseCredential $credential
    try
    {
        # Update a sync group
        $newIntervalInSeconds = 200
        $sg2 = Update-AzSqlSyncGroup -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName `
            -DatabaseName $databaseName -SyncGroupName $sgName -IntervalInSeconds $newIntervalInSeconds 
        Assert-AreEqual $newIntervalInSeconds $sg2.IntervalInSeconds
    }
    finally
    {
        Remove-ResourceGroupForTest $rg
    }
}

<# 
    .SYNOPSIS
    Tests for getting a sync group and listing all sync groups
#>
function Test-GetAndListSyncGroups
{
    # Setup
    $rg = Create-ResourceGroupForTest
    $server = Create-ServerForTest $rg "West US 2"
    $credential = Get-ServerCredential
    $databaseName = Get-DatabaseName
    $db = New-AzSqlDatabase -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -DatabaseName $databaseName
    $syncDatabaseName = Get-DatabaseName
    $syncdb = New-AzSqlDatabase -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -DatabaseName $syncDatabaseName
    $params = Get-SqlSyncGroupTestEnvironmentParameters
    # Create a sync group
    $sgName = Get-SyncGroupName
    $sg = New-AzSqlSyncGroup -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName `
        -DatabaseName $databaseName -SyncGroupName $sgName -IntervalInSeconds $params.intervalInSeconds `
        -ConflictResolutionPolicy $params.conflictResolutionPolicy -SyncDatabaseName $syncDatabaseName -SyncDatabaseServerName `
        $server.ServerName -SyncDatabaseResourceGroupName $rg.ResourceGroupName -DatabaseCredential $credential
    try
    {
        # Get a sync group
        $sg1 = Get-AzSqlSyncGroup -ServerName $server.ServerName -ResourceGroupName $rg.ResourceGroupName `
        -DatabaseName $databaseName -SyncGroupName $sgName
        Assert-AreEqual $params.intervalInSeconds $sg1.IntervalInSeconds
        Assert-AreEqual $params.conflictResolutionPolicy $sg1.ConflictResolutionPolicy

        # List all sync groups
        $all = Get-AzSqlSyncGroup -ServerName $server.ServerName -ResourceGroupName $rg.ResourceGroupName `
        -DatabaseName $databaseName -SyncGroupName *
        Assert-AreEqual $all.Count 1
        Assert-AreEqual $params.intervalInSeconds $all[0].IntervalInSeconds
        Assert-AreEqual $params.conflictResolutionPolicy $all[0].ConflictResolutionPolicy
    }
    finally
    {
        Remove-ResourceGroupForTest $rg
    }
}

<# 
    .SYNOPSIS
    Tests for freshing and getting a sync group schema
#>
function Test-RefreshAndGetSyncGroupHubSchema
{
    # Setup
    $rg = Create-ResourceGroupForTest
    $server = Create-ServerForTest $rg "West US 2"
    $credential = Get-ServerCredential
    $databaseName = Get-DatabaseName
    $db = New-AzSqlDatabase -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -DatabaseName $databaseName
    $syncDatabaseName = Get-DatabaseName
    $syncdb = New-AzSqlDatabase -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -DatabaseName $syncDatabaseName
    $params = Get-SqlSyncGroupTestEnvironmentParameters
    # Create a sync group
    $sgName = Get-SyncGroupName
    $sg = New-AzSqlSyncGroup -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName `
        -DatabaseName $databaseName -SyncGroupName $sgName -IntervalInSeconds $params.intervalInSeconds `
        -ConflictResolutionPolicy $params.conflictResolutionPolicy -SyncDatabaseName $syncDatabaseName -SyncDatabaseServerName `
        $server.ServerName -SyncDatabaseResourceGroupName $rg.ResourceGroupName -DatabaseCredential $credential
    try
    {
        # Refresh hub schema
        Update-AzSqlSyncSchema -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName `
            -DatabaseName $databaseName -SyncGroupName $sgName

        # Get hub schema
        $schema = Get-AzSqlSyncSchema -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName `
            -DatabaseName $databaseName -SyncGroupName $sgName
        Assert-NotNull $schema
    }
    finally
    {
        Remove-ResourceGroupForTest $rg
    }
}

<# 
    .SYNOPSIS
    Tests for removing a sync group
#>
function Test-RemoveSyncGroup
{
    # Setup
    $rg = Create-ResourceGroupForTest
    $server = Create-ServerForTest $rg "West US 2"
    $credential = Get-ServerCredential
    $databaseName = Get-DatabaseName
    $db = New-AzSqlDatabase -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -DatabaseName $databaseName
    $syncDatabaseName = Get-DatabaseName
    $syncdb = New-AzSqlDatabase -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -DatabaseName $syncDatabaseName
    $params = Get-SqlSyncGroupTestEnvironmentParameters
    # Create a sync group
    $sgName = Get-SyncGroupName
    $sg = New-AzSqlSyncGroup -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName `
        -DatabaseName $databaseName -SyncGroupName $sgName -IntervalInSeconds $params.intervalInSeconds `
        -ConflictResolutionPolicy $params.conflictResolutionPolicy -SyncDatabaseName $syncDatabaseName -SyncDatabaseServerName `
        $server.ServerName -SyncDatabaseResourceGroupName $rg.ResourceGroupName -DatabaseCredential $credential
    try
    {
        # Remove sync group
        Remove-AzSqlSyncGroup -ServerName $server.ServerName -ResourceGroupName $rg.ResourceGroupName `
        -DatabaseName $databaseName -SyncGroupName $sgName -Force
        
        $all = Get-AzSqlSyncGroup -ServerName $server.ServerName -ResourceGroupName $rg.ResourceGroupName `
        -DatabaseName $databaseName
        Assert-AreEqual $all.Count 0
    }
    finally
    {
        Remove-ResourceGroupForTest $rg
    }
}

<# 
    .SYNOPSIS
    Tests for creating a sync member
#>
function Test-CreateSyncMember
{
    # Setup
    $rg = Create-ResourceGroupForTest 
    $server = Create-ServerForTest $rg "West US 2"
    $serverDNS = Get-DNSNameBasedOnEnvironment
    $serverName = $server.ServerName + $serverDNS
    $credential = Get-ServerCredential
    $databaseName1 = Get-DatabaseName
    $db1 = New-AzSqlDatabase -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -DatabaseName $databaseName1
    $databaseName2 = Get-DatabaseName
    $db2 = New-AzSqlDatabase -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -DatabaseName $databaseName2
    $syncDatabaseName = Get-DatabaseName
    $syncdb = New-AzSqlDatabase -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -DatabaseName $syncDatabaseName
    
    $params = Get-SqlSyncGroupTestEnvironmentParameters
    $sgName = Get-SyncGroupName
    $sg = New-AzSqlSyncGroup -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName `
                -DatabaseName $databaseName1 -SyncGroupName $sgName -IntervalInSeconds $params.intervalInSeconds `
                -ConflictResolutionPolicy $params.conflictResolutionPolicy -SyncDatabaseName $syncDatabaseName -SyncDatabaseServerName `
                $server.ServerName -SyncDatabaseResourceGroupName $rg.ResourceGroupName -DatabaseCredential $credential

    try
    {
        # Create a sync member 
        $smParams = Get-SqlSyncMemberTestEnvironmentParameters
        $smName = Get-SyncMemberName
        $sm1 = New-AzSqlSyncMember -ServerName $server.ServerName -ResourceGroupName $rg.ResourceGroupName `
            -DatabaseName $databaseName1 -SyncGroupName $sgName -SyncMemberName $smName `
            -SyncDirection $smParams.syncDirection -MemberDatabaseType $smParams.databaseType -MemberDatabaseName $databaseName2 `
            -MemberServerName $serverName -MemberDatabaseCredential $credential
        Assert-AreEqual $smParams.syncDirection $sm1.SyncDirection
        Assert-AreEqual $smParams.databaseType $sm1.MemberDatabaseType
        Assert-AreEqual $databaseName2 $sm1.MemberDatabaseName
        Assert-AreEqual $serverName $sm1.MemberServerName
        Assert-Null $sm1.MemberDatabasePassword
        Assert-Null $sm1.SyncAgentId
        Assert-Null $sm1.SqlServerDatabaseId
    }
    finally
    {
        Remove-ResourceGroupForTest $rg
    }
}

<# 
    .SYNOPSIS
    Tests for getting a sync member and listing all sync members
#>
function Test-GetAndListSyncMembers
{
    # Setup
    $rg = Create-ResourceGroupForTest
    $server = Create-ServerForTest $rg "West US 2"
    $serverDNS = Get-DNSNameBasedOnEnvironment
    $serverName = $server.ServerName + $serverDNS
    $credential = Get-ServerCredential
    $databaseName1 = Get-DatabaseName
    $db1 = New-AzSqlDatabase -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -DatabaseName $databaseName1
    $databaseName2 = Get-DatabaseName
    $db2 = New-AzSqlDatabase -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -DatabaseName $databaseName2
    $syncDatabaseName = Get-DatabaseName
    $syncdb = New-AzSqlDatabase -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -DatabaseName $syncDatabaseName
        
    $params = Get-SqlSyncGroupTestEnvironmentParameters
    $sgName = Get-SyncGroupName
    $sg = New-AzSqlSyncGroup -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName `
                -DatabaseName $databaseName1 -SyncGroupName $sgName -IntervalInSeconds $params.intervalInSeconds `
                -ConflictResolutionPolicy $params.conflictResolutionPolicy -SyncDatabaseName $syncDatabaseName -SyncDatabaseServerName `
                $server.ServerName -SyncDatabaseResourceGroupName $rg.ResourceGroupName -DatabaseCredential $credential
    # Create a sync member 
    $smParams = Get-SqlSyncMemberTestEnvironmentParameters
    $smName = Get-SyncMemberName
    $sm1 = New-AzSqlSyncMember -ServerName $server.ServerName -ResourceGroupName $rg.ResourceGroupName `
        -DatabaseName $databaseName1 -SyncGroupName $sgName -SyncMemberName $smName `
        -SyncDirection $smParams.syncDirection -MemberDatabaseType $smParams.databaseType -MemberDatabaseName $databaseName2 `
        -MemberServerName $serverName -MemberDatabaseCredential $credential
    try
    {
        # Get a sync member
        $sm2 = Get-AzSqlSyncMember -ServerName $server.ServerName -ResourceGroupName $rg.ResourceGroupName `
        -DatabaseName $databaseName1 -SyncGroupName $sg.SyncGroupName -SyncMemberName $smName
        Assert-AreEqual $smParams.syncDirection $sm1.SyncDirection
        Assert-AreEqual $smParams.databaseType $sm1.MemberDatabaseType
        Assert-AreEqual $databaseName2 $sm1.MemberDatabaseName
        Assert-AreEqual $serverName $sm1.MemberServerName
        Assert-Null $sm1.MemberDatabasePassword
        Assert-Null $sm1.SyncAgentId
        Assert-Null $sm1.SqlServerDatabaseId

        # List all sync members
        $all = Get-AzSqlSyncMember -ServerName $server.ServerName -ResourceGroupName $rg.ResourceGroupName `
        -DatabaseName $databaseName1 -SyncGroupName $sg.SyncGroupName -SyncMemberName *
        Assert-AreEqual 1 $all.Count
        Assert-AreEqual $smParams.syncDirection $all[0].SyncDirection
        Assert-AreEqual $smParams.databaseType $all[0].MemberDatabaseType
    }
    finally
    {
        Remove-ResourceGroupForTest $rg
    }
}

<# 
    .SYNOPSIS
    Tests for updating a sync member
#>
function Test-UpdateSyncMember
{
    # Setup
    $rg = Create-ResourceGroupForTest
    $server = Create-ServerForTest $rg "West US 2"
    $serverDNS = Get-DNSNameBasedOnEnvironment
    $serverName = $server.ServerName + $serverDNS
    $credential = Get-ServerCredential
    $databaseName1 = Get-DatabaseName
    $db1 = New-AzSqlDatabase -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -DatabaseName $databaseName1
    $databaseName2 = Get-DatabaseName
    $db2 = New-AzSqlDatabase -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -DatabaseName $databaseName2
    $syncDatabaseName = Get-DatabaseName
    $syncdb = New-AzSqlDatabase -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -DatabaseName $syncDatabaseName
    
    $params = Get-SqlSyncGroupTestEnvironmentParameters
    $sgName = Get-SyncGroupName
    $sg = New-AzSqlSyncGroup -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName `
                -DatabaseName $databaseName1 -SyncGroupName $sgName -IntervalInSeconds $params.intervalInSeconds `
                -ConflictResolutionPolicy $params.conflictResolutionPolicy -SyncDatabaseName $syncDatabaseName -SyncDatabaseServerName `
                $server.ServerName -SyncDatabaseResourceGroupName $rg.ResourceGroupName -DatabaseCredential $credential
    # Create a sync member 
    $smParams = Get-SqlSyncMemberTestEnvironmentParameters
    $smName = Get-SyncMemberName
    $sm1 = New-AzSqlSyncMember -ServerName $server.ServerName -ResourceGroupName $rg.ResourceGroupName `
        -DatabaseName $databaseName1 -SyncGroupName $sgName -SyncMemberName $smName `
        -SyncDirection $smParams.syncDirection -MemberDatabaseType $smParams.databaseType -MemberDatabaseName $databaseName2 `
        -MemberServerName $serverName -MemberDatabaseCredential $credential
    try
    {
        # Update a sync member
        $sm2 = Update-AzSqlSyncMember -ServerName $server.ServerName -ResourceGroupName $rg.ResourceGroupName `
            -DatabaseName $databaseName1 -SyncGroupName $sgName -SyncMemberName $smName `
            -MemberDatabaseCredential $credential
        Assert-AreEqual $smParams.databaseType $sm2.MemberDatabaseType
        Assert-AreEqual $databaseName2 $sm2.MemberDatabaseName
        Assert-AreEqual $serverName $sm2.MemberServerName
        Assert-Null $sm2.MemberDatabasePassword
        Assert-Null $sm2.SyncAgentId
        Assert-Null $sm2.SqlServerDatabaseId
    }
    finally
    {
        Remove-ResourceGroupForTest $rg
    }
}

<# 
    .SYNOPSIS
    Tests for refreshing and getting a sync member schema
#>
function Test-RefreshAndGetSyncMemberSchema
{
    # Setup
    $rg = Create-ResourceGroupForTest
    $server = Create-ServerForTest $rg "West US 2"
    $serverDNS = Get-DNSNameBasedOnEnvironment
    $serverName = $server.ServerName + $serverDNS
    $credential = Get-ServerCredential
    $databaseName1 = Get-DatabaseName
    $db1 = New-AzSqlDatabase -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -DatabaseName $databaseName1
    $databaseName2 = Get-DatabaseName
    $db2 = New-AzSqlDatabase -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -DatabaseName $databaseName2
    $syncDatabaseName = Get-DatabaseName
    $syncdb = New-AzSqlDatabase -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -DatabaseName $syncDatabaseName
    
    $params = Get-SqlSyncGroupTestEnvironmentParameters
    $sgName = Get-SyncGroupName
    $sg = New-AzSqlSyncGroup -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName `
                -DatabaseName $databaseName1 -SyncGroupName $sgName -IntervalInSeconds $params.intervalInSeconds `
                -ConflictResolutionPolicy $params.conflictResolutionPolicy -SyncDatabaseName $syncDatabaseName -SyncDatabaseServerName `
                $server.ServerName -SyncDatabaseResourceGroupName $rg.ResourceGroupName -DatabaseCredential $credential
    # Create a sync member 
    $smParams = Get-SqlSyncMemberTestEnvironmentParameters
    $smName = Get-SyncMemberName
    $sm1 = New-AzSqlSyncMember -ServerName $server.ServerName -ResourceGroupName $rg.ResourceGroupName `
        -DatabaseName $databaseName1 -SyncGroupName $sgName -SyncMemberName $smName `
        -SyncDirection $smParams.syncDirection -MemberDatabaseType $smParams.databaseType -MemberDatabaseName $databaseName2 `
        -MemberServerName $serverName -MemberDatabaseCredential $credential
    try
    {
        # Refresh member schema
        Update-AzSqlSyncSchema -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName `
            -DatabaseName $databaseName1 -SyncGroupName $sgName -SyncMemberName $smName 

        # Get member schema
        $schema = Get-AzSqlSyncSchema -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName `
            -DatabaseName $databaseName1 -SyncGroupName $sgName -SyncMemberName $smName 
        Assert-NotNull $schema
    }
    finally
    {    
        Remove-ResourceGroupForTest $rg
    }
}

<# 
    .SYNOPSIS
    Tests for removing a sync member
#>
function Test-RemoveSyncMember
{
    # Setup
    $rg = Create-ResourceGroupForTest
    $server = Create-ServerForTest $rg "West US 2"
    $serverDNS = Get-DNSNameBasedOnEnvironment
    $serverName = $server.ServerName + $serverDNS
    $credential = Get-ServerCredential
    $databaseName1 = Get-DatabaseName
    $db1 = New-AzSqlDatabase -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -DatabaseName $databaseName1
    $databaseName2 = Get-DatabaseName
    $db2 = New-AzSqlDatabase -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -DatabaseName $databaseName2
    $syncDatabaseName = Get-DatabaseName
    $syncdb = New-AzSqlDatabase -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -DatabaseName $syncDatabaseName
    
    $params = Get-SqlSyncGroupTestEnvironmentParameters
    $sgName = Get-SyncGroupName
    $sg = New-AzSqlSyncGroup -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName `
                -DatabaseName $databaseName1 -SyncGroupName $sgName -IntervalInSeconds $params.intervalInSeconds `
                -ConflictResolutionPolicy $params.conflictResolutionPolicy -SyncDatabaseName $syncDatabaseName -SyncDatabaseServerName `
                $server.ServerName -SyncDatabaseResourceGroupName $rg.ResourceGroupName -DatabaseCredential $credential
    # Create a sync member 
    $smParams = Get-SqlSyncMemberTestEnvironmentParameters
    $smName = Get-SyncMemberName
    $sm1 = New-AzSqlSyncMember -ServerName $server.ServerName -ResourceGroupName $rg.ResourceGroupName `
        -DatabaseName $databaseName1 -SyncGroupName $sgName -SyncMemberName $smName `
        -SyncDirection $smParams.syncDirection -MemberDatabaseType $smParams.databaseType -MemberDatabaseName $databaseName2 `
        -MemberServerName $serverName -MemberDatabaseCredential $credential
    try
    {
        # Delete a sync member
        Remove-AzSqlSyncMember -ServerName $server.ServerName -ResourceGroupName $rg.ResourceGroupName `
        -DatabaseName $databaseName1 -SyncGroupName $sgName -SyncMemberName $smName -Force
        
        $all = Get-AzSqlSyncMember -ServerName $server.ServerName -ResourceGroupName $rg.ResourceGroupName `
        -DatabaseName $databaseName1 -SyncGroupName $sgName
        Assert-AreEqual $all.Count 0
    }
    finally
    {
        Remove-ResourceGroupForTest $rg
    }
}