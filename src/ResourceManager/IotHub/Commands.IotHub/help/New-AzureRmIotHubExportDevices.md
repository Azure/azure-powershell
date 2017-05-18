---
external help file: Microsoft.Azure.Commands.IotHub.dll-Help.xml
online version: 
schema: 2.0.0
---

# New-AzureRmIotHubExportDevices

## SYNOPSIS
Creates a new export devices job.

## SYNTAX

```
New-AzureRmIotHubExportDevices [-ResourceGroupName] <String> [-Name] <String>
 [-ExportBlobContainerUri] <String> [-WhatIf] [-Confirm]
```

## DESCRIPTION
Creates a new export devices job for the IotHub.
This will export all the devices to the specified container. 
Refer to the following article on how to generate the SAS URI.
https://azure.microsoft.com/en-us/documentation/articles/iot-hub-bulk-identity-mgmt/ .

## EXAMPLES

### Example 1 Issue an export device request.
```
PS C:\> New-AzureRmIotHubExportDevices -ResourceGroupName "myresourcegroup" -Name "myiothub" -ExportBlobContainerUri "https://mystorageaccount.blob.core.windows.net/?sv=2015-04-05&ss=bfqt&sr=c&srt=sco&sp=rwdl&se=2016-10-27T04:01:48Z&st=2016-10-26T20:01:48Z&spr=https&sig=QqpIhHsIMF8hNuFO%3D" -ExcludeKeys $true
```

Creates a new export device request for the IotHub "myiothub" excluding the keys.

## PARAMETERS

### -ExportBlobContainerUri
ExportBlobContainerUri

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: True
Position: 2
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
Name

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

### -ResourceGroupName
Resource Group Name

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

### -Confirm
Prompts you for confirmation before running the cmdlet.

```yaml
Type: SwitchParameter
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
The cmdlet is not run.

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases: wi

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

## INPUTS

### System.String

## OUTPUTS

### Microsoft.Azure.Management.IotHub.Models.JobResponse

## NOTES

## RELATED LINKS

