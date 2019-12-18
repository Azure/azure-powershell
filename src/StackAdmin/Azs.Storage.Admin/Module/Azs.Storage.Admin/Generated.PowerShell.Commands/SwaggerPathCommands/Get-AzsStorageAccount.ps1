<#
Copyright (c) Microsoft Corporation. All rights reserved.
Licensed under the MIT License. See License.txt in the project root for license information.
#>

<#
.SYNOPSIS
    

.DESCRIPTION
    Returns a list of storage accounts.

.PARAMETER Summary
    Switch for wheter summary or detailed information is returned.

.PARAMETER Filter
    Filter string

.PARAMETER InputObject
    The input object of type Microsoft.AzureStack.Management.Storage.Admin.Models.StorageAccount.

.PARAMETER ResourceId
    The resource id.

.PARAMETER Location
    Resource location.

.PARAMETER Name
    Internal storage account ID, which is not visible to tenant.

.EXAMPLE

	PS C:\> Get-AzsStorageAccount 

	Get a list of storage accounts.

.EXAMPLE

    PS C:\> Get-AzsStorageAccount -Name f8f7ff7335cb4ba284fb855547e48f34 -Summary

    Get details of the specified storage account.

#>
function Get-AzsStorageAccount {
    [OutputType([Microsoft.AzureStack.Management.Storage.Admin.Models.StorageAccount])]
    [CmdletBinding(DefaultParameterSetName = 'List')]
    param(    
        [Parameter(Mandatory = $false, ParameterSetName = 'List')]
        [switch]
        $Summary,
    
        [Parameter(Mandatory = $false, ParameterSetName = 'List')]
        [System.String]
        $Filter,
    
        [Parameter(Mandatory = $true, ValueFromPipeline = $true, ParameterSetName = 'InputObject')]
        [Microsoft.AzureStack.Management.Storage.Admin.Models.StorageAccount]
        $InputObject,
    
        [Parameter(Mandatory = $true, ValueFromPipelineByPropertyName = $true, ParameterSetName = 'ResourceId')]
        [Alias('id')]
        [System.String]
        $ResourceId,
    
        [Parameter(Mandatory = $false, ParameterSetName = 'Get')]
        [Parameter(Mandatory = $false, ParameterSetName = 'List')]
        [System.String]
        $Location,
    
        [Parameter(Mandatory = $true, ParameterSetName = 'Get')]
        [Alias('AccountId')]
        [System.String]
        $Name
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

        $NewServiceClient_params = @{
            FullClientTypeName = 'Microsoft.AzureStack.Management.Storage.Admin.StorageAdminClient'
        }

        $GlobalParameterHashtable = @{ }
        $NewServiceClient_params['GlobalParameterHashtable'] = $GlobalParameterHashtable
     
        $GlobalParameterHashtable['SubscriptionId'] = $null
        if ($PSBoundParameters.ContainsKey('SubscriptionId')) {
            $GlobalParameterHashtable['SubscriptionId'] = $PSBoundParameters['SubscriptionId']
        }

        $StorageAdminClient = New-ServiceClient @NewServiceClient_params

        $AccountId = $Name

 
        if ('InputObject' -eq $PsCmdlet.ParameterSetName -or 'ResourceId' -eq $PsCmdlet.ParameterSetName) {
            $GetArmResourceIdParameterValue_params = @{
                IdTemplate = '/subscriptions/{subscriptionId}/providers/Microsoft.Storage.Admin/locations/{location}/storageaccounts/{accountId}'
            }

            if ('ResourceId' -eq $PsCmdlet.ParameterSetName) {
                $GetArmResourceIdParameterValue_params['Id'] = $ResourceId
            }
            else {
                $GetArmResourceIdParameterValue_params['Id'] = $InputObject.Id
            }
            $ArmResourceIdParameterValues = Get-ArmResourceIdParameterValue @GetArmResourceIdParameterValue_params
            $location = $ArmResourceIdParameterValues['location']

            $accountId = $ArmResourceIdParameterValues['accountId']
        }
        elseif ([System.String]::IsNullOrEmpty($Location)) {
            $Location = (Get-AzureRmLocation).Location
        }

        if ('List' -eq $PsCmdlet.ParameterSetName) {
            Write-Verbose -Message 'Performing operation ListWithHttpMessagesAsync on $StorageAdminClient.'
            $TaskResult = $StorageAdminClient.StorageAccounts.ListWithHttpMessagesAsync($Location, $(if ($PSBoundParameters.ContainsKey('Filter')) { $Filter } else { [NullString]::Value }), $Summary)
        }
        elseif ('Get' -eq $PsCmdlet.ParameterSetName -or 'InputObject' -eq $PsCmdlet.ParameterSetName -or 'ResourceId' -eq $PsCmdlet.ParameterSetName) {
            Write-Verbose -Message 'Performing operation GetWithHttpMessagesAsync on $StorageAdminClient.'
            $TaskResult = $StorageAdminClient.StorageAccounts.GetWithHttpMessagesAsync($Location, $AccountId)
        }
        else {
            Write-Verbose -Message 'Failed to map parameter set to operation method.'
            throw 'Module failed to find operation to execute.'
        }

        if ($TaskResult) {
            $GetTaskResult_params = @{
                TaskResult = $TaskResult
            }

            $PageResult = @{
                'Result' = $null
            }
            $GetTaskResult_params['PageResult'] = $PageResult 
            $GetTaskResult_params['PageType'] = 'Microsoft.Rest.Azure.IPage[Microsoft.AzureStack.Management.Storage.Admin.Models.StorageAccount]' -as [Type]            
            Get-TaskResult @GetTaskResult_params
            
            Write-Verbose -Message 'Flattening paged results.'
            while (('List' -eq $PsCmdlet.ParameterSetName) -and $PageResult -and $PageResult.Page -and (Get-Member -InputObject $PageResult.Page -Name 'NextPageLink') -and $PageResult.Page.'NextPageLink' ) {
                Write-Debug -Message "Retrieving next page: $($PageResult.Page.'NextPageLink')"
                $TaskResult = $StorageAdminClient.StorageAccounts.ListNextWithHttpMessagesAsync($PageResult.Page.'NextPageLink')
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

