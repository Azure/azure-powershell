---
external help file:
Module Name: Az.Automanage
online version: https://docs.microsoft.com/powershell/module/az.automanage/get-azautomanageconfigprofile
schema: 2.0.0
---

# Get-AzAutomanageConfigProfile

## SYNOPSIS
Get information about a configuration profile

## SYNTAX

### List1 (Default)
```
Get-AzAutomanageConfigProfile [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzAutomanageConfigProfile -Name <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzAutomanageConfigProfile -InputObject <IAutomanageIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### List
```
Get-AzAutomanageConfigProfile -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Get information about a configuration profile

## EXAMPLES

### Example 1: List all configuration profiles under a subscription
```powershell
Get-AzAutomanageConfigProfile
```

```output
Location Name                         ResourceGroupName
-------- ----                         -----------------
eastus   confpro-pwsh01               automangerg
eastus   lucas-best-practices-devtest automangerg
```

This command lists all configuration profiles under a subscription.

### Example 2: List all configuration profiles under a resource group
```powershell
Get-AzAutomanageConfigProfile -ResourceGroupName automangerg
```

```output
Location Name                         ResourceGroupName
-------- ----                         -----------------
eastus   confpro-pwsh01               automangerg
eastus   lucas-best-practices-devtest automangerg
```

This command lists all configuration profiles under a resource group.

### Example 3: Get information about a configuration profile by name
```powershell
Get-AzAutomanageConfigProfile -ResourceGroupName automangerg -Name lucas-best-practices-devtest
```

```output
Location Name                         ResourceGroupName
-------- ----                         -----------------
eastus   lucas-best-practices-devtest automangerg
```

This command gets information about a configuration profile by name.

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
Type: Microsoft.Azure.PowerShell.Cmdlets.Automanage.Models.IAutomanageIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The configuration profile name.

```yaml
Type: System.String
Parameter Sets: Get
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
Parameter Sets: Get, List
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
Parameter Sets: Get, List, List1
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

### Microsoft.Azure.PowerShell.Cmdlets.Automanage.Models.IAutomanageIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Automanage.Models.Api20220504.IConfigurationProfile

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


`INPUTOBJECT <IAutomanageIdentity>`: Identity Parameter
  - `[BestPracticeName <String>]`: The Automanage best practice name.
  - `[ClusterName <String>]`: The name of the Arc machine.
  - `[ConfigurationProfileAssignmentName <String>]`: Name of the configuration profile assignment. Only default is supported.
  - `[ConfigurationProfileName <String>]`: Name of the configuration profile.
  - `[Id <String>]`: Resource identity path
  - `[MachineName <String>]`: The name of the Arc machine.
  - `[ReportName <String>]`: The report name.
  - `[ResourceGroupName <String>]`: The name of the resource group. The name is case insensitive.
  - `[SubscriptionId <String>]`: The ID of the target subscription.
  - `[VMName <String>]`: The name of the virtual machine.
  - `[VersionName <String>]`: The Automanage best practice version name.

## RELATED LINKS

