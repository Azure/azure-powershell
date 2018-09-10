<#
Copyright (c) Microsoft Corporation. All rights reserved.
Licensed under the MIT License. See License.txt in the project root for license information.
#>

<#
.SYNOPSIS


.DESCRIPTION
	Get the list of Operations.

#>
function Get-AzsOperation
{
	[OutputType([Microsoft.AzureStack.Management.Subscriptions.Admin.Models.Operation])]
	[CmdletBinding(DefaultParameterSetName='Operations_List')]
	param(
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



	$NewServiceClient_params = @{
		FullClientTypeName = 'Microsoft.AzureStack.Management.Subscriptions.Admin.SubscriptionsAdminClient'
	}

	$GlobalParameterHashtable = @{}
	$NewServiceClient_params['GlobalParameterHashtable'] = $GlobalParameterHashtable

	$SubscriptionsAdminClient = New-ServiceClient @NewServiceClient_params


	if ('Operations_List' -eq $PsCmdlet.ParameterSetName) {
		Write-Verbose -Message 'Performing operation ListWithHttpMessagesAsync on $SubscriptionsAdminClient.'
		$TaskResult = $SubscriptionsAdminClient.Operations.ListWithHttpMessagesAsync()
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

