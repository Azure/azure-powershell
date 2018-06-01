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
    $rg1 = Create-ResourceGroupForTest
    $s1 = Create-ServerForTest $rg1 "westus2"
    $db1 = Create-DatabaseForTest $s1
    $db2 = Create-DatabaseForTest $s1
    $db3 = Create-DatabaseForTest $s1
    $db4 = Create-DatabaseForTest $s1

    try
    {
        # Test using default parameters
        $agentName = Get-AgentName
        $resp = New-AzureRmSqlElasticJobAgent -ResourceGroupName $rg1.ResourceGroupName -ServerName $s1.ServerName -DatabaseName $db1.DatabaseName -AgentName $agentName
        Assert-AreEqual $resp.AgentName $agentName
        Assert-AreEqual $resp.ServerName $s1.ServerName
        Assert-AreEqual $resp.DatabaseName $db1.DatabaseName
        Assert-AreEqual $resp.ResourceGroupName $rg1.ResourceGroupName
        Assert-AreEqual $resp.Location $s1.Location
        Assert-AreEqual $resp.WorkerCount 100

        # Test using database object
        $agentName = Get-AgentName
        $resp = New-AzureRmSqlElasticJobAgent -DatabaseObject $db2 -Name $agentName
        Assert-AreEqual $resp.AgentName $agentName
        Assert-AreEqual $resp.ServerName $s1.ServerName
        Assert-AreEqual $resp.DatabaseName $db2.DatabaseName
        Assert-AreEqual $resp.ResourceGroupName $rg1.ResourceGroupName
        Assert-AreEqual $resp.Location $s1.Location
        Assert-AreEqual $resp.WorkerCount 100

        # Test using database resource id
        $agentName = Get-AgentName
        $resp = New-AzureRmSqlElasticJobAgent -DatabaseResourceId $db3.ResourceId -Name $agentName
        Assert-AreEqual $resp.AgentName $agentName
        Assert-AreEqual $resp.ServerName $s1.ServerName
        Assert-AreEqual $resp.DatabaseName $db3.DatabaseName
        Assert-AreEqual $resp.ResourceGroupName $rg1.ResourceGroupName
        Assert-AreEqual $resp.Location $s1.Location
        Assert-AreEqual $resp.WorkerCount 100

        # Test piping - Create using piping
        $agentName = Get-AgentName
        $resp = $db4 | New-AzureRmSqlElasticJobAgent -Name $agentName
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
    # Setup
    $rg1 = Create-ResourceGroupForTest
    $s1 = Create-ServerForTest $rg1 "westus2"
    $db1 = Create-DatabaseForTest $s1
    $a1 = Create-AgentForTest $db1
    $agentName = Get-AgentName
    $tags = @{ Octopus="Agent"}

    try
    {
        # Test using default parameters
        $resp = Set-AzureRmSqlElasticJobAgent -ResourceGroupName $a1.ResourceGroupName -ServerName $a1.ServerName -AgentName $a1.AgentName -Tag $tags
        Assert-AreEqual $resp.AgentName $a1.AgentName
        Assert-AreEqual $resp.ServerName $a1.ServerName
        Assert-AreEqual $resp.DatabaseName $a1.DatabaseName
        Assert-AreEqual $resp.ResourceGroupName $a1.ResourceGroupName
        Assert-AreEqual $resp.Location $a1.Location
        Assert-AreEqual $resp.WorkerCount 100
        Assert-AreEqual $resp.Tags.Octopus "Agent"

        # Test using input object
        $resp = Set-AzureRmSqlElasticJobAgent -InputObject $a1 -Tag $tags
        Assert-AreEqual $resp.AgentName $a1.AgentName
        Assert-AreEqual $resp.ServerName $a1.ServerName
        Assert-AreEqual $resp.DatabaseName $a1.DatabaseName
        Assert-AreEqual $resp.ResourceGroupName $a1.ResourceGroupName
        Assert-AreEqual $resp.Location $a1.Location
        Assert-AreEqual $resp.WorkerCount 100
        Assert-AreEqual $resp.Tags.Octopus "Agent"

        # Test using resource id
        $resp = Set-AzureRmSqlElasticJobAgent -ResourceId $a1.ResourceId -Tag $tags
        Assert-AreEqual $resp.AgentName $a1.AgentName
        Assert-AreEqual $resp.ServerName $a1.ServerName
        Assert-AreEqual $resp.DatabaseName $a1.DatabaseName
        Assert-AreEqual $resp.ResourceGroupName $a1.ResourceGroupName
        Assert-AreEqual $resp.Location $a1.Location
        Assert-AreEqual $resp.WorkerCount 100
        Assert-AreEqual $resp.Tags.Octopus "Agent"

        # Test using piping
        $resp = $a1 | Set-AzureRmSqlElasticJobAgent -Tag $tags
        Assert-AreEqual $resp.AgentName $a1.AgentName
        Assert-AreEqual $resp.ServerName $a1.ServerName
        Assert-AreEqual $resp.DatabaseName $a1.DatabaseName
        Assert-AreEqual $resp.ResourceGroupName $a1.ResourceGroupName
        Assert-AreEqual $resp.Location $a1.Location
        Assert-AreEqual $resp.WorkerCount 100
        Assert-AreEqual $resp.Tags.Octopus "Agent"
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
    $rg1 = Create-ResourceGroupForTest
    $s1 = Create-ServerForTest $rg1 "westus2"
    $s2 = Create-ServerForTest $rg1 "westus2"
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
        $resp = Get-AzureRmSqlElasticJobAgent -ResourceGroupName $a1.ResourceGroupName -ServerName $a1.ServerName -AgentName $a1.AgentName
        Assert-AreEqual $resp.AgentName $a1.AgentName
        Assert-AreEqual $resp.ServerName $a1.ServerName
        Assert-AreEqual $resp.DatabaseName $a1.DatabaseName
        Assert-AreEqual $resp.ResourceGroupName $a1.ResourceGroupName
        Assert-AreEqual $resp.Location $a1.Location
        Assert-AreEqual $resp.WorkerCount 100

        # Test using input object
        $resp = Get-AzureRmSqlElasticJobAgent -ServerObject $s1 -AgentName $a1.AgentName
        Assert-AreEqual $resp.AgentName $a1.AgentName
        Assert-AreEqual $resp.ServerName $a1.ServerName
        Assert-AreEqual $resp.DatabaseName $a1.DatabaseName
        Assert-AreEqual $resp.ResourceGroupName $a1.ResourceGroupName
        Assert-AreEqual $resp.Location $a1.Location
        Assert-AreEqual $resp.WorkerCount 100

        # Test using server resource id
        $resp = Get-AzureRmSqlElasticJobAgent -ServerResourceId $s1.ResourceId -AgentName $a1.AgentName
        Assert-AreEqual $resp.AgentName $a1.AgentName
        Assert-AreEqual $resp.ServerName $a1.ServerName
        Assert-AreEqual $resp.DatabaseName $a1.DatabaseName
        Assert-AreEqual $resp.ResourceGroupName $a1.ResourceGroupName
        Assert-AreEqual $resp.Location $a1.Location
        Assert-AreEqual $resp.WorkerCount 100

        # Test using piping
        $resp = $s1 | Get-AzureRmSqlElasticJobAgent -Name $a1.AgentName
        Assert-AreEqual $resp.AgentName $a1.AgentName
        Assert-AreEqual $resp.ServerName $a1.ServerName
        Assert-AreEqual $resp.DatabaseName $a1.DatabaseName
        Assert-AreEqual $resp.ResourceGroupName $a1.ResourceGroupName
        Assert-AreEqual $resp.Location $a1.Location
        Assert-AreEqual $resp.WorkerCount 100

        # Get all in s1
        $resp = $s1 | Get-AzureRmSqlElasticJobAgent
        Assert-AreEqual $resp.Count 2

        # Get all agents in servers in rg1
        $resp = Get-AzureRmSqlServer -ResourceGroupName $rg1.ResourceGroupName | Get-AzureRmSqlElasticJobAgent
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
        $resp = Remove-AzureRmSqlElasticJobAgent -ResourceGroupName $rg1.ResourceGroupName -ServerName $s1.ServerName -AgentName $a1.AgentName
        Assert-AreEqual $resp.AgentName $a1.AgentName
        Assert-AreEqual $resp.ServerName $s1.ServerName
        Assert-AreEqual $resp.DatabaseName $db1.DatabaseName
        Assert-AreEqual $resp.ResourceGroupName $rg1.ResourceGroupName
        Assert-AreEqual $resp.Location $s1.Location
        Assert-AreEqual $resp.WorkerCount 100

        # Test using input object
        $resp = Remove-AzureRmSqlElasticJobAgent -InputObject $a2
        Assert-AreEqual $resp.AgentName $a2.AgentName
        Assert-AreEqual $resp.ServerName $s1.ServerName
        Assert-AreEqual $resp.DatabaseName $db2.DatabaseName
        Assert-AreEqual $resp.ResourceGroupName $rg1.ResourceGroupName
        Assert-AreEqual $resp.Location $s1.Location
        Assert-AreEqual $resp.WorkerCount 100

        # Test using resource id
        $resp = Remove-AzureRmSqlElasticJobAgent -ResourceId $a3.ResourceId
        Assert-AreEqual $resp.AgentName $a3.AgentName
        Assert-AreEqual $resp.ServerName $s1.ServerName
        Assert-AreEqual $resp.DatabaseName $db3.DatabaseName
        Assert-AreEqual $resp.ResourceGroupName $rg1.ResourceGroupName
        Assert-AreEqual $resp.Location $s1.Location
        Assert-AreEqual $resp.WorkerCount 100

        # Test using piping
        $resp = $a4 | Remove-AzureRmSqlElasticJobAgent
        Assert-AreEqual $resp.AgentName $a4.AgentName
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