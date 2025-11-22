---
external help file:
Module Name: Az.EdgeAction
online version: https://learn.microsoft.com/powershell/module/az.edgeaction/deploy-azedgeactionversioncode
schema: 2.0.0
---

# Deploy-AzEdgeActionVersionCode

## SYNOPSIS
Deploy Edge Action version code from a file.

## SYNTAX

```
Deploy-AzEdgeActionVersionCode -EdgeActionName <String> -ResourceGroupName <String> -Version <String>
 -FilePath <String> [-SubscriptionId <String>] [-DeploymentType <String>] [-Name <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Deploy Edge Action version code from a JavaScript or zip file.
This command handles file reading, 
automatic zipping (for JavaScript files when using zip deployment), and base64 encoding.

## EXAMPLES

### Example 1: Deploy a JavaScript file to an edge action version
```powershell
Deploy-AzEdgeActionVersionCode -ResourceGroupName "myResourceGroup" -EdgeActionName "myEdgeAction" -Version "v1" -FilePath "C:\code\handler.js"
```

Deploys a JavaScript file to the specified edge action version.
The deployment type is automatically detected based on the file extension (.js → file type).

### Example 2: Deploy a JavaScript file as a zip package
```powershell
Deploy-AzEdgeActionVersionCode -ResourceGroupName "myResourceGroup" -EdgeActionName "myEdgeAction" -Version "v1" -FilePath "C:\code\handler.js" -DeploymentType "zip"
```

Deploys a JavaScript file by automatically creating a zip archive, encoding it in base64, and uploading it to the edge action version.

### Example 3: Deploy a pre-packaged zip file
```powershell
Deploy-AzEdgeActionVersionCode -ResourceGroupName "myResourceGroup" -EdgeActionName "myEdgeAction" -Version "v1" -FilePath "C:\code\package.zip"
```

Deploys an existing zip file containing the edge action code.
The zip file is encoded in base64 and uploaded.

### Example 4: Deploy with a custom deployment name
```powershell
Deploy-AzEdgeActionVersionCode -ResourceGroupName "myResourceGroup" -EdgeActionName "myEdgeAction" -Version "v1" -FilePath "C:\code\handler.js" -DeploymentName "production-deploy-001"
```

Deploys code with a custom deployment name for tracking purposes.

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
The credentials, account, tenant, and subscription used for communication with Azure.

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

### -DeploymentType
Deployment type: 'file' for JavaScript files, 'zip' for zip archives.
Auto-detected if not specified.

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

### -EdgeActionName
The name of the Edge Action

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

### -FilePath
Path to JavaScript (.js) or zip (.zip) file

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
The version code deployment name.
Defaults to the version name if not specified.

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

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

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

### -SubscriptionId
The ID of the target subscription.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -Version
The version name

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

## OUTPUTS

### System.Object

## NOTES

## RELATED LINKS

