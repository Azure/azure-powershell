---
external help file: Az.NetworkCloud-help.xml
Module Name: Az.NetworkCloud
online version: https://learn.microsoft.com/powershell/module/az.networkcloud/start-aznetworkcloudstorageappliancereadcommand
schema: 2.0.0
---

# Start-AzNetworkCloudStorageApplianceReadCommand

## SYNOPSIS
Run one or more read-only commands on the provided storage appliance.

## SYNTAX

### RunViaIdentityExpanded (Default)
```
Start-AzNetworkCloudStorageApplianceReadCommand -InputObject <INetworkCloudIdentity>
 -Command <IStorageApplianceCommandSpecification[]> -LimitTimeSecond <Int64> [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-PassThru] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### RunViaJsonString
```
Start-AzNetworkCloudStorageApplianceReadCommand -ResourceGroupName <String> -StorageApplianceName <String>
 [-SubscriptionId <String>] -JsonString <String> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### RunViaJsonFilePath
```
Start-AzNetworkCloudStorageApplianceReadCommand -ResourceGroupName <String> -StorageApplianceName <String>
 [-SubscriptionId <String>] -JsonFilePath <String> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### RunExpanded
```
Start-AzNetworkCloudStorageApplianceReadCommand -ResourceGroupName <String> -StorageApplianceName <String>
 [-SubscriptionId <String>] -Command <IStorageApplianceCommandSpecification[]> -LimitTimeSecond <Int64>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru] [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Run one or more read-only commands on the provided storage appliance.

## EXAMPLES

### Example 1: Run read-only health check command on storage appliance
```powershell
$command = @{
    command = "health"
    arguments = @()
}
Start-AzNetworkCloudStorageApplianceReadCommand -StorageApplianceName "storageApplianceName" -ResourceGroupName "resourceGroupName" -Command @($command) -LimitTimeSecond 60
```

```output
True
```

This example runs a read-only health check command on the specified storage appliance with a 60-second timeout.

### Example 2: Run multiple read-only diagnostic commands on storage appliance
```powershell
$command1 = @{
    command = "readiness"
    arguments = @()
}
$command2 = @{
    command = "logs"
    arguments = @("--level", "info")
}
Start-AzNetworkCloudStorageApplianceReadCommand -StorageApplianceName "storageApplianceName" -ResourceGroupName "resourceGroupName" -Command @($command1, $command2) -LimitTimeSecond 120
```

```output
True
```

This example runs multiple read-only diagnostic commands on the storage appliance with a 120-second timeout.

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

### -Command
The list of read-only commands to be executed directly against the target storage appliance.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Models.IStorageApplianceCommandSpecification[]
Parameter Sets: RunViaIdentityExpanded, RunExpanded
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
Type: Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Models.INetworkCloudIdentity
Parameter Sets: RunViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Run operation

```yaml
Type: System.String
Parameter Sets: RunViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Run operation

```yaml
Type: System.String
Parameter Sets: RunViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -LimitTimeSecond
The maximum time the commands are allowed to run.

```yaml
Type: System.Int64
Parameter Sets: RunViaIdentityExpanded, RunExpanded
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
Parameter Sets: RunViaJsonString, RunViaJsonFilePath, RunExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -StorageApplianceName
The name of the storage appliance.

```yaml
Type: System.String
Parameter Sets: RunViaJsonString, RunViaJsonFilePath, RunExpanded
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
Parameter Sets: RunViaJsonString, RunViaJsonFilePath, RunExpanded
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
