### Example 1: Bulk uploading Sims using vendor specific keys
```powershell
$sim1 = @{Name = "BulkSim01"; InternationalMobileSubscriberIdentity = "0000000001"; AuthenticationKey = "00000000000000000000000000000001"; OperatorKeyCode = "00000000000000000000000000000001"}
$sim2 = @{Name = "BulkSim02"; InternationalMobileSubscriberIdentity = "0000000002"; AuthenticationKey = "00000000000000000000000000000002"; OperatorKeyCode = "00000000000000000000000000000002"}
$sims = @($sim1,$sim2)
Update-AzMobileNetworkBulkSimUploadEncrypted -ResourceGroupName rf4-pctt-env-1 -SimGroupName SimGroup01 -Sim $sims -AzureKeyIdentifier 123 -EncryptedTransportKey 123 -SignedTransportKey 456 -VendorKeyFingerprint 123 -Version 1
```

Bulk upload SIMs in encrypted form to a SIM group using the Vendor specific keys.
