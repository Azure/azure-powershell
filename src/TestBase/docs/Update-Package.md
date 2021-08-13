---
external help file:
Module Name: TestBase
online version: https://docs.microsoft.com/en-us/powershell/module/testbase/update-package
schema: 2.0.0
---

# Update-Package

## SYNOPSIS
Update an existing Test Base Package.

## SYNTAX

### UpdateExpanded (Default)
```
Update-Package -PackageName <String> -ResourceGroupName <String> -SubscriptionId <String>
 -TestBaseAccountName <String> [-BlobPath <String>] [-FlightingRing <String>] [-IsEnabled] [-Tags <Hashtable>]
 [-TargetOSList <ITargetOSInfo[]>] [-Tests <ITest[]>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### Update
```
Update-Package -PackageName <String> -ResourceGroupName <String> -SubscriptionId <String>
 -TestBaseAccountName <String> -Parameters <IPackageUpdateParameters> [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### UpdateViaIdentity
```
Update-Package -InputObject <ITestBaseIdentity> -Parameters <IPackageUpdateParameters> [-AsJob] [-NoWait]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-Package -InputObject <ITestBaseIdentity> [-BlobPath <String>] [-FlightingRing <String>] [-IsEnabled]
 [-Tags <Hashtable>] [-TargetOSList <ITargetOSInfo[]>] [-Tests <ITest[]>] [-AsJob] [-NoWait] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Update an existing Test Base Package.

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
The file name of the package.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

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
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

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
Type: Sample.API.Models.ITestBaseIdentity
Parameter Sets: UpdateViaIdentity, UpdateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -IsEnabled
Specifies whether the package is enabled.
It doesn't schedule test for package which is not enabled.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
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

### -PackageName
The resource name of the Test Base Package.

```yaml
Type: System.String
Parameter Sets: Update, UpdateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Parameters
Parameters supplied to update a Test Base Package.
To construct, see NOTES section for PARAMETERS properties and create a hash table.

```yaml
Type: Sample.API.Models.IPackageUpdateParameters
Parameter Sets: Update, UpdateViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group that contains the resource.

```yaml
Type: System.String
Parameter Sets: Update, UpdateExpanded
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
Parameter Sets: Update, UpdateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Tags
The tags of the Package.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
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
Type: Sample.API.Models.ITargetOSInfo[]
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
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
Parameter Sets: Update, UpdateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Tests
The detailed test information.
To construct, see NOTES section for TESTS properties and create a hash table.

```yaml
Type: Sample.API.Models.ITest[]
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
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

### Sample.API.Models.IPackageUpdateParameters

### Sample.API.Models.ITestBaseIdentity

## OUTPUTS

### Sample.API.Models.IPackageResource

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


INPUTOBJECT <ITestBaseIdentity>: Identity Parameter
  - `[AnalysisResultName <AnalysisResultName?>]`: The name of the Analysis Result of a Test Result.
  - `[AvailableOSResourceName <String>]`: The resource name of an Available OS.
  - `[CustomerEventName <String>]`: The resource name of the Test Base Customer event.
  - `[EmailEventResourceName <String>]`: The resource name of an email event.
  - `[FavoriteProcessResourceName <String>]`: The resource name of a favorite process in a package. If the process name contains characters that are not allowed in Azure Resource Name, we use 'actualProcessName' in request body to submit the name.
  - `[FlightingRingResourceName <String>]`: The resource name of a flighting ring.
  - `[OSUpdateResourceName <String>]`: The resource name of an OS Update.
  - `[PackageName <String>]`: The resource name of the Test Base Package.
  - `[ResourceGroupName <String>]`: The name of the resource group that contains the resource.
  - `[SubscriptionId <String>]`: The Azure subscription ID. This is a GUID-formatted string.
  - `[TestBaseAccountName <String>]`: The resource name of the Test Base Account.
  - `[TestResultName <String>]`: The Test Result Name. It equals to {osName}-{TestResultId} string.
  - `[TestSummaryName <String>]`: The name of the Test Summary.
  - `[TestTypeResourceName <String>]`: The resource name of a test type.

PARAMETERS <IPackageUpdateParameters>: Parameters supplied to update a Test Base Package.
  - `[BlobPath <String>]`: The file name of the package.
  - `[FlightingRing <String>]`: The flighting ring for feature update.
  - `[IsEnabled <Boolean?>]`: Specifies whether the package is enabled. It doesn't schedule test for package which is not enabled.
  - `[Tags <ITags>]`: The tags of the Package.
    - `[(Any) <String>]`: This indicates any property can be added to this object.
  - `[TargetOSList <ITargetOSInfo[]>]`: Specifies the target OSs of specific OS Update types.
    - `OSUpdateType <String>`: Specifies the OS update type to test against, e.g., 'Security updates' or 'Feature updates'.
    - `TargetOSs <String[]>`: Specifies the target OSs to be tested.
  - `[Tests <ITest[]>]`: The detailed test information.
    - `Commands <ICommand[]>`: The commands used in the test.
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
    - `TestType <TestType>`: The type of the test.
    - `[IsActive <Boolean?>]`: Indicates if this test is active.It doesn't schedule test for not active Test.

TARGETOSLIST <ITargetOSInfo[]>: Specifies the target OSs of specific OS Update types.
  - `OSUpdateType <String>`: Specifies the OS update type to test against, e.g., 'Security updates' or 'Feature updates'.
  - `TargetOSs <String[]>`: Specifies the target OSs to be tested.

TESTS <ITest[]>: The detailed test information.
  - `Commands <ICommand[]>`: The commands used in the test.
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
  - `TestType <TestType>`: The type of the test.
  - `[IsActive <Boolean?>]`: Indicates if this test is active.It doesn't schedule test for not active Test.

## RELATED LINKS

