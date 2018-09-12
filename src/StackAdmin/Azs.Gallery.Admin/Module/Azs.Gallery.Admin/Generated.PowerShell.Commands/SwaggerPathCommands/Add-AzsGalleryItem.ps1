<#
Copyright (c) Microsoft Corporation. All rights reserved.
Licensed under the MIT License. See License.txt in the project root for license information.
#>

<#
.SYNOPSIS
    Uploads a provider gallery item to the storage.

.DESCRIPTION
    Uploads a provider gallery item to the storage.

.PARAMETER GalleryItemUri
    The URI to the gallery item JSON file.

.PARAMETER Force
    Don't ask for confirmation.

.EXAMPLE

    Add-AzsGalleryItem -GalleryItemUri 'http://galleryitemuri'

    Create a new gallery item.
#>
function Add-AzsGalleryItem {
    [OutputType([Microsoft.AzureStack.Management.Gallery.Admin.Models.GalleryItem])]
    [CmdletBinding(SupportsShouldProcess = $true)]
    param(
        [Parameter(Mandatory = $true, Position = 0 )]
        [ValidateNotNullOrEmpty()]
        [System.String]
        $GalleryItemUri,

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

        if ($PSCmdlet.ShouldProcess("$GalleryItemUri" , "Add Gallery item")) {
            if ($Force.IsPresent -or $PSCmdlet.ShouldContinue("Gallery item could already exist, are you sure?", "Performing operation add gallery item from $GalleryItemUri")) {

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

                Write-Verbose -Message 'Performing operation add on $GalleryAdminClient.'
                $TaskResult = $GalleryAdminClient.GalleryItems.CreateWithHttpMessagesAsync($(if ($PSBoundParameters.ContainsKey('GalleryItemUri')) {
                            $GalleryItemUri
                        } else {
                            [NullString]::Value
                        }))

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

