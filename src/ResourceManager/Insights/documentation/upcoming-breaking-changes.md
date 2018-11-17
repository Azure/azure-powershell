<!--
    Please leave this section at the top of the breaking change documentation.

    New breaking changes should go under the section titled "Upcoming Breaking Changes", and should adhere to the following format:

    # Upcoming Breaking Changes

    ## Release X.0.0 - January 2017

    The following cmdlets were affected this release:

    **Cmdlet 1**
    - Description of what has changed

    ```powershell
    # Old
    # Sample of how the cmdlet was previously called

    # New
    # Sample of how the cmdlet should now be called
    ```

    Note: the above section follows the template found in the link below: 

    https://github.com/Azure/azure-powershell/blob/dev/documentation/breaking-changes/breaking-change-template.md
-->

# Upcoming Breaking Changes

## Release 0.0.0 - May 2018

**General**
- The namespace of the Model classes changed from Microsoft.Azure.Management.Monitor.Management.Models to Microsoft.Azure.Management.Monitor.Models.
- The namespace for output classes will be uniform for all classes in future releases to make it independent of modifications in the model classes.

**Set-AzureRmDiagnosticSetting**
- The plural names for the arguments Categories and Timegrains will be removed and the singular versions will be used instead.

## Release 0.0.0 - May 2018

**Get-AzureRmAlertHistory**
**Get-AzureRmAlertRule**
**Get-AzureRmAutoscaleHistory**
**Get-AzureRmAutoscaleSetting**
**Get-AzureRmLog**
**Get-AzureRmMetric**
**Get-AzureRmMetricDefinition**
- Argument deprecation: The DetailedOutput argument will be deprecated. In the current version the cmdlet is already returning complete objects, but showing only some attributes for the "no details" option.