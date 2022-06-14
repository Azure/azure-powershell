---
external help file:
Module Name: Az.NotificationHubs
online version: https://docs.microsoft.com/en-us/powershell/module/az.notificationhubs/test-aznotificationhubsnotificationhubavailability
schema: 2.0.0
---

# Test-AzNotificationHubsNotificationHubAvailability

## SYNOPSIS
Checks the availability of the given notificationHub in a namespace.

## SYNTAX

### CheckExpanded (Default)
```
Test-AzNotificationHubsNotificationHubAvailability -NamespaceName <String> -ResourceGroupName <String>
 -Name <String> [-SubscriptionId <String>] [-IsAvailiable] [-Location <String>] [-SkuCapacity <Int32>]
 [-SkuFamily <String>] [-SkuName <SkuName>] [-SkuSize <String>] [-SkuTier <String>] [-Tag <Hashtable>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Check
```
Test-AzNotificationHubsNotificationHubAvailability -NamespaceName <String> -ResourceGroupName <String>
 -Parameter <ICheckAvailabilityParameters> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### CheckViaIdentity
```
Test-AzNotificationHubsNotificationHubAvailability -InputObject <INotificationHubsIdentity>
 -Parameter <ICheckAvailabilityParameters> [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### CheckViaIdentityExpanded
```
Test-AzNotificationHubsNotificationHubAvailability -InputObject <INotificationHubsIdentity> -Name <String>
 [-IsAvailiable] [-Location <String>] [-SkuCapacity <Int32>] [-SkuFamily <String>] [-SkuName <SkuName>]
 [-SkuSize <String>] [-SkuTier <String>] [-Tag <Hashtable>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

## DESCRIPTION
Checks the availability of the given notificationHub in a namespace.

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
Parameter Sets: CheckViaIdentity, CheckViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -IsAvailiable
True if the name is available and can be used to create new Namespace/NotificationHub.
Otherwise false.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: CheckExpanded, CheckViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Location
Resource location

```yaml
Type: System.String
Parameter Sets: CheckExpanded, CheckViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
Resource name

```yaml
Type: System.String
Parameter Sets: CheckExpanded, CheckViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NamespaceName
The namespace name.

```yaml
Type: System.String
Parameter Sets: Check, CheckExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Parameter
Parameters supplied to the Check Name Availability for Namespace and NotificationHubs.
To construct, see NOTES section for PARAMETER properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.NotificationHubs.Models.Api20170401.ICheckAvailabilityParameters
Parameter Sets: Check, CheckViaIdentity
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
Parameter Sets: Check, CheckExpanded
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
Parameter Sets: CheckExpanded, CheckViaIdentityExpanded
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
Parameter Sets: CheckExpanded, CheckViaIdentityExpanded
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
Parameter Sets: CheckExpanded, CheckViaIdentityExpanded
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
Parameter Sets: CheckExpanded, CheckViaIdentityExpanded
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
Parameter Sets: CheckExpanded, CheckViaIdentityExpanded
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
Parameter Sets: Check, CheckExpanded
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
Parameter Sets: CheckExpanded, CheckViaIdentityExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.NotificationHubs.Models.Api20170401.ICheckAvailabilityParameters

### Microsoft.Azure.PowerShell.Cmdlets.NotificationHubs.Models.INotificationHubsIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.NotificationHubs.Models.Api20170401.ICheckAvailabilityResult

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

PARAMETER <ICheckAvailabilityParameters>: Parameters supplied to the Check Name Availability for Namespace and NotificationHubs.
  - `Name <String>`: Resource name
  - `[IsAvailiable <Boolean?>]`: True if the name is available and can be used to create new Namespace/NotificationHub. Otherwise false.
  - `[Location <String>]`: Resource location
  - `[SkuCapacity <Int32?>]`: The capacity of the resource
  - `[SkuFamily <String>]`: The Sku Family
  - `[SkuName <SkuName?>]`: Name of the notification hub sku
  - `[SkuSize <String>]`: The Sku size
  - `[SkuTier <String>]`: The tier of particular sku
  - `[Tag <ICheckAvailabilityParametersTags>]`: Resource tags
    - `[(Any) <String>]`: This indicates any property can be added to this object.

## RELATED LINKS

