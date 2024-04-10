---
external help file:
Module Name: Az.StandbyPool
online version: https://learn.microsoft.com/powershell/module/az.standbypool/get-azstandbycontainerpool
schema: 2.0.0
---

# Get-AzStandbyContainerPool

## SYNOPSIS
Get a StandbyContainerGroupPoolResource

## SYNTAX

### List (Default)
```
Get-AzStandbyContainerPool [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzStandbyContainerPool -Name <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzStandbyContainerPool -InputObject <IStandbyPoolIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### List1
```
Get-AzStandbyContainerPool -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Get a StandbyContainerGroupPoolResource

## EXAMPLES

### Example 1: Get a standby container pool
```powershell
Get-AzStandbyContainerPool `
-SubscriptionId f8da6e30-a9d8-48ab-b05c-3f7fe482e13b `
-Name testPool `
-ResourceGroupName test-standbypool
```

```output
ContainerGroupProfileId           : /subscriptions/f8da6e30-a9d8-48ab-b05c-3f7fe482e13b/resourcegroups/test-standbypool/providers/Microsoft.ContainerInstance/containerGroupProfiles/testCG
ContainerGroupProfileRevision     : 1
ContainerGroupPropertySubnetId    : {{
                                      "id": "/subscriptions/f8da6e30-a9d8-48ab-b05c-3f7fe482e13b/resourceGroups/test-standbypool/providers/Microsoft.Network/virtualNetworks/test-vnet/subnets/default"
                                    }}
ElasticityProfileMaxReadyCapacity : 1
ElasticityProfileRefillPolicy     : always
Id                                : /subscriptions/f8da6e30-a9d8-48ab-b05c-3f7fe482e13b/resourceGroups/test-standbypool/providers/Microsoft.StandbyPool/standbyContainerGroupPools/testPool
Location                          : eastus
Name                              : testPool
ProvisioningState                 : Succeeded
ResourceGroupName                 : test-standbypool
SystemDataCreatedAt               : 4/10/2024 7:09:36 PM
SystemDataCreatedBy               : dev@microsoft.com
SystemDataCreatedByType           : User
SystemDataLastModifiedAt          : 4/10/2024 7:09:36 PM
SystemDataLastModifiedBy          : dev@microsoft.com
SystemDataLastModifiedByType      : User
Tag                               : {
                                    }
Type                              : microsoft.standbypool/standbycontainergrouppools
```

Above command is getting a standby container pool.

### Example 2: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here (remove the output block if the example doesn't have an output) }}
```

{{ Add description here }}

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

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.StandbyPool.Models.IStandbyPoolIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
Name of the standby container group pool

```yaml
Type: System.String
Parameter Sets: Get
Aliases: StandbyContainerGroupPoolName

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
Parameter Sets: Get, List1
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
Parameter Sets: Get, List, List1
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

### Microsoft.Azure.PowerShell.Cmdlets.StandbyPool.Models.IStandbyPoolIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.StandbyPool.Models.IStandbyContainerGroupPoolResource

## NOTES

## RELATED LINKS

