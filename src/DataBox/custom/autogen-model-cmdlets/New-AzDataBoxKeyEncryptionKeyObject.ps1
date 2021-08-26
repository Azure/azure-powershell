
    # ----------------------------------------------------------------------------------
    #
    # Copyright Microsoft Corporation
    # Licensed under the Apache License, Version 2.0 (the \"License\");
    # you may not use this file except in compliance with the License.
    # You may obtain a copy of the License at
    # http://www.apache.org/licenses/LICENSE-2.0
    # Unless required by applicable law or agreed to in writing, software
    # distributed under the License is distributed on an \"AS IS\" BASIS,
    # WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
    # See the License for the specific language governing permissions and
    # limitations under the License.
    # ----------------------------------------------------------------------------------

    <#
    .Synopsis
    Create a in-memory object for KeyEncryptionKey
    .Description
    Create a in-memory object for KeyEncryptionKey

    .Outputs
    Microsoft.Azure.PowerShell.Cmdlets.DataBox.Models.Api20210301.KeyEncryptionKey
    .Link
    https://docs.microsoft.com/powershell/module/az.DataBox/new-AzDataBoxKeyEncryptionKeyObject
    #>
    function New-AzDataBoxKeyEncryptionKeyObject {
        [OutputType('Microsoft.Azure.PowerShell.Cmdlets.DataBox.Models.Api20210301.KeyEncryptionKey')]
        [CmdletBinding(PositionalBinding=$false)]
        Param(
    
            [Parameter(HelpMessage="Managed identity properties used for key encryption.")]
            [Microsoft.Azure.PowerShell.Cmdlets.DataBox.Models.Api20210301.IIdentityProperties]
            $IdentityProperty,
            [Parameter(Mandatory, HelpMessage="Type of encryption key used for key encryption.")]
            [Microsoft.Azure.PowerShell.Cmdlets.DataBox.Support.KekType]
            $KekType,
            [Parameter(HelpMessage="Key encryption key. It is required in case of Customer managed KekType.")]
            [string]
            $KekUrl,
            [Parameter(HelpMessage="Kek vault resource id. It is required in case of Customer managed KekType.")]
            [string]
            $KekVaultResourceId
        )

        process {
            $Object = [Microsoft.Azure.PowerShell.Cmdlets.DataBox.Models.Api20210301.KeyEncryptionKey]::New()
    
            $Object.IdentityProperty = $IdentityProperty
            $Object.KekType = $KekType
            $Object.KekUrl = $KekUrl
            $Object.KekVaultResourceId = $KekVaultResourceId
            return $Object
        }
    }
    
