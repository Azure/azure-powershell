# Generate Azure.CodeSigning SDK

## Settings

```yaml
license-header: MICROSOFT_MIT_NO_VERSION
input-file: Swagger/certificateprofile.json
output-folder: Generated/
clear-output-folder: true
openapi-type: data-plane
public-clients: true
csharp: true
namespace: Azure.CodeSigning
use:
  - '@autorest/csharp@3.0.0-beta.20210604.3'
skip-csproj: true
```
