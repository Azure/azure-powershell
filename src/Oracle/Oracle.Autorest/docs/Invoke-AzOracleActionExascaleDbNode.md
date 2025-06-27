---
external help file:
Module Name: Az.Oracle
online version: https://learn.microsoft.com/powershell/module/az.oracle/invoke-azoracleactionexascaledbnode
schema: 2.0.0
---

# Invoke-AzOracleActionExascaleDbNode

## SYNOPSIS
VM actions on DbNode of ExadbVmCluster by the provided filter

## SYNTAX

### ActionExpanded (Default)
```
Invoke-AzOracleActionExascaleDbNode -ExadbVMClusterName <String> -ExascaleDbNodeName <String>
 -ResourceGroupName <String> -Action <String> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### ActionViaIdentityExadbVMCluster
```
Invoke-AzOracleActionExascaleDbNode -ExadbVMClusterInputObject <IOracleIdentity> -ExascaleDbNodeName <String>
 -Body <IDbNodeAction> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### ActionViaIdentityExadbVMClusterExpanded
```
Invoke-AzOracleActionExascaleDbNode -ExadbVMClusterInputObject <IOracleIdentity> -ExascaleDbNodeName <String>
 -Action <String> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### ActionViaIdentityExpanded
```
Invoke-AzOracleActionExascaleDbNode -InputObject <IOracleIdentity> -Action <String>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### ActionViaJsonFilePath
```
Invoke-AzOracleActionExascaleDbNode -ExadbVMClusterName <String> -ExascaleDbNodeName <String>
 -ResourceGroupName <String> -JsonFilePath <String> [-SubscriptionId <String>] [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### ActionViaJsonString
```
Invoke-AzOracleActionExascaleDbNode -ExadbVMClusterName <String> -ExascaleDbNodeName <String>
 -ResourceGroupName <String> -JsonString <String> [-SubscriptionId <String>] [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
VM actions on DbNode of ExadbVmCluster by the provided filter

## EXAMPLES

### Example 1: Stop a VM in a Exa Db  Cluster Node resource
```powershell
$vmClusterName = "OFake_PowerShellTestVmCluster"
$resourceGroup = "PowerShellTestRg"
$stopActionName = "Stop"
            
$dbNodeList = Get-AzOracleExascaleDbNode -Exadbvmclustername $vmClusterName -ResourceGroupName $resourceGroup
$dbNodeOcid1 = $dbNodeList[0].Name
            
Invoke-AzOracleActionExascaleDbNode -ExadbVMClusterName $vmClusterName -ExascaleDbNodeName $dbNodeOcid1 -ResourceGroupName $resourceGroup -Action $stopActionName
```

```output
ocid                        : ocid1.dbnode.oc1..aaaaa3klq
additionalDetails           : zjvaydzrzxrmtiolutkhyfumql
cpuCoreCount                : 25
dbNodeStorageSizeInGbs      : 7
faultDomain                 : bgtzblfwbdooaj
hostname                    : nmbmxqpkdqueswkwystaupanqrn
lifecycleState              : Available
ProvisioningState           : Stopping
maintenanceType             : ncsgznwyxmzcrqnmzbn
memorySizeInGbs             : 29
softwareStorageSizeInGb     : 14
timeMaintenanceWindowEnd    : 2024-12-09T21:02:38.078Z
timeMaintenanceWindowStart  : 2024-12-09T21:02:38.078Z
totalCpuCoreCount           : 26
id                          : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/rg1/providers/Oracle.Database/exadbVmClusters/vmCluster/dbNodes/dbNodeName
name                        : lkjpzwgzy
type                        : zdrljrxhtseejhwvzox
createdBy                   : ilrpjodjmvzhybazxipoplnql
createdByType               : User
createdAt                   : 2024-12-09T21:02:12.592Z
lastModifiedBy              : lhjbxchqkaia
lastModifiedByType          : User
lastModifiedAt              : 2024-12-09T21:02:12.592Z
```

Get a list of the Database Nodes for a Cloud VM Cluster resource.
For more information, execute `Get-Help Invoke-AzOracleExascaleDbNode`

## PARAMETERS

### -Action
Db action

```yaml
Type: System.String
Parameter Sets: ActionExpanded, ActionViaIdentityExadbVMClusterExpanded, ActionViaIdentityExpanded
Aliases:

Required: True
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

### -Body
DbNode action object

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Oracle.Models.IDbNodeAction
Parameter Sets: ActionViaIdentityExadbVMCluster
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
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

### -ExadbVMClusterInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Oracle.Models.IOracleIdentity
Parameter Sets: ActionViaIdentityExadbVMCluster, ActionViaIdentityExadbVMClusterExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ExadbVMClusterName
The name of the ExadbVmCluster

```yaml
Type: System.String
Parameter Sets: ActionExpanded, ActionViaJsonFilePath, ActionViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ExascaleDbNodeName
The name of the ExascaleDbNode

```yaml
Type: System.String
Parameter Sets: ActionExpanded, ActionViaIdentityExadbVMCluster, ActionViaIdentityExadbVMClusterExpanded, ActionViaJsonFilePath, ActionViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Oracle.Models.IOracleIdentity
Parameter Sets: ActionViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Action operation

```yaml
Type: System.String
Parameter Sets: ActionViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Action operation

```yaml
Type: System.String
Parameter Sets: ActionViaJsonString
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

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: ActionExpanded, ActionViaJsonFilePath, ActionViaJsonString
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
Parameter Sets: ActionExpanded, ActionViaJsonFilePath, ActionViaJsonString
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

### Microsoft.Azure.PowerShell.Cmdlets.Oracle.Models.IDbNodeAction

### Microsoft.Azure.PowerShell.Cmdlets.Oracle.Models.IOracleIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Oracle.Models.IDbActionResponse

## NOTES

## RELATED LINKS

