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
# Use these commands to setup the tests for recording - KV operations do not work within the test framework
#####
#
# $password = "[password]" | ConvertTo-SecureString -Force -AsPlainText
# New-AzureRmServiceFabricCluster -ResourceGroupName azurermsfrg -Name azurermsfcluster -Location southcentralus -VmPassword $password -KeyVaultName azurermsfkv -CertificateOutputFolder $pwd -CertificatePassword $password -CertificateSubjectName "AzureRMSFTestCert"
# $policy = New-AzureKeyVaultCertificatePolicy -SecretContentType application/x-pkcs12 -SubjectName "CN=AzureRMSFTestCert2" -IssuerName Self
# Add-AzureKeyVaultCertificate -VaultName azurermsfkv -Name AzureRMSFTestCert2 -CertificatePolicy $policy
# Get-AzureKeyVaultCertificate -VaultName azurermsfkv -Name AzureRMSFTestCert2 | select Thumbprint, SecretId
# Add the above values to Get-SecretUrl and Get-Thumbrprint
#
#####

function WaitClusterReady
{
	$clusterName = Get-ClusterName
	$resourceGroupName = Get-ResourceGroupName
	$clusters = Get-AzureRmServiceFabricCluster -ClusterName $clusterName -ResourceGroupName $resourceGroupName
	while($clusters[0].ClusterState -ne 'Ready' -and $clusters[0].ClusterState -ne 'Failed')
	{
		Start-Sleep -s 60
	}
}

function Get-ResourceGroupName
{
    return "azurermsfrg";
}

function Get-ClusterName
{
    return "azurermsfcluster";
}

function Get-NodeTypeName
{
    return "nt1vm";
}

function Get-KeyVaultName
{
    return "azurermsfkv";
}

function Get-NewCertName
{
    return "AzureRMSFTestCert2"
}

function Get-SecretUrl
{
    # Thumbprint for this cert should be specified in TestServiceFabric.cs
    return "https://azurermsfkv.vault.azure.net/secrets/AzureRMSFTestCert2/62bccb6ecac54a03a204c7676fa9b8cf"
}

function Get-Thumbprint
{
    return "2F51AC39C590551FC7391A7A0A187A67BF8256CA"
}

function Get-DurabilityLevel
{
	return "Silver"
}

function Get-ReliabilityLevel
{
	return "Bronze"
}

function Get-NewNodeTypeName
{
	return 'nt2vm'
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

function Get-VmPwd
{
    $length = 10
    $allowedCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray()
    $allowedDigits = "0123456789".ToCharArray()
    $allowedSpecial = "!@#$%^&*()-+_={}\[];':,.<>".ToCharArray()
    $myRandomString = -join (Get-Random -Count $length -InputObject $allowedCharacters)
    $myRandomString += Get-Random -Count 1 -InputObject $allowedDigits
    $myRandomString += Get-Random -Count 1 -InputObject $allowedSpecial
    return  "$myRandomString"
}