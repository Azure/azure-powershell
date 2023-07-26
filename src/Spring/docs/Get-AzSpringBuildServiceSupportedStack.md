---
external help file:
Module Name: Az.Spring
online version: https://learn.microsoft.com/powershell/module/az.spring/get-azspringbuildservicesupportedstack
schema: 2.0.0
---

# Get-AzSpringBuildServiceSupportedStack

## SYNOPSIS
Get the supported stack resource.

## SYNTAX

### List (Default)
```
Get-AzSpringBuildServiceSupportedStack -ResourceGroupName <String> -ServiceName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzSpringBuildServiceSupportedStack -Name <String> -ResourceGroupName <String> -ServiceName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzSpringBuildServiceSupportedStack -InputObject <ISpringIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentityBuildService
```
Get-AzSpringBuildServiceSupportedStack -BuildServiceInputObject <ISpringIdentity> -Name <String>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Get the supported stack resource.

## EXAMPLES

### Example 1: Get all supported stack resource
```powershell
Get-AzSpringBuildServiceSupportedStack -ResourceGroupName Spring-gp-junxi -ServiceName Spring-01
```

```output
Name                             ResourceGroupName StackId                     Version
----                             ----------------- -------                     -------
io.buildpacks.stacks.bionic-base Springrg     io.buildpacks.stacks.bionic base
io.buildpacks.stacks.bionic-full Springrg     io.buildpacks.stacks.bionic full
```

Get all supported stack resource.

### Example 2: Get the supported stack resource
```powershell
Get-AzSpringBuildServiceSupportedStack -ResourceGroupName Spring-gp-junxi -ServiceName Spring-01 -Name io.buildpacks.stacks.bionic-full
```

```output
Name                             ResourceGroupName StackId                     Version
----                             ----------------- -------                     -------
io.buildpacks.stacks.bionic-base Springrg     io.buildpacks.stacks.bionic base
```

Get the supported stack resource.

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
The name of the stack resource.

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

### Microsoft.Azure.PowerShell.Cmdlets.Spring.Models.ISupportedStackResource

### Microsoft.Azure.PowerShell.Cmdlets.Spring.Models.ISupportedStacksCollection

## NOTES

## RELATED LINKS

