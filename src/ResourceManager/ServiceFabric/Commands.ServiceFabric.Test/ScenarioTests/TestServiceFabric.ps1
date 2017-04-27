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

function Test-UpdateAzureRmServiceFabricDurability
{
	$nodeTypeName = Get-NodeTypeName
	$clusterName = Get-ClusterName
	$resourceGroupName = Get-ResourceGroupName
	$durabilityLevel = Get-DurabilityLevel

	$cluster = Update-AzureRmServiceFabricDurability -Level $durabilityLevel -NodeType $nodeTypeName -ClusterName $clusterName -ResourceGroupName $resourceGroupName
	$clusters = Get-AzureRmServiceFabricCluster -ClusterName $clusterName -ResourceGroupName $resourceGroupName 
	Assert-AreEqual $clusters[0].NodeTypes[0].DurabilityLevel $durabilityLevel
}

function Test-UpdateAzureRmServiceFabricReliability
{
	$clusterName = Get-ClusterName
	$resourceGroupName = Get-ResourceGroupName
	$reliabilityLevel = Get-ReliabilityLevel

	$cluster = Update-AzureRmServiceFabricReliability -ReliabilityLevel $reliabilityLevel  -ClusterName $clusterName -ResourceGroupName $resourceGroupName
	$clusters = Get-AzureRmServiceFabricCluster -ClusterName $clusterName -ResourceGroupName $resourceGroupName 
	Assert-AreEqual $clusters[0].ReliabilityLevel $reliabilityLevel
}

function Test-AddAzureRmServiceFabricClusterCertificate
{
	$clusterName = Get-ClusterName
	$resourceGroupName = Get-ResourceGroupName
	$keyvaultName = Get-KeyVaultName
	$keyVaultResouceGroupName = Get-KeyVaultResourceGroupLocation
	$thumbprint = Get-ThumbprintByFile
	$keyvaulturi = Get-SecretUrl

	$cluster = 	Add-AzureRmServiceFabricClusterCertificate -ResourceGroupName $resourceGroupName  -ClusterName $clusterName `
	-SecretIdentifier $keyvaulturi -CertificateThumprint $thumbprint 
	$clusters = Get-AzureRmServiceFabricCluster -ClusterName $clusterName -ResourceGroupName $resourceGroupName 
	Assert-NotNull $clusters[0].Certificate.ThumbprintSecondary 
}

function Test-RemoveAzureRmServiceFabricClusterCertificate
{
	$clusterName = Get-ClusterName
	$resourceGroupName = Get-ResourceGroupName
	$thumbprint  = Get-ThumbprintByFile

	$cluster = Remove-AzureRmServiceFabricClusterCertificate -ClusterName $clusterName -ResourceGroupName $resourceGroupName -Thumbprint $thumbprint
	$clusters = Get-AzureRmServiceFabricCluster -ClusterName $clusterName -ResourceGroupName $resourceGroupName 
	Assert-Null $clusters[0].Certificate.ThumbprintSecondary 
}


function Test-AddAzureRmServiceFabricClientCertificate
{
	$clusterName = Get-ClusterName
	$resourceGroupName = Get-ResourceGroupName
	$thumbprint  = Get-ThumbprintByFile

	$cluster = Add-AzureRmServiceFabricClientCertificate -ClusterName $clusterName -ResourceGroupName $resourceGroupName -Thumbprint $thumbprint 
	$clusters = Get-AzureRmServiceFabricCluster -ClusterName $clusterName -ResourceGroupName $resourceGroupName 
	Assert-AreEqual $clusters[0].ClientCertificateThumbprints[0].CertificateThumbprint $thumbprint
}

function Test-RemoveAzureRmServiceFabricClientCertificate
{
	$clusterName = Get-ClusterName
	$resourceGroupName = Get-ResourceGroupName
	$thumbprint  = Get-ThumbprintByFile

	$cluster = Remove-AzureRmServiceFabricClientCertificate -ClusterName $clusterName -ResourceGroupName $resourceGroupName -Thumbprint $thumbprint 
	$clusters = Get-AzureRmServiceFabricCluster -ClusterName $clusterName -ResourceGroupName $resourceGroupName 
	Assert-AreEqual $clusters[0].ClientCertificateThumbprints.Count 0
}

function Test-NewAzureRmServiceFabricCluster
{
	$clusterName = Get-NewClusterName
	$thumbprint  = Get-ThumbprintByFile
	$resourceGroupName = Get-NewResourceGroupName
	$vaultName = Get-KeyVaultName
	$keyvaulturi = Get-SecretUrl
	$keyvaultRg = Get-KeyVaultResourceGroup

	$cluster = New-AzureRmServiceFabricCluster -ResourceGroupName $resourceGroupName -TemplateFile .\Resources\template.json `
	          -ParameterFile .\Resources\parameters.json  -SecretIdentifier $keyvaulturi -CertificateThumprint $thumbprint
	$clusters = Get-AzureRmServiceFabricCluster -ClusterName $clusterName -ResourceGroupName $resourceGroupName 
	Assert-NotNull $clusters[0]
}

function Test-AddAzureRmServiceFabricNodeType
{
	$clusterName = Get-ClusterName
	$resourceGroupName = Get-ResourceGroupName	
	$newNodeTypeName = Get-NewNodeTypeName

	$clusters = Get-AzureRmServiceFabricCluster -ClusterName $clusterName -ResourceGroupName $resourceGroupName
	$count = $clusters[0].NodeTypes.Count
    $vmPassword = ConvertTo-SecureString -Force -AsPlainText -String Get-VmPassword
	$cluster = Add-AzureRmServiceFabricNodeType -Capacity 1 -VmUserName username -VmPassword $vmPassword -NodeType $newNodeTypeName `
	           -ClusterName $clusterName -ResourceGroupName $resourceGroupName
	$clusters = Get-AzureRmServiceFabricCluster -ClusterName $clusterName -ResourceGroupName $resourceGroupName 
	Assert-AreEqual ($clusters[0].NodeTypes.Count - $count)  1
}

function Test-RemoveAzureRmServiceFabricNodeType
{
	$clusterName = Get-ClusterName
	$resourceGroupName = Get-ResourceGroupName	
	$newNodeTypeName = Get-NewNodeTypeName

	$clusters = Get-AzureRmServiceFabricCluster -ClusterName $clusterName -ResourceGroupName $resourceGroupName
	$count = $clusters[0].NodeTypes.Count
	$cluster = Remove-AzureRmServiceFabricNodeType -ResourceGroupName $resourceGroupName -ClusterName $clusterName -NodeType $newNodeTypeName
	$clusters = Get-AzureRmServiceFabricCluster -ClusterName $clusterName -ResourceGroupName $resourceGroupName 
	Assert-AreEqual ($count - $clusters[0].NodeTypes.Count)  1
}

function Test-SetAzureRmServiceFabricSettings
{
	$clusterName = Get-ClusterName
	$resourceGroupName = Get-ResourceGroupName	
	$newNodeTypeName = Get-NewNodeTypeName
	$sectionName =  Get-SectionName
	$parameterName = Get-ParameterName
	$valueName = Get-ValueName

	$clusters = Get-AzureRmServiceFabricCluster -ClusterName $clusterName -ResourceGroupName $resourceGroupName
	$count = $clusters[0].FabricSettings.Count
	$cluster = Set-AzureRmServiceFabricSettings -ResourceGroupName $resourceGroupName -ClusterName $clusterName -Section $sectionName `
	-Parameter $parameterName -Value $valueName
	$clusters = Get-AzureRmServiceFabricCluster -ClusterName $clusterName -ResourceGroupName $resourceGroupName 
	Assert-Null  ($clusters[0].FabricSettings[$sectionName])  
}

function Test-RemoveAzureRmServiceFabricSettings
{
	$clusterName = Get-ClusterName
	$resourceGroupName = Get-ResourceGroupName	
	$newNodeTypeName = Get-NewNodeTypeName
	$sectionName =  Get-SectionName
	$parameterName = Get-ParameterName
	$valueName = Get-ValueName

	$clusters = Get-AzureRmServiceFabricCluster -ClusterName $clusterName -ResourceGroupName $resourceGroupName
	$preSettings = $clusters[0].FabricSettings
	$cluster = Remove-AzureRmServiceFabricSettings -ResourceGroupName $resourceGroupName -ClusterName $clusterName -Section $sectionName `
	-Parameter $parameterName
	$clusters = Get-AzureRmServiceFabricCluster -ClusterName $clusterName -ResourceGroupName $resourceGroupName 
	
	Assert-AreNotEqual $preSettings  $clusters[0].FabricSettings
}

function Test-SetAzureRmServiceFabricUpgradeType
{
	$clusterName = Get-ClusterName
	$resourceGroupName = Get-ResourceGroupName	
	
	$cluster =Set-AzureRmServiceFabricUpgradeType -ResourceGroupName $resourceGroupName -ClusterName $clusterName -UpgradeMode Automatic
	$clusters = Get-AzureRmServiceFabricCluster -ClusterName $clusterName -ResourceGroupName $resourceGroupName 
	Assert-AreEqual $clusters[0].UpgradeMode 'Automatic'
}