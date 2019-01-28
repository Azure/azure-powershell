<#
Copyright (c) Microsoft Corporation. All rights reserved.
Licensed under the MIT License. See License.txt in the project root for license information.
#>

<#
.SYNOPSIS
    Create a new virtual machine extension image.

.DESCRIPTION
    Create a virtual machine extension image.

.PARAMETER Publisher
    Name of the publisher.

.PARAMETER Type
    Type of extension.

.PARAMETER Version
    The version of the vritual machine image extension.

.PARAMETER SourceBlob
    URI to virtual machine extension package.

.PARAMETER VmOsType
    Target virtual machine operating system type necessary for deploying the extension handler.

.PARAMETER ComputeRole
    The type of role, IaaS or PaaS, this extension supports.

.PARAMETER VmScaleSetEnabled
    Value indicating whether the extension is enabled for virtual machine scale set support.

.PARAMETER SupportMultipleExtensions
    True if supports multiple extensions.

.PARAMETER IsSystemExtension
    Indicates if the extension is for the system.

.PARAMETER Location
    Location of the resource.

.PARAMETER AsJob
    Run asynchronous as a job and return the job object.

.PARAMETER Force
    Don't ask for confirmation.

.EXAMPLE

    PS C:\> Add-AzsVMExtension -Publisher "Microsoft" -Type "MicroExtension" -Version "0.1.0" -ComputeRole "IaaS" -SourceBlob "https://github.com/Microsoft/PowerShell-DSC-for-Linux/archive/v1.1.1-294.zip" -SupportMultipleExtensions -VmOsType "Linux"

    Add a new platform image extension.

#>
using module '..\CustomObjects\VmExtensionObject.psm1'

function Add-AzsVMExtension {
    [OutputType([VMExtensionObject])]
    [CmdletBinding(SupportsShouldProcess = $true)]
    param(
        [Parameter(Mandatory = $true)]
        [ValidateNotNullOrEmpty()]
        [System.String]
        $Publisher,

        [Parameter(Mandatory = $true)]
        [ValidateNotNullOrEmpty()]
        [System.String]
        $Type,

        [Parameter(Mandatory = $true)]
        [ValidateNotNullOrEmpty()]
        [System.String]
        $Version,

        [Parameter(Mandatory = $true)]
        [ValidateNotNullOrEmpty()]
        $SourceBlob,

        [Parameter(Mandatory = $true)]
        [ValidateSet("Unknown", "Windows", "Linux")]
        [ValidateNotNullOrEmpty()]
        $VmOsType,

        [Parameter(Mandatory = $true)]
        [System.String]
        [ValidateSet('IaaS', 'PaaS')]
        [ValidateNotNullOrEmpty()]
        $ComputeRole,

        [Parameter(Mandatory = $false)]
        [switch]
        $VmScaleSetEnabled,

        [Parameter(Mandatory = $false)]
        [switch]
        $SupportMultipleExtensions,

        [Parameter(Mandatory = $false)]
        [switch]
        $IsSystemExtension,

        [Parameter(Mandatory = $false)]
        [System.String]
        $Location,

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

        if ($Force.IsPresent -or $PSCmdlet.ShouldProcess("$Publisher/$Type/$Version" , "Add virtual machine image extension")) {

            if ( -not $PSBoundParameters.ContainsKey('Location')) {
                $Location = (Get-AzureRMLocation).Location
            }

            if ($null -ne (Get-AzsVMExtension -Publisher $Publisher -Type $Type -Version $Version -Location $Location -ErrorAction SilentlyContinue)) {
                Write-Error "A VM extension with the publisher $publisher, type $type, and version $Version at location $location already exists"
                return
            }

            $NewServiceClient_params = @{
                FullClientTypeName = 'Microsoft.AzureStack.Management.Compute.Admin.ComputeAdminClient'
            }

            $GlobalParameterHashtable = @{}
            $NewServiceClient_params['GlobalParameterHashtable'] = $GlobalParameterHashtable

            $GlobalParameterHashtable['SubscriptionId'] = $null
            if ($PSBoundParameters.ContainsKey('SubscriptionId')) {
                $GlobalParameterHashtable['SubscriptionId'] = $PSBoundParameters['SubscriptionId']
            }

            $ComputeAdminClient = New-ServiceClient @NewServiceClient_params

            $SourceBlob = New-AzureBlobObject -Uri $SourceBlob

            # Create object
            $utilityCmdParams = @{}
            $utilityCmdParams["SourceBlob"] = $SourceBlob
            $flattenedParameters = @('VmOsType', 'ComputeRole', 'VmScaleSetEnabled', 'SupportMultipleExtensions', 'IsSystemExtension')
            $flattenedParameters | ForEach-Object {
                if ($PSBoundParameters.ContainsKey($_)) {
                    $utilityCmdParams[$_] = $PSBoundParameters[$_]
                }
            }
            $Extension = New-VMExtensionParametersObject @utilityCmdParams

            Write-Verbose -Message 'Performing operation add on $ComputeAdminClient.'
            $TaskResult = $ComputeAdminClient.VMExtensions.CreateWithHttpMessagesAsync($Location, $Publisher, $Type, $Version, $Extension)

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
                    $vmExtension = Get-TaskResult @GetTaskResult_params
                    if ($vmExtension -and (Get-Member -InputObject $vmExtension -Name 'Id') -and $vmExtension.Id)
                    {
                        ConvertTo-VmExtensionObject -VmExtension $vmExtension
                    }
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

