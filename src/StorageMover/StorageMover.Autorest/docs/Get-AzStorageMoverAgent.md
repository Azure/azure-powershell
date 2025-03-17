---
external help file:
Module Name: Az.StorageMover
online version: https://learn.microsoft.com/powershell/module/az.storagemover/get-azstoragemoveragent
schema: 2.0.0
---

# Get-AzStorageMoverAgent

## SYNOPSIS
Gets an Agent resource.

## SYNTAX

### List (Default)
```
Get-AzStorageMoverAgent -ResourceGroupName <String> -StorageMoverName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzStorageMoverAgent -Name <String> -ResourceGroupName <String> -StorageMoverName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzStorageMoverAgent -InputObject <IStorageMoverIdentity> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Gets an Agent resource.

## EXAMPLES

### Example 1: Get all agents in a Storage mover
```powershell
Get-AzStorageMoverAgent -ResourceGroupName myResourceGroup -StorageMoverName myStorageMover
```

```output
AgentStatus                  : Registering
ArcResourceId                : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/myResourceGroup/providers/Microsoft.HybridCompute/machines/myAgent
ArcVMUuid                    : aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa
Description                  :
ErrorDetailCode              :
ErrorDetailMessage           :
Id                           : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/myResourceGroup/providers/microsoft.storagemover/storagemovers/myStorageMover/agents/myAgent
LastStatusUpdate             :
LocalIPAddress               :
MemoryInMb                   :
Name                         : myAgent
NumberOfCores                :
ProvisioningState            : Succeeded
SystemDataCreatedAt          : 8/2/2022 7:15:19 AM
SystemDataCreatedBy          : myAccount@xxx.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 8/2/2022 7:15:19 AM
SystemDataLastModifiedBy     : myAccount@xxx.com
SystemDataLastModifiedByType : User
Type                         : microsoft.storagemover/storagemovers/agents
UptimeInSeconds              :
Version                      :
```

This command gets all the agents under a Storage mover

### Example 2: Get a specific agent
```powershell
Get-AzStorageMoverAgent -ResourceGroupName myResourceGroup -StorageMoverName myStorageMover -Name myAgent
```

```output
AgentStatus                  : Registering
ArcResourceId                : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/myResourceGroup/providers/Microsoft.HybridCompute/machines/myAgent
ArcVMUuid                    : aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa
Description                  :
ErrorDetailCode              :
ErrorDetailMessage           :
Id                           : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/myResourceGroup/providers/microsoft.storagemover/storagemovers/myStorageMover/agents/myAgent
LastStatusUpdate             :
LocalIPAddress               :
MemoryInMb                   :
Name                         : myAgent
NumberOfCores                :
ProvisioningState            : Succeeded
SystemDataCreatedAt          : 8/2/2022 7:15:19 AM
SystemDataCreatedBy          : myAccount@xxx.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 8/2/2022 7:15:19 AM
SystemDataLastModifiedBy     : myAccount@xxx.com
SystemDataLastModifiedByType : User
Type                         : microsoft.storagemover/storagemovers/agents
UptimeInSeconds              :
Version                      :
```

This command gets a specific agent.

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
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.StorageMover.Models.IStorageMoverIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The name of the Agent resource.

```yaml
Type: System.String
Parameter Sets: Get
Aliases: AgentName

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
Parameter Sets: Get, List
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -StorageMoverName
The name of the Storage Mover resource.

```yaml
Type: System.String
Parameter Sets: Get, List
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
Type: System.String[]
Parameter Sets: Get, List
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

### Microsoft.Azure.PowerShell.Cmdlets.StorageMover.Models.IStorageMoverIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.StorageMover.Models.Api20240701.IAgent

## NOTES

## RELATED LINKS

