---
external help file:
Module Name: Az.Batch
online version: https://learn.microsoft.com/powershell/module/az.batch/remove-azpoolnode
schema: 2.0.0
---

# Remove-AzPoolNode

## SYNOPSIS
This operation can only run when the allocation state of the Pool is steady.\nWhen this operation runs, the allocation state changes from steady to resizing.\nEach request may remove up to 100 nodes.

## SYNTAX

### RemoveExpanded (Default)
```
Remove-AzPoolNode -Endpoint <String> -PoolId <String> -NodeId <String[]> [-TimeOut <Int32>]
 [-ClientRequestId <String>] [-IfMatch <String>] [-IfModifiedSince <String>] [-IfNoneMatch <String>]
 [-IfUnmodifiedSince <String>] [-Ocpdate <String>] [-ReturnClientRequestId] [-NodeDeallocationOption <String>]
 [-ResizeTimeout <TimeSpan>] [-DefaultProfile <PSObject>] [-PassThru] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### Remove
```
Remove-AzPoolNode -Endpoint <String> -PoolId <String> -RemoveOption <IBatchNodeRemoveOptions>
 [-TimeOut <Int32>] [-ClientRequestId <String>] [-IfMatch <String>] [-IfModifiedSince <String>]
 [-IfNoneMatch <String>] [-IfUnmodifiedSince <String>] [-Ocpdate <String>] [-ReturnClientRequestId]
 [-DefaultProfile <PSObject>] [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### RemoveViaIdentity
```
Remove-AzPoolNode -Endpoint <String> -InputObject <IBatchIdentity> -RemoveOption <IBatchNodeRemoveOptions>
 [-TimeOut <Int32>] [-ClientRequestId <String>] [-IfMatch <String>] [-IfModifiedSince <String>]
 [-IfNoneMatch <String>] [-IfUnmodifiedSince <String>] [-Ocpdate <String>] [-ReturnClientRequestId]
 [-DefaultProfile <PSObject>] [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### RemoveViaIdentityExpanded
```
Remove-AzPoolNode -Endpoint <String> -InputObject <IBatchIdentity> -NodeId <String[]> [-TimeOut <Int32>]
 [-ClientRequestId <String>] [-IfMatch <String>] [-IfModifiedSince <String>] [-IfNoneMatch <String>]
 [-IfUnmodifiedSince <String>] [-Ocpdate <String>] [-ReturnClientRequestId] [-NodeDeallocationOption <String>]
 [-ResizeTimeout <TimeSpan>] [-DefaultProfile <PSObject>] [-PassThru] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### RemoveViaJsonFilePath
```
Remove-AzPoolNode -Endpoint <String> -PoolId <String> -JsonFilePath <String> [-TimeOut <Int32>]
 [-ClientRequestId <String>] [-IfMatch <String>] [-IfModifiedSince <String>] [-IfNoneMatch <String>]
 [-IfUnmodifiedSince <String>] [-Ocpdate <String>] [-ReturnClientRequestId] [-DefaultProfile <PSObject>]
 [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### RemoveViaJsonString
```
Remove-AzPoolNode -Endpoint <String> -PoolId <String> -JsonString <String> [-TimeOut <Int32>]
 [-ClientRequestId <String>] [-IfMatch <String>] [-IfModifiedSince <String>] [-IfNoneMatch <String>]
 [-IfUnmodifiedSince <String>] [-Ocpdate <String>] [-ReturnClientRequestId] [-DefaultProfile <PSObject>]
 [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
This operation can only run when the allocation state of the Pool is steady.\nWhen this operation runs, the allocation state changes from steady to resizing.\nEach request may remove up to 100 nodes.

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
Parameter Sets: RemoveViaIdentity, RemoveViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Remove operation

```yaml
Type: System.String
Parameter Sets: RemoveViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Remove operation

```yaml
Type: System.String
Parameter Sets: RemoveViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NodeDeallocationOption
Determines what to do with a Compute Node and its running task(s) after it has been selected for deallocation.
The default value is requeue.

```yaml
Type: System.String
Parameter Sets: RemoveExpanded, RemoveViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NodeId
A list containing the IDs of the Compute Nodes to be removed from the specified Pool.
A maximum of 100 nodes may be removed per request.

```yaml
Type: System.String[]
Parameter Sets: RemoveExpanded, RemoveViaIdentityExpanded
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

### -PoolId
The ID of the Pool to get.

```yaml
Type: System.String
Parameter Sets: Remove, RemoveExpanded, RemoveViaJsonFilePath, RemoveViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RemoveOption
Parameters for removing nodes from an Azure Batch Pool.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Batch.Models.IBatchNodeRemoveOptions
Parameter Sets: Remove, RemoveViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ResizeTimeout
The timeout for removal of Compute Nodes to the Pool.
The default value is 15 minutes.
The minimum value is 5 minutes.
If you specify a value less than 5 minutes, the Batch service returns an error; if you are calling the REST API directly, the HTTP status code is 400 (Bad Request).

```yaml
Type: System.TimeSpan
Parameter Sets: RemoveExpanded, RemoveViaIdentityExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.Batch.Models.IBatchNodeRemoveOptions

## OUTPUTS

### System.Boolean

## NOTES

## RELATED LINKS

