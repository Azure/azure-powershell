---
external help file:
Module Name: Az.NetworkCloud
online version: https://learn.microsoft.com/powershell/module/az.networkcloud/update-aznetworkcloudservicesnetwork
schema: 2.0.0
---

# Update-AzNetworkCloudServicesNetwork

## SYNOPSIS
Update properties of the provided cloud services network, or update the tags associated with it.
Properties and tag updates can be done independently.

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzNetworkCloudServicesNetwork -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-AdditionalEgressEndpoint <IEgressEndpoint[]>]
 [-EnableDefaultEgressEndpoint <CloudServicesNetworkEnableDefaultEgressEndpoints>] [-Tag <Hashtable>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzNetworkCloudServicesNetwork -InputObject <INetworkCloudIdentity>
 [-AdditionalEgressEndpoint <IEgressEndpoint[]>]
 [-EnableDefaultEgressEndpoint <CloudServicesNetworkEnableDefaultEgressEndpoints>] [-Tag <Hashtable>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Update properties of the provided cloud services network, or update the tags associated with it.
Properties and tag updates can be done independently.

## EXAMPLES

### Example 1: Update cloud services network
```powershell
$tags = @{
    Tag1 = 'tag1'
    Tag2  = 'tag2'
}

Update-AzNetworkCloudServicesNetwork -ResourceGroupName resourceGroupName -CloudServicesNetworkName cloudNetworkServicesName -Tag $tags
```

This command updates tags associated with the cloud services network.

### Example 2: Update egress endpoint for cloud services network
```powershell
$endpointEgressList = @{}
Update-AzNetworkCloudServicesNetwork -ResourceGroupName resourceGroupName -CloudServicesNetworkName cloudNetworkServicesName -AdditionalEgressEndpoint $endpointEgressList -EnableDefaultEgressEndpoint false
```

This command updates the egress endpoint for the cloud services network.

## PARAMETERS

### -AdditionalEgressEndpoint
The list of egress endpoints.
This allows for connection from a Hybrid AKS cluster to the specified endpoint.
To construct, see NOTES section for ADDITIONALEGRESSENDPOINT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Models.Api20240701.IEgressEndpoint[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

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

### -EnableDefaultEgressEndpoint
The indicator of whether the platform default endpoints are allowed for the egress traffic.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Support.CloudServicesNetworkEnableDefaultEgressEndpoints
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
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Models.INetworkCloudIdentity
Parameter Sets: UpdateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The name of the cloud services network.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases: CloudServicesNetworkName

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

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

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
The ID of the target subscription.
The value must be an UUID.

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
The Azure resource tags that will replace the existing ones.

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

### Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Models.INetworkCloudIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Models.Api20240701.ICloudServicesNetwork

## NOTES

## RELATED LINKS

