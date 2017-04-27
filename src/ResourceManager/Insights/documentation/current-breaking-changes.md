<!--
    Please leave this section at the top of the breaking change documentation.

    New breaking changes should go under the section titled "Current Breaking Changes", and should adhere to the following format:

    ## Current Breaking Changes

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

    # The call remains the same, but the returned values changed    
    $s1 = Get-AzureRmMetricDefinition -res $resourceIdMetric -det
    write-host "Values: $s1"
    $s11 = $s1[0]
    write-host "First value: $s11"
    
    # Notice name is now a LocalizableString
    $metricName = $s11.Name.Value
    
    $s2 = Get-AzureRmMetricDefinition -res $resourceIdMetric -met $metricName -det
    $s21 = $s2[0]
    write-host "Availabilities: $s21.MetricAvailabilities"
    
    # Notice there are no properties and name is now a LocalizableString
    write-host "Unit: $s21.Unit"
    write-host "ResourceId: $s21.ResourceId"
    write-host "Name: $s21.Name.Value"
    write-host "PrimaryAggregationType: $s21.PrimaryAggregationType"
    
    # Notice there are no BlobLocation or Location
    $s22 = $s21.MetricAvailabilities[0]
    write-host "Retention: $s22.Retention"
    write-host "Timegrain: $s22.TimeGrain"
    
    ```
    
  **Get-AzureRmMetric**
    - The metrics are now retrieved from MDM. The call and the returned records are different now.

    ```powershell
    # Old
    
    # The old syntax can be described this way: Get-AzureRmMEtric [-resourceid] string [-timeGrain] string [-detailedOutput] [-starttime string] [-endtime string] [-metricNames string [, string]*]
    # ResourceId and timeGrain are mandatory and positional
    # Other parameters are: StartTime (DateTime), EndTime (DateTime), MetricNames (array of strings), DetailedOutput (SwitchParameter).
    #   All of them are optional.
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
    
    # The new syntax can be described as follows: Get-AzureRmMetric [-resourceId] string [[-metricNames] string [, string]* [-timeGrain string] [-starttime string] [-endtime string] [-aggregationType string]] [-detailedOutput]
    # ResourceId remians mandatory and positional (position 0)
    # All the other parameters are now optional, including timeGrain (hence this is a breaking change)
    # There is a new parameter AggregationType with this values (None (default), Average, Count, Minimum, Maximum, Total)
    # MetricNames, when given, is positional (position 1) and enables the other parameters: TimeGrain, StartTime, EndTime, AggregationType
    #
    # The following two calls are now valid since resourceId remains mandatory and positional
    $s1 = Get-AzureRmMetric $resourceIdMetric -det
    $s1 = Get-AzureRmMetric -res $resourceIdMetric -det
  
    write-host "Values: $s1"
  
    # This calls now requires the argument -MetricNames to succeed. MetricName is also positional (position 1). TimeGrain becomes optional and it is only accepted if MetricNames is given.
    # If metricName is not given, no other parameter is accepted (except resourceId)
    $s2 = Get-AzureRmMetric $resourceIdMetric $metricName -time $timeGrain -det
    $s2 = Get-AzureRmMetric $resourceIdMetric $metricName -time $timeGrain -det -aggreg Maximum
    
    write-host "Values: $s2"
    
    $s21 = $s2[0]
    
    # The output shows a different structure: the name is a localizable string, and metric values is now called Data.
    # The contents of Data depend on the value of AggregationType (if given). If not given Data will contain the values for the default aggregation type which depends on the metric and how it was defined.
    write-host "Name: $s21.Name.Value"
    write-host "Unit: $s21.Unit"
    write-host "Data: $s21.Data"
    
    ```

    ## Release X.0.0

    The following cmdlets were affected this release:

    **Cmdlet 1**
    - Description of what has changed

    ```powershell
    # Old
    # Sample of how the cmdlet was previously called

    # New
    # Sample of how the cmdlet should now be called
    ```

    Note: the above sections follow the template found in the link below: 

    https://github.com/Azure/azure-powershell/blob/dev/documentation/breaking-changes/breaking-change-template.md
-->

## Current Breaking Changes