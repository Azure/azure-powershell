---
external help file:
Module Name: Az.VMware
online version: https://learn.microsoft.com/powershell/module/az.vmware/get-azvmwareglobalreachconnection
schema: 2.0.0
---

# Get-AzVMwareGlobalReachConnection

## SYNOPSIS
Get a global reach connection by name in a private cloud

## SYNTAX

### List (Default)
```
Get-AzVMwareGlobalReachConnection -PrivateCloudName <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzVMwareGlobalReachConnection -Name <String> -PrivateCloudName <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzVMwareGlobalReachConnection -InputObject <IVMwareIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentityPrivateCloud
```
Get-AzVMwareGlobalReachConnection -Name <String> -PrivateCloudInputObject <IVMwareIdentity>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Get a global reach connection by name in a private cloud

## EXAMPLES

### Example 1: List global reach connection in a private cloud
```powershell
Get-AzVMwareGlobalReachConnection -PrivateCloudName azps_test_cloud -ResourceGroupName azps_test_group
```

```output
Name          Type                                               ResourceGroupName
----          ----                                               -----------------
azps_test_grc Microsoft.AVS/privateClouds/globalReachConnections azps_test_group
```

List global reach connection in a private cloud

### Example 2: Get a global reach connection by name in a private cloud
```powershell
Get-AzVMwareGlobalReachConnection -Name azps_test_grc -PrivateCloudName azps_test_cloud -ResourceGroupName azps_test_group
```

```output
Name          Type                                               ResourceGroupName
----          ----                                               -----------------
azps_test_grc Microsoft.AVS/privateClouds/globalReachConnections azps_test_group
```

Get a global reach connection by name in a private cloud

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

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

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
Name of the global reach connection in the private cloud

```yaml
Type: System.String
Parameter Sets: Get, GetViaIdentityPrivateCloud
Aliases: GlobalReachConnectionName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PrivateCloudInputObject
Identity Parameter
To construct, see NOTES section for PRIVATECLOUDINPUTOBJECT properties and create a hash table.

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
Parameter Sets: Get, List
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
Parameter Sets: Get, List
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.

```yaml
Type: System.String[]
Parameter Sets: Get, List
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.IVMwareIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.IGlobalReachConnection

## NOTES

## RELATED LINKS

