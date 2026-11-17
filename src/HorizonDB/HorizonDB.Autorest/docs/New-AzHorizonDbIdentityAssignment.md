---
external help file:
Module Name: Az.HorizonDB
online version: https://learn.microsoft.com/powershell/module/az.horizondb/new-azhorizondbidentityassignment
schema: 2.0.0
---

# New-AzHorizonDbIdentityAssignment

## SYNOPSIS
Create or idempotently replaces a change data capture identity assignment.
The identity resource ID is immutable and must reference a user-assigned managed identity already attached to the parent cluster.
The service also validates destination permissions, which are not granted by attaching the identity to the cluster.

## SYNTAX

### CreateExpanded (Default)
```
New-AzHorizonDbIdentityAssignment -AssignmentName <String> -ClusterName <String> -DestinationName <String>
 -ResourceGroupName <String> [-SubscriptionId <String>] [-IdentityResourceId <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaIdentityChangeDataCaptureDestinationExpanded
```
New-AzHorizonDbIdentityAssignment -AssignmentName <String>
 -ChangeDataCaptureDestinationInputObject <IHorizonDbIdentity> [-IdentityResourceId <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaIdentityClusterExpanded
```
New-AzHorizonDbIdentityAssignment -AssignmentName <String> -ClusterInputObject <IHorizonDbIdentity>
 -DestinationName <String> [-IdentityResourceId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaJsonFilePath
```
New-AzHorizonDbIdentityAssignment -AssignmentName <String> -ClusterName <String> -DestinationName <String>
 -ResourceGroupName <String> -JsonFilePath <String> [-SubscriptionId <String>] [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaJsonString
```
New-AzHorizonDbIdentityAssignment -AssignmentName <String> -ClusterName <String> -DestinationName <String>
 -ResourceGroupName <String> -JsonString <String> [-SubscriptionId <String>] [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Create or idempotently replaces a change data capture identity assignment.
The identity resource ID is immutable and must reference a user-assigned managed identity already attached to the parent cluster.
The service also validates destination permissions, which are not granted by attaching the identity to the cluster.

## EXAMPLES

### Example 1: Assign a managed identity to a change data capture destination
```powershell
$subscriptionId = (Get-AzContext).Subscription.Id
$identityId = "/subscriptions/$subscriptionId/resourceGroups/identity-resource-group/providers/Microsoft.ManagedIdentity/userAssignedIdentities/fabric-writer"

New-AzHorizonDbIdentityAssignment -ResourceGroupName 'example-resource-group' -ClusterName 'example-cluster' -DestinationName 'fabric-mirroring' -AssignmentName 'fabric-writer' -IdentityResourceId $identityId | Format-List -Property Name, IdentityResourceId, ValidationState, ActivationState, ProvisioningState
```

```output
Name               : fabric-writer
IdentityResourceId : /subscriptions/ffffffff-ffff-ffff-ffff-ffffffffffff/resourceGroups/identity-resource-group/providers/Microsoft.ManagedIdentity/userAssignedIdentities/fabric-writer
ValidationState    : Succeeded
ActivationState    : Inactive
ProvisioningState  : Succeeded
```

Sample output from the HTTP 200 response.
Values are illustrative REST response data, not a live execution result.

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

### -AssignmentName
The caller-selected name of the identity assignment.

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

### -ChangeDataCaptureDestinationInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.HorizonDB.Models.IHorizonDbIdentity
Parameter Sets: CreateViaIdentityChangeDataCaptureDestinationExpanded
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
Parameter Sets: CreateViaIdentityClusterExpanded
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
Parameter Sets: CreateExpanded, CreateViaJsonFilePath, CreateViaJsonString
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
Parameter Sets: CreateExpanded, CreateViaIdentityClusterExpanded, CreateViaJsonFilePath, CreateViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IdentityResourceId
The immutable resource ID of the user-assigned managed identity selected for this destination.
The ID must exactly match a key in the parent cluster's top-level identity.userAssignedIdentities dictionary; otherwise creation is rejected.
Attaching the identity to the cluster does not grant destination access, so required role assignments must be configured separately.
Resubmitting the same value is accepted; changing it requires deleting and recreating the assignment.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityChangeDataCaptureDestinationExpanded, CreateViaIdentityClusterExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Create operation

```yaml
Type: System.String
Parameter Sets: CreateViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Create operation

```yaml
Type: System.String
Parameter Sets: CreateViaJsonString
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
Parameter Sets: CreateExpanded, CreateViaJsonFilePath, CreateViaJsonString
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
Parameter Sets: CreateExpanded, CreateViaJsonFilePath, CreateViaJsonString
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

### Microsoft.Azure.PowerShell.Cmdlets.HorizonDB.Models.IHorizonDbIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.HorizonDB.Models.IIdentityAssignment

## NOTES

## RELATED LINKS

