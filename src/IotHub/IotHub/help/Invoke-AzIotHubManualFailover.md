---
external help file: Microsoft.Azure.PowerShell.Cmdlets.IotHub.dll-Help.xml
Module Name: Az.IotHub
online version: https://docs.microsoft.com/en-us/powershell/module/az.iothub/invoke-aziothubmanualfailover
schema: 2.0.0
---

# Invoke-AzIotHubManualFailover

## SYNOPSIS
Initiate a manual failover for the IoT Hub to the geo-paired disaster recovery region.

## SYNTAX

### ResourceSet (Default)
```
Invoke-AzIotHubManualFailover [-ResourceGroupName] <String> [-Name] <String> [-FailoverRegion <String>]
 [-AsJob] [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### InputObjectSet
```
Invoke-AzIotHubManualFailover [-InputObject] <PSIotHub> [-FailoverRegion <String>] [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### ResourceIdSet
```
Invoke-AzIotHubManualFailover [-ResourceId] <String> [-FailoverRegion <String>] [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
It will trigger the failover your IoT hub to the secondary location. This action will cause down time and telemetry loss to your solution. 
This is a long running operation and could take several minutes to finish. Please exercise with caution when using it.

## EXAMPLES

### Example 1
```powershell
PS C:\> Invoke-AzIotHubManualFailover -ResourceGroupName "myresourcegroup" -Name "myiothub"
```

Initiating failover process of "myiothub" IoT Hub.

### Example 2
```powershell
PS C:\> Invoke-AzIotHubManualFailover -ResourceGroupName "myresourcegroup" -Name "myiothub" -AsJob
```

Initiating failover process of "myiothub" IoT Hub in the background.

### Example 3
```powershell
PS C:\> Invoke-AzIotHubManualFailover -ResourceGroupName "myresourcegroup" -Name "myiothub" -FailoverRegion "WestUS2"
```

Initiating failover process of "myiothub" IoT Hub to the specified geo-paired disaster recovery region.

## PARAMETERS

### -AsJob
Run cmdlet in the background

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
Type: Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer
Parameter Sets: (All)
Aliases: AzContext, AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -FailoverRegion
The region that the IoT hubfails over to.
Must be the paired region to the current IoT hub region.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Iot Hub Object

```yaml
Type: Microsoft.Azure.Commands.Management.IotHub.Models.PSIotHub
Parameter Sets: InputObjectSet
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
Name of the Iot Hub

```yaml
Type: System.String
Parameter Sets: ResourceSet
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ResourceGroupName
Name of the Resource Group

```yaml
Type: System.String
Parameter Sets: ResourceSet
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ResourceId
Iot Hub Resource Id

```yaml
Type: System.String
Parameter Sets: ResourceIdSet
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.Commands.Management.IotHub.Models.PSIotHub

### System.String

## OUTPUTS

### System.Void

## NOTES

## RELATED LINKS
