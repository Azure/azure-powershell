### Example 1: Create remote desktop extension object

```powershell
PS C:\> $credential = Get-Credential
PS C:\> $expiration = (Get-Date).AddYears(1)
PS C:\> $extension = New-AzCloudServiceRemoteDesktopExtensionObject -Name 'RDPExtension' -Credential $credential -Expiration $expiration -TypeHandlerVersion '1.2.1'
```

This command creates remote desktop extension object which is used for creating or updating a cloud service. For more details see New-AzCloudService.
