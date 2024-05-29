---
external help file: Az.Automanage-help.xml
Module Name: Az.Automanage
online version: https://learn.microsoft.com/powershell/module/az.automanage/new-azautomanageconfigprofile
schema: 2.0.0
---

# New-AzAutomanageConfigProfile

## SYNOPSIS
Creates a configuration profile

## SYNTAX

```
New-AzAutomanageConfigProfile -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 -Location <String> [-Configuration <Hashtable>] [-Tag <Hashtable>] [-DefaultProfile <PSObject>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Creates a configuration profile

## EXAMPLES

### Example 1: Creates a configuration profile
```powershell
$confprof = @{
          "Antimalware/Enable"='false';
          "Backup/Enable"='false';
          "VMInsights/Enable"= 'true';
          "AzureSecurityCenter/Enable"='true';
          "UpdateManagement/Enable"='true';
          "ChangeTrackingAndInventory/Enable"='true';
          "GuestConfiguration/Enable"='true';
          "LogAnalytics/Enable"='true';
          "BootDiagnostics/Enable"='true'
        }
New-AzAutomanageConfigProfile -ResourceGroupName automangerg -Name confpro-pwsh01 -Location eastus -Configuration $confprof
```

```output
Location Name           ResourceGroupName
-------- ----           -----------------
eastus   confpro-pwsh01 automangerg
```

This command creates a configuration profile.

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

### -Location
The geo-location where the resource lives

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

### -Name
Name of the configuration profile.

```yaml
Type: System.String
Parameter Sets: (All)
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
Parameter Sets: (All)
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

### Microsoft.Azure.PowerShell.Cmdlets.Automanage.Models.Api20220504.IConfigurationProfile

## NOTES

## RELATED LINKS
