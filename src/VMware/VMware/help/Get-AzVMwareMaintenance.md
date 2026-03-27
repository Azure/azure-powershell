---
external help file: Az.VMware-help.xml
Module Name: Az.VMware
online version: https://learn.microsoft.com/powershell/module/az.vmware/get-azvmwaremaintenance
schema: 2.0.0
---

# Get-AzVMwareMaintenance

## SYNOPSIS
Get a Maintenance

## SYNTAX

### List (Default)
```
Get-AzVMwareMaintenance -PrivateCloudName <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-From <DateTime>] [-StateName <String>] [-Status <String>] [-To <DateTime>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentityPrivateCloud
```
Get-AzVMwareMaintenance -Name <String> -PrivateCloudInputObject <IVMwareIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### Get
```
Get-AzVMwareMaintenance -Name <String> -PrivateCloudName <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzVMwareMaintenance -InputObject <IVMwareIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Get a Maintenance

## EXAMPLES

### Example 1: List maintenance under resource group
```powershell
Get-AzVMwareMaintenance -PrivateCloudName azps_test_cloud -ResourceGroupName azps_test_group
```

```output
Name         ResourceGroupName
----         -----------------
maintenance1 group1
maintenance2 group1
```

Lists all maintenance items within the specified private cloud and resource group

### Example 2: Get a maintenace by name in a private cloud
```powershell
Get-AzVMwareMaintenance -Name maintenance1 -PrivateCloudName azps_test_cloud -ResourceGroupName azps_test_group
```

```output
Name         DisplayName      Component StateName ReadinessStatus ScheduledStartTime    EstimatedDurationInMinute ClusterId
----         -----------      --------- --------- --------------- ------------------    ------------------------- ---------
maintenance1 vcsa 7.0 upgrade VCSA      Scheduled NotReady        1/12/2023 11:00:11 AM                       960         1
```

Gets detailed information about a specific maintenance item by name within the private cloud and resource group.

## PARAMETERS

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

### -From
date from which result should be returned.
ie.
scheduledStartTime \>= from

```yaml
Type: System.DateTime
Parameter Sets: List
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.IVMwareIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
Name of the maintenance

```yaml
Type: System.String
Parameter Sets: GetViaIdentityPrivateCloud, Get
Aliases: MaintenanceName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PrivateCloudInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.IVMwareIdentity
Parameter Sets: GetViaIdentityPrivateCloud
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -PrivateCloudName
Name of the private cloud

```yaml
Type: System.String
Parameter Sets: List, Get
Aliases:

Required: True
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
Parameter Sets: List, Get
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -StateName
Filter maintenances based on state

```yaml
Type: System.String
Parameter Sets: List
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Status
Filter active or inactive maintenances

```yaml
Type: System.String
Parameter Sets: List
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.
The value must be an UUID.

```yaml
Type: System.String[]
Parameter Sets: List, Get
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -To
date till which result should be returned.
i.e.
scheduledStartTime \<= to

```yaml
Type: System.DateTime
Parameter Sets: List
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.IVMwareIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.IMaintenance

## NOTES

## RELATED LINKS
