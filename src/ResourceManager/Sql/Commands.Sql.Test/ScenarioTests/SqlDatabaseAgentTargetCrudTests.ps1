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
	Tests adding server targets to target group
    .DESCRIPTION
	SmokeTest
#>
function Test-ServerTarget
{
    # Setup
    $rg1 = Create-ResourceGroupForTest
    $s1 = Create-ServerForTest $rg1 "westus2"
    $db1 = Create-DatabaseForTest $s1
    $a1 = Create-AgentForTest $db1
    $jc1 = Create-JobCredentialForTest $a1
    $tg1 = Create-TargetGroupForTest $a1

    # Server Target Helper Objects
    $st1 =  @{ ServerName = "s1"; } # Include
    $st2 =  @{ ServerName = "s2"; } # Include
    $st3 =  @{ ServerName = "s3"; } # Exclude
    $st4 =  @{ ServerName = "s4"; } # Include

    try
    {
        Test-AddServerTarget $a1 $jc1 $tg1 $st1 $st2 $st3 $st4
        Test-RemoveServerTarget $a1 $jc1 $tg1 $st1 $st2 $st3 $st4
    }
    finally
    {
        Remove-ResourceGroupForTest $rg1
    }
}

<#
	.SYNOPSIS
	Tests adding server targets to target group
    .DESCRIPTION
	SmokeTest
#>
function Test-AddServerTarget($a1, $jc1, $tg1, $st1, $st2, $st3, $st4)
{
    ## --------- Server Target Tests -------------
    ## Test default parameters 

    # Include s1
    $resp = Add-AzureRmSqlDatabaseAgentTarget -ResourceGroupName $a1.ResourceGroupName -AgentServerName $a1.ServerName -AgentName $a1.AgentName -TargetGroupName $tg1.TargetGroupName -ServerName $st1.ServerName -RefreshCredentialName $jc1.CredentialName

    Assert-AreEqual $resp.ServerName $st1.ServerName
    Assert-AreEqual $resp.RefreshCredential $jc1.ResourceId
    Assert-AreEqual $resp.MembershipType "Include"
    Assert-AreEqual $resp.Type "SqlServer"

    # Exclude s1
    $resp = Add-AzureRmSqlDatabaseAgentTarget -ResourceGroupName $a1.ResourceGroupName -AgentServerName $a1.ServerName -AgentName $a1.AgentName -TargetGroupName $tg1.TargetGroupName -ServerName $st1.ServerName -RefreshCredentialName $jc1.CredentialName -Exclude

    Assert-AreEqual $resp.ServerName $st1.ServerName
    Assert-AreEqual $resp.RefreshCredential $jc1.ResourceId
    Assert-AreEqual $resp.MembershipType "Exclude"
    Assert-AreEqual $resp.Type "SqlServer"

    # Exclude s1 again - no errors and no resp
    $resp = Add-AzureRmSqlDatabaseAgentTarget -ResourceGroupName $a1.ResourceGroupName -AgentServerName $a1.ServerName -AgentName $a1.AgentName -TargetGroupName $tg1.TargetGroupName -ServerName $st1.ServerName -RefreshCredentialName $jc1.CredentialName -Exclude
    Assert-Null $resp

    # Include s1 - no errors and resp
    $resp = Add-AzureRmSqlDatabaseAgentTarget -ResourceGroupName $a1.ResourceGroupName -AgentServerName $a1.ServerName -AgentName $a1.AgentName -TargetGroupName $tg1.TargetGroupName -ServerName $st1.ServerName -RefreshCredentialName $jc1.CredentialName

    # Test updating back to include shows membership type as Include again.
    Assert-AreEqual $resp.ServerName $st1.ServerName
    Assert-AreEqual $resp.RefreshCredential $jc1.ResourceId
    Assert-AreEqual $resp.MembershipType "Include"
    Assert-AreEqual $resp.Type "SqlServer"

    $all = Get-AzureRmSqlDatabaseAgentTargetGroup -InputObject $a1 -Name $tg1.TargetGroupName
    Assert-AreEqual $all.Members.Count 1

    ## Test input object

    # Include s2
    $resp = Add-AzureRmSqlDatabaseAgentTarget -InputObject $tg1 -ServerName $st2.ServerName -RefreshCredentialName $jc1.CredentialName
        
    Assert-AreEqual $resp.ServerName $st2.ServerName
    Assert-AreEqual $resp.RefreshCredential $jc1.ResourceId
    Assert-AreEqual $resp.MembershipType "Include"
    Assert-AreEqual $resp.Type "SqlServer"

    # Exclude s2
    $resp = Add-AzureRmSqlDatabaseAgentTarget -InputObject $tg1 -ServerName $st2.ServerName -RefreshCredentialName $jc1.CredentialName -Exclude
        
    Assert-AreEqual $resp.ServerName $st2.ServerName
    Assert-AreEqual $resp.RefreshCredential $jc1.ResourceId
    Assert-AreEqual $resp.MembershipType "Exclude"
    Assert-AreEqual $resp.Type "SqlServer"

    # Exclude s2 again - no errors and no resp
    $resp = Add-AzureRmSqlDatabaseAgentTarget -InputObject $tg1 -ServerName $st2.ServerName -RefreshCredentialName $jc1.CredentialName -Exclude
    Assert-Null $resp
        
    # Include s2 - no errors and resp
    $resp = Add-AzureRmSqlDatabaseAgentTarget -InputObject $tg1 -ServerName $st2.ServerName -RefreshCredentialName $jc1.CredentialName
        
    Assert-AreEqual $resp.ServerName $st2.ServerName
    Assert-AreEqual $resp.RefreshCredential $jc1.ResourceId
    Assert-AreEqual $resp.MembershipType "Include"
    Assert-AreEqual $resp.Type "SqlServer"

    $all = Get-AzureRmSqlDatabaseAgentTargetGroup -InputObject $a1 -Name $tg1.TargetGroupName
    Assert-AreEqual $all.Members.Count 2

    ## Test resource id

    # Include s3
    $resp = Add-AzureRmSqlDatabaseAgentTarget -ResourceId $tg1.ResourceId -ServerName $st3.ServerName -RefreshCredentialName $jc1.CredentialName
        
    Assert-AreEqual $resp.ServerName $st3.ServerName
    Assert-AreEqual $resp.RefreshCredential $jc1.ResourceId
    Assert-AreEqual $resp.MembershipType "Include"
    Assert-AreEqual $resp.Type "SqlServer"

    # Exclude s3
    $resp = Add-AzureRmSqlDatabaseAgentTarget -ResourceId $tg1.ResourceId -ServerName $st3.ServerName -RefreshCredentialName $jc1.CredentialName -Exclude
        
    Assert-AreEqual $resp.ServerName $st3.ServerName
    Assert-AreEqual $resp.RefreshCredential $jc1.ResourceId
    Assert-AreEqual $resp.MembershipType "Exclude"
    Assert-AreEqual $resp.Type "SqlServer"

    # Exclude s3 again - no errors and no resp
    $resp = Add-AzureRmSqlDatabaseAgentTarget -ResourceId $tg1.ResourceId -ServerName $st3.ServerName -RefreshCredentialName $jc1.CredentialName -Exclude
    Assert-Null $resp

    $all = Get-AzureRmSqlDatabaseAgentTargetGroup -InputObject $a1 -Name $tg1.TargetGroupName
    Assert-AreEqual $all.Members.Count 3

    ## Test piping

    # Add s4 to tg1
    $resp = $tg1 | Add-AzureRmSqlDatabaseAgentTarget -ServerName $st4.ServerName -RefreshCredentialName $jc1.CredentialName
    Assert-AreEqual $resp.ServerName $st4.ServerName
    Assert-AreEqual $resp.RefreshCredential $jc1.ResourceId
    Assert-AreEqual $resp.MembershipType "Include"
    Assert-AreEqual $resp.Type "SqlServer"

    $all = Get-AzureRmSqlDatabaseAgentTargetGroup -InputObject $a1 -Name $tg1.TargetGroupName
    Assert-AreEqual $all.Members.Count 4

    # Add all servers from rg1 to tg1 - Could also add other servers from all resource groups but unsure what count would be otherwise
    $added = Get-AzureRmSqlServer -ResourceGroupName $a1.ResourceGroupName | Add-AzureRmSqlDatabaseAgentTarget -InputObject $tg1 -RefreshCredentialName $jc1.CredentialName
    Assert-AreEqual 1 $added.Count

    $all = Get-AzureRmSqlDatabaseAgentTargetGroup -InputObject $a1 -Name $tg1.TargetGroupName
    Assert-AreEqual $all.Members.Count 5
}

<#
	.SYNOPSIS
	Tests removing server targets to target group
    .DESCRIPTION
	SmokeTest
#>
function Test-RemoveServerTarget($a1, $jc1, $tg1, $st1, $st2, $st3, $st4)
{
    ## --------- Server Target Tests -------------
    ## Test default parameters 

    # Remove s1
    $resp = Remove-AzureRmSqlDatabaseAgentTarget -ResourceGroupName $a1.ResourceGroupName -AgentServerName $a1.ServerName -AgentName $a1.AgentName -TargetGroupName $tg1.TargetGroupName -ServerName $st1.ServerName -RefreshCredentialName $jc1.CredentialName

    Assert-AreEqual $resp.ServerName $st1.ServerName
    Assert-AreEqual $resp.RefreshCredential $jc1.ResourceId
    Assert-AreEqual $resp.MembershipType "Include"
    Assert-AreEqual $resp.Type "SqlServer"

    # Try remove again - should have no resp
    $resp = Remove-AzureRmSqlDatabaseAgentTarget -ResourceGroupName $a1.ResourceGroupName -AgentServerName $a1.ServerName -AgentName $a1.AgentName -TargetGroupName $tg1.TargetGroupName -ServerName $st1.ServerName -RefreshCredentialName $jc1.CredentialName
    Assert-Null $resp

    $all = Get-AzureRmSqlDatabaseAgentTargetGroup -InputObject $a1 -Name $tg1.TargetGroupName
    Assert-AreEqual $all.Members.Count 4

    ## Test input object

    # Remove s2
    $resp = Remove-AzureRmSqlDatabaseAgentTarget -InputObject $tg1 -ServerName $st2.ServerName -RefreshCredentialName $jc1.CredentialName
        
    Assert-AreEqual $resp.ServerName $st2.ServerName
    Assert-AreEqual $resp.RefreshCredential $jc1.ResourceId
    Assert-AreEqual $resp.MembershipType "Include"
    Assert-AreEqual $resp.Type "SqlServer"

    # Try remove again - should have no resp
    $resp = Remove-AzureRmSqlDatabaseAgentTarget -InputObject $tg1 -ServerName $st2.ServerName -RefreshCredentialName $jc1.CredentialName
    Assert-Null $resp

    $all = Get-AzureRmSqlDatabaseAgentTargetGroup -InputObject $a1 -Name $tg1.TargetGroupName
    Assert-AreEqual $all.Members.Count 3

    ## Test resource id

    # Remove s3
    $resp = Remove-AzureRmSqlDatabaseAgentTarget -ResourceId $tg1.ResourceId -ServerName $st3.ServerName -RefreshCredentialName $jc1.CredentialName
    
    Assert-AreEqual $resp.ServerName $st3.ServerName
    Assert-AreEqual $resp.RefreshCredential $jc1.ResourceId
    Assert-AreEqual $resp.MembershipType "Exclude"
    Assert-AreEqual $resp.Type "SqlServer"

    # Try remove again - should have no resp
    $resp = Remove-AzureRmSqlDatabaseAgentTarget -ResourceId $tg1.ResourceId -ServerName $st3.ServerName -RefreshCredentialName $jc1.CredentialName
    Assert-Null $resp

    $all = Get-AzureRmSqlDatabaseAgentTargetGroup -InputObject $a1 -Name $tg1.TargetGroupName
    Assert-AreEqual $all.Members.Count 2

    ## Test piping

    # Remove s4 to tg1
    $resp = $tg1 | Remove-AzureRmSqlDatabaseAgentTarget -ServerName $st4.ServerName -RefreshCredentialName $jc1.CredentialName
    Assert-AreEqual $resp.ServerName $st4.ServerName
    Assert-AreEqual $resp.RefreshCredential $jc1.ResourceId
    Assert-AreEqual $resp.MembershipType "Include"
    Assert-AreEqual $resp.Type "SqlServer"

    $all = Get-AzureRmSqlDatabaseAgentTargetGroup -InputObject $a1 -Name $tg1.TargetGroupName
    Assert-AreEqual $all.Members.Count 1

    # Remove all servers from rg1 in tg1
    $removed = Get-AzureRmSqlServer -ResourceGroupName $a1.ResourceGroupName | Remove-AzureRmSqlDatabaseAgentTarget -InputObject $tg1 -RefreshCredentialName $jc1.CredentialName
    Assert-AreEqual 1 $removed.Count

    $all = Get-AzureRmSqlDatabaseAgentTargetGroup -InputObject $a1 -Name $tg1.TargetGroupName
    Assert-AreEqual $all.Members.Count 0
}

<#
	.SYNOPSIS
	Tests adding targets to target group
    .DESCRIPTION
	SmokeTest
#>
function Test-DatabaseTarget
{
    # Setup
    $rg1 = Create-ResourceGroupForTest
    $s1 = Create-ServerForTest $rg1 "westus2"
    $db1 = Create-DatabaseForTest $s1
    $a1 = Create-AgentForTest $db1
    $jc1 = Create-JobCredentialForTest $a1
    $tg1 = Create-TargetGroupForTest $a1

    # Target Helper Objects
    $dbt1 = @{ ServerName = "s1"; DatabaseName = "db1" } # Include
    $dbt2 = @{ ServerName = "s2"; DatabaseName = "db2" } # Include
    $dbt3 = @{ ServerName = "s3"; DatabaseName = "db3" } # Exclude
    $dbt4 = @{ ServerName = "s4"; DatabaseName = "db4" } # Include

    try
    {
        Test-AddDatabaseTarget $a1 $jc1 $tg1 $dbt1 $dbt2 $dbt3 $dbt4
        Test-RemoveDatabaseTarget $a1 $jc1 $tg1 $dbt1 $dbt2 $dbt3 $dbt4
    }
    finally
    {
        Remove-ResourceGroupForTest $rg1
    }
}

<#
	.SYNOPSIS
	Tests adding database targets to target group
    .DESCRIPTION
	SmokeTest
#>
function Test-AddDatabaseTarget($a1, $jc1, $tg1, $dbt1, $dbt2, $dbt3, $dbt4)
{
    ## --------- Database Target Tests -------------
    ## Test default parameters

    # Include db1
    $resp = Add-AzureRmSqlDatabaseAgentTarget -ResourceGroupName $a1.ResourceGroupName -AgentServerName $a1.ServerName -AgentName $a1.AgentName -TargetGroupName $tg1.TargetGroupName -ServerName $dbt1.ServerName -DatabaseName $dbt1.DatabaseName 

    Assert-AreEqual $resp.ServerName $dbt1.ServerName
    Assert-AreEqual $resp.DatabaseName $dbt1.DatabaseName
    Assert-AreEqual $resp.MembershipType "Include"
    Assert-AreEqual $resp.Type "SqlDatabase"

    # Exclude db1
    $resp = Add-AzureRmSqlDatabaseAgentTarget -ResourceGroupName $a1.ResourceGroupName -AgentServerName $a1.ServerName -AgentName $a1.AgentName -TargetGroupName $tg1.TargetGroupName -ServerName $dbt1.ServerName -DatabaseName $dbt1.DatabaseName -Exclude

    Assert-AreEqual $resp.ServerName $dbt1.ServerName
    Assert-AreEqual $resp.DatabaseName $dbt1.DatabaseName
    Assert-AreEqual $resp.MembershipType "Exclude"
    Assert-AreEqual $resp.Type "SqlDatabase"

    # Exclude db1 again - no errors and no resp
    $resp = Add-AzureRmSqlDatabaseAgentTarget -ResourceGroupName $a1.ResourceGroupName -AgentServerName $a1.ServerName -AgentName $a1.AgentName -TargetGroupName $tg1.TargetGroupName -ServerName $dbt1.ServerName -DatabaseName $dbt1.DatabaseName -Exclude
    Assert-Null $resp

    # Include db1 - no errors and resp
    $resp = Add-AzureRmSqlDatabaseAgentTarget -ResourceGroupName $a1.ResourceGroupName -AgentServerName $a1.ServerName -AgentName $a1.AgentName -TargetGroupName $tg1.TargetGroupName -ServerName $dbt1.ServerName -DatabaseName $dbt1.DatabaseName

    # Test updating back to include shows membership type as Include again.
    Assert-AreEqual $resp.ServerName $dbt1.ServerName
    Assert-AreEqual $resp.DatabaseName $dbt1.DatabaseName
    Assert-AreEqual $resp.MembershipType "Include"
    Assert-AreEqual $resp.Type "SqlDatabase"

    $all = Get-AzureRmSqlDatabaseAgentTargetGroup -InputObject $a1 -Name $tg1.TargetGroupName
    Assert-AreEqual $all.Members.Count 1

    ## Test input object

    # Include db2
    $resp = Add-AzureRmSqlDatabaseAgentTarget -InputObject $tg1 -ServerName $dbt2.ServerName -DatabaseName $dbt2.DatabaseName

    Assert-AreEqual $resp.ServerName $dbt2.ServerName
    Assert-AreEqual $resp.DatabaseName $dbt2.DatabaseName
    Assert-AreEqual $resp.MembershipType "Include"
    Assert-AreEqual $resp.Type "SqlDatabase"

    # Exclude db2
    $resp = Add-AzureRmSqlDatabaseAgentTarget -InputObject $tg1 -ServerName $dbt2.ServerName -DatabaseName $dbt2.DatabaseName -Exclude

    Assert-AreEqual $resp.ServerName $dbt2.ServerName
    Assert-AreEqual $resp.DatabaseName $dbt2.DatabaseName
    Assert-AreEqual $resp.MembershipType "Exclude"
    Assert-AreEqual $resp.Type "SqlDatabase"

    # Exclude db2 again - no errors and no resp
    $resp = Add-AzureRmSqlDatabaseAgentTarget -InputObject $tg1 -ServerName $dbt2.ServerName -DatabaseName $dbt2.DatabaseName -Exclude
    Assert-Null $resp

    # Include db2 - no errors and resp
    $resp = Add-AzureRmSqlDatabaseAgentTarget -InputObject $tg1 -ServerName $dbt2.ServerName -DatabaseName $dbt2.DatabaseName

    # Test updating back to include shows membership type as Include again.
    Assert-AreEqual $resp.ServerName $dbt2.ServerName
    Assert-AreEqual $resp.DatabaseName $dbt2.DatabaseName
    Assert-AreEqual $resp.MembershipType "Include"
    Assert-AreEqual $resp.Type "SqlDatabase"

    $all = Get-AzureRmSqlDatabaseAgentTargetGroup -InputObject $a1 -Name $tg1.TargetGroupName
    Assert-AreEqual $all.Members.Count 2

    ## Test resource id

    # Include db3
    $resp = Add-AzureRmSqlDatabaseAgentTarget -ResourceId $tg1.ResourceId -ServerName $dbt3.ServerName -DatabaseName $dbt3.DatabaseName

    Assert-AreEqual $resp.ServerName $dbt3.ServerName
    Assert-AreEqual $resp.DatabaseName $dbt3.DatabaseName
    Assert-AreEqual $resp.MembershipType "Include"
    Assert-AreEqual $resp.Type "SqlDatabase"

    # Exclude db3
    $resp = Add-AzureRmSqlDatabaseAgentTarget -ResourceId $tg1.ResourceId -ServerName $dbt3.ServerName -DatabaseName $dbt3.DatabaseName -Exclude

    Assert-AreEqual $resp.ServerName $dbt3.ServerName
    Assert-AreEqual $resp.DatabaseName $dbt3.DatabaseName
    Assert-AreEqual $resp.MembershipType "Exclude"
    Assert-AreEqual $resp.Type "SqlDatabase"

    # Exclude db3 again - no errors and no resp
    $resp = Add-AzureRmSqlDatabaseAgentTarget -ResourceId $tg1.ResourceId -ServerName $dbt3.ServerName -DatabaseName $dbt3.DatabaseName -Exclude
    Assert-Null $resp

    $all = Get-AzureRmSqlDatabaseAgentTargetGroup -InputObject $a1 -Name $tg1.TargetGroupName
    Assert-AreEqual $all.Members.Count 3

    ## Test piping

    # Add db4 to tg1
    $resp = $tg1 | Add-AzureRmSqlDatabaseAgentTarget -ServerName $dbt4.ServerName -DatabaseName $dbt4.DatabaseName
    Assert-AreEqual $resp.ServerName $dbt4.ServerName
    Assert-AreEqual $resp.DatabaseName $dbt4.DatabaseName
    Assert-AreEqual $resp.MembershipType "Include"
    Assert-AreEqual $resp.Type "SqlDatabase"

    $all = Get-AzureRmSqlDatabaseAgentTargetGroup -InputObject $a1 -Name $tg1.TargetGroupName
    Assert-AreEqual $all.Members.Count 4

    # Add all databases from server in rg1 to tg1 (should be master & 1 user db)
    $added = Get-AzureRmSqlServer -ResourceGroupName $a1.ResourceGroupName | Get-AzureRmSqlDatabase | Add-AzureRmSqlDatabaseAgentTarget -InputObject $tg1
    Assert-AreEqual 2 $added.Count

    $all = Get-AzureRmSqlDatabaseAgentTargetGroup -InputObject $a1 -Name $tg1.TargetGroupName
    Assert-AreEqual $all.Members.Count 6
}

<#
	.SYNOPSIS
	Tests removing database targets from target group
    .DESCRIPTION
	SmokeTest
#>
function Test-RemoveDatabaseTarget($a1, $jc1, $tg1, $dbt1, $dbt2, $dbt3, $dbt4)
{
    ## --------- Database Target Tests -------------
    ## Test default parameters

    # Remove db1
    $resp = Remove-AzureRmSqlDatabaseAgentTarget -ResourceGroupName $a1.ResourceGroupName -AgentServerName $a1.ServerName -AgentName $a1.AgentName -TargetGroupName $tg1.TargetGroupName -ServerName $dbt1.ServerName -DatabaseName $dbt1.DatabaseName
    Assert-AreEqual $resp.ServerName $dbt1.ServerName
    Assert-AreEqual $resp.DatabaseName $dbt1.DatabaseName
    Assert-AreEqual $resp.MembershipType "Include"
    Assert-AreEqual $resp.Type "SqlDatabase"

    # Should have no resp
    $resp = Remove-AzureRmSqlDatabaseAgentTarget -ResourceGroupName $a1.ResourceGroupName -AgentServerName $a1.ServerName -AgentName $a1.AgentName -TargetGroupName $tg1.TargetGroupName -ServerName $dbt1.ServerName -DatabaseName $dbt1.DatabaseName
    Assert-Null $resp

    $all = Get-AzureRmSqlDatabaseAgentTargetGroup -InputObject $a1 -Name $tg1.TargetGroupName
    Assert-AreEqual $all.Members.Count 5

    ## Test input object

    # Remove db2
    $resp = Remove-AzureRmSqlDatabaseAgentTarget -InputObject $tg1 -ServerName $dbt2.ServerName -DatabaseName $dbt2.DatabaseName
    Assert-AreEqual $resp.ServerName $dbt2.ServerName
    Assert-AreEqual $resp.DatabaseName $dbt2.DatabaseName
    Assert-AreEqual $resp.MembershipType "Include"
    Assert-AreEqual $resp.Type "SqlDatabase"

    # Should have no resp
    $resp = Remove-AzureRmSqlDatabaseAgentTarget -InputObject $tg1 -ServerName $dbt2.ServerName -DatabaseName $dbt2.DatabaseName
    Assert-Null $resp

    $all = Get-AzureRmSqlDatabaseAgentTargetGroup -InputObject $a1 -Name $tg1.TargetGroupName
    Assert-AreEqual $all.Members.Count 4

    ## Test resource id

    # Remove db3
    $resp = Remove-AzureRmSqlDatabaseAgentTarget -ResourceId $tg1.ResourceId -ServerName $dbt3.ServerName -DatabaseName $dbt3.DatabaseName
    Assert-AreEqual $resp.ServerName $dbt3.ServerName
    Assert-AreEqual $resp.DatabaseName $dbt3.DatabaseName
    Assert-AreEqual $resp.MembershipType "Exclude"
    Assert-AreEqual $resp.Type "SqlDatabase"
    
    # Should have no resp
    $resp = Remove-AzureRmSqlDatabaseAgentTarget -ResourceId $tg1.ResourceId -ServerName $dbt3.ServerName -DatabaseName $dbt3.DatabaseName
    Assert-Null $resp

    $all = Get-AzureRmSqlDatabaseAgentTargetGroup -InputObject $a1 -Name $tg1.TargetGroupName
    Assert-AreEqual $all.Members.Count 3

    ## Test piping

    # Remove db4 to tg1
    $resp = $tg1 | Remove-AzureRmSqlDatabaseAgentTarget -ServerName $dbt4.ServerName -DatabaseName $dbt4.DatabaseName
    Assert-AreEqual $resp.ServerName $dbt4.ServerName
    Assert-AreEqual $resp.DatabaseName $dbt4.DatabaseName
    Assert-AreEqual $resp.MembershipType "Include"
    Assert-AreEqual $resp.Type "SqlDatabase"

    $all = Get-AzureRmSqlDatabaseAgentTargetGroup -InputObject $a1 -Name $tg1.TargetGroupName
    Assert-AreEqual $all.Members.Count 2

    # Remove all databases from server in rg1 to tg1 (should be master & 1 user db)
    $removed = Get-AzureRmSqlServer -ResourceGroupName $a1.ResourceGroupName | Get-AzureRmSqlDatabase | Remove-AzureRmSqlDatabaseAgentTarget -InputObject $tg1
    Assert-AreEqual 2 $removed.Count

    $all = Get-AzureRmSqlDatabaseAgentTargetGroup -InputObject $a1 -Name $tg1.TargetGroupName
    Assert-AreEqual $all.Members.Count 0
}


<#
	.SYNOPSIS
	Tests adding and deleting elastic pool targets
    .DESCRIPTION
	SmokeTest
#>
function Test-ElasticPoolTarget
{
    # Setup
    $rg1 = Create-ResourceGroupForTest
    $s1 = Create-ServerForTest $rg1 "westus2"
    $db1 = Create-DatabaseForTest $s1
    $ep1 = Create-ElasticPoolForTest $s1
    $a1 = Create-AgentForTest $db1
    $jc1 = Create-JobCredentialForTest $a1
    $tg1 = Create-TargetGroupForTest $a1

    # Target Helper Objects
    $ept1 = @{ ServerName = "s1"; ElasticPoolName = "ep1"; }
    $ept2 = @{ ServerName = "s2"; ElasticPoolName = "ep2"; }
    $ept3 = @{ ServerName = "s3"; ElasticPoolName = "ep3"; }
    $ept4 = @{ ServerName = "s4"; ElasticPoolName = "ep4"; }

    try
    {
        Test-AddElasticPoolTarget $a1 $jc1 $tg1 $ept1 $ept2 $ept3 $ept4
        Test-RemoveElasticPoolTarget $a1 $jc1 $tg1 $ept1 $ept2 $ept3 $ept4
    }
    finally
    {
        Remove-ResourceGroupForTest $rg1
    }
}

<#
	.SYNOPSIS
	Tests adding elastic pool targets to target group
    .DESCRIPTION
	SmokeTest
#>
function Test-AddElasticPoolTarget($a1, $jc1, $tg1, $ept1, $ept2, $ept3, $ept4)
{
    ## --------- Elastic Pool Target Tests -------------
    ## Test default parameters

    # Include ep1
    $resp = Add-AzureRmSqlDatabaseAgentTarget -ResourceGroupName $a1.ResourceGroupName -AgentServerName $a1.ServerName -AgentName $a1.AgentName -TargetGroupName $tg1.TargetGroupName -ServerName $ept1.ServerName -ElasticPoolName $ept1.ElasticPoolName -RefreshCredentialName $jc1.CredentialName

    Assert-AreEqual $resp.ServerName $ept1.ServerName
    Assert-AreEqual $resp.ElasticPoolName $ept1.ElasticPoolName
    Assert-AreEqual $resp.RefreshCredential $jc1.ResourceId
    Assert-AreEqual $resp.MembershipType "Include"
    Assert-AreEqual $resp.Type "SqlElasticPool"

    # Exclude ep1
    $resp = Add-AzureRmSqlDatabaseAgentTarget -ResourceGroupName $a1.ResourceGroupName -AgentServerName $a1.ServerName -AgentName $a1.AgentName -TargetGroupName $tg1.TargetGroupName -ServerName $ept1.ServerName -ElasticPoolName $ept1.ElasticPoolName -RefreshCredentialName $jc1.CredentialName -Exclude

    Assert-AreEqual $resp.ServerName $ept1.ServerName
    Assert-AreEqual $resp.ElasticPoolName $ept1.ElasticPoolName
    Assert-AreEqual $resp.RefreshCredential $jc1.ResourceId
    Assert-AreEqual $resp.MembershipType "Exclude"
    Assert-AreEqual $resp.Type "SqlElasticPool"

    # Exclude ep1 again - no errors and no resp
    $resp = Add-AzureRmSqlDatabaseAgentTarget -ResourceGroupName $a1.ResourceGroupName -AgentServerName $a1.ServerName -AgentName $a1.AgentName -TargetGroupName $tg1.TargetGroupName -ServerName $ept1.ServerName -ElasticPoolName $ept1.ElasticPoolName -RefreshCredentialName $jc1.CredentialName -Exclude
    Assert-Null $resp

    # Include ep1 - no errors and resp
    $resp = Add-AzureRmSqlDatabaseAgentTarget -ResourceGroupName $a1.ResourceGroupName -AgentServerName $a1.ServerName -AgentName $a1.AgentName -TargetGroupName $tg1.TargetGroupName -ServerName $ept1.ServerName -ElasticPoolName $ept1.ElasticPoolName -RefreshCredentialName $jc1.CredentialName

    # Test updating back to include shows membership type as Include again.
    Assert-AreEqual $resp.ServerName $ept1.ServerName
    Assert-AreEqual $resp.ElasticPoolName $ept1.ElasticPoolName
    Assert-AreEqual $resp.RefreshCredential $jc1.ResourceId
    Assert-AreEqual $resp.MembershipType "Include"
    Assert-AreEqual $resp.Type "SqlElasticPool"

    $all = Get-AzureRmSqlDatabaseAgentTargetGroup -InputObject $a1 -Name $tg1.TargetGroupName
    Assert-AreEqual $all.Members.Count 1

    ## Test input object

    # Include ep2
    $resp = Add-AzureRmSqlDatabaseAgentTarget -InputObject $tg1 -ServerName $ept2.ServerName -ElasticPoolName $ept2.ElasticPoolName -RefreshCredentialName $jc1.CredentialName

    Assert-AreEqual $resp.ServerName $ept2.ServerName
    Assert-AreEqual $resp.ElasticPoolName $ept2.ElasticPoolName
    Assert-AreEqual $resp.RefreshCredential $jc1.ResourceId
    Assert-AreEqual $resp.MembershipType "Include"
    Assert-AreEqual $resp.Type "SqlElasticPool"

    # Exclude ep2
    $resp = Add-AzureRmSqlDatabaseAgentTarget -InputObject $tg1 -ServerName $ept2.ServerName -ElasticPoolName $ept2.ElasticPoolName -RefreshCredentialName $jc1.CredentialName -Exclude

    Assert-AreEqual $resp.ServerName $ept2.ServerName
    Assert-AreEqual $resp.ElasticPoolName $ept2.ElasticPoolName
    Assert-AreEqual $resp.RefreshCredential $jc1.ResourceId
    Assert-AreEqual $resp.MembershipType "Exclude"
    Assert-AreEqual $resp.Type "SqlElasticPool"

    # Exclude ep2 again - no errors and no resp
    $resp = Add-AzureRmSqlDatabaseAgentTarget -InputObject $tg1 -ServerName $ept2.ServerName -ElasticPoolName $ept2.ElasticPoolName -RefreshCredentialName $jc1.CredentialName -Exclude
    Assert-Null $resp

    # Include ep2 - no errors and resp
    $resp = Add-AzureRmSqlDatabaseAgentTarget -InputObject $tg1 -ServerName $ept2.ServerName -ElasticPoolName $ept2.ElasticPoolName -RefreshCredentialName $jc1.CredentialName

    # Test updating back to include shows membership type as Include again.
    Assert-AreEqual $resp.ServerName $ept2.ServerName
    Assert-AreEqual $resp.ElasticPoolName $ept2.ElasticPoolName
    Assert-AreEqual $resp.RefreshCredential $jc1.ResourceId
    Assert-AreEqual $resp.MembershipType "Include"
    Assert-AreEqual $resp.Type "SqlElasticPool"

    $all = Get-AzureRmSqlDatabaseAgentTargetGroup -InputObject $a1 -Name $tg1.TargetGroupName
    Assert-AreEqual $all.Members.Count 2

    ## Test resource id

    # Include ep3
    $resp = Add-AzureRmSqlDatabaseAgentTarget -ResourceId $tg1.ResourceId -ServerName $ept3.ServerName -ElasticPoolName $ept3.ElasticPoolName -RefreshCredentialName $jc1.CredentialName

    Assert-AreEqual $resp.ServerName $ept3.ServerName
    Assert-AreEqual $resp.ElasticPoolName $ept3.ElasticPoolName
    Assert-AreEqual $resp.RefreshCredential $jc1.ResourceId
    Assert-AreEqual $resp.MembershipType "Include"
    Assert-AreEqual $resp.Type "SqlElasticPool"

    # Exclude ep3
    $resp = Add-AzureRmSqlDatabaseAgentTarget -ResourceId $tg1.ResourceId -ServerName $ept3.ServerName -ElasticPoolName $ept3.ElasticPoolName -RefreshCredentialName $jc1.CredentialName -Exclude

    Assert-AreEqual $resp.ServerName $ept3.ServerName
    Assert-AreEqual $resp.ElasticPoolName $ept3.ElasticPoolName
    Assert-AreEqual $resp.RefreshCredential $jc1.ResourceId
    Assert-AreEqual $resp.MembershipType "Exclude"
    Assert-AreEqual $resp.Type "SqlElasticPool"

    # Exclude ep3 again - no errors and no resp
    $resp = Add-AzureRmSqlDatabaseAgentTarget -ResourceId $tg1.ResourceId -ServerName $ept3.ServerName -ElasticPoolName $ept3.ElasticPoolName -RefreshCredentialName $jc1.CredentialName -Exclude
    Assert-Null $resp

    $all = Get-AzureRmSqlDatabaseAgentTargetGroup -InputObject $a1 -Name $tg1.TargetGroupName
    Assert-AreEqual $all.Members.Count 3

    ## Test piping

    # Add ep4 to tg1
    $resp = $tg1 | Add-AzureRmSqlDatabaseAgentTarget -ServerName $ept4.ServerName -ElasticPoolName $ept4.ElasticPoolName -RefreshCredentialName $jc1.CredentialName
    Assert-AreEqual $resp.ServerName $ept4.ServerName
    Assert-AreEqual $resp.ElasticPoolName $ept4.ElasticPoolName
    Assert-AreEqual $resp.RefreshCredential $jc1.ResourceId
    Assert-AreEqual $resp.MembershipType "Include"
    Assert-AreEqual $resp.Type "SqlElasticPool"

    $all = Get-AzureRmSqlDatabaseAgentTargetGroup -InputObject $a1 -Name $tg1.TargetGroupName
    Assert-AreEqual $all.Members.Count 4

    # Add all elastic pools from rg1 to tg1
    $added = Get-AzureRmSqlServer -ResourceGroupName $a1.ResourceGroupName | Get-AzureRmSqlElasticPool | Add-AzureRmSqlDatabaseAgentTarget -InputObject $tg1 -RefreshCredentialName $jc1.CredentialName
    Assert-AreEqual 1 $added.Count

    $all = Get-AzureRmSqlDatabaseAgentTargetGroup -InputObject $a1 -Name $tg1.TargetGroupName
    Assert-AreEqual $all.Members.Count 5
}

<#
	.SYNOPSIS
	Tests removing elastic pool targets from target group
    .DESCRIPTION
	SmokeTest
#>
function Test-RemoveElasticPoolTarget($a1, $jc1, $tg1, $ept1, $ept2, $ept3, $ept4)
{
    ## --------- Elastic Pool Target Tests -------------
    ## Test default parameters

    # Remove ep1
    $resp = Remove-AzureRmSqlDatabaseAgentTarget -ResourceGroupName $a1.ResourceGroupName -AgentServerName $a1.ServerName -AgentName $a1.AgentName -TargetGroupName $tg1.TargetGroupName -ServerName $ept1.ServerName -ElasticPoolName $ept1.ElasticPoolName -RefreshCredentialName $jc1.CredentialName

    Assert-AreEqual $resp.ServerName $ept1.ServerName
    Assert-AreEqual $resp.ElasticPoolName $ept1.ElasticPoolName
    Assert-AreEqual $resp.RefreshCredential $jc1.ResourceId
    Assert-AreEqual $resp.MembershipType "Include"
    Assert-AreEqual $resp.Type "SqlElasticPool"

    $resp = Remove-AzureRmSqlDatabaseAgentTarget -ResourceGroupName $a1.ResourceGroupName -AgentServerName $a1.ServerName -AgentName $a1.AgentName -TargetGroupName $tg1.TargetGroupName -ServerName $ept1.ServerName -ElasticPoolName $ept1.ElasticPoolName -RefreshCredentialName $jc1.CredentialName
    Assert-Null $resp

    $all = Get-AzureRmSqlDatabaseAgentTargetGroup -InputObject $a1 -Name $tg1.TargetGroupName
    Assert-AreEqual $all.Members.Count 4

    ## Test input object

    # Remove ep2
    $resp = Remove-AzureRmSqlDatabaseAgentTarget -InputObject $tg1 -ServerName $ept2.ServerName -ElasticPoolName $ept2.ElasticPoolName -RefreshCredentialName $jc1.CredentialName

    Assert-AreEqual $resp.ServerName $ept2.ServerName
    Assert-AreEqual $resp.ElasticPoolName $ept2.ElasticPoolName
    Assert-AreEqual $resp.RefreshCredential $jc1.ResourceId
    Assert-AreEqual $resp.MembershipType "Include"
    Assert-AreEqual $resp.Type "SqlElasticPool"

    $resp = Remove-AzureRmSqlDatabaseAgentTarget -InputObject $tg1 -ServerName $ept2.ServerName -ElasticPoolName $ept2.ElasticPoolName -RefreshCredentialName $jc1.CredentialName
    Assert-Null $resp
    
    $all = Get-AzureRmSqlDatabaseAgentTargetGroup -InputObject $a1 -Name $tg1.TargetGroupName
    Assert-AreEqual $all.Members.Count 3

    ## Test resource id

    # Remove ep3
    $resp = Remove-AzureRmSqlDatabaseAgentTarget -ResourceId $tg1.ResourceId -ServerName $ept3.ServerName -ElasticPoolName $ept3.ElasticPoolName -RefreshCredentialName $jc1.CredentialName

    Assert-AreEqual $resp.ServerName $ept3.ServerName
    Assert-AreEqual $resp.ElasticPoolName $ept3.ElasticPoolName
    Assert-AreEqual $resp.RefreshCredential $jc1.ResourceId
    Assert-AreEqual $resp.MembershipType "Exclude"
    Assert-AreEqual $resp.Type "SqlElasticPool"

    $resp = Remove-AzureRmSqlDatabaseAgentTarget -ResourceId $tg1.ResourceId -ServerName $ept3.ServerName -ElasticPoolName $ept3.ElasticPoolName -RefreshCredentialName $jc1.CredentialName
    Assert-Null $resp

    $all = Get-AzureRmSqlDatabaseAgentTargetGroup -InputObject $a1 -Name $tg1.TargetGroupName
    Assert-AreEqual $all.Members.Count 2

    ## Test piping

    # Remove ep4 to tg1
    $resp = $tg1 | Remove-AzureRmSqlDatabaseAgentTarget -ServerName $ept4.ServerName -ElasticPoolName $ept4.ElasticPoolName -RefreshCredentialName $jc1.CredentialName
    Assert-AreEqual $resp.ServerName $ept4.ServerName
    Assert-AreEqual $resp.ElasticPoolName $ept4.ElasticPoolName
    Assert-AreEqual $resp.RefreshCredential $jc1.ResourceId
    Assert-AreEqual $resp.MembershipType "Include"
    Assert-AreEqual $resp.Type "SqlElasticPool"

    $all = Get-AzureRmSqlDatabaseAgentTargetGroup -InputObject $a1 -Name $tg1.TargetGroupName
    Assert-AreEqual $all.Members.Count 1

    # Remove all elastic pools from rg1 to tg1
    $removed = Get-AzureRmSqlServer -ResourceGroupName $a1.ResourceGroupName | Get-AzureRmSqlElasticPool | Remove-AzureRmSqlDatabaseAgentTarget -InputObject $tg1 -RefreshCredentialName $jc1.CredentialName
    Assert-AreEqual 1 $removed.Count

    $all = Get-AzureRmSqlDatabaseAgentTargetGroup -InputObject $a1 -Name $tg1.TargetGroupName
    Assert-AreEqual $all.Members.Count 0
}

<#
	.SYNOPSIS
	Tests adding and deleting shard map targets
    .DESCRIPTION
	SmokeTest
#>
function Test-ShardMapTarget
{
    # Setup
    $rg1 = Create-ResourceGroupForTest
    $s1 = Create-ServerForTest $rg1 "westus2"
    $db1 = Create-DatabaseForTest $s1
    $a1 = Create-AgentForTest $db1
    $jc1 = Create-JobCredentialForTest $a1
    $tg1 = Create-TargetGroupForTest $a1

    # Target Helper Objects
    $smt1 = @{ ServerName = "s1"; ShardMapName = "sm1"; DatabaseName = "db1"} # Include
    $smt2 = @{ ServerName = "s1"; ShardMapName = "sm2"; DatabaseName = "db2"} # Include
    $smt3 = @{ ServerName = "s1"; ShardMapName = "sm3"; DatabaseName = "db3"} # Exclude
    $smt4 = @{ ServerName = "s1"; ShardMapName = "sm4"; DatabaseName = "db4"} # Include

    try
    {
        Test-AddShardMapTarget $a1 $jc1 $tg1 $smt1 $smt2 $smt3 $smt4
        Test-RemoveShardMapTarget $a1 $jc1 $tg1 $smt1 $smt2 $smt3 $smt4
    }
    finally
    {
        Remove-ResourceGroupForTest $rg1
    }
}

<#
	.SYNOPSIS
	Tests adding shard map targets to target group
    .DESCRIPTION
	SmokeTest
#>
function Test-AddShardMapTarget($a1, $jc1, $tg1, $smt1, $smt2, $smt3, $smt4)
{
    ## --------- Shard Map Target Tests -------------
    ## Test default parameters

    # Include sm1
    $resp = Add-AzureRmSqlDatabaseAgentTarget -ResourceGroupName $a1.ResourceGroupName -AgentServerName $a1.ServerName -AgentName $a1.AgentName -TargetGroupName $tg1.TargetGroupName -ServerName $smt1.ServerName -ShardMapName $smt1.ShardMapName -DatabaseName $smt1.DatabaseName -RefreshCredentialName $jc1.CredentialName

    Assert-AreEqual $resp.ServerName $smt1.ServerName
    Assert-AreEqual $resp.ShardMapName $smt1.ShardMapName
    Assert-AreEqual $resp.DatabaseName $smt1.DatabaseName
    Assert-AreEqual $resp.RefreshCredential $jc1.ResourceId
    Assert-AreEqual $resp.MembershipType "Include"
    Assert-AreEqual $resp.Type "SqlShardMap"

    # Exclude sm1
    $resp = Add-AzureRmSqlDatabaseAgentTarget -ResourceGroupName $a1.ResourceGroupName -AgentServerName $a1.ServerName -AgentName $a1.AgentName -TargetGroupName $tg1.TargetGroupName -ServerName $smt1.ServerName -ShardMapName $smt1.ShardMapName  -DatabaseName $smt1.DatabaseName -RefreshCredentialName $jc1.CredentialName -Exclude

    Assert-AreEqual $resp.ServerName $smt1.ServerName
    Assert-AreEqual $resp.ShardMapName $smt1.ShardMapName
    Assert-AreEqual $resp.DatabaseName $smt1.DatabaseName
    Assert-AreEqual $resp.RefreshCredential $jc1.ResourceId
    Assert-AreEqual $resp.MembershipType "Exclude"
    Assert-AreEqual $resp.Type "SqlShardMap"

    # Exclude sm1 again - no errors and no resp
    $resp = Add-AzureRmSqlDatabaseAgentTarget -ResourceGroupName $a1.ResourceGroupName -AgentServerName $a1.ServerName -AgentName $a1.AgentName -TargetGroupName $tg1.TargetGroupName -ServerName $smt1.ServerName -ShardMapName $smt1.ShardMapName -DatabaseName $smt1.DatabaseName -RefreshCredentialName $jc1.CredentialName -Exclude
    Assert-Null $resp

    # Include sm1 - no errors and resp
    $resp = Add-AzureRmSqlDatabaseAgentTarget -ResourceGroupName $a1.ResourceGroupName -AgentServerName $a1.ServerName -AgentName $a1.AgentName -TargetGroupName $tg1.TargetGroupName -ServerName $smt1.ServerName -ShardMapName $smt1.ShardMapName -DatabaseName $smt1.DatabaseName -RefreshCredentialName $jc1.CredentialName

    # Test updating back to include shows membership type as Include again.
    Assert-AreEqual $resp.ServerName $smt1.ServerName
    Assert-AreEqual $resp.ShardMapName $smt1.ShardMapName
    Assert-AreEqual $resp.DatabaseName $smt1.DatabaseName
    Assert-AreEqual $resp.RefreshCredential $jc1.ResourceId
    Assert-AreEqual $resp.MembershipType "Include"
    Assert-AreEqual $resp.Type "SqlShardMap"

    $all = Get-AzureRmSqlDatabaseAgentTargetGroup -InputObject $a1 -Name $tg1.TargetGroupName
    Assert-AreEqual $all.Members.Count 1

    ## Test input object

    # Include sm2
    $resp = Add-AzureRmSqlDatabaseAgentTarget -InputObject $tg1 -ServerName $smt2.ServerName -ShardMapName $smt2.ShardMapName -DatabaseName $smt2.DatabaseName -RefreshCredentialName $jc1.CredentialName

    Assert-AreEqual $resp.ServerName $smt2.ServerName
    Assert-AreEqual $resp.ShardMapName $smt2.ShardMapName
    Assert-AreEqual $resp.DatabaseName $smt2.DatabaseName
    Assert-AreEqual $resp.RefreshCredential $jc1.ResourceId
    Assert-AreEqual $resp.MembershipType "Include"
    Assert-AreEqual $resp.Type "SqlShardMap"

    # Exclude sm2
    $resp = Add-AzureRmSqlDatabaseAgentTarget -InputObject $tg1 -ServerName $smt2.ServerName -ShardMapName $smt2.ShardMapName  -DatabaseName $smt2.DatabaseName -RefreshCredentialName $jc1.CredentialName -Exclude

    Assert-AreEqual $resp.ServerName $smt2.ServerName
    Assert-AreEqual $resp.ShardMapName $smt2.ShardMapName
    Assert-AreEqual $resp.DatabaseName $smt2.DatabaseName
    Assert-AreEqual $resp.RefreshCredential $jc1.ResourceId
    Assert-AreEqual $resp.MembershipType "Exclude"
    Assert-AreEqual $resp.Type "SqlShardMap"

    # Exclude sm2 again - no errors and no resp
    $resp = Add-AzureRmSqlDatabaseAgentTarget -InputObject $tg1 -ServerName $smt2.ServerName -ShardMapName $smt2.ShardMapName -DatabaseName $smt2.DatabaseName -RefreshCredentialName $jc1.CredentialName -Exclude
    Assert-Null $resp

    # Include sm2 - no errors and resp
    $resp = Add-AzureRmSqlDatabaseAgentTarget -InputObject $tg1 -ServerName $smt2.ServerName -ShardMapName $smt2.ShardMapName -DatabaseName $smt2.DatabaseName -RefreshCredentialName $jc1.CredentialName

    # Test updating back to include shows membership type as Include again.
    Assert-AreEqual $resp.ServerName $smt2.ServerName
    Assert-AreEqual $resp.ShardMapName $smt2.ShardMapName
    Assert-AreEqual $resp.DatabaseName $smt2.DatabaseName
    Assert-AreEqual $resp.RefreshCredential $jc1.ResourceId
    Assert-AreEqual $resp.MembershipType "Include"
    Assert-AreEqual $resp.Type "SqlShardMap"

    $all = Get-AzureRmSqlDatabaseAgentTargetGroup -InputObject $a1 -Name $tg1.TargetGroupName
    Assert-AreEqual $all.Members.Count 2

    ## Test resource id

    # Include sm3
    $resp = Add-AzureRmSqlDatabaseAgentTarget -ResourceId $tg1.ResourceId -ServerName $smt3.ServerName -ShardMapName $smt3.ShardMapName -DatabaseName $smt3.DatabaseName -RefreshCredentialName $jc1.CredentialName

    Assert-AreEqual $resp.ServerName $smt3.ServerName
    Assert-AreEqual $resp.ShardMapName $smt3.ShardMapName
    Assert-AreEqual $resp.DatabaseName $smt3.DatabaseName
    Assert-AreEqual $resp.RefreshCredential $jc1.ResourceId
    Assert-AreEqual $resp.MembershipType "Include"
    Assert-AreEqual $resp.Type "SqlShardMap"

    # Exclude sm3
    $resp = Add-AzureRmSqlDatabaseAgentTarget -ResourceId $tg1.ResourceId -ServerName $smt3.ServerName -ShardMapName $smt3.ShardMapName -DatabaseName $smt3.DatabaseName -RefreshCredentialName $jc1.CredentialName -Exclude

    Assert-AreEqual $resp.ServerName $smt3.ServerName
    Assert-AreEqual $resp.ShardMapName $smt3.ShardMapName
    Assert-AreEqual $resp.DatabaseName $smt3.DatabaseName
    Assert-AreEqual $resp.RefreshCredential $jc1.ResourceId
    Assert-AreEqual $resp.MembershipType "Exclude"
    Assert-AreEqual $resp.Type "SqlShardMap"

    # Exclude sm3 again - no errors and no resp
    $resp = Add-AzureRmSqlDatabaseAgentTarget -ResourceId $tg1.ResourceId -ServerName $smt3.ServerName -ShardMapName $smt3.ShardMapName -DatabaseName $smt3.DatabaseName -RefreshCredentialName $jc1.CredentialName -Exclude
    Assert-Null $resp

    $all = Get-AzureRmSqlDatabaseAgentTargetGroup -InputObject $a1 -Name $tg1.TargetGroupName
    Assert-AreEqual $all.Members.Count 3

    ## Test piping

    # Add sm4 to tg1
    $resp = $tg1 | Add-AzureRmSqlDatabaseAgentTarget -ServerName $smt4.ServerName -ShardMapName $smt4.ShardMapName -DatabaseName $smt4.DatabaseName -RefreshCredentialName $jc1.CredentialName
    Assert-AreEqual $resp.ServerName $smt4.ServerName
    Assert-AreEqual $resp.ShardMapName $smt4.ShardMapName
    Assert-AreEqual $resp.DatabaseName $smt4.DatabaseName
    Assert-AreEqual $resp.RefreshCredential $jc1.ResourceId
    Assert-AreEqual $resp.MembershipType "Include"
    Assert-AreEqual $resp.Type "SqlShardMap"

    $all = Get-AzureRmSqlDatabaseAgentTargetGroup -InputObject $a1 -Name $tg1.TargetGroupName
    Assert-AreEqual $all.Members.Count 4
}

<#
	.SYNOPSIS
	Tests removing shard map targets from target group
    .DESCRIPTION
	SmokeTest
#>
function Test-RemoveShardMapTarget($a1, $jc1, $tg1, $smt1, $smt2, $smt3, $smt4)
{
    ## --------- Shard Map Target Tests -------------
    ## Test default parameters

    # Remove sm1
    $resp = Remove-AzureRmSqlDatabaseAgentTarget -ResourceGroupName $a1.ResourceGroupName -AgentServerName $a1.ServerName -AgentName $a1.AgentName -TargetGroupName $tg1.TargetGroupName -ServerName $smt1.ServerName -ShardMapName $smt1.ShardMapName -DatabaseName $smt1.DatabaseName -RefreshCredentialName $jc1.CredentialName
    Assert-AreEqual $resp.ServerName $smt1.ServerName
    Assert-AreEqual $resp.ShardMapName $smt1.ShardMapName
    Assert-AreEqual $resp.DatabaseName $smt1.DatabaseName
    Assert-AreEqual $resp.RefreshCredential $jc1.ResourceId
    Assert-AreEqual $resp.MembershipType "Include"
    Assert-AreEqual $resp.Type "SqlShardMap"

    $resp = Remove-AzureRmSqlDatabaseAgentTarget -ResourceGroupName $a1.ResourceGroupName -AgentServerName $a1.ServerName -AgentName $a1.AgentName -TargetGroupName $tg1.TargetGroupName -ServerName $smt1.ServerName -ShardMapName $smt1.ShardMapName -DatabaseName $smt1.DatabaseName -RefreshCredentialName $jc1.CredentialName
    Assert-Null $resp

    $all = Get-AzureRmSqlDatabaseAgentTargetGroup -InputObject $a1 -Name $tg1.TargetGroupName
    Assert-AreEqual $all.Members.Count 3
    
    ## Test input object

    # Remove sm2
    $resp = Remove-AzureRmSqlDatabaseAgentTarget -InputObject $tg1 -ServerName $smt2.ServerName -ShardMapName $smt2.ShardMapName -DatabaseName $smt2.DatabaseName -RefreshCredentialName $jc1.CredentialName
    Assert-AreEqual $resp.ServerName $smt2.ServerName
    Assert-AreEqual $resp.ShardMapName $smt2.ShardMapName
    Assert-AreEqual $resp.DatabaseName $smt2.DatabaseName
    Assert-AreEqual $resp.RefreshCredential $jc1.ResourceId
    Assert-AreEqual $resp.MembershipType "Include"
    Assert-AreEqual $resp.Type "SqlShardMap"

    $resp = Remove-AzureRmSqlDatabaseAgentTarget -InputObject $tg1 -ServerName $smt2.ServerName -ShardMapName $smt2.ShardMapName -DatabaseName $smt2.DatabaseName -RefreshCredentialName $jc1.CredentialName
    Assert-Null $resp


    $all = Get-AzureRmSqlDatabaseAgentTargetGroup -InputObject $a1 -Name $tg1.TargetGroupName
    Assert-AreEqual $all.Members.Count 2

    ## Test resource id

    # Remove sm3
    $resp = Remove-AzureRmSqlDatabaseAgentTarget -ResourceId $tg1.ResourceId -ServerName $smt3.ServerName -ShardMapName $smt3.ShardMapName -DatabaseName $smt3.DatabaseName -RefreshCredentialName $jc1.CredentialName
    Assert-AreEqual $resp.ServerName $smt3.ServerName
    Assert-AreEqual $resp.ShardMapName $smt3.ShardMapName
    Assert-AreEqual $resp.DatabaseName $smt3.DatabaseName
    Assert-AreEqual $resp.RefreshCredential $jc1.ResourceId
    Assert-AreEqual $resp.MembershipType "Exclude"
    Assert-AreEqual $resp.Type "SqlShardMap"

    $resp = Remove-AzureRmSqlDatabaseAgentTarget -ResourceId $tg1.ResourceId -ServerName $smt3.ServerName -ShardMapName $smt3.ShardMapName -DatabaseName $smt3.DatabaseName -RefreshCredentialName $jc1.CredentialName
    Assert-Null $resp
    
    $all = Get-AzureRmSqlDatabaseAgentTargetGroup -InputObject $a1 -Name $tg1.TargetGroupName
    Assert-AreEqual $all.Members.Count 1

    ## Test piping

    # Remove sm4
    $resp = $tg1 | Remove-AzureRmSqlDatabaseAgentTarget -ServerName $smt4.ServerName -ShardMapName $smt4.ShardMapName -DatabaseName $smt4.DatabaseName -RefreshCredentialName $jc1.CredentialName
    Assert-AreEqual $resp.ServerName $smt4.ServerName
    Assert-AreEqual $resp.ShardMapName $smt4.ShardMapName
    Assert-AreEqual $resp.DatabaseName $smt4.DatabaseName
    Assert-AreEqual $resp.RefreshCredential $jc1.ResourceId
    Assert-AreEqual $resp.MembershipType "Include"
    Assert-AreEqual $resp.Type "SqlShardMap"

    $all = Get-AzureRmSqlDatabaseAgentTargetGroup -InputObject $a1 -Name $tg1.TargetGroupName
    Assert-AreEqual $all.Members.Count 0
}