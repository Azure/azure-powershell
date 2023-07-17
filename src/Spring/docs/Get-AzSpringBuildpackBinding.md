---
external help file:
Module Name: Az.Spring
online version: https://learn.microsoft.com/powershell/module/az.spring/get-azspringbuildpackbinding
schema: 2.0.0
---

# Get-AzSpringBuildpackBinding

## SYNOPSIS
Get a buildpack binding by name.

## SYNTAX

### List (Default)
```
Get-AzSpringBuildpackBinding -BuilderName <String> -ResourceGroupName <String> -ServiceName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzSpringBuildpackBinding -BuilderName <String> -Name <String> -ResourceGroupName <String>
 -ServiceName <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzSpringBuildpackBinding -InputObject <ISpringIdentity> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentityBuilder
```
Get-AzSpringBuildpackBinding -BuilderInputObject <ISpringIdentity> -Name <String> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentityBuildService
```
Get-AzSpringBuildpackBinding -BuilderName <String> -BuildServiceInputObject <ISpringIdentity> -Name <String>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentitySpring
```
Get-AzSpringBuildpackBinding -BuilderName <String> -Name <String> -SpringInputObject <ISpringIdentity>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Get a buildpack binding by name.

## EXAMPLES

### Example 1: List all buildpack binding
```powershell
Get-AzSpringBuildpackBinding -ResourceGroupName Spring-gp-junxi -ServiceName Spring-01 -BuilderName default
```

```output
Name    SystemDataCreatedAt SystemDataCreatedBy     SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModi
                                                                                                     fiedBy
----    ------------------- -------------------     ----------------------- ------------------------ ------------------
default 2022/7/13 3:26:33   *********@microsoft.com User                    2022/7/13 3:26:33        *********@microso…
```

List all buildpack binding.

### Example 2: Get a buildpack binding by name
```powershell
Get-AzSpringBuildpackBinding -ResourceGroupName Spring-gp-junxi -ServiceName Spring-01 -BuilderName default -Name default
```

```output
Name    SystemDataCreatedAt SystemDataCreatedBy     SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModi
                                                                                                     fiedBy
----    ------------------- -------------------     ----------------------- ------------------------ ------------------
default 2022/7/13 3:26:33   *********@microsoft.com User                    2022/7/13 3:26:33        *********@microso…
```

Get a buildpack binding by name.

### Example 2: Get a buildpack binding by pipeline
```powershell
New-AzSpringBuildpackBinding -ResourceGroupName Springrg -ServiceName sspring-portal01 -BuilderName default -Name binging01 -BindingType 'AppDynamics' | Get-AzSpringBuildpackBinding
```

```output
Name      SystemDataCreatedAt SystemDataCreatedBy     SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModi
                                                                                                     fiedBy
----      ------------------- -------------------     ----------------------- ------------------------ ------------------
binging01 2022/7/13 3:26:33   *********@microsoft.com User                    2022/7/13 3:26:33        *********@microso…
```

Get a buildpack binding by pipeline.

## PARAMETERS

### -BuilderInputObject
Identity Parameter
To construct, see NOTES section for BUILDERINPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Spring.Models.ISpringIdentity
Parameter Sets: GetViaIdentityBuilder
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -BuilderName
The name of the builder resource.

```yaml
Type: System.String
Parameter Sets: Get, GetViaIdentityBuildService, GetViaIdentitySpring, List
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

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
The name of the Buildpack Binding Name

```yaml
Type: System.String
Parameter Sets: Get, GetViaIdentityBuilder, GetViaIdentityBuildService, GetViaIdentitySpring
Aliases: BuildpackBindingName

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

### Microsoft.Azure.PowerShell.Cmdlets.Spring.Models.IBuildpackBindingResource

## NOTES

## RELATED LINKS

