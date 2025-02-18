---
external help file:
Module Name: Az.NetworkCloud
online version: https://learn.microsoft.com/powershell/module/az.networkcloud/new-aznetworkcloudbmckeyset
schema: 2.0.0
---

# New-AzNetworkCloudBmcKeySet

## SYNOPSIS
Create a new baseboard management controller key set or update the existing one for the provided cluster.

## SYNTAX

```
New-AzNetworkCloudBmcKeySet -ClusterName <String> -Name <String> -ResourceGroupName <String>
 -AzureGroupId <String> -Expiration <DateTime> -ExtendedLocationName <String> -ExtendedLocationType <String>
 -Location <String> -PrivilegeLevel <BmcKeySetPrivilegeLevel> -UserList <IKeySetUser[]>
 [-SubscriptionId <String>] [-Tag <Hashtable>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Create a new baseboard management controller key set or update the existing one for the provided cluster.

## EXAMPLES

### Example 1: Create Cluster's baseboard management controller key set
```powershell
$tagHash = @{
    tag = "tag"
}
$userList = @{
    description   = "userDescription"
    azureUserName = "userName"
    sshPublicKey  = @{
        keyData = "ssh-rsa aaaKyfsdx= fakekey@vm"
    }
}

New-AzNetworkCloudBmcKeySet -ResourceGroupName resourceGroupName -Name baseboardmgtcontrollerkeysetname -ClusterName clusterName -AzureGroupId azuregroupid -Expiration "2023-12-31T23:59:59.008Z" -ExtendedLocationName /subscriptions/subscriptionId/resourceGroups/resourceGroupName/providers/Microsoft.ExtendedLocation/customLocations/customLocationName -PrivilegeLevel ReadOnly -ExtendedLocationType CustomLocation -Location EastUs -Tag $tagHash -UserList $userList
```

```output
Location Name        SystemDataCreatedAt SystemDataCreatedBy       SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy             SystemDataLastModifiedByType ResourceGroupNam
                                                                                                                                                                                      e
-------- ----        ------------------- -------------------       ----------------------- ------------------------ ------------------------             ---------------------------- ----------------
eastus   baseboardmgtcontrollerkeysetname 07/27/2023 20:19:43 user1 User                    07/27/2023 20:23:23      user1 User                 RG-name
```

This command creates a cluster's baseboard management controller key set.

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

### -AzureGroupId
The object ID of Azure Active Directory group that all users in the list must be in for access to be granted.
Users that are not in the group will not have access.

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

### -ClusterName
The name of the cluster.

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

### -Expiration
The date and time after which the users in this key set will be removed from the baseboard management controllers.

```yaml
Type: System.DateTime
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ExtendedLocationName
The resource ID of the extended location on which the resource will be created.

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

### -ExtendedLocationType
The extended location type, for example, CustomLocation.

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
The name of the baseboard management controller key set.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: BmcKeySetName

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

### -PrivilegeLevel
The access level allowed for the users in this key set.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Support.BmcKeySetPrivilegeLevel
Parameter Sets: (All)
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
Parameter Sets: (All)
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
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -Tag
Resource tags.

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

### -UserList
The unique list of permitted users.
To construct, see NOTES section for USERLIST properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Models.Api20240701.IKeySetUser[]
Parameter Sets: (All)
Aliases:

Required: True
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

### Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Models.Api20240701.IBmcKeySet

## NOTES

## RELATED LINKS

