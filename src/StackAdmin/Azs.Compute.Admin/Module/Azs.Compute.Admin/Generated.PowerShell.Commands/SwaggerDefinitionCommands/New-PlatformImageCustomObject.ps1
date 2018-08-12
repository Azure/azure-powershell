


class PlatformImageCustomObject {
    # Resource properties
    [string]$Id;
    [string]$Location
    [string]$Name
    [string]$Type

    # Extended Properties
    [string]$Publisher
    [string]$Offer;
    [string]$Sku;
    [string]$Version

    # VM Extension Properties
    [Object]$OsDisk;
    [Object]$DataDisks
    [Object]$Details
    [Object]$ProvisioningState
}

function New-PlatformImageCustomObject {
    [OutputType([PlatformImageCustomObject])]
    param (
        [Microsoft.AzureStack.Management.Compute.Admin.Models.PlatformImage]$PlatformImage
    )

    # Objects
    [PlatformImageCustomObject]$result = @{}

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
