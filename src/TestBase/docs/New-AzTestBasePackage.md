---
external help file:
Module Name: Az.TestBase
online version: https://docs.microsoft.com/powershell/module/az.testbase/new-aztestbasepackage
schema: 2.0.0
---

# New-AzTestBasePackage

## SYNOPSIS
Create or replace (overwrite/recreate, with potential downtime) a Test Base Package.

## SYNTAX

```
New-AzTestBasePackage -Name <String> -ResourceGroupName <String> -TestBaseAccountName <String>
 -Location <String> [-SubscriptionId <String>] [-ApplicationName <String>] [-BlobPath <String>]
 [-FlightingRing <String>] [-Tag <Hashtable>] [-TargetOSList <ITargetOSInfo[]>] [-Test <ITest[]>]
 [-Version <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Create or replace (overwrite/recreate, with potential downtime) a Test Base Package.

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
PS C:\> {{ Add code here }}

{{ Add output here }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
PS C:\> {{ Add code here }}

{{ Add output here }}
```

{{ Add description here }}

## PARAMETERS

### -ApplicationName
Application name

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

### -BlobPath
The file path of the package.

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

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

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

### -FlightingRing
The flighting ring for feature update.

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

### -Location
The geo-location where the resource lives

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

### -Name
The resource name of the Test Base Package.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: PackageName

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
The name of the resource group that contains the resource.

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

### -SubscriptionId
The Azure subscription ID.
This is a GUID-formatted string.

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
The tags of the resource.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TargetOSList
Specifies the target OSs of specific OS Update types.
To construct, see NOTES section for TARGETOSLIST properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.TestBase.Models.Api20201216Preview.ITargetOSInfo[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Test
The detailed test information.
To construct, see NOTES section for TEST properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.TestBase.Models.Api20201216Preview.ITest[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TestBaseAccountName
The resource name of the Test Base Account.

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

### -Version
Application version

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

### Microsoft.Azure.PowerShell.Cmdlets.TestBase.Models.Api20201216Preview.IPackageResource

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


TARGETOSLIST <ITargetOSInfo[]>: Specifies the target OSs of specific OS Update types.
  - `OSUpdateType <String>`: Specifies the OS update type to test against, e.g., 'Security updates' or 'Feature updates'.
  - `TargetOSs <String[]>`: Specifies the target OSs to be tested.

TEST <ITest[]>: The detailed test information.
  - `Command <ICommand[]>`: The commands used in the test.
    - `Action <Action>`: The action of the command.
    - `Content <String>`: The content of the command. The content depends on source type.
    - `ContentType <ContentType>`: The type of command content.
    - `Name <String>`: The name of the command.
    - `[AlwaysRun <Boolean?>]`: Specifies whether to run the command even if a previous command is failed.
    - `[ApplyUpdateBefore <Boolean?>]`: Specifies whether to apply update before the command.
    - `[MaxRunTime <Int32?>]`: Specifies the max run time of the command.
    - `[RestartAfter <Boolean?>]`: Specifies whether to restart the VM after the command executed.
    - `[RunAsInteractive <Boolean?>]`: Specifies whether to run the command in interactive mode.
    - `[RunElevated <Boolean?>]`: Specifies whether to run the command as administrator.
  - `Type <TestType>`: The type of the test.
  - `[IsActive <Boolean?>]`: Indicates if this test is active.It doesn't schedule test for not active Test.

## RELATED LINKS

