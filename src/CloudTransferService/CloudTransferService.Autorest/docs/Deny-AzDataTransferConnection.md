---
external help file:
Module Name: Az.AzzDataTransfer
online version: https://learn.microsoft.com/powershell/module/az.azzdatatransfer/deny-azdatatransferconnection
schema: 2.0.0
---

# Deny-AzDataTransferConnection

## SYNOPSIS
Rejects the specified connection in a pipeline.

## SYNTAX

### RejectExpanded (Default)
```
Deny-AzDataTransferConnection -PipelineName <String> -ResourceGroupName <String> -Id <String>
 [-SubscriptionId <String>] [-StatusReason <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Reject
```
Deny-AzDataTransferConnection -PipelineName <String> -ResourceGroupName <String> -Connection <IResourceBody>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### Reject1
```
Deny-AzDataTransferConnection -PipelineName <String> -ResourceGroupName <String> -Connection <IResourceBody>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### RejectExpanded1
```
Deny-AzDataTransferConnection -PipelineName <String> -ResourceGroupName <String> -Id <String>
 [-SubscriptionId <String>] [-StatusReason <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### RejectViaIdentity
```
Deny-AzDataTransferConnection -InputObject <IAzzDataTransferIdentity> -Connection <IResourceBody>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### RejectViaIdentity1
```
Deny-AzDataTransferConnection -InputObject <IAzzDataTransferIdentity> -Connection <IResourceBody>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### RejectViaIdentityExpanded
```
Deny-AzDataTransferConnection -InputObject <IAzzDataTransferIdentity> -Id <String> [-StatusReason <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### RejectViaIdentityExpanded1
```
Deny-AzDataTransferConnection -InputObject <IAzzDataTransferIdentity> -Id <String> [-StatusReason <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### RejectViaJsonFilePath
```
Deny-AzDataTransferConnection -PipelineName <String> -ResourceGroupName <String> -JsonFilePath <String>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### RejectViaJsonFilePath1
```
Deny-AzDataTransferConnection -PipelineName <String> -ResourceGroupName <String> -JsonFilePath <String>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### RejectViaJsonString
```
Deny-AzDataTransferConnection -PipelineName <String> -ResourceGroupName <String> -JsonString <String>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### RejectViaJsonString1
```
Deny-AzDataTransferConnection -PipelineName <String> -ResourceGroupName <String> -JsonString <String>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

## DESCRIPTION
Rejects the specified connection in a pipeline.

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

### -AsJob
Run the command as a job

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

### -Connection
The resource to reference.

```yaml
Type: PrivateADT.Models.IResourceBody
Parameter Sets: Reject, Reject1, RejectViaIdentity, RejectViaIdentity1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
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

### -Id
ID of the resource.

```yaml
Type: System.String
Parameter Sets: RejectExpanded, RejectExpanded1, RejectViaIdentityExpanded, RejectViaIdentityExpanded1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Identity Parameter

```yaml
Type: PrivateADT.Models.IAzzDataTransferIdentity
Parameter Sets: RejectViaIdentity, RejectViaIdentity1, RejectViaIdentityExpanded, RejectViaIdentityExpanded1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Reject operation

```yaml
Type: System.String
Parameter Sets: RejectViaJsonFilePath, RejectViaJsonFilePath1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Reject operation

```yaml
Type: System.String
Parameter Sets: RejectViaJsonString, RejectViaJsonString1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NoWait
Run the command asynchronously

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

### -PipelineName
The name for the pipeline that is to be requested.

```yaml
Type: System.String
Parameter Sets: Reject, Reject1, RejectExpanded, RejectExpanded1, RejectViaJsonFilePath, RejectViaJsonFilePath1, RejectViaJsonString, RejectViaJsonString1
Aliases:

Required: True
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
Parameter Sets: Reject, Reject1, RejectExpanded, RejectExpanded1, RejectViaJsonFilePath, RejectViaJsonFilePath1, RejectViaJsonString, RejectViaJsonString1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -StatusReason
Reason for resource operation.

```yaml
Type: System.String
Parameter Sets: RejectExpanded, RejectExpanded1, RejectViaIdentityExpanded, RejectViaIdentityExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.
The value must be an UUID.

```yaml
Type: System.String
Parameter Sets: Reject, Reject1, RejectExpanded, RejectExpanded1, RejectViaJsonFilePath, RejectViaJsonFilePath1, RejectViaJsonString, RejectViaJsonString1
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

### PrivateADT.Models.IAzzDataTransferIdentity

### PrivateADT.Models.IResourceBody

## OUTPUTS

### PrivateADT.Models.IConnection

## NOTES

## RELATED LINKS

