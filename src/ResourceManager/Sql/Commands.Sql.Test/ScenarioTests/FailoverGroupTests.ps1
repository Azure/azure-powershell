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
	Tests create and update a failover group
function Test-CRUDFailoverGroup($serverVersion = "12.0", $location = "Southeast Asia")
{
	# Setup
	$rg = Create-ResourceGroupForTest
	$server = Create-ServerForTest $rg $serverVersion $location
	
	# Create with default values
	$fgName = Get-"TestFailoverGroupCreateUpdate"
	$fg = New-AzureRmSqlDatabaseFailoverGroup -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -FailoverGroupName $fgName -FailoverPolicy Automatic -GracePeriodWithoutDatalossMinutes 15 -GracePeriodWithDataLossMinutes 120 -AllowReadOnlyFailoverToPrimary Enabled
	Assert-AreEqual $fg.FailoverGroupName $fgName
	Assert-AreEqual $fg.FailoverPolicy Automatic
	Assert-AreEqual $fg.GracePeriodWithoutDatalossMinutes 15
	Assert-AreEqual $fg.GracePeriodWithDataLossMinutes 120
	Assert-AreEqual $fg.AllowReadOnlyFailoverToPrimary Enabled

	try
	{
		# Alter all properties
		$fg2 = Set-AzureRmSqlDatabaseFailoverGroup -ResourceGroupName $fg.ResourceGroupName -ServerName $fg.ServerName -FailoverGroupName $fg.FailoverGroupName  -FailoverPolicy Manual -GracePeriodWithoutDatalossMinutes 5 -GracePeriodWithDataLossMinutes 60 -AllowReadOnlyFailoverToPrimary Disabled
		Assert-AreEqual $fg.FailoverGroupName $fgName
		Assert-AreEqual $fg.FailoverPolicy Manual
		Assert-AreEqual $fg.GracePeriodWithoutDatalossMinutes 5
		Assert-AreEqual $fg.GracePeriodWithDataLossMinutes 60
		Assert-AreEqual $fg.AllowReadOnlyFailoverToPrimary Disabled

		#Alter again but piping in the server object
		$fg3 = $serverObject = Get-AzureRMSqlDatabaseServer -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName
		$serverObject | Set-AzureRMSqlDatabaseFailoverGroup –ResourceGroupName $rg.ResourceGroupName –FailoverGroupName $fg.FailoverGroupName -FailoverPolicy Automatic-GracePeriodWithoutDatalossMinutes 15 -GracePeriodWithDataLossMinutes 120 -AllowReadOnlyFailoverToPrimary Enabled 
		Assert-AreEqual $fg3.FailoverGroupName $fgName
		Assert-AreEqual $fg3.FailoverPolicy Automatic
		Assert-AreEqual $fg3.GracePeriodWithoutDatalossMinutes 15
		Assert-AreEqual $fg3.GracePeriodWithDataLossMinutes 120
		Assert-AreEqual $fg3.AllowReadOnlyFailoverToPrimary Enabled

		#Get Failover Group
		$fg4 = $serverObject | Get-AzureRMSqlDatabaseFailoverGroup –ResourceGroupName $rg.ResourceGroupName –FailoverGroupName $fg.FailoverGroupName
		Assert-AreEqual $fg4.FailoverGroupName $fgName
		Assert-AreEqual $fg4.FailoverPolicy Automatic
		Assert-AreEqual $fg4.GracePeriodWithoutDatalossMinutes 15
		Assert-AreEqual $fg4.GracePeriodWithDataLossMinutes 120
		Assert-AreEqual $fg4.AllowReadOnlyFailoverToPrimary Enabled

		#Get Failover Group
		$fgs = $serverObject | Get-AzureRMSqlDatabaseFailoverGroup –ResourceGroupName $rg.ResourceGroupName
		Assert-AreEqual $fgs.Count 0

		#Remove Failover Group
		Remove-AzureRmSqlDatabaseFailoverGroup -ServerName $server.ServerName -ResourceGroupName $rg.ResourceGroupName –FailoverGroupName $fg.FailoverGroupName
		$all = $server | Get-AzureRmSqlElasticPool
		Assert-AreEqual $all.Count 0
	}
	finally
	{
		Remove-ResourceGroupForTest $rg
	}
}


<#
	.SYNOPSIS
	Tests Getting a 
#>
function Test-GetDatabaseReadScale ($serverVersion = "12.0", $location = "Southeast Asia")
{
	# Setup
	$rg = Create-ResourceGroupForTest
	$server = Create-ServerForTest $rg $serverVersion $location
	
	# Create with default values
	$databaseName = Get-DatabaseName
	$db = New-AzureRmSqlDatabase -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -DatabaseName $databaseName -Edition Premium
	Assert-AreEqual $db.DatabaseName $databaseName

	try
	{
		$db1 = Get-AzureRmSqlDatabase -ResourceGroupName $server.ResourceGroupname -ServerName $server.ServerName -DatabaseName $db.DatabaseName

		Assert-AreEqual $fg.Databases.count 0
		$serverObject = Get-AzureRMSqlDatabaseServer -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName
		$fg = $server | Add-AzureRMSqlDatabaseToFailoverGroup –FailoverGroupName “myFG” –ResourceGroupName $rg.ResourceGroupName -Databases $db1
		Assert-AreEqual $fg.Databases.count 1

		$fg2 = $server | Remove-AzureRMSqlDatabaseFromFailoverGroup –FailoverGroupName “myFG” –ResourceGroupName $rg.ResourceGroupName -Databases $db1
		Assert-AreEqual $fg.Databases.count 0
	}
	finally
	{
		Remove-ResourceGroupForTest $rg
	}
}