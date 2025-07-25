---
external help file: Az.CloudService-help.xml
Module Name: Az.CloudService
online version: https://learn.microsoft.com/powershell/module/az.cloudservice/get-azcloudserviceosfamily
schema: 2.0.0
---

# Get-AzCloudServiceOSFamily

## SYNOPSIS
Gets properties of a guest operating system family that can be specified in the XML service configuration (.cscfg) for a cloud service.

## SYNTAX

### List (Default)
```
Get-AzCloudServiceOSFamily -Location <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### Get
```
Get-AzCloudServiceOSFamily -Location <String> -OSFamilyName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzCloudServiceOSFamily -InputObject <ICloudServiceIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Gets properties of a guest operating system family that can be specified in the XML service configuration (.cscfg) for a cloud service.

## EXAMPLES

### Example 1: Get all OS families in a location
```powershell
Get-AzCloudServiceOSFamily -location 'westus2'
```

```output
Name Label
---- -----
5    Windows Server 2016
4    Windows Server 2012 R2
6    Windows Server 2019
3    Windows Server 2012
2    Windows Server 2008 R2
```

This command gets all OS families in location westus2

### Example 2: Get OS family
```powershell
Get-AzCloudServiceOSFamily -location 'westus2' -OSFamilyName 5
```

```output
Name Label
---- -----
5    Windows Server 2016
```

This command gets OS family named 5 that is located in westus2.

## PARAMETERS

### -DefaultProfile
The DefaultProfile parameter is not functional.
Use the SubscriptionId parameter when available if executing the cmdlet against a different subscription.

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

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.ICloudServiceIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Location
Name of the location that the OS family pertains to.

```yaml
Type: System.String
Parameter Sets: List, Get
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -OSFamilyName
Name of the OS family.

```yaml
Type: System.String
Parameter Sets: Get
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
Subscription credentials which uniquely identify Microsoft Azure subscription.
The subscription ID forms part of the URI for every service call.

```yaml
Type: System.String[]
Parameter Sets: List, Get
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.ICloudServiceIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20220904.IOSFamily

## NOTES

## RELATED LINKS
