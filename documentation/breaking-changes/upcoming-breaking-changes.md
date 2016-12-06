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

## Release 3.0.0 - February 2017

    The following cmdlets were affected this release:

    **Get-AzureRmMetricDefinition**
    - The metric definitions are now retrieved from MDM. In this case, the records returned by this cmdlet are different even though the call remains the same.

    ```powershell
    # Old
  
    $s1 = Get-AzureRmMetricDefinition -res $resourceIdMetric -det
    write-host "Values: $s1"
    $s11 = $s1[0]
    write-host "First value: $s11"
    $metricName = $s11.Name
    
    $s2 = Get-AzureRmMetricDefinition -res $resourceIdMetric -met $metricName -det
    $s21 = $s2[0]
    write-host "Availabilities: $s21.MetricAvailabilities"
    
    write-host "Unit: $s21.Unit"
    write-host "ResourceId: $s21.ResourceId"
    write-host "Name: $s21.Name"
    write-host "PrimaryAggregationType: $s21.PrimaryAggregationType"
    write-host "Properties: $s21.Properties"
    
    $s22 = $s21.MetricAvailabilities[0]
    write-host "BlobLocation: $s22.BlobLocation"
    write-host "Location: $s22.Location"
    write-host "Retention: $s22.Retention"
    write-host "Timegrain: $s22.TimeGrain"

    # New
  
    $s1 = Get-AzureRmMetricDefinition -res $resourceIdMetric -det
    write-host "Values: $s1"
    $s11 = $s1[0]
    write-host "First value: $s11"
    $metricName = $s11.Name.Value
    
    $s2 = Get-AzureRmMetricDefinition -res $resourceIdMetric -met $metricName -det
    $s21 = $s2[0]
    write-host "Availabilities: $s21.MetricAvailabilities"
    
    write-host "Unit: $s21.Unit"
    write-host "ResourceId: $s21.ResourceId"
    write-host "Name: $s21.Name.Value"
    write-host "PrimaryAggregationType: $s21.PrimaryAggregationType"
    
    $s22 = $s21.MetricAvailabilities[0]
    write-host "Retention: $s22.Retention"
    write-host "Timegrain: $s22.TimeGrain"
    
    ```
  
  **Get-AzureRmMetric**
    - The metrics are now retrieved from MDM. The call and the returned records are different now.

    ```powershell
    # Old
    
    # ResourceId and timeGrain are mandatory and positional
    $s1 = Get-AzureRmMetric $resourceIdMetric $timeGrain -det
    
    write-host "Values: $s1"
    
    $s11 = $s1[0]
    
    write-host "Dimension name: $s11.DimensionName"
    write-host "Dimension value: $s11.DimensionValue"
    write-host "End time: $s11.EndTime"
    write-host "Start time: $s11.StartTime"
    write-host "ResourceId: $s11.ResourceId"
    write-host "TimeGrain: $s11.TimeGrain"
    write-host "Unit: $s11.Unit"
    write-host "Metric values: $s11.MetricValues"

    # New
  
    # This calls are valid. ResourceId remains mandatory and positional
    $s1 = Get-AzureRmMetric $resourceIdMetric
    $s1 = Get-AzureRmMetric -res $resourceIdMetric
  
    write-host "Values: $s1"
  
    # This calls now requires the argument -MetricNames to succeed. MetricName is also positional (position 1). TimeGrain becomes optional and it is only accepted if MetricNames is given.
    # If metricName is not given, no other parameter is accepted (except resourceId)
    $s2 = Get-AzureRmMetric $resourceIdMetric -time $timeGrain -metricn $metricName
    
    write-host "Values: $s2"
    
    $s21 = $s2[0]
    
    write-host "Name: $s21.Name.Value"
    write-host "Unit: $s21.Unit"
    write-host "Data: $s21.Data"
    
    ```