---
external help file:
Module Name: Az.Fleet
online version: https://learn.microsoft.com/powershell/module/az.fleet/start-azfleetupdaterun
schema: 2.0.0
---

# Start-AzFleetUpdateRun

## SYNOPSIS
Starts an UpdateRun.

## SYNTAX

### Start (Default)
```
Start-AzFleetUpdateRun -FleetName <String> -Name <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] [-IfMatch <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### StartViaIdentity
```
Start-AzFleetUpdateRun -InputObject <IFleetIdentity> [-IfMatch <String>] [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### StartViaIdentityFleet
```
Start-AzFleetUpdateRun -FleetInputObject <IFleetIdentity> -Name <String> [-IfMatch <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Starts an UpdateRun.

## EXAMPLES

### Example 1: Start specific fleet update run with specified name
```powershell
Start-AzFleetUpdateRun -FleetName testfleet01 -Name run1 -ResourceGroupName K8sFleet-Test
```

```output
AdditionalInfo                             : 
Code                                       : 
Detail                                     : 
ETag                                       : "cb067c64-0000-0100-0000-655c808d0000"
Id                                         : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/K8sFleet-Test/providers/Microsoft.ContainerService/fleets/testfleet01/updateRuns/run1
Message                                    : 
Name                                       : run1
NodeImageSelectionSelectedNodeImageVersion : 
NodeImageSelectionType                     : Latest
ProvisioningState                          : Succeeded
ResourceGroupName                          : K8sFleet-Test
StatusCompletedTime                        : 
StatusStage                                : {{
                                               "status": {
                                                 "state": "NotStarted"
                                               },
                                               "name": "default",
                                               "groups": [
                                                 {
                                                   "status": {
                                                     "state": "NotStarted"
                                                   },
                                                   "name": "default",
                                                   "members": [
                                                     {
                                                       "status": {
                                                         "state": "NotStarted"
                                                       },
                                                       "name": "testmember",
                                                       "clusterResourceId":
                                             "/subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/K8sFleet-Test/providers/microsoft.containerservice/managedClusters/TestCluster01"
                                                     },
                                                     {
                                                       "status": {
                                                         "state": "NotStarted"
                                                       },
                                                       "name": "testmember2",
                                                       "clusterResourceId":
                                             "/subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/K8sFleet-Test/providers/microsoft.containerservice/managedClusters/testCluster02"
                                                     }
                                                   ]
                                                 }
                                               ]
                                             }}
StatusStartTime                            : 
StatusState                                : NotStarted
StrategyStage                              : 
SystemDataCreatedAt                        : 11/21/2023 10:03:56 AM
SystemDataCreatedBy                        : user1@example.com
SystemDataCreatedByType                    : User
SystemDataLastModifiedAt                   : 11/21/2023 10:03:56 AM
SystemDataLastModifiedBy                   : user1@example.com
SystemDataLastModifiedByType               : User
Target                                     : 
Type                                       : Microsoft.ContainerService/fleets/updateRuns
UpdateStrategyId                           : 
UpgradeKubernetesVersion                   : 1.28.3
UpgradeType                                : Full
```

This command starts specific fleet update run with specified name

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

### -FleetInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Fleet.Models.IFleetIdentity
Parameter Sets: StartViaIdentityFleet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -FleetName
The name of the Fleet resource.

```yaml
Type: System.String
Parameter Sets: Start
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IfMatch
The request should only proceed if an entity matches this string.

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

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Fleet.Models.IFleetIdentity
Parameter Sets: StartViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The name of the UpdateRun resource.

```yaml
Type: System.String
Parameter Sets: Start, StartViaIdentityFleet
Aliases: UpdateRunName

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
Parameter Sets: Start
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
Parameter Sets: Start
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
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

### Microsoft.Azure.PowerShell.Cmdlets.Fleet.Models.IFleetIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Fleet.Models.IUpdateRun

## NOTES

## RELATED LINKS

