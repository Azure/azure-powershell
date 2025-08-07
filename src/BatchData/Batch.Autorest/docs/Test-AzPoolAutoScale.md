---
external help file:
Module Name: Az.Batch
online version: https://learn.microsoft.com/powershell/module/az.batch/test-azpoolautoscale
schema: 2.0.0
---

# Test-AzPoolAutoScale

## SYNOPSIS
This API is primarily for validating an autoscale formula, as it simply returns\nthe result without applying the formula to the Pool.
The Pool must have auto\nscaling enabled in order to evaluate a formula.

## SYNTAX

### EvaluateExpanded (Default)
```
Test-AzPoolAutoScale -Endpoint <String> -PoolId <String> -AutoScaleFormula <String> [-TimeOut <Int32>]
 [-ClientRequestId <String>] [-Ocpdate <String>] [-ReturnClientRequestId] [-DefaultProfile <PSObject>]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Evaluate
```
Test-AzPoolAutoScale -Endpoint <String> -PoolId <String>
 -EvaluateAutoScaleOption <IBatchPoolEvaluateAutoScaleOptions> [-TimeOut <Int32>] [-ClientRequestId <String>]
 [-Ocpdate <String>] [-ReturnClientRequestId] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### EvaluateViaIdentity
```
Test-AzPoolAutoScale -Endpoint <String> -InputObject <IBatchIdentity>
 -EvaluateAutoScaleOption <IBatchPoolEvaluateAutoScaleOptions> [-TimeOut <Int32>] [-ClientRequestId <String>]
 [-Ocpdate <String>] [-ReturnClientRequestId] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### EvaluateViaIdentityExpanded
```
Test-AzPoolAutoScale -Endpoint <String> -InputObject <IBatchIdentity> -AutoScaleFormula <String>
 [-TimeOut <Int32>] [-ClientRequestId <String>] [-Ocpdate <String>] [-ReturnClientRequestId]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### EvaluateViaJsonFilePath
```
Test-AzPoolAutoScale -Endpoint <String> -PoolId <String> -JsonFilePath <String> [-TimeOut <Int32>]
 [-ClientRequestId <String>] [-Ocpdate <String>] [-ReturnClientRequestId] [-DefaultProfile <PSObject>]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### EvaluateViaJsonString
```
Test-AzPoolAutoScale -Endpoint <String> -PoolId <String> -JsonString <String> [-TimeOut <Int32>]
 [-ClientRequestId <String>] [-Ocpdate <String>] [-ReturnClientRequestId] [-DefaultProfile <PSObject>]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
This API is primarily for validating an autoscale formula, as it simply returns\nthe result without applying the formula to the Pool.
The Pool must have auto\nscaling enabled in order to evaluate a formula.

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

### -AutoScaleFormula
The formula for the desired number of Compute Nodes in the Pool.
The formula is validated and its results calculated, but it is not applied to the Pool.
To apply the formula to the Pool, 'Enable automatic scaling on a Pool'.
For more information about specifying this formula, see Automatically scale Compute Nodes in an Azure Batch Pool (https://learn.microsoft.com/azure/batch/batch-automatic-scaling).

```yaml
Type: System.String
Parameter Sets: EvaluateExpanded, EvaluateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

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

### -EvaluateAutoScaleOption
Parameters for evaluating an automatic scaling formula on an Azure Batch Pool.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Batch.Models.IBatchPoolEvaluateAutoScaleOptions
Parameter Sets: Evaluate, EvaluateViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Batch.Models.IBatchIdentity
Parameter Sets: EvaluateViaIdentity, EvaluateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Evaluate operation

```yaml
Type: System.String
Parameter Sets: EvaluateViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Evaluate operation

```yaml
Type: System.String
Parameter Sets: EvaluateViaJsonString
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

### -PoolId
The ID of the Pool on which to evaluate the automatic scaling formula.

```yaml
Type: System.String
Parameter Sets: Evaluate, EvaluateExpanded, EvaluateViaJsonFilePath, EvaluateViaJsonString
Aliases:

Required: True
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

### Microsoft.Azure.PowerShell.Cmdlets.Batch.Models.IBatchPoolEvaluateAutoScaleOptions

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Batch.Models.IAutoScaleRun

## NOTES

## RELATED LINKS

