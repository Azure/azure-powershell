---
external help file: Microsoft.Azure.Commands.Insights.dll-Help.xml
ms.assetid: C7EC21C7-1C7E-49B2-9B33-486532FCDAEC
online version: 
schema: 2.0.0
---

# Remove-AzureRmActivityLogAlert

## SYNOPSIS
Removes an activity log alert.

## SYNTAX

```
Remove-AzureRmActivityLogAlert [-InputObject <PSActivityLogAlertResource>] [-ResourceGroupName <String> -Name <String>] [<CommonParameters>]
```

## DESCRIPTION
The **Remove-AzureRmActivityLogAlert** cmdlet removes an activity log alert.
This cmdlet implements the ShouldProcess pattern, i.e. it might request confirmation from the user before actually patching the resource and it accepts the -Force argument.

## EXAMPLES

### Example 1: Remove an activity log alert
```
PS C:\>Remove-AzureRmActivityLogAlert -ResourceGroup "Default-Web-CentralUS" -Name "myalert"
RequestId                                                                                                    StatusCode
---------                                                                                                    ----------
2c6c159b-0e73-4a01-a67b-c32c1a0008a3                                                                                 OK
```

Removes an activity log alert using name and resource group name as inputs.

### Example 2: Remove an activity log alert using a PSActivityLogAlertResource as input
```
PS C:\>Get-AzureRmActivityLogAlert -ResourceGroup "Default-activityLogAlerts" -Name "alert1" | Remove-AzureRmActivityLogAlert 
RequestId                                                                                                    StatusCode
---------                                                                                                    ----------
5c371547-80b0-4185-9b95-700b129de9d4                                                                                 OK
```

Removes an activity log alert using a PSActivityLogAlertResource as input.

## PARAMETERS

### -Name
The name of the activity log alert.

```yaml
Type: System.String
Parameter Sets: RemoveActivityLogAlertDeafultParamGroup
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group where the alert resource exists.

```yaml
Type: System.String
Parameter Sets: RemoveActivityLogAlertDeafultParamGroup
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -InputObject
Sets the InputObject tags property of the call to extract the required name, and resource group name properties.

```yaml
Type: Microsoft.Azure.Commands.Insights.OutputClasses.PSActivityLogAlertResource
Parameter Sets: RemoveActivityLogAlertFromPipeParamGroup
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: True (FromPipeline)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Force, -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.AzureOperationResponse

## NOTES

## RELATED LINKS

[Enable-AzureRmActivityLogAlert](./Enable-AzureRmActivityLogAlert.md)

[Disable-AzureRmActivityLogAlert](./Disable-AzureRmActivityLogAlert.md)

[Set-AzureRmActivityLogAlert](./Set-AzureRmActivityLogAlert.md)

[Get-AzureRmActivityLogAlert](./Get-AzureRmActivityLogAlert.md)

[New-AzureRmActionGroup](./New-AzureRmActionGroup.md)

[New-AzureRmActivityLogAlertCondition](./Get-AzureRmActivityLogAlertCondition.md)

