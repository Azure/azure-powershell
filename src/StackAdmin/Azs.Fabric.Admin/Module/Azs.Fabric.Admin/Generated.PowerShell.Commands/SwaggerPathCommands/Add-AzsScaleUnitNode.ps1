<#
Copyright (c) Microsoft Corporation. All rights reserved.
Licensed under the MIT License. See License.txt in the project root for license information.
#>

<#
.SYNOPSIS
    Add a new scale unit.

.DESCRIPTION
    Add a new scale unit.

.PARAMETER ScaleUnitName
    Name of the scale unit.

.PARAMETER NodeList
    List of nodes in the scale unit.

.PARAMETER AwaitStorageConvergence
    Flag indicates if the operation should wait for storage to converge before returning.

.PARAMETER Location
    Location of the resource.

.PARAMETER ResourceGroupName
    Resource group in which the resource provider has been registered.

.PARAMETER ResourceId
    Scale unit node resource ID.

.PARAMETER AsJob
    Run asynchronous as a job and return the job object.

.PARAMETER Force
    Don't ask for confirmation

.EXAMPLE

    PS C:\> Add-AzsScaleUnitNode -ScaleUnitName "Azs-ERC03" -NodeList $nodeList

    Add a new scale unit node.

#>
function Add-AzsScaleUnitNode {
    [CmdletBinding(DefaultParameterSetName = 'ScaleOut', SupportsShouldProcess = $true)]
    param(
        [Parameter(Mandatory = $true, ParameterSetName = 'ScaleOut')]
        [ValidateNotNullOrEmpty()]
        [System.String]
        $Name,

        [Parameter(Mandatory = $true)]
        [ValidateNotNullOrEmpty()]
        [Microsoft.AzureStack.Management.Fabric.Admin.Models.ScaleOutScaleUnitParameters[]]
        $NodeList,

        [Parameter(Mandatory = $false)]
        [switch]
        $AwaitStorageConvergence,

        [Parameter(Mandatory = $false, ParameterSetName = 'ScaleOut')]
        [System.String]
        $Location,

        [Parameter(Mandatory = $false, ParameterSetName = 'ScaleOut')]
        [ValidateLength(1, 90)]
        [System.String]
        $ResourceGroupName,

        [Parameter(Mandatory = $true, ValueFromPipelineByPropertyName = $true, ParameterSetName = 'ResourceId')]
        [Alias('id')]
        [ValidateNotNullOrEmpty()]
        [System.String]
        $ResourceId,

        [Parameter(Mandatory = $false)]
        [switch]
        $AsJob,

        [Parameter(Mandatory = $false)]
        [switch]
        $Force
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

        if ('ResourceId' -eq $PsCmdlet.ParameterSetName) {
            $GetArmResourceIdParameterValue_params = @{
                IdTemplate = '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Fabric.Admin/fabricLocations/{location}/scaleUnits/{scaleUnit}'
            }

            $GetArmResourceIdParameterValue_params['Id'] = $ResourceId
            $ArmResourceIdParameterValues = Get-ArmResourceIdParameterValue @GetArmResourceIdParameterValue_params

            $ResourceGroupName = $ArmResourceIdParameterValues['resourceGroupName']
            $location = $ArmResourceIdParameterValues['location']
            $Name = $ArmResourceIdParameterValues['scaleUnit']
        }

        if ($PSCmdlet.ShouldProcess("$Name" , "Add new scale unit node")) {
            if ($Force.IsPresent -or $PSCmdlet.ShouldContinue("Add new scale unit node?", "Performing operation add scale unit node for scale unit $Name")) {

                $NewServiceClient_params = @{
                    FullClientTypeName = 'Microsoft.AzureStack.Management.Fabric.Admin.FabricAdminClient'
                }

                $GlobalParameterHashtable = @{}
                $NewServiceClient_params['GlobalParameterHashtable'] = $GlobalParameterHashtable

                $GlobalParameterHashtable['SubscriptionId'] = $null
                if ($PSBoundParameters.ContainsKey('SubscriptionId')) {
                    $GlobalParameterHashtable['SubscriptionId'] = $PSBoundParameters['SubscriptionId']
                }

                $flattenedParameters = @('NodeList', 'AwaitStorageConvergence')
                $utilityCmdParams = @{}
                $flattenedParameters | ForEach-Object {
                    if ($PSBoundParameters.ContainsKey($_)) {
                        $utilityCmdParams[$_] = $PSBoundParameters[$_]
                    }
                }

                $ListOfNodeParameters = New-ScaleOutScaleUnitParametersListObject @utilityCmdParams

                $FabricAdminClient = New-ServiceClient @NewServiceClient_params

                if ([String]::IsNullOrEmpty($Location)) {
                    $Location = (Get-AzureRMLocation).Location
                }
                if ([String]::IsNullOrEmpty($ResourceGroupName)) {
                    $ResourceGroupName = "System.$Location"
                }

                if ('ScaleOut' -eq $PsCmdlet.ParameterSetName -or "ResourceId" -eq $PsCmdlet.ParameterSetName) {
                    Write-Verbose -Message 'Performing operation ScaleOutWithHttpMessagesAsync on $FabricAdminClient.'
                    $TaskResult = $FabricAdminClient.ScaleUnits.ScaleOutWithHttpMessagesAsync($ResourceGroupName, $Location, $Name, $ListOfNodeParameters)
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
                if (-not $AsJob.IsPresent) {
                    Invoke-Command -ScriptBlock $PSSwaggerJobScriptBlock `
                        -ArgumentList $TaskResult, $TaskHelperFilePath `
                        @PSCommonParameters
                } else {
                    $ScriptBlockParameters = New-Object -TypeName 'System.Collections.Generic.Dictionary[string,object]'
                    $ScriptBlockParameters['TaskResult'] = $TaskResult
                    $ScriptBlockParameters['AsJob'] = $true
                    $ScriptBlockParameters['TaskHelperFilePath'] = $TaskHelperFilePath
                    $PSCommonParameters.GetEnumerator() | ForEach-Object { $ScriptBlockParameters[$_.Name] = $_.Value }

                    Start-PSSwaggerJobHelper -ScriptBlock $PSSwaggerJobScriptBlock `
                        -CallerPSBoundParameters $ScriptBlockParameters `
                        -CallerPSCmdlet $PSCmdlet `
                        @PSCommonParameters
                }
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

