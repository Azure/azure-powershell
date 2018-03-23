---
external help file: Microsoft.Azure.Commands.Resources.dll-Help.xml
Module Name: AzureRM.Resources
online version: https://docs.microsoft.com/en-us/powershell/module/get-azurermmanagementpartner
schema: 2.0.0
---

# Get-AzureRmManagementPartner

## SYNOPSIS
Gets the Microsoft Partner Network(MPN) ID of the current authenticated user or service principal. 

## SYNTAX

```
Get-AzureRmManagementPartner [[-PartnerId] <String>] [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

## DESCRIPTION
Gets the Microsoft Partner Network(MPN) ID of the current authenticated user or service principal. 

## EXAMPLES

### Example 1
```powershell
PS C:\> Get-AzureRmManagementPartner
PartnerId TenantId                             ObjectId                             State
--------- --------                             --------                             -----
123457    1b1121dd-6900-412a-af73-e8d44f81e1c1 aa67f786-0552-423e-8849-244ed12bf581 Active
```

Get the current management partner id

### Example 2
```powershell
PS C:\> Get-AzureRmManagementPartner -PartnerId 123457
PartnerId TenantId                             ObjectId                             State
--------- --------                             --------                             -----
123457    1b1121dd-6900-412a-af73-e8d44f81e1c1 aa67f786-0552-423e-8849-244ed12bf581 Active
```

Get the current management partner id using a partner id, if they don't match, it will fail

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

### -PartnerId
The management partner id, it is a 6 digits number

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: False
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable.
For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None


## OUTPUTS

### Microsoft.Azure.Commands.Resources.PSManagementPartner


## NOTES

## RELATED LINKS
[Remove-AzureRmManagementPartner](./Remove-AzureRmManagementPartner.md)

[New-AzureRmManagementPartner](./New-AzureRmManagementPartner.md)

[Update-AzureRmManagementPartner](./Update-AzureRmManagementPartner.md)