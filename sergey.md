# Comments

1. availabilitySet in VMSS
1. we don't create AvailabilitySets.

## Dependencies

```
VM -> AvailabilitySet -> ProximityPlacementGroup
   ->                    ProximityPlacementGroup
```

## Scenarios

- availabilitySet, proximityPlacementGroup
  - check match.
- availabilitySet
  - generate proximityPlacementGroup ?
- proximityPlacementGroup
  - generate availabilitySet ?
- none.
  - generate proximityPlacementGroup ?
  - generate availabilitySet ?

## Requirements

Make sure PPG is matching AvailabilitySetGroup.PPG ? I don't think we have such validations in other configurations.