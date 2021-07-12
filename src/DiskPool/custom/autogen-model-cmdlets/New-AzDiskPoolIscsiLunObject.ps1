
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
    Create a in-memory object for IscsiLun
    .Description
    Create a in-memory object for IscsiLun

    .Outputs
    Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Models.Api20210401Preview.IscsiLun
    .Link
    https://docs.microsoft.com/powershell/module/az.DiskPool/new-AzDiskPoolIscsiLunObject
    #>
    function New-AzDiskPoolIscsiLunObject {
        [OutputType('Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Models.Api20210401Preview.IscsiLun')]
        [CmdletBinding(PositionalBinding=$false)]
        Param(
    
            [Parameter(Mandatory, HelpMessage="Azure Resource ID of the Managed Disk.")]
            [string]
            $ManagedDiskAzureResourceId,
            [Parameter(Mandatory, HelpMessage="User defined name for iSCSI LUN; example: `"lun0`".")]
            [string]
            $Name
        )

        process {
            $Object = [Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Models.Api20210401Preview.IscsiLun]::New()
    
            $Object.ManagedDiskAzureResourceId = $ManagedDiskAzureResourceId
            $Object.Name = $Name
            return $Object
        }
    }
    
