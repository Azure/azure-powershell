---
external help file:
Module Name: Az.Batch
online version: https://learn.microsoft.com/powershell/module/az.batch/new-aztaskcollection
schema: 2.0.0
---

# New-AzTaskCollection

## SYNOPSIS
Note that each Task must have a unique ID.
The Batch service may not return the\nresults for each Task in the same order the Tasks were submitted in this\nrequest.
If the server times out or the connection is closed during the\nrequest, the request may have been partially or fully processed, or not at all.\nIn such cases, the user should re-issue the request.
Note that it is up to the\nuser to correctly handle failures when re-issuing a request.
For example, you\nshould use the same Task IDs during a retry so that if the prior operation\nsucceeded, the retry will not create extra Tasks unexpectedly.
If the response\ncontains any Tasks which failed to add, a client can retry the request.
In a\nretry, it is most efficient to resubmit only Tasks that failed to add, and to\nomit Tasks that were successfully added on the first attempt.
The maximum\nlifetime of a Task from addition to completion is 180 days.
If a Task has not\ncompleted within 180 days of being added it will be terminated by the Batch\nservice and left in whatever state it was in at that time.

## SYNTAX

### CreateExpanded (Default)
```
New-AzTaskCollection -Endpoint <String> -JobId <String> -Value <IBatchTaskCreateOptions[]> [-TimeOut <Int32>]
 [-ClientRequestId <String>] [-Ocpdate <String>] [-ReturnClientRequestId] [-DefaultProfile <PSObject>]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaJsonFilePath
```
New-AzTaskCollection -Endpoint <String> -JobId <String> -JsonFilePath <String> [-TimeOut <Int32>]
 [-ClientRequestId <String>] [-Ocpdate <String>] [-ReturnClientRequestId] [-DefaultProfile <PSObject>]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaJsonString
```
New-AzTaskCollection -Endpoint <String> -JobId <String> -JsonString <String> [-TimeOut <Int32>]
 [-ClientRequestId <String>] [-Ocpdate <String>] [-ReturnClientRequestId] [-DefaultProfile <PSObject>]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Note that each Task must have a unique ID.
The Batch service may not return the\nresults for each Task in the same order the Tasks were submitted in this\nrequest.
If the server times out or the connection is closed during the\nrequest, the request may have been partially or fully processed, or not at all.\nIn such cases, the user should re-issue the request.
Note that it is up to the\nuser to correctly handle failures when re-issuing a request.
For example, you\nshould use the same Task IDs during a retry so that if the prior operation\nsucceeded, the retry will not create extra Tasks unexpectedly.
If the response\ncontains any Tasks which failed to add, a client can retry the request.
In a\nretry, it is most efficient to resubmit only Tasks that failed to add, and to\nomit Tasks that were successfully added on the first attempt.
The maximum\nlifetime of a Task from addition to completion is 180 days.
If a Task has not\ncompleted within 180 days of being added it will be terminated by the Batch\nservice and left in whatever state it was in at that time.

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

### -JobId
The ID of the Job to which the Task collection is to be added.

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

### -Value
The collection of Tasks to add.
The maximum count of Tasks is 100.
The total serialized size of this collection must be less than 1MB.
If it is greater than 1MB (for example if each Task has 100's of resource files or environment variables), the request will fail with code 'RequestBodyTooLarge' and should be retried again with fewer Tasks.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Batch.Models.IBatchTaskCreateOptions[]
Parameter Sets: CreateExpanded
Aliases:

Required: True
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

### Microsoft.Azure.PowerShell.Cmdlets.Batch.Models.IBatchCreateTaskCollectionResult

## NOTES

## RELATED LINKS

