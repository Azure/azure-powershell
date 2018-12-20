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
#
# # add second certificate to key vault (AzureRMSFTestCert2)
# $policy = New-AzureKeyVaultCertificatePolicy -SecretContentType application/x-pkcs12 -SubjectName "CN=AzureRMSFTestCert2" -IssuerName Self
# Add-AzureKeyVaultCertificate -VaultName azurermsfkv -Name AzureRMSFTestCert2 -CertificatePolicy $policy
# Get-AzureKeyVaultCertificate -VaultName azurermsfkv -Name AzureRMSFTestCert2 | select Thumbprint, SecretId
# # Add the above values to Get-SecretUrl and Get-Thumbrprint
#
# # add certificate for application test to key vault (AzureRMSFTestCertApp)
# $policyCertApp = New-AzureKeyVaultCertificatePolicy -SecretContentType application/x-pkcs12 -SubjectName "CN=AzureRMSFTestCertApp" -IssuerName Self
# # Add-AzureKeyVaultCertificate -VaultName azurermsfkvtest -Name AzureRMSFTestCertApp -CertificatePolicy $policyCertApp
# Get-AzureKeyVaultCertificate -VaultName azurermsfkvtest -Name AzureRMSFTestCertApp | select Thumbprint, SecretId
# # Add the above values to Get-CertAppThumbprint and Get-CertAppSecretUrl
#
# # add ca certificate for create with common name test (azurermsfcntest.southcentralus.cloudapp.azure.com)
# # ask alsantam for password and cert file 
# $certPassword = "[pass]" | ConvertTo-SecureString -Force -AsPlainText 
# $KVSecret = Import-AzureKeyVaultCertificate -VaultName azurermsfkvtest -Name azurermsfcntest -FilePath c:\path\to\file\azurermsfcntest.pfx -Password $certPassword -Verbose
# $KVSecret.SecretId
# # Add the above value to Get-CACertSecretUrl
#
#####

function Get-ResourceGroupName
{
    return "azurermsfrg";
}

function Get-ClusterName
{
    return "azurermsfclustertest";
}

function Get-NodeTypeName
{
    return "nt1vm";
}

function Get-KeyVaultName
{
    return "azurermsfkvtest";
}

function Get-NewCertName
{
    return "AzureRMSFTestCert2"
}

function Get-SecretUrl
{
    # Thumbprint for this cert should be specified in TestServiceFabric.cs in ServiceFabricCmdletBase.TestThumbprint
    return "https://azurermsfkvtest.vault.azure.net:443/secrets/AzureRMSFTestCert2/631f0364216e46738dffca1bf6067e74"
}

function Get-Thumbprint
{
    #Change the thumbprint in the TestServiceFabric.cs file as well in ServiceFabricCmdletBase.TestThumbprint
    return "3C70633899C7F5194596EB745D1DD106E9F06E79"
}

function Get-CertAppSecretUrl
{
    # Thumbprint for this cert should be specified in TestServiceFabric.cs in ServiceFabricCmdletBase.TestThumbprintAppCert
    return " https://azurermsfkvtest.vault.azure.net:443/secrets/AzureRMSFTestCertApp/26002f61565446baaa6e3bf120227792"
}

function Get-CertAppThumbprint
{
    #Change the thumbprint in the TestServiceFabric.cs file as well in ServiceFabricCmdletBase.TestThumbprintAppCert
    return "13B2D20A82B3785B6F9F111FA939DB712F41DB96"
}

function Get-CACertCommonName
{
	return "azurermsfcntest.southcentralus.cloudapp.azure.com"
}

function Get-CACertIssuerThumbprint
{
	return "417e225037fbfaa4f95761d5ae729e1aea7e3a42,d4de20d05e66fc53fe1a50882c78db2852cae474"
}

function Get-CACertSecretUrl
{
	return "https://azurermsfkvtest.vault.azure.net:443/secrets/azurermsfcntest/4984be5c03b04f55aa0c771e163472fa"
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

function Get-RandomPwd
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

function WaitForClusterReadyStateIfRecord($clusterName, $resourceGroupName)
{
	if ([Microsoft.Azure.Test.HttpRecorder.HttpMockServer]::Mode -ne [Microsoft.Azure.Test.HttpRecorder.HttpRecorderMode]::Playback)
	{
		# Wait for Ready cluster state before updating otherwise update is going to fail
		if (-not (WaitForClusterReadyState $clusterName $resourceGroupName))
		{
			Assert-True $false 'Cluster is not in Ready state. Can not continue with test.'
		}
	}
}

function WaitForClusterReadyState($clusterName, $resourceGroupName, $timeoutInSeconds = 1200)
{
    $timeoutTime = (Get-Date).AddSeconds($timeoutInSeconds)
    while (-not $clusterReady -and (Get-Date) -lt $timeoutTime) {
        $cluster = (Get-AzureRmServiceFabricCluster -ResourceGroupName $resourceGroupName -Name $clusterName)[0]
        if ($cluster.ClusterState -eq "Ready")
        {
            return $true
            break
        }

        Write-Host "Cluster state: $($cluster.ClusterState). Waiting for Ready state before continuing."
        Start-Sleep -Seconds 15
    }

    Write-Error "WaitForClusterReadyState timed out"
    return $false
}