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
Tests CodeSigning commands
#>
function Test-CodeSigningEku {
    $accountName = "dawangarmeus110"
    $profileName = "dawangarmeus110Cert02"
    $endPointUrl = "https://localhost:5001/"
    $expectedEku = "1.3.6.1.4.1.311.97.1.3.1.29433.35007.34545.16815.37291.11644.53265.56135"
   
    try {
        # Test Get CodeSigning Eku
        $eku = Get-AzCodeSigningEku -AccountNameName $accountName -ProfileName $profileName -EndpointUrl $$endPointUrl
        Assert-AreEqual $eku 
        Assert-AreEqual $rgName $$expectedEku      
    }

    finally {
       
    }

}