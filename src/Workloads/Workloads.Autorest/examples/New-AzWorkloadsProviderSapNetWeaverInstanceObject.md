### Example 1: Create SAP Netweaver Provider 
```powershell
New-AzWorkloadsProviderSapNetWeaverInstanceObject -SapClientId 000 -SapHostFileEntry '["10.0.82.4 l13appvm0.ams.azure.com l13appvm0","10.0.82.5 l13ascsvm.ams.azure.com l13ascsvm"]' -SapHostname 10.0.82.4 -SapInstanceNr 00 -SapPassword Password@1234 -SapSid L13 -SapUsername AMSUSER -SslPreference Disabled
```

```output
ProviderType SapClientId SapHostFileEntry                                                                                SapHostname
------------ ----------- ----------------                                                                                -----------
SapNetWeaver 000         {["10.0.82.4 l13appvm0.ams.azure.com l13appvm0","10.0.82.5 l13ascsvm.ams.azure.com l13ascsvm"]} 10.0.82.4
```

Create SAP Netweaver Provider for an AMS instance
