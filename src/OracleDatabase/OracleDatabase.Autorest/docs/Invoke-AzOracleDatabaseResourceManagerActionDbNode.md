---
external help file:
Module Name: Az.OracleDatabaseResourceManager
online version: https://learn.microsoft.com/powershell/module/az.oracledatabaseresourcemanager/invoke-azoracledatabaseresourcemanageractiondbnode
schema: 2.0.0
---

# Invoke-AzOracleDatabaseResourceManagerActionDbNode

## SYNOPSIS
VM actions on DbNode of VM Cluster by the provided filter

## SYNTAX

### ActionExpanded (Default)
```
Invoke-AzOracleDatabaseResourceManagerActionDbNode -Cloudvmclustername <String> -Dbnodeocid <String>
 -ResourceGroupName <String> -Action <String> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Action
```
Invoke-AzOracleDatabaseResourceManagerActionDbNode -Cloudvmclustername <String> -Dbnodeocid <String>
 -ResourceGroupName <String> -Body <IDbNodeAction> [-SubscriptionId <String>] [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### ActionViaIdentity
```
Invoke-AzOracleDatabaseResourceManagerActionDbNode -InputObject <IOracleDatabaseResourceManagerIdentity>
 -Body <IDbNodeAction> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### ActionViaIdentityCloudVMCluster
```
Invoke-AzOracleDatabaseResourceManagerActionDbNode
 -CloudVMClusterInputObject <IOracleDatabaseResourceManagerIdentity> -Dbnodeocid <String>
 -Body <IDbNodeAction> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### ActionViaIdentityCloudVMClusterExpanded
```
Invoke-AzOracleDatabaseResourceManagerActionDbNode
 -CloudVMClusterInputObject <IOracleDatabaseResourceManagerIdentity> -Dbnodeocid <String> -Action <String>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### ActionViaIdentityExpanded
```
Invoke-AzOracleDatabaseResourceManagerActionDbNode -InputObject <IOracleDatabaseResourceManagerIdentity>
 -Action <String> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### ActionViaJsonFilePath
```
Invoke-AzOracleDatabaseResourceManagerActionDbNode -Cloudvmclustername <String> -Dbnodeocid <String>
 -ResourceGroupName <String> -JsonFilePath <String> [-SubscriptionId <String>] [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### ActionViaJsonString
```
Invoke-AzOracleDatabaseResourceManagerActionDbNode -Cloudvmclustername <String> -Dbnodeocid <String>
 -ResourceGroupName <String> -JsonString <String> [-SubscriptionId <String>] [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
VM actions on DbNode of VM Cluster by the provided filter

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here (remove the output block if the example doesn't have an output) }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here (remove the output block if the example doesn't have an output) }}
```

{{ Add description here }}

## PARAMETERS

### -Action
Db action

```yaml
Type: System.String
Parameter Sets: ActionExpanded, ActionViaIdentityCloudVMClusterExpanded, ActionViaIdentityExpanded
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
Type: Microsoft.Azure.PowerShell.Cmdlets.OracleDatabaseResourceManager.Models.IDbNodeAction
Parameter Sets: Action, ActionViaIdentity, ActionViaIdentityCloudVMCluster
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -CloudVMClusterInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.OracleDatabaseResourceManager.Models.IOracleDatabaseResourceManagerIdentity
Parameter Sets: ActionViaIdentityCloudVMCluster, ActionViaIdentityCloudVMClusterExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Cloudvmclustername
CloudVmCluster name

```yaml
Type: System.String
Parameter Sets: Action, ActionExpanded, ActionViaJsonFilePath, ActionViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Dbnodeocid
DbNode OCID.

```yaml
Type: System.String
Parameter Sets: Action, ActionExpanded, ActionViaIdentityCloudVMCluster, ActionViaIdentityCloudVMClusterExpanded, ActionViaJsonFilePath, ActionViaJsonString
Aliases:

Required: True
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

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.OracleDatabaseResourceManager.Models.IOracleDatabaseResourceManagerIdentity
Parameter Sets: ActionViaIdentity, ActionViaIdentityExpanded
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
Parameter Sets: Action, ActionExpanded, ActionViaJsonFilePath, ActionViaJsonString
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
Parameter Sets: Action, ActionExpanded, ActionViaJsonFilePath, ActionViaJsonString
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

### Microsoft.Azure.PowerShell.Cmdlets.OracleDatabaseResourceManager.Models.IDbNodeAction

### Microsoft.Azure.PowerShell.Cmdlets.OracleDatabaseResourceManager.Models.IOracleDatabaseResourceManagerIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.OracleDatabaseResourceManager.Models.IDbNode

## NOTES

## RELATED LINKS

