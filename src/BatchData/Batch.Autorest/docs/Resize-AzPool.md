---
external help file:
Module Name: Az.Batch
online version: https://learn.microsoft.com/powershell/module/az.batch/resize-azpool
schema: 2.0.0
---

# Resize-AzPool

## SYNOPSIS
You can only resize a Pool when its allocation state is steady.
If the Pool is\nalready resizing, the request fails with status code 409.
When you resize a\nPool, the Pool's allocation state changes from steady to resizing.
You cannot\nresize Pools which are configured for automatic scaling.
If you try to do this,\nthe Batch service returns an error 409.
If you resize a Pool downwards, the\nBatch service chooses which Compute Nodes to remove.
To remove specific Compute\nNodes, use the Pool remove Compute Nodes API instead.

## SYNTAX

### ResizeExpanded (Default)
```
Resize-AzPool -Endpoint <String> -Id <String> [-TimeOut <Int32>] [-ClientRequestId <String>]
 [-IfMatch <String>] [-IfModifiedSince <String>] [-IfNoneMatch <String>] [-IfUnmodifiedSince <String>]
 [-Ocpdate <String>] [-ReturnClientRequestId] [-NodeDeallocationOption <String>] [-ResizeTimeout <TimeSpan>]
 [-TargetDedicatedNode <Int32>] [-TargetLowPriorityNode <Int32>] [-DefaultProfile <PSObject>] [-PassThru]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Resize
```
Resize-AzPool -Endpoint <String> -Id <String> -ResizeOption <IBatchPoolResizeOptions> [-TimeOut <Int32>]
 [-ClientRequestId <String>] [-IfMatch <String>] [-IfModifiedSince <String>] [-IfNoneMatch <String>]
 [-IfUnmodifiedSince <String>] [-Ocpdate <String>] [-ReturnClientRequestId] [-DefaultProfile <PSObject>]
 [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### ResizeViaIdentity
```
Resize-AzPool -Endpoint <String> -InputObject <IBatchIdentity> -ResizeOption <IBatchPoolResizeOptions>
 [-TimeOut <Int32>] [-ClientRequestId <String>] [-IfMatch <String>] [-IfModifiedSince <String>]
 [-IfNoneMatch <String>] [-IfUnmodifiedSince <String>] [-Ocpdate <String>] [-ReturnClientRequestId]
 [-DefaultProfile <PSObject>] [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### ResizeViaIdentityExpanded
```
Resize-AzPool -Endpoint <String> -InputObject <IBatchIdentity> [-TimeOut <Int32>] [-ClientRequestId <String>]
 [-IfMatch <String>] [-IfModifiedSince <String>] [-IfNoneMatch <String>] [-IfUnmodifiedSince <String>]
 [-Ocpdate <String>] [-ReturnClientRequestId] [-NodeDeallocationOption <String>] [-ResizeTimeout <TimeSpan>]
 [-TargetDedicatedNode <Int32>] [-TargetLowPriorityNode <Int32>] [-DefaultProfile <PSObject>] [-PassThru]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### ResizeViaJsonFilePath
```
Resize-AzPool -Endpoint <String> -Id <String> -JsonFilePath <String> [-TimeOut <Int32>]
 [-ClientRequestId <String>] [-IfMatch <String>] [-IfModifiedSince <String>] [-IfNoneMatch <String>]
 [-IfUnmodifiedSince <String>] [-Ocpdate <String>] [-ReturnClientRequestId] [-DefaultProfile <PSObject>]
 [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### ResizeViaJsonString
```
Resize-AzPool -Endpoint <String> -Id <String> -JsonString <String> [-TimeOut <Int32>]
 [-ClientRequestId <String>] [-IfMatch <String>] [-IfModifiedSince <String>] [-IfNoneMatch <String>]
 [-IfUnmodifiedSince <String>] [-Ocpdate <String>] [-ReturnClientRequestId] [-DefaultProfile <PSObject>]
 [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
You can only resize a Pool when its allocation state is steady.
If the Pool is\nalready resizing, the request fails with status code 409.
When you resize a\nPool, the Pool's allocation state changes from steady to resizing.
You cannot\nresize Pools which are configured for automatic scaling.
If you try to do this,\nthe Batch service returns an error 409.
If you resize a Pool downwards, the\nBatch service chooses which Compute Nodes to remove.
To remove specific Compute\nNodes, use the Pool remove Compute Nodes API instead.

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

### -Id
The ID of the Pool to get.

```yaml
Type: System.String
Parameter Sets: Resize, ResizeExpanded, ResizeViaJsonFilePath, ResizeViaJsonString
Aliases: PoolId

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
Parameter Sets: ResizeViaIdentity, ResizeViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Resize operation

```yaml
Type: System.String
Parameter Sets: ResizeViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Resize operation

```yaml
Type: System.String
Parameter Sets: ResizeViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NodeDeallocationOption
Determines what to do with a Compute Node and its running task(s) if the Pool size is decreasing.
The default value is requeue.

```yaml
Type: System.String
Parameter Sets: ResizeExpanded, ResizeViaIdentityExpanded
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

### -ResizeOption
Parameters for changing the size of an Azure Batch Pool.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Batch.Models.IBatchPoolResizeOptions
Parameter Sets: Resize, ResizeViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ResizeTimeout
The timeout for allocation of Nodes to the Pool or removal of Compute Nodes from the Pool.
The default value is 15 minutes.
The minimum value is 5 minutes.
If you specify a value less than 5 minutes, the Batch service returns an error; if you are calling the REST API directly, the HTTP status code is 400 (Bad Request).

```yaml
Type: System.TimeSpan
Parameter Sets: ResizeExpanded, ResizeViaIdentityExpanded
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

### -TargetDedicatedNode
The desired number of dedicated Compute Nodes in the Pool.

```yaml
Type: System.Int32
Parameter Sets: ResizeExpanded, ResizeViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TargetLowPriorityNode
The desired number of Spot/Low-priority Compute Nodes in the Pool.

```yaml
Type: System.Int32
Parameter Sets: ResizeExpanded, ResizeViaIdentityExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.Batch.Models.IBatchPoolResizeOptions

## OUTPUTS

### System.Boolean

## NOTES

## RELATED LINKS

