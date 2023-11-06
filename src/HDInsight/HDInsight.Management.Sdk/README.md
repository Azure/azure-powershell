# Overall
This directory contains management plane service clients of Az.HDInsight module.

## Run Generation
In this directory, run AutoRest:
```
autorest --reset
autorest --use:@microsoft.azure/autorest.csharp@2.3.90
```

### AutoRest Configuration
> see https://aka.ms/autorest
``` yaml
isSdkGenerator: true
csharp: true
clear-output-folder: true
reflect-api-versions: true
openapi-type: arm
azure-arm: true
license-header: MICROSOFT_MIT_NO_VERSION
payload-flattening-threshold: 2
namespace: Microsoft.Azure.Management.HDInsight
modelerfour:
  flatten-payloads: false
skip-csproj: true
```



###
``` yaml
commit: b36f75338bb933cbf23cc1daedc222f0d50855ca
input-file:
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/hdinsight/resource-manager/Microsoft.HDInsight/preview/2023-04-15-preview/applications.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/hdinsight/resource-manager/Microsoft.HDInsight/preview/2023-04-15-preview/cluster.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/hdinsight/resource-manager/Microsoft.HDInsight/preview/2023-04-15-preview/configurations.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/hdinsight/resource-manager/Microsoft.HDInsight/preview/2023-04-15-preview/extensions.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/hdinsight/resource-manager/Microsoft.HDInsight/preview/2023-04-15-preview/locations.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/hdinsight/resource-manager/Microsoft.HDInsight/preview/2023-04-15-preview/operations.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/hdinsight/resource-manager/Microsoft.HDInsight/preview/2023-04-15-preview/privateEndpointConnections.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/hdinsight/resource-manager/Microsoft.HDInsight/preview/2023-04-15-preview/privateLinkResources.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/hdinsight/resource-manager/Microsoft.HDInsight/preview/2023-04-15-preview/scriptActions.json
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/hdinsight/resource-manager/Microsoft.HDInsight/preview/2023-04-15-preview/virtualMachines.json

output-folder: Generated



format-by-name-rules:
  'tenantId': 'uuid'
  'ETag': 'etag'
  'location': 'azure-location'
  '*Uri': 'Uri'
  '*Uris': 'Uri'
  'privateIPAddress': 'ip-address'

rename-rules:
  CPU: Cpu
  CPUs: Cpus
  Os: OS
  Ip: IP
  Ips: IPs|ips
  ID: Id
  IDs: Ids
  VM: Vm
  VMs: Vms
  Vmos: VmOS
  VMScaleSet: VmScaleSet
  DNS: Dns
  VPN: Vpn
  NAT: Nat
  WAN: Wan
  Ipv4: IPv4|ipv4
  Ipv6: IPv6|ipv6
  Ipsec: IPsec|ipsec
  SSO: Sso
  URI: Uri
  Etag: ETag|etag
  RSA: Rsa
  RSA15: Rsa15
  Autoscale: AutoScale
  Mb: MB


```