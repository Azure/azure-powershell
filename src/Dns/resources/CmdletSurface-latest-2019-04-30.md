### AzDnsRecordSet [Get, New, Remove, Set, Update] `IRecordSet, Boolean`
  - ResourceGroupName `String`
  - SubscriptionId `String[]`
  - ZoneName `String`
  - Name `String`
  - RecordType `RecordType`
  - InputObject `IDnsIdentity`
  - NameSuffix `String`
  - Top `Int32`
  - IfMatch `String`
  - IfNoneMatch `String`
  - ARecord `IARecord[]`
  - AaaaRecord `IAaaaRecord[]`
  - CaaRecord `ICaaRecord[]`
  - CnameRecordName `String`
  - Etag `String`
  - MXRecord `IMxRecord[]`
  - Metadata `Hashtable`
  - NSRecord `INsRecord[]`
  - PtrRecord `IPtrRecord[]`
  - SoaRecordEmail `String`
  - SoaRecordExpireTime `Int64`
  - SoaRecordHost `String`
  - SoaRecordMinimumTtl `Int64`
  - SoaRecordRefreshTime `Int64`
  - SoaRecordRetryTime `Int64`
  - SoaRecordSerialNumber `Int64`
  - SrvRecord `ISrvRecord[]`
  - TargetResourceId `String`
  - TimeToLive `Int64`
  - TxtRecord `ITxtRecord[]`
  - RecordSet `IRecordSet`

### AzDnsResourceReference [Get] `IDnsResourceReferenceResultProperties`
  - SubscriptionId `String[]`
  - InputObject `IDnsIdentity`
  - TargetResource `ISubResource[]`
  - ResourceReference `IDnsResourceReferenceRequest`

### AzDnsZone [Get, New, Remove, Set] `IZone, Boolean`
  - SubscriptionId `String[]`
  - Name `String`
  - ResourceGroupName `String`
  - InputObject `IDnsIdentity`
  - Top `Int32`
  - IfMatch `String`
  - IfNoneMatch `String`
  - Etag `String`
  - Location `String`
  - RegistrationVirtualNetwork `ISubResource[]`
  - ResolutionVirtualNetwork `ISubResource[]`
  - Tag `Hashtable`
  - ZoneType `ZoneType`
  - Zone `IZone`

### AzDummy [Test] `Boolean`
  - Name `String`

