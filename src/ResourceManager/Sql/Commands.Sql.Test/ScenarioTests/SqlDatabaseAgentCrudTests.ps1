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
	Tests creating an agent using default parameters
    .DESCRIPTION
	SmokeTest
#>
function Test-CreateAgent
{
    # Setup
    $rg1 = Create-ResourceGroupForTest
    $s1 = Create-ServerForTest $rg1 "westus2"
    $db1 = Create-DatabaseForTest $s1
    $db2 = Create-DatabaseForTest $s1
    $db3 = Create-DatabaseForTest $s1
    $db4 = Create-DatabaseForTest $s1
    $agentName1 = Get-AgentName
    $agentName2 = Get-AgentName
    $agentName3 = Get-AgentName
    $agentName4 = Get-AgentName

    try 
    {
        # Test using default parameters
    	$resp1 = New-AzureRmSqlDatabaseAgent -ResourceGroupName $rg1.ResourceGroupName -ServerName $s1.ServerName -DatabaseName $db1.DatabaseName -AgentName $agentName1

        Assert-AreEqual $resp1.AgentName $agentName1
        Assert-AreEqual $resp1.ServerName $s1.ServerName
        Assert-AreEqual $resp1.DatabaseName $db1.DatabaseName
        Assert-AreEqual $resp1.ResourceGroupName $rg1.ResourceGroupName
        Assert-AreEqual $resp1.Location $s1.Location
        Assert-AreEqual $resp1.WorkerCount 100

        # Test using input object
        $resp2 = New-AzureRmSqlDatabaseAgent -InputObject $db2 -Name $agentName2

        Assert-AreEqual $resp2.AgentName $agentName2
        Assert-AreEqual $resp2.ServerName $s1.ServerName
        Assert-AreEqual $resp2.DatabaseName $db2.DatabaseName
        Assert-AreEqual $resp2.ResourceGroupName $rg1.ResourceGroupName
        Assert-AreEqual $resp2.Location $s1.Location
        Assert-AreEqual $resp2.WorkerCount 100

        # Test using resource id
        $resp3 = New-AzureRmSqlDatabaseAgent -ResourceId $db3.ResourceId -Name $agentName3

        Assert-AreEqual $resp3.AgentName $agentName3
        Assert-AreEqual $resp3.ServerName $s1.ServerName
        Assert-AreEqual $resp3.DatabaseName $db3.DatabaseName
        Assert-AreEqual $resp3.ResourceGroupName $rg1.ResourceGroupName
        Assert-AreEqual $resp3.Location $s1.Location
        Assert-AreEqual $resp3.WorkerCount 100

        # Test piping - Create using piping
        $resp4 = $db4 | New-AzureRmSqlDatabaseAgent -Name $agentName4

        Assert-AreEqual $resp4.AgentName $agentName4
        Assert-AreEqual $resp4.ServerName $s1.ServerName
        Assert-AreEqual $resp4.DatabaseName $db4.DatabaseName
        Assert-AreEqual $resp4.ResourceGroupName $rg1.ResourceGroupName
        Assert-AreEqual $resp4.Location $s1.Location
        Assert-AreEqual $resp4.WorkerCount 100
    }
    finally
    {
        Remove-ResourceGroupForTest $rg1
    }
}

<#
	.SYNOPSIS
	Tests updating an agent
    .DESCRIPTION
	SmokeTest
#>
function Test-UpdateAgent
{
    # Setup
    $rg1 = Create-ResourceGroupForTest
    $s1 = Create-ServerForTest $rg1 "westus2"
    $db1 = Create-DatabaseForTest $s1
    $a1 = Create-AgentForTest $db1

    $tags1 = @{ Dept="Finance"; AnotherTag="WOOHOO" }
    $tags2 = @{ Dept="CS" }
    $tags3 = @{ Job="Agent"}
    $tags4 = @{ Octopus="Agent"}

    try
    {
        # Test using default parameters
    	$resp1 = Set-AzureRmSqlDatabaseAgent -ResourceGroupName $rg1.ResourceGroupName -ServerName $s1.ServerName -AgentName $a1.AgentName -Tag $tags1

        Assert-AreEqual $resp1.AgentName $a1.AgentName
        Assert-AreEqual $resp1.ServerName $s1.ServerName
        Assert-AreEqual $resp1.DatabaseName $db1.DatabaseName
        Assert-AreEqual $resp1.ResourceGroupName $rg1.ResourceGroupName
        Assert-AreEqual $resp1.Location $s1.Location
        Assert-AreEqual $resp1.WorkerCount 100
        Assert-AreEqual $resp1.Tags.Dept "Finance"
        Assert-AreEqual $resp1.Tags.AnotherTag "WOOHOO"

        # Test using input object
        $resp2 = Set-AzureRmSqlDatabaseAgent -InputObject $a1 -Tag $tags2

        Assert-AreEqual $resp2.AgentName $a1.AgentName
        Assert-AreEqual $resp2.ServerName $s1.ServerName
        Assert-AreEqual $resp2.DatabaseName $db1.DatabaseName
        Assert-AreEqual $resp2.ResourceGroupName $rg1.ResourceGroupName
        Assert-AreEqual $resp2.Location $s1.Location
        Assert-AreEqual $resp2.WorkerCount 100
        Assert-AreEqual $resp2.Tags.Dept "CS"
        Assert-Null $resp2.AnotherTag
        
        # Test using resource id
        $resp3 = Set-AzureRmSqlDatabaseAgent -ResourceId $a1.ResourceId -Tag $tags3

        Assert-AreEqual $resp3.AgentName $a1.AgentName
        Assert-AreEqual $resp3.ServerName $s1.ServerName
        Assert-AreEqual $resp3.DatabaseName $db1.DatabaseName
        Assert-AreEqual $resp3.ResourceGroupName $rg1.ResourceGroupName
        Assert-AreEqual $resp3.Location $s1.Location
        Assert-AreEqual $resp3.WorkerCount 100
        Assert-AreEqual $resp3.Tags.Job "Agent"

        # Test using piping
        $resp4 = $a1 | Set-AzureRmSqlDatabaseAgent -Tag $tags4

        Assert-AreEqual $resp4.AgentName $a1.AgentName
        Assert-AreEqual $resp4.ServerName $s1.ServerName
        Assert-AreEqual $resp4.DatabaseName $db1.DatabaseName
        Assert-AreEqual $resp4.ResourceGroupName $rg1.ResourceGroupName
        Assert-AreEqual $resp4.Location $s1.Location
        Assert-AreEqual $resp4.WorkerCount 100
        Assert-AreEqual $resp4.Tags.Octopus "Agent"
    }
    finally
    {
        Remove-ResourceGroupForTest $rg1
    }
}

<#
	.SYNOPSIS
	Tests getting an agent
    .DESCRIPTION
	SmokeTest
#>
function Test-GetAgent
{
    # Setup
    $rg1 = Create-ResourceGroupForTest
    $s1 = Create-ServerForTest $rg1 "westus2"
    $s2 = Create-ServerForTest $rg1 "westus2"
    $db1 = Create-DatabaseForTest $s1
    $db2 = Create-DatabaseForTest $s1
    $db3 = Create-DatabaseForTest $s2
    $a1 = Create-AgentForTest $db1
    $a2 = Create-AgentForTest $db2
    $a3 = Create-AgentForTest $db3
    
    try {
        # Test using default parameters
        $resp1 = Get-AzureRmSqlDatabaseAgent -ResourceGroupName $rg1.ResourceGroupName -ServerName $s1.ServerName -AgentName $a1.AgentName

        Assert-AreEqual $resp1.AgentName $a1.AgentName
        Assert-AreEqual $resp1.ServerName $s1.ServerName
        Assert-AreEqual $resp1.DatabaseName $db1.DatabaseName
        Assert-AreEqual $resp1.ResourceGroupName $rg1.ResourceGroupName
        Assert-AreEqual $resp1.Location $s1.Location
        Assert-AreEqual $resp1.WorkerCount 100

        # Test get all agents in s1
        $all = Get-AzureRmSqlDatabaseAgent -ResourceGroupName $rg1.ResourceGroupName -ServerName $s1.ServerName
        Assert-AreEqual 2 $all.Count

        # Test using input object
        $resp2 = Get-AzureRmSqlDatabaseAgent -InputObject $s1 -AgentName $a2.AgentName

        Assert-AreEqual $resp2.AgentName $a2.AgentName
        Assert-AreEqual $resp2.ServerName $s1.ServerName
        Assert-AreEqual $resp2.DatabaseName $db2.DatabaseName
        Assert-AreEqual $resp2.ResourceGroupName $rg1.ResourceGroupName
        Assert-AreEqual $resp2.Location $s1.Location
        Assert-AreEqual $resp2.WorkerCount 100

        # Test get all agents in s1 using input object
        $all = Get-AzureRmSqlDatabaseAgent -InputObject $s1
        Assert-AreEqual 2 $all.Count

        # Test using resource id
        $resp3 = Get-AzureRmSqlDatabaseAgent -ResourceId $s2.ResourceId -AgentName $a3.AgentName

        Assert-AreEqual $resp3.AgentName $a3.AgentName
        Assert-AreEqual $resp3.ServerName $s2.ServerName
        Assert-AreEqual $resp3.DatabaseName $db3.DatabaseName
        Assert-AreEqual $resp3.ResourceGroupName $rg1.ResourceGroupName
        Assert-AreEqual $resp3.Location $s1.Location
        Assert-AreEqual $resp3.WorkerCount 100
        
        # Test get all agents in s2 using resource id
        $all = Get-AzureRmSqlDatabaseAgent -InputObject $s2
        Assert-AreEqual 1 $all.Count

        # Test piping - Get all agents in s1
        $all = $s1 | Get-AzureRmSqlDatabaseAgent
        Assert-AreEqual 2 $all.Count
        
        # Test piping - Get all agents in servers with resource group $rg1
        $all = Get-AzureRmSqlServer -ResourceGroupName $rg1.ResourceGroupName | Get-AzureRmSqlDatabaseAgent
        Assert-AreEqual 3 $all.Count
    }
    finally
    {
    	Remove-ResourceGroupForTest $rg1
    }
}

<#
	.SYNOPSIS
	Tests removing an agent
    .DESCRIPTION
	SmokeTest
#>
function Test-RemoveAgent
{
    # Setup
    $rg1 = Create-ResourceGroupForTest
    $s1 = Create-ServerForTest $rg1 "westus2"
    $db1 = Create-DatabaseForTest $s1
    $db2 = Create-DatabaseForTest $s1
    $db3 = Create-DatabaseForTest $s1
    $db4 = Create-DatabaseForTest $s1
    $a1 = Create-AgentForTest $db1
    $a2 = Create-AgentForTest $db2
    $a3 = Create-AgentForTest $db3
    $a4 = Create-AgentForTest $db4

    try
    {
        # Test using parameters
        $resp1 = Remove-AzureRmSqlDatabaseAgent -ResourceGroupName $rg1.ResourceGroupName -ServerName $s1.ServerName -AgentName $a1.AgentName
        Assert-AreEqual $resp1.AgentName $a1.AgentName
        Assert-AreEqual $resp1.ServerName $s1.ServerName
        Assert-AreEqual $resp1.DatabaseName $db1.DatabaseName
        Assert-AreEqual $resp1.ResourceGroupName $rg1.ResourceGroupName
        Assert-AreEqual $resp1.Location $s1.Location
        Assert-AreEqual $resp1.WorkerCount 100

        # Test using input object
        $resp2 = Remove-AzureRmSqlDatabaseAgent -InputObject $a2
        Assert-AreEqual $resp2.AgentName $a2.AgentName
        Assert-AreEqual $resp2.ServerName $s1.ServerName
        Assert-AreEqual $resp2.DatabaseName $db2.DatabaseName
        Assert-AreEqual $resp2.ResourceGroupName $rg1.ResourceGroupName
        Assert-AreEqual $resp2.Location $s1.Location
        Assert-AreEqual $resp2.WorkerCount 100

        # Test using resource id
        $resp3 = Remove-AzureRmSqlDatabaseAgent -ResourceId $a3.ResourceId
        Assert-AreEqual $resp3.AgentName $a3.AgentName
        Assert-AreEqual $resp3.ServerName $s1.ServerName
        Assert-AreEqual $resp3.DatabaseName $db3.DatabaseName
        Assert-AreEqual $resp3.ResourceGroupName $rg1.ResourceGroupName
        Assert-AreEqual $resp3.Location $s1.Location
        Assert-AreEqual $resp3.WorkerCount 100

        # Test using piping
        $resp4 = $a4 | Remove-AzureRmSqlDatabaseAgent
        Assert-AreEqual $resp4.AgentName $a4.AgentName
        Assert-AreEqual $resp4.ServerName $s1.ServerName
        Assert-AreEqual $resp4.DatabaseName $db4.DatabaseName
        Assert-AreEqual $resp4.ResourceGroupName $rg1.ResourceGroupName
        Assert-AreEqual $resp4.Location $s1.Location
        Assert-AreEqual $resp4.WorkerCount 100
    }
    finally 
    {
        Remove-ResourceGroupForTest $rg1
    }
}