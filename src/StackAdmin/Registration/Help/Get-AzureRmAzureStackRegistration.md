---
external help file: Microsoft.Azure.Commands.AzureStack.Registration.dll-Help.xml
Module Name: AzureRM.AzureStack.Registration
online version:
schema: 2.0.0
---

# Get-AzureRmAzureStackRegistration

## SYNOPSIS
Get an Azure Stack registration or list Azure Stack registrations.

## SYNTAX

```
Get-AzureRmAzureStackRegistration [-ResourceGroupName <String>] [-Name <String>]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
Get an Azure Stack registration or list Azure Stack registrations under a specified resource group.

## EXAMPLES

### Example 1
```powershell
PS C:\> Get-AzureRmAzureStackRegistration -ResourceGroupName "TestResourceGroup" -Name "TestAzureStackRegistration"
```

Get an Azure Stack registration named `TestAzureStackRegistration` under a resource group named `TestResourceGroup`.

## PARAMETERS

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: IAzureContextContainer
Parameter Sets: (All)
Aliases: AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
Name of Azure Stack registration.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ResourceGroupName
Name of resource group where Azure Stack registration is created.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String

## OUTPUTS

### Microsoft.Azure.Commands.AzureStack.Models.RegistrationResult

## NOTES

## RELATED LINKS
