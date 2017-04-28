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

#####
# For some reason we can use this command create a cluster first before we can run it on cloud
# New-AzureRmServiceFabricCluster -ResourceGroupName ps1cluster -Location "South Central US" `
#  -VmPassword $certPwd -Verbose -OS WindowsServer2012R2Datacenter -PfxOutputFolder c:\test `
#  -CertificatePassword $certPwd
# It will print key vault , thumbprint for the test
#####

$global:time = Get-Date
$global:suffix = 'cluster'
$global:prefix = 'ps1'

function WaitClusterReady
{
	$clusterName = Get-ClusterName
	$resourceGroupName = Get-ResourceGroupName
	$pwd = Get-Pwd | ConvertTo-SecureString -AsPlainText -Force
	Try  
    {  
        $clusters = Get-AzureRmServiceFabricCluster -ClusterName $clusterName -ResourceGroupName $resourceGroupName
    }   
    Catch
    {  
		ReplaceParameterFile
		$keyvaulturi = Get-SecretUrl
		$resourceGroupName = Get-ResourceGroupName
		New-AzureRmServiceFabricCluster -ResourceGroupName $resourceGroupName -TemplateFile .\Resources\template.json `
	          -ParameterFile .\Resources\parameters.json  -SecretIdentifier $keyvaulturi -Thumbprint Get-ThumbprintByFile
    } 	 
	
	$clusters = Get-AzureRmServiceFabricCluster -ClusterName $clusterName -ResourceGroupName $resourceGroupName
	while($clusters[0].ClusterState -ne 'Ready' -and $clusters[0].ClusterState -ne 'Failed')
	{
		Start-Sleep -s 60
	}
}

function ReplaceParameterFile
{
	$cluster = Get-ClusterName
	(Get-Content .\Resources\parameters.json).replace('[replaceclusterName]', $cluster) | Set-Content .\Resources\parameters.json
}

function Get-ResourceGroupName
{
    return $global:prefix + $global:suffix;
}

function Get-ClusterName
{
    return $global:prefix + $global:suffix;
}

function Get-NewClusterName
{
	return 'newcreated' + $global:prefix + $global:suffix;
}

function Get-NewResourceGroupName
{
    return 'newcreated' + $global:prefix + $global:suffix
}

function Get-NodeTypeName
{
    return "nt1vm";
}

function Get-Cert
{
    return ".\Resources\test.pfx";
}

function Get-Pwd
{
    return "123";
}

function Get-KeyVaultName
{
    return "kvps";
}

function Get-SecretUrl
{
	return 'https://kvps.vault.azure.net:443/secrets/kvpsrg/6202d05ec08c4767911ddf0613c2b1e8'
}

function Get-ThumbprintByFile
{
    return "2394f562bf05258059fe32c0d7c63024ead13096"
}

function Get-DurabilityLevel
{
	return "Bronze"
}

function Get-ReliabilityLevel
{
	return "None"
}

function Get-NewNodeTypeName
{
	return 'nnt1'
}

function Get-SectionName
{
	return 'NamingService'
}

function Get-ParameterName
{
	return 'MaxFileOperationTimeout'
}

function Get-ValueName
{
	return '5000'
}

function Get-VmPassword
{
    return  "User@12345123"
}