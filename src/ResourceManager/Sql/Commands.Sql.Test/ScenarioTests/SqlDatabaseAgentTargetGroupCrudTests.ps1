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
	Tests creating a target group
    .DESCRIPTION
	SmokeTest
#>
function Test-CreateTargetGroup
{
    # Setup
    $rg1 = Create-ResourceGroupForTest
    $s1 = Create-ServerForTest $rg1 "westus2"
    $db1 = Create-DatabaseForTest $s1
    $a1 = Create-AgentForTest $db1
    $tgName1 = Get-TargetGroupName
    $tgName2 = Get-TargetGroupName
    $tgName3 = Get-TargetGroupName
    $tgName4 = Get-TargetGroupName
    
    try
    {
        # Test using default parameters
        $resp1 = New-AzureRmSqlDatabaseAgentTargetGroup -ResourceGroupName $rg1.ResourceGroupName -ServerName $s1.ServerName -AgentName $a1.AgentName -Name $tgName1
        Assert-AreEqual $resp1.ResourceGroupName $rg1.ResourceGroupName
        Assert-AreEqual $resp1.AgentName $a1.AgentName
        Assert-AreEqual $resp1.ServerName $s1.ServerName
        Assert-AreEqual $resp1.TargetGroupName $tgName1
        Assert-AreEqual $resp1.Members.Count 0

        # Test using input object
        $resp2 = New-AzureRmSqlDatabaseAgentTargetGroup -InputObject $a1 -Name $tgName2
        Assert-AreEqual $resp2.ResourceGroupName $rg1.ResourceGroupName
        Assert-AreEqual $resp2.AgentName $a1.AgentName
        Assert-AreEqual $resp2.ServerName $s1.ServerName
        Assert-AreEqual $resp2.TargetGroupName $tgName2
        Assert-AreEqual $resp2.Members.Count 0

        # Test using resource id
        $resp3 = New-AzureRmSqlDatabaseAgentTargetGroup -ResourceId $a1.ResourceId -Name $tgName3
        Assert-AreEqual $resp3.ResourceGroupName $rg1.ResourceGroupName
        Assert-AreEqual $resp3.AgentName $a1.AgentName
        Assert-AreEqual $resp3.ServerName $s1.ServerName
        Assert-AreEqual $resp3.TargetGroupName $tgName3
        Assert-AreEqual $resp3.Members.Count 0

        # Test piping
        $resp4 = $a1 | New-AzureRmSqlDatabaseAgentTargetGroup -Name $tgName4
        Assert-AreEqual $resp4.ResourceGroupName $rg1.ResourceGroupName
        Assert-AreEqual $resp4.AgentName $a1.AgentName
        Assert-AreEqual $resp4.ServerName $s1.ServerName
        Assert-AreEqual $resp4.TargetGroupName $tgName4
        Assert-AreEqual $resp4.Members.Count 0
    }
    finally
    {
        Remove-ResourceGroupForTest $rg1
    }
}

<#
	.SYNOPSIS
	Tests getting a target group
    .DESCRIPTION
	SmokeTest
#>
function Test-GetTargetGroup
{
    # Setup
    $rg1 = Create-ResourceGroupForTest
    $s1 = Create-ServerForTest $rg1 "westus2"
    $db1 = Create-DatabaseForTest $s1
    $a1 = Create-AgentForTest $db1

    $tg1 = Create-TargetGroupForTest $a1
    $tg2 = Create-TargetGroupForTest $a1
    $tg3 = Create-TargetGroupForTest $a1
    $tg4 = Create-TargetGroupForTest $a1

    try
    {
        # Test using default parameters
        $resp1 = Get-AzureRmSqlDatabaseAgentTargetGroup -ResourceGroupName $rg1.ResourceGroupName -ServerName $s1.ServerName -AgentName $a1.AgentName -Name $tg1.TargetGroupName
        Assert-AreEqual $resp1.ResourceGroupName $rg1.ResourceGroupName
        Assert-AreEqual $resp1.AgentName $a1.AgentName
        Assert-AreEqual $resp1.ServerName $s1.ServerName
        Assert-AreEqual $resp1.TargetGroupName $tg1.TargetGroupName
        Assert-AreEqual $resp1.Members.Count 0

        # Test get all target groups
        $all = Get-AzureRmSqlDatabaseAgentTargetGroup -ResourceGroupName $rg1.ResourceGroupName -ServerName $s1.ServerName -AgentName $a1.AgentName
        Assert-AreEqual 4 $all.Count

        # Test using input object
        $resp2 = Get-AzureRmSqlDatabaseAgentTargetGroup -InputObject $a1 -Name $tg2.TargetGroupName
        Assert-AreEqual $resp2.ResourceGroupName $rg1.ResourceGroupName
        Assert-AreEqual $resp2.AgentName $a1.AgentName
        Assert-AreEqual $resp2.ServerName $s1.ServerName
        Assert-AreEqual $resp2.TargetGroupName $tg2.TargetGroupName
        Assert-AreEqual $resp2.Members.Count 0

        # Test get all target groups - using input object
        $all = Get-AzureRmSqlDatabaseAgentTargetGroup -InputObject $a1
        Assert-AreEqual 4 $all.Count

        # Test using resource id
        $resp3 = Get-AzureRmSqlDatabaseAgentTargetGroup -ResourceId $a1.ResourceId -Name $tg3.TargetGroupName
        Assert-AreEqual $resp3.ResourceGroupName $rg1.ResourceGroupName
        Assert-AreEqual $resp3.AgentName $a1.AgentName
        Assert-AreEqual $resp3.ServerName $s1.ServerName
        Assert-AreEqual $resp3.TargetGroupName $tg3.TargetGroupName
        Assert-AreEqual $resp3.Members.Count 0

        # Test get all target groups - using resource id
        $all = Get-AzureRmSqlDatabaseAgentTargetGroup -ResourceId $a1.ResourceId
        Assert-AreEqual 4 $all.Count

        # Test piping
        $resp4 = $a1 | Get-AzureRmSqlDatabaseAgentTargetGroup -Name $tg4.TargetGroupName
        Assert-AreEqual $resp4.ResourceGroupName $rg1.ResourceGroupName
        Assert-AreEqual $resp4.AgentName $a1.AgentName
        Assert-AreEqual $resp4.ServerName $s1.ServerName
        Assert-AreEqual $resp4.TargetGroupName $tg4.TargetGroupName
        Assert-AreEqual $resp4.Members.Count 0
        
        # Test get all using piping
        $all = $a1 | Get-AzureRmSqlDatabaseAgentTargetGroup
        Assert-AreEqual 4 $all.Count
    }
    finally
    {
        Remove-ResourceGroupForTest $rg1
    }
}

<#
	.SYNOPSIS
	Tests removing a target group
    .DESCRIPTION
	SmokeTest
#>
function Test-RemoveTargetGroup
{
    # Setup
    $rg1 = Create-ResourceGroupForTest
    $s1 = Create-ServerForTest $rg1 "westus2"
    $db1 = Create-DatabaseForTest $s1
    $a1 = Create-AgentForTest $db1

    $tg1 = Create-TargetGroupForTest $a1
    $tg2 = Create-TargetGroupForTest $a1
    $tg3 = Create-TargetGroupForTest $a1
    $tg4 = Create-TargetGroupForTest $a1

    try
    {
        # Test using default parameters
        $resp1 = Remove-AzureRmSqlDatabaseAgentTargetGroup -ResourceGroupName $rg1.ResourceGroupName -ServerName $s1.ServerName -AgentName $a1.AgentName -Name $tg1.TargetGroupName
        Assert-AreEqual $resp1.ResourceGroupName $rg1.ResourceGroupName
        Assert-AreEqual $resp1.AgentName $a1.AgentName
        Assert-AreEqual $resp1.ServerName $s1.ServerName
        Assert-AreEqual $resp1.TargetGroupName $tg1.TargetGroupName
        Assert-AreEqual $resp1.Members.Count 0

        # Test using input object
        $resp2 = Remove-AzureRmSqlDatabaseAgentTargetGroup -InputObject $tg2
        Assert-AreEqual $resp2.ResourceGroupName $rg1.ResourceGroupName
        Assert-AreEqual $resp2.AgentName $a1.AgentName
        Assert-AreEqual $resp2.ServerName $s1.ServerName
        Assert-AreEqual $resp2.TargetGroupName $tg2.TargetGroupName
        Assert-AreEqual $resp2.Members.Count 0

        # Test using resource id
        $resp3 = Remove-AzureRmSqlDatabaseAgentTargetGroup -ResourceId $tg3.ResourceId
        Assert-AreEqual $resp3.ResourceGroupName $rg1.ResourceGroupName
        Assert-AreEqual $resp3.AgentName $a1.AgentName
        Assert-AreEqual $resp3.ServerName $s1.ServerName
        Assert-AreEqual $resp3.TargetGroupName $tg3.TargetGroupName
        Assert-AreEqual $resp3.Members.Count 0

        # Test piping
        $resp4 = $tg4 | Remove-AzureRmSqlDatabaseAgentTargetGroup
        Assert-AreEqual $resp4.ResourceGroupName $rg1.ResourceGroupName
        Assert-AreEqual $resp4.AgentName $a1.AgentName
        Assert-AreEqual $resp4.ServerName $s1.ServerName
        Assert-AreEqual $resp4.TargetGroupName $tg4.TargetGroupName
        Assert-AreEqual $resp4.Members.Count 0

        $all = Get-AzureRmSqlDatabaseAgentTargetGroup -InputObject $a1
        Assert-AreEqual 0 $all.Count
    }
    finally
    {
        Remove-ResourceGroupForTest $rg1
    }
}