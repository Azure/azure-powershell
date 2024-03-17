---
external help file: Az.Fleet-help.xml
Module Name: Az.Fleet
online version: https://learn.microsoft.com/powershell/module/az.fleet/new-azfleet
schema: 2.0.0
---

# New-AzFleet

## SYNOPSIS
Create a Fleet.

## SYNTAX

### CreateExpanded (Default)
```
New-AzFleet -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>] [-IfMatch <String>]
 [-IfNoneMatch <String>] -Location <String> [-EnableSystemAssignedIdentity] [-Tag <Hashtable>]
 [-UserAssignedIdentity <String[]>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateViaJsonString
```
New-AzFleet -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>] [-IfMatch <String>]
 [-IfNoneMatch <String>] -JsonString <String> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateViaJsonFilePath
```
New-AzFleet -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>] [-IfMatch <String>]
 [-IfNoneMatch <String>] -JsonFilePath <String> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateViaIdentityExpanded
```
New-AzFleet -InputObject <IFleetIdentity> [-IfMatch <String>] [-IfNoneMatch <String>] -Location <String>
 [-EnableSystemAssignedIdentity] [-Tag <Hashtable>] [-UserAssignedIdentity <String[]>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
Create a Fleet.

## EXAMPLES

### Example 1: Creates a Fleet resource
```powershell
New-AzFleet -Name sss -ResourceGroupName ps1-test -Location eastus
```

```output
ETag                         : "25052d24-0000-0100-0000-65532a620000"
Id                           : /subscriptions/'subscriptionId'/resourceGroups/ps1-test/providers/Microsoft.ContainerService/fleets/sss
IdentityPrincipalId          : 
IdentityTenantId             : 
IdentityType                 : 
IdentityUserAssignedIdentity : {
                               }
Location                     : eastus
Name                         : sss
ProvisioningState            : Succeeded
ResourceGroupName            : ps1-test
SystemDataCreatedAt          : 11/14/2023 8:05:54 AM
SystemDataCreatedBy          : user1@example.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 11/14/2023 8:05:54 AM
SystemDataLastModifiedBy     : user1@example.com
SystemDataLastModifiedByType : User
Tag                          : {
                               }
Type                         : Microsoft.ContainerService/fleets
```

This command creates a Fleet resource with a long running operation.

## PARAMETERS

### -AsJob
Runthecommandasajob

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
TheDefaultProfileparameterisnotfunctional.UsetheSubscriptionIdparameterwhenavailableifexecutingthecmdletagainstadifferentsubscription.

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

### -EnableSystemAssignedIdentity
Decidesifenableasystemassignedidentityfortheresource.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IfMatch
Therequestshouldonlyproceedifanentitymatchesthisstring.

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

### -IfNoneMatch
Therequestshouldonlyproceedifnoentitymatchesthisstring.

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

### -InputObject
IdentityParameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Fleet.Models.IFleetIdentity
Parameter Sets: CreateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -JsonFilePath
PathofJsonfilesuppliedtotheCreateoperation

```yaml
Type: System.String
Parameter Sets: CreateViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
JsonstringsuppliedtotheCreateoperation

```yaml
Type: System.String
Parameter Sets: CreateViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Location
Thegeo-locationwheretheresourcelives

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
ThenameoftheFleetresource.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaJsonString, CreateViaJsonFilePath
Aliases: FleetName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NoWait
Runthecommandasynchronously

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

### -ProgressAction
{{ Fill ProgressAction Description }}

```yaml
Type: System.Management.Automation.ActionPreference
Parameter Sets: (All)
Aliases: proga

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
Thenameoftheresourcegroup.Thenameiscaseinsensitive.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaJsonString, CreateViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
TheIDofthetargetsubscription.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaJsonString, CreateViaJsonFilePath
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -Tag
Resourcetags.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -UserAssignedIdentity
Thearrayofuserassignedidentitiesassociatedwiththeresource.TheelementsinarraywillbeARMresourceidsintheform:'/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/{identityName}.'

```yaml
Type: System.String[]
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.Fleet.Models.IFleetIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Fleet.Models.IFleet

## NOTES

## RELATED LINKS
