---
external help file: Az.NetworkCloud-help.xml
Module Name: Az.NetworkCloud
online version: https://learn.microsoft.com/powershell/module/az.networkcloud/invoke-aznetworkcloudbaremetalmachinedataextractrestricted
schema: 2.0.0
---

# Invoke-AzNetworkCloudBareMetalMachineDataExtractRestricted

## SYNOPSIS
Run one or more restricted data extractions on the provided bare metal machine.
The URL to storage account with the command execution results and the command exit code can be retrieved from the operation status API once available.

## SYNTAX

### RunViaIdentity (Default)
```
Invoke-AzNetworkCloudBareMetalMachineDataExtractRestricted -InputObject <INetworkCloudIdentity>
 -BareMetalMachineRunDataExtractsRestrictedParameter <IBareMetalMachineRunDataExtractsParameters>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru] [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

### RunViaJsonString
```
Invoke-AzNetworkCloudBareMetalMachineDataExtractRestricted -BareMetalMachineName <String>
 -ResourceGroupName <String> [-SubscriptionId <String>] -JsonString <String> [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-PassThru] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### RunViaJsonFilePath
```
Invoke-AzNetworkCloudBareMetalMachineDataExtractRestricted -BareMetalMachineName <String>
 -ResourceGroupName <String> [-SubscriptionId <String>] -JsonFilePath <String> [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-PassThru] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### RunExpanded
```
Invoke-AzNetworkCloudBareMetalMachineDataExtractRestricted -BareMetalMachineName <String>
 -ResourceGroupName <String> [-SubscriptionId <String>] -Command <IBareMetalMachineCommandSpecification[]>
 -LimitTimeSecond <Int64> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### Run
```
Invoke-AzNetworkCloudBareMetalMachineDataExtractRestricted -BareMetalMachineName <String>
 -ResourceGroupName <String> [-SubscriptionId <String>]
 -BareMetalMachineRunDataExtractsRestrictedParameter <IBareMetalMachineRunDataExtractsParameters>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru] [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

### RunViaIdentityExpanded
```
Invoke-AzNetworkCloudBareMetalMachineDataExtractRestricted -InputObject <INetworkCloudIdentity>
 -Command <IBareMetalMachineCommandSpecification[]> -LimitTimeSecond <Int64> [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-PassThru] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Run one or more restricted data extractions on the provided bare metal machine.
The URL to storage account with the command execution results and the command exit code can be retrieved from the operation status API once available.

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here }}
```

{{ Add description here }}

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
Parameter Sets: RunViaJsonString, RunViaJsonFilePath, RunExpanded, Run
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -BareMetalMachineRunDataExtractsRestrictedParameter
BareMetalMachineRunDataExtractsParameters represents the body of request containing list of curated data extraction commands to run on the bare metal machine.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Models.IBareMetalMachineRunDataExtractsParameters
Parameter Sets: RunViaIdentity, Run
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Command
The list of curated data extraction commands to be executed directly against the target machine.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Models.IBareMetalMachineCommandSpecification[]
Parameter Sets: RunExpanded, RunViaIdentityExpanded
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
Parameter Sets: RunViaIdentity, RunViaIdentityExpanded
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
If the execution time exceeds the maximum, the script will be stopped, any output produced until then will be captured, and the exit code matching a timeout will be returned (252).

```yaml
Type: System.Int64
Parameter Sets: RunExpanded, RunViaIdentityExpanded
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
Parameter Sets: RunViaJsonString, RunViaJsonFilePath, RunExpanded, Run
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
Parameter Sets: RunViaJsonString, RunViaJsonFilePath, RunExpanded, Run
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

### Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Models.IBareMetalMachineRunDataExtractsParameters

### Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Models.INetworkCloudIdentity

## OUTPUTS

### System.Boolean

## NOTES

## RELATED LINKS
