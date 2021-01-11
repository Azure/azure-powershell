
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
Create a in-memory object for ReplicaSet
.Description
Create a in-memory object for ReplicaSet

.Outputs
Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.ReplicaSet
.Link
https://docs.microsoft.com/en-us/powershell/module/az.ADDomainServices/new-AzADDomainServiceReplicaSet
#>
function New-AzADDomainServiceReplicaSet {
    [OutputType('Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.ReplicaSet')]
    [CmdletBinding(PositionalBinding=$false)]
    Param(

        [Parameter(HelpMessage="Virtual network location.")]
        [string]
        $Location,
        [Parameter(HelpMessage="The name of the virtual network that Domain Services will be deployed on. The id of the subnet that Domain Services will be deployed on. /virtualNetwork/vnetName/subnets/subnetName.")]
        [string]
        $SubnetId
    )

    process {
        $Object = [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.ReplicaSet]::New()

        $Object.Location = $Location
        $Object.SubnetId = $SubnetId
        return $Object
    }
}

