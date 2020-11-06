---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Websites.dll-Help.xml
Module Name: Az.Websites
online version:
schema: 2.0.0
---

# Remove-AzWebAppManagedCertificate

## SYNOPSIS
Creates an App service managed certificate for an Azure Web App. 

## SYNTAX

```
Remove-AzWebAppManagedCertificate [-ResourceGroupName] <String> [-WebAppName] <String> [[-Slot] <String>]
 [-HostName] <String> [-ThumbPrint] <String> [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
The **Remove-AzWebAppManagedCertificate** cmdlet creates an Azure App Service Managed Certificate

## EXAMPLES

### Example 1
```powershell
PS C:\>Remove-AzWebAppManagedCertificate -ResourceGroupName Default-Web-WestUS -WebAppName "ContosoSite" -HostName "www.ContosoSite.net" -Thumbprint "E3A38EBA60CAA1C162785A2E1C44A15AD450199C3" 
```

This command removes App Service Managed certificate for the given web app.

## PARAMETERS

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: IAzureContextContainer
Parameter Sets: (All)
Aliases: AzContext, AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -HostName
Custom hostnames associated with web app/slot.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: True
Position: 3
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Slot
The name of the web app slot.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: False
Position: 2
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ThumbPrint
Thumbprint of the certificate that already exists in web space.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: True
Position: 3
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WebAppName
The name of the web app.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None

## OUTPUTS

### System.Void

## NOTES

## RELATED LINKS
[New-AzWebAppManagedCertificate](./New-AzWebAppManagedCertificate.md)
