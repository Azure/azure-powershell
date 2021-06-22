
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
    Create a in-memory object for Acl
    .Description
    Create a in-memory object for Acl

    .Outputs
    Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Models.Api20210401Preview.Acl
    .Link
    https://docs.microsoft.com/powershell/module/az.DiskPool/new-AzDiskPoolAclObject
    #>
    function New-AzDiskPoolAclObject {
        [OutputType('Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Models.Api20210401Preview.Acl')]
        [CmdletBinding(PositionalBinding=$false)]
        Param(
    
            [Parameter(Mandatory, HelpMessage="iSCSI initiator IQN (iSCSI Qualified Name); example: `"iqn.2005-03.org.iscsi:client`".")]
            [string]
            $InitiatorIqn,
            [Parameter(Mandatory, HelpMessage="List of LUN names mapped to the ACL.")]
            [string[]]
            $MappedLun
        )

        process {
            $Object = [Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Models.Api20210401Preview.Acl]::New()
    
            $Object.InitiatorIqn = $InitiatorIqn
            $Object.MappedLun = $MappedLun
            return $Object
        }
    }
    
