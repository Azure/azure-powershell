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
	Tests creating an agent
    .DESCRIPTION
	SmokeTest
#>
function Test-CreateAgent
{
    # Setup
    $rg = Create-ResourceGroupForTest
    $server = Create-ServerForTest $rg "westus2"
    $db = Create-DatabaseForTest $rg $server "db1"
    $agentName = "agent1"

    try 
    {
    	$agent = New-AzureRmSqlDatabaseAgent -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -DatabaseName $db.DatabaseName -AgentName $agentName

        # Default create agent
        Assert-AreEqual $agent.AgentName $agentName
        Assert-AreEqual $agent.ServerName $server.ServerName
        Assert-AreEqual $agent.DatabaseName $db.DatabaseName
        Assert-AreEqual $agent.ResourceGroupName $rg.ResourceGroupName
        Assert-AreEqual $agent.Location $server.Location
        Assert-AreEqual $agent.WorkerCount 100
    }
    finally
    {
        Remove-ResourceGroupForTest $rg
    }
}

function Test-CreateAgentWithWorkerCount
{
    # Setup
    $rg = Create-ResourceGroupForTest
    $server = Create-ServerForTest $rg "westus2"
    $db = Create-DatabaseForTest $rg $server "db1"
    $agentName = "agent1"
    $agentWorkerCount = 200

    try 
    {
    	$agent = New-AzureRmSqlDatabaseAgent -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -DatabaseName $db.DatabaseName -AgentName $agentName -WorkerCount $agentWorkerCount

        Assert-AreEqual $agent.AgentName $agentName
        Assert-AreEqual $agent.ServerName $server.ServerName
        Assert-AreEqual $agent.DatabaseName $db.DatabaseName
        Assert-AreEqual $agent.ResourceGroupName $rg.ResourceGroupName
        Assert-AreEqual $agent.Location $server.Location
        Assert-AreEqual $agent.WorkerCount $agentWorkerCount
    }
    finally
    {
        Remove-ResourceGroupForTest $rg
    }
}

<#
	.SYNOPSIS
	Tests getting one or more agents
    .DESCRIPTION
	SmokeTest
#>
function Test-GetAgent
{
    # Setup
    $rg = Create-ResourceGroupForTest
    $server = Create-ServerForTest $rg "westus2"
    $db1 = Create-DatabaseForTest $rg $server "db1"
    $agent1 = Create-AgentForTest $rg $server $db1 "agent1"
    
    try {
        $resp1 = Get-AzureRmSqlDatabaseAgent -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -AgentName $agent1.AgentName
        Assert-AreEqual $resp1.AgentName $agent1.AgentName
        Assert-AreEqual $resp1.ServerName $server.ServerName
        Assert-AreEqual $resp1.DatabaseName $db1.DatabaseName
        Assert-AreEqual $resp1.ResourceGroupName $rg.ResourceGroupName
        Assert-AreEqual $resp1.Location $server.Location
        Assert-AreEqual $resp1.WorkerCount 100
    }
    finally
    {
    	Remove-ResourceGroupForTest $rg
    }
}

<#
	.SYNOPSIS
	Tests updating Azure SQL Database Agents. TODO: Need to update management client with latest changes
    .DESCRIPTION
	SmokeTest
#>
function Test-UpdateAgent
{
    # Setup
    $rg = Create-ResourceGroupForTest
    $server = Create-ServerForTest $rg "westus2"
    $db1 = Create-DatabaseForTest $rg $server "db1"
    $agent1 = Create-AgentForTest $rg $server $db1 "agent1"

    try 
    {
        Assert-AreEqual $agent1.WorkerCount 100 # Default worker count created
        $agent1 = Set-AzureRmSqlDatabaseAgent -ServerName $server.ServerName -AgentName $agent.AgentName -WorkerCount 200
        
        Assert-AreEqual $resp1.AgentName $agent1.AgentName
        Assert-AreEqual $resp1.ServerName $server.ServerName
        Assert-AreEqual $resp1.DatabaseName $db1.DatabaseName
        Assert-AreEqual $resp1.ResourceGroupName $rg.ResourceGroupName
        Assert-AreEqual $resp1.Location $server.Location
        Assert-AreEqual $resp1.WorkerCount 200
    }
    finally
    {
        Remove-ResourceGroupForTest $rg
    }
}

<#
	.SYNOPSIS
	Tests removing Azure SQL Database Agents
    .DESCRIPTION
	SmokeTest
#>
function Test-RemoveAgent
{
    # Setup
    $rg = Create-ResourceGroupForTest
    $server = Create-ServerForTest $rg "westus2"
    $db1 = Create-DatabaseForTest $rg $server "db1"
    $agent1 = Create-AgentForTest $rg $server $db1 "agent1"

    try
    {
        Remove-AzureRmSqlDatabaseAgent -ResourceGroupName $rg.ResourceGroupName -ServerName $server -AgentName $agent1.AgentName
    }
    finally 
    {
        Remove-ResourceGroupForTest $rg
    }
}