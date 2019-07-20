### AaaaRecord [Api20150504Preview]
  - Ipv6Address `String`

### ARecord [Api20150504Preview]
  - Ipv4Address `String`

### AzureEntityResource [Api10]
  - Etag `String`
  - Id `String`
  - Name `String`
  - Type `String`

### CaaRecord [Api20180501]
  - Flag `Int32?`
  - Tag `String`
  - Value `String`

### CloudError [Api20160401, Api20180501]
  - ErrorCode `String`
  - ErrorDetail `ICloudErrorBody[]`
  - ErrorMessage `String`
  - ErrorTarget `String`

### CloudErrorBody [Api20160401, Api20180501]
  - Code `String`
  - Detail `ICloudErrorBody[]`
  - Message `String`
  - Target `String`

### CnameRecord [Api20150504Preview]
  - Cname `String`

### DnsIdentity [Models]
  - Id `String`
  - RecordType `RecordType?`
  - RelativeRecordSetName `String`
  - ResourceGroupName `String`
  - SubscriptionId `String`
  - ZoneName `String`

### DnsResourceReference [Api20180501]
  - DnsResource `ISubResource[]`
  - TargetResourceId `String`

### DnsResourceReferenceRequest [Api20180501]
  - TargetResource `ISubResource[]`

### DnsResourceReferenceRequestProperties [Api20180501]
  - TargetResource `ISubResource[]`

### DnsResourceReferenceResult [Api20180501]
  - DnsResourceReference `IDnsResourceReference[]`

### DnsResourceReferenceResultProperties [Api20180501]
  - DnsResourceReference `IDnsResourceReference[]`

### MxRecord [Api20150504Preview]
  - Exchange `String`
  - Preference `Int32?`

### NsRecord [Api20150504Preview]
  - Nsdname `String`

### ProxyResource [Api10]
  - Id `String`
  - Name `String`
  - Type `String`

### PtrRecord [Api20150504Preview]
  - Ptrdname `String`

### RecordSet [Api20150504Preview, Api20160401, Api20180501]
  - AaaaRecord `IAaaaRecord[]`
  - ARecord `IARecord[]`
  - CaaRecord `ICaaRecord[]`
  - CnameRecordCname `String`
  - Etag `String`
  - Fqdn `String`
  - Id `String`
  - Location `String`
  - Metadata `IRecordSetPropertiesMetadata`
  - MxRecord `IMxRecord[]`
  - Name `String`
  - NsRecord `INsRecord[]`
  - ProvisioningState `String`
  - PtrRecord `IPtrRecord[]`
  - SoaRecordEmail `String`
  - SoaRecordExpireTime `Int64?`
  - SoaRecordHost `String`
  - SoaRecordMinimumTtl `Int64?`
  - SoaRecordRefreshTime `Int64?`
  - SoaRecordRetryTime `Int64?`
  - SoaRecordSerialNumber `Int64?`
  - SrvRecord `ISrvRecord[]`
  - Tag `ITrackedResourceTags`
  - TargetResourceId `String`
  - Ttl `Int64?`
  - TxtRecord `ITxtRecord[]`
  - Type `String`

### RecordSetListResult [Api20160401, Api20180501]
  - NextLink `String`
  - Value `IRecordSet[]`

### RecordSetProperties [Api20150504Preview, Api20160401, Api20180501]
  - AaaaRecord `IAaaaRecord[]`
  - ARecord `IARecord[]`
  - CaaRecord `ICaaRecord[]`
  - CnameRecord `ICnameRecord`
  - CnameRecordCname `String`
  - Fqdn `String`
  - Metadata `IRecordSetPropertiesMetadata`
  - MxRecord `IMxRecord[]`
  - NsRecord `INsRecord[]`
  - ProvisioningState `String`
  - PtrRecord `IPtrRecord[]`
  - SoaRecord `ISoaRecord`
  - SoaRecordEmail `String`
  - SoaRecordExpireTime `Int64?`
  - SoaRecordHost `String`
  - SoaRecordMinimumTtl `Int64?`
  - SoaRecordRefreshTime `Int64?`
  - SoaRecordRetryTime `Int64?`
  - SoaRecordSerialNumber `Int64?`
  - SrvRecord `ISrvRecord[]`
  - TargetResourceId `String`
  - Ttl `Int64?`
  - TxtRecord `ITxtRecord[]`

### RecordSetPropertiesMetadata [Api20160401]
  - Item `String`

### Resource [Api10, Api20180501]
  - Id `String`
  - Location `String`
  - Name `String`
  - Tag `IResourceTags`
  - Type `String`

### ResourceTags [Api20180501]
  - Item `String`

### SoaRecord [Api20150504Preview, Api20160401]
  - Email `String`
  - ExpireTime `Int64?`
  - Host `String`
  - MinimumTtl `Int64?`
  - RefreshTime `Int64?`
  - RetryTime `Int64?`
  - SerialNumber `Int64?`

### SrvRecord [Api20150504Preview]
  - Port `Int32?`
  - Priority `Int32?`
  - Target `String`
  - Weight `Int32?`

### SubResource [Api20180301Preview]
  - Id `String`

### TrackedResource [Api10]
  - Id `String`
  - Location `String`
  - Name `String`
  - Tag `ITrackedResourceTags`
  - Type `String`

### TrackedResourceTags [Api10]
  - Item `String`

### TxtRecord [Api20150504Preview]
  - Value `String[]`

### Zone [Api20150504Preview, Api20160401, Api20170901, Api20180301Preview, Api20180501]
  - Etag `String`
  - Id `String`
  - Location `String`
  - MaxNumberOfRecordSet `Int64?`
  - Name `String`
  - NameServer `String[]`
  - NumberOfRecordSet `Int64?`
  - RegistrationVirtualNetwork `ISubResource[]`
  - ResolutionVirtualNetwork `ISubResource[]`
  - Tag `IResourceTags`
  - Type `String`
  - ZoneType `ZoneType?`

### ZoneDeleteResult [Api20160401]
  - AzureAsyncOperation `String`
  - RequestId `String`
  - Status `OperationStatus?`
  - StatusCode `HttpStatusCode?`

### ZoneListResult [Api20160401, Api20180501]
  - NextLink `String`
  - Value `IZone[]`

### ZoneProperties [Api20150504Preview, Api20160401, Api20170901, Api20180301Preview]
  - MaxNumberOfRecordSet `Int64?`
  - NameServer `String[]`
  - NumberOfRecordSet `Int64?`
  - RegistrationVirtualNetwork `ISubResource[]`
  - ResolutionVirtualNetwork `ISubResource[]`
  - ZoneType `ZoneType?`

### ZoneUpdate [Api20180501]
  - Tag `IZoneUpdateTags`

### ZoneUpdateTags [Api20180501]
  - Item `String`

