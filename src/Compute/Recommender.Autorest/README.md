<!-- region Generated -->
# Az.Recommender
This directory contains the PowerShell module for the Recommender service.

---
## Info
- Modifiable: yes
- Generated: all
- Committed: yes
- Packaged: yes

---
## Detail
This module was primarily generated via [AutoRest](https://github.com/Azure/autorest) using the [PowerShell](https://github.com/Azure/autorest.powershell) extension.

## Module Requirements
- [Az.Accounts module](https://www.powershellgallery.com/packages/Az.Accounts/), version 2.7.5 or greater

## Authentication
AutoRest does not generate authentication code for the module. Authentication is handled via Az.Accounts by altering the HTTP payload before it is sent.

## Development
For information on how to develop for `Az.Recommender`, see [how-to.md](how-to.md).
<!-- endregion -->

### AutoRest Configuration
> see https://aka.ms/autorest
``` yaml
commit: 6f498e0646e1bb978b8b6f8b4e701938dd79df2b
require:
# readme.azure.noprofile.md is the common configuration file
  - $(this-folder)/../../readme.azure.noprofile.md
# If the swagger has not been put in the repo, you may uncomment the following line and refer to it locally
# - (this-folder)/relative-path-to-your-local-readme.md
input-file:
# You need to specify your swagger files here.
#  - $(repo)/specification/compute/resource-manager/Microsoft.Compute/RecommenderRP/stable/2025-06-05/RecommenderRP.json
# If the swagger has not been put in the repo, you may uncomment the following line and refer to it locally
 - (this-folder)/../../../../../azure-rest-api-specs/specification/compute/resource-manager/Microsoft.Compute/RecommenderRP/stable/2025-06-05/RecommenderRP.json
module-version: 0.3.0
# Normally, title is the service name
title: Recommender
subject-prefix: ""

# If there are post APIs for some kinds of actions in the RP, you may need to 
# uncomment following line to support viaIdentity for these post APIs
# identity-correction-for-post: true

# For new modules, please avoid setting 3.x using the use-extension method and instead, use 4.x as the default option
use-extension:
  "@autorest/powershell": "3.x"

directive:
  # Following is two common directive which are normally required in all the RPs
  # 1. Remove the unexpanded parameter set
  # 2. For New-* cmdlets, ViaIdentity is not required, so CreateViaIdentityExpanded is removed as well
  - where:
      variant: ^Create$|^CreateViaIdentity$|^CreateViaIdentityExpanded$|^Update$|^UpdateViaIdentity$
    remove: true
  # Remove following verbs
  - select: command
    where:
      verb: Export|Convert|Install
    remove: true
  ## Add Alias for Invoke-AzSpotPlacementScore
  - where:
      verb: Invoke
      subject: SpotPlacementRecommender
    remove: true
  - where:
      verb: Invoke
      subject: SpotPlacementScore
    set:
      alias: Invoke-AzSpotPlacementRecommender
  - where:
      parameter-name: SpotPlacementScoresInput
    set:
      alias: SpotPlacementRecommenderInput
```
