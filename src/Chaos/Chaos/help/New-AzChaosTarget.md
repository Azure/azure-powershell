---
external help file: Az.Chaos-help.xml
Module Name: Az.Chaos
online version: https://learn.microsoft.com/powershell/module/az.chaos/new-azchaostarget
schema: 2.0.0
---

# New-AzChaosTarget

## SYNOPSIS
Create a Target resource that extends a tracked regional resource.

## SYNTAX

### CreateExpanded (Default)
```
New-AzChaosTarget -Name <String> -ParentProviderNamespace <String> -ParentResourceName <String>
 -ParentResourceType <String> -ResourceGroupName <String> [-SubscriptionId <String>] [-Location <String>]
 [-Property <Hashtable>] [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### CreateViaJsonString
```
New-AzChaosTarget -Name <String> -ParentProviderNamespace <String> -ParentResourceName <String>
 -ParentResourceType <String> -ResourceGroupName <String> [-SubscriptionId <String>] -JsonString <String>
 [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateViaJsonFilePath
```
New-AzChaosTarget -Name <String> -ParentProviderNamespace <String> -ParentResourceName <String>
 -ParentResourceType <String> -ResourceGroupName <String> [-SubscriptionId <String>] -JsonFilePath <String>
 [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateViaIdentityExpanded
```
New-AzChaosTarget -InputObject <IChaosIdentity> [-Location <String>] [-Property <Hashtable>]
 [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Create a Target resource that extends a tracked regional resource.

## EXAMPLES

### Example 1: Create a Target resource that extends a tracked regional resource.
```powershell
$property = @{"type"="CertificateSubjectIssuer";"subject"="CN=example.subject"}
$propertyArr = @($property)
$identities = @{"identities"=$propertyArr}
New-AzChaosTarget -Name microsoft-virtualmachine -ParentProviderNamespace Microsoft.Compute -ParentResourceName exampleVM -ParentResourceType virtualMachines -ResourceGroupName azps_test_group_chaos -Location eastus -Property $identities
```

```output
Id                           : /subscriptions/{subId}/resourceGroups/azps_test_group_chaos/providers/Microsoft.Compute/virtualMachines/exampleVM/providers/Microsoft.Chaos/targets/
                               microsoft-virtualmachine
Location                     : eastus
Name                         : microsoft-virtualmachine
Property                     : {
                               }
ResourceGroupName            : azps_test_group_chaos
SystemDataCreatedAt          : 2024-03-26 06:43:28 AM
SystemDataCreatedBy          :
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 2024-03-26 07:26:26 AM
SystemDataLastModifiedBy     :
SystemDataLastModifiedByType :
Type                         : Microsoft.Chaos/targets
```

Create a Target resource that extends a tracked regional resource.

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

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Chaos.Models.IChaosIdentity
Parameter Sets: CreateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Create operation

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
Json string supplied to the Create operation

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
Location of the target resource.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
String that represents a Target resource name.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaJsonString, CreateViaJsonFilePath
Aliases: TargetName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ParentProviderNamespace
String that represents a resource provider namespace.

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

### -ParentResourceName
String that represents a resource name.

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

### -ParentResourceType
String that represents a resource type.

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

### -Property
The properties of the target resource.

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

### -ResourceGroupName
String that represents an Azure resource group.

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
GUID that represents an Azure subscription ID.

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

### Microsoft.Azure.PowerShell.Cmdlets.Chaos.Models.IChaosIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Chaos.Models.ITarget

## NOTES

## RELATED LINKS
