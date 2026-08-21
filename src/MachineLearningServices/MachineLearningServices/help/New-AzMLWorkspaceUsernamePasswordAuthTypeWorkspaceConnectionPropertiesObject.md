---
external help file: Az.MachineLearningServices-help.xml
Module Name: Az.MachineLearningServices
online version: https://learn.microsoft.com/powershell/module/Az.MachineLearningServices/new-azmlworkspaceusernamepasswordauthtypeworkspaceconnectionpropertiesobject
schema: 2.0.0
---

# New-AzMLWorkspaceUsernamePasswordAuthTypeWorkspaceConnectionPropertiesObject

## SYNOPSIS
Create an in-memory object for UsernamePasswordAuthTypeWorkspaceConnectionProperties.

## SYNTAX

```
New-AzMLWorkspaceUsernamePasswordAuthTypeWorkspaceConnectionPropertiesObject [-CredentialsPassword <String>]
 [-CredentialsSecurityToken <String>] [-CredentialsUsername <String>] [-Category <String>]
 [-ExpiryTime <DateTime>] [-IsSharedToAll <Boolean>] [-Metadata <IWorkspaceConnectionPropertiesV2Metadata>]
 [-SharedUserList <String[]>] [-Target <String>] [-Value <String>] [-ValueFormat <String>]
 [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for UsernamePasswordAuthTypeWorkspaceConnectionProperties.

## EXAMPLES

### Example 1: Create an in-memory object for UsernamePasswordAuthTypeWorkspaceConnectionProperties
```powershell
New-AzMLWorkspaceUsernamePasswordAuthTypeWorkspaceConnectionPropertiesObject -Category <ConnectionCategory> -CredentialsPassword <String> -CredentialsSecurityToken <String> -CredentialsUsername <String> -IsSharedToAll <Boolean> -Metadata <IWorkspaceConnectionPropertiesV2Metadata> -Target <String>
```

This command creates an in-memory object for UsernamePasswordAuthTypeWorkspaceConnectionProperties.

## PARAMETERS

### -Category
Category of the connection.

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

### -CredentialsPassword

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

### -CredentialsSecurityToken
Optional, required by connections like SalesForce for extra security in addition to UsernamePassword.

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

### -CredentialsUsername

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

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.IWorkspaceConnectionPropertiesV2Metadata
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
Type: System.String
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

### Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.UsernamePasswordAuthTypeWorkspaceConnectionProperties

## NOTES

## RELATED LINKS
