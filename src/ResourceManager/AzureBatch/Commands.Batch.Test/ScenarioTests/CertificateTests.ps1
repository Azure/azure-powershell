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

<#
.SYNOPSIS
Tests adding certificates to a Batch account
#>
function Test-AddCertificate
{
    param([string]$accountName)

    $context = Get-ScenarioTestContext $accountName

    # Load certificates so thumbprints can be compared later
    $localDir = ($pwd).Path # Use $pwd to get the local directory. If $pwd is not used, paths are relative to [Environment]::CurrentDirectory, which can be different
    $cer2Path = $localDir + "\Resources\BatchTestCert02.cer"
    $cer3Path = $localDir + "\Resources\BatchTestCert03.cer"
    $pfx4Path = $localDir + "\Resources\BatchTestCert04.pfx"
    $pfx5Path = $localDir + "\Resources\BatchTestCert05.pfx"

    $password = "Passw0rd"
    $securePassword = ConvertTo-SecureString $password -AsPlainText -Force

    $cer2 = New-Object System.Security.Cryptography.X509Certificates.X509Certificate2 -ArgumentList $cer2Path
    $cer3 = New-Object System.Security.Cryptography.X509Certificates.X509Certificate2 -ArgumentList $cer3Path
    $pfx4 = New-Object System.Security.Cryptography.X509Certificates.X509Certificate2 -ArgumentList @($pfx4Path,$securePassword)
    $pfx5 = New-Object System.Security.Cryptography.X509Certificates.X509Certificate2 -ArgumentList @($pfx5Path,$securePassword)
    $pfx5Bytes = [System.IO.File]::ReadAllBytes($pfx5Path)
        
    try 
    {
        # .cer by file path
        New-AzureBatchCertificate $cer2Path -BatchContext $context
        $cert = Get-AzureBatchCertificate "sha1" $cer2.Thumbprint -BatchContext $context
        Assert-AreEqual $cer2.Thumbprint $cert.Thumbprint

        # .cer by raw data
        $cer3 | New-AzureBatchCertificate -BatchContext $context
        $cert = Get-AzureBatchCertificate "sha1" $cer3.Thumbprint -BatchContext $context
        Assert-AreEqual $cer3.Thumbprint $cert.Thumbprint
        
        # .pfx by file path
        New-AzureBatchCertificate $pfx4Path -Password $password -BatchContext $context
        $cert = Get-AzureBatchCertificate "sha1" $pfx4.Thumbprint -BatchContext $context
        Assert-AreEqual $pfx4.Thumbprint $cert.Thumbprint

        # .pfx by raw data
        New-AzureBatchCertificate $pfx5Bytes -Password $password -BatchContext $context
        $cert = Get-AzureBatchCertificate "sha1" $pfx4.Thumbprint -BatchContext $context
        Assert-AreEqual $pfx4.Thumbprint $cert.Thumbprint
    }
    finally
    {
        Get-AzureBatchCertificate -BatchContext $context | Remove-AzureBatchCertificate -Force -BatchContext $context
    }
}

<#
.SYNOPSIS
Tests querying for a certificate by its thumbprint
#>
function Test-GetCertificateByThumbprint
{
    param([string]$accountName, [string]$thumbprintAlgorithm, [string]$thumbprint)

    $context = Get-ScenarioTestContext $accountName
    $cert = Get-AzureBatchCertificate $thumbprintAlgorithm $thumbprint -BatchContext $context

    Assert-AreEqual $thumbprint $cert.Thumbprint
    Assert-AreEqual $thumbprintAlgorithm $cert.ThumbprintAlgorithm
}

<#
.SYNOPSIS
Tests querying for Batch certs using a filter
#>
function Test-ListCertificatesByFilter
{
    param([string]$accountName, [string]$state, [string]$toDeleteThumbprint, [string]$matches)

    $context = Get-ScenarioTestContext $accountName
    $filter = "state eq '$state'"

    # Put a cert in the 'deleting' state
    Remove-AzureBatchCertificate "sha1" $toDeleteThumbprint -Force -BatchContext $context

    $certs = Get-AzureBatchCertificate -Filter $filter -BatchContext $context

    Assert-AreEqual $matches $certs.Length
    foreach($cert in $certs)
    {
        Assert-AreEqual $state $cert.State
    }
}

<#
.SYNOPSIS
Tests querying for Batch certs using a select clause
#>
function Test-GetAndListCertificatesWithSelect
{
    param([string]$accountName, [string]$thumbprintAlgorithm, [string]$thumbprint)

    $context = Get-ScenarioTestContext $accountName
    $filter = "state eq 'active'"
    $selectClause = "thumbprint,state"

    # Test with Get cert API
    $cert = Get-AzureBatchCertificate $thumbprintAlgorithm $thumbprint -BatchContext $context
    Assert-AreNotEqual $null $cert.Url
    Assert-AreEqual $thumbprint $cert.Thumbprint

    $cert = Get-AzureBatchCertificate $thumbprintAlgorithm $thumbprint -Select $selectClause -BatchContext $context
    Assert-AreEqual $null $cert.Url
    Assert-AreEqual $thumbprint $cert.Thumbprint

    # Test with List certs API
    $cert = Get-AzureBatchCertificate -Filter $filter -BatchContext $context
    Assert-AreNotEqual $null $cert.Url
    Assert-AreEqual $thumbprint $cert.Thumbprint

    $cert = Get-AzureBatchCertificate -Filter $filter -Select $selectClause -BatchContext $context
    Assert-AreEqual $null $cert.Url
    Assert-AreEqual $thumbprint $cert.Thumbprint
}

<#
.SYNOPSIS
Tests querying for Batch certs and supplying a max count
#>
function Test-ListCertificatesWithMaxCount
{
    param([string]$accountName, [string]$maxCount)

    $context = Get-ScenarioTestContext $accountName
    $certs = Get-AzureBatchCertificate -MaxCount $maxCount -BatchContext $context

    Assert-AreEqual $maxCount $certs.Length
}

<#
.SYNOPSIS
Tests querying for all certs under an account
#>
function Test-ListAllCertificates
{
    param([string]$accountName, [string]$count)

    $context = Get-ScenarioTestContext $accountName
    $certs = Get-AzureBatchCertificate -BatchContext $context

    Assert-AreEqual $count $certs.Length
}

<#
.SYNOPSIS
Tests deleting a cert
#>
function Test-DeleteCertificate
{
    param([string]$accountName, [string]$thumbprintAlgorithm, [string]$thumbprint)

    $context = Get-ScenarioTestContext $accountName

    # Verify the cert exists
    $cert = Get-AzureBatchCertificate $thumbprintAlgorithm $thumbprint -BatchContext $context
    Assert-AreEqual $thumbprint $cert.Thumbprint

    Get-AzureBatchCertificate $thumbprintAlgorithm $thumbprint -BatchContext $context | Remove-AzureBatchCertificate -Force -BatchContext $context

    # Verify the cert was deleted. Use the List API since the Get Certificate API will return a 404 if the cert isn't found.
    $filter = "state eq 'deleting'"
    $cert = Get-AzureBatchCertificate -Filter $filter -BatchContext $context
    
    Assert-True { $cert -eq $null -or $cert.Thumbprint -eq $thumbprint }
}

<#
.SYNOPSIS
Tests canceling a cert deletion
#>
function Test-TestCancelCertificateDelete
{
    param([string]$accountName, [string]$thumbprintAlgorithm, [string]$thumbprint)

    $context = Get-ScenarioTestContext $accountName

    # Verify the cert is in the deletefailed state
    $cert = Get-AzureBatchCertificate $thumbprintAlgorithm $thumbprint -BatchContext $context
    Assert-AreEqual 'deletefailed' $cert.State.ToString().ToLower()

    Get-AzureBatchCertificate $thumbprintAlgorithm $thumbprint -BatchContext $context | Stop-AzureBatchCertificateDeletion -BatchContext $context

    # Verify the cert went back to the active state
    $filter = "state eq 'active'"
    $cert = Get-AzureBatchCertificate -Filter $filter -BatchContext $context
    
    Assert-AreEqual $thumbprint $cert.Thumbprint
}