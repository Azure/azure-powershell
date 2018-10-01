<#
Copyright (c) Microsoft Corporation. All rights reserved.
Licensed under the MIT License. See License.txt in the project root for license information.
#>

<#
.SYNOPSIS
    Scale out a scale unit.

.DESCRIPTION
    Add a new scale unit node to your scale unit cluster.

.PARAMETER NodeList
    A list of input data that allows for adding a set of scale unit nodes.

.PARAMETER ResourceGroupName
    Name of the resource group.

.PARAMETER ScaleUnit
    Name of the scale units.

.PARAMETER Location
    Location of the resource.

.PARAMETER AwaitStorageConvergence
    Wait for storage replication to complete before returning success.

.PARAMETER AsJob
    Run asynchronous as a job and return the job object.

.EXAMPLE

    Add-AzsScaleUnitNode -NodeList $Nodes -ScaleUnit $ScaleUnitName

    Adds a list of nodes to the scale unit.

#>
function Add-AzsScaleUnitNode
{
    [CmdletBinding()]
    param(
        [Parameter(Mandatory = $true)]
        [ValidateNotNull()]
        [Microsoft.AzureStack.Management.Fabric.Admin.Models.ScaleOutScaleUnitParameters[]]
        $NodeList,

        [Parameter(Mandatory = $false)]
        [ValidateNotNullOrEmpty()]
        [System.String]
        $ResourceGroupName,

        [Parameter(Mandatory = $true)]
        [ValidateNotNullOrEmpty()]
        [System.String]
        $ScaleUnit,

        [Parameter(Mandatory = $false)]
        [System.String]
        [ValidateNotNullOrEmpty()]
        $Location,

        [Parameter(Mandatory = $false)]
        [switch]
        $AwaitStorageConvergence,

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

    $ScaleUnit = Get-ResourceName -ResourceName $ScaleUnit


    $NewServiceClient_params = @{
        FullClientTypeName = 'Microsoft.AzureStack.Management.Fabric.Admin.FabricAdminClient'
    }

    $GlobalParameterHashtable = @{}
    $NewServiceClient_params['GlobalParameterHashtable'] = $GlobalParameterHashtable

    $GlobalParameterHashtable['SubscriptionId'] = $null
    if($PSBoundParameters.ContainsKey('SubscriptionId')) {
        $GlobalParameterHashtable['SubscriptionId'] = $PSBoundParameters['SubscriptionId']
    }

    $FabricAdminClient = New-ServiceClient @NewServiceClient_params

    $ParamList = New-ScaleOutScaleUnitParametersListObject -NodeList $NodeList -AwaitStorageConvergence:$AwaitStorageConvergence:IsPresent

    if ([System.String]::IsNullOrEmpty($Location)) {
        $Location = (Get-AzureRmLocation).Location
    }

    if ([System.String]::IsNullOrEmpty($ResourceGroupName)) {
        $ResourceGroupName = "System.$Location"
    }

    Write-Verbose -Message 'Performing operation ScaleOutWithHttpMessagesAsync on $FabricAdminClient.'
    $TaskResult = $FabricAdminClient.ScaleUnits.ScaleOutWithHttpMessagesAsync($ResourceGroupName, $Location, $ScaleUnit, $ParamList)

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

