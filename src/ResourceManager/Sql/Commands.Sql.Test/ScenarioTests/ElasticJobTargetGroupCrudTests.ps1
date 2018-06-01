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
#>
function Test-CreateTargetGroup
{
	# Setup
	$a1 = Create-ElasticJobAgentTestEnvironment

	try
	{
		Test-CreateTargetGroupWithDefaultParam $a1
		Test-CreateTargetGroupWithAgentObject $a1
		Test-CreateTargetGroupWithAgentResourceId $a1
		Test-CreateTargetGroupWithPiping $a1
	}
	finally
	{
		Remove-ResourceGroupForTest $a1
	}
}

<#
	.SYNOPSIS
	Tests getting target group
#>
function Test-GetTargetGroup
{
	# Setup
	$a1 = Create-ElasticJobAgentTestEnvironment

	try
	{
		Test-GetTargetGroupWithDefaultParam $a1
		Test-GetTargetGroupWithAgentObject $a1
		Test-GetTargetGroupWithAgentResourceId $a1
		Test-GetTargetGroupWithPiping $a1
	}
	finally
	{
		Remove-ResourceGroupForTest $a1
	}
}

<#
	.SYNOPSIS
	Tests removing target group
#>
function Test-RemoveTargetGroup
{
	# Setup
	$a1 = Create-ElasticJobAgentTestEnvironment

	try
	{
		Test-RemoveTargetGroupWithDefaultParam $a1
		Test-RemoveTargetGroupWithInputObject $a1
		Test-RemoveTargetGroupWithResourceId $a1
		Test-RemoveTargetGroupWithPiping $a1
	}
	finally
	{
		Remove-ResourceGroupForTest $a1
	}
}

<#
    .SYNOPSIS
    Tests creating a target group with default params
    .DESCRIPTION
    SmokeTest
#>
function Test-CreateTargetGroupWithDefaultParam ($a1)
{
    $tgName = Get-TargetGroupName

    # Test using default parameters
    $resp = New-AzureRmSqlElasticJobTargetGroup -ResourceGroupName $a1.ResourceGroupName -ServerName $a1.ServerName -AgentName $a1.AgentName -Name $tgName
    Assert-AreEqual $resp.ResourceGroupName $a1.ResourceGroupName
    Assert-AreEqual $resp.AgentName $a1.AgentName
    Assert-AreEqual $resp.ServerName $a1.ServerName
    Assert-AreEqual $resp.TargetGroupName $tgName
    Assert-AreEqual $resp.Members.Count 0
}

<#
    .SYNOPSIS
    Tests creating a target group with agent object
    .DESCRIPTION
    SmokeTest
#>
function Test-CreateTargetGroupWithAgentObject ($a1)
{
    $tgName = Get-TargetGroupName

    # Test using input object
    $resp = New-AzureRmSqlElasticJobTargetGroup -AgentObject $a1 -Name $tgName
    Assert-AreEqual $resp.ResourceGroupName $a1.ResourceGroupName
    Assert-AreEqual $resp.AgentName $a1.AgentName
    Assert-AreEqual $resp.ServerName $a1.ServerName
    Assert-AreEqual $resp.TargetGroupName $tgName
    Assert-AreEqual $resp.Members.Count 0
}

<#
    .SYNOPSIS
    Tests creating a target group with agent resource id
    .DESCRIPTION
    SmokeTest
#>
function Test-CreateTargetGroupWithAgentResourceId ($a1)
{
    $tgName = Get-TargetGroupName

    # Test using resource id
    $resp = New-AzureRmSqlElasticJobTargetGroup -AgentResourceId $a1.ResourceId -Name $tgName
    Assert-AreEqual $resp.ResourceGroupName $a1.ResourceGroupName
    Assert-AreEqual $resp.AgentName $a1.AgentName
    Assert-AreEqual $resp.ServerName $a1.ServerName
    Assert-AreEqual $resp.TargetGroupName $tgName
    Assert-AreEqual $resp.Members.Count 0
}

<#
    .SYNOPSIS
    Tests creating a target group with piping
    .DESCRIPTION
    SmokeTest
#>
function Test-CreateTargetGroupWithPiping ($a1)
{
    $tgName = Get-TargetGroupName

    # Test piping
    $resp = $a1 | New-AzureRmSqlElasticJobTargetGroup -Name $tgName
    Assert-AreEqual $resp.ResourceGroupName $a1.ResourceGroupName
    Assert-AreEqual $resp.AgentName $a1.AgentName
    Assert-AreEqual $resp.ServerName $a1.ServerName
    Assert-AreEqual $resp.TargetGroupName $tgName
    Assert-AreEqual $resp.Members.Count 0
}

<#
    .SYNOPSIS
    Tests getting a target group with default param
    .DESCRIPTION
    SmokeTest
#>
function Test-GetTargetGroupWithDefaultParam ($a1)
{
    $tg = Create-TargetGroupForTest $a1
    $tg2 = Create-TargetGroupForTest $a1

    # Test using default parameters
    $resp = Get-AzureRmSqlElasticJobTargetGroup -ResourceGroupName $a1.ResourceGroupName -ServerName $a1.ServerName -AgentName $a1.AgentName -Name $tg.TargetGroupName
    Assert-AreEqual $resp.ResourceGroupName $a1.ResourceGroupName
    Assert-AreEqual $resp.AgentName $a1.AgentName
    Assert-AreEqual $resp.ServerName $a1.ServerName
    Assert-AreEqual $resp.TargetGroupName $tg.TargetGroupName
    Assert-AreEqual $resp.Members.Count 0

    # Test get all with default parameters
    $resp = Get-AzureRmSqlElasticJobTargetGroup -ResourceGroupName $a1.ResourceGroupName -ServerName $a1.ServerName -AgentName $a1.AgentName
    Assert-True { $resp.Count -ge 2 }
}

<#
    .SYNOPSIS
    Tests getting a target group with agent object
    .DESCRIPTION
    SmokeTest
#>
function Test-GetTargetGroupWithAgentObject ($a1)
{
    $tg = Create-TargetGroupForTest $a1
    $tg2 = Create-TargetGroupForTest $a1

    # Test using input object
    $resp = Get-AzureRmSqlElasticJobTargetGroup -AgentObject $a1 -Name $tg.TargetGroupName
    Assert-AreEqual $resp.ResourceGroupName $a1.ResourceGroupName
    Assert-AreEqual $resp.AgentName $a1.AgentName
    Assert-AreEqual $resp.ServerName $a1.ServerName
    Assert-AreEqual $resp.TargetGroupName $tg.TargetGroupName
    Assert-AreEqual $resp.Members.Count 0

    # Test get all with default parameters
    $resp = Get-AzureRmSqlElasticJobTargetGroup -AgentObject $a1
    Assert-True { $resp.Count -ge 2 }
}

<#
    .SYNOPSIS
    Tests getting a target group with agent resource id
    .DESCRIPTION
    SmokeTest
#>
function Test-GetTargetGroupWithAgentResourceId ($a1)
{
    $tg = Create-TargetGroupForTest $a1
    $tg2 = Create-TargetGroupForTest $a1 

    # Test using resource id
    $resp = Get-AzureRmSqlElasticJobTargetGroup -AgentResourceId $a1.ResourceId -Name $tg.TargetGroupName
    Assert-AreEqual $resp.ResourceGroupName $a1.ResourceGroupName
    Assert-AreEqual $resp.AgentName $a1.AgentName
    Assert-AreEqual $resp.ServerName $a1.ServerName
    Assert-AreEqual $resp.TargetGroupName $tg.TargetGroupName
    Assert-AreEqual $resp.Members.Count 0

    # Test get all with default parameters
    $resp = Get-AzureRmSqlElasticJobTargetGroup -AgentResourceId $a1.ResourceId
    Assert-True { $resp.Count -ge 2 }
}

<#
    .SYNOPSIS
    Tests getting a target group
    .DESCRIPTION
    SmokeTest
#>
function Test-GetTargetGroupWithPiping ($a1)
{
    $tg = Create-TargetGroupForTest $a1

    # Test piping
    $resp = $a1 | Get-AzureRmSqlElasticJobTargetGroup -Name $tg.TargetGroupName
    Assert-AreEqual $resp.ResourceGroupName $tg.ResourceGroupName
    Assert-AreEqual $resp.AgentName $tg.AgentName
    Assert-AreEqual $resp.ServerName $tg.ServerName
    Assert-AreEqual $resp.TargetGroupName $tg.TargetGroupName
    Assert-AreEqual $resp.Members.Count 0
}

<#
    .SYNOPSIS
    Tests removing a target group with default param
    .DESCRIPTION
    SmokeTest
#>
function Test-RemoveTargetGroupWithDefaultParam ($a1)
{
    $tg = Create-TargetGroupForTest $a1

    # Test using default parameters
    $resp = Remove-AzureRmSqlElasticJobTargetGroup -ResourceGroupName $a1.ResourceGroupName -ServerName $a1.ServerName -AgentName $a1.AgentName -Name $tg.TargetGroupName
    Assert-AreEqual $resp.ResourceGroupName $tg.ResourceGroupName
    Assert-AreEqual $resp.AgentName $tg.AgentName
    Assert-AreEqual $resp.ServerName $tg.ServerName
    Assert-AreEqual $resp.TargetGroupName $tg.TargetGroupName
    Assert-AreEqual $resp.Members.Count 0
}

<#
    .SYNOPSIS
    Tests removing a target group with inpuut object
    .DESCRIPTION
    SmokeTest
#>
function Test-RemoveTargetGroupWithInputObject ($a1)
{
    $tg = Create-TargetGroupForTest $a1

    # Test using input object
    $resp = Remove-AzureRmSqlElasticJobTargetGroup -InputObject $tg
    Assert-AreEqual $resp.ResourceGroupName $tg.ResourceGroupName
    Assert-AreEqual $resp.AgentName $tg.AgentName
    Assert-AreEqual $resp.ServerName $tg.ServerName
    Assert-AreEqual $resp.TargetGroupName $tg.TargetGroupName
    Assert-AreEqual $resp.Members.Count 0
}

<#
    .SYNOPSIS
    Tests removing a target group with resource id
    .DESCRIPTION
    SmokeTest
#>
function Test-RemoveTargetGroupWithResourceId ($a1)
{
    $tg = Create-TargetGroupForTest $a1

    # Test using resource id
    $resp = Remove-AzureRmSqlElasticJobTargetGroup -ResourceId $tg.ResourceId
    Assert-AreEqual $resp.ResourceGroupName $tg.ResourceGroupName
    Assert-AreEqual $resp.AgentName $tg.AgentName
    Assert-AreEqual $resp.ServerName $tg.ServerName
    Assert-AreEqual $resp.TargetGroupName $tg.TargetGroupName
    Assert-AreEqual $resp.Members.Count 0
}

<#
    .SYNOPSIS
    Tests removing a target group with piping
    .DESCRIPTION
    SmokeTest
#>
function Test-RemoveTargetGroupWithPiping ($a1)
{
    $tg = Create-TargetGroupForTest $a1
    $tg2 = Create-TargetGroupForTest $a1

    # Test piping
    $resp = $tg | Remove-AzureRmSqlElasticJobTargetGroup
    Assert-AreEqual $resp.ResourceGroupName $tg.ResourceGroupName
    Assert-AreEqual $resp.AgentName $tg.AgentName
    Assert-AreEqual $resp.ServerName $tg.ServerName
    Assert-AreEqual $resp.TargetGroupName $tg.TargetGroupName
    Assert-AreEqual $resp.Members.Count 0

    # Test remove all
    $all = $a1 | Get-AzureRmSqlElasticJobTargetGroup
    $resp = $all | Remove-AzureRmSqlElasticJobTargetGroup
    Assert-True { $resp.Count -ge 1 }
}