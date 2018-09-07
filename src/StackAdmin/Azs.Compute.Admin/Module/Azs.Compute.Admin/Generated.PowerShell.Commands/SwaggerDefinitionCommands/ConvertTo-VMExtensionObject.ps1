

function ConvertTo-VmExtensionObject {
    [OutputType([VmExtensionObject])]
    param (
        [Microsoft.AzureStack.Management.Compute.Admin.Models.VMExtension]$VMExtension
    )

    # Objects
    [VmExtensionObject]$result = @{}

    # Add existing properties to new object
    Get-Member -InputObject $VMExtension -MemberType Properties | ForEach-Object {
        $property = $_.Name
        $value = Select-Object -InputObject $VMExtension -ExpandProperty "$property"
        $result."$property" = $value
        # Add-Member -MemberType NoteProperty -InputObject $result -Name $property -Value $value | Out-Null
    }

    # Extract information
    $GetArmResourceIdParameterValue_params = @{
        IdTemplate = '/subscriptions/{subscriptionId}/providers/Microsoft.Compute.Admin/locations/{locationName}/artifactTypes/VMExtension/publishers/{publisher}/types/{type}/versions/{version}'
    }
    $GetArmResourceIdParameterValue_params['Id'] = $VMExtension.Id
    $ArmResourceIdParameterValues = Get-ArmResourceIdParameterValue @GetArmResourceIdParameterValue_params

    $publisherProperty = $ArmResourceIdParameterValues['publisher']
    $typeProperty = $ArmResourceIdParameterValues['type']
    $versionProperty = $ArmResourceIdParameterValues['version']

    # Add extra information
    $result.Publisher = $publisherProperty
    $result.ExtensionType = $typeProperty
    $result.TypeHandlerVersion = $versionProperty

    $result
}
