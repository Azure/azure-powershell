---
external help file:
Module Name: Az.Spring
online version: https://learn.microsoft.com/powershell/module/az.spring/get-azspringbuildservicebuilder
schema: 2.0.0
---

# Get-AzSpringBuildServiceBuilder

## SYNOPSIS
Get a KPack builder.

## SYNTAX

### List (Default)
```
Get-AzSpringBuildServiceBuilder -ResourceGroupName <String> -ServiceName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzSpringBuildServiceBuilder -Name <String> -ResourceGroupName <String> -ServiceName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzSpringBuildServiceBuilder -InputObject <ISpringIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentityBuildService
```
Get-AzSpringBuildServiceBuilder -BuildServiceInputObject <ISpringIdentity> -Name <String>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Get a KPack builder.

## EXAMPLES

### Example 1: List all KPack builder
```powershell
Get-AzSpringBuildServiceBuilder -ResourceGroupName Springrg -ServiceName sspring-portal01
```

```output
Name    ResourceGroupName ProvisioningState StackId                     StackVersion
----    ----------------- ----------------- -------                     ------------
default Springrg     Succeeded         io.buildpacks.stacks.bionic base
```

List all KPack builder.

### Example 2: List all KPack builders under build service
```powershell
Get-AzSpringBuildServiceBuilder -ResourceGroupName Springrg -ServiceName sspring-portal01 -Name default
```

```output
Name    ResourceGroupName ProvisioningState StackId                     StackVersion
----    ----------------- ----------------- -------                     ------------
default Springrg     Succeeded         io.buildpacks.stacks.bionic base
```

List all KPack builders under build service.

### Example 2: Get a KPack builder by pipeline
```powershell
New-AzSpringBuildServiceBuilder -ResourceGroupName Springrg -ServiceName sspring-portal01 -Name builder03 -StackId 'io.buildpacks.stacks.bionic' -StackVersion 'base' | Get-AzSpringBuildServiceBuilder
```

```output
Name    ResourceGroupName ProvisioningState StackId                     StackVersion
----    ----------------- ----------------- -------                     ------------
builder01 Springrg     Succeeded         io.buildpacks.stacks.bionic base
```

Get a KPack builder by pipeline.

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

### -Name
The name of the builder resource.

```yaml
Type: System.String
Parameter Sets: Get, GetViaIdentityBuildService
Aliases:

Required: True
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
Parameter Sets: Get, List
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
Parameter Sets: Get, List
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

### Microsoft.Azure.PowerShell.Cmdlets.Spring.Models.ISpringIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Spring.Models.IBuilderResource

## NOTES

## RELATED LINKS

