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
    Create a in-memory object for AddonSrmProperties
    .Description
    Create a in-memory object for AddonSrmProperties

    .Outputs
    Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.AddonSrmProperties
    .Link
    https://learn.microsoft.com/powershell/module/az.VMware/new-AzVMwareAddonSrmPropertiesObject
    #>
    function New-AzVMwareAddonSrmPropertiesObject {
        [OutputType('Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.AddonSrmProperties')]
        [CmdletBinding(PositionalBinding=$false)]
        Param(
    
            [Parameter(Mandatory, HelpMessage="The Site Recovery Manager (SRM) license.")]
            [string]
            $LicenseKey
        )

        process {
            $Object = [Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.AddonSrmProperties]::New()
    
            $Object.LicenseKey = $LicenseKey
            $Object.AddonType = "SRM"
            return $Object
        }
    }
    
