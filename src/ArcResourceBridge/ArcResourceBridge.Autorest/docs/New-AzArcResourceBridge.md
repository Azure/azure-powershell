---
external help file:
Module Name: Az.ArcResourceBridge
online version: https://learn.microsoft.com/powershell/module/az.arcresourcebridge/new-azarcresourcebridge
schema: 2.0.0
---

# New-AzArcResourceBridge

## SYNOPSIS
Creates or updates an Appliance in the specified Subscription and Resource Group.

## SYNTAX

```
New-AzArcResourceBridge -Name <String> -ResourceGroupName <String> -Location <String>
 [-SubscriptionId <String>] [-Distro <Distro>] [-IdentityType <ResourceIdentityType>]
 [-InfrastructureConfigProvider <Provider>] [-PublicKey <String>] [-Tag <Hashtable>] [-Version <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Creates or updates an Appliance in the specified Subscription and Resource Group.

## EXAMPLES

### Example 1: Creates or updates an Appliance in the specified Subscription and Resource Group.
```powershell
New-AzArcResourceBridge -Name azps-resource-bridge -ResourceGroupName azps_test_group -Location eastus -IdentityType 'SystemAssigned' -Distro 'AKSEdge' -InfrastructureConfigProvider 'VMware' -Tag @{"123"="abc"}
```

```output
Name                 Location ProvisioningState ResourceGroupName
----                 -------- ----------------- -----------------
azps-resource-bridge eastus   Succeeded         azps_test_group
```

Creates or updates an Appliance in the specified Subscription and Resource Group.

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

### -Distro
Represents a supported Fabric/Infra.
(AKSEdge etc...).

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ArcResourceBridge.Support.Distro
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IdentityType
The identity type.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ArcResourceBridge.Support.ResourceIdentityType
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InfrastructureConfigProvider
Information about the connected appliance.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ArcResourceBridge.Support.Provider
Parameter Sets: (All)
Aliases:

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
Appliances name.

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

### -PublicKey
Certificates pair used to download MSI certificate from HIS.
Can only be set once.

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

### -Version
Version of the Appliance

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

### Microsoft.Azure.PowerShell.Cmdlets.ArcResourceBridge.Models.Api20221027.IAppliance

## NOTES

ALIASES

## RELATED LINKS

