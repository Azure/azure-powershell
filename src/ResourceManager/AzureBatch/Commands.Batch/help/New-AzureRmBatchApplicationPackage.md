---
external help file: Microsoft.Azure.Commands.Batch.dll-Help.xml
Module Name: AzureRM.Batch
ms.assetid: D53DAEB6-DC4F-473C-A193-A1E2A65326D4
online version: https://docs.microsoft.com/en-us/powershell/module/azurerm.batch/new-azurermbatchapplicationpackage
schema: 2.0.0
---

# New-AzureRmBatchApplicationPackage

## SYNOPSIS
Creates an application package in a Batch account.

## SYNTAX

### UploadAndActivate (Default)
```
New-AzureRmBatchApplicationPackage [-AccountName] <String> [-ResourceGroupName] <String>
 [-ApplicationId] <String> [-ApplicationVersion] <String> [-Format] <String> -FilePath <String>
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### ActivateOnly
```
New-AzureRmBatchApplicationPackage [-AccountName] <String> [-ResourceGroupName] <String>
 [-ApplicationId] <String> [-ApplicationVersion] <String> [-Format] <String> [-ActivateOnly]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
The **New-AzureRmBatchApplicationPackage** cmdlet creates an application package in an Azure Batch account.

## EXAMPLES

### Example 1: Install an application package into a Batch account
```
PS C:\>New-AzureRmBatchApplicationPackage -AccountName "ContosoBatch" -ResourceGroupName "ContosoBatchGroup" -ApplicationId "Litware" -ApplicationVersion "1.0" -FilePath "litware.1.0.zip" -Format "zip"
```

This command creates and activates version 1.0 of the Litware application, and uploads the contents of litware.1.0.zip as the application package content.

## PARAMETERS

### -AccountName
Specifies the name of the Batch account to which this cmdlet adds an application package.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ActivateOnly
Indicates that this cmdlet activates an application package that has already been uploaded.

```yaml
Type: SwitchParameter
Parameter Sets: ActivateOnly
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ApplicationId
Specifies the ID of the application.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: True
Position: 2
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ApplicationVersion
Specifies the version of the application.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: True
Position: 3
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with azure.

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

### -FilePath
Specifies the file to be uploaded as the application package binary file.

```yaml
Type: String
Parameter Sets: UploadAndActivate
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Format
Specifies the format of the application package binary file.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: True
Position: 4
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ResourceGroupName
Specifies the name of the resource group that contains the Batch account.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: True
Position: 1
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.Commands.Batch.Models.PSApplicationPackage

## NOTES

## RELATED LINKS

[Get-AzureRmBatchApplication](./Get-AzureRmBatchApplication.md)

[Get-AzureRmBatchApplicationPackage](./Get-AzureRmBatchApplicationPackage.md)

[New-AzureRmBatchApplication](./New-AzureRmBatchApplication.md)

[Remove-AzureRmBatchApplication](./Remove-AzureRmBatchApplication.md)

[Remove-AzureRmBatchApplicationPackage](./Remove-AzureRmBatchApplicationPackage.md)

[Set-AzureRmBatchApplication](./Set-AzureRmBatchApplication.md)


