---
external help file: Microsoft.AzureStack.Commands.StorageAdmin.dll-Help.xml
online version: 
schema: 2.0.0
ms.assetid: 25D0C4A3-49EE-4A56-955F-C0A21A5BE0CB
---

# Get-ACSEvent

## SYNOPSIS
Gets the events in the ACS system.

## SYNTAX

### EventWithFilter (Default)
```
Get-ACSEvent -FarmName <String> -StartTime <DateTime> -EndTime <DateTime> [-NodeName <String>]
 [-ResourceUri <String>] [-ProviderGuid <Guid>] [-EventId <Int32[]>] [[-SubscriptionId] <String>]
 [[-Token] <String>] [[-AdminUri] <Uri>] [-ResourceGroupName] <String> [-SkipCertificateValidation]
 [<CommonParameters>]
```

### EventWithLocation
```
Get-ACSEvent -EventQuery <EventQuery> [[-SubscriptionId] <String>] [[-Token] <String>] [[-AdminUri] <Uri>]
 [-ResourceGroupName] <String> [-SkipCertificateValidation] [<CommonParameters>]
```

## DESCRIPTION
The **Get-ACSEvent** cmdlet gets a list of event objects events in the Azure Consistent Storage (ACS) system.
You can compose an event query with the Get-ACSEventQuery cmdlet.

## EXAMPLES

### Example 1: Get the events in the Consistent Storage system
```
PS C:\>$StartTime = Get-Date
PS C:\> $EndTime = $StartTime.AddMinutes(10)
PS C:\> $Events = Get-ACSEvents -StartTime $StartTime -EndTime $EndTime -FarmName $Farm.Name -Token $Token -SubscriptionId $SubscriptId -AdminUri $AdminUri -ResourceGroupName $ResourceGroup
PS C:\> $Events | select-object -expandproperty Properties
Id             : 0000000000000000000___0635804041200000000_511___WEIX6COL2___0000000004295475859
Timestamp      : 10/14/2015 7:23:49 AM +00:00
ComputerName   : WEIX6COL2
ChannelName    : Microsoft-Windows-ObjectStorageService/Admin
EventId        : 1024
Level          : Error
ProviderName   : Microsoft-Windows-ObjectStorageService
EventTimeStamp : 10/14/2015 7:22:09 AM
Message        : Health check CreateListDeleteBlobsHealthCheck failed. Resource type: MonitoringServer Resource ID: WEIX6COL2 Error: System.AggregateException: One or more errors occurred. ---> System.NullReferenceException: Object reference not set to an instance of an object. 
                    at Microsoft.ObjectStorage.Health.SmokeTests.BlobEndToEndTest.<ExecuteHealthCheckAsync>d__2.MoveNext()
                 --- End of stack trace from previous location where exception was thrown ---
                    at System.Runtime.CompilerServices.TaskAwaiter.ThrowForNonSuccess(Task task) 
                    at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task) 
                    at System.Runtime.CompilerServices.TaskAwaiter`1.GetResult()
                    at Microsoft.ObjectStorage.Health.ExecutionEngine.<ExecuteTestCasesAsync>d__d.MoveNext()
                    --- End of inner exception stack trace ---
                 ---> (Inner Exception #0) System.NullReferenceException: Object reference not set to an instance of an object. 
                    at Microsoft.ObjectStorage.Health.SmokeTests.BlobEndToEndTest.<ExecuteHealthCheckAsync>d__2.MoveNext()
                 --- End of stack trace from previous location where exception was thrown ---
                    at System.Runtime.CompilerServices.TaskAwaiter.ThrowForNonSuccess(Task task) 
                    at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task) 
                    at System.Runtime.CompilerServices.TaskAwaiter`1.GetResult()
                    at Microsoft.ObjectStorage.Health.ExecutionEngine.<ExecuteTestCasesAsync>d__d.MoveNext()<---
```

This command gets the events in the Consistent Storage system and stores the result in the $Events variable.

### Example 2: Get the select events in the Consistent Storage system based on a query
```
PS C:\>$EndTime=Get-Date
PS C:\> $StartTime=$EndTime.addminutes(-10)
PS C:\> $Query = Get-ACSEventQuery -FarmId $farm.Name -Token $Token -SubscriptionId $SubscriptId -AdminUri $AdminUri -ResourceGroupName $ResourceGroup -StartTime $StartTime -EndTime $EndTime
PS C:\> Get-ACSEvents -EventQuery $Query -Token "DS" -SubscriptionId "SID" -AdminUri "https://weix6col0:30020" -ResourceGroupName "System" | select-object -expandproperty Properties
Id             : 0000000000000000000___0635804041200000000_511___WEIX6COL2___0000000004295475859
Timestamp      : 10/14/2015 7:23:49 AM +00:00
ComputerName   : WEIX6COL2
ChannelName    : Microsoft-Windows-ObjectStorageService/Admin
EventId        : 1024
Level          : Error
ProviderName   : Microsoft-Windows-ObjectStorageService
EventTimeStamp : 10/14/2015 7:22:09 AM
Message        : Health check CreateListDeleteBlobsHealthCheck failed. Resource type: MonitoringServer Resource ID: 
                 WEIX6COL2 Error: System.AggregateException: One or more errors occurred. --->
                 System.NullReferenceException: Object reference not set to an instance of an object.
```

This command gets select events in the Consistent Storage system that is based on a query.

## PARAMETERS

### -AdminUri
Specifies the location of the Resource Manager endpoint.
If you configured your environment by using the Set-AzureRMEnvironment cmdlet, you do not have to specify this parameter.

```yaml
Type: Uri
Parameter Sets: (All)
Aliases: 

Required: False
Position: 2
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -EndTime
Specifies the end of a time range.

```yaml
Type: DateTime
Parameter Sets: EventWithFilter
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EventId

```yaml
Type: Int32[]
Parameter Sets: EventWithFilter
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EventQuery
Specifies the Event query come from **Get-ACSEventQuery** cmdlet.

```yaml
Type: EventQuery
Parameter Sets: EventWithLocation
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -FarmName
Specifies the name of the ACS farm.

```yaml
Type: String
Parameter Sets: EventWithFilter
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NodeName
Specifies the name of the node.

```yaml
Type: String
Parameter Sets: EventWithFilter
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProviderGuid
Specifies an array of GUIDs for the event provider.
If both the *ProviderGuid* and *EventIds* parameters are provided, the cmdlet returns the events from the specified providers that match the event IDs.

```yaml
Type: Guid
Parameter Sets: EventWithFilter
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
Specifies the name of the resource group that this cmdlet gets ACS events from.

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

### -ResourceUri
Specifies the URI of a resource.

```yaml
Type: String
Parameter Sets: EventWithFilter
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SkipCertificateValidation
Indicates that this cmdlet skips certificate validation.

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -StartTime
Specifies the beginning of the time range.

```yaml
Type: DateTime
Parameter Sets: EventWithFilter
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
Specifies the service administrator subscription ID.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: False
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Token
Specifies the service administrator token.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: False
Position: 1
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.AzureStack.Commands.StorageAdmin.FarmResponse,
Output from Get-ACSFarm can be piped to this cmdlet's input.

## OUTPUTS

## NOTES

## RELATED LINKS

[Get-ACSEventQuery](./Get-ACSEventQuery.md)

[Get-ACSFarm](./Get-ACSFarm.md)


