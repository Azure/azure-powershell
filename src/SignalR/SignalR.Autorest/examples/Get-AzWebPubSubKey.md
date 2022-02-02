### Example 1: Get the access keys of a Web PubSub resource
```powershell
PS C:\> Get-AzWebPubSubKey -ResourceGroupName psdemo -ResourceName psdemo-wps  | Format-List

PrimaryConnectionString   : Endpoint=https://psdemo-wps.webpubsub.azure.com;AccessKey=********;Version=1.0;
PrimaryKey                : ********
SecondaryConnectionString : Endpoint=https://psdemo-wps.webpubsub.azure.com;AccessKey=********;Version=1.0;
SecondaryKey              : ********
```

The example gets the access keys of the Web PubSub resource and then pipes the result to `Format-List` to see all the property values of the result.

### Example 2: Get the access keys of a Web PubSub resource via identity
```powershell
PS C:\> $wps = Get-AzWebPubSub -ResourceGroupName psdemo -ResourceName psdemo-wps
PS C:\> $wps | Get-AzWebPubSubKey | Format-List

PrimaryConnectionString   : Endpoint=https://psdemo-wps.webpubsub.azure.com;AccessKey=********;Version=1.0;
PrimaryKey                : ********
SecondaryConnectionString : Endpoint=https://psdemo-wps.webpubsub.azure.com;AccessKey=********;Version=1.0;
SecondaryKey              : ********
```

The example gets the access keys of the Web PubSub resource and then pipes the result to `Format-List` to see all the property values of the result.

