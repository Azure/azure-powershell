
# ----------------------------------------------------------------------------------
# Copyright (c) Microsoft Corporation. All rights reserved.
# Licensed under the Apache License, Version 2.0 (the "License");
# you may not use this file except in compliance with the License.
# You may obtain a copy of the License at
# http://www.apache.org/licenses/LICENSE-2.0
# Unless required by applicable law or agreed to in writing, software
# distributed under the License is distributed on an "AS IS" BASIS,
# WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
# See the License for the specific language governing permissions and
# limitations under the License.
# Code generated by Microsoft (R) AutoRest Code Generator.Changes may cause incorrect behavior and will be lost if the code
# is regenerated.
# ----------------------------------------------------------------------------------

<#
.Synopsis
Create an in-memory object for ServiceDataFlowTemplate.
.Description
Create an in-memory object for ServiceDataFlowTemplate.

.Outputs
Microsoft.Azure.PowerShell.Cmdlets.MobileNetwork.Models.ServiceDataFlowTemplate
.Link
https://learn.microsoft.com/powershell/module/Az.MobileNetwork/new-azmobilenetworkservicedataflowtemplateobject
#>
function New-AzMobileNetworkServiceDataFlowTemplateObject {
    [Microsoft.Azure.PowerShell.Cmdlets.MobileNetwork.ModelCmdletAttribute()]
    [OutputType('Microsoft.Azure.PowerShell.Cmdlets.MobileNetwork.Models.ServiceDataFlowTemplate')]
    [CmdletBinding(PositionalBinding=$false)]
    Param(

        [Parameter(Mandatory, HelpMessage="The direction of this flow.")]
        [Microsoft.Azure.PowerShell.Cmdlets.MobileNetwork.PSArgumentCompleterAttribute("Uplink", "Downlink", "Bidirectional")]
        [string]
        $Direction,
        [Parameter(HelpMessage="The port(s) to which UEs will connect for this flow. You can specify zero or more ports or port ranges. If you specify one or more ports or port ranges then you must specify a value other than `ip` in the `protocol` field. This is an optional setting. If you do not specify it then connections will be allowed on all ports. Port ranges must be specified as <FirstPort>-<LastPort>. For example: [`8080`, `8082-8085`].")]
        [string[]]
        $Port,
        [Parameter(Mandatory, HelpMessage="A list of the allowed protocol(s) for this flow. If you want this flow to be able to use any protocol within the internet protocol suite, use the value `ip`. If you only want to allow a selection of protocols, you must use the corresponding IANA Assigned Internet Protocol Number for each protocol, as described in https://www.iana.org/assignments/protocol-numbers/protocol-numbers.xhtml. For example, for UDP, you must use 17. If you use the value `ip` then you must leave the field `port` unspecified.")]
        [string[]]
        $Protocol,
        [Parameter(Mandatory, HelpMessage="The remote IP address(es) to which UEs will connect for this flow. If you want to allow connections on any IP address, use the value 'any'. Otherwise, you must provide each of the remote IP addresses to which the packet core instance will connect for this flow. You must provide each IP address in CIDR notation, including the netmask (for example, 192.0.2.54/24).")]
        [string[]]
        $RemoteIPList,
        [Parameter(Mandatory, HelpMessage="The name of the data flow template. This must be unique within the parent data flow policy rule. You must not use any of the following reserved strings - 'default', 'requested' or 'service'.")]
        [string]
        $TemplateName
    )

    process {
        $Object = [Microsoft.Azure.PowerShell.Cmdlets.MobileNetwork.Models.ServiceDataFlowTemplate]::New()

        if ($PSBoundParameters.ContainsKey('Direction')) {
            $Object.Direction = $Direction
        }
        if ($PSBoundParameters.ContainsKey('Port')) {
            $Object.Port = $Port
        }
        if ($PSBoundParameters.ContainsKey('Protocol')) {
            $Object.Protocol = $Protocol
        }
        if ($PSBoundParameters.ContainsKey('RemoteIPList')) {
            $Object.RemoteIPList = $RemoteIPList
        }
        if ($PSBoundParameters.ContainsKey('TemplateName')) {
            $Object.TemplateName = $TemplateName
        }
        return $Object
    }
}

