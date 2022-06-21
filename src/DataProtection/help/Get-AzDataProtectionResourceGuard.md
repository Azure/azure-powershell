---
external help file:
Module Name: Az.DataProtection
online version: https://docs.microsoft.com/powershell/module/az.dataprotection/get-azdataprotectionresourceguard
schema: 2.0.0
---

# Get-AzDataProtectionResourceGuard

## SYNOPSIS
Returns a ResourceGuard belonging to a resource group.

## SYNTAX

### Get1 (Default)
```
Get-AzDataProtectionResourceGuard -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzDataProtectionResourceGuard -Name <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzDataProtectionResourceGuard -InputObject <IDataProtectionIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Returns a ResourceGuard belonging to a resource group.

## EXAMPLES

### Example 1: Fetch a resource guard with a particular Name
```powershell
PS C:\> $resGuard = Get-AzDataProtectionResourceGuard -SubscriptionId "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx" -ResourceGroupName "RGName" -Name "ResourceGuardName"
PS C:\> $resGuard
```

```output
ETag Id                                                                                                                                                       IdentityPrincipalId IdentityTenantId IdentityType Location      Name
---- --                                                                                                                                                       ------------------- ---------------- ------------ --------      ----
     /subscriptions/xxxxxxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/RGName/providers/Microsoft.DataProtection/resourceGuards/ResourceGuardName                                                   centraluseuap ResourceGuardName
```

Gets a resource guard under a resource group with name "ResourceGuardName"

### Example 2: Fetch all the resource guards under a resource group
```powershell
PS C:\> $resGuardList = Get-AzDataProtectionResourceGuard -SubscriptionId "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx" -ResourceGroupName "RGName"
PS C:\> $resGuardList
```

```output
ETag Id                                                                                                                                                       IdentityPrincipalId IdentityTenantId IdentityType Location      Name               Type
---- --                                                                                                                                                       ------------------- ---------------- ------------ --------      ----               ----
     /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourcegroups/RGName/providers/Microsoft.DataProtection/resourceGuards/rguard1                                                    centraluseuap rguard1  Microsoft.DataProtection/resourceGuards
     /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourcegroups/RGName/providers/Microsoft.DataProtection/resourceGuards/rguard2                                                   centraluseuap rguard2 Microsoft.DataProtection/resourceGuards
     /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/RGName/providers/Microsoft.DataProtection/resourceGuards/rguard3                                                   centraluseuap rguard3 Microsoft.DataProtection/resourceGuards
     /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/RGName/providers/Microsoft.DataProtection/resourceGuards/rguard4                                                   centraluseuap rguard4 Microsoft.DataProtection/resourceGuards
```

Gets all resource guards under a resource group

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
Type: Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.IDataProtectionIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The name of ResourceGuard

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
The name of the resource group where the backup vault is present.

```yaml
Type: System.String
Parameter Sets: Get, Get1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The subscription Id.

```yaml
Type: System.String[]
Parameter Sets: Get, Get1
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

### Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.IDataProtectionIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20220401.IResourceGuardResource

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


INPUTOBJECT <IDataProtectionIdentity>: Identity Parameter
  - `[BackupInstanceName <String>]`: The name of the backup instance
  - `[BackupPolicyName <String>]`: 
  - `[Id <String>]`: Resource identity path
  - `[JobId <String>]`: The Job ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).
  - `[Location <String>]`: The location in which uniqueness will be verified.
  - `[OperationId <String>]`: 
  - `[RecoveryPointId <String>]`: 
  - `[RequestName <String>]`: 
  - `[ResourceGroupName <String>]`: The name of the resource group where the backup vault is present.
  - `[ResourceGuardsName <String>]`: The name of ResourceGuard
  - `[SubscriptionId <String>]`: The subscription Id.
  - `[VaultName <String>]`: The name of the backup vault.

## RELATED LINKS

