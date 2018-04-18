---
external help file: Azs.Subscriptions.Admin-help.xml
Module Name: Azs.Subscriptions.Admin
online version: 
schema: 2.0.0
---

# Set-AzsDirectoryTenant

## SYNOPSIS
Updates a directory tenant.

## SYNTAX

### Update (Default)
```
Set-AzsDirectoryTenant -Name <String> -ResourceGroupName <String> [-TenantId <String>] [-Location <String>]
 [-Force] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ResourceId
```
Set-AzsDirectoryTenant -ResourceGroupName <String> [-TenantId <String>] [-Location <String>]
 -ResourceId <String> [-Force] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### InputObject
```
Set-AzsDirectoryTenant -ResourceGroupName <String> [-TenantId <String>] [-Location <String>]
 -InputObject <DirectoryTenant> [-Force] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Updates a directory tenant.

## EXAMPLES

### -------------------------- EXAMPLE 1 --------------------------
```
Set-AzsDirectoryTenant -ResourceGroupName rg1 -Name tenant1
```

Update a directory tenant under a resource group.

## PARAMETERS

### -Force
Don't ask for confirmation.

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases: 

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
The input object of type Microsoft.AzureStack.Management.Subscriptions.Admin.Models.DirectoryTenant.

```yaml
Type: DirectoryTenant
Parameter Sets: InputObject
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Location
Location of the resource.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
Directory tenant name.

```yaml
Type: String
Parameter Sets: Update
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The resource group the resource is located under.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceId
The resource id.

```yaml
Type: String
Parameter Sets: ResourceId
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -TenantId
Tenant unique identifier.

```yaml
Type: String
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
Type: SwitchParameter
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
Type: SwitchParameter
Parameter Sets: (All)
Aliases: wi

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.AzureStack.Management.Subscriptions.Admin.Models.DirectoryTenant

## NOTES

## RELATED LINKS

