---
external help file:
Module Name: Az.ArcGateway
online version: https://learn.microsoft.com/powershell/module/az.arcgateway/new-azarcgateway
schema: 2.0.0
---

# New-AzArcGateway

## SYNOPSIS
The operation to create or update a gateway.

## SYNTAX

### CreateExpanded (Default)
```
New-AzArcGateway -Name <String> -ResourceGroupName <String> -Location <String> [-SubscriptionId <String>]
 [-GatewayType <String>] [-Tag <Hashtable>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### Create
```
New-AzArcGateway -Name <String> -ResourceGroupName <String> -Parameter <IGateway> [-SubscriptionId <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaIdentity
```
New-AzArcGateway -InputObject <IArcGatewayIdentity> -Parameter <IGateway> [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaIdentityExpanded
```
New-AzArcGateway -InputObject <IArcGatewayIdentity> -Location <String> [-GatewayType <String>]
 [-Tag <Hashtable>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaJsonFilePath
```
New-AzArcGateway -Name <String> -ResourceGroupName <String> -JsonFilePath <String> [-SubscriptionId <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaJsonString
```
New-AzArcGateway -Name <String> -ResourceGroupName <String> -JsonString <String> [-SubscriptionId <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
The operation to create or update a gateway.

## EXAMPLES

### Example 1: create a gateway for arc machine
```powershell
New-AzArcGateway -Name "myArcGateway" -ResourceGroupName "ytongtest" -Location "eastus" -SubscriptionId "00000000-0000-0000-0000-000000000000"
```

```output
AllowedFeature               : {*}
Endpoint                     : 00000000-0000-0000-0000-000000000000.gw.arc.azure.com
GatewayId                    : 00000000-0000-0000-0000-000000000000
GatewayType                  : Public
Id                           : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/ytongtest
                               /providers/Microsoft.HybridCompute/gateways/myArcGateway
Location                     : eastus
Name                         : myArcGateway
ProvisioningState            : Succeeded
ResourceGroupName            : ytongtest
SystemDataCreatedAt          :
SystemDataCreatedBy          :
SystemDataCreatedByType      :
SystemDataLastModifiedAt     :
SystemDataLastModifiedBy     :
SystemDataLastModifiedByType :
Tag                          : {
                               }
Type                         : Microsoft.HybridCompute/gateways
```

create a gateway for arc machine

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

### -GatewayType
The type of the Gateway resource.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
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
Type: Microsoft.Azure.PowerShell.Cmdlets.ArcGateway.Models.IArcGatewayIdentity
Parameter Sets: CreateViaIdentity, CreateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Create operation

```yaml
Type: System.String
Parameter Sets: CreateViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Create operation

```yaml
Type: System.String
Parameter Sets: CreateViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Location
The geo-location where the resource lives

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The name of the Gateway.

```yaml
Type: System.String
Parameter Sets: Create, CreateExpanded, CreateViaJsonFilePath, CreateViaJsonString
Aliases: GatewayName

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

### -Parameter
Describes an Arc Gateway.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ArcGateway.Models.IGateway
Parameter Sets: Create, CreateViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: Create, CreateExpanded, CreateViaJsonFilePath, CreateViaJsonString
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
Parameter Sets: Create, CreateExpanded, CreateViaJsonFilePath, CreateViaJsonString
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
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.ArcGateway.Models.IArcGatewayIdentity

### Microsoft.Azure.PowerShell.Cmdlets.ArcGateway.Models.IGateway

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ArcGateway.Models.IGateway

## NOTES

## RELATED LINKS

