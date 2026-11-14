---
external help file:
Module Name: Az.Commvault
online version: https://learn.microsoft.com/powershell/module/az.commvault/get-azcommvaultprotecteditemrestorepoint
schema: 2.0.0
---

# Get-AzCommvaultProtectedItemRestorePoint

## SYNOPSIS
Gets the restore points that are available for a protected item.

## SYNTAX

### Get (Default)
```
Get-AzCommvaultProtectedItemRestorePoint -CloudAccountName <String> -ProtectedItemName <String>
 -ProtectionGroupName <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzCommvaultProtectedItemRestorePoint -InputObject <ICommvaultIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentityCloudAccount
```
Get-AzCommvaultProtectedItemRestorePoint -CloudAccountInputObject <ICommvaultIdentity>
 -ProtectedItemName <String> -ProtectionGroupName <String> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentityProtectionGroup
```
Get-AzCommvaultProtectedItemRestorePoint -ProtectedItemName <String>
 -ProtectionGroupInputObject <ICommvaultIdentity> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Gets the restore points that are available for a protected item.

## EXAMPLES

### Example 1: Get the restore points of a protected item
```powershell
Get-AzCommvaultProtectedItemRestorePoint -ResourceGroupName rg-commvault -CloudAccountName cca-contoso -ProtectionGroupName pg-prod-vms -ProtectedItemName vm-app01
```

Gets the restore points that are available for the protected item.

## PARAMETERS

### -CloudAccountInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Commvault.Models.ICommvaultIdentity
Parameter Sets: GetViaIdentityCloudAccount
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -CloudAccountName
Name of the Cloud Account resource

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

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Commvault.Models.ICommvaultIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ProtectedItemName
The protectedItem Id, name of 2 protected items can be same under a PG if they belong to different resource group or even different data source types VM/DB/AKS, etc; and name is mandatory in Azure Typespec, hence using name parameter for id in Commvault In case of Vm it will be vmGuid

```yaml
Type: System.String
Parameter Sets: Get, GetViaIdentityCloudAccount, GetViaIdentityProtectionGroup
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProtectionGroupInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Commvault.Models.ICommvaultIdentity
Parameter Sets: GetViaIdentityProtectionGroup
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ProtectionGroupName
Name of the ProtectionGroup resource

```yaml
Type: System.String
Parameter Sets: Get, GetViaIdentityCloudAccount
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
The value must be an UUID.

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

### Microsoft.Azure.PowerShell.Cmdlets.Commvault.Models.ICommvaultIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Commvault.Models.IRestorePoints

## NOTES

## RELATED LINKS

