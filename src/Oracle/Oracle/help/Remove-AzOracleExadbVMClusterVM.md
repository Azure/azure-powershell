---
external help file:
Module Name: Az.Oracle
online version: https://learn.microsoft.com/powershell/module/az.oracle/remove-azoracleexadbvmclustervm
schema: 2.0.0
---

# Remove-AzOracleExadbVMClusterVM

## SYNOPSIS
Remove VMs from the VM Cluster

## SYNTAX

### RemoveViaIdentity (Default)
```
Remove-AzOracleExadbVMClusterVM -InputObject <IOracleIdentity>
 -Body <IRemoveVirtualMachineFromExadbVMClusterDetails> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Remove
```
Remove-AzOracleExadbVMClusterVM -ExadbVMClusterName <String> -ResourceGroupName <String>
 -Body <IRemoveVirtualMachineFromExadbVMClusterDetails> [-SubscriptionId <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### RemoveExpanded
```
Remove-AzOracleExadbVMClusterVM -ExadbVMClusterName <String> -ResourceGroupName <String>
 -DbNode <IDbNodeDetails[]> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### RemoveViaIdentityExpanded
```
Remove-AzOracleExadbVMClusterVM -InputObject <IOracleIdentity> -DbNode <IDbNodeDetails[]>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### RemoveViaJsonFilePath
```
Remove-AzOracleExadbVMClusterVM -ExadbVMClusterName <String> -ResourceGroupName <String>
 -JsonFilePath <String> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### RemoveViaJsonString
```
Remove-AzOracleExadbVMClusterVM -ExadbVMClusterName <String> -ResourceGroupName <String> -JsonString <String>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

## DESCRIPTION
Remove VMs from the VM Cluster

## EXAMPLES

### Example 1: Remove a VM from a Cloud VM Cluster resource
```powershell
$resourceGroup = "PowerShellTestRg"

$dbNodeList = Get-AzOracleExascaleDbNode -Exadbvmclustername "OFake_PowerShellTestVmCluster" -ResourceGroupName $resourceGroup
$dbNodeOcid1 = $dbNodeList[0].Ocid
$dbNodeToRemove = @($dbNodeOcid1)

Remove-AzOracleExadbVMClusterVM -Exadbvmclustername "OFake_PowerShellTestVmCluster" -ResourceGroupName $resourceGroup -DbNode $dbNodeToRemove
```

Remove a VM from a Cloud VM Cluster resource.
For more information, execute `Get-Help Remove-AzOracleCloudVMClusterVM`.

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

### -Body
Details of removing Virtual Machines from the Exadata VM cluster on Exascale Infrastructure.
Applies to Exadata Database Service on Exascale Infrastructure only.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Oracle.Models.IRemoveVirtualMachineFromExadbVMClusterDetails
Parameter Sets: Remove, RemoveViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -DbNode
The list of ExaCS DB nodes for the Exadata VM cluster on Exascale Infrastructure to be removed.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Oracle.Models.IDbNodeDetails[]
Parameter Sets: RemoveExpanded, RemoveViaIdentityExpanded
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

### -ExadbVMClusterName
The name of the ExadbVmCluster

```yaml
Type: System.String
Parameter Sets: Remove, RemoveExpanded, RemoveViaJsonFilePath, RemoveViaJsonString
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
Parameter Sets: RemoveViaIdentity, RemoveViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Remove operation

```yaml
Type: System.String
Parameter Sets: RemoveViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Remove operation

```yaml
Type: System.String
Parameter Sets: RemoveViaJsonString
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
Parameter Sets: Remove, RemoveExpanded, RemoveViaJsonFilePath, RemoveViaJsonString
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
Parameter Sets: Remove, RemoveExpanded, RemoveViaJsonFilePath, RemoveViaJsonString
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

### Microsoft.Azure.PowerShell.Cmdlets.Oracle.Models.IOracleIdentity

### Microsoft.Azure.PowerShell.Cmdlets.Oracle.Models.IRemoveVirtualMachineFromExadbVMClusterDetails

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Oracle.Models.IExadbVMCluster

## NOTES

## RELATED LINKS

