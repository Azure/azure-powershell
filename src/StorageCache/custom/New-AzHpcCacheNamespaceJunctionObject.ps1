
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
Create a in-memory object for NamespaceJunction
.Description
Create a in-memory object for NamespaceJunction

.Outputs
Microsoft.Azure.PowerShell.Cmdlets.HpcCache.Models.Api20210301.NamespaceJunction
.Link
https://docs.microsoft.com/powershell/module//az.HpcCache/new-AzHpcCacheNamespaceJunctionObject
#>
function New-AzHpcCacheNamespaceJunctionObject {
    [OutputType('Microsoft.Azure.PowerShell.Cmdlets.HpcCache.Models.Api20210301.NamespaceJunction')]
    [CmdletBinding(PositionalBinding=$false)]
    Param(

        [Parameter(HelpMessage="Namespace path on a Cache for a Storage Target.")]
        [string]
        $NamespacePath,
        [Parameter(HelpMessage="Name of the access policy applied to this junction.")]
        [string]
        $NfsAccessPolicyName,
        [Parameter(HelpMessage="NFS export where targetPath exists.")]
        [string]
        $NfsExport,
        [Parameter(HelpMessage="Path in Storage Target to which namespacePath points.")]
        [string]
        $TargetPath
    )

    process {
        $Object = [Microsoft.Azure.PowerShell.Cmdlets.HpcCache.Models.Api20210301.NamespaceJunction]::New()

        $Object.NamespacePath = $NamespacePath
        $Object.NfsAccessPolicy = $NfsAccessPolicyName
        $Object.NfsExport = $NfsExport
        $Object.TargetPath = $TargetPath
        return $Object
    }
}

