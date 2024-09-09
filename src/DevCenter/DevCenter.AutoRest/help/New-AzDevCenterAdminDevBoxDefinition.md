---
external help file:
Module Name: Az.DevCenter
online version: https://learn.microsoft.com/powershell/module/az.devcenter/new-azdevcenteradmindevboxdefinition
schema: 2.0.0
---

# New-AzDevCenterAdminDevBoxDefinition

## SYNOPSIS
Creates or updates a Dev Box definition.

## SYNTAX

### CreateExpanded (Default)
```
New-AzDevCenterAdminDevBoxDefinition -DevCenterName <String> -Name <String> -ResourceGroupName <String>
 -ImageReferenceId <String> -Location <String> -OSStorageType <String> -SkuName <String>
 [-SubscriptionId <String>] [-HibernateSupport <HibernateSupport>] [-SkuCapacity <Int32>]
 [-SkuFamily <String>] [-SkuSize <String>] [-SkuTier <SkuTier>] [-Tag <Hashtable>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaIdentityExpanded
```
New-AzDevCenterAdminDevBoxDefinition -InputObject <IDevCenterIdentity> -ImageReferenceId <String>
 -Location <String> -OSStorageType <String> -SkuName <String> [-HibernateSupport <HibernateSupport>]
 [-SkuCapacity <Int32>] [-SkuFamily <String>] [-SkuSize <String>] [-SkuTier <SkuTier>] [-Tag <Hashtable>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Creates or updates a Dev Box definition.

## EXAMPLES

### Example 1: Create a dev box definition
```powershell
New-AzDevCenterAdminDevBoxDefinition -Name "WebDevBox" -DevCenterName Contoso -ResourceGroupName testRg -Location "westus3" -HibernateSupport "Enabled" -ImageReferenceId "/subscriptions/0ac520ee-14c0-480f-b6c9-0a90c58ffff/resourceGroups/testRg/providers/Microsoft.DevCenter/devcenters/Contoso/galleries/contosogallery/images/exampleImage/version/1.0.0" -OSStorageType "ssd_1024gb" -SkuName "general_a_8c32gb_v1" 
```

This command creates a dev box definition named "WebDevBox" in the dev center "Contoso".

### Example 2: Create a dev box definition using InputObject
```powershell
$devBoxDefinition = @{"ResourceGroupName" = "testRg"; "DevCenterName" = "Contoso"; "DevBoxDefinitionName" = "WebDevBox"; "SubscriptionId" = "0ac520ee-14c0-480f-b6c9-0a90c58ffff"}
New-AzDevCenterAdminDevBoxDefinition -InputObject $devBoxDefinition -Location "westus3" -HibernateSupport "Enabled" -ImageReferenceId "/subscriptions/0ac520ee-14c0-480f-b6c9-0a90c58ffff/resourceGroups/testRg/providers/Microsoft.DevCenter/devcenters/Contoso/galleries/contosogallery/images/exampleImage/version/1.0.0" -OSStorageType "ssd_1024gb" -SkuName "general_a_8c32gb_v1"
```

This command creates a dev box definition named "WebDevBox" in the dev center "Contoso".

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

### -DevCenterName
The name of the devcenter.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -HibernateSupport
Indicates whether Dev Boxes created with this definition are capable of hibernation.
Not all images are capable of supporting hibernation.
To find out more see https://aka.ms/devbox/hibernate

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DevCenter.Support.HibernateSupport
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ImageReferenceId
Image ID, or Image version ID.
When Image ID is provided, its latest version will be used.

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

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DevCenter.Models.IDevCenterIdentity
Parameter Sets: CreateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
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
The name of the Dev Box definition.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases: DevBoxDefinitionName

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

### -OSStorageType
The storage type used for the Operating System disk of Dev Boxes created using this definition.

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

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SkuCapacity
If the SKU supports scale out/in then the capacity integer should be included.
If scale out/in is not possible for the resource this may be omitted.

```yaml
Type: System.Int32
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SkuFamily
If the service has different generations of hardware, for the same SKU, then that can be captured here.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SkuName
The name of the SKU.
E.g.
P3.
It is typically a letter+number code

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

### -SkuSize
The SKU size.
When the name field is the combination of tier and some other value, this would be the standalone code.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SkuTier
This field is required to be implemented by the Resource Provider if the service has more than one tier, but is not required on a PUT.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DevCenter.Support.SkuTier
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.DevCenter.Models.IDevCenterIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.DevCenter.Models.Api20240501Preview.IDevBoxDefinition

## NOTES

## RELATED LINKS

