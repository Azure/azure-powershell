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
.Synopsis
Create a reference to provide a secret to store the password for accessing the database.
.Description
Create a reference to provide a secret to store the password for accessing the database.
$keyVaultResourceId="/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/{your resource group name}/providers/Microsoft.KeyVault/vaults/{your vault name}";
$secretName="{your secret name}"
$referenceName="{your secret reference name}";

$secretReference=New-AzHdInsightOnAksSecretReferenceObject -SecretName $secretName -ReferenceName $referenceName
NA
.Outputs
Microsoft.Azure.PowerShell.Cmdlets.HdInsightOnAks.Models.ISecretReference
.Link
https://learn.microsoft.com/powershell/module/az.hdinsightonaks/New-AzHdInsightOnAksSecretReferenceObject
#>
function New-AzHdInsightOnAksSecretReferenceObject {
    [OutputType([Microsoft.Azure.PowerShell.Cmdlets.HdInsightOnAks.Models.ISecretReference])]
    [CmdletBinding(DefaultParameterSetName = 'Create', PositionalBinding = $false)]
    param(
        [Parameter(ParameterSetName = 'Create', Mandatory)]
        [System.String]
        # The secret name in the key vault.
        ${SecretName},

        [Parameter(ParameterSetName = 'Create', Mandatory)]
        [System.String]
        # The reference name of the secret to be used in service configs.
        ${ReferenceName},
        
        [Parameter(ParameterSetName = 'Create')]
        [System.String]
        # The version of the secret in key vault.
        ${Version}
    )
    process {
        try {
            $SecretReference = New-Object Microsoft.Azure.PowerShell.Cmdlets.HdInsightOnAks.Models.SecretReference -Property `
            @{KeyVaultObjectName = $SecretName;
                ReferenceName    = $ReferenceName;
                Type             = "Secret";
                Version          = $Version
            }
            return $SecretReference
        }
        catch {
            throw
        }
    }
}