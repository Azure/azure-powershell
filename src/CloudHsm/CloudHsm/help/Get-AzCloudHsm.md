---
external help file: Az.CloudHsm-help.xml
Module Name: Az.CloudHsm
online version: https://learn.microsoft.com/powershell/module/az.cloudhsm/get-azcloudhsm
schema: 2.0.0
---

# Get-AzCloudHsm

## SYNOPSIS
Gets Cloud HSMs.

## SYNTAX

### List1 (Default)
```
Get-AzCloudHsm [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### Get
```
Get-AzCloudHsm [-SubscriptionId <String[]>] -Name <String> -ResourceGroupName <String>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### List
```
Get-AzCloudHsm [-SubscriptionId <String[]>] -ResourceGroupName <String> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
The Get-AzCloudHsm cmdlet gets information about the Cloud HSMs in a subscription.
You can view all Cloud HSMs instances in a subscription, or filter your results by a resource group or a particular Cloud HSM.
Note that although specifying the resource group is optional for this cmdlet when you get a single Cloud HSM, you should do so for better performance.

## EXAMPLES

### Example 1: Get all Cloud HSMs in your current subscription
```powershell
Get-AzCloudHsm
```

```output
IdentityPrincipalId IdentityTenantId IdentityType Location      Name                 SkuCapacity SkuFamily SkuName
------------------- ---------------- ------------ --------      ----                 ----------- --------- -------
                                     UserAssigned ukwest        chsm1                      B         Standard_B1
                                     UserAssigned ukwest        chsm2                      B         Standard_B1
```

This command gets all the Cloud HSMs in your current subscription

### Example 2:  Get a Cloud HSM in a resource group
```powershell
Get-AzCloudHsm -ResourceGroupName 'group'
```

```output
IdentityPrincipalId IdentityTenantId IdentityType Location      Name                 SkuCapacity SkuFamily SkuName
------------------- ---------------- ------------ --------      ----                 ----------- --------- -------
                                     UserAssigned ukwest        chsm1                      B         Standard_B1
                                     UserAssigned ukwest        chsm2                      B         Standard_B1
```

This command gets all the Cloud HSMs in the resource group named group.

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

### -Name
The name of the Cloud HSM Cluster within the specified resource group.
Cloud HSM Cluster names must be between 3 and 23 characters in length.

```yaml
Type: System.String
Parameter Sets: Get
Aliases: CloudHsmClusterName

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
The value must be an UUID.

```yaml
Type: System.String[]
Parameter Sets: (All)
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

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.CloudHsm.Models.ICloudHsmCluster

## NOTES

## RELATED LINKS
