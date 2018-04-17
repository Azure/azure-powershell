<#
Copyright (c) Microsoft Corporation. All rights reserved.
Licensed under the MIT License. See License.txt in the project root for license information.
#>

<#
.SYNOPSIS
    Get the list of public offers.

.DESCRIPTION
    Get the list of public offers.

.PARAMETER Skip
    Skip the first N items as specified by the parameter value.

.PARAMETER Top
    Return the top N items as specified by the parameter value. Applies after the -Skip parameter.

.EXAMPLE

    PS C:\> Get-AzsOffer | fl

    Get the list of public offers.

#>
function Get-AzsOffer {
    [OutputType([Microsoft.AzureStack.Management.Subscriptions.Models.Offer])]
    [CmdletBinding()]
    param(
        [Parameter(Mandatory = $false)]
        [int]
        $Skip = -1,

        [Parameter(Mandatory = $false)]
        [int]
        $Top = -1,

        [Parameter(Mandatory = $false)]
        [string]
        $Provider
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

        if ($PSBoundParameters.ContainsKey('Provider')) {
            Write-Warning -Message "The parameter Provider will be deprecated in a future release. This parameter is not used anymore. Please use Get-AzsDelegatedProviderOffer cmdlet to get Provider specific offers"
        }
    
        $NewServiceClient_params = @{
            FullClientTypeName = 'Microsoft.AzureStack.Management.Subscriptions.SubscriptionsManagementClient'
        }

        $GlobalParameterHashtable = @{}
        $NewServiceClient_params['GlobalParameterHashtable'] = $GlobalParameterHashtable

        $SubscriptionsManagementClient = New-ServiceClient @NewServiceClient_params

        Write-Verbose -Message 'Performing operation ListWithHttpMessagesAsync on $SubscriptionsManagementClient.'
        $TaskResult = $SubscriptionsManagementClient.Offers.ListWithHttpMessagesAsync()

        if ($TaskResult) {
            $GetTaskResult_params = @{
                TaskResult = $TaskResult
            }

            $TopInfo = @{
                'Count' = 0
                'Max'   = $Top
            }
            $GetTaskResult_params['TopInfo'] = $TopInfo
            $SkipInfo = @{
                'Count' = 0
                'Max'   = $Skip
            }
            $GetTaskResult_params['SkipInfo'] = $SkipInfo
            $PageResult = @{
                'Result' = $null
            }
            $GetTaskResult_params['PageResult'] = $PageResult
            $GetTaskResult_params['PageType'] = 'Microsoft.Rest.Azure.IPage[Microsoft.AzureStack.Management.Subscriptions.Models.Offer]' -as [Type]
            Get-TaskResult @GetTaskResult_params

            Write-Verbose -Message 'Flattening paged results.'
            while ($PageResult -and $PageResult.Result -and (Get-Member -InputObject $PageResult.Result -Name 'nextLink') -and $PageResult.Result.'nextLink' -and (($TopInfo -eq $null) -or ($TopInfo.Max -eq -1) -or ($TopInfo.Count -lt $TopInfo.Max))) {
                $PageResult.Result = $null
                Write-Debug -Message "Retrieving next page: $($PageResult.Result.'nextLink')"
                $TaskResult = $SubscriptionsManagementClient.Offers.ListNextWithHttpMessagesAsync($PageResult.Result.'nextLink')
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

