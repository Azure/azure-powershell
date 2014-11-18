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

Function to get user name and password for a variety of different account types
#>

function Get-UserCredentials ([string] $userType) 
{
    # Force load of testing assembly to get connection string parser
    [System.Reflection.Assembly]::Load("Microsoft.WindowsAzure.Testing")

    function get-from-environment ($varName) {
        if (-not (test-path "Env:\$varName")) {
            throw "Required environment variable $varName is not set"
        }
        (get-childitem "Env:\$varName").Value
    }

    function credential-from-username-password ($user, $password) 
    {
        $ss = ConvertTo-SecureString -String $password -AsPlainText -Force
        New-Object -TypeName System.Management.Automation.PSCredential -ArgumentList $user, $ss
    }

    function fields-from-connection-string ([string] $cs) 
    {
        [Microsoft.WindowsAzure.Testing.TestEnvironmentFactory]::ParseConnectionString($cs)
    }

    function credential-from-fields ($fields) 
    {
        $user = $fields[[Microsoft.WindowsAzure.Testing.ConnectionStringFields]::UserId]
        $password = $fields[[Microsoft.WindowsAzure.Testing.ConnectionStringFields]::Password]
        credential-from-username-password $user $password
    }

    function environment-from-fields ($fields) 
    {
        $baseUri = $fields[[Microsoft.WindowsAzure.Testing.ConnectionStringFields]::BaseUri]
        if (($baseUri -eq $null) -or ($baseUri -eq "")) {
            "AzureCloud"
        } else {
            $envs = (Get-AzureEnvironment | ? { $_.ServiceManagement -eq $baseUri })
            if ($envs.Length -eq 1) {
                $envs[0].Name
            } else {
                throw "Could not find environment matching $baseUri"
            }
        }
    }

    function account-info-from-connection-string ([string] $cs) 
    {
        $fields = fields-from-connection-string $cs
        @{
            UserId = $fields[[Microsoft.WindowsAzure.Testing.ConnectionStringFields]::UserId];
            Credential = (credential-from-fields $fields);
            Environment = (environment-from-fields $fields);
            ExpectedSubscription = $fields[[Microsoft.WindowsAzure.Testing.ConnectionStringFields]::SubscriptionId];
            TenantId = $fields[[Microsoft.WindowsAzure.Testing.ConnectionStringFields]::AADTenant]
        }
    }

    function account-info-from-environment-var ([string] $envvar) {
        $cs = get-from-environment $envvar
        account-info-from-connection-string $cs
    }

    $typeHandlers = @{
        OrgIdOneTenantOneSubscription = { account-info-from-environment-var AZURE_ORGID_ONE_TENANT_ONE_SUBSCRIPTION };
        OrgIdForeignPrincipal = { account-info-from-environment-var AZURE_ORGID_FPO };
        MicrosoftId = { account-info-from-environment-var AZURE_LIVEID };
        ServicePrincipal = { account-info-from-environment-var AZURE_SERVICE_PRINCIPAL }
    }

    $handler = $typeHandlers[$userType]
    if ($handler -ne $Null) {
        & $handler
    } else {
        throw "Unknown credential type $userType"
    }
}
