---
external help file:
Module Name: Az.ManagedServiceIdentity
online version: https://docs.microsoft.com/powershell/module/az.managedserviceidentity/get-azuserassignedidentity
schema: 2.0.0
---

# Get-AzUserAssignedIdentity

## SYNOPSIS
Gets the identity.

## SYNTAX

### List (Default)
```
Get-AzUserAssignedIdentity [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzUserAssignedIdentity -Name <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzUserAssignedIdentity -InputObject <IManagedServiceIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### List1
```
Get-AzUserAssignedIdentity -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Gets the identity.

## EXAMPLES

### Example 1: Lists user assigned identity under a subscription
```powershell
Get-AzUserAssignedIdentity
```

```output
Location      Name                                ResourceGroupName
--------      ----                                -----------------
eastus        AzSecPackAutoConfigUA-eastus        AzSecPackAutoConfigRG
eastus        uai-pwsh01                          azure-rg-test
eastus2       AzSecPackAutoConfigUA-eastus2       AzSecPackAutoConfigRG
```

This command lists user assigned identity under a subscription.

### Example 2: List user assigned identity under a resource group
```powershell
Get-AzUserAssignedIdentity -ResourceGroupName azure-rg-test
```

```output
Location Name       ResourceGroupName
-------- ----       -----------------
eastus   uai-pwsh01 azure-rg-test
```

This command lists user assigned identity under a resource group.

### Example 3: Get an user assigned identity
```powershell
Get-AzUserAssignedIdentity -ResourceGroupName azure-rg-test -Name uai-pwsh01
```

```output
Location Name       ResourceGroupName
-------- ----       -----------------
eastus   uai-pwsh01 azure-rg-test
```

This command gets an user assigned identity.

### Example 4: Get an user assigned identity by pipeline
```powershell
New-AzUserAssignedIdentity -ResourceGroupName azure-rg-test -Name uai-pwsh01 -Location eastus `
 | Get-AzUserAssignedIdentity
```

```output
Location Name       ResourceGroupName
-------- ----       -----------------
eastus   uai-pwsh01 azure-rg-test
```

This command gets an user assigned identity by pipeline.

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
Type: Microsoft.Azure.PowerShell.Cmdlets.ManagedServiceIdentity.Models.IManagedServiceIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The name of the identity resource.

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
The name of the Resource Group to which the identity belongs.

```yaml
Type: System.String
Parameter Sets: Get, List1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The Id of the Subscription to which the identity belongs.

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

### Microsoft.Azure.PowerShell.Cmdlets.ManagedServiceIdentity.Models.IManagedServiceIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ManagedServiceIdentity.Models.Api20181130.IIdentity

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


INPUTOBJECT `<IManagedServiceIdentity>`: Identity Parameter
  - `[Id <String>]`: Resource identity path
  - `[ResourceGroupName <String>]`: The name of the Resource Group to which the identity belongs.
  - `[ResourceName <String>]`: The name of the identity resource.
  - `[Scope <String>]`: The resource provider scope of the resource. Parent resource being extended by Managed Identities.
  - `[SubscriptionId <String>]`: The Id of the Subscription to which the identity belongs.

## RELATED LINKS

