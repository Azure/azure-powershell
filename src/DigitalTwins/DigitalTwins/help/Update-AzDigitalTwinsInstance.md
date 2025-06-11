---
external help file: Az.DigitalTwins-help.xml
Module Name: Az.DigitalTwins
online version: https://learn.microsoft.com/powershell/module/az.digitaltwins/update-azdigitaltwinsinstance
schema: 2.0.0
---

# Update-AzDigitalTwinsInstance

## SYNOPSIS
Update the metadata of a DigitalTwinsInstance.
The usual pattern to modify a property is to retrieve the DigitalTwinsInstance and security metadata, and then combine them with the modified values in a new body to update the DigitalTwinsInstance.

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzDigitalTwinsInstance -ResourceGroupName <String> -ResourceName <String> [-SubscriptionId <String>]
 [-EnableSystemAssignedIdentity <Boolean>] [-PrivateEndpointConnection <IPrivateEndpointConnection[]>]
 [-PublicNetworkAccess <String>] [-Tag <Hashtable>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzDigitalTwinsInstance -InputObject <IDigitalTwinsIdentity> [-EnableSystemAssignedIdentity <Boolean>]
 [-PrivateEndpointConnection <IPrivateEndpointConnection[]>] [-PublicNetworkAccess <String>] [-Tag <Hashtable>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
Update the metadata of a DigitalTwinsInstance.
The usual pattern to modify a property is to retrieve the DigitalTwinsInstance and security metadata, and then combine them with the modified values in a new body to update the DigitalTwinsInstance.

## EXAMPLES

### Example 1: Update metadata of DigitalTwinsInstance.
```powershell
Update-AzDigitalTwinsInstance -ResourceGroupName azps_test_group -ResourceName azps-digitaltwins-instance -Tag @{"abc"="123"}
```

```output
CreatedTime                  : 2025-06-06 09:44:17 AM
HostName                     : azps-digitaltwins-instance.api.eus.digitaltwins.azure.net
Id                           : /subscriptions/{subId}/resourceGroups/azps_test_group/providers/Microsoft.DigitalTwins/digitalTwinsInstances/azps-digitaltwins-instance
IdentityPrincipalId          : 6463ae74-a748-4f95-acf9-7d76e1d343b3
IdentityTenantId             : 213e87ed-8e08-4eb4-a63c-c073058f7b00
IdentityType                 : SystemAssigned
LastUpdatedTime              : 2025-06-06 11:27:24 AM
Location                     : eastus
Name                         : azps-digitaltwins-instance
PrivateEndpointConnection    : {}
ProvisioningState            : Succeeded
PublicNetworkAccess          : Enabled
ResourceGroupName            : azps_test_group
SystemDataCreatedAt          : 2025-06-06 09:44:15 AM
SystemDataCreatedBy          : xxxxx.xxxxx@microsoft.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 2025-06-06 11:27:22 AM
SystemDataLastModifiedBy     : xxxxx.xxxxx@microsoft.com
SystemDataLastModifiedByType : User
Tag                          : {
                                 "abc": "123"
                               }
Type                         : Microsoft.DigitalTwins/digitalTwinsInstances
```

Update metadata of DigitalTwinsInstance.

### Example 2: Update the AzDigitalTwinsInstance by another AzDigitalTwinsInstance.
```powershell
Get-AzDigitalTwinsInstance -ResourceGroupName azps_test_group -ResourceName azps-digitaltwins-instance | Update-AzDigitalTwinsInstance -Tag @{"1234"="abcd"}
```

```output
CreatedTime                  : 2025-06-06 09:44:17 AM
HostName                     : azps-digitaltwins-instance.api.eus.digitaltwins.azure.net
Id                           : /subscriptions/{subId}/resourceGroups/azps_test_group/providers/Microsoft.DigitalTwins/digitalTwinsInstances/azps-digitaltwins-instance
IdentityPrincipalId          : 6463ae74-a748-4f95-acf9-7d76e1d343b3
IdentityTenantId             : 213e87ed-8e08-4eb4-a63c-c073058f7b00
IdentityType                 : SystemAssigned
LastUpdatedTime              : 2025-06-06 11:29:03 AM
Location                     : eastus
Name                         : azps-digitaltwins-instance
PrivateEndpointConnection    : {}
ProvisioningState            : Succeeded
PublicNetworkAccess          : Enabled
ResourceGroupName            : azps_test_group
SystemDataCreatedAt          : 2025-06-06 09:44:15 AM
SystemDataCreatedBy          : xxxxx.xxxxx@microsoft.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 2025-06-06 11:29:01 AM
SystemDataLastModifiedBy     : xxxxx.xxxxx@microsoft.com
SystemDataLastModifiedByType : User
Tag                          : {
                                 "1234": "abcd"
                               }
Type                         : Microsoft.DigitalTwins/digitalTwinsInstances
```

Update the AzDigitalTwinsInstance by another AzDigitalTwinsInstance.

## PARAMETERS

### -AsJob
Run the command as a job

```yaml
Type: System.Management.Automation.SwitchParameter
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

### -EnableSystemAssignedIdentity
Determines whether to enable a system-assigned identity for the resource.

```yaml
Type: System.Nullable`1[System.Boolean]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Models.IDigitalTwinsIdentity
Parameter Sets: UpdateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -NoWait
Run the command asynchronously

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PrivateEndpointConnection
The private endpoint connections.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Models.IPrivateEndpointConnection[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PublicNetworkAccess
Public network access for the DigitalTwinsInstance.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group that contains the DigitalTwinsInstance.

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

### -ResourceName
The name of the DigitalTwinsInstance.

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
The subscription identifier.

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
The resource tags.

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

### Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Models.IDigitalTwinsIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Models.IDigitalTwinsDescription

## NOTES

## RELATED LINKS
