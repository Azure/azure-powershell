---
external help file:
Module Name: Az.StreamAnalytics
online version: https://docs.microsoft.com/powershell/module/az.streamanalytics/update-azstreamanalyticsinput
schema: 2.0.0
---

# Update-AzStreamAnalyticsInput

## SYNOPSIS
Updates an existing input under an existing streaming job.
This can be used to partially update (ie.
update one or two properties) an input without affecting the rest the job or input definition.

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzStreamAnalyticsInput -JobName <String> -Name <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] [-IfMatch <String>] [-CompressionType <String>] [-PartitionKey <String>]
 [-PropertiesType <String>] [-SerializationType <EventSerializationType>] [-DefaultProfile <PSObject>]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Update
```
Update-AzStreamAnalyticsInput -JobName <String> -Name <String> -ResourceGroupName <String> -Input <IInput>
 [-SubscriptionId <String>] [-IfMatch <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### UpdateViaIdentity
```
Update-AzStreamAnalyticsInput -InputObject <IStreamAnalyticsIdentity> -Input <IInput> [-IfMatch <String>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzStreamAnalyticsInput -InputObject <IStreamAnalyticsIdentity> [-IfMatch <String>]
 [-CompressionType <String>] [-PartitionKey <String>] [-PropertiesType <String>]
 [-SerializationType <EventSerializationType>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

## DESCRIPTION
Updates an existing input under an existing streaming job.
This can be used to partially update (ie.
update one or two properties) an input without affecting the rest the job or input definition.

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

### -CompressionType
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

### -IfMatch
The ETag of the input.
Omit this value to always overwrite the current input.
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
An input object, containing all information associated with the named input.
All inputs are contained under a streaming job.
To construct, see NOTES section for INPUT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IInput
Parameter Sets: Update, UpdateViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
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

### -JobName
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

### -Name
The name of the input.

```yaml
Type: System.String
Parameter Sets: Update, UpdateExpanded
Aliases: InputName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PartitionKey
partitionKey Describes a key in the input data which is used for partitioning the input data

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

### -PropertiesType
Indicates whether the input is a source of reference data or stream data.
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

### -SerializationType
Indicates the type of serialization that the input or output uses.
Required on PUT (CreateOrReplace) requests.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Support.EventSerializationType
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

### Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IInput

### Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.IStreamAnalyticsIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IInput

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


INPUT <IInput>: An input object, containing all information associated with the named input. All inputs are contained under a streaming job.
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

## RELATED LINKS

