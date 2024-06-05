### Example 1: Create a WebhookResource object with default values.
```powershell
$secret = ConvertTo-SecureString "testSecret" -AsPlainText
New-AzAcatWebhookResourceObject -TriggerMode "all" -PayloadUrl "https://example.com" -Secret $secret
```

```output
Name SystemDataCreatedAt  SystemDataCreatedBy SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy
---- -------------------  ------------------- ----------------------- ------------------------ ------------------------
     1/1/0001 12:00:00 AM                                             1/1/0001 12:00:00 AM
```

Create a WebhookResource object with default values.

### Example 2: Create a WebhookResource object.
```powershell
$secret = ConvertTo-SecureString "testSecret" -AsPlainText
New-AzAcatWebhookResourceObject -EnableSslVerification "true"  -Disable -TriggerMode "all" -PayloadUrl "https://example.com" -ContentType "application/json" -Secret $secret
```

```output
Name SystemDataCreatedAt  SystemDataCreatedBy SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy
---- -------------------  ------------------- ----------------------- ------------------------ ------------------------
     1/1/0001 12:00:00 AM                                             1/1/0001 12:00:00 AM
```

Create a WebhookResource object.
