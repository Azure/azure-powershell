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
#>
function Test-CreateAgent
{
    # Setup
    $location = Get-Location "Microsoft.Sql" "operations" "West US 2"
    $rg1 = Create-ResourceGroupForTest
    $s1 = Create-ServerForTest $rg1 $location
    $db1 = Create-DatabaseForTest $s1
    $db2 = Create-DatabaseForTest $s1
    $db3 = Create-DatabaseForTest $s1
    $db4 = Create-DatabaseForTest $s1

    try
    {
        # Test using default parameters
        $agentName = Get-AgentName
        $resp = New-AzSqlElasticJobAgent -ResourceGroupName $rg1.ResourceGroupName -ServerName $s1.ServerName -DatabaseName $db1.DatabaseName -AgentName $agentName
        Assert-AreEqual $resp.AgentName $agentName
        Assert-AreEqual $resp.ServerName $s1.ServerName
        Assert-AreEqual $resp.DatabaseName $db1.DatabaseName
        Assert-AreEqual $resp.ResourceGroupName $rg1.ResourceGroupName
        Assert-AreEqual $resp.Location $s1.Location
        Assert-AreEqual $resp.WorkerCount 100

        # Test using database object
        $agentName = Get-AgentName
        $resp = New-AzSqlElasticJobAgent -DatabaseObject $db2 -Name $agentName
        Assert-AreEqual $resp.AgentName $agentName
        Assert-AreEqual $resp.ServerName $s1.ServerName
        Assert-AreEqual $resp.DatabaseName $db2.DatabaseName
        Assert-AreEqual $resp.ResourceGroupName $rg1.ResourceGroupName
        Assert-AreEqual $resp.Location $s1.Location
        Assert-AreEqual $resp.WorkerCount 100

        # Test using database resource id
        $agentName = Get-AgentName
        $resp = New-AzSqlElasticJobAgent -DatabaseResourceId $db3.ResourceId -Name $agentName
        Assert-AreEqual $resp.AgentName $agentName
        Assert-AreEqual $resp.ServerName $s1.ServerName
        Assert-AreEqual $resp.DatabaseName $db3.DatabaseName
        Assert-AreEqual $resp.ResourceGroupName $rg1.ResourceGroupName
        Assert-AreEqual $resp.Location $s1.Location
        Assert-AreEqual $resp.WorkerCount 100

        # Test piping - Create using piping
        $agentName = Get-AgentName
        $resp = $db4 | New-AzSqlElasticJobAgent -Name $agentName
        Assert-AreEqual $resp.AgentName $agentName
        Assert-AreEqual $resp.ServerName $s1.ServerName
        Assert-AreEqual $resp.DatabaseName $db4.DatabaseName
        Assert-AreEqual $resp.ResourceGroupName $rg1.ResourceGroupName
        Assert-AreEqual $resp.Location $s1.Location
        Assert-AreEqual $resp.WorkerCount 100
    }
    finally
    {
        Remove-ResourceGroupForTest $rg1
    }
}

<#
    .SYNOPSIS
    Tests updating an agent
#>
function Test-UpdateAgent
{
    # Setup
    $location = Get-Location "Microsoft.Sql" "operations" "West US 2"
    $rg1 = Create-ResourceGroupForTest
    $s1 = Create-ServerForTest $rg1 $location
    $db1 = Create-DatabaseForTest $s1
    $a1 = Create-AgentForTest $db1
    $agentName = Get-AgentName
    $tags = @{ Octopus="Agent"}

    try
    {
        # Test using default parameters
        $resp = Set-AzSqlElasticJobAgent -ResourceGroupName $a1.ResourceGroupName -ServerName $a1.ServerName -AgentName $a1.AgentName -Tag $tags
        Assert-AreEqual $resp.AgentName $a1.AgentName
        Assert-AreEqual $resp.ServerName $a1.ServerName
        Assert-AreEqual $resp.DatabaseName $a1.DatabaseName
        Assert-AreEqual $resp.ResourceGroupName $a1.ResourceGroupName
        Assert-AreEqual $resp.Location $a1.Location
        Assert-AreEqual $resp.WorkerCount 100
        # Assert-AreEqual $resp.Tags.Octopus "Agent"

        # Test using input object
        $resp = Set-AzSqlElasticJobAgent -InputObject $a1 -Tag $tags
        Assert-AreEqual $resp.AgentName $a1.AgentName
        Assert-AreEqual $resp.ServerName $a1.ServerName
        Assert-AreEqual $resp.DatabaseName $a1.DatabaseName
        Assert-AreEqual $resp.ResourceGroupName $a1.ResourceGroupName
        Assert-AreEqual $resp.Location $a1.Location
        Assert-AreEqual $resp.WorkerCount 100
        # Assert-AreEqual $resp.Tags.Octopus "Agent"

        # Test using resource id
        $resp = Set-AzSqlElasticJobAgent -ResourceId $a1.ResourceId -Tag $tags
        Assert-AreEqual $resp.AgentName $a1.AgentName
        Assert-AreEqual $resp.ServerName $a1.ServerName
        Assert-AreEqual $resp.DatabaseName $a1.DatabaseName
        Assert-AreEqual $resp.ResourceGroupName $a1.ResourceGroupName
        Assert-AreEqual $resp.Location $a1.Location
        Assert-AreEqual $resp.WorkerCount 100
        # Assert-AreEqual $resp.Tags.Octopus "Agent"

        # Test using piping
        $resp = $a1 | Set-AzSqlElasticJobAgent -Tag $tags
        Assert-AreEqual $resp.AgentName $a1.AgentName
        Assert-AreEqual $resp.ServerName $a1.ServerName
        Assert-AreEqual $resp.DatabaseName $a1.DatabaseName
        Assert-AreEqual $resp.ResourceGroupName $a1.ResourceGroupName
        Assert-AreEqual $resp.Location $a1.Location
        Assert-AreEqual $resp.WorkerCount 100
        # Assert-AreEqual $resp.Tags.Octopus "Agent"
    }
    finally
    {
        Remove-ResourceGroupForTest $rg1
    }
}

<#
    .SYNOPSIS
    Tests getting an agent
#>
function Test-GetAgent
{
    # Setup
    $location = Get-Location "Microsoft.Sql" "operations" "West US 2"
    $rg1 = Create-ResourceGroupForTest
    $s1 = Create-ServerForTest $rg1 $location
    $s2 = Create-ServerForTest $rg1 $location
    $db1 = Create-DatabaseForTest $s1
    $db2 = Create-DatabaseForTest $s1
    $db3 = Create-DatabaseForTest $s2
    $a1 = Create-AgentForTest $db1
    $a2 = Create-AgentForTest $db2
    $a3 = Create-AgentForTest $db3
    $agentName = Get-AgentName

    try
    {
        # Test using default parameters
        $resp = Get-AzSqlElasticJobAgent -ResourceGroupName $a1.ResourceGroupName -ServerName $a1.ServerName -AgentName $a1.AgentName
        Assert-AreEqual $resp.AgentName $a1.AgentName
        Assert-AreEqual $resp.ServerName $a1.ServerName
        Assert-AreEqual $resp.DatabaseName $a1.DatabaseName
        Assert-AreEqual $resp.ResourceGroupName $a1.ResourceGroupName
        Assert-AreEqual $resp.Location $a1.Location
        Assert-AreEqual $resp.WorkerCount 100

        # Test using input object
        $resp = Get-AzSqlElasticJobAgent -ParentObject $s1 -AgentName $a1.AgentName
        Assert-AreEqual $resp.AgentName $a1.AgentName
        Assert-AreEqual $resp.ServerName $a1.ServerName
        Assert-AreEqual $resp.DatabaseName $a1.DatabaseName
        Assert-AreEqual $resp.ResourceGroupName $a1.ResourceGroupName
        Assert-AreEqual $resp.Location $a1.Location
        Assert-AreEqual $resp.WorkerCount 100

        # Test using server resource id
        $resp = Get-AzSqlElasticJobAgent -ParentResourceId $s1.ResourceId -AgentName $a1.AgentName
        Assert-AreEqual $resp.AgentName $a1.AgentName
        Assert-AreEqual $resp.ServerName $a1.ServerName
        Assert-AreEqual $resp.DatabaseName $a1.DatabaseName
        Assert-AreEqual $resp.ResourceGroupName $a1.ResourceGroupName
        Assert-AreEqual $resp.Location $a1.Location
        Assert-AreEqual $resp.WorkerCount 100

        # Test using piping
        $resp = $s1 | Get-AzSqlElasticJobAgent -Name $a1.AgentName
        Assert-AreEqual $resp.AgentName $a1.AgentName
        Assert-AreEqual $resp.ServerName $a1.ServerName
        Assert-AreEqual $resp.DatabaseName $a1.DatabaseName
        Assert-AreEqual $resp.ResourceGroupName $a1.ResourceGroupName
        Assert-AreEqual $resp.Location $a1.Location
        Assert-AreEqual $resp.WorkerCount 100

        # Get all in s1
        $resp = $s1 | Get-AzSqlElasticJobAgent
        Assert-AreEqual $resp.Count 2

        # Get all agents in servers in rg1
        $resp = Get-AzSqlServer -ResourceGroupName $rg1.ResourceGroupName | Get-AzSqlElasticJobAgent
        Assert-AreEqual $resp.Count 3
    }
    finally
    {
        Remove-ResourceGroupForTest $rg1
    }
}

<#
    .SYNOPSIS
    Tests removing an agent
#>
function Test-RemoveAgent
{
    # Setup
    $location = Get-Location "Microsoft.Sql" "operations" "West US 2"
    $rg1 = Create-ResourceGroupForTest
    $s1 = Create-ServerForTest $rg1 $location
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
        $resp = Remove-AzSqlElasticJobAgent -ResourceGroupName $rg1.ResourceGroupName -ServerName $s1.ServerName -AgentName $a1.AgentName -Force
        Assert-AreEqual $resp.AgentName $a1.AgentName
        Assert-AreEqual $resp.ServerName $s1.ServerName
        Assert-AreEqual $resp.DatabaseName $db1.DatabaseName
        Assert-AreEqual $resp.ResourceGroupName $rg1.ResourceGroupName
        Assert-AreEqual $resp.Location $s1.Location
        Assert-AreEqual $resp.WorkerCount 100

        # Test using input object
        $resp = Remove-AzSqlElasticJobAgent -InputObject $a2 -Force
        Assert-AreEqual $resp.AgentName $a2.AgentName
        Assert-AreEqual $resp.ServerName $s1.ServerName
        Assert-AreEqual $resp.DatabaseName $db2.DatabaseName
        Assert-AreEqual $resp.ResourceGroupName $rg1.ResourceGroupName
        Assert-AreEqual $resp.Location $s1.Location
        Assert-AreEqual $resp.WorkerCount 100

        # Test using resource id
        $resp = Remove-AzSqlElasticJobAgent -ResourceId $a3.ResourceId -Force
        Assert-AreEqual $resp.AgentName $a3.AgentName
        Assert-AreEqual $resp.ServerName $s1.ServerName
        Assert-AreEqual $resp.DatabaseName $db3.DatabaseName
        Assert-AreEqual $resp.ResourceGroupName $rg1.ResourceGroupName
        Assert-AreEqual $resp.Location $s1.Location
        Assert-AreEqual $resp.WorkerCount 100

        # Test using piping
        $resp = $a4 | Remove-AzSqlElasticJobAgent -Force
        Assert-AreEqual $resp.AgentName $a4.AgentName
        Assert-AreEqual $resp.ServerName $s1.ServerName
        Assert-AreEqual $resp.DatabaseName $db4.DatabaseName
        Assert-AreEqual $resp.ResourceGroupName $rg1.ResourceGroupName
        Assert-AreEqual $resp.Location $s1.Location
        Assert-AreEqual $resp.WorkerCount 100

        # Test that agents are indeed gone
        Assert-Throws { $s1 | Get-AzSqlElasticJobAgent -Name $a1.AgentName }
        Assert-Throws { $s1 | Get-AzSqlElasticJobAgent -Name $a2.AgentName }
        Assert-Throws { $s1 | Get-AzSqlElasticJobAgent -Name $a3.AgentName }
        Assert-Throws { $s1 | Get-AzSqlElasticJobAgent -Name $a4.AgentName }
    }
    finally
    {
        Remove-ResourceGroupForTest $rg1
    }
}