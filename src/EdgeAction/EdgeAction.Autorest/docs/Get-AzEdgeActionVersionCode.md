---
external help file:
Module Name: Az.EdgeAction
online version: https://learn.microsoft.com/powershell/module/az.edgeaction/get-azedgeactionversioncode
schema: 2.0.0
---

# Get-AzEdgeActionVersionCode

## SYNOPSIS
Get Edge Action version code and optionally save to file.

## SYNTAX

### GetCustom (Default)
```
Get-AzEdgeActionVersionCode -EdgeActionName <String> -ResourceGroupName <String> -Version <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [<CommonParameters>]
```

### GetAndSaveCustom
```
Get-AzEdgeActionVersionCode -EdgeActionName <String> -ResourceGroupName <String> -Version <String>
 -OutputPath <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [<CommonParameters>]
```

## DESCRIPTION
A long-running resource action that retrieves the version code for an Edge Action version.
When the -OutputPath parameter is specified, the base64-encoded content is decoded and saved
as a zip file to the specified directory.
Otherwise, returns the raw response with base64 content.

## EXAMPLES

### Example 1: Get version code as base64-encoded content
```powershell
Get-AzEdgeActionVersionCode -ResourceGroupName "myResourceGroup" -EdgeActionName "myEdgeAction" -Version "v1"
```

```output
Content                                                                             Name
-------                                                                             ----
UEsDBBQAAAAIAI... (base64 encoded ZIP content)                                      v1
```

This command retrieves the deployed version code as a base64-encoded ZIP file.
The content can be decoded and extracted to view the original source files.

### Example 2: Get version code and save to file
```powershell
Get-AzEdgeActionVersionCode -ResourceGroupName "myResourceGroup" -EdgeActionName "myEdgeAction" -Version "v1" -OutputPath "C:\Downloads"
```

```output
Message                      FilePath                    Name
-------                      --------                    ----
Version code saved...        C:\Downloads\v1.zip         v1
```

This command retrieves the deployed version code and saves it directly to a ZIP file in the specified output directory.
The file is automatically named using the version name.

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

### -OutputPath
Output directory to save the decoded version code as a zip file.

```yaml
Type: System.String
Parameter Sets: GetAndSaveCustom
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
The value must be an UUID.

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -Version
The name of the Edge Action version

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.EdgeAction.Models.IVersionCode

### System.Management.Automation.PSCustomObject

## NOTES

## RELATED LINKS

