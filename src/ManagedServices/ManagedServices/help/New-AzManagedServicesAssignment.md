---
external help file: Microsoft.Azure.PowerShell.Cmdlets.ManagedServices.dll-Help.xml
Module Name: Az.ManagedServices
online version: https://docs.microsoft.com/en-us/powershell/module/az.managedservices/new-azmanagedservicesassignment
schema: 2.0.0
---

# New-AzManagedServicesAssignment

## SYNOPSIS
Creates or updates a registration assignment.

## SYNTAX

### Default (Default)
```
New-AzManagedServicesAssignment [[-Scope] <String>] -RegistrationDefinitionName <String> [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ByResourceId
```
New-AzManagedServicesAssignment [[-Scope] <String>] -RegistrationDefinitionId <String> [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ByInputObject
```
New-AzManagedServicesAssignment [[-Scope] <String>] -RegistrationDefinition <PSRegistrationDefinition> [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Creates or updates a registration assignment.

## EXAMPLES

### Example 1
```powershell
PS C:\> New-AzManagedServicesAssignment -RegistrationDefinitionId /subscriptions/38bd4bef-41ff-45b5-b3af-d03e55a4ca15/providers/Microsoft.ManagedServices/registrationDefinitions/d4d14a4c-9b54-4dc3-b755-6d0659e0224b

Name                                 RegistrationDefinitionId
----                                 ------------------------
3b3d5411-ec8c-4a52-8972-73f4952724b2 /subscriptions/38bd4bef-41ff-45b5-b3af-d03e55a4ca15/providers/Microsoft.ManagedServices/registrationDefinitions/d4d14a4c-9b54-4dc3-b755-6d0659e0224b
```

Creates a new registration assignment given the fully qualified resource id of the registration definition.

### Example 2
```powershell
New-AzManagedServicesAssignment -Scope /subscriptions/38bd4bef-41ff-45b5-b3af-d03e55a4ca15/resourceGroups/mygroup1 -RegistrationDefinitionName 47f471b3-ff5f-463c-8a1f-286501b01ddc

Name                                 RegistrationDefinitionId
----                                 ------------------------
5aa0d921-64b8-40e8-af33-31993f0deaa8 /subscriptions/38bd4bef-41ff-45b5-b3af-d03e55a4ca15/providers/Microsoft.ManagedServices/registrationDefinitions/47f471b3-ff5f-463c-8a1f-286501b01ddc
```

Creates a the registration assignment given a scope and the registration definition name.

### Example 3
```powershell
PS C:\> $def = New-AzManagedServicesDefinition -RegistrationDefinitionName asd -ManagedByTenantId "bab3375b-6197-4a15-a44b-16c41faa91d7" -PrincipalId "d6f6c88a-5b7a-455e-ba40-ce146d4d3671" -RoleDefinitionId "acdd72a7-3385-48ef-bd42-f606fba81ae7"
PS C:\> New-AzManagedServicesAssignment -RegistrationDefinition $def

Name                                 RegistrationDefinitionId
----                                 ------------------------
a25f63d9-605c-4878-99bd-0d315480d46b /subscriptions/38bd4bef-41ff-45b5-b3af-d03e55a4ca15/providers/Microsoft.ManagedServices/registrationDefinitions/4a50f8eb-96b3-44c4-a397-e1e57035fe65
```
Creates a the registration assignment given a registration definition object.
## PARAMETERS

### -AsJob
Run cmdlet in the background

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
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer
Parameter Sets: (All)
Aliases: AzContext, AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RegistrationDefinition
The registration definition input object.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ManagedServices.Models.PSRegistrationDefinition
Parameter Sets: ByInputObject
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -RegistrationDefinitionResourceId
The fully qualified resource id of the registration definition (for example, /subscriptions/bb6d49b2-603d-489f-b6ca-ca4dc497c749/providers/Microsoft.ManagedServices/registrationDefinitions/b0c052e5-c437-4771-a476-8b1201158a57).

```yaml
Type: System.String
Parameter Sets: ByResourceId
Aliases: ResourceId

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -RegistrationDefinitionName
The registration definition name (for example, b0c052e5-c437-4771-a476-8b1201158a57.

```yaml
Type: System.String
Parameter Sets: Default
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Scope
The scope where the registration assignment should be created.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: 0
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

### None

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ManagedServices.Models.PSRegistrationAssignment

## NOTES

## RELATED LINKS
