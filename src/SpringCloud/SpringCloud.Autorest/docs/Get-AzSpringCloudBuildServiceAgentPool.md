---
external help file:
Module Name: Az.SpringCloud
online version: https://learn.microsoft.com/powershell/module/az.springcloud/get-azspringcloudbuildserviceagentpool
schema: 2.0.0
---

# Get-AzSpringCloudBuildServiceAgentPool

## SYNOPSIS
Get build service agent pool.

## SYNTAX

### Get (Default)
```
Get-AzSpringCloudBuildServiceAgentPool -ResourceGroupName <String> -ServiceName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzSpringCloudBuildServiceAgentPool -InputObject <ISpringCloudIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Get build service agent pool.

## EXAMPLES

### Example 1: Get a build service agent pool
```powershell
Get-AzSpringCloudBuildServiceAgentPool -ResourceGroupName springcloudrg -ServiceName sspring-portal01
```

```output
Name    ResourceGroupName ProvisioningState PoolSizeCpu PoolSizeMemory PoolSizeName
----    ----------------- ----------------- ----------- -------------- ------------
default springcloudrg     Succeeded         2           4Gi            S1
```

Get a build service agent pool.

### Example 2: Get a build service agent pool by pipeline
```powershell
New-AzSpringCloudBuildServiceAgentPool -ResourceGroupName springcloudrg -ServiceName espring-pwsh01 -PoolSizeName "S1" | Get-AzSpringCloudBuildServiceAgentPool
```

```output
Name    ResourceGroupName ProvisioningState PoolSizeCpu PoolSizeMemory PoolSizeName
----    ----------------- ----------------- ----------- -------------- ------------
default springcloudrg     Succeeded         2           4Gi            S1
```

Get a build service agent pool by pipeline.

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
Type: Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.ISpringCloudIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group that contains the resource.
You can obtain this value from the Azure Resource Manager API or the portal.

```yaml
Type: System.String
Parameter Sets: Get
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
Parameter Sets: Get
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
Gets subscription ID which uniquely identify the Microsoft Azure subscription.
The subscription ID forms part of the URI for every service call.

```yaml
Type: System.String[]
Parameter Sets: Get
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

### Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.ISpringCloudIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20220401.IBuildServiceAgentPoolResource

## NOTES

## RELATED LINKS

