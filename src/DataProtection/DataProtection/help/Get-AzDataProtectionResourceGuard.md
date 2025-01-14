---
external help file: Az.DataProtection-help.xml
Module Name: Az.DataProtection
online version: https://learn.microsoft.com/powershell/module/az.dataprotection/get-azdataprotectionresourceguard
schema: 2.0.0
---

# Get-AzDataProtectionResourceGuard

## SYNOPSIS
Returns a ResourceGuard belonging to a resource group.

## SYNTAX

### Get1 (Default)
```
Get-AzDataProtectionResourceGuard -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### Get
```
Get-AzDataProtectionResourceGuard -Name <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzDataProtectionResourceGuard -InputObject <IDataProtectionIdentity> [-DefaultProfile <PSObject>]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
Returns a ResourceGuard belonging to a resource group.

## EXAMPLES

### Example 1: Fetch a resource guard with a particular Name
```powershell
Get-AzDataProtectionResourceGuard -SubscriptionId "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx" -ResourceGroupName "RGName" -Name "ResourceGuardName"
```

```output
ETag Id                                                                                                                                                       IdentityPrincipalId IdentityTenantId IdentityType Location      Name
---- --                                                                                                                                                       ------------------- ---------------- ------------ --------      ----
     /subscriptions/xxxxxxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/RGName/providers/Microsoft.DataProtection/resourceGuards/ResourceGuardName                                                   centraluseuap ResourceGuardName
```

Gets a resource guard under a resource group with name "ResourceGuardName"

### Example 2: Fetch all the resource guards under a resource group
```powershell
Get-AzDataProtectionResourceGuard -SubscriptionId "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx" -ResourceGroupName "RGName"
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
The name of the resource group.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: Get1, Get
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.
The value must be an UUID.

```yaml
Type: System.String[]
Parameter Sets: Get1, Get
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

### Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20240401.IResourceGuardResource

## NOTES

## RELATED LINKS
