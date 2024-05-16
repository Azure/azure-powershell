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
    Create a in-memory object for AddonVrProperties
    .Description
    Create a in-memory object for AddonVrProperties

    .Outputs
    Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.AddonVrProperties
    .Link
    https://learn.microsoft.com/powershell/module/az.VMware/new-AzVMwareAddonVrPropertiesObject
    #>
    function New-AzVMwareAddonVrPropertiesObject {
        [OutputType('Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.AddonVrProperties')]
        [CmdletBinding(PositionalBinding=$false)]
        Param(
    
            [Parameter(Mandatory, HelpMessage="The vSphere Replication Server (VRS) count.")]
            [int]
            $VrsCount
        )

        process {
            $Object = [Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.AddonVrProperties]::New()
    
            $Object.VrsCount = $VrsCount
            $Object.AddonType = "VR"
            return $Object
        }
    }
    
