<#
Copyright (c) Microsoft Corporation. All rights reserved.
Licensed under the MIT License. See License.txt in the project root for license information.
#>

<#
.SYNOPSIS
    Delete a specific gallery item.

.DESCRIPTION
    Delete a specific gallery item.

.PARAMETER Name
    Identity of the gallery item. Includes publisher name, item name, and may include version separated by period character.

.PARAMETER ResourceId
    Fully qualified Azure resource Id.

.PARAMETER Force
    Don't ask for confirmation.

.EXAMPLE

    Remove-AzsGalleryItem -Name "microsoft.vmss.1.3.6"

    Delete a gallery item.
#>
function Remove-AzsGalleryItem {
    [CmdletBinding(DefaultParameterSetName = 'Delete', SupportsShouldProcess = $true)]
    param(
        [Parameter(Mandatory = $true, ParameterSetName = 'Delete', Position = 0)]
        [ValidateNotNullOrEmpty()]
        [System.String]
        $Name,

        [Parameter(Mandatory = $true, ValueFromPipelineByPropertyName = $true, ParameterSetName = 'ResourceId')]
        [Alias('id')]
        [ValidateNotNullOrEmpty()]
        [System.String]
        $ResourceId,

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


        if ($PSCmdlet.ParameterSetName -eq "ResourceId") {
            $GetArmResourceIdParameterValue_params = @{
                IdTemplate = '/subscriptions/{subscriptionId}/providers/microsoft.gallery.admin/galleryItems/{galleryItemName}'
            }
            $GetArmResourceIdParameterValue_params['Id'] = $ResourceId
            $ArmResourceIdParameterValues = Get-ArmResourceIdParameterValue @GetArmResourceIdParameterValue_params

            $Name = $ArmResourceIdParameterValues['galleryItemName']
        }

        if ($PSCmdlet.ShouldProcess("$Name" , "Delete the gallery item")) {
            if (($Force.IsPresent -or $PSCmdlet.ShouldContinue("Delete the Gallery Item?", "Performing operation delete gallery item on $Name."))) {

                $NewServiceClient_params = @{
                    FullClientTypeName = 'Microsoft.AzureStack.Management.Gallery.Admin.GalleryAdminClient'
                }

                $GlobalParameterHashtable = @{}
                $NewServiceClient_params['GlobalParameterHashtable'] = $GlobalParameterHashtable

                $GlobalParameterHashtable['SubscriptionId'] = $null
                if ($PSBoundParameters.ContainsKey('SubscriptionId')) {
                    $GlobalParameterHashtable['SubscriptionId'] = $PSBoundParameters['SubscriptionId']
                }

                $GalleryAdminClient = New-ServiceClient @NewServiceClient_params

                if ('Delete' -eq $PsCmdlet.ParameterSetName -or 'ResourceId' -eq $PsCmdlet.ParameterSetName) {
                    Write-Verbose -Message 'Performing operation DeleteWithHttpMessagesAsync on $GalleryAdminClient.'
                    $TaskResult = $GalleryAdminClient.GalleryItems.DeleteWithHttpMessagesAsync($Name)
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
        }
    }
    End {
        if ($tracerObject) {
            $global:DebugPreference = $oldDebugPreference
            Unregister-PSSwaggerClientTracing -TracerObject $tracerObject
        }
    }
}

