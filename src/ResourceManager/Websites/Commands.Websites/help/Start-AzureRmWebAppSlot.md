---
external help file: Microsoft.Azure.Commands.Websites.dll-Help.xml
ms.assetid: 0FDDDEE1-CEAD-46DA-A7EB-EE477ED59749
online version: 
schema: 2.0.0
---

# Start-AzureRmWebAppSlot

## SYNOPSIS
Starts an Azure Web App slot.

## SYNTAX

### S1
```
Start-AzureRmWebAppSlot [-ResourceGroupName] <String> [-Name] <String> [-Slot] <String>
```

### S2
```
Start-AzureRmWebAppSlot [-WebApp] <Site>
```

## DESCRIPTION
The **Start-AzureRmWebAppSlot** cmdlet starts an Azure Web App Slot.

## EXAMPLES

### Example 1
```
PS C:\>Start-AzureRmWebAppSlot -ResourceGroupName "Default-Web-WestUS" -Name "ContosoWebApp" -Slot "Slot001"
```

This command starts the Slot named Slot001 pertaining to the Web App named ContosoWebApp that belongs to the resource group named Default-Web-WestUS.

## PARAMETERS

### -Name
WebApp Name

```yaml
Type: String
Parameter Sets: S1
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
Parameter Sets: S1
Aliases: 

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Slot
WebApp Slot Name

```yaml
Type: String
Parameter Sets: S1
Aliases: 

Required: True
Position: 2
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WebApp
WebApp Object

```yaml
Type: Site
Parameter Sets: S2
Aliases: 

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

## INPUTS

## OUTPUTS

## NOTES

## RELATED LINKS

[Get-AzureRMWebAppSlot](./Get-AzureRMWebAppSlot.md)

[New-AzureRMWebAppSlot](./New-AzureRMWebAppSlot.md)

[Remove-AzureRMWebAppSlot](./Remove-AzureRMWebAppSlot.md)

[Restart-AzureRMWebAppSlot](./Restart-AzureRMWebAppSlot.md)

[Set-AzureRMWebAppSlot](./Set-AzureRMWebAppSlot.md)

[Stop-AzureRMWebAppSlot](./Stop-AzureRMWebAppSlot.md)

[Get-AzureRmWebApp](./Get-AzureRmWebApp.md)
