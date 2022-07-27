---
external help file:
Module Name: Az.Logz
online version: https://docs.microsoft.com/powershell/module/az.logz/get-azlogzmonitortagrule
schema: 2.0.0
---

# Get-AzLogzMonitorTagRule

## SYNOPSIS
Get a tag rule set for a given monitor resource.

## SYNTAX

### Get (Default)
```
Get-AzLogzMonitorTagRule -MonitorName <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzLogzMonitorTagRule -InputObject <ILogzIdentity> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Get a tag rule set for a given monitor resource.

## EXAMPLES

### Example 1: Get the default tag rule set for a given monitor resource
```powershell
Get-AzLogzMonitorTagRule -ResourceGroupName logz-rg-test -MonitorName pwsh-logz04
```

```output
Name    ProvisioningState ResourceGroupName
----    ----------------- -----------------
default Succeeded         logz-rg-test
```

This command gets the default tag rule set for a given monitor resource.

### Example 2: Get the default tag rule set for a given monitor resource by pipeline
```powershell
Get-AzLogzMonitorTagRule -ResourceGroupName logz-rg-test -MonitorName pwsh-logz04 | Get-AzLogzMonitorTagRule
```

```output
Name    ProvisioningState ResourceGroupName
----    ----------------- -----------------
default Succeeded         logz-rg-test
```

This command gets the default tag rule set for a given monitor resource by pipeline.

## PARAMETERS

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

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
Type: Microsoft.Azure.PowerShell.Cmdlets.Logz.Models.ILogzIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -MonitorName
Monitor resource name

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

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

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

### -SubscriptionId
The ID of the target subscription.

```yaml
Type: System.String[]
Parameter Sets: Get
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

### Microsoft.Azure.PowerShell.Cmdlets.Logz.Models.ILogzIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Logz.Models.Api20201001Preview.IMonitoringTagRules

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


INPUTOBJECT `<ILogzIdentity>`: Identity Parameter
  - `[ConfigurationName <String>]`: 
  - `[Id <String>]`: Resource identity path
  - `[MonitorName <String>]`: Monitor resource name
  - `[ResourceGroupName <String>]`: The name of the resource group. The name is case insensitive.
  - `[RuleSetName <String>]`: 
  - `[SubAccountName <String>]`: Sub Account resource name
  - `[SubscriptionId <String>]`: The ID of the target subscription.

## RELATED LINKS

