---
external help file: Az.Websites-help.xml
Module Name: Az.Websites
online version: https://learn.microsoft.com/powershell/module/az.websites/get-azwebappslottriggeredwebjobhistory
schema: 2.0.0
---

# Get-AzWebAppSlotTriggeredWebJobHistory

## SYNOPSIS
Get or list triggered web job's history for a deployment slot.

## SYNTAX

### List (Default)
```
Get-AzWebAppSlotTriggeredWebJobHistory -AppName <String> -Name <String> -ResourceGroupName <String>
 -SlotName <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [-PassThru]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### Get
```
Get-AzWebAppSlotTriggeredWebJobHistory -AppName <String> -Id <String> -Name <String>
 -ResourceGroupName <String> -SlotName <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [-PassThru] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzWebAppSlotTriggeredWebJobHistory -InputObject <IWebsitesIdentity> [-DefaultProfile <PSObject>]
 [-PassThru] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
Get or list triggered web job's history for a deployment slot.

## EXAMPLES

### Example 1: List triggered web job's history for a deployment slot
```powershell
Get-AzWebAppSlotTriggeredWebJobHistory -ResourceGroupName webjob-rg-test -AppName appService-test01 -SlotName slot01 -Name slottriggeredjob-03
```

```output
Kind Name                                                            ResourceGroupName
---- ----                                                            -----------------
     appService-test01/slot01/slottriggeredjob-03/202201040202032401 webjob-rg-test
```

This command list triggered web job's history for a deployment slot.

### Example 2: Get triggered web job's history for a deployment slot
```powershell
Get-AzWebAppSlotTriggeredWebJobHistory -ResourceGroupName webjob-rg-test -AppName appService-test01 -SlotName slot01 -Name slottriggeredjob-03 -Id 202201040202032401
```

```output
Kind Name                                                            ResourceGroupName
---- ----                                                            -----------------
     appService-test01/slot01/slottriggeredjob-03/202201040202032401 webjob-rg-test
```

This command get triggered web job's history for a deployment slot.

### Example 3: Get triggered web job's history for a deployment slot by pipeline
```powershell
$jobs = Get-AzWebAppSlotTriggeredWebJobHistory -ResourceGroupName webjob-rg-test -AppName appService-test01 -SlotName slot01 -Name slottriggeredjob-03
$jobs[0].Id | Get-AzWebAppSlotTriggeredWebJobHistory
```

```output
Kind Name                                                            ResourceGroupName
---- ----                                                            -----------------
     appService-test01/slot01/slottriggeredjob-03/202201040202032401 webjob-rg-test
```

This command get triggered web job's history for a deployment slot by pipeline.

## PARAMETERS

### -AppName
Site name.

```yaml
Type: System.String
Parameter Sets: List, Get
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

### -Id
History ID.

```yaml
Type: System.String
Parameter Sets: Get
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.IWebsitesIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
Name of Web Job.

```yaml
Type: System.String
Parameter Sets: List, Get
Aliases:

Required: True
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

### -ProgressAction
{{ Fill ProgressAction Description }}

```yaml
Type: System.Management.Automation.ActionPreference
Parameter Sets: (All)
Aliases: proga

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
Name of the resource group to which the resource belongs.

```yaml
Type: System.String
Parameter Sets: List, Get
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SlotName
Name of the deployment slot.
If a slot is not specified, the API uses the production slot.

```yaml
Type: System.String
Parameter Sets: List, Get
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
Your Azure subscription ID.
This is a GUID-formatted string (e.g.
00000000-0000-0000-0000-000000000000).

```yaml
Type: System.String[]
Parameter Sets: List, Get
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.IWebsitesIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20210201.ITriggeredJobHistory

## NOTES

## RELATED LINKS
