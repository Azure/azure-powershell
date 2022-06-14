---
external help file:
Module Name: Az.NotificationHubs
online version: https://docs.microsoft.com/en-us/powershell/module/az.notificationhubs/update-aznotificationhubsnamespace
schema: 2.0.0
---

# Update-AzNotificationHubsNamespace

## SYNOPSIS
Patches the existing namespace

## SYNTAX

### PatchExpanded (Default)
```
Update-AzNotificationHubsNamespace -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-SkuCapacity <Int32>] [-SkuFamily <String>] [-SkuName <SkuName>] [-SkuSize <String>] [-SkuTier <String>]
 [-Tag <Hashtable>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Patch
```
Update-AzNotificationHubsNamespace -Name <String> -ResourceGroupName <String>
 -Parameter <INamespacePatchParameters> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### PatchViaIdentity
```
Update-AzNotificationHubsNamespace -InputObject <INotificationHubsIdentity>
 -Parameter <INamespacePatchParameters> [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### PatchViaIdentityExpanded
```
Update-AzNotificationHubsNamespace -InputObject <INotificationHubsIdentity> [-SkuCapacity <Int32>]
 [-SkuFamily <String>] [-SkuName <SkuName>] [-SkuSize <String>] [-SkuTier <String>] [-Tag <Hashtable>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Patches the existing namespace

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here }}
```

{{ Add description here }}

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
Type: Microsoft.Azure.PowerShell.Cmdlets.NotificationHubs.Models.INotificationHubsIdentity
Parameter Sets: PatchViaIdentity, PatchViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The namespace name.

```yaml
Type: System.String
Parameter Sets: Patch, PatchExpanded
Aliases: NamespaceName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Parameter
Parameters supplied to the Patch Namespace operation.
To construct, see NOTES section for PARAMETER properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.NotificationHubs.Models.Api20170401.INamespacePatchParameters
Parameter Sets: Patch, PatchViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.

```yaml
Type: System.String
Parameter Sets: Patch, PatchExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SkuCapacity
The capacity of the resource

```yaml
Type: System.Int32
Parameter Sets: PatchExpanded, PatchViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SkuFamily
The Sku Family

```yaml
Type: System.String
Parameter Sets: PatchExpanded, PatchViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SkuName
Name of the notification hub sku

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.NotificationHubs.Support.SkuName
Parameter Sets: PatchExpanded, PatchViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SkuSize
The Sku size

```yaml
Type: System.String
Parameter Sets: PatchExpanded, PatchViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SkuTier
The tier of particular sku

```yaml
Type: System.String
Parameter Sets: PatchExpanded, PatchViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
Gets subscription credentials which uniquely identify Microsoft Azure subscription.
The subscription ID forms part of the URI for every service call.

```yaml
Type: System.String
Parameter Sets: Patch, PatchExpanded
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -Tag
Resource tags

```yaml
Type: System.Collections.Hashtable
Parameter Sets: PatchExpanded, PatchViaIdentityExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.NotificationHubs.Models.Api20170401.INamespacePatchParameters

### Microsoft.Azure.PowerShell.Cmdlets.NotificationHubs.Models.INotificationHubsIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.NotificationHubs.Models.Api20170401.INamespaceResource

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


INPUTOBJECT <INotificationHubsIdentity>: Identity Parameter
  - `[AuthorizationRuleName <String>]`: Authorization Rule Name.
  - `[Id <String>]`: Resource identity path
  - `[NamespaceName <String>]`: The namespace name.
  - `[NotificationHubName <String>]`: The notification hub name.
  - `[ResourceGroupName <String>]`: The name of the resource group.
  - `[SubscriptionId <String>]`: Gets subscription credentials which uniquely identify Microsoft Azure subscription. The subscription ID forms part of the URI for every service call.

PARAMETER <INamespacePatchParameters>: Parameters supplied to the Patch Namespace operation.
  - `[SkuCapacity <Int32?>]`: The capacity of the resource
  - `[SkuFamily <String>]`: The Sku Family
  - `[SkuName <SkuName?>]`: Name of the notification hub sku
  - `[SkuSize <String>]`: The Sku size
  - `[SkuTier <String>]`: The tier of particular sku
  - `[Tag <INamespacePatchParametersTags>]`: Resource tags
    - `[(Any) <String>]`: This indicates any property can be added to this object.

## RELATED LINKS

