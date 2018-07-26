<#
Copyright (c) Microsoft Corporation. All rights reserved.
Licensed under the MIT License. See License.txt in the project root for license information.
#>

<#
.SYNOPSIS
	

.DESCRIPTION
	Move subscriptions between delegated provider offers. This process will only perform a rebranding,
	the underlying offer, plans, quotas for the subscriptions will not be altered.

.PARAMETER DestinationDelegatedProviderOffer
	Specifies the fully qualified delegated provider offer into which this cmdlet moves subscriptions.
	NULL if the subscriptions are to be moved back to the Default Provider.

.PARAMETER ResourceId
	Specifies an array of fully qualified subscription resource identifiers that this
	cmdlet moves.

.PARAMETER AsJob
	Specifies whether the move operation is to be executed as a job.

.EXAMPLE
	Move user subscriptions to a delegated provider offer.
	Move-AzsSubscription `
		-DestinationDelegatedProviderOffer "/subscriptions/45ec4d39-8dea-4d26-a373-c176ec53717a/providers/Microsoft.Subscriptions.Admin/delegatedProviders/798568b7-c6f1-4bf7-bb8f-2c8bebc7c777/offers/ro1"
		-ResourceId "/subscriptions/45ec4d39-8dea-4d26-a373-c176ec53717a/providers/Microsoft.Subscriptions.Admin/subscriptions/ce4c7fdb-5a38-46f5-8bbc-b8b328a87ab6","/subscriptions/45ec4d39-8dea-4d26-a373-c176ec53717a/providers/Microsoft.Subscriptions.Admin/subscriptions/a0d1a71c-0b27-4e73-abfc-169512576f7d"

.EXAMPLE
	Move user subscriptions from a delegated provider to the Default Provider.
	$resourceIds = Get-AzsUserSubscription -Filter "offerName eq 'o1'" | where {$_.DelegatedProviderSubscriptionId -eq "798568b7-c6f1-4bf7-bb8f-2c8bebc7c777"} | Select -ExpandProperty Id
	Move-AzsSubscription -ResourceId $resourceIds
#>
function Move-AzsSubscription
{
	[CmdletBinding(DefaultParameterSetName='Subscriptions_MoveSubscriptions')]
	param(    
		[Parameter(Mandatory = $false)]
		[System.String]
		$DestinationDelegatedProviderOffer = $null,

		[Parameter(Mandatory = $true)]
		[ValidateNotNullOrEmpty()]
		[System.String[]]
		$ResourceId,

		[Parameter(Mandatory = $false)]
		[switch]
		$AsJob
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
		FullClientTypeName = 'Microsoft.AzureStack.Management.Subscriptions.Admin.SubscriptionsAdminClient'
	}

	$GlobalParameterHashtable = @{}
	$NewServiceClient_params['GlobalParameterHashtable'] = $GlobalParameterHashtable
	 
	$GlobalParameterHashtable['SubscriptionId'] = $null
	if($PSBoundParameters.ContainsKey('SubscriptionId')) {
		$GlobalParameterHashtable['SubscriptionId'] = $PSBoundParameters['SubscriptionId']
	}

	$MoveSubscriptionsDefinition = New-MoveSubscriptionsDefinitionObject -Resources $ResourceId -TargetDelegatedProviderOffer $DestinationDelegatedProviderOffer
	
	$SubscriptionsAdminClient = New-ServiceClient @NewServiceClient_params

	if ('Subscriptions_MoveSubscriptions' -eq $PsCmdlet.ParameterSetName) {
		Write-Verbose -Message 'Performing operation MoveSubscriptionsWithHttpMessagesAsync on $SubscriptionsAdminClient.'
		$TaskResult = $SubscriptionsAdminClient.Subscriptions.MoveSubscriptionsWithHttpMessagesAsync($MoveSubscriptionsDefinition)
	} else {
		Write-Verbose -Message 'Failed to map parameter set to operation method.'
		throw 'Module failed to find operation to execute.'
	}

	Write-Verbose -Message "Waiting for the operation to complete."

	$PSSwaggerJobScriptBlock = {
		[CmdletBinding()]
		param(    
			[Parameter(Mandatory = $true)]
			[System.Threading.Tasks.Task]
			$TaskResult,

			[Parameter(Mandatory = $true)]
			[string]
			$TaskHelperFilePath
		)
		if ($TaskResult) {
			. $TaskHelperFilePath
			$GetTaskResult_params = @{
				TaskResult = $TaskResult
			}
			
			Get-TaskResult @GetTaskResult_params
			
		}
	}

	$PSCommonParameters = Get-PSCommonParameter -CallerPSBoundParameters $PSBoundParameters
	$TaskHelperFilePath = Join-Path -Path $ExecutionContext.SessionState.Module.ModuleBase -ChildPath 'Get-TaskResult.ps1'
	if($AsJob)
	{
		$ScriptBlockParameters = New-Object -TypeName 'System.Collections.Generic.Dictionary[string,object]'
		$ScriptBlockParameters['TaskResult'] = $TaskResult
		$ScriptBlockParameters['AsJob'] = $AsJob
		$ScriptBlockParameters['TaskHelperFilePath'] = $TaskHelperFilePath
		$PSCommonParameters.GetEnumerator() | ForEach-Object { $ScriptBlockParameters[$_.Name] = $_.Value }

		Start-PSSwaggerJobHelper -ScriptBlock $PSSwaggerJobScriptBlock `
									 -CallerPSBoundParameters $ScriptBlockParameters `
									 -CallerPSCmdlet $PSCmdlet `
									 @PSCommonParameters
	}
	else
	{
		Invoke-Command -ScriptBlock $PSSwaggerJobScriptBlock `
					   -ArgumentList $TaskResult,$TaskHelperFilePath `
					   @PSCommonParameters
	}
	}

	End {
		if ($tracerObject) {
			$global:DebugPreference = $oldDebugPreference
			Unregister-PSSwaggerClientTracing -TracerObject $tracerObject
		}
	}
}