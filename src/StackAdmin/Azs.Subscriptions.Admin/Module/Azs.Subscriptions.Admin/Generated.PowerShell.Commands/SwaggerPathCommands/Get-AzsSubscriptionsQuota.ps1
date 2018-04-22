<#
Copyright (c) Microsoft Corporation. All rights reserved.
Licensed under the MIT License. See License.txt in the project root for license information.
#>

<#
.SYNOPSIS
     Get the list of subscription resource provider quotas at a location.

.DESCRIPTION
    Get the list of quotas at a location.

.PARAMETER ResourceId
    The resource id.

.PARAMETER Name
    Name of the quota.

.PARAMETER Location
    The AzureStack location.

.EXAMPLE

    PS C:\Windows\system32> Get-AzsSubscriptionsQuota

    Get the list of subscription resource provider quotas at a location.

#>
function Get-AzsSubscriptionsQuota {
    [OutputType([Microsoft.AzureStack.Management.Subscriptions.Admin.Models.Quota])]
    [CmdletBinding(DefaultParameterSetName = 'List')]
    param(
        [Parameter(Mandatory = $true, ParameterSetName = 'Get')]
        [ValidateNotNullOrEmpty()]
        [System.String]
        $Name,

        [Parameter(Mandatory = $false, ParameterSetName = 'Get')]
        [Parameter(Mandatory = $false, ParameterSetName = 'List')]
        [Alias("ArmLocation")]
        [System.String]
        $Location,

        [Parameter(Mandatory = $true, ValueFromPipelineByPropertyName = $true, ParameterSetName = 'ResourceId')]
        [ValidateNotNullOrEmpty()]
        [System.String]
        $ResourceId
    )

    Begin {
        Initialize-PSSwaggerDependencies -Azure
        $tracerObject = $null
        if (('continue' -eq $DebugPreference) -or ('inquire' -eq $DebugPreference)) {
            $oldDebugPreference = $global:DebugPreference
            $global:DebugPreference = "continue"
            $tracerObject = New-PSSwaggerClientTracing
            Register-PSSwaggerClientTracing -TracerObject $tracerObject
        }
    }

    Process {

        $ErrorActionPreference = 'Stop'

        if ($PSBoundParameters.ContainsKey('Location')) {
            if( $MyInvocation.Line -match "\s-ArmLocation\s")
            {
                Write-Warning -Message "The parameter alias ArmLocation will be deprecated in future release. Please use the parameter Location instead"
            }
        }

        $NewServiceClient_params = @{
            FullClientTypeName = 'Microsoft.AzureStack.Management.Subscriptions.Admin.SubscriptionsAdminClient'
        }

        $GlobalParameterHashtable = @{}
        $NewServiceClient_params['GlobalParameterHashtable'] = $GlobalParameterHashtable

        $GlobalParameterHashtable['SubscriptionId'] = $null
        if ($PSBoundParameters.ContainsKey('SubscriptionId')) {
            $GlobalParameterHashtable['SubscriptionId'] = $PSBoundParameters['SubscriptionId']
        }

        $SubscriptionsAdminClient = New-ServiceClient @NewServiceClient_params

        $Quota = $Name


        if ( 'ResourceId' -eq $PsCmdlet.ParameterSetName) {
            $GetArmResourceIdParameterValue_params = @{
                IdTemplate = '/subscriptions/{subscriptionId}/providers/Microsoft.Subscriptions.Admin/locations/{location}/quotas/{quota}'
            }
            $GetArmResourceIdParameterValue_params['Id'] = $ResourceId
            $ArmResourceIdParameterValues = Get-ArmResourceIdParameterValue @GetArmResourceIdParameterValue_params
            $location = $ArmResourceIdParameterValues['location']

            $quota = $ArmResourceIdParameterValues['quota']
        } elseif ([System.String]::IsNullOrEmpty($Location)) {
            $Location = (Get-AzureRMLocation).Location
        }


        if ('List' -eq $PsCmdlet.ParameterSetName) {
            Write-Verbose -Message 'Performing operation ListWithHttpMessagesAsync on $SubscriptionsAdminClient.'
            $TaskResult = $SubscriptionsAdminClient.Quotas.ListWithHttpMessagesAsync($Location)
        } elseif ('Get' -eq $PsCmdlet.ParameterSetName -or 'ResourceId' -eq $PsCmdlet.ParameterSetName) {
            Write-Verbose -Message 'Performing operation GetWithHttpMessagesAsync on $SubscriptionsAdminClient.'
            $TaskResult = $SubscriptionsAdminClient.Quotas.GetWithHttpMessagesAsync($Location, $Quota)
        } else {
            Write-Verbose -Message 'Failed to map parameter set to operation method.'
            throw 'Module failed to find operation to execute.'
        }

        if ($TaskResult) {
            $GetTaskResult_params = @{
                TaskResult = $TaskResult
            }

            Get-TaskResult @GetTaskResult_params

        }
    }

    End {
        if ($tracerObject) {
            $global:DebugPreference = $oldDebugPreference
            Unregister-PSSwaggerClientTracing -TracerObject $tracerObject
        }
    }
}

