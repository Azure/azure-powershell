<#
Copyright (c) Microsoft Corporation. All rights reserved.
Licensed under the MIT License. See License.txt in the project root for license information.
#>

<#
.SYNOPSIS
    Create an infrastructure IP pool.  Once created an IP pool cannot be deleted or modified.

.DESCRIPTION
    Create an infrastructure IP pool.

.PARAMETER Name
    IP pool name.

.PARAMETER AddressPrefix
    The address prefix.

.PARAMETER StartIpAddress
    The starting IP address.

.PARAMETER EndIpAddress
    The ending IP address.

.PARAMETER Location
    The region where the resource is located.

.PARAMETER ResourceGroupName
    Resource group in which the resource provider has been registered.

.PARAMETER AsJob
    Run asynchronous as a job and return the job object.

.PARAMETER Tags
    List of key-value pairs.

.EXAMPLE

    PS C:\> New-AzsIpPool -Name IpPool4 -StartIpAddress ***.***.***.*** -EndIpAddress ***.***.***.*** -AddressPrefix ***.***.***.***/24

    Create a new IP pool.

#>
function New-AzsIpPool {
    [OutputType([Microsoft.AzureStack.Management.Fabric.Admin.Models.ProvisioningState])]
    [CmdletBinding(SupportsShouldProcess = $true)]
    param(
        [Parameter(Mandatory = $false)]
        [System.String]
        $Name,

        [Parameter(Mandatory = $false)]
        [System.String]
        $AddressPrefix,

        [Parameter(Mandatory = $false)]
        [System.String]
        $StartIpAddress,

        [Parameter(Mandatory = $false)]
        [System.String]
        $EndIpAddress,

        [Parameter(Mandatory = $false)]
        [System.String]
        $Location,

        [Parameter(Mandatory = $false)]
        [ValidateLength(1, 90)]
        [System.String]
        $ResourceGroupName,

        [Parameter(Mandatory = $false)]
        [System.Collections.Generic.Dictionary[[System.String], [System.String]]]
        $Tags,

        [Parameter(Mandatory = $false)]
        [switch]
        $AsJob
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

        if ($PSCmdlet.ShouldProcess("$Name", "Create a new Ip Pool")) {

            if ([System.String]::IsNullOrEmpty($Location)) {
                $Location = (Get-AzureRMLocation).Location
            }
            if ([System.String]::IsNullOrEmpty($ResourceGroupName)) {
                $ResourceGroupName = "System.$Location"
            }

            # Validate this resource does not exist.
            if ($null -ne (Get-AzsIpPool -Name $Name -Location $Location -ResourceGroupName $ResourceGroupName -ErrorAction SilentlyContinue)) {
                Write-Error "An IP pool with the name $Name under the resource group $ResourceGroupName at location $location already exists"
                return
            }

            $flattenedParameters = @('NumberOfIpAddressesInTransition', 'StartIpAddress', 'Tags', 'AddressPrefix', 'NumberOfIpAddresses', 'Location', 'EndIpAddress', 'NumberOfAllocatedIpAddresses')
            $utilityCmdParams = @{}
            $flattenedParameters | ForEach-Object {
                if ($PSBoundParameters.ContainsKey($_)) {
                    $utilityCmdParams[$_] = $PSBoundParameters[$_]
                }
            }
            $Pool = New-IpPoolObject @utilityCmdParams

            $NewServiceClient_params = @{
                FullClientTypeName = 'Microsoft.AzureStack.Management.Fabric.Admin.FabricAdminClient'
            }
            $GlobalParameterHashtable = @{}
            $GlobalParameterHashtable['SubscriptionId'] = $null
            if ($PSBoundParameters.ContainsKey('SubscriptionId')) {
                $GlobalParameterHashtable['SubscriptionId'] = $PSBoundParameters['SubscriptionId']
            }
            $NewServiceClient_params['GlobalParameterHashtable'] = $GlobalParameterHashtable
            $FabricAdminClient = New-ServiceClient @NewServiceClient_params

            Write-Verbose -Message 'Performing operation create on $FabricAdminClient.'
            $TaskResult = $FabricAdminClient.IpPools.CreateOrUpdateWithHttpMessagesAsync($ResourceGroupName, $Location, $Name, $Pool)

            Write-Verbose -Message "Waiting for the operation to complete."

            $PSSwaggerJobScriptBlock = {
                [CmdletBinding()]
                param(
                    [Parameter(Mandatory = $true)]
                    [System.Threading.Tasks.Task]
                    $TaskResult,

                    [Parameter(Mandatory = $true)]
                    [System.String]
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

    End {
        if ($tracerObject) {
            $global:DebugPreference = $oldDebugPreference
            Unregister-PSSwaggerClientTracing -TracerObject $tracerObject
        }
    }
}

