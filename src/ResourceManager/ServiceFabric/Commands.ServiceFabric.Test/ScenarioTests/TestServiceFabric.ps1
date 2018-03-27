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
	$nodeTypeName = Get-NewNodeTypeName
	$clusterName = Get-ClusterName
	$resourceGroupName = Get-ResourceGroupName
	$durabilityLevel = Get-DurabilityLevel
    $newNodeTypeName = Get-NewNodeTypeName

	$cluster = Update-AzureRmServiceFabricDurability -Level $durabilityLevel -NodeType $nodeTypeName -ClusterName $clusterName -ResourceGroupName $resourceGroupName -Verbose
	$clusters = Get-AzureRmServiceFabricCluster -ClusterName $clusterName -ResourceGroupName $resourceGroupName 
	Assert-AreEqual $clusters[0].NodeTypes.Where({$_.Name -eq $newNodeTypeName}).DurabilityLevel $durabilityLevel
}

function Test-UpdateAzureRmServiceFabricReliability
{
	$clusterName = Get-ClusterName
	$resourceGroupName = Get-ResourceGroupName
	$reliabilityLevel = Get-ReliabilityLevel

	$cluster = Update-AzureRmServiceFabricReliability -ReliabilityLevel $reliabilityLevel  -ClusterName $clusterName -ResourceGroupName $resourceGroupName -Verbose
	$clusters = Get-AzureRmServiceFabricCluster -ClusterName $clusterName -ResourceGroupName $resourceGroupName 
	Assert-AreEqual $clusters[0].ReliabilityLevel $reliabilityLevel
}

function Test-AddAzureRmServiceFabricClusterCertificate
{
	$clusterName = Get-ClusterName
	$resourceGroupName = Get-ResourceGroupName
    $keyvaulturi = Get-SecretUrl

    $cluster = 	Add-AzureRmServiceFabricClusterCertificate -ResourceGroupName $resourceGroupName  -ClusterName $clusterName -SecretIdentifier $keyvaulturi -Verbose
	$clusters = Get-AzureRmServiceFabricCluster -ClusterName $clusterName -ResourceGroupName $resourceGroupName 
	Assert-NotNull $clusters[0].Certificate.ThumbprintSecondary 
}

function Test-RemoveAzureRmServiceFabricClusterCertificate
{
	$clusterName = Get-ClusterName
	$resourceGroupName = Get-ResourceGroupName
    $thumbprint  = Get-Thumbprint

	$cluster = Remove-AzureRmServiceFabricClusterCertificate -ClusterName $clusterName -ResourceGroupName $resourceGroupName -Thumbprint $thumbprint -Verbose
	$clusters = Get-AzureRmServiceFabricCluster -ClusterName $clusterName -ResourceGroupName $resourceGroupName 
	Assert-Null $clusters[0].Certificate.ThumbprintSecondary 
}


function Test-AddAzureRmServiceFabricClientCertificate
{
	$clusterName = Get-ClusterName
	$resourceGroupName = Get-ResourceGroupName
    $certName  = Get-NewCertName
    $commonName = "cn=$certName"
    $thumbprint  = Get-Thumbprint

	$cluster = Add-AzureRmServiceFabricClientCertificate -ClusterName $clusterName -ResourceGroupName $resourceGroupName -CommonName $commonName -IssuerThumbprint $thumbprint -Verbose
	$clusters = Get-AzureRmServiceFabricCluster -ClusterName $clusterName -ResourceGroupName $resourceGroupName 
    Assert-AreEqual $clusters[0].ClientCertificateCommonNames[0].CertificateCommonName $commonName
}

function Test-RemoveAzureRmServiceFabricClientCertificate
{
	$clusterName = Get-ClusterName
	$resourceGroupName = Get-ResourceGroupName
    $certName  = Get-NewCertName
    $commonName = "cn=$certName"
    $thumbprint  = Get-Thumbprint

	$cluster = Remove-AzureRmServiceFabricClientCertificate -ClusterName $clusterName -ResourceGroupName $resourceGroupName -CommonName $commonName -IssuerThumbprint $thumbprint -Verbose
	$clusters = Get-AzureRmServiceFabricCluster -ClusterName $clusterName -ResourceGroupName $resourceGroupName
	Assert-Null $clusters[0].ClientCertificateThumbprints[0]
}

function Test-NewAzureRmServiceFabricCluster
{
    $clusterName = "azurermsfcluster2"
    $resourceGroupName = "azurermsfrg2"
    $keyvaulturi = Get-SecretUrl
    $vmPassword = Get-VmPwd | ConvertTo-SecureString -Force -AsPlainText

    $cluster = New-AzureRmServiceFabricCluster -ResourceGroupName $resourceGroupName -VmPassword $vmPassword `
        -TemplateFile $pwd\resources\template.json -ParameterFile $pwd\resources\parameters.json -SecretIdentifier $keyvaulturi -Verbose
    $clusters = Get-AzureRmServiceFabricCluster -ClusterName $clusterName -ResourceGroupName $resourceGroupName
    Assert-NotNull $clusters.Where({$_.Name -eq $clusterName})
}

function Test-AddAzureRmServiceFabricNodeType
{
	$clusterName = Get-ClusterName
	$resourceGroupName = Get-ResourceGroupName	
	$newNodeTypeName = Get-NewNodeTypeName

	$clusters = Get-AzureRmServiceFabricCluster -ClusterName $clusterName -ResourceGroupName $resourceGroupName
    $vmPassword = Get-VmPwd | ConvertTo-SecureString -Force -AsPlainText
	$cluster = Add-AzureRmServiceFabricNodeType -Capacity 1 -VmUserName username -VmPassword $vmPassword -NodeType $newNodeTypeName -ClusterName $clusterName -ResourceGroupName $resourceGroupName -Verbose
	$clusters = Get-AzureRmServiceFabricCluster -ClusterName $clusterName -ResourceGroupName $resourceGroupName 
	Assert-NotNull $clusters[0].NodeTypes.Where({$_.Name -eq $newNodeTypeName})
}

function Test-RemoveAzureRmServiceFabricNodeType
{
	$clusterName = Get-ClusterName
	$resourceGroupName = Get-ResourceGroupName	
	$newNodeTypeName = Get-NewNodeTypeName

	$clusters = Get-AzureRmServiceFabricCluster -ClusterName $clusterName -ResourceGroupName $resourceGroupName
	$cluster = Remove-AzureRmServiceFabricNodeType -ResourceGroupName $resourceGroupName -ClusterName $clusterName -NodeType $newNodeTypeName -Verbose
	$clusters = Get-AzureRmServiceFabricCluster -ClusterName $clusterName -ResourceGroupName $resourceGroupName 
	Assert-Null $clusters[0].NodeTypes.Where({$_.Name -eq $newNodeTypeName})
}

function Test-AddAzureRmServiceFabricNode
{
    $clusterName = Get-ClusterName
    $resourceGroupName = Get-ResourceGroupName	
    $newNodeTypeName = Get-NewNodeTypeName
    $nodes = 5

    $clusters = Get-AzureRmServiceFabricCluster -ClusterName $clusterName -ResourceGroupName $resourceGroupName
    $count = $clusters[0].NodeTypes.Where({$_.Name -eq $newNodeTypeName}).VmInstanceCount
    $cluster = Add-AzureRmServiceFabricNode -NodeType $newNodeTypeName -NumberOfNodesToAdd $nodes -ClusterName $clusterName -ResourceGroupName $resourceGroupName -Verbose
    $clusters = Get-AzureRmServiceFabricCluster -ClusterName $clusterName -ResourceGroupName $resourceGroupName 
    Assert-AreEqual ($count + $nodes)  $clusters[0].NodeTypes.Where({$_.Name -eq $newNodeTypeName}).VmInstanceCount
}

function Test-RemoveAzureRmServiceFabricNode
{
    $clusterName = Get-ClusterName
    $resourceGroupName = Get-ResourceGroupName	
    $newNodeTypeName = Get-NewNodeTypeName
    $nodes = 1

    $clusters = Get-AzureRmServiceFabricCluster -ClusterName $clusterName -ResourceGroupName $resourceGroupName
    $count = $clusters[0].NodeTypes.Where({$_.Name -eq $newNodeTypeName}).VmInstanceCount
    $cluster = Remove-AzureRmServiceFabricNode -NodeType $newNodeTypeName -NumberOfNodesToRemove $nodes -ClusterName $clusterName -ResourceGroupName $resourceGroupName -Verbose
    $clusters = Get-AzureRmServiceFabricCluster -ClusterName $clusterName -ResourceGroupName $resourceGroupName 
    Assert-AreEqual ($count - $nodes)  $clusters[0].NodeTypes.Where({$_.Name -eq $newNodeTypeName}).VmInstanceCount
}

function Test-SetAzureRmServiceFabricSettings
{
	$clusterName = Get-ClusterName
	$resourceGroupName = Get-ResourceGroupName	
	$sectionName =  Get-SectionName
	$parameterName = Get-ParameterName
	$valueName = Get-ValueName

	$clusters = Get-AzureRmServiceFabricCluster -ClusterName $clusterName -ResourceGroupName $resourceGroupName
	$count = $clusters[0].FabricSettings.Count
	$cluster = Set-AzureRmServiceFabricSetting -ResourceGroupName $resourceGroupName -ClusterName $clusterName -Section $sectionName -Parameter $parameterName -Value $valueName -Verbose
	$clusters = Get-AzureRmServiceFabricCluster -ClusterName $clusterName -ResourceGroupName $resourceGroupName 
	Assert-Null  ($clusters[0].FabricSettings[$sectionName])  
}

function Test-RemoveAzureRmServiceFabricSettings
{
	$clusterName = Get-ClusterName
	$resourceGroupName = Get-ResourceGroupName	
	$sectionName =  Get-SectionName
	$parameterName = Get-ParameterName

	$clusters = Get-AzureRmServiceFabricCluster -ClusterName $clusterName -ResourceGroupName $resourceGroupName
	$preSettings = $clusters[0].FabricSettings
	$cluster = Remove-AzureRmServiceFabricSetting -ResourceGroupName $resourceGroupName -ClusterName $clusterName -Section $sectionName -Parameter $parameterName -Verbose
	$clusters = Get-AzureRmServiceFabricCluster -ClusterName $clusterName -ResourceGroupName $resourceGroupName 
	Assert-AreNotEqual $preSettings  $clusters[0].FabricSettings
}

function Test-SetAzureRmServiceFabricUpgradeType
{
	$clusterName = Get-ClusterName
	$resourceGroupName = Get-ResourceGroupName	
	
	$cluster = Set-AzureRmServiceFabricUpgradeType -ResourceGroupName $resourceGroupName -ClusterName $clusterName -UpgradeMode Manual -Verbose
	$clusters = Get-AzureRmServiceFabricCluster -ClusterName $clusterName -ResourceGroupName $resourceGroupName 
	Assert-AreEqual $clusters[0].UpgradeMode 'Manual'
}