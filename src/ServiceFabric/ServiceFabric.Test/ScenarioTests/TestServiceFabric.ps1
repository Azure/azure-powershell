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

	WaitForClusterReadyStateIfRecord $clusterName  $resourceGroupName

	$cluster = Update-AzServiceFabricDurability -Level $durabilityLevel -NodeType $nodeTypeName -ClusterName $clusterName -ResourceGroupName $resourceGroupName -Verbose
	$clusters = Get-AzServiceFabricCluster -ClusterName $clusterName -ResourceGroupName $resourceGroupName 
	Assert-AreEqual $clusters[0].NodeTypes.Where({$_.Name -eq $newNodeTypeName}).DurabilityLevel $durabilityLevel
}

function Test-UpdateAzureRmServiceFabricReliability
{
	$clusterName = Get-ClusterName
	$resourceGroupName = Get-ResourceGroupName
	$reliabilityLevel = Get-ReliabilityLevel

	WaitForClusterReadyStateIfRecord $clusterName  $resourceGroupName

	$cluster = Update-AzServiceFabricReliability -ReliabilityLevel $reliabilityLevel  -ClusterName $clusterName -ResourceGroupName $resourceGroupName -Verbose
	$clusters = Get-AzServiceFabricCluster -ClusterName $clusterName -ResourceGroupName $resourceGroupName 
	Assert-AreEqual $clusters[0].ReliabilityLevel $reliabilityLevel
}

function Test-AddAzureRmServiceFabricClusterCertificate
{
	$clusterName = Get-ClusterName
	$resourceGroupName = Get-ResourceGroupName
    $keyvaulturi = Get-SecretUrl

	WaitForClusterReadyStateIfRecord $clusterName  $resourceGroupName

    $cluster = 	Add-AzServiceFabricClusterCertificate -ResourceGroupName $resourceGroupName  -ClusterName $clusterName -SecretIdentifier $keyvaulturi -Verbose
	$clusters = Get-AzServiceFabricCluster -ClusterName $clusterName -ResourceGroupName $resourceGroupName 
	Assert-NotNull $clusters[0].Certificate.ThumbprintSecondary 
}

function Test-AddAzureRmServiceFabricClusterCertificateCNNotAllowed
{
	$clusterName = Get-ClusterName
	$resourceGroupName = Get-ResourceGroupName
    $keyvaulturi = Get-SecretUrl
	$commonName = Get-CACertCommonName
	$issuerThumbprint = Get-CACertIssuerThumbprint

	$exceptionThrown = $false

	Try
	{
		$cluster = 	Add-AzServiceFabricClusterCertificate -ResourceGroupName $resourceGroupName  -ClusterName $clusterName -SecretIdentifier $keyvaulturi `
			-CertificateCommonName $commonName -CertificateIssuerThumbprint $issuerThumbprint -Verbose -ErrorAction Stop
	}
	Catch [System.Management.Automation.PSInvalidOperationException]
	{
		Assert-AreEqual $true ($PSItem.Exception.Message -match 'Unable to mix certificates by common name and thumbprint')
		$exceptionThrown = $true
	}

	Assert-AreEqual $true $exceptionThrown "Expected Exception mix certs not thrown"

}

function Test-RemoveAzureRmServiceFabricClusterCertificate
{
	$clusterName = Get-ClusterName
	$resourceGroupName = Get-ResourceGroupName
    $thumbprint  = Get-Thumbprint

	WaitForClusterReadyStateIfRecord $clusterName  $resourceGroupName

	$cluster = Remove-AzServiceFabricClusterCertificate -ClusterName $clusterName -ResourceGroupName $resourceGroupName -Thumbprint $thumbprint -Verbose
	$clusters = Get-AzServiceFabricCluster -ClusterName $clusterName -ResourceGroupName $resourceGroupName 
	Assert-Null $clusters[0].Certificate.ThumbprintSecondary 
}

function Test-RemoveAzureRmServiceFabricClusterCertificateNotAllowed
{
	$clusterName = Get-ClusterName
	$resourceGroupName = Get-ResourceGroupName
    $thumbprint  = Get-Thumbprint

	$exceptionThrown = $false
	Try
	{
		$cluster = Remove-AzServiceFabricClusterCertificate -ClusterName $clusterName -ResourceGroupName $resourceGroupName -Thumbprint $thumbprint -Verbose -ErrorAction Stop
	}
	Catch [System.InvalidOperationException]
	{
		Assert-AreEqual $true ($PSItem.Exception.Message -match 'There is only one certificate in the cluster')
		$exceptionThrown = $true
	}
	
	Assert-AreEqual $true $exceptionThrown "Expected Exception only one cert not thrown"
}

function Test-AddAzureRmServiceFabricClientCertificate
{
	$clusterName = Get-ClusterName
	$resourceGroupName = Get-ResourceGroupName
    $certName  = Get-NewCertName
    $commonName = "cn=$certName"
    $thumbprint  = Get-Thumbprint

	WaitForClusterReadyStateIfRecord $clusterName  $resourceGroupName

	$cluster = Add-AzServiceFabricClientCertificate -ClusterName $clusterName -ResourceGroupName $resourceGroupName -CommonName $commonName -IssuerThumbprint $thumbprint -Verbose
	$clusters = Get-AzServiceFabricCluster -ClusterName $clusterName -ResourceGroupName $resourceGroupName 
    Assert-AreEqual $clusters[0].ClientCertificateCommonNames[0].CertificateCommonName $commonName
}

function Test-RemoveAzureRmServiceFabricClientCertificate
{
	$clusterName = Get-ClusterName
	$resourceGroupName = Get-ResourceGroupName
    $certName  = Get-NewCertName
    $commonName = "cn=$certName"
    $thumbprint  = Get-Thumbprint

	WaitForClusterReadyStateIfRecord $clusterName  $resourceGroupName

	$cluster = Remove-AzServiceFabricClientCertificate -ClusterName $clusterName -ResourceGroupName $resourceGroupName -CommonName $commonName -IssuerThumbprint $thumbprint -Verbose
	$clusters = Get-AzServiceFabricCluster -ClusterName $clusterName -ResourceGroupName $resourceGroupName
	Assert-Null $clusters[0].ClientCertificateCommonNames[0]
}

function Test-NewAzureRmServiceFabricCluster
{
    $clusterName = "azurermsfclustertptest"
    $resourceGroupName = "azurermsfrgTP"
    $keyvaulturi = Get-SecretUrl
    $vmPassword = Get-RandomPwd | ConvertTo-SecureString -Force -AsPlainText

    $cluster = New-AzServiceFabricCluster -ResourceGroupName $resourceGroupName -VmPassword $vmPassword `
        -TemplateFile (Join-Path $pwd '\Resources\template.json') -ParameterFile (Join-Path $pwd '\Resources\parameters.json') -SecretIdentifier $keyvaulturi -Verbose

    $clusters = Get-AzServiceFabricCluster -ClusterName $clusterName -ResourceGroupName $resourceGroupName

	$newClsuter = $clusters.Where({$_.Name -eq $clusterName})
	Assert-NotNull $newClsuter
	Assert-NotNull $newClsuter.Certificate
	Assert-Null $newClsuter.CertificateCommonNames
}

function Test-NewAzureRmServiceFabricClusterCNCert
{
    $clusterName = "azurermsfcntest"
    $resourceGroupName = "azurermsfrgCNTest"
    $keyvaulturi = Get-CACertSecretUrl
    $vmPassword = Get-RandomPwd | ConvertTo-SecureString -Force -AsPlainText
    $commonName = Get-CACertCommonName
	$issuerThumbprint = Get-CACertIssuerThumbprint

    $cluster = New-AzServiceFabricCluster -ResourceGroupName $resourceGroupName -VmPassword $vmPassword `
        -TemplateFile (Join-Path $pwd '\Resources\templateCNCert.json') -ParameterFile (Join-Path $pwd '\Resources\parametersCNCert.json') `
		-SecretIdentifier $keyvaulturi -CertCommonName $commonName -CertIssuerThumbprint $issuerThumbprint -Verbose

    $clusters = Get-AzServiceFabricCluster -ClusterName $clusterName -ResourceGroupName $resourceGroupName

    $newClsuter = $clusters.Where({$_.Name -eq $clusterName})
	Assert-NotNull $newClsuter
	Assert-Null $newClsuter.Certificate 
	Assert-NotNull $newClsuter.CertificateCommonNames.CommonNames
	Assert-AreEqual $newClsuter.CertificateCommonNames.CommonNames[0].CertificateCommonName $commonName
}

function Test-AddAzureRmServiceFabricNodeType
{
	$clusterName = Get-ClusterName
	$resourceGroupName = Get-ResourceGroupName	
	$newNodeTypeName = Get-NewNodeTypeName

	WaitForClusterReadyStateIfRecord $clusterName  $resourceGroupName

	$clusters = Get-AzServiceFabricCluster -ClusterName $clusterName -ResourceGroupName $resourceGroupName
    $vmPassword = Get-RandomPwd | ConvertTo-SecureString -Force -AsPlainText
	$cluster = Add-AzServiceFabricNodeType -Capacity 1 -VmUserName username -VmPassword $vmPassword -NodeType $newNodeTypeName -ClusterName $clusterName -ResourceGroupName $resourceGroupName -Verbose
	$clusters = Get-AzServiceFabricCluster -ClusterName $clusterName -ResourceGroupName $resourceGroupName 
	Assert-NotNull $clusters[0].NodeTypes.Where({$_.Name -eq $newNodeTypeName})
}

function Test-RemoveAzureRmServiceFabricNodeType
{
	$clusterName = Get-ClusterName
	$resourceGroupName = Get-ResourceGroupName	
	$newNodeTypeName = Get-NewNodeTypeName

	WaitForClusterReadyStateIfRecord $clusterName  $resourceGroupName

	$clusters = Get-AzServiceFabricCluster -ClusterName $clusterName -ResourceGroupName $resourceGroupName
	$cluster = Remove-AzServiceFabricNodeType -ResourceGroupName $resourceGroupName -ClusterName $clusterName -NodeType $newNodeTypeName -Verbose
	$clusters = Get-AzServiceFabricCluster -ClusterName $clusterName -ResourceGroupName $resourceGroupName 
	Assert-Null $clusters[0].NodeTypes.Where({$_.Name -eq $newNodeTypeName})
}

function Test-AddAzureRmServiceFabricNode
{
    $clusterName = Get-ClusterName
    $resourceGroupName = Get-ResourceGroupName	
    $newNodeTypeName = Get-NewNodeTypeName
    $nodes = 5

	WaitForClusterReadyStateIfRecord $clusterName  $resourceGroupName

    $clusters = Get-AzServiceFabricCluster -ClusterName $clusterName -ResourceGroupName $resourceGroupName
    $count = $clusters[0].NodeTypes.Where({$_.Name -eq $newNodeTypeName}).VmInstanceCount
    $cluster = Add-AzServiceFabricNode -NodeType $newNodeTypeName -NumberOfNodesToAdd $nodes -ClusterName $clusterName -ResourceGroupName $resourceGroupName -Verbose
    $clusters = Get-AzServiceFabricCluster -ClusterName $clusterName -ResourceGroupName $resourceGroupName 
    Assert-AreEqual ($count + $nodes)  $clusters[0].NodeTypes.Where({$_.Name -eq $newNodeTypeName}).VmInstanceCount
}

function Test-RemoveAzureRmServiceFabricNode
{
    $clusterName = Get-ClusterName
    $resourceGroupName = Get-ResourceGroupName	
    $newNodeTypeName = Get-NewNodeTypeName
    $nodes = 1

	WaitForClusterReadyStateIfRecord $clusterName  $resourceGroupName

    $clusters = Get-AzServiceFabricCluster -ClusterName $clusterName -ResourceGroupName $resourceGroupName
    $count = $clusters[0].NodeTypes.Where({$_.Name -eq $newNodeTypeName}).VmInstanceCount
    $cluster = Remove-AzServiceFabricNode -NodeType $newNodeTypeName -NumberOfNodesToRemove $nodes -ClusterName $clusterName -ResourceGroupName $resourceGroupName -Verbose
    $clusters = Get-AzServiceFabricCluster -ClusterName $clusterName -ResourceGroupName $resourceGroupName 
    Assert-AreEqual ($count - $nodes)  $clusters[0].NodeTypes.Where({$_.Name -eq $newNodeTypeName}).VmInstanceCount
}

function Test-SetAzureRmServiceFabricSettings
{
	$clusterName = Get-ClusterName
	$resourceGroupName = Get-ResourceGroupName	
	$sectionName =  Get-SectionName
	$parameterName = Get-ParameterName
	$valueName = Get-ValueName

	WaitForClusterReadyStateIfRecord $clusterName  $resourceGroupName

	$clusters = Get-AzServiceFabricCluster -ClusterName $clusterName -ResourceGroupName $resourceGroupName
	$count = $clusters[0].FabricSettings.Count
	$cluster = Set-AzServiceFabricSetting -ResourceGroupName $resourceGroupName -ClusterName $clusterName -Section $sectionName -Parameter $parameterName -Value $valueName -Verbose
	$clusters = Get-AzServiceFabricCluster -ClusterName $clusterName -ResourceGroupName $resourceGroupName 
	$settingAdded = $false;
	foreach ($setting in $clusters[0].FabricSettings)
	{
		if ($setting.name -eq $sectionName)
		{
			$settingAdded = ($setting.parameters[0].name -eq $parameterName -and $setting.parameters[0].value -eq $valueName)
		}
	}

	Assert-True { $settingAdded }
}

function Test-RemoveAzureRmServiceFabricSettings
{
	$clusterName = Get-ClusterName
	$resourceGroupName = Get-ResourceGroupName	
	$sectionName =  Get-SectionName
	$parameterName = Get-ParameterName

	WaitForClusterReadyStateIfRecord $clusterName  $resourceGroupName

	$clusters = Get-AzServiceFabricCluster -ClusterName $clusterName -ResourceGroupName $resourceGroupName
	$preSettings = $clusters[0].FabricSettings
	$cluster = Remove-AzServiceFabricSetting -ResourceGroupName $resourceGroupName -ClusterName $clusterName -Section $sectionName -Parameter $parameterName -Verbose
	$clusters = Get-AzServiceFabricCluster -ClusterName $clusterName -ResourceGroupName $resourceGroupName 
	Assert-AreNotEqual $preSettings  $clusters[0].FabricSettings
}

function Test-SetAzureRmServiceFabricUpgradeType
{
	$clusterName = Get-ClusterName
	$resourceGroupName = Get-ResourceGroupName
	
	$cluster = Set-AzServiceFabricUpgradeType -ResourceGroupName $resourceGroupName -ClusterName $clusterName -UpgradeMode Manual -Verbose
	$clusters = Get-AzServiceFabricCluster -ClusterName $clusterName -ResourceGroupName $resourceGroupName 
	Assert-AreEqual $clusters[0].UpgradeMode 'Manual'
}

function Test-AddAzureRmServiceFabricApplicationCertificate
{
	$clusterName = Get-ClusterName
	$resourcGroup = Get-ResourceGroupName
	$certSecert = Get-CertAppSecretUrl
	$res = Add-AzServiceFabricApplicationCertificate -ResourceGroupName $resourcGroup -Name $clusterName -SecretIdentifier $certSecert
	Assert-NotNull $res.CertificateThumbprint
}

function Test-AddAzureRmServiceFabricApplicationCertificateRollback
{
	$clusterName = Get-ClusterName
	$resourcGroup = Get-ResourceGroupName
	$certWU_SecretId = Get-CertWUSecretUrl

	$exceptionThrown = $false
	Try
	{
		$res = Add-AzureRmServiceFabricApplicationCertificate -ResourceGroupName $resourcGroup -Name $clusterName -SecretIdentifier $certWU_SecretId
	}
	Catch [System.Exception]
	{
		$Exception = $PSitem.Exception
		while ($Exception.InnerException -ne $null)
		{
			$Exception = $Exception.InnerException
		}
		
		Assert-AreEqual $true ($Exception.Message -match 'is different from the location of the VM') ("unexpected error message: " + $Exception.Message )
		$exceptionThrown = $true
	}

	Assert-AreEqual $true $exceptionThrown "Expected Exception keyvault in different location than VMSS not thrown"
}