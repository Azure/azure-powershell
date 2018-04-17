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
 [<CommonParameters>]
```

### ResourceId
```
Set-AzsDirectoryTenant -ResourceGroupName <String> [-TenantId <String>] [-Location <String>]
 -ResourceId <String> [<CommonParameters>]
```

### InputObject
```
Set-AzsDirectoryTenant -ResourceGroupName <String> [-TenantId <String>] [-Location <String>]
 -InputObject <DirectoryTenant> [<CommonParameters>]
```

## DESCRIPTION
Updates a directory tenant.

## EXAMPLES

### Example 1
```
PS C:\> {{ Add example code here }}
```

{{ Add example description here }}

## PARAMETERS

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
{{Fill ResourceGroupName Description}}

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.AzureStack.Management.Subscriptions.Admin.Models.DirectoryTenant

## NOTES

## RELATED LINKS

