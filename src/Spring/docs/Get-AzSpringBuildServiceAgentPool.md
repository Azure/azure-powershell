---
external help file:
Module Name: Az.Spring
online version: https://learn.microsoft.com/powershell/module/az.spring/get-azspringbuildserviceagentpool
schema: 2.0.0
---

# Get-AzSpringBuildServiceAgentPool

## SYNOPSIS
Get build service agent pool.

## SYNTAX

### Get (Default)
```
Get-AzSpringBuildServiceAgentPool -ResourceGroupName <String> -ServiceName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzSpringBuildServiceAgentPool -InputObject <ISpringIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentityBuildService
```
Get-AzSpringBuildServiceAgentPool -BuildServiceInputObject <ISpringIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentitySpring
```
Get-AzSpringBuildServiceAgentPool -SpringInputObject <ISpringIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Get build service agent pool.

## EXAMPLES

### Example 1: Get a build service agent pool
```powershell
Get-AzSpringBuildServiceAgentPool -ResourceGroupName Springrg -ServiceName sspring-portal01
```

```output
Name    ResourceGroupName ProvisioningState PoolSizeCpu PoolSizeMemory PoolSizeName
----    ----------------- ----------------- ----------- -------------- ------------
default Springrg     Succeeded         2           4Gi            S1
```

Get a build service agent pool.

### Example 2: Get a build service agent pool by pipeline
```powershell
New-AzSpringBuildServiceAgentPool -ResourceGroupName Springrg -ServiceName espring-pwsh01 -PoolSizeName "S1" | Get-AzSpringBuildServiceAgentPool
```

```output
Name    ResourceGroupName ProvisioningState PoolSizeCpu PoolSizeMemory PoolSizeName
----    ----------------- ----------------- ----------- -------------- ------------
default Springrg     Succeeded         2           4Gi            S1
```

Get a build service agent pool by pipeline.

## PARAMETERS

### -BuildServiceInputObject
Identity Parameter
To construct, see NOTES section for BUILDSERVICEINPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Spring.Models.ISpringIdentity
Parameter Sets: GetViaIdentityBuildService
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
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
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Spring.Models.ISpringIdentity
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

### -SpringInputObject
Identity Parameter
To construct, see NOTES section for SPRINGINPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Spring.Models.ISpringIdentity
Parameter Sets: GetViaIdentitySpring
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

### Microsoft.Azure.PowerShell.Cmdlets.Spring.Models.ISpringIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Spring.Models.IBuildServiceAgentPoolResource

## NOTES

## RELATED LINKS

