---
external help file:
Module Name: Az.SpringApps
online version: https://learn.microsoft.com/powershell/module/az.springapps/update-azspringapplicationaccelerator
schema: 2.0.0
---

# Update-AzSpringApplicationAccelerator

## SYNOPSIS
Update the application accelerator.

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzSpringApplicationAccelerator -Name <String> -ResourceGroupName <String> -ServiceName <String>
 [-SubscriptionId <String>] [-SkuCapacity <Int32>] [-SkuName <String>] [-SkuTier <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzSpringApplicationAccelerator -InputObject <ISpringAppsIdentity> [-SkuCapacity <Int32>]
 [-SkuName <String>] [-SkuTier <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### UpdateViaIdentitySpringExpanded
```
Update-AzSpringApplicationAccelerator -Name <String> -SpringInputObject <ISpringAppsIdentity>
 [-SkuCapacity <Int32>] [-SkuName <String>] [-SkuTier <String>] [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Update the application accelerator.

## EXAMPLES

### Example 1: Update the application accelerator.
```powershell
Update-AzSpringApplicationAccelerator -Name default -ResourceGroupName azps_test_group_spring -ServiceName azps-spring-01 -SkuName E0 -SkuCapacity 2 -SkuTier Enterprise
```

```output
Component                    : {{
                                 "resourceRequests": {
                                   "cpu": "200m",
                                   "memory": "256Mi",
                                   "instanceCount": 2
                                 },
                                 "name": "accelerator-server",
                                 "instances": [
                                   {
                                     "name": "acc-server-744d7b79b5-s4b8x",
                                     "status": "Running"
                                   },
                                   {
                                     "name": "acc-server-744d7b79b5-xpnzr",
                                     "status": "Running"
                                   }
                                 ]
                               }, {
                                 "resourceRequests": {
                                   "cpu": "1000m",
                                   "memory": "3Gi",
                                   "instanceCount": 1
                                 },
                                 "name": "accelerator-engine",
                                 "instances": [
                                   {
                                     "name": "acc-engine-799bc59df8-wr2p2",
                                     "status": "Running"
                                   }
                                 ]
                               }, {
                                 "resourceRequests": {
                                   "cpu": "200m",
                                   "memory": "256Mi",
                                   "instanceCount": 1
                                 },
                                 "name": "accelerator-controller",
                                 "instances": [
                                   {
                                     "name": "accelerator-controller-manager-565b9c888b-qldlg",
                                     "status": "Running"
                                   }
                                 ]
                               }, {
                                 "resourceRequests": {
                                   "cpu": "200m",
                                   "memory": "256Mi",
                                   "instanceCount": 1
                                 },
                                 "name": "source-controller",
                                 "instances": [
                                   {
                                     "name": "source-controller-manager-5c9cd87f5-bwr9x",
                                     "status": "Running"
                                   }
                                 ]
                               }…}
Id                           : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/azps_test_group_spring/providers/Microsoft.AppPlatform/Spring/azps-spring-01/applicationAccelerators/default
Name                         : default
ProvisioningState            : Succeeded
ResourceGroupName            : azps_test_group_spring
SkuCapacity                  :
SkuName                      :
SkuTier                      :
SystemDataCreatedAt          : 2024-05-24 上午 07:01:38
SystemDataCreatedBy          : v-jinpel@microsoft.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 2024-05-28 上午 11:55:35
SystemDataLastModifiedBy     : v-jinpel@microsoft.com
SystemDataLastModifiedByType : User
Type                         : Microsoft.AppPlatform/Spring/applicationAccelerators
```

Update the application accelerator.

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
Type: Microsoft.Azure.PowerShell.Cmdlets.SpringApps.Models.ISpringAppsIdentity
Parameter Sets: UpdateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The name of the application accelerator.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentitySpringExpanded
Aliases: ApplicationAcceleratorName

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
You can obtain this value from the Azure Resource Manager API or the portal.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ServiceName
The name of the Service resource.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SkuCapacity
Current capacity of the target resource

```yaml
Type: System.Int32
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SkuName
Name of the Sku

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

### -SkuTier
Tier of the Sku

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

### -SpringInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.SpringApps.Models.ISpringAppsIdentity
Parameter Sets: UpdateViaIdentitySpringExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -SubscriptionId
Gets subscription ID which uniquely identify the Microsoft Azure subscription.
The subscription ID forms part of the URI for every service call.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.SpringApps.Models.ISpringAppsIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.SpringApps.Models.IApplicationAcceleratorResource

## NOTES

## RELATED LINKS

