
<#
Copyright (c) Microsoft Corporation. All rights reserved.
Licensed under the MIT License. See License.txt in the project root for license information.
#>

using module '..\CustomObjects\PlatformImageObject.psm1'
function ConvertTo-PlatformImageObject {
    [cmdletbinding()]
    [OutputType([PlatformImageObject])]
    param (
        [Microsoft.AzureStack.Management.Compute.Admin.Models.PlatformImage]$PlatformImage
    )

    # Objects
    [PlatformImageObject]$result = @{}

    # Add existing properties to new object
    Get-Member -InputObject $PlatformImage -MemberType Properties | ForEach-Object {
        $property = $_.Name
        $value = Select-Object -InputObject $PlatformImage -ExpandProperty "$property"
        $result."$property" = $value
    }

    $GetArmResourceIdParameterValue_params = @{
        IdTemplate = '/subscriptions/{subscriptionId}/providers/Microsoft.Compute.Admin/locations/{locationName}/artifactTypes/platformImage/publishers/{publisher}/offers/{offer}/skus/{sku}/versions/{version}'
    }
    $GetArmResourceIdParameterValue_params['Id'] = $PlatformImage.Id
    $ArmResourceIdParameterValues = Get-ArmResourceIdParameterValue @GetArmResourceIdParameterValue_params

    # Add extra information
    $result.Publisher = $ArmResourceIdParameterValues['Publisher']
    $result.Offer = $ArmResourceIdParameterValues['Offer']
    $result.Sku = $ArmResourceIdParameterValues['Sku']
    $result.Version = $ArmResourceIdParameterValues['Version']

    $result
}
