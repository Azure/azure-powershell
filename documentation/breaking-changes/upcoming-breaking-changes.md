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

## Release X.0.0 - January 2017

    The following cmdlets were affected this release:

    **Get-AzureRmMetricDefinition**
    - The metric definitions are now retrieved from MDM. In this case, the records returned by this cmdlet are different even though the call remains the same.

    ```powershell
    # Old
    # Sample of how the cmdlet was previously called
	
	Get-AzureRmMetricDefinition -res $resourceIdMetric
	Get-AzureRmMetricDefinition -res $resourceIdMetric -det
	Get-AzureRmMetricDefinition -res $resourceIdMetric -det -met $metricName

    # New
    # Sample of how the cmdlet should now be called
	
	Get-AzureRmMetricDefinition -res $resourceIdMetric
	Get-AzureRmMetricDefinition -res $resourceIdMetric -det
	Get-AzureRmMetricDefinition -res $resourceIdMetric -det -met $metricName
    ```
	
	**Get-AzureRmMetric**
    - The metrics are now retrieved from MDM. The call and the returned records are different now.

    ```powershell
    # Old
    # Sample of how the cmdlet was previously called
	
	Get-AzureRmMetric -res $resourceIdMetric
	Get-AzureRmMetric -res $resourceIdMetric -time $timeGrain

    # New
    # Sample of how the cmdlet should now be called
	
	# This call remains valid
	Get-AzureRmMetric -res $resourceIdMetric
	
	# This call now requires the argument -MetricNames to succeed
	Get-AzureRmMetric -res $resourceIdMetric -time $timeGrain -metricn $metricName
    ```