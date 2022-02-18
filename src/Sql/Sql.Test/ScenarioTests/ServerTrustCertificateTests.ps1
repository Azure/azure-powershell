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

# Location to use for provisioning test managed instances
$instanceLocation = "westcentralus"
$certName1 = "test_cert1"
$certVal1 = "0x3082031E30820206A00302010202107339C358890D88B04D584E95AD40EFA0300D06092A864886F70D01010B0500304B3149304706035504031E40004D0053005F0053006D006F0045007800740065006E006400650064005300690067006E0069006E006700430065007200740069006600690063006100740065301E170D3231303332333031343733385A170D3232303332333031343733385A304B3149304706035504031E40004D0053005F0053006D006F0045007800740065006E006400650064005300690067006E0069006E00670043006500720074006900660069006300610074006530820122300D06092A864886F70D01010105000382010F003082010A0282010100B796616200301A3E8E06A594CD45EB665676E23368222D7F7F70E6474B602978A7A3D45381B293D6FE5C4EB47298496CDA2599DBC2645B2A1CEB311FC4D5AD5AE162E337776D90B8D1E30BF2BB1D19783B22AA261EBA70FBF6896FFE356ED7A7E09EA71F67B6E2213ACE95E8DA12038B6D2D2C986D56CA0859D6A1BDA7DA08DCFFE11FF1E59EDA4225BC0A252405025E49F5C34B65E9614DF8BBD78AFE33CD14E32F2043D833EE7EF6CE3E663BF437A72DE2933D6FC62FB5E87F6B443A0257135C09B8308B231358594EE2FD3A384B3AD5B7D22B1B35E1682F28CC5F7F27A233D704E7DE46126B811E5CF4D2835C316DBD9A4288DA02B2481FF8FCEF754F957D0203010001300D06092A864886F70D01010B0500038201010029577117B09612B085B6AE47417C556013DEF38F61E726E1DEE908332BDD50F830CE43B7D61F20E300E50E23305C94D19DB5FF0F66D0E7B6DAB6510680A10B346653359C1B20F219BF1EB4217B6AEC4CD01BB96F0E84CC9C5DC6DA325EB8979DCA9E9F61AF1C2BB3E3DAB4DE7D118588184FF98FE8E803F3374392464A64563D097AB878DB01115CD443EAF58B0705E13A1E27021F6C0E0104CF5307DCCA79D4CA70F26A3FD2CE89AAE0AD1C08E884AB1BD8FAF3983A0667820BB122688E30C873932FB25BF85EA0B23E651D4DBA5436EC6F17D770832E7041ED44952883470E1B599FDB0E518E663CBD6FED7983849101A89497CF4D0C9FE2DF7F9C2BE3C21A"
$thumbprint1 = "0x5E1C40529126487B5B20C0E7E299FFF7190E94D7"
$certType = "Microsoft.Sql/managedInstances/serverTrustCertificates"

<#
	.SYNOPSIS
	Tests creating a server trust certificate
#>
function Test-NewServerTrustCertificate
{
	# Setup
	#$rg = Create-ResourceGroupForTest $instanceLocation
	#$mi = Create-ManagedInstanceForTest $rg

	try
	{
		$cert = New-AzSqlInstanceServerTrustCertificate -ResourceGroupName CustomerExperienceTeam_RG -ManagedInstanceName chimera-ps-cli-v2 -CertificateName $certName1 -PublicKey $certVal1
		## Create Dtu based pool with DtuPoolParameterSet
		# Create a pool with all values
		#$poolName = Get-ElasticPoolName
		#$job = 
		#-ServerName $server.ServerName -ResourceGroupName $rg.ResourceGroupName `
		#	-ElasticPoolName $poolName -Edition Standard -Dtu 200 -DatabaseDtuMin 10 -DatabaseDtuMax 100 -StorageMB 204800 -AsJob
		#$job | Wait-Job
		#$ep1 = $job.Output
		#
		#Assert-NotNull $ep1
		#Assert-AreEqual	Standard $ep1.Edition
		#Assert-AreEqual StandardPool $ep1.SkuName
		#Assert-AreEqual 200 $ep1.Capacity
		#Assert-AreEqual 10 $ep1.DatabaseCapacityMin
		#Assert-AreEqual 100 $ep1.DatabaseCapacityMax
		#
		## Create a pool using piping and default values
		#$poolName = Get-ElasticPoolName
		#$ep2 = $server | New-AzSqlElasticPool -ElasticPoolName $poolName
		#Assert-NotNull $ep2
		Assert-NotNull $cert
		Assert-AreEqual	$cert.CertificateName $certName1
		Assert-AreEqual	$cert.Name $certName1
		Assert-AreEqual	$cert.Thumbprint $thumbprint1
		Assert-AreEqual "0x" + $cert.PublicBlob $certVal1
		Assert-AreEqual	$cert.Type $certType
	}
	finally
	{
		Remove-ResourceGroupForTest $rg
	}
}

#<#
#.SYNOPSIS
#Tests Managed Instance failover.
##>
#function Test-FailoverManagedInstance
#{
#	try
#	{
#		# Setup
#		$rg = Create-ResourceGroupForTest
#
#		# Initiate sync create of managed instance.
#		$managedInstance1Job = Create-ManagedInstanceForTestAsJob $rg
#		$managedInstance2Job = Create-ManagedInstanceForTestAsJob $rg
#
#		$managedInstance = Create-ManagedInstanceForTest $rg
#		
#		# Wait for first full backup
#		Wait-Seconds 300
#		$job = Invoke-AzSqlInstanceFailover -ResourceGroupName $rg.ResourceGroupName -Name $managedInstance.ManagedInstanceName -AsJob
#		$job | Wait-Job
#
#		try
#		{
#			Invoke-AzSqlInstanceFailover -ResourceGroupName $rg.ResourceGroupName -Name $managedInstance.ManagedInstanceName -AsJob
#		}
#		catch
#		{
#			$ErrorMessage = $_.Exception.Message
#			Assert-AreEqual True $ErrorMessage.Contains("There was a recent failover on the managed instance")
#		}
#
#		$managedInstance1Job | Wait-Job
#		$managedInstance1 = $managedInstance1Job.Output
#
#		# PassThru #
#		############
#
#		# Wait for first full backup
#		Wait-Seconds 120
#		$output = Invoke-AzSqlInstanceFailover -ResourceGroupName $rg.ResourceGroupName -Name $managedInstance1.ManagedInstanceName -PassThru
#		Assert-True { $output }
#
#		$managedInstance2Job | Wait-Job
#		$managedInstance2 = $managedInstance2Job.Output
#
#		# Piping #
#		##########
#
#		# Wait for first full backup
#		Wait-Seconds 60
#		Get-AzSqlInstance -ResourceGroupName $rg.ResourceGroupName -Name $managedInstance2.ManagedInstanceName | Invoke-AzSqlInstanceFailover
#	}
#	finally
#	{
#		Remove-ResourceGroupForTest $rg
#	}
#}
