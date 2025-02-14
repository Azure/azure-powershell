---
external help file:
Module Name: Az.NetworkCloud
online version: https://learn.microsoft.com/powershell/module/az.networkcloud/invoke-aznetworkcloudbaremetalmachinerunreadcommand
schema: 2.0.0
---

# Invoke-AzNetworkCloudBareMetalMachineRunReadCommand

## SYNOPSIS
Run one or more read-only commands on the provided bare metal machine.
The URL to storage account with the command execution results and the command exit code can be retrieved from the operation status API once available.

## SYNTAX

### RunViaIdentityExpanded (Default)
```
Invoke-AzNetworkCloudBareMetalMachineRunReadCommand -InputObject <INetworkCloudIdentity>
 -Command <IBareMetalMachineCommandSpecification[]> -LimitTimeSecond <Int64> [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### RunExpanded
```
Invoke-AzNetworkCloudBareMetalMachineRunReadCommand -BareMetalMachineName <String> -ResourceGroupName <String>
 -Command <IBareMetalMachineCommandSpecification[]> -LimitTimeSecond <Int64> [-SubscriptionId <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Run one or more read-only commands on the provided bare metal machine.
The URL to storage account with the command execution results and the command exit code can be retrieved from the operation status API once available.

## EXAMPLES

### Example 1: Run read command on bare metal machine
```powershell
$command = @{
    Command = "command"
    Argument = "commandArguments"
}

Invoke-AzNetworkCloudBareMetalMachineRunReadCommand -BareMetalMachineName bmmName -ResourceGroupName resourceGroupName -SubscriptionId subscriptionId -Command $command -LimitTimeSecond limitTimeInSeconds -Debug
```

This command runs a read-only command on a bare metal machine.
Including the -Debug flag ensures successful output of the storage account URL containing the command's results.
This is necessary to retrieve the results of the command on the bare metal machine.

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

### -BareMetalMachineName
The name of the bare metal machine.

```yaml
Type: System.String
Parameter Sets: RunExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Command
The list of read-only commands to be executed directly against the target machine.
To construct, see NOTES section for COMMAND properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Models.Api20240701.IBareMetalMachineCommandSpecification[]
Parameter Sets: (All)
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
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Models.INetworkCloudIdentity
Parameter Sets: RunViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -LimitTimeSecond
The maximum time the commands are allowed to run.If the execution time exceeds the maximum, the script will be stopped, any output produced until then will be captured, and the exit code matching a timeout will be returned (252).

```yaml
Type: System.Int64
Parameter Sets: (All)
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

### -PassThru
Returns true when the command succeeds

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
Parameter Sets: RunExpanded
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
Parameter Sets: RunExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Models.INetworkCloudIdentity

## OUTPUTS

### System.Boolean

## NOTES

## RELATED LINKS

