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
	Tests creating a job credential
    .DESCRIPTION
	SmokeTest
#>
function Test-CreateJobCredential
{
    # Setup
    $rg1 = Create-ResourceGroupForTest
    $s1 = Create-ServerForTest $rg1 "westus2"
    $db1 = Create-DatabaseForTest $s1
    $a1 = Create-AgentForTest $db1

    # Credential params
    $cn1 = Get-JobCredentialName
    $cn2 = Get-JobCredentialName
    $cn3 = Get-JobCredentialName
    $cn4 = Get-JobCredentialName
    $c1 = Get-ServerCredential

    try 
    {
        # Create using default params
    	$resp1 = New-AzureRmSqlDatabaseAgentJobCredential -ResourceGroupName $rg1.ResourceGroupName -ServerName $s1.ServerName -AgentName $a1.AgentName -Name $cn1 -Credential $c1
        Assert-AreEqual $resp1.ResourceGroupName $rg1.ResourceGroupName
        Assert-AreEqual $resp1.ServerName $s1.ServerName
        Assert-AreEqual $resp1.CredentialName $cn1
        Assert-AreEqual $resp1.UserName $c1.UserName
        
        # Create using agent input object
    	$resp2 = New-AzureRmSqlDatabaseAgentJobCredential -InputObject $a1 -Name $cn2 -Credential $c1
        Assert-AreEqual $resp2.ResourceGroupName $rg1.ResourceGroupName
        Assert-AreEqual $resp2.ServerName $s1.ServerName
        Assert-AreEqual $resp2.CredentialName $cn2
        Assert-AreEqual $resp2.UserName $c1.UserName

        # Create using agent resource id
        $resp3 = New-AzureRmSqlDatabaseAgentJobCredential -ResourceId $a1.ResourceId -Name $cn3 -Credential $c1
        Assert-AreEqual $resp3.ResourceGroupName $rg1.ResourceGroupName
        Assert-AreEqual $resp3.ServerName $s1.ServerName
        Assert-AreEqual $resp3.CredentialName $cn3
        Assert-AreEqual $resp3.UserName $c1.UserName

        # Tests using piping
        $resp4 = $a1 | New-AzureRmSqlDatabaseAgentJobCredential -Name $cn4 -Credential $c1
        Assert-AreEqual $resp4.ResourceGroupName $rg1.ResourceGroupName
        Assert-AreEqual $resp4.ServerName $s1.ServerName
        Assert-AreEqual $resp4.CredentialName $cn4
        Assert-AreEqual $resp4.UserName $c1.UserName
    }
    finally
    {
        Remove-ResourceGroupForTest $rg1
    }
}

<#
	.SYNOPSIS
	Tests updating a job credential
    .DESCRIPTION
	SmokeTest
#>
function Test-UpdateJobCredential
{
    # Setup
    $rg1 = Create-ResourceGroupForTest
    $s1 = Create-ServerForTest $rg1 "westus2"
    $db1 = Create-DatabaseForTest $s1
    $a1 = Create-AgentForTest $db1
    $jc1 = Create-JobCredentialForTest $a1

    try
    {
        # Test default parameters
        $newCred = Get-Credential
        $resp1 = Set-AzureRmSqlDatabaseAgentJobCredential -ResourceGroupName $rg1.ResourceGroupName -ServerName $s1.ServerName -AgentName $a1.AgentName -Name $jc1.CredentialName -Credential $newCred

        Assert-AreEqual $resp1.ResourceGroupName $rg1.ResourceGroupName
        Assert-AreEqual $resp1.ServerName $s1.ServerName
        Assert-AreEqual $resp1.AgentName $a1.AgentName
        Assert-AreEqual $resp1.CredentialName $jc1.CredentialName
        Assert-AreEqual $resp1.UserName $newCred.UserName

        # Test job credential input object
        $newCred = Get-Credential
        $resp2 = Set-AzureRmSqlDatabaseAgentJobCredential -InputObject $jc1 -Credential $newCred

        Assert-AreEqual $resp2.ResourceGroupName $rg1.ResourceGroupName
        Assert-AreEqual $resp2.ServerName $s1.ServerName
        Assert-AreEqual $resp2.AgentName $a1.AgentName
        Assert-AreEqual $resp2.CredentialName $jc1.CredentialName
        Assert-AreEqual $resp2.UserName $newCred.UserName

        # Test job credential resource id
        $newCred = Get-Credential
        $resp3 = Set-AzureRmSqlDatabaseAgentJobCredential -ResourceId $jc1.ResourceId -Credential $newCred
        Assert-AreEqual $resp3.ResourceGroupName $rg1.ResourceGroupName
        Assert-AreEqual $resp3.ServerName $s1.ServerName
        Assert-AreEqual $resp3.AgentName $a1.AgentName
        Assert-AreEqual $resp3.CredentialName $jc1.CredentialName
        Assert-AreEqual $resp3.UserName $newCred.UserName

        # Test piping
        $newCred = Get-Credential
        $resp4 = $jc1 | Set-AzureRmSqlDatabaseAgentJobCredential -Credential $newCred
        Assert-AreEqual $resp4.ResourceGroupName $rg1.ResourceGroupName
        Assert-AreEqual $resp4.ServerName $s1.ServerName
        Assert-AreEqual $resp4.AgentName $a1.AgentName
        Assert-AreEqual $resp4.CredentialName $jc1.CredentialName
        Assert-AreEqual $resp4.UserName $newCred.UserName
    }
    finally 
    {
        Remove-ResourceGroupForTest $rg1
    }
}

<#
	.SYNOPSIS
	Tests getting a job credential
    .DESCRIPTION
	SmokeTest
#>
function Test-GetJobCredential
{
    # Setup
    $rg1 = Create-ResourceGroupForTest
    $s1 = Create-ServerForTest $rg1 "westus2"
    $db1 = Create-DatabaseForTest $s1
    $a1 = Create-AgentForTest $db1
    $jc1 = Create-JobCredentialForTest $a1
    $jc2 = Create-JobCredentialForTest $a1
    $jc3 = Create-JobCredentialForTest $a1
    $jc4 = Create-JobCredentialForTest $a1

    try
    {
        # Test default parameters - get specific credential
        $resp1 = Get-AzureRmSqlDatabaseAgentJobCredential -ResourceGroupName $rg1.ResourceGroupName -ServerName $s1.ServerName -AgentName $a1.AgentName -Name $jc1.CredentialName

        Assert-AreEqual $resp1.ResourceGroupName $rg1.ResourceGroupName
        Assert-AreEqual $resp1.ServerName $s1.ServerName
        Assert-AreEqual $resp1.AgentName $a1.AgentName
        Assert-AreEqual $resp1.CredentialName $jc1.CredentialName
        Assert-AreEqual $resp1.UserName $jc1.UserName

        # Test default parameters - get all credentials
        $all = Get-AzureRmSqlDatabaseAgentJobCredential -ResourceGroupName $rg1.ResourceGroupName -ServerName $s1.ServerName -AgentName $a1.AgentName
        Assert-AreEqual 4 $all.Count

        # Test job credential input object
        $resp2 = Get-AzureRmSqlDatabaseAgentJobCredential -InputObject $a1 -Name $jc2.CredentialName

        Assert-AreEqual $resp2.ResourceGroupName $rg1.ResourceGroupName
        Assert-AreEqual $resp2.ServerName $s1.ServerName
        Assert-AreEqual $resp2.AgentName $a1.AgentName
        Assert-AreEqual $resp2.CredentialName $jc2.CredentialName
        Assert-AreEqual $resp2.UserName $jc2.UserName
        
        # Test job credential input object - get all credentials
        $all = Get-AzureRmSqlDatabaseAgentJobCredential -InputObject $a1
        Assert-AreEqual 4 $all.Count

        # Test job credential resource id
        $resp3 = Get-AzureRmSqlDatabaseAgentJobCredential -InputObject $a1 -Name $jc3.CredentialName

        Assert-AreEqual $resp3.ResourceGroupName $rg1.ResourceGroupName
        Assert-AreEqual $resp3.ServerName $s1.ServerName
        Assert-AreEqual $resp3.AgentName $a1.AgentName
        Assert-AreEqual $resp3.CredentialName $jc3.CredentialName
        Assert-AreEqual $resp3.UserName $jc3.UserName
        
        # Test job credential resource id - get all credentials
        $all = Get-AzureRmSqlDatabaseAgentJobCredential -ResourceId $a1.ResourceId
        Assert-AreEqual 4 $all.Count

        # Test piping - get job credential
        $resp4 = $a1 | Get-AzureRmSqlDatabaseAgentJobCredential -Name $jc4.CredentialName
        Assert-AreEqual $resp4.ResourceGroupName $rg1.ResourceGroupName
        Assert-AreEqual $resp4.ServerName $s1.ServerName
        Assert-AreEqual $resp4.AgentName $a1.AgentName
        Assert-AreEqual $resp4.CredentialName $jc4.CredentialName
        Assert-AreEqual $resp4.UserName $jc4.UserName

        # Test piping - get all credentials from agent
        $all = $a1 | Get-AzureRmSqlDatabaseAgentJobCredential
        Assert-AreEqual 4 $all.Count
    }
    finally 
    {
        Remove-ResourceGroupForTest $rg1
    }
}

<#
	.SYNOPSIS
	Tests removing a job credential
    .DESCRIPTION
	SmokeTest
#>
function Test-RemoveJobCredential
{
    # Setup
    $rg1 = Create-ResourceGroupForTest
    $s1 = Create-ServerForTest $rg1 "westus2"
    $db1 = Create-DatabaseForTest $s1
    $a1 = Create-AgentForTest $db1

    $jc1 = Create-JobCredentialForTest $a1
    $jc2 = Create-JobCredentialForTest $a1
    $jc3 = Create-JobCredentialForTest $a1
    $jc4 = Create-JobCredentialForTest $a1

    try
    {
        # Test default parameters - Remove credential
        $resp1 = Remove-AzureRmSqlDatabaseAgentJobCredential -ResourceGroupName $rg1.ResourceGroupName -ServerName $s1.ServerName -AgentName $a1.AgentName -Name $jc1.CredentialName

        Assert-AreEqual $resp1.ResourceGroupName $rg1.ResourceGroupName
        Assert-AreEqual $resp1.ServerName $s1.ServerName
        Assert-AreEqual $resp1.AgentName $a1.AgentName
        Assert-AreEqual $resp1.CredentialName $jc1.CredentialName
        Assert-AreEqual $resp1.UserName $jc1.UserName

        # Test input object 
        $resp2 = Remove-AzureRmSqlDatabaseAgentJobCredential -InputObject $jc2

        Assert-AreEqual $resp2.ResourceGroupName $rg1.ResourceGroupName
        Assert-AreEqual $resp2.ServerName $s1.ServerName
        Assert-AreEqual $resp2.AgentName $a1.AgentName
        Assert-AreEqual $resp2.CredentialName $jc2.CredentialName
        Assert-AreEqual $resp2.UserName $jc2.UserName

        # Test resource id
        $resp3 = Remove-AzureRmSqlDatabaseAgentJobCredential -ResourceId $jc3.ResourceId

        Assert-AreEqual $resp3.ResourceGroupName $rg1.ResourceGroupName
        Assert-AreEqual $resp3.ServerName $s1.ServerName
        Assert-AreEqual $resp3.AgentName $a1.AgentName
        Assert-AreEqual $resp3.CredentialName $jc3.CredentialName
        Assert-AreEqual $resp3.UserName $jc3.UserName

        # Test piping
        $resp4 = $jc4 | Remove-AzureRmSqlDatabaseAgentJobCredential

        Assert-AreEqual $resp4.ResourceGroupName $rg1.ResourceGroupName
        Assert-AreEqual $resp4.ServerName $s1.ServerName
        Assert-AreEqual $resp4.AgentName $a1.AgentName
        Assert-AreEqual $resp4.CredentialName $jc4.CredentialName
        Assert-AreEqual $resp4.UserName $jc4.UserName

        # Confirm no more credentials
   		$all = Get-AzureRmSqlDatabaseAgent -InputObject $s1 -Name $a1.AgentName | Get-AzureRmSqlDatabaseAgentJobCredential
		Assert-AreEqual $all.Count 0
    }
    finally 
    {
        Remove-ResourceGroupForTest $rg1
    }
}