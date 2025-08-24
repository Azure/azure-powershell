---
external help file:
Module Name: Az.Batch
online version: https://learn.microsoft.com/powershell/module/az.batch/new-azjobschedule
schema: 2.0.0
---

# New-AzJobSchedule

## SYNOPSIS
Create a Job Schedule to the specified Account.

## SYNTAX

### CreateExpanded (Default)
```
New-AzJobSchedule -Endpoint <String> -Id <String> -JobSpecification <IBatchJobSpecification>
 [-TimeOut <Int32>] [-ClientRequestId <String>] [-Ocpdate <String>] [-ReturnClientRequestId]
 [-DisplayName <String>] [-Metadata <IBatchMetadataItem[]>] [-ScheduleDoNotRunAfter <DateTime>]
 [-ScheduleDoNotRunUntil <DateTime>] [-ScheduleRecurrenceInterval <TimeSpan>]
 [-ScheduleStartWindow <TimeSpan>] [-DefaultProfile <PSObject>] [-PassThru] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### CreateViaJsonFilePath
```
New-AzJobSchedule -Endpoint <String> -JsonFilePath <String> [-TimeOut <Int32>] [-ClientRequestId <String>]
 [-Ocpdate <String>] [-ReturnClientRequestId] [-DefaultProfile <PSObject>] [-PassThru] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### CreateViaJsonString
```
New-AzJobSchedule -Endpoint <String> -JsonString <String> [-TimeOut <Int32>] [-ClientRequestId <String>]
 [-Ocpdate <String>] [-ReturnClientRequestId] [-DefaultProfile <PSObject>] [-PassThru] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

## DESCRIPTION
Create a Job Schedule to the specified Account.

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here (remove the output block if the example doesn't have an output) }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here (remove the output block if the example doesn't have an output) }}
```

{{ Add description here }}

## PARAMETERS

### -ClientRequestId
The caller-generated request identity, in the form of a GUID with no decoration
such as curly braces, e.g.
9C4D50EE-2D56-4CD3-8152-34347DC9F2B0.

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

### -DefaultProfile
The DefaultProfile parameter is not functional.
Use the SubscriptionId parameter when available if executing the cmdlet against a different subscription.

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

### -DisplayName
The display name for the schedule.
The display name need not be unique and can contain any Unicode characters up to a maximum length of 1024.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Endpoint
Batch account endpoint (for example: https://batchaccount.eastus2.batch.azure.com).

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Id
A string that uniquely identifies the schedule within the Account.
The ID can contain any combination of alphanumeric characters including hyphens and underscores, and cannot contain more than 64 characters.
The ID is case-preserving and case-insensitive (that is, you may not have two IDs within an Account that differ only by case).

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JobSpecification
The details of the Jobs to be created on this schedule.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Batch.Models.IBatchJobSpecification
Parameter Sets: CreateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Create operation

```yaml
Type: System.String
Parameter Sets: CreateViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Create operation

```yaml
Type: System.String
Parameter Sets: CreateViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Metadata
A list of name-value pairs associated with the schedule as metadata.
The Batch service does not assign any meaning to metadata; it is solely for the use of user code.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Batch.Models.IBatchMetadataItem[]
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Ocpdate
The time the request was issued.
Client libraries typically set this to the
current system clock time; set it explicitly if you are calling the REST API
directly.

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

### -PassThru
Returns true when the command succeeds

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ReturnClientRequestId
Whether the server should return the client-request-id in the response.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ScheduleDoNotRunAfter
A time after which no Job will be created under this Job Schedule.
The schedule will move to the completed state as soon as this deadline is past and there is no active Job under this Job Schedule.
If you do not specify a doNotRunAfter time, and you are creating a recurring Job Schedule, the Job Schedule will remain active until you explicitly terminate it.

```yaml
Type: System.DateTime
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ScheduleDoNotRunUntil
The earliest time at which any Job may be created under this Job Schedule.
If you do not specify a doNotRunUntil time, the schedule becomes ready to create Jobs immediately.

```yaml
Type: System.DateTime
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ScheduleRecurrenceInterval
The time interval between the start times of two successive Jobs under the Job Schedule.
A Job Schedule can have at most one active Job under it at any given time.
Because a Job Schedule can have at most one active Job under it at any given time, if it is time to create a new Job under a Job Schedule, but the previous Job is still running, the Batch service will not create the new Job until the previous Job finishes.
If the previous Job does not finish within the startWindow period of the new recurrenceInterval, then no new Job will be scheduled for that interval.
For recurring Jobs, you should normally specify a jobManagerTask in the jobSpecification.
If you do not use jobManagerTask, you will need an external process to monitor when Jobs are created, add Tasks to the Jobs and terminate the Jobs ready for the next recurrence.
The default is that the schedule does not recur: one Job is created, within the startWindow after the doNotRunUntil time, and the schedule is complete as soon as that Job finishes.
The minimum value is 1 minute.
If you specify a lower value, the Batch service rejects the schedule with an error; if you are calling the REST API directly, the HTTP status code is 400 (Bad Request).

```yaml
Type: System.TimeSpan
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ScheduleStartWindow
The time interval, starting from the time at which the schedule indicates a Job should be created, within which a Job must be created.
If a Job is not created within the startWindow interval, then the 'opportunity' is lost; no Job will be created until the next recurrence of the schedule.
If the schedule is recurring, and the startWindow is longer than the recurrence interval, then this is equivalent to an infinite startWindow, because the Job that is 'due' in one recurrenceInterval is not carried forward into the next recurrence interval.
The default is infinite.
The minimum value is 1 minute.
If you specify a lower value, the Batch service rejects the schedule with an error; if you are calling the REST API directly, the HTTP status code is 400 (Bad Request).

```yaml
Type: System.TimeSpan
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TimeOut
The maximum time that the server can spend processing the request, in seconds.
The default is 30 seconds.
If the value is larger than 30, the default will be used instead.".

```yaml
Type: System.Int32
Parameter Sets: (All)
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

## OUTPUTS

### System.Boolean

## NOTES

## RELATED LINKS

