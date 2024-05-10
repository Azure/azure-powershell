---
external help file:
Module Name: Az.Automanage
online version: https://learn.microsoft.com/powershell/module/az.automanage/update-azautomanageconfigprofile
schema: 2.0.0
---

# Update-AzAutomanageConfigProfile

## SYNOPSIS
Updates a configuration profile

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzAutomanageConfigProfile -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-Configuration <Hashtable>] [-Tag <Hashtable>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzAutomanageConfigProfile -InputObject <IAutomanageIdentity> [-Configuration <Hashtable>]
 [-Tag <Hashtable>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Updates a configuration profile

## EXAMPLES

### Example 1: Updates a configuration profile
```powershell
Update-AzAutomanageConfigProfile -ResourceGroupName automangerg -Name confpro-pwsh01 -Tag @{"Organization" = "Administration"}
```

```output
Location Name           ResourceGroupName
-------- ----           -----------------
eastus   confpro-pwsh01 automangerg
```

This command updates a configuration profile.

### Example 2: Updates a configuration pipeline.
```powershell
Get-AzAutomanageConfigProfile -ResourceGroupName automangerg -Name confpro-pwsh01 | Update-AzAutomanageConfigProfile -Tag @{"Organization" = "Administration"}
```

```output
Location Name           ResourceGroupName
-------- ----           -----------------
eastus   confpro-pwsh01 automangerg
```

This command updates a configuration pipeline.

## PARAMETERS

### -Configuration
configuration dictionary of the configuration profile.

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

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Automanage.Models.IAutomanageIdentity
Parameter Sets: UpdateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
Name of the configuration profile.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases: ConfigurationProfileName

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
Parameter Sets: UpdateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -Tag
The tags of the resource.

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

### Microsoft.Azure.PowerShell.Cmdlets.Automanage.Models.IAutomanageIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Automanage.Models.Api20220504.IConfigurationProfile

## NOTES

## RELATED LINKS

