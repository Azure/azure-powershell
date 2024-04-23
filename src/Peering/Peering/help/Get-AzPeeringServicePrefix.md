---
external help file: Az.Peering-help.xml
Module Name: Az.Peering
online version: https://learn.microsoft.com/powershell/module/az.peering/get-azpeeringserviceprefix
schema: 2.0.0
---

# Get-AzPeeringServicePrefix

## SYNOPSIS
Gets an existing prefix with the specified name under the given subscription, resource group and peering service.

## SYNTAX

### List (Default)
```
Get-AzPeeringServicePrefix -PeeringServiceName <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-Expand <String>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### Get
```
Get-AzPeeringServicePrefix -Name <String> -PeeringServiceName <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-Expand <String>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzPeeringServicePrefix -InputObject <IPeeringIdentity> [-Expand <String>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Gets an existing prefix with the specified name under the given subscription, resource group and peering service.

## EXAMPLES

### Example 1: List all peering service prefixes
```powershell
Get-AzPeeringServicePrefix -PeeringServiceName TestDRInterCloudZurich -ResourceGroupName DemoRG
```

```output
Name        Prefix          Key                                  PrefixValidationState LearnedType ProvisioningState
----        ------          ---                                  --------------------- ----------- -----------------
TestPrefix  91.194.255.0/24 6a7f0d42-e49c-4eea-a930-280610671c3f Failed                None        Succeeded
TestPrefix2 240.0.0.0/24                                         Failed                None        Succeeded
```

Lists all peering service prefixes for the peering service

### Example 2: Get specific peering service prefix
```powershell
Get-AzPeeringServicePrefix -PeeringServiceName TestDRInterCloudZurich -ResourceGroupName DemoRG -Name TestPrefix
```

```output
Name        Prefix          Key                                  PrefixValidationState LearnedType ProvisioningState
----        ------          ---                                  --------------------- ----------- -----------------
TestPrefix  91.194.255.0/24 6a7f0d42-e49c-4eea-a930-280610671c3f Failed                None        Succeeded
```

Gets a specific peering service prefix

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

### -Expand
The properties to be expanded.

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

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Peering.Models.IPeeringIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The name of the prefix.

```yaml
Type: System.String
Parameter Sets: Get
Aliases: PrefixName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PeeringServiceName
The name of the peering service.

```yaml
Type: System.String
Parameter Sets: List, Get
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.

```yaml
Type: System.String
Parameter Sets: List, Get
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The Azure subscription ID.

```yaml
Type: System.String[]
Parameter Sets: List, Get
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

### Microsoft.Azure.PowerShell.Cmdlets.Peering.Models.IPeeringIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Peering.Models.Api20221001.IPeeringServicePrefix

## NOTES

## RELATED LINKS
