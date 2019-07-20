### AzDnsRecordSet [Get, New, Remove, Set, Update]
  - ResourceGroupName `String`
  - SubscriptionId `String[]`
  - ZoneName `String`
  - RecordType `RecordType`
  - RelativeRecordSetName `String`
  - InputObject `IDnsIdentity`
  - Recordsetnamesuffix `String`
  - Top `Int32`
  - IfMatch `String`
  - IfNoneMatch `String`
  - Parameter `IRecordSet`
  - ARecord `IARecord[]`
  - AaaaRecord `IAaaaRecord[]`
  - CaaRecord `ICaaRecord[]`
  - CnameRecordCname `String`
  - Etag `String`
  - Metadata `Hashtable`
  - MxRecord `IMxRecord[]`
  - NsRecord `INsRecord[]`
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

### AzDnsResourceReference [Get]
  - SubscriptionId `String[]`
  - InputObject `IDnsIdentity`
  - Parameter `IDnsResourceReferenceRequest`
  - TargetResource `ISubResource[]`

### AzDnsZone [Get, New, Remove, Set, Update]
  - SubscriptionId `String[]`
  - Name `String`
  - ResourceGroupName `String`
  - InputObject `IDnsIdentity`
  - Top `Int32`
  - IfMatch `String`
  - IfNoneMatch `String`
  - Parameter `IZone`
  - Etag `String`
  - Location `String`
  - RegistrationVirtualNetwork `ISubResource[]`
  - ResolutionVirtualNetwork `ISubResource[]`
  - Tag `Hashtable`
  - ZoneType `ZoneType`

