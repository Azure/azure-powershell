# Upcoming Features in Future Az 4.0 previews
This document describes features that are planned, but were not ready for the 4.0 previews

## Argument Completers
Existing Az cmdlets implement `dynamic` tab completers on parameters like `Location`, `ResourceGroupName`, and `ResourceId`, allowing users to complete parameter values by tabbing through existing resources in their subscriptions in Azure.  This capability, and extensions to include Argument Completers for Subscriptiona nd Tenant will be available in an upcoming preview.

## Positional Parameters
Az 4.0 preview cmdlets contian no positional parameters.  A future release will include consistently-applied positional parameters for all cmdlets.

## Force / ShouldContinue Support
Az 4.0 cmdlets implement `ShouldProcess` functionality appropriately, but none implement a `Force` parameter or use the `ShouldContinue` prompts for destructive cmdlet actions.  A future preview will contain appropriate application of Force and ShouldContinue to approproiate cmdlets.

