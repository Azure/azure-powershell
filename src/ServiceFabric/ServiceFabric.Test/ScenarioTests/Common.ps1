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
# New-AzServiceFabricCluster -ResourceGroupName azurermsfrg -Name azurermsfcluster -Location southcentralus -VmPassword $password -KeyVaultName azurermsfkv -CertificateOutputFolder $pwd -CertificatePassword $password -CertificateSubjectName "AzureRMSFTestCert"
#
# # add second certificate to key vault (AzureRMSFTestCert2)
# $policy = New-AzKeyVaultCertificatePolicy -SecretContentType application/x-pkcs12 -SubjectName "CN=AzureRMSFTestCert2" -IssuerName Self
# Add-AzKeyVaultCertificate -VaultName azurermsfkv -Name AzureRMSFTestCert2 -CertificatePolicy $policy
# Get-AzKeyVaultCertificate -VaultName azurermsfkv -Name AzureRMSFTestCert2 | select Thumbprint, SecretId
# # Add the above values to Get-SecretUrl and Get-Thumbrprint
#
# # add certificate for application test to key vault (AzureRMSFTestCertApp)
# $policyCertApp = New-AzKeyVaultCertificatePolicy -SecretContentType application/x-pkcs12 -SubjectName "CN=AzureRMSFTestCertApp" -IssuerName Self
# # Add-AzKeyVaultCertificate -VaultName azurermsfkvtest -Name AzureRMSFTestCertApp -CertificatePolicy $policyCertApp
# Get-AzKeyVaultCertificate -VaultName azurermsfkvtest -Name AzureRMSFTestCertApp | select Thumbprint, SecretId
# # Add the above values to Get-CertAppThumbprint and Get-CertAppSecretUrl
#
# # add ca certificate for create with common name test (azurermsfcntest.southcentralus.cloudapp.azure.com)
# # ask alsantam for password and cert file 
# $certPassword = "[pass]" | ConvertTo-SecureString -Force -AsPlainText 
# $KVSecret = Import-AzKeyVaultCertificate -VaultName azurermsfkvtest -Name azurermsfcntest -FilePath c:\path\to\file\azurermsfcntest.pfx -Password $certPassword -Verbose
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
    return "https://azurermsfkvtest.vault.azure.net:443/secrets/AzureRMSFTestCert2/4e680cd578ba4e57b650d9f89cd20835"
}

function Get-InitialThumbprint
{
    return "3545EEBFA6F5EA7A1D436F5D6C708AD6A7110D6B"
}

function Get-Thumbprint
{
    # Change the thumbprint in the TestServiceFabric.cs file as well in ServiceFabricCmdletBase.TestThumbprint
    return "9ED6D1B225C63DC653CB0D9E16CFD7F799785FAC"
}

function Get-CertAppSecretUrl
{
    # Thumbprint for this cert should be specified in TestServiceFabric.cs in ServiceFabricCmdletBase.TestThumbprintAppCert
    return "https://azurermsfkvtest.vault.azure.net:443/secrets/AzureRMSFTestCertApp/599d307311bf4508b7511ed482fa746f"
}

function Get-CertAppThumbprint
{
    # Change the thumbprint in the TestServiceFabric.cs file as well in ServiceFabricCmdletBase.TestThumbprintAppCert
    return "3B892D25432FDA538F54B1EADD0B28BA82C488CC"
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
	return "https://azurermsfkvtest.vault.azure.net:443/secrets/azurermsfcntest/219a6d1803c34447b686db16ecd6285a"
}

function Get-CertWUSecretUrl
{
	return "https://azurermsfkvtestwu.vault.azure.net:443/secrets/AzureRMSFTestCertWU/5236086354ac470e8efa4e0426b6144d"
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
        $cluster = (Get-AzServiceFabricCluster -ResourceGroupName $resourceGroupName -Name $clusterName)[0]
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

function WaitForAllJob($timeoutInSeconds = 1200)
{
    $timeoutTime = (Get-Date).AddSeconds($timeoutInSeconds)
    $allJobs = Get-Job
    do
    {
        $completed = Get-Job | Where-Object {  $_.State -eq "Completed" }
        if ($completed.Count -eq $allJobs.Count)
        {
            return $true
            break
		}

        $failed = Get-Job | Where-Object {  $_.State -eq "Failed" }
        if ($failed.Count -gt 0)
        {
            Write-Error "At least one Job failed" $failed
            return $false
		}

        Start-Sleep -Seconds 15
    } while ((Get-Date) -lt $timeoutTime)

    Write-Error "WaitForJob timed out"
    return $false
}

# Application functions

function Get-AppTypeName
{
    return "CalcServiceApp"
}

function Get-AppTypeV1Name
{
    return "1.0"
}

function Get-AppTypeV2Name
{
    return "1.1"
}

function Get-AppPackageV1
{
    return "https://azsfapptest.blob.core.windows.net/azsfapptest/CalcApp_1.0.sfpkg"
}

function Get-AppPackageV2
{
    return "https://azsfapptest.blob.core.windows.net/azsfapptest/CalcApp_1.1.sfpkg"
}

function Get-ServiceTypeName
{
    return "CalcServiceType"
}