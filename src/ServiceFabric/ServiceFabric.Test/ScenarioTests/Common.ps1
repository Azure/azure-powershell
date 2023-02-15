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
    return "https://azurermsfkvtest.vault.azure.net:443/secrets/AzureRMSFTestCert2/b4bfdec635514591bc1ee087b9b61772"
}

function Get-InitialThumbprint
{
    return "ED1647D7E58F9F69E473B4700A0CCED50F7F65B0"
}

function Get-Thumbprint
{
    # Change the thumbprint in the TestServiceFabric.cs file as well in ServiceFabricCmdletBase.TestThumbprint
    return "D1DC34B88497F50FB0C0F019DA74E4DA5FADD56D"
}

function Get-CertAppSecretUrl
{
    # Thumbprint for this cert should be specified in TestServiceFabric.cs in ServiceFabricCmdletBase.TestThumbprintAppCert
    return "https://azurermsfkvtest.vault.azure.net:443/secrets/AzureRMSFTestCertApp/f052a9de0e9249cc8e84f9951a96afe4"
}

function Get-CertAppThumbprint
{
    # Change the thumbprint in the TestServiceFabric.cs file as well in ServiceFabricCmdletBase.TestThumbprintAppCert
    return "50EA76B5EC4B588CC25CB4C38CC13666A0CA0BB3"
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
	return "https://azurermsfkvtest.vault.azure.net:443/secrets/azurermsfcntest/c0770e09071f41b38cbb49204dd2f820"
}

function Get-CertWUSecretUrl
{
	return "https://azurermsfkvtestwu.vault.azure.net:443/secrets/AzureRMSFTestCertWU/4159eda1fcea468e9bf40a361021f18d"
}

function Get-DurabilityLevel
{
	return "Silver"
}

function Get-ReliabilityLevel
{
	return "Bronze"
}

function Get-VmImage
{
	return "Windows"
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
        Start-TestSleep -Seconds 15
    }

    Write-Error "WaitForClusterReadyState timed out"
    return $false
}

function WaitForManagedClusterReadyStateIfRecord($clusterName, $resourceGroupName)
{
	if ([Microsoft.Azure.Test.HttpRecorder.HttpMockServer]::Mode -ne [Microsoft.Azure.Test.HttpRecorder.HttpRecorderMode]::Playback)
	{
		# Wait for Ready cluster state before updating otherwise update is going to fail
		if (-not (WaitForManagedClusterReadyState $clusterName $resourceGroupName))
		{
			Assert-True $false 'Cluster is not in Ready state. Can not continue with test.'
		}
	}
}

function WaitForManagedClusterReadyState($clusterName, $resourceGroupName, $timeoutInSeconds = 1200)
{
    $timeoutTime = (Get-Date).AddSeconds($timeoutInSeconds)
    while (-not $clusterReady -and (Get-Date) -lt $timeoutTime) {
        $cluster = (Get-AzServiceFabricManagedCluster -ResourceGroupName $resourceGroupName -Name $clusterName)[0]
        if ($cluster.ClusterState -eq "Ready")
        {
            return $true
            break
        }

        Write-Host "Cluster state: $($cluster.ClusterState). Waiting for Ready state before continuing."
        Start-TestSleep -Seconds 15
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

        Start-TestSleep -Seconds 15
    } while ((Get-Date) -lt $timeoutTime)

    Write-Error "WaitForJob timed out"
    return $false
}

<#
.SYNOPSIS
Asserts if two hashtables with simple key and value types are equal
#>
function Assert-HashtableEqual($h1, $h2)
{
  if($h1.count -ne $h2.count)
  {
    throw "Hashtable size not equal. Hashtable1: " + $h1.count + " Hashtable2: " + $h2.count
  }

  foreach($key in $h1.Keys)
  {
    if($h1[$key] -ne $h2[$key])
    {
      throw "Tag content not equal. Key:$key Tags1:" +  $h1[$key] + " Tags2:" + $h2[$key]
    }
  }
}

###################
#
# Verify that the actual string ends with the expected suffix
#
#    param [string] $expectedSuffix : The expected suffix
#    param [string] $actual         : The actual string
#    param [string] $message        : The message to return if the actual string does not end with the suffix
####################
function Assert-EndsWith
{
    param([string] $expectedSuffix, [string] $actual, [string] $message)

  Assert-NotNull $actual

  if (!$message)
  {
      $message = "Assertion failed because actual '$actual' does not end with '$expectedSuffix'"
  }

  if (-not $actual.EndsWith($expectedSuffix))
  {
      throw $message
  }

  return $true
}

###################
#
# Verify that the properties of the object are equal taking into account a list of exceptions
#
#    param [object]   $expected       : The expected object
#    param [object]   $actual         : The actual object
#    param [string[]] $except         : The list of property names that don't need to be equal
#    param [string]   $message        : The message to return if the actual string does not end with the suffix
####################
function Assert-AreEqualObjectPropertiesExcept
{
    param([object] $expected, [object] $actual, [string[]] $except, [string] $message)
    
    $properties = $expected | Get-Member -MemberType "Property" | Select -ExpandProperty Name
    
    foreach ($exception in $except) {
        $properties = $properties | Where-Object { $_ -ne $exception }
    }

    $diff = Compare-Object $expected $actual -Property $properties

    if ($diff -ne $null)
    {
        if (!$message)
        {
            $message = "Assert failed because the objects don't match. Expected: " + $diff[0] + " Actual: " + $diff[1]
        }

        throw $message
    }

    return $true
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

# Managed Application functions

function Get-ManagedAppTypeName
{
    return "VotingType"
}

function Get-ManagedAppTypeV1Name
{
    return "1.0.0"
}

function Get-ManagedAppTypeV2Name
{
    return "2.0.0"
}

function Get-ManagedAppPackageV1
{
    return "https://sfmconeboxst.blob.core.windows.net/managed-application-deployment/Voting.sfpkg"
}

function Get-ManagedAppPackageV2
{
    return "https://sfmconeboxst.blob.core.windows.net/managed-application-deployment/Voting.2.0.0.sfpkg"
}

function Get-ManagedStatelessServiceTypeName
{
    return "VotingWebType"
}

function Get-ManagedStatefulServiceTypeName
{
    return "VotingDataType"
}