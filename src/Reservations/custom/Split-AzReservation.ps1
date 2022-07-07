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
Split a Reservation order.
.Description
Split a Reservation order.
#>
function Split-AzReservation {
    [OutputType([Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.IReservationResponse])]
    [CmdletBinding(PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
    param(
        [Parameter(Mandatory, HelpMessage='Reservation Order Id.')]
        [ValidateNotNull()]
        [Alias('ReservationOrderId')]
        [Microsoft.Azure.PowerShell.Cmdlets.Reservations.Category('Body')]
        [System.String]
        # Reservation Order Id.
        ${OrderId},
    
        [Parameter(Mandatory, HelpMessage='Reservation Id.')]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.Reservations.Category('Body')]
        [System.String]
        # Reservation Id.
        ${ReservationId},

        [Parameter(Mandatory, HelpMessage='Quantity.')]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.Reservations.Category('Body')]
        [int[]]
        # Quantity.
        ${Quantity},

         [Parameter()]
        [Alias('AzureRMContext', 'AzureCredential')]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.Reservations.Category('Azure')]
        [System.Management.Automation.PSObject]
        # The credentials, account, tenant, and subscription used for communication with Azure.
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
            if (-not $PSBoundParameters.ContainsKey('ReservationId')) {
                $CommonPSBoundParameters['HttpPipelineAppend'] = $HttpPipelineAppend
            }
            if (-not [guid]::TryParse($PSBoundParameters['ReservationId'], $([ref][guid]::Empty))) {
                throw "Should supply a Reservation Id(GUID)"
            }
            
            $PSBoundParameters['ReservationId'] = '/providers/Microsoft.Capacity/reservationOrders/' + $PSBoundParameters['OrderId'] + '/reservations/' + $PSBoundParameters['ReservationId']
            Az.Reservations.internal\Split-AzReservation @PSBoundParameters
          } catch {
              throw
          }
    }
}
