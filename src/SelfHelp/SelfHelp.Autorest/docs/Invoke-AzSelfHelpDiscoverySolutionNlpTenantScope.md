---
external help file:
Module Name: Az.SelfHelp
online version: https://learn.microsoft.com/powershell/module/az.selfhelp/invoke-azselfhelpdiscoverysolutionnlptenantscope
schema: 2.0.0
---

# Invoke-AzSelfHelpDiscoverySolutionNlpTenantScope

## SYNOPSIS
Solution discovery using natural language processing.

## SYNTAX

### PostExpanded (Default)
```
Invoke-AzSelfHelpDiscoverySolutionNlpTenantScope [-AdditionalContext <String>] [-IssueSummary <String>]
 [-ResourceId <String>] [-ServiceId <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### Post
```
Invoke-AzSelfHelpDiscoverySolutionNlpTenantScope -DiscoverSolutionRequest <IDiscoveryNlpRequest>
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Solution discovery using natural language processing.

## EXAMPLES

### Example 1: Discover Solution using natural language at tenant scope
```powershell
Invoke-AzSelfHelpDiscoverySolutionNlpTenantScope -IssueSummary "Billing Issues"
```

```output
[No output]
```

Search for relevant Azure Diagnostics, Solutions and Troubleshooters using a natural language issue summary.

## PARAMETERS

### -AdditionalContext
Additional information in the form of a string.

```yaml
Type: System.String
Parameter Sets: PostExpanded
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

### -DiscoverSolutionRequest
Discover NLP request.
To construct, see NOTES section for DISCOVERSOLUTIONREQUEST properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.SelfHelp.Models.Api20240301Preview.IDiscoveryNlpRequest
Parameter Sets: Post
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -IssueSummary
Describe the issue with the affected resource.

```yaml
Type: System.String
Parameter Sets: PostExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceId
Provide resourceId of affected resource

```yaml
Type: System.String
Parameter Sets: PostExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ServiceId
Service Classification id for the resource.
You can find required serviceId from Services API: https://learn.microsoft.com/rest/api/support/services/listtabs=HTTP Service Id is the GUID which can be found under name field in Services List response

```yaml
Type: System.String
Parameter Sets: PostExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.SelfHelp.Models.Api20240301Preview.IDiscoveryNlpRequest

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.SelfHelp.Models.Api20240301Preview.ISolutionNlpMetadataResource

## NOTES

## RELATED LINKS

