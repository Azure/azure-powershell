---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Websites.dll-Help.xml
Module Name: Az.Websites
ms.assetid: 3AB3D398-E5DB-4214-BA27-6E3B7D
online version: https://docs.microsoft.com/powershell/module/az.websites/remove-azwebappsslbinding
schema: 2.0.0
---

# Remove-AzWebAppSSLBinding

## SYNOPSIS
Removes an SSL binding from an uploaded certificate.

## SYNTAX

### S1
```
Remove-AzWebAppSSLBinding [-Name] <String> [[-DeleteCertificate] <Boolean>] [-Force]
 [-ResourceGroupName] <String> [-WebAppName] <String> [[-Slot] <String>]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### S2
```
Remove-AzWebAppSSLBinding [-Name] <String> [[-DeleteCertificate] <Boolean>] [-Force] [-WebApp] <PSSite>
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The **Remove-AzWebAppSSLBinding** cmdlet removes a Secure Sockets Layer (SSL) binding from an Azure Web App.
SSL bindings are used to associate a Web App with a certificate.

## EXAMPLES

### Example 1: Remove an SSL binding for a web app
```
PS C:\>Remove-AzWebAppSSLBinding -ResourceGroupName "ContosoResourceGroup" -WebAppName "ContosoWebApp" -Name "www.contoso.com"
```

This command removes the SSL binding for the web app ContosoWebApp.
Since the *DeleteCertificate* parameter is not included, the certificate will be deleted if it no longer has any SSL bindings.

### Example 2: Remove an SSL binding without removing the certificate
```
PS C:\>Remove-AzWebAppSSLBinding -ResourceGroupName "ContosoResourceGroup" -WebAppName "ContosoWebApp" -Name "www.contoso.com" -DeleteCertificate $False
```

Similar to Example 1, this command also removes the SSL binding for the Web App ContosoWebApp.
In this case, however, the *DeleteCertificate* parameter is included, and the parameter value is set to $False.
That means that the certificate will not be deleted regardless of whether it has any SSL bindings or not.

### Example 3: Use an object reference to remove an SSL binding
```
PS C:\>$WebApp = Get-AzWebApp -Name "ContosoWebApp"
PS C:\> Remove-AzWebAppSSLBinding -WebApp $WebApp -Name "www.contoso.com"
```

This example uses an object reference to the Web App website to remove the SSL binding for a Web App.
The first command uses the Get-AzWebApp cmdlet to create an object reference to the Web App named ContosoWebApp.
That object reference is stored in a variable named $WebApp.
The second command uses the object reference and the **Remove-AzWebAppSSLBinding** cmdlet to remove the SSL binding.

## PARAMETERS

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with azure.

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

### -DeleteCertificate
Specifies the action to take place if the SSL binding being removed is the only binding used by the certificate.
If *DeleteCertificate* is set to $False, the certificate will not be deleted when the binding is deleted.
If *DeleteCertificate* is set to $True or is not included in the command, the certificate will be deleted along with the SSL binding.
The certificate will only be deleted if the SSL binding being removed is the only binding used by the certificate.
If the certificate has more than one binding, the certificate will not be removed regardless of the value of the *DeleteCertificate* parameter.

```yaml
Type: System.Nullable`1[System.Boolean]
Parameter Sets: (All)
Aliases:

Required: False
Position: 4
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Force
Forces the command to run without asking for user confirmation.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: 5
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
Specifies the name of the Web App.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: 3
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
Specifies the name of the resource group that the certificate is assigned to.
You cannot use the *ResourceGroupName* parameter and the *WebApp* parameter in the same command.

```yaml
Type: System.String
Parameter Sets: S1
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Slot
Specifies the Web App deployment slot.
To get a deployment slot, use the Get-AzWebAppSlot cmdlet.

```yaml
Type: System.String
Parameter Sets: S1
Aliases:

Required: False
Position: 2
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WebApp
Specifies a Web App.
To get a Web App, use the Get-AzWebApp cmdlet.
You cannot use the *WebApp* parameter in the same command as the *ResourceGroupName* parameter and/or the *WebAppName*.

```yaml
Type: Microsoft.Azure.Commands.WebApps.Models.PSSite
Parameter Sets: S2
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -WebAppName
Specifies the name of the Web App.
You cannot use the *WebAppName* parameter and the *WebApp* parameter in the same command.

```yaml
Type: System.String
Parameter Sets: S1
Aliases:

Required: True
Position: 1
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
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### -WhatIf
Shows what would happen if the cmdlet runs.
The cmdlet is not run.Shows what would happen if the cmdlet runs.
The cmdlet is not run.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: wi

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.Commands.WebApps.Models.PSSite

## OUTPUTS

### System.Void

## NOTES

## RELATED LINKS

[Get-AzWebAppSSLBinding](./Get-AzWebAppSSLBinding.md)

[New-AzWebAppSSLBinding](./New-AzWebAppSSLBinding.md)

[Get-AzWebAppSlot](./Get-AzWebAppSlot.md)

[Get-AzWebApp](./Get-AzWebApp.md)


