<#
Copyright (c) Microsoft Corporation. All rights reserved.
Licensed under the MIT License. See License.txt in the project root for license information.
#>

<#
.SYNOPSIS
    Returns virtual machine image extensions currently available.

.DESCRIPTION
    Returns virtual machine image extensions.

.PARAMETER Publisher
    Name of the publisher.

.PARAMETER Type
    Type of extension.

.PARAMETER Version
    The version of the virtual machine image extension.

.PARAMETER Location
    Location of the resource.

.PARAMETER ResourceId
    The resource id.

.EXAMPLE

    PS C:\> Get-AzsVMExtension

    Get all VM extensions at a location.

.EXAMPLE

    PS C:\> Get-AzsVMExtension -Publisher "Microsoft" -Type "MicroExtension" -Version "0.1.0"

    Get specific VM extension.

#>
using module '..\CustomObjects\VmExtensionObject.psm1'

function Get-AzsVMExtension {
    [OutputType([VmExtensionObject])]
    [CmdletBinding(DefaultParameterSetName = 'List')]
    param(
        [Parameter(Mandatory = $true, ParameterSetName = 'Get')]
        [Parameter(Mandatory = $false, ParameterSetName = 'List')]
        [ValidateNotNullOrEmpty()]
        [System.String]
        $Publisher,

        [Parameter(Mandatory = $true, ParameterSetName = 'Get')]
        [Parameter(Mandatory = $false, ParameterSetName = 'List')]
        [ValidateNotNullOrEmpty()]
        [System.String]
        $Type,

        [Parameter(Mandatory = $true, ParameterSetName = 'Get')]
        [ValidateNotNullOrEmpty()]
        [System.String]
        $Version,

        [Parameter(Mandatory = $false, ParameterSetName = 'List')]
        [Parameter(Mandatory = $false, ParameterSetName = 'Get')]
        [System.String]
        $Location,

        [Parameter(Mandatory = $true, ValueFromPipelineByPropertyName = $true, ParameterSetName = 'ResourceId')]
        [Alias('id')]
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

        if ('ResourceId' -eq $PsCmdlet.ParameterSetName) {
            $GetArmResourceIdParameterValue_params = @{
                IdTemplate = '/subscriptions/{subscriptionId}/providers/Microsoft.Compute.Admin/locations/{locationName}/artifactTypes/VMExtension/publishers/{publisher}/types/{type}/versions/{version}'
            }
            $GetArmResourceIdParameterValue_params['Id'] = $ResourceId
            $ArmResourceIdParameterValues = Get-ArmResourceIdParameterValue @GetArmResourceIdParameterValue_params

            $Location = $ArmResourceIdParameterValues['locationName']
            $publisher = $ArmResourceIdParameterValues['publisher']
            $type = $ArmResourceIdParameterValues['type']
            $version = $ArmResourceIdParameterValues['version']
        } elseif ( [System.String]::IsNullOrEmpty($Location)) {
            $Location = (Get-AzureRMLocation).Location
        }

        if ('Get' -eq $PsCmdlet.ParameterSetName -or 'ResourceId' -eq $PsCmdlet.ParameterSetName) {
            Write-Verbose -Message 'Performing operation GetWithHttpMessagesAsync on $ComputeAdminClient.'
            $TaskResult = $ComputeAdminClient.VMExtensions.GetWithHttpMessagesAsync($Location, $Publisher, $Type, $Version)
        } elseif ('List' -eq $PsCmdlet.ParameterSetName) {
            Write-Verbose -Message 'Performing operation ListWithHttpMessagesAsync on $ComputeAdminClient.'
            $TaskResult = $ComputeAdminClient.VMExtensions.ListWithHttpMessagesAsync($Location)
        } else {
            Write-Verbose -Message 'Failed to map parameter set to operation method.'
            throw 'Module failed to find operation to execute.'
        }

        if ($TaskResult) {
            $GetTaskResult_params = @{
                TaskResult = $TaskResult
            }

            Get-TaskResult @GetTaskResult_params | ForEach-Object {
                [VmExtensionObject]$Object = ConvertTo-VmExtensionObject -VMExtension $_

                # Filter
                [bool]$add = $true
                if ($add -and (-not [System.String]::IsNullOrEmpty($Publisher))) {
                    $add = $Object.Publisher -like "*$Publisher*"
                }
                if ($add -and (-not [System.String]::IsNullOrEmpty($Type))) {
                    $add = $Object.ExtensionType -like "*$Type*"
                }

                if ($add) {
                    $Object
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
