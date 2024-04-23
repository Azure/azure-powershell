---
external help file: Az.StandbyPool-help.xml
Module Name: Az.StandbyPool
online version: https://learn.microsoft.com/powershell/module/az.standbypool/new-azstandbycontainergrouppool
schema: 2.0.0
---

# New-AzStandbyContainerGroupPool

## SYNOPSIS
Create a StandbyContainerGroupPoolResource

## SYNTAX

### CreateExpanded (Default)
```
New-AzStandbyContainerGroupPool -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 -Location <String> [-ContainerProfileId <String>] [-MaxReadyCapacity <Int64>] [-ProfileRevision <Int64>]
 [-RefillPolicy <String>] [-SubnetId <ISubnet[]>] [-Tag <Hashtable>] [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateViaJsonFilePath
```
New-AzStandbyContainerGroupPool -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 -JsonFilePath <String> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateViaJsonString
```
New-AzStandbyContainerGroupPool -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 -JsonString <String> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Create a StandbyContainerGroupPoolResource

## EXAMPLES

### Example 1: Create a standby container pool
```powershell
New-AzStandbyContainerGroupPool `
-Name testPool `
-SubscriptionId f8da6e30-a9d8-48ab-b05c-3f7fe482e13b `
-ResourceGroupName test-standbypool `
-Location eastus `
-MaxReadyCapacity 1 `
-RefillPolicy always `
-ContainerProfileId /subscriptions/f8da6e30-a9d8-48ab-b05c-3f7fe482e13b/resourcegroups/test-standbypool/providers/Microsoft.ContainerInstance/containerGroupProfiles/testCG `
-ProfileRevision 1 `
-SubnetId @{id="/subscriptions/f8da6e30-a9d8-48ab-b05c-3f7fe482e13b/resourceGroups/test-standbypool/providers/Microsoft.Network/virtualNetworks/test-vnet/subnets/default"} `
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

The above command created a standby container pool.

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

### -ContainerProfileId
Specifies container group profile id of standby container groups.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
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
Parameter Sets: CreateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MaxReadyCapacity
Specifies maximum number of standby container groups in the standby pool.

```yaml
Type: System.Int64
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
Name of the standby container group pool

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: StandbyContainerGroupPoolName

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

### -ProfileRevision
Specifies revision of container group profile.

```yaml
Type: System.Int64
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RefillPolicy
Specifies refill policy of the pool.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
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

### -SubnetId
Specifies subnet Ids for container group.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.StandbyPool.Models.ISubnet[]
Parameter Sets: CreateExpanded
Aliases:

Required: False
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
Parameter Sets: CreateExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.StandbyPool.Models.IStandbyContainerGroupPoolResource

## NOTES

## RELATED LINKS
