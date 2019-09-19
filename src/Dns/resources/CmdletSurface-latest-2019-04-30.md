### AzDnsRecordSet [Get, New, Remove, Set, Update] `IRecordSet, Boolean`
  - ResourceGroupName `String`
  - SubscriptionId `String[]`
  - ZoneName `String`
  - Name `String`
  - RecordType `RecordType`
  - InputObject `IDnsIdentity`
  - NameSuffix `String`
  - Top `Int32`
  - DoNotOverwrite `SwitchParameter`
  - CnameRecordName `String`
  - Etag `String`
  - Metadata `Hashtable`
  - TargetResourceId `String`
  - TimeToLive `Int64`
  - ARecord `IARecord[]`
  - AaaaRecord `IAaaaRecord[]`
  - CaaRecord `ICaaRecord[]`
  - MXRecord `IMxRecord[]`
  - NSRecord `INsRecord[]`
  - PtrRecord `IPtrRecord[]`
  - SrvRecord `ISrvRecord[]`
  - TxtRecord `ITxtRecord[]`
  - IfMatch `String`
  - SoaRecordEmail `String`
  - SoaRecordExpireTime `Int64`
  - SoaRecordHost `String`
  - SoaRecordMinimumTtl `Int64`
  - SoaRecordRefreshTime `Int64`
  - SoaRecordRetryTime `Int64`
  - SoaRecordSerialNumber `Int64`

### AzDnsResourceReference [Get] `IDnsResourceReferenceResultProperties`
  - SubscriptionId `String[]`
  - TargetResourceId `String[]`

### AzDnsZone [Get, New, Remove, Set] `IZone, Boolean`
  - SubscriptionId `String[]`
  - Name `String`
  - ResourceGroupName `String`
  - InputObject `IDnsIdentity`
  - Top `Int32`
  - DoNotOverwrite `SwitchParameter`
  - Location `String`
  - Etag `String`
  - Tag `Hashtable`
  - Private `SwitchParameter`
  - RegistrationVirtualNetworkId `String[]`
  - ResolutionVirtualNetworkId `String[]`
  - IfMatch `String`

