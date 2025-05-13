---
external help file:
Module Name: Az.AzzDataTransfer
online version: https://learn.microsoft.com/powershell/module/az.azzdatatransfer/invoke-azdatatransferlinkpendingflow
schema: 2.0.0
---

# Invoke-AzDataTransferLinkPendingFlow

## SYNOPSIS
Links the specified flow.

## SYNTAX

### LinkExpanded (Default)
```
Invoke-AzDataTransferLinkPendingFlow -ConnectionName <String> -FlowName <String> -ResourceGroupName <String>
 -Id <String> [-SubscriptionId <String>] [-StatusReason <String>] [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Link
```
Invoke-AzDataTransferLinkPendingFlow -ConnectionName <String> -FlowName <String> -ResourceGroupName <String>
 -Flow <IResourceBody> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### Link1
```
Invoke-AzDataTransferLinkPendingFlow -ConnectionName <String> -FlowName <String> -ResourceGroupName <String>
 -Flow <IResourceBody> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### LinkExpanded1
```
Invoke-AzDataTransferLinkPendingFlow -ConnectionName <String> -FlowName <String> -ResourceGroupName <String>
 -Id <String> [-SubscriptionId <String>] [-StatusReason <String>] [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### LinkViaIdentity
```
Invoke-AzDataTransferLinkPendingFlow -InputObject <IAzzDataTransferIdentity> -Flow <IResourceBody>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### LinkViaIdentity1
```
Invoke-AzDataTransferLinkPendingFlow -InputObject <IAzzDataTransferIdentity> -Flow <IResourceBody>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### LinkViaIdentityConnection
```
Invoke-AzDataTransferLinkPendingFlow -ConnectionInputObject <IAzzDataTransferIdentity> -FlowName <String>
 -Flow <IResourceBody> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### LinkViaIdentityConnection1
```
Invoke-AzDataTransferLinkPendingFlow -Connection1InputObject <IAzzDataTransferIdentity> -FlowName <String>
 -Flow <IResourceBody> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### LinkViaIdentityConnectionExpanded
```
Invoke-AzDataTransferLinkPendingFlow -ConnectionInputObject <IAzzDataTransferIdentity> -FlowName <String>
 -Id <String> [-StatusReason <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### LinkViaIdentityConnectionExpanded1
```
Invoke-AzDataTransferLinkPendingFlow -ConnectionInputObject <IAzzDataTransferIdentity> -FlowName <String>
 -Id <String> [-StatusReason <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### LinkViaIdentityExpanded
```
Invoke-AzDataTransferLinkPendingFlow -InputObject <IAzzDataTransferIdentity> -Id <String>
 [-StatusReason <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### LinkViaIdentityExpanded1
```
Invoke-AzDataTransferLinkPendingFlow -InputObject <IAzzDataTransferIdentity> -Id <String>
 [-StatusReason <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### LinkViaJsonFilePath
```
Invoke-AzDataTransferLinkPendingFlow -ConnectionName <String> -FlowName <String> -ResourceGroupName <String>
 -JsonFilePath <String> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### LinkViaJsonFilePath1
```
Invoke-AzDataTransferLinkPendingFlow -ConnectionName <String> -FlowName <String> -ResourceGroupName <String>
 -JsonFilePath <String> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### LinkViaJsonString
```
Invoke-AzDataTransferLinkPendingFlow -ConnectionName <String> -FlowName <String> -ResourceGroupName <String>
 -JsonString <String> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### LinkViaJsonString1
```
Invoke-AzDataTransferLinkPendingFlow -ConnectionName <String> -FlowName <String> -ResourceGroupName <String>
 -JsonString <String> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Links the specified flow.

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

### -Connection1InputObject
Identity Parameter

```yaml
Type: PrivateADT.Models.IAzzDataTransferIdentity
Parameter Sets: LinkViaIdentityConnection1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ConnectionInputObject
Identity Parameter

```yaml
Type: PrivateADT.Models.IAzzDataTransferIdentity
Parameter Sets: LinkViaIdentityConnection, LinkViaIdentityConnectionExpanded, LinkViaIdentityConnectionExpanded1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ConnectionName
The name for the connection that is to be requested.

```yaml
Type: System.String
Parameter Sets: Link, Link1, LinkExpanded, LinkExpanded1, LinkViaJsonFilePath, LinkViaJsonFilePath1, LinkViaJsonString, LinkViaJsonString1
Aliases:

Required: True
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

### -Flow
The resource to reference.

```yaml
Type: PrivateADT.Models.IResourceBody
Parameter Sets: Link, Link1, LinkViaIdentity, LinkViaIdentity1, LinkViaIdentityConnection, LinkViaIdentityConnection1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -FlowName
The name for the flow that is to be onboarded.

```yaml
Type: System.String
Parameter Sets: Link, Link1, LinkExpanded, LinkExpanded1, LinkViaIdentityConnection, LinkViaIdentityConnection1, LinkViaIdentityConnectionExpanded, LinkViaIdentityConnectionExpanded1, LinkViaJsonFilePath, LinkViaJsonFilePath1, LinkViaJsonString, LinkViaJsonString1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Id
ID of the resource.

```yaml
Type: System.String
Parameter Sets: LinkExpanded, LinkExpanded1, LinkViaIdentityConnectionExpanded, LinkViaIdentityConnectionExpanded1, LinkViaIdentityExpanded, LinkViaIdentityExpanded1
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
Parameter Sets: LinkViaIdentity, LinkViaIdentity1, LinkViaIdentityExpanded, LinkViaIdentityExpanded1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Link operation

```yaml
Type: System.String
Parameter Sets: LinkViaJsonFilePath, LinkViaJsonFilePath1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Link operation

```yaml
Type: System.String
Parameter Sets: LinkViaJsonString, LinkViaJsonString1
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

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: Link, Link1, LinkExpanded, LinkExpanded1, LinkViaJsonFilePath, LinkViaJsonFilePath1, LinkViaJsonString, LinkViaJsonString1
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
Parameter Sets: LinkExpanded, LinkExpanded1, LinkViaIdentityConnectionExpanded, LinkViaIdentityConnectionExpanded1, LinkViaIdentityExpanded, LinkViaIdentityExpanded1
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
Parameter Sets: Link, Link1, LinkExpanded, LinkExpanded1, LinkViaJsonFilePath, LinkViaJsonFilePath1, LinkViaJsonString, LinkViaJsonString1
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

### PrivateADT.Models.IFlow

## NOTES

## RELATED LINKS

