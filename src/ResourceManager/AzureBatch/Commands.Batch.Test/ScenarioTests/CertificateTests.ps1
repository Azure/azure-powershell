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
Tests basic CRUD operations on certificates
#>
function Test-CertificateCrudOperations
{
    $context = New-Object Microsoft.Azure.Commands.Batch.Test.ScenarioTests.ScenarioTestContext
    $thumbprintAlgorithm = "sha1"

    $localDir = ($pwd).Path # Use $pwd to get the local directory. If $pwd is not used, paths are relative to [Environment]::CurrentDirectory, which can be different
    $certPath = $localDir + "\Resources\BatchTestCert01.cer"
    $x509cert = New-Object System.Security.Cryptography.X509Certificates.X509Certificate2 -ArgumentList $certPath

    # Add the cert
    $x509cert | New-AzureBatchCertificate -BatchContext $context

    # Get the cert and ensure its properties match expectations
    $addedCert = Get-AzureBatchCertificate $thumbprintAlgorithm $x509cert.Thumbprint -BatchContext $context
    Assert-AreEqual $x509cert.Thumbprint $addedCert.Thumbprint
    Assert-AreEqual $thumbprintAlgorithm $addedCert.ThumbprintAlgorithm

    # Delete the cert via pipelining
    $addedCert | Remove-AzureBatchCertificate -BatchContext $context

    # Ensure that our delete call was successful. Use a list operation to avoid the 404 that a get will return.
    $allCerts = Get-AzureBatchCertificate -BatchContext $context
    foreach ($c in $allCerts)
    {
        Assert-True { ($c.Thumbprint -ne $x509cert.Thumbprint) -or ($c.State.ToString().ToLower() -eq 'deleting') }
    }
}

<#
.SYNOPSIS
Tests canceling a cert deletion
#>
function Test-TestCancelCertificateDelete
{
    param([string]$thumbprintAlgorithm, [string]$thumbprint)

    $context = New-Object Microsoft.Azure.Commands.Batch.Test.ScenarioTests.ScenarioTestContext

    # Verify the cert is in the deletefailed state
    $cert = Get-AzureBatchCertificate $thumbprintAlgorithm $thumbprint -BatchContext $context
    Assert-AreEqual 'deletefailed' $cert.State.ToString().ToLower()

    Get-AzureBatchCertificate $thumbprintAlgorithm $thumbprint -BatchContext $context | Stop-AzureBatchCertificateDeletion -BatchContext $context

    # Verify the cert went back to the active state
    $filter = "state eq 'active'"
    $cert = Get-AzureBatchCertificate -Filter $filter -BatchContext $context
    
    Assert-AreEqual $thumbprint $cert.Thumbprint
}