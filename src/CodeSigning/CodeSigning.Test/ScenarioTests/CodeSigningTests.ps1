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
Test codesigning command to get extended key usage from the certificate profile
#>
function Test-CodeSigningEku {

    $accountName = "acs-test-account"
    $profileName = "acs-test-account-ci"
    $endPointUrl = "https://scus.codesigning.azure.net/"
    $expectedEku = "1.3.6.1.4.1.311.97.1.3.1.29433.35007.34545.16815.37291.11644.53265.56135,1.3.6.1.4.1.311.97.1.4.1.29433.35007.34545.16815.37291.11644.53265.56135"

    try {
        # Test Get CodeSigning Eku
        $eku = Get-AzCodeSigningCustomerEku -AccountName $accountName -ProfileName $profileName -EndpointUrl $endPointUrl
        Assert-AreEqual $eku $expectedEku
    }

    finally {

    }
}

<#
.SYNOPSIS
Test codesigning command to get the root certificate from the certificate profile
#>
function Test-GetCodeSigningRootCert {
    $accountName = "acs-test-account"
    $profileName = "acs-test-account-ci"
    $endPointUrl = "https://scus.codesigning.azure.net/"
    $destination = "C:\temp"

    try {
        # Test Get CodeSigning Root Cert
        $cert = Get-AzCodeSigningRootCert -AccountName $accountName -ProfileName $profileName -EndpointUrl $endPointUrl -Destination $destination
        Assert-NotNullOrEmpty $cert
    }

    finally {

    }
}

<#
.SYNOPSIS
Test codesigning command to get the certificate chain from the certificate profile
#>
function Test-GetCodeSigningCertChain {
    $accountName = "acs-test-account"
    $profileName = "acs-test-account-ci"
    $endPointUrl = "https://scus.codesigning.azure.net/"
    $destination = "C:\temp"

    try {
        # Test Get CodeSigning Certificate Chain
        $chain = Get-AzCodeSigningCertChain -AccountName $accountName -ProfileName $profileName -EndpointUrl $endPointUrl -Destination $destination
        Assert-NotNullOrEmpty $chain
    }

    finally {

    }
}