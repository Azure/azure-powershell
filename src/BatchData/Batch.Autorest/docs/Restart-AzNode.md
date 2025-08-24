---
external help file:
Module Name: Az.Batch
online version: https://learn.microsoft.com/powershell/module/az.batch/restart-aznode
schema: 2.0.0
---

# Restart-AzNode

## SYNOPSIS
You can restart a Compute Node only if it is in an idle or running state.

## SYNTAX

### RebootExpanded (Default)
```
Restart-AzNode -Endpoint <String> -Id <String> -PoolId <String> [-TimeOut <Int32>] [-ClientRequestId <String>]
 [-Ocpdate <String>] [-ReturnClientRequestId] [-NodeRebootKind <String>] [-DefaultProfile <PSObject>]
 [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Reboot
```
Restart-AzNode -Endpoint <String> -Id <String> -PoolId <String> -Option <IBatchNodeRebootOptions>
 [-TimeOut <Int32>] [-ClientRequestId <String>] [-Ocpdate <String>] [-ReturnClientRequestId]
 [-DefaultProfile <PSObject>] [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### RebootViaIdentity
```
Restart-AzNode -Endpoint <String> -InputObject <IBatchIdentity> -Option <IBatchNodeRebootOptions>
 [-TimeOut <Int32>] [-ClientRequestId <String>] [-Ocpdate <String>] [-ReturnClientRequestId]
 [-DefaultProfile <PSObject>] [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### RebootViaIdentityExpanded
```
Restart-AzNode -Endpoint <String> -InputObject <IBatchIdentity> [-TimeOut <Int32>] [-ClientRequestId <String>]
 [-Ocpdate <String>] [-ReturnClientRequestId] [-NodeRebootKind <String>] [-DefaultProfile <PSObject>]
 [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### RebootViaIdentityPool
```
Restart-AzNode -Endpoint <String> -Id <String> -PoolInputObject <IBatchIdentity>
 -Option <IBatchNodeRebootOptions> [-TimeOut <Int32>] [-ClientRequestId <String>] [-Ocpdate <String>]
 [-ReturnClientRequestId] [-DefaultProfile <PSObject>] [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### RebootViaIdentityPoolExpanded
```
Restart-AzNode -Endpoint <String> -Id <String> -PoolInputObject <IBatchIdentity> [-TimeOut <Int32>]
 [-ClientRequestId <String>] [-Ocpdate <String>] [-ReturnClientRequestId] [-NodeRebootKind <String>]
 [-DefaultProfile <PSObject>] [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### RebootViaJsonFilePath
```
Restart-AzNode -Endpoint <String> -Id <String> -PoolId <String> -JsonFilePath <String> [-TimeOut <Int32>]
 [-ClientRequestId <String>] [-Ocpdate <String>] [-ReturnClientRequestId] [-DefaultProfile <PSObject>]
 [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### RebootViaJsonString
```
Restart-AzNode -Endpoint <String> -Id <String> -PoolId <String> -JsonString <String> [-TimeOut <Int32>]
 [-ClientRequestId <String>] [-Ocpdate <String>] [-ReturnClientRequestId] [-DefaultProfile <PSObject>]
 [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
You can restart a Compute Node only if it is in an idle or running state.

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
The ID of the Compute Node that you want to restart.

```yaml
Type: System.String
Parameter Sets: Reboot, RebootExpanded, RebootViaIdentityPool, RebootViaIdentityPoolExpanded, RebootViaJsonFilePath, RebootViaJsonString
Aliases: NodeId

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Batch.Models.IBatchIdentity
Parameter Sets: RebootViaIdentity, RebootViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Reboot operation

```yaml
Type: System.String
Parameter Sets: RebootViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Reboot operation

```yaml
Type: System.String
Parameter Sets: RebootViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NodeRebootKind
When to reboot the Compute Node and what to do with currently running Tasks.
The default value is requeue.

```yaml
Type: System.String
Parameter Sets: RebootExpanded, RebootViaIdentityExpanded, RebootViaIdentityPoolExpanded
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

### -Option
Parameters for rebooting an Azure Batch Compute Node.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Batch.Models.IBatchNodeRebootOptions
Parameter Sets: Reboot, RebootViaIdentity, RebootViaIdentityPool
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
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
The ID of the Pool that contains the Compute Node.

```yaml
Type: System.String
Parameter Sets: Reboot, RebootExpanded, RebootViaJsonFilePath, RebootViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PoolInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Batch.Models.IBatchIdentity
Parameter Sets: RebootViaIdentityPool, RebootViaIdentityPoolExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
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

### Microsoft.Azure.PowerShell.Cmdlets.Batch.Models.IBatchNodeRebootOptions

## OUTPUTS

### System.Boolean

## NOTES

## RELATED LINKS

