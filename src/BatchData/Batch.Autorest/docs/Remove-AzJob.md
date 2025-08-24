---
external help file:
Module Name: Az.Batch
online version: https://learn.microsoft.com/powershell/module/az.batch/remove-azjob
schema: 2.0.0
---

# Remove-AzJob

## SYNOPSIS
Deleting a Job also deletes all Tasks that are part of that Job, and all Job\nstatistics.
This also overrides the retention period for Task data; that is, if\nthe Job contains Tasks which are still retained on Compute Nodes, the Batch\nservices deletes those Tasks' working directories and all their contents.
When\na Delete Job request is received, the Batch service sets the Job to the\ndeleting state.
All delete operations on a Job that is in deleting state will\nfail with status code 409 (Conflict), with additional information indicating\nthat the Job is being deleted.

## SYNTAX

### Delete (Default)
```
Remove-AzJob -Endpoint <String> -Id <String> [-Force] [-TimeOut <Int32>] [-ClientRequestId <String>]
 [-IfMatch <String>] [-IfModifiedSince <String>] [-IfNoneMatch <String>] [-IfUnmodifiedSince <String>]
 [-Ocpdate <String>] [-ReturnClientRequestId] [-DefaultProfile <PSObject>] [-PassThru] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### DeleteViaIdentity
```
Remove-AzJob -Endpoint <String> -InputObject <IBatchIdentity> [-Force] [-TimeOut <Int32>]
 [-ClientRequestId <String>] [-IfMatch <String>] [-IfModifiedSince <String>] [-IfNoneMatch <String>]
 [-IfUnmodifiedSince <String>] [-Ocpdate <String>] [-ReturnClientRequestId] [-DefaultProfile <PSObject>]
 [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Deleting a Job also deletes all Tasks that are part of that Job, and all Job\nstatistics.
This also overrides the retention period for Task data; that is, if\nthe Job contains Tasks which are still retained on Compute Nodes, the Batch\nservices deletes those Tasks' working directories and all their contents.
When\na Delete Job request is received, the Batch service sets the Job to the\ndeleting state.
All delete operations on a Job that is in deleting state will\nfail with status code 409 (Conflict), with additional information indicating\nthat the Job is being deleted.

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

### -Force
If true, the server will delete the Job even if the corresponding nodes have not fully processed the deletion.
The default value is false.

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

### -Id
The ID of the Job to delete.

```yaml
Type: System.String
Parameter Sets: Delete
Aliases: JobId

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IfMatch
An ETag value associated with the version of the resource known to the client.
The operation will be performed only if the resource's current ETag on the
service exactly matches the value specified by the client.

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

### -IfModifiedSince
A timestamp indicating the last modified time of the resource known to the
client.
The operation will be performed only if the resource on the service has
been modified since the specified time.

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

### -IfNoneMatch
An ETag value associated with the version of the resource known to the client.
The operation will be performed only if the resource's current ETag on the
service does not match the value specified by the client.

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

### -IfUnmodifiedSince
A timestamp indicating the last modified time of the resource known to the
client.
The operation will be performed only if the resource on the service has
not been modified since the specified time.

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

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Batch.Models.IBatchIdentity
Parameter Sets: DeleteViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
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

### Microsoft.Azure.PowerShell.Cmdlets.Batch.Models.IBatchIdentity

## OUTPUTS

### System.Boolean

## NOTES

## RELATED LINKS

