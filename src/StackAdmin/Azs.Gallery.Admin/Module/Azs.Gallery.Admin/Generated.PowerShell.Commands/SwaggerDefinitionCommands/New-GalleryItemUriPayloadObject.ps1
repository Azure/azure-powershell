<#
Copyright (c) Microsoft Corporation. All rights reserved.
Licensed under the MIT License. See License.txt in the project root for license information.
#>

<#
.SYNOPSIS
    Location of gallery item payload.

.DESCRIPTION
    Location of gallery item payload.

.PARAMETER GalleryItemUri
    URI for your gallery package that has already been uploaded online.

#>
function New-GalleryItemUriPayloadObject
{
    param(    
        [Parameter(Mandatory = $false)]
        [string]
        $GalleryItemUri
    )
    
    $Object = New-Object -TypeName Microsoft.AzureStack.Management.Gallery.Admin.Models.GalleryItemUriPayload -ArgumentList @($galleryItemUri)

    if(Get-Member -InputObject $Object -Name Validate -MemberType Method)
    {
        $Object.Validate()
    }

    return $Object
}

