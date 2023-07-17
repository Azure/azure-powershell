---
external help file:
Module Name: Az.Spring
online version: https://learn.microsoft.com/powershell/module/az.spring/get-azspringbuildservice
schema: 2.0.0
---

# Get-AzSpringBuildService

## SYNOPSIS
Get a build service resource.

## SYNTAX

### Get (Default)
```
Get-AzSpringBuildService -ResourceGroupName <String> -ServiceName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzSpringBuildService -InputObject <ISpringIdentity> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentitySpring
```
Get-AzSpringBuildService -SpringInputObject <ISpringIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Get a build service resource.

## EXAMPLES

### Example 1: Get a build service resource of the enterprise spring cloud
```powershell
Get-AzSpringBuildService -ResourceGroupName Springrg -ServiceName sspring-portal01
```

```output
Name    ResourceGroupName ProvisioningState KPackVersion ResourceRequestCpu ResourceRequestMemory
----    ----------------- ----------------- ------------ ------------------ ---------------------
default Springrg     Succeeded         0.5.2        2                  4Gi
```

Get a build service resource of the enterprise spring cloud.

### Example 2: Get a build service resource of the enterprise spring cloud by id
```powershell
Get-AzSpringBuildService -InputObject "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/Springrg/providers/Microsoft.AppPlatform/Spring/sspring-portal01/buildServices/default"
```

```output
Name    ResourceGroupName ProvisioningState KPackVersion ResourceRequestCpu ResourceRequestMemory
----    ----------------- ----------------- ------------ ------------------ ---------------------
default Springrg     Succeeded         0.5.2        2                  4Gi
```

Get a build service resource of the enterprise spring cloud.

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

### Microsoft.Azure.PowerShell.Cmdlets.Spring.Models.IBuildService

## NOTES

## RELATED LINKS

