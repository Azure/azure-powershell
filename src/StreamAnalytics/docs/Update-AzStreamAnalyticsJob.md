---
external help file:
Module Name: Az.StreamAnalytics
online version: https://docs.microsoft.com/powershell/module/az.streamanalytics/update-azstreamanalyticsjob
schema: 2.0.0
---

# Update-AzStreamAnalyticsJob

## SYNOPSIS
Updates an existing streaming job.
This can be used to partially update (ie.
update one or two properties) a streaming job without affecting the rest the job definition.

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzStreamAnalyticsJob -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-IfMatch <String>] [-ClusterId <String>] [-CompatibilityLevel <CompatibilityLevel>]
 [-ContentStoragePolicy <ContentStoragePolicy>] [-DataLocale <String>]
 [-EventsLateArrivalMaxDelayInSecond <Int32>] [-EventsOutOfOrderMaxDelayInSecond <Int32>]
 [-EventsOutOfOrderPolicy <EventsOutOfOrderPolicy>] [-ExternalContainer <String>] [-ExternalPath <String>]
 [-Function <IFunction[]>] [-IdentityPrincipalId <String>] [-IdentityTenantId <String>]
 [-IdentityType <String>] [-Input <IInput[]>] [-JobStorageAccountAuthenticationMode <AuthenticationMode>]
 [-JobStorageAccountKey <String>] [-JobStorageAccountName <String>] [-JobType <JobType>] [-Location <String>]
 [-Output <IOutput[]>] [-OutputErrorPolicy <OutputErrorPolicy>] [-OutputStartMode <OutputStartMode>]
 [-OutputStartTime <DateTime>] [-Query <String>] [-SkuName <StreamingJobSkuName>]
 [-StorageAccountKey <String>] [-StorageAccountName <String>] [-StreamingUnit <Int32>] [-Tag <Hashtable>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Update
```
Update-AzStreamAnalyticsJob -Name <String> -ResourceGroupName <String> -StreamingJob <IStreamingJob>
 [-SubscriptionId <String>] [-IfMatch <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### UpdateViaIdentity
```
Update-AzStreamAnalyticsJob -InputObject <IStreamAnalyticsIdentity> -StreamingJob <IStreamingJob>
 [-IfMatch <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzStreamAnalyticsJob -InputObject <IStreamAnalyticsIdentity> [-IfMatch <String>] [-ClusterId <String>]
 [-CompatibilityLevel <CompatibilityLevel>] [-ContentStoragePolicy <ContentStoragePolicy>]
 [-DataLocale <String>] [-EventsLateArrivalMaxDelayInSecond <Int32>]
 [-EventsOutOfOrderMaxDelayInSecond <Int32>] [-EventsOutOfOrderPolicy <EventsOutOfOrderPolicy>]
 [-ExternalContainer <String>] [-ExternalPath <String>] [-Function <IFunction[]>]
 [-IdentityPrincipalId <String>] [-IdentityTenantId <String>] [-IdentityType <String>] [-Input <IInput[]>]
 [-JobStorageAccountAuthenticationMode <AuthenticationMode>] [-JobStorageAccountKey <String>]
 [-JobStorageAccountName <String>] [-JobType <JobType>] [-Location <String>] [-Output <IOutput[]>]
 [-OutputErrorPolicy <OutputErrorPolicy>] [-OutputStartMode <OutputStartMode>] [-OutputStartTime <DateTime>]
 [-Query <String>] [-SkuName <StreamingJobSkuName>] [-StorageAccountKey <String>]
 [-StorageAccountName <String>] [-StreamingUnit <Int32>] [-Tag <Hashtable>] [-DefaultProfile <PSObject>]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Updates an existing streaming job.
This can be used to partially update (ie.
update one or two properties) a streaming job without affecting the rest the job definition.

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
PS C:\> {{ Add code here }}

{{ Add output here }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
PS C:\> {{ Add code here }}

{{ Add output here }}
```

{{ Add description here }}

## PARAMETERS

### -ClusterId
The resource id of cluster.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CompatibilityLevel
Controls certain runtime behaviors of the streaming job.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Support.CompatibilityLevel
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ContentStoragePolicy
Valid values are JobStorageAccount and SystemAccount.
If set to JobStorageAccount, this requires the user to also specify jobStorageAccount property.
.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Support.ContentStoragePolicy
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DataLocale
The data locale of the stream analytics job.
Value should be the name of a supported .NET Culture from the set https://msdn.microsoft.com/en-us/library/system.globalization.culturetypes(v=vs.110).aspx.
Defaults to 'en-US' if none specified.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: System.Management.Automation.PSObject
Parameter Sets: (All)
Aliases: AzureRMContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EventsLateArrivalMaxDelayInSecond
The maximum tolerable delay in seconds where events arriving late could be included.
Supported range is -1 to 1814399 (20.23:59:59 days) and -1 is used to specify wait indefinitely.
If the property is absent, it is interpreted to have a value of -1.

```yaml
Type: System.Int32
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EventsOutOfOrderMaxDelayInSecond
The maximum tolerable delay in seconds where out-of-order events can be adjusted to be back in order.

```yaml
Type: System.Int32
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EventsOutOfOrderPolicy
Indicates the policy to apply to events that arrive out of order in the input event stream.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Support.EventsOutOfOrderPolicy
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ExternalContainer
.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ExternalPath
.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Function
A list of one or more functions for the streaming job.
The name property for each function is required when specifying this property in a PUT request.
This property cannot be modify via a PATCH operation.
You must use the PATCH API available for the individual transformation.
To construct, see NOTES section for FUNCTION properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IFunction[]
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IdentityPrincipalId
.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IdentityTenantId
.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IdentityType
.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IfMatch
The ETag of the streaming job.
Omit this value to always overwrite the current record set.
Specify the last-seen ETag value to prevent accidentally overwriting concurrent changes.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Input
A list of one or more inputs to the streaming job.
The name property for each input is required when specifying this property in a PUT request.
This property cannot be modify via a PATCH operation.
You must use the PATCH API available for the individual input.
To construct, see NOTES section for INPUT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IInput[]
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.IStreamAnalyticsIdentity
Parameter Sets: UpdateViaIdentity, UpdateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -JobStorageAccountAuthenticationMode
Authentication Mode.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Support.AuthenticationMode
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JobStorageAccountKey
The account key for the Azure Storage account.
Required on PUT (CreateOrReplace) requests.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JobStorageAccountName
The name of the Azure Storage account.
Required on PUT (CreateOrReplace) requests.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JobType
Describes the type of the job.
Valid modes are `Cloud` and 'Edge'.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Support.JobType
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Location
The geo-location where the resource lives

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The name of the streaming job.

```yaml
Type: System.String
Parameter Sets: Update, UpdateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Output
A list of one or more outputs for the streaming job.
The name property for each output is required when specifying this property in a PUT request.
This property cannot be modify via a PATCH operation.
You must use the PATCH API available for the individual output.
To construct, see NOTES section for OUTPUT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IOutput[]
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -OutputErrorPolicy
Indicates the policy to apply to events that arrive at the output and cannot be written to the external storage due to being malformed (missing column values, column values of wrong type or size).

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Support.OutputErrorPolicy
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -OutputStartMode
This property should only be utilized when it is desired that the job be started immediately upon creation.
Value may be JobStartTime, CustomTime, or LastOutputEventTime to indicate whether the starting point of the output event stream should start whenever the job is started, start at a custom user time stamp specified via the outputStartTime property, or start from the last event output time.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Support.OutputStartMode
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -OutputStartTime
Value is either an ISO-8601 formatted time stamp that indicates the starting point of the output event stream, or null to indicate that the output event stream will start whenever the streaming job is started.
This property must have a value if outputStartMode is set to CustomTime.

```yaml
Type: System.DateTime
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Query
Specifies the query that will be run in the streaming job.
You can learn more about the Stream Analytics Query Language (SAQL) here: https://msdn.microsoft.com/library/azure/dn834998 .
Required on PUT (CreateOrReplace) requests.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: Update, UpdateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SkuName
The name of the SKU.
Required on PUT (CreateOrReplace) requests.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Support.StreamingJobSkuName
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -StorageAccountKey
The account key for the Azure Storage account.
Required on PUT (CreateOrReplace) requests.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -StorageAccountName
The name of the Azure Storage account.
Required on PUT (CreateOrReplace) requests.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -StreamingJob
A streaming job object, containing all information associated with the named streaming job.
To construct, see NOTES section for STREAMINGJOB properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IStreamingJob
Parameter Sets: Update, UpdateViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -StreamingUnit
Specifies the number of streaming units that the streaming job uses.

```yaml
Type: System.Int32
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.

```yaml
Type: System.String
Parameter Sets: Update, UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -Tag
Resource tags.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Confirm
Prompts you for confirmation before running the cmdlet.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: cf

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WhatIf
Shows what would happen if the cmdlet runs.
The cmdlet is not run.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: wi

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IStreamingJob

### Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.IStreamAnalyticsIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IStreamingJob

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


FUNCTION <IFunction[]>: A list of one or more functions for the streaming job. The name property for each function is required when specifying this property in a PUT request. This property cannot be modify via a PATCH operation. You must use the PATCH API available for the individual transformation.
  - `[BindingType <String>]`: Indicates the function binding type.
  - `[ETag <String>]`: 
  - `[Input <IFunctionInput[]>]`: 
    - `[DataType <String>]`: The (Azure Stream Analytics supported) data type of the function input parameter. A list of valid Azure Stream Analytics data types are described at https://msdn.microsoft.com/en-us/library/azure/dn835065.aspx
    - `[IsConfigurationParameter <Boolean?>]`: A flag indicating if the parameter is a configuration parameter. True if this input parameter is expected to be a constant. Default is false.
  - `[OutputDataType <String>]`: The (Azure Stream Analytics supported) data type of the function output. A list of valid Azure Stream Analytics data types are described at https://msdn.microsoft.com/en-us/library/azure/dn835065.aspx
  - `[PropertiesType <String>]`: Indicates the type of function.

INPUT <IInput[]>: A list of one or more inputs to the streaming job. The name property for each input is required when specifying this property in a PUT request. This property cannot be modify via a PATCH operation. You must use the PATCH API available for the individual input.
  - `[CompressionType <String>]`: 
  - `[ETag <String>]`: 
  - `[PartitionKey <String>]`: partitionKey Describes a key in the input data which is used for partitioning the input data
  - `[PropertiesType <String>]`: Indicates whether the input is a source of reference data or stream data. Required on PUT (CreateOrReplace) requests.
  - `[SerializationType <EventSerializationType?>]`: Indicates the type of serialization that the input or output uses. Required on PUT (CreateOrReplace) requests.

INPUTOBJECT <IStreamAnalyticsIdentity>: Identity Parameter
  - `[ClusterName <String>]`: The name of the cluster.
  - `[FunctionName <String>]`: The name of the function.
  - `[Id <String>]`: Resource identity path
  - `[InputName <String>]`: The name of the input.
  - `[JobName <String>]`: The name of the streaming job.
  - `[Location <String>]`: The region in which to retrieve the subscription's quota information. You can find out which regions Azure Stream Analytics is supported in here: https://azure.microsoft.com/en-us/regions/
  - `[OutputName <String>]`: The name of the output.
  - `[ResourceGroupName <String>]`: The name of the resource group. The name is case insensitive.
  - `[SubscriptionId <String>]`: The ID of the target subscription.
  - `[TransformationName <String>]`: The name of the transformation.

OUTPUT <IOutput[]>: A list of one or more outputs for the streaming job. The name property for each output is required when specifying this property in a PUT request. This property cannot be modify via a PATCH operation. You must use the PATCH API available for the individual output.
  - `[DatasourceType <String>]`: Indicates the type of data source output will be written to. Required on PUT (CreateOrReplace) requests.
  - `[ETag <String>]`: 
  - `[SerializationType <EventSerializationType?>]`: Indicates the type of serialization that the input or output uses. Required on PUT (CreateOrReplace) requests.
  - `[SizeWindow <Single?>]`: 
  - `[TimeWindow <String>]`: 

STREAMINGJOB <IStreamingJob>: A streaming job object, containing all information associated with the named streaming job.
  - `[Location <String>]`: The geo-location where the resource lives
  - `[Tag <ITrackedResourceTags>]`: Resource tags.
    - `[(Any) <String>]`: This indicates any property can be added to this object.
  - `[ClusterId <String>]`: The resource id of cluster.
  - `[CompatibilityLevel <CompatibilityLevel?>]`: Controls certain runtime behaviors of the streaming job.
  - `[ContentStoragePolicy <ContentStoragePolicy?>]`: Valid values are JobStorageAccount and SystemAccount. If set to JobStorageAccount, this requires the user to also specify jobStorageAccount property. .
  - `[DataLocale <String>]`: The data locale of the stream analytics job. Value should be the name of a supported .NET Culture from the set https://msdn.microsoft.com/en-us/library/system.globalization.culturetypes(v=vs.110).aspx. Defaults to 'en-US' if none specified.
  - `[ETag <String>]`: 
  - `[EventsLateArrivalMaxDelayInSecond <Int32?>]`: The maximum tolerable delay in seconds where events arriving late could be included.  Supported range is -1 to 1814399 (20.23:59:59 days) and -1 is used to specify wait indefinitely. If the property is absent, it is interpreted to have a value of -1.
  - `[EventsOutOfOrderMaxDelayInSecond <Int32?>]`: The maximum tolerable delay in seconds where out-of-order events can be adjusted to be back in order.
  - `[EventsOutOfOrderPolicy <EventsOutOfOrderPolicy?>]`: Indicates the policy to apply to events that arrive out of order in the input event stream.
  - `[ExternalContainer <String>]`: 
  - `[ExternalPath <String>]`: 
  - `[Function <IFunction[]>]`: A list of one or more functions for the streaming job. The name property for each function is required when specifying this property in a PUT request. This property cannot be modify via a PATCH operation. You must use the PATCH API available for the individual transformation.
    - `[BindingType <String>]`: Indicates the function binding type.
    - `[ETag <String>]`: 
    - `[Input <IFunctionInput[]>]`: 
      - `[DataType <String>]`: The (Azure Stream Analytics supported) data type of the function input parameter. A list of valid Azure Stream Analytics data types are described at https://msdn.microsoft.com/en-us/library/azure/dn835065.aspx
      - `[IsConfigurationParameter <Boolean?>]`: A flag indicating if the parameter is a configuration parameter. True if this input parameter is expected to be a constant. Default is false.
    - `[OutputDataType <String>]`: The (Azure Stream Analytics supported) data type of the function output. A list of valid Azure Stream Analytics data types are described at https://msdn.microsoft.com/en-us/library/azure/dn835065.aspx
    - `[PropertiesType <String>]`: Indicates the type of function.
  - `[IdentityPrincipalId <String>]`: 
  - `[IdentityTenantId <String>]`: 
  - `[IdentityType <String>]`: 
  - `[Input <IInput[]>]`: A list of one or more inputs to the streaming job. The name property for each input is required when specifying this property in a PUT request. This property cannot be modify via a PATCH operation. You must use the PATCH API available for the individual input.
    - `[CompressionType <String>]`: 
    - `[ETag <String>]`: 
    - `[PartitionKey <String>]`: partitionKey Describes a key in the input data which is used for partitioning the input data
    - `[PropertiesType <String>]`: Indicates whether the input is a source of reference data or stream data. Required on PUT (CreateOrReplace) requests.
    - `[SerializationType <EventSerializationType?>]`: Indicates the type of serialization that the input or output uses. Required on PUT (CreateOrReplace) requests.
  - `[JobStorageAccountAuthenticationMode <AuthenticationMode?>]`: Authentication Mode.
  - `[JobStorageAccountKey <String>]`: The account key for the Azure Storage account. Required on PUT (CreateOrReplace) requests.
  - `[JobStorageAccountName <String>]`: The name of the Azure Storage account. Required on PUT (CreateOrReplace) requests.
  - `[JobType <JobType?>]`: Describes the type of the job. Valid modes are `Cloud` and 'Edge'.
  - `[Output <IOutput[]>]`: A list of one or more outputs for the streaming job. The name property for each output is required when specifying this property in a PUT request. This property cannot be modify via a PATCH operation. You must use the PATCH API available for the individual output.
    - `[DatasourceType <String>]`: Indicates the type of data source output will be written to. Required on PUT (CreateOrReplace) requests.
    - `[ETag <String>]`: 
    - `[SerializationType <EventSerializationType?>]`: Indicates the type of serialization that the input or output uses. Required on PUT (CreateOrReplace) requests.
    - `[SizeWindow <Single?>]`: 
    - `[TimeWindow <String>]`: 
  - `[OutputErrorPolicy <OutputErrorPolicy?>]`: Indicates the policy to apply to events that arrive at the output and cannot be written to the external storage due to being malformed (missing column values, column values of wrong type or size).
  - `[OutputStartMode <OutputStartMode?>]`: This property should only be utilized when it is desired that the job be started immediately upon creation. Value may be JobStartTime, CustomTime, or LastOutputEventTime to indicate whether the starting point of the output event stream should start whenever the job is started, start at a custom user time stamp specified via the outputStartTime property, or start from the last event output time.
  - `[OutputStartTime <DateTime?>]`: Value is either an ISO-8601 formatted time stamp that indicates the starting point of the output event stream, or null to indicate that the output event stream will start whenever the streaming job is started. This property must have a value if outputStartMode is set to CustomTime.
  - `[Query <String>]`: Specifies the query that will be run in the streaming job. You can learn more about the Stream Analytics Query Language (SAQL) here: https://msdn.microsoft.com/library/azure/dn834998 . Required on PUT (CreateOrReplace) requests.
  - `[SkuName <StreamingJobSkuName?>]`: The name of the SKU. Required on PUT (CreateOrReplace) requests.
  - `[StorageAccountKey <String>]`: The account key for the Azure Storage account. Required on PUT (CreateOrReplace) requests.
  - `[StorageAccountName <String>]`: The name of the Azure Storage account. Required on PUT (CreateOrReplace) requests.
  - `[StreamingUnit <Int32?>]`: Specifies the number of streaming units that the streaming job uses.
  - `[TransformationETag <String>]`: 

## RELATED LINKS

