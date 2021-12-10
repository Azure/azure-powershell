### Example 1: Regenerate the primary access key of a Web PubSub resource
```powershell
PS C:\>  New-AzWebPubSubKey  -ResourceGroupName psdemo -ResourceName psdemo-wps -KeyType 'Primary' | Format-List

PrimaryConnectionString   : Endpoint=https://psdemo-wps.webpubsub.azure.com;AccessKey=********;Version=1.0;
PrimaryKey                : ********
SecondaryConnectionString : Endpoint=https://psdemo-wps.webpubsub.azure.com;AccessKey=********;Version=1.0;
SecondaryKey              : ********
```


### Example 2: Regenerate the primary access key of a Web PubSub resource via identity
```powershell
PS C:\>  $wps = Get-AzWebPubSub -Name psdemo-wps -ResourceGroupName psdemo
PS C:\> $wps | New-AzWebPubSubKey -KeyType Primary | Format-List

PrimaryConnectionString   : Endpoint=https://psdemo-wps.webpubsub.azure.com;AccessKey=********;Version=1.0;
PrimaryKey                : ********
SecondaryConnectionString : Endpoint=https://psdemo-wps.webpubsub.azure.com;AccessKey=********;Version=1.0;
SecondaryKey              : ********
```



