<#
Copyright (c) Microsoft Corporation. All rights reserved.
Licensed under the MIT License. See License.txt in the project root for license information.
#>

<#
.SYNOPSIS
    Get the list of offers for the specified delegated provider.

.DESCRIPTION
    Get the list of offers for the specified delegated provider.

.PARAMETER OfferName
    Name of the offer.

.PARAMETER Skip
    Skip the first N items as specified by the parameter value.

.PARAMETER Top
    Return the top N items as specified by the parameter value. Applies after the -Skip parameter.

.PARAMETER DelegatedProviderId
    Id of the delegated provider.

.EXAMPLE

    PS C:\> Get-AzsDelegatedProviderOffer -DelegatedProviderId 4b763321-23f5-4a45-a44d-9ccfdd705a3d | fl

    Get the list of offers for the specified delegated provider.
#>
function Get-AzsDelegatedProviderOffer
{
    [OutputType([Microsoft.AzureStack.Management.Subscription.Models.Offer])]
    [CmdletBinding(DefaultParameterSetName='List')]
    param(
        [Parameter(Mandatory = $true, ParameterSetName = 'Get')]
        [ValidateNotNullOrEmpty()]
        [System.String]
        $OfferName,

        [Parameter(Mandatory = $true, ParameterSetName = 'List')]
        [Parameter(Mandatory = $true, ParameterSetName = 'Get')]
        [ValidateNotNullOrEmpty()]
        [System.String]
        $DelegatedProviderId,

        [Parameter(Mandatory = $false, ParameterSetName = 'List')]
        [Parameter(Mandatory = $false, ParameterSetName = 'Get')]
        [int]
        $Skip = -1,

        [Parameter(Mandatory = $false, ParameterSetName = 'List')]
        [Parameter(Mandatory = $false, ParameterSetName = 'Get')]
        [int]
        $Top = -1
    )

    Begin
    {
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

    $NewServiceClient_params = @{
        FullClientTypeName = 'Microsoft.AzureStack.Management.Subscription.SubscriptionClient'
    }

    $GlobalParameterHashtable = @{}
    $NewServiceClient_params['GlobalParameterHashtable'] = $GlobalParameterHashtable

    $SubscriptionClient = New-ServiceClient @NewServiceClient_params


    if ('List' -eq $PsCmdlet.ParameterSetName) {
        Write-Verbose -Message 'Performing operation ListWithHttpMessagesAsync on $SubscriptionClient.'
        $TaskResult = $SubscriptionClient.DelegatedProviderOffers.ListWithHttpMessagesAsync($DelegatedProviderId)
    } elseif ('Get' -eq $PsCmdlet.ParameterSetName) {
        Write-Verbose -Message 'Performing operation GetWithHttpMessagesAsync on $SubscriptionClient.'
        $TaskResult = $SubscriptionClient.DelegatedProviderOffers.GetWithHttpMessagesAsync($DelegatedProviderId, $OfferName)
    } else {
        Write-Verbose -Message 'Failed to map parameter set to operation method.'
        throw 'Module failed to find operation to execute.'
    }

    if ($TaskResult) {
        $GetTaskResult_params = @{
            TaskResult = $TaskResult
        }

        $TopInfo = @{
            'Count' = 0
            'Max' = $Top
        }
        $GetTaskResult_params['TopInfo'] = $TopInfo
        $SkipInfo = @{
            'Count' = 0
            'Max' = $Skip
        }
        $GetTaskResult_params['SkipInfo'] = $SkipInfo
        $PageResult = @{
            'Result' = $null
        }
        $GetTaskResult_params['PageResult'] = $PageResult
        $GetTaskResult_params['PageType'] = 'Array' -as [Type]
        Get-TaskResult @GetTaskResult_params

        Write-Verbose -Message 'Flattening paged results.'
        while ($PageResult -and $PageResult.Page -and (Get-Member -InputObject $PageResult.Page -Name 'nextPageLink') -and $PageResult.Page.'nextPageLink' -and (($TopInfo -eq $null) -or ($TopInfo.Max -eq -1) -or ($TopInfo.Count -lt $TopInfo.Max))) {
            Write-Debug -Message "Retrieving next page: $($PageResult.Page.'nextPageLink')"
            $TaskResult = $SubscriptionClient.DelegatedProviderOffers.ListNextWithHttpMessagesAsync($PageResult.Page.'nextPageLink')
            $PageResult.Page = $null
            $GetTaskResult_params['TaskResult'] = $TaskResult
            $GetTaskResult_params['PageResult'] = $PageResult
            Get-TaskResult @GetTaskResult_params
        }
    }
    }

    End {
        if ($tracerObject) {
            $global:DebugPreference = $oldDebugPreference
            Unregister-PSSwaggerClientTracing -TracerObject $tracerObject
        }
    }
}

