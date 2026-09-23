### AzChangeSafetyChangeRecord [Get, New, Remove, Update] `IChangeRecord, Boolean`
  - SubscriptionId `String[]`
  - Name `String`
  - ResourceGroupName `String`
  - InputObject `IChangeSafetyIdentity`
  - AdditionalData `IAny`
  - AnticipatedEndTime `DateTime`
  - AnticipatedStartTime `DateTime`
  - ChangeDefinitionDetail `IAny`
  - ChangeDefinitionKind `String`
  - ChangeDefinitionName `String`
  - ChangeType `String`
  - Comment `String`
  - Description `String`
  - Link `ILink[]`
  - OrchestrationTool `String`
  - Parameter `Hashtable`
  - ReleaseLabel `String`
  - RolloutType `String`
  - StageMapParameter `Hashtable`
  - StageMapResourceId `String`
  - Targets `Object[]`
  - TargetName `String`
  - JsonString `String`
  - JsonFilePath `String`

### AzChangeSafetyStageMap [Get, New, Remove, Update] `IStageMap, Boolean`
  - SubscriptionId `String[]`
  - ManagementGroupName `String`
  - Name `String`
  - ManagementGroupInputObject `IChangeSafetyIdentity`
  - ResourceGroupName `String`
  - InputObject `IChangeSafetyIdentity`
  - Parameter `Hashtable`
  - Stage `IStage[]`
  - JsonString `String`
  - JsonFilePath `String`

### AzChangeSafetyStageProgression [Get, New, Remove, Update] `IChangeRecordStageProgression, Boolean`
  - ChangeRecordName `String`
  - SubscriptionId `String[]`
  - ResourceGroupName `String`
  - StageProgressionName `String`
  - ChangeRecord1InputObject `IChangeSafetyIdentity`
  - ChangeRecordInputObject `IChangeSafetyIdentity`
  - InputObject `IChangeSafetyIdentity`
  - AdditionalData `IAny`
  - Comment `String`
  - Link `ILink[]`
  - Parameter `Hashtable`
  - StageReference `String`
  - StageVariable `Hashtable`
  - Status `String`
  - JsonString `String`
  - JsonFilePath `String`

