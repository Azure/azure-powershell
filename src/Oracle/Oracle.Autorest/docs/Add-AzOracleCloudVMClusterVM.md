---
external help file:
Module Name: Az.Oracle
online version: https://learn.microsoft.com/powershell/module/az.oracle/add-azoraclecloudvmclustervm
schema: 2.0.0
---

# Add-AzOracleCloudVMClusterVM

## SYNOPSIS
Add VMs to the VM Cluster

## SYNTAX

### AddExpanded (Default)
```
Add-AzOracleCloudVMClusterVM -Cloudvmclustername <String> -ResourceGroupName <String> -DbServer <String[]>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### AddViaIdentityExpanded
```
Add-AzOracleCloudVMClusterVM -InputObject <IOracleIdentity> -DbServer <String[]> [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### AddViaJsonFilePath
```
Add-AzOracleCloudVMClusterVM -Cloudvmclustername <String> -ResourceGroupName <String> -JsonFilePath <String>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### AddViaJsonString
```
Add-AzOracleCloudVMClusterVM -Cloudvmclustername <String> -ResourceGroupName <String> -JsonString <String>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

## DESCRIPTION
Add VMs to the VM Cluster

## EXAMPLES

### Example 1: Add a VM to a Cloud VM Cluster resource
```powershell
$resourceGroup = "PowerShellTestRg"

$dbServerList = Get-AzOracleDbServer -Cloudexadatainfrastructurename "OFake_PowerShellTestExaInfra" -ResourceGroupName $resourceGroup
$dbServerOcid1 = $dbServerList[0].Ocid
$dbServersToAdd = @($dbServerOcid1)

Add-AzOracleCloudVMClusterVM -Cloudvmclustername "OFake_PowerShellTestVmCluster" -ResourceGroupName $resourceGroup -DbServer $dbServersToAdd
```

Add a VM to a Cloud VM Cluster resource.
For more information, execute `Get-Help Add-AzOracleCloudVMClusterVM`.

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

### -Cloudvmclustername
CloudVmCluster name

```yaml
Type: System.String
Parameter Sets: AddExpanded, AddViaJsonFilePath, AddViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DbServer
Db servers ocids

```yaml
Type: System.String[]
Parameter Sets: AddExpanded, AddViaIdentityExpanded
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
Type: Microsoft.Azure.PowerShell.Cmdlets.Oracle.Models.IOracleIdentity
Parameter Sets: AddViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Add operation

```yaml
Type: System.String
Parameter Sets: AddViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Add operation

```yaml
Type: System.String
Parameter Sets: AddViaJsonString
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
Parameter Sets: AddExpanded, AddViaJsonFilePath, AddViaJsonString
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
Parameter Sets: AddExpanded, AddViaJsonFilePath, AddViaJsonString
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

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Oracle.Models.ICloudVMCluster

## NOTES

## RELATED LINKS

