---
external help file:
Module Name: Az.HorizonDB
online version: https://learn.microsoft.com/powershell/module/az.horizondb/initialize-azhorizondbchangedatacapturedestinationidentity
schema: 2.0.0
---

# Initialize-AzHorizonDbChangeDataCaptureDestinationIdentity

## SYNOPSIS
Atomically activates a validated identity assignment for this destination.
If-Match is evaluated against the destination entity tag.
Activating the already-active assignment succeeds idempotently.

## SYNTAX

### ActivateExpanded (Default)
```
Initialize-AzHorizonDbChangeDataCaptureDestinationIdentity -ClusterName <String> -DestinationName <String>
 -ResourceGroupName <String> -IfMatch <String> -IdentityAssignmentResourceId <String>
 [-SubscriptionId <String>] [-DrainExistingSession] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### Activate
```
Initialize-AzHorizonDbChangeDataCaptureDestinationIdentity -ClusterName <String> -DestinationName <String>
 -ResourceGroupName <String> -IfMatch <String> -Body <IActivateChangeDataCaptureIdentityRequest>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### ActivateViaIdentity
```
Initialize-AzHorizonDbChangeDataCaptureDestinationIdentity -InputObject <IHorizonDbIdentity> -IfMatch <String>
 -Body <IActivateChangeDataCaptureIdentityRequest> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### ActivateViaIdentityCluster
```
Initialize-AzHorizonDbChangeDataCaptureDestinationIdentity -ClusterInputObject <IHorizonDbIdentity>
 -DestinationName <String> -IfMatch <String> -Body <IActivateChangeDataCaptureIdentityRequest>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### ActivateViaIdentityClusterExpanded
```
Initialize-AzHorizonDbChangeDataCaptureDestinationIdentity -ClusterInputObject <IHorizonDbIdentity>
 -DestinationName <String> -IfMatch <String> -IdentityAssignmentResourceId <String> [-DrainExistingSession]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### ActivateViaIdentityExpanded
```
Initialize-AzHorizonDbChangeDataCaptureDestinationIdentity -InputObject <IHorizonDbIdentity> -IfMatch <String>
 -IdentityAssignmentResourceId <String> [-DrainExistingSession] [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### ActivateViaJsonFilePath
```
Initialize-AzHorizonDbChangeDataCaptureDestinationIdentity -ClusterName <String> -DestinationName <String>
 -ResourceGroupName <String> -IfMatch <String> -JsonFilePath <String> [-SubscriptionId <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### ActivateViaJsonString
```
Initialize-AzHorizonDbChangeDataCaptureDestinationIdentity -ClusterName <String> -DestinationName <String>
 -ResourceGroupName <String> -IfMatch <String> -JsonString <String> [-SubscriptionId <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Atomically activates a validated identity assignment for this destination.
If-Match is evaluated against the destination entity tag.
Activating the already-active assignment succeeds idempotently.

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
The request to activate an identity assignment for a change data capture destination.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.HorizonDB.Models.IActivateChangeDataCaptureIdentityRequest
Parameter Sets: Activate, ActivateViaIdentity, ActivateViaIdentityCluster
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ClusterInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.HorizonDB.Models.IHorizonDbIdentity
Parameter Sets: ActivateViaIdentityCluster, ActivateViaIdentityClusterExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ClusterName
The name of the HorizonDB cluster.

```yaml
Type: System.String
Parameter Sets: Activate, ActivateExpanded, ActivateViaJsonFilePath, ActivateViaJsonString
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

### -DestinationName
The caller-selected name of the change data capture destination.

```yaml
Type: System.String
Parameter Sets: Activate, ActivateExpanded, ActivateViaIdentityCluster, ActivateViaIdentityClusterExpanded, ActivateViaJsonFilePath, ActivateViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DrainExistingSession
Whether existing destination sessions should drain before the identity cutover.
The default is false.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: ActivateExpanded, ActivateViaIdentityClusterExpanded, ActivateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IdentityAssignmentResourceId
The resource ID of an inactive, successfully validated identity assignment under the destination receiving the action.

```yaml
Type: System.String
Parameter Sets: ActivateExpanded, ActivateViaIdentityClusterExpanded, ActivateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IfMatch
The destination entity tag.
The action proceeds only when this value matches the destination's current entity tag.

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

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.HorizonDB.Models.IHorizonDbIdentity
Parameter Sets: ActivateViaIdentity, ActivateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Activate operation

```yaml
Type: System.String
Parameter Sets: ActivateViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Activate operation

```yaml
Type: System.String
Parameter Sets: ActivateViaJsonString
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
Parameter Sets: Activate, ActivateExpanded, ActivateViaJsonFilePath, ActivateViaJsonString
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
Parameter Sets: Activate, ActivateExpanded, ActivateViaJsonFilePath, ActivateViaJsonString
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

### Microsoft.Azure.PowerShell.Cmdlets.HorizonDB.Models.IActivateChangeDataCaptureIdentityRequest

### Microsoft.Azure.PowerShell.Cmdlets.HorizonDB.Models.IHorizonDbIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.HorizonDB.Models.IActivateChangeDataCaptureIdentityResult

## NOTES

## RELATED LINKS

