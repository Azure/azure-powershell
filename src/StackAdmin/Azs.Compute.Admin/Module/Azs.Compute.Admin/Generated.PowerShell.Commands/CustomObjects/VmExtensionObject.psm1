
class VmExtensionObject {
    # Resource properties
    [string]$Id;
    [string]$Location
    [string]$Name
    [string]$Type

    # Extended Properties
    [string]$Publisher
    [string]$TypeHandlerVersion;
    [string]$ExtensionType

    # VM Extension Properties
    [string]$ComputeRole;

    [bool]$IsSystemExtension
    [Object]$ProvisioningState

    [Object]$SourceBlob
    [string]$SupportMultipleExtensions

    [Object]$VmOsType
    [bool]$VmScaleSetEnabled
}
