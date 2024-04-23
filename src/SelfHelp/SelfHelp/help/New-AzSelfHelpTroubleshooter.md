---
external help file: Az.SelfHelp-help.xml
Module Name: Az.SelfHelp
online version: https://learn.microsoft.com/powershell/module/az.selfhelp/new-azselfhelptroubleshooter
schema: 2.0.0
---

# New-AzSelfHelpTroubleshooter

## SYNOPSIS
Creates the specific troubleshooter action under a resource or subscription using the 'solutionId' and  'properties.parameters' as the trigger.
\<br/\> Azure Troubleshooters help with hard to classify issues, reducing the gap between customer observed problems and solutions by guiding the user effortlessly through the troubleshooting process.
Each Troubleshooter flow represents a problem area within Azure and has a complex tree-like structure that addresses many root causes.
These flows are prepared with the help of Subject Matter experts and customer support engineers by carefully considering previous support requests raised by customers.
Troubleshooters terminate at a well curated solution based off of resource backend signals and customer manual selections.

## SYNTAX

```
New-AzSelfHelpTroubleshooter -Name <String> -Scope <String> [-Parameter <Hashtable>] [-SolutionId <String>]
 [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Creates the specific troubleshooter action under a resource or subscription using the 'solutionId' and  'properties.parameters' as the trigger.
\<br/\> Azure Troubleshooters help with hard to classify issues, reducing the gap between customer observed problems and solutions by guiding the user effortlessly through the troubleshooting process.
Each Troubleshooter flow represents a problem area within Azure and has a complex tree-like structure that addresses many root causes.
These flows are prepared with the help of Subject Matter experts and customer support engineers by carefully considering previous support requests raised by customers.
Troubleshooters terminate at a well curated solution based off of resource backend signals and customer manual selections.

## EXAMPLES

### Example 1: New-AzSelfHelpTroubleshooter
```powershell
$parameters = [ordered]@{
 "addParam1"= "/subscriptions/02d59989-f8a9-4b69-9919-1ef51df4eff6"
 
 }
New-AzSelfHelpTroubleshooter -Scope "/subscriptions/6bded6d5-a
6af-43e1-96d3-bf71f6f5f8ba" -Name "12d59989-f8a9-4b69-9919-1ef51df4eff6" -Parameter $parameters -SolutionId "e104dbdf-9e14-4c9f-bc78-21ac90382231"
```

```output
Name                                 SystemDataCreatedAt SystemDataCreatedBy SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy SystemDataLastModifiedByType ResourceGroupName
----                                 ------------------- ------------------- ----------------------- ------------------------ ------------------------ ---------------------------- -----------------
12d59989-f8a9-4b69-9919-1ef51df4eff6
```

Creates new troubleshooter resource.

## PARAMETERS

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

### -Name
Troubleshooter resource Name.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: TroubleshooterName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Parameter
Client input parameters to run Troubleshooter Resource

```yaml
Type: System.Collections.Hashtable
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Scope
scope = resourceUri of affected resource.\<br/\> For example: /subscriptions/0d0fcd2e-c4fd-4349-8497-200edb3923c6/resourcegroups/myresourceGroup/providers/Microsoft.KeyVault/vaults/test-keyvault-non-read

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

### -SolutionId
Solution Id to identify single troubleshooter.

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

### Microsoft.Azure.PowerShell.Cmdlets.SelfHelp.Models.Api20240301Preview.ITroubleshooterResource

## NOTES

## RELATED LINKS
