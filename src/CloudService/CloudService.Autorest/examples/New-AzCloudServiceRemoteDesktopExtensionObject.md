### Example 1: Create remote desktop extension object

```powershell
$credential = Get-Credential
$expiration = (Get-Date).AddYears(1)
$extension = New-AzCloudServiceRemoteDesktopExtensionObject -Name 'RDPExtension' -Credential $credential -Expiration $expiration -TypeHandlerVersion '1.2.1'
```

This command creates remote desktop extension object which is used for creating or updating a cloud service. For more details see New-AzCloudService.
