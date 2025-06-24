# ----------------------------------------------------------------------------------
#
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
# ----------------------------------------------------------------------------------

<#
.Synopsis
Return a reservation and get refund information.
.Description
Return a reservation and get refund information.

.Inputs
Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.IReservationsIdentity
.Outputs
Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.IReservationOrderResponse
.Notes
COMPLEX PARAMETER PROPERTIES
To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

INPUTOBJECT <IReservationsIdentity>: Identity Parameter
  [Id <String>]: Resource identity path
  [ReservationId <String>]: Id of the reservation item
  [ReservationOrderId <String>]: Order Id of the reservation
  [SubscriptionId <String>]: Id of the subscription
.Link
https://learn.microsoft.com/powershell/module/az.reservations/invoke-azreservationreturn
#>
function Invoke-AzReservationReturn {
    [OutputType([Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.IReservationOrderResponse])]
    [CmdletBinding(DefaultParameterSetName='PostExpanded', PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
    param(
        [Parameter(ParameterSetName='PostExpanded', Mandatory)]
        [Parameter(ParameterSetName='PostViaJsonFilePath', Mandatory)]
        [Parameter(ParameterSetName='PostViaJsonString', Mandatory)]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.Reservations.Category('Path')]
        [System.String]
        # Order Id of the reservation
        ${ReservationOrderId},

        [Parameter(ParameterSetName='PostViaIdentityExpanded', Mandatory, ValueFromPipeline)]
        [Microsoft.Azure.PowerShell.Cmdlets.Reservations.Category('Path')]
        [Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.IReservationsIdentity]
        # Identity Parameter
        ${InputObject},

        [Parameter(ParameterSetName='PostExpanded', Mandatory)]
        [Parameter(ParameterSetName='PostViaIdentityExpanded', Mandatory)]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.Reservations.Category('Body')]
        [System.Int32]
        # Quantity to be returned.
        # Must be greater than zero.
        ${ReservationToReturnQuantity},
    
        [Parameter(ParameterSetName='PostExpanded', Mandatory)]
        [Parameter(ParameterSetName='PostViaIdentityExpanded', Mandatory)]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.Reservations.Category('Body')]
        [System.String]
        # Fully qualified identifier of the reservation being returned
        ${ReservationToReturnReservationId},

        [Parameter(ParameterSetName='PostExpanded', Mandatory)]
        [Parameter(ParameterSetName='PostViaIdentityExpanded', Mandatory)]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.Reservations.Category('Body')]
        [System.String]
        # The reason of returning the reservation
        ${ReturnReason},

        [Parameter(ParameterSetName='PostExpanded', Mandatory)]
        [Parameter(ParameterSetName='PostViaIdentityExpanded', Mandatory)]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.Reservations.Category('Body')]
        [System.String]
        # The scope of this return, e.g. Reservation.
        ${Scope},

        [Parameter(ParameterSetName='PostExpanded', Mandatory)]
        [Parameter(ParameterSetName='PostViaIdentityExpanded', Mandatory)]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.Reservations.Category('Body')]
        [System.String]
        # The session id obtained from Invoke-AzReservationCalculateRefund..
        ${SessionId},

        [Parameter(ParameterSetName='PostViaJsonFilePath', Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.Reservations.Category('Body')]
        [System.String]
        # Path of Json file supplied to the Post operation
        ${JsonFilePath},
    
        [Parameter(ParameterSetName='PostViaJsonString', Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.Reservations.Category('Body')]
        [System.String]
        # Json string supplied to the Post operation
        ${JsonString},
        [Parameter(DontShow)]
        [Alias('AzureRMContext', 'AzureCredential')]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.Reservations.Category('Azure')]
        [System.Management.Automation.PSObject]
        # The DefaultProfile parameter is not functional.
        # Use the SubscriptionId parameter when available if executing the cmdlet against a different subscription.
        ${DefaultProfile},
    
        [Parameter(DontShow)]
        [Microsoft.Azure.PowerShell.Cmdlets.Reservations.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        # Wait for .NET debugger to attach
        ${Break},
    
        [Parameter(DontShow)]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.Reservations.Category('Runtime')]
        [Microsoft.Azure.PowerShell.Cmdlets.Reservations.Runtime.SendAsyncStep[]]
        # SendAsync Pipeline Steps to be appended to the front of the pipeline
        ${HttpPipelineAppend},
    
        [Parameter(DontShow)]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.Reservations.Category('Runtime')]
        [Microsoft.Azure.PowerShell.Cmdlets.Reservations.Runtime.SendAsyncStep[]]
        # SendAsync Pipeline Steps to be prepended to the front of the pipeline
        ${HttpPipelinePrepend},
    
        [Parameter(DontShow)]
        [Microsoft.Azure.PowerShell.Cmdlets.Reservations.Category('Runtime')]
        [System.Uri]
        # The URI for the proxy server to use
        ${Proxy},
    
        [Parameter(DontShow)]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.Reservations.Category('Runtime')]
        [System.Management.Automation.PSCredential]
        # Credentials for a proxy server to use for the remote call
        ${ProxyCredential},
    
        [Parameter(DontShow)]
        [Microsoft.Azure.PowerShell.Cmdlets.Reservations.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        # Use the default credentials for the proxy
        ${ProxyUseDefaultCredentials}
    )
    
    process {
        try {
            $PSBoundParameters['AsJob'] = $true
            $response = Az.Reservations.internal\Invoke-AzReservationReturn @PSBoundParameters

            # Remove extra parameters for Get-AzReservationOrder
            $null = $PSBoundParameters.Remove('JsonString')
            $null = $PSBoundParameters.Remove('JsonFilePath')
            $null = $PSBoundParameters.Remove('ReservationToReturnReservationId')
            $null = $PSBoundParameters.Remove('ReservationToReturnQuantity')
            $null = $PSBoundParameters.Remove('SessionId')
            $null = $PSBoundParameters.Remove('Scope')
            $null = $PSBoundParameters.Remove('ReturnReason')
            $null = $PSBoundParameters.Remove('AsJob')

            return Get-AzReservationOrder @PSBoundParameters
        } catch {
            throw
        }
    }
}