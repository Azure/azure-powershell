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
Create node profile.
.Description
Create node profile.
.Example
NA
.Outputs

.Link
#>
function New-AzHdInsightOnAksSecretReference{
    [OutputType([Microsoft.Azure.PowerShell.Cmdlets.HdInsightOnAks.Models.Api20230601Preview.ISecretReference])]
    [CmdletBinding(DefaultParameterSetName='Create', PositionalBinding=$false)]
    param(
        [Parameter(ParameterSetName='Create', Mandatory)]
        [System.String]
        # The secret name in the key vault.
        ${SecretName},

        [Parameter(ParameterSetName='Create', Mandatory)]
        [System.String]
        # The reference name of the secret to be used in service configs.
        ${ReferenceName},
        
        [Parameter(ParameterSetName='Create')]
        [System.String]
        # The version of the secret in key vault.
        ${Version}
    )
    process{

        try{

            $SecretReference=New-Object Microsoft.Azure.PowerShell.Cmdlets.HdInsightOnAks.Models.Api20230601Preview.SecretReference -Property `
                                            @{KeyVaultObjectName=$SecretName;
                                              ReferenceName=$ReferenceName;
                                              Type="Secret";
                                              Version=$Version}
            return $SecretReference
        }
        catch{
            throw
        }
    }
}