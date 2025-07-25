---
external help file: Az.MachineLearningServices-help.xml
Module Name: Az.MachineLearningServices
online version: https://learn.microsoft.com/powershell/module/Az.MachineLearningServices/new-AzMLWorkspaceManagedIdentityAuthTypeWorkspaceConnectionPropertiesObject
schema: 2.0.0
---

# New-AzMLWorkspaceManagedIdentityAuthTypeWorkspaceConnectionPropertiesObject

## SYNOPSIS
Create an in-memory object for ManagedIdentityAuthTypeWorkspaceConnectionProperties.

## SYNTAX

```
New-AzMLWorkspaceManagedIdentityAuthTypeWorkspaceConnectionPropertiesObject [-CredentialsClientId <String>]
 [-CredentialsResourceId <String>] [-Category <ConnectionCategory>] [-ExpiryTime <DateTime>]
 [-IsSharedToAll <Boolean>] [-Metadata <IWorkspaceConnectionPropertiesV2Metadata>] [-SharedUserList <String[]>]
 [-Target <String>] [-Value <String>] [-ValueFormat <ValueFormat>]
 [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for ManagedIdentityAuthTypeWorkspaceConnectionProperties.

## EXAMPLES

### Example 1: Create an in-memory object for ManagedIdentityAuthTypeWorkspaceConnectionProperties
```powershell
New-AzMLWorkspaceManagedIdentityAuthTypeWorkspaceConnectionPropertiesObject -Category <ConnectionCategory> -CredentialsClientId <String> -CredentialsResourceId <String> -IsSharedToAll <Boolean> -Metadata <IWorkspaceConnectionPropertiesV2Metadata> -Target <String>
```

This command creates an in-memory object for ManagedIdentityAuthTypeWorkspaceConnectionProperties.

## PARAMETERS

### -Category
Category of the connection.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Support.ConnectionCategory
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CredentialsClientId

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

### -CredentialsResourceId

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

### -ExpiryTime

```yaml
Type: System.DateTime
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IsSharedToAll

```yaml
Type: System.Boolean
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Metadata
Store user metadata for this connection.
To construct, see NOTES section for METADATA properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20240401.IWorkspaceConnectionPropertiesV2Metadata
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SharedUserList

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Target

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

### -Value
Value details of the workspace connection.

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

### -ValueFormat
format for the workspace connection value.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Support.ValueFormat
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20240401.ManagedIdentityAuthTypeWorkspaceConnectionProperties

## NOTES

## RELATED LINKS
