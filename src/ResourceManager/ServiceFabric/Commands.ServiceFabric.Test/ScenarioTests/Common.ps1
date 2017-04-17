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

$global:time = Get-Date
$global:suffix = $time.ToString("yyyyMMdd")
$global:prefix = 'ps'

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

function Get-ResourceGroupLocation
{
    return "South Central US";
}

function Get-ClusterName
{
    return $global:prefix + $global:suffix;
}

function Get-NewClusterName
{
	return 'new' + $global:prefix + $global:suffix;
}

function Get-NewResourceGroupName
{
    return 'new' + $global:prefix + $global:suffix
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
    return "User@123";
}

function Get-KeyVaultName
{
    return "kvps";
}

function Get-KeyVaultResourceGroup
{
    return "kvps";
}

function Get-KeyVaultResourceGroupLocation
{
    return "South Central US";
}

function Get-SecretUrl
{
	return 'https://kvps.vault.azure.net:443/secrets/kvpsrg/6202d05ec08c4767911ddf0613c2b1e8'
}

function Get-ThumbprintByFile
{
    $CertPath = Get-Cert
    $CertPass = Get-Pwd
    $Cert = New-Object System.Security.Cryptography.X509Certificates.X509Certificate2($CertPath, $CertPass)
	return $Cert.Thumbprint
}

function Get-DurabilityLevel
{
	return "silver"
}

function Get-ReliabilityLevel
{
	return "silver"
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