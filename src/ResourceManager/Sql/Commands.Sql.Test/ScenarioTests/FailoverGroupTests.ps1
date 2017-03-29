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
#>

function Test-FailoverGroup($serverVersion = "12.0", $location = "North Europe")
{
	$env = Add-AzureRmEnvironment -Name Dogfood -PublishSettingsFileUrl  'https://windows.azure-test.net/publishsettings/index' -ServiceEndpoint  'https://management-preview.core.windows-int.net/' -ManagementPortalUrl  'https://windows.azure-test.net/' -ActiveDirectoryEndpoint  'https://login.windows-ppe.net/' -ActiveDirectoryServiceEndpointResourceId 'https://management.core.windows.net/' -ResourceManagerEndpoint  'https://api-dogfood.resources.windows-int.net/modules/AzureResourceManager/' -GalleryEndpoint  'https://df.gallery.azure-test.net/' -GraphEndpoint  'https://graph.ppe.windows.net/'
	# Setup
	$rg = Create-ResourceGroupForTest
	$server = Create-ServerForTest $rg $serverVersion $location
	$partnerServer = Create-ServerForTest $rg $serverVersion $location
	
	# Create with default values
	$fgName = Get-"TestFailoverGroupCreateUpdate"
	$fg = New-AzureRmSqlDatabaseFailoverGroup -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -PartnerServerName $partnerServer.ServerName -FailoverGroupName $fgName -FailoverPolicy Automatic -GracePeriodWithDataLossHours 1 -AllowReadOnlyFailoverToPrimary Enabled
	Assert-AreEqual $fg.FailoverGroupName $fgName
	Assert-AreEqual $fg.FailoverPolicy Automatic
	Assert-AreEqual $fg.GracePeriodWithDataLossHours 1
	Assert-AreEqual $fg.AllowReadOnlyFailoverToPrimary Enabled

	try
	{
		# Alter all properties
		$fg2 = Set-AzureRmSqlDatabaseFailoverGroup -ResourceGroupName $fg.ResourceGroupName -ServerName $fg.ServerName -FailoverGroupName $fg.FailoverGroupName  -FailoverPolicy Manual -AllowReadOnlyFailoverToPrimary Disabled
		Assert-AreEqual $fg.FailoverGroupName $fgName
		Assert-AreEqual $fg.FailoverPolicy Manual
		Assert-AreEqual $fg.AllowReadOnlyFailoverToPrimary Disabled

		#Alter again but piping in the server object
		$fg3 = $serverObject = Get-AzureRMSqlDatabaseServer -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName
		$serverObject | Set-AzureRMSqlDatabaseFailoverGroup –ResourceGroupName $rg.ResourceGroupName –FailoverGroupName $fg.FailoverGroupName -FailoverPolicy Automatic
		Assert-AreEqual $fg3.FailoverGroupName $fgName
		Assert-AreEqual $fg3.FailoverPolicy Automatic
	    Assert-AreEqual $fg.GracePeriodWithDataLossHours 1


		#Get Failover Group
		$fg4 = $serverObject | Get-AzureRMSqlDatabaseFailoverGroup –ResourceGroupName $rg.ResourceGroupName –FailoverGroupName $fg.FailoverGroupName
		Assert-AreEqual $fg4.FailoverGroupName $fgName
		Assert-AreEqual $fg3.FailoverPolicy Automatic
	    Assert-AreEqual $fg.GracePeriodWithDataLossHours 1

		#Get Failover Group
		$fgs = $serverObject | Get-AzureRMSqlDatabaseFailoverGroup –ResourceGroupName $rg.ResourceGroupName
		Assert-AreEqual $fgs.Count 1

		#Remove Failover Group
		Remove-AzureRmSqlDatabaseFailoverGroup -ServerName $server.ServerName -ResourceGroupName $rg.ResourceGroupName –FailoverGroupName $fg.FailoverGroupName
		$all = $server | Get-AzureRMSqlDatabaseFailoverGroup –ResourceGroupName $rg.ResourceGroupName
		Assert-AreEqual $all.Count 0
	}
	finally
	{
		Remove-ResourceGroupForTest $rg
	}

}