---
external help file:
Module Name: Az.Cdn
online version: https://learn.microsoft.com/powershell/module/az.cdn/update-azcdnedgeactionexecutionfilter
schema: 2.0.0
---

# Update-AzCdnEdgeActionExecutionFilter

## SYNOPSIS
Update EdgeActionExecutionFilter resource

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzCdnEdgeActionExecutionFilter -EdgeActionName <String> -ExecutionFilter <String>
 -ResourceGroupName <String> [-SubscriptionId <String>] [-ExecutionFilterIdentifierHeaderName <String>]
 [-ExecutionFilterIdentifierHeaderValue <String>] [-Tag <Hashtable>] [-VersionId <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaJsonFilePath
```
Update-AzCdnEdgeActionExecutionFilter -EdgeActionName <String> -ExecutionFilter <String>
 -ResourceGroupName <String> -JsonFilePath <String> [-SubscriptionId <String>] [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaJsonString
```
Update-AzCdnEdgeActionExecutionFilter -EdgeActionName <String> -ExecutionFilter <String>
 -ResourceGroupName <String> -JsonString <String> [-SubscriptionId <String>] [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Update EdgeActionExecutionFilter resource

## EXAMPLES

### Example 1: Update Edge Action Execution Filter with JSON string
```powershell
$jsonString = '{"properties":{"filterType":"response","conditions":[{"operator":"Equal","matchValues":["text/html"]}]}}'
Update-AzCdnEdgeActionExecutionFilter -ResourceGroupName testps-rg-da16jm -EdgeActionName edgeaction001 -Name filter001 -JsonString $jsonString
```

```output
Name      ResourceGroupName EdgeActionName
----      ----------------- --------------
filter001 testps-rg-da16jm  edgeaction001
```

Update an Edge Action Execution Filter using JSON string configuration

### Example 2: Update Edge Action Execution Filter from JSON file
```powershell
Update-AzCdnEdgeActionExecutionFilter -ResourceGroupName testps-rg-da16jm -EdgeActionName edgeaction001 -Name filter001 -JsonFilePath "C:\config\execution-filter.json"
```

```output
Name      ResourceGroupName EdgeActionName
----      ----------------- --------------
filter001 testps-rg-da16jm  edgeaction001
```

Update an Edge Action Execution Filter using configuration from a JSON file

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

### -EdgeActionName
The name of the Edge Action

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

### -ExecutionFilter
The name of the execution filter

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

### -ExecutionFilterIdentifierHeaderName
Custom Header Key associated with the execution filter

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ExecutionFilterIdentifierHeaderValue
Custom Header Value associated with the execution filter

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Update operation

```yaml
Type: System.String
Parameter Sets: UpdateViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Update operation

```yaml
Type: System.String
Parameter Sets: UpdateViaJsonString
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
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
Azure Subscription ID.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -Tag
Resource tags.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -VersionId
The referenced versionId of the edgeAction version

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IEdgeActionExecutionFilter

## NOTES

## RELATED LINKS

