### ArmResourceOperation [Models]
  - BodyLocation `String`
  - BodyName `String`
  - BodyProperty `IAny`
  - HttpMethod `String`
  - Uri `String`

### ArrayParameter [Models]
  - AllowedValue `List<IAny>`
  - DefaultValue `List<IAny>`
  - Metadata `IParameterMetadata <String>`
  - Type `String`

### ArrayParameterUpdate [Models]
  - AllowedValue `List<IAny>`
  - DefaultValue `List<IAny>`
  - Metadata `IParameterUpdateMetadata <String>`
  - Type `String`

### AuditRecord [Models]
  - Id `String`
  - InitiatedBy `String`
  - InitiatedByType `String`
  - Property `IAny`
  - Timestamp `DateTime?`
  - Type `String`

### ChangeDefinition [Models]
  - Detail `IAny`
  - Kind `String`
  - Name `String`

### ChangeDefinitionUpdate [Models]
  - Detail `IAny`
  - Kind `String`
  - Name `String`

### ChangeRecord [Models]
  - AdditionalData `IAny`
  - AnticipatedEndTime `DateTime?`
  - AnticipatedStartTime `DateTime?`
  - ChangeDefinitionDetail `IAny`
  - ChangeDefinitionKind `String`
  - ChangeDefinitionName `String`
  - ChangeType `String`
  - Comment `String`
  - Description `String`
  - Id `String`
  - Link `List<ILink>`
  - Name `String`
  - OrchestrationTool `String`
  - Parameter `IChangeRecordPropertiesParameters <IParameter>`
  - ProvisioningState `String`
  - ReleaseLabel `String`
  - ResourceGroupName `String`
  - RolloutType `String`
  - StageMapParameter `INestedStageMapParameters <Object>`
  - StageMapResourceId `String`
  - StageMapSnapshot `List<IAny>`
  - Status `String`
  - SystemDataCreatedAt `DateTime?`
  - SystemDataCreatedBy `String`
  - SystemDataCreatedByType `String`
  - SystemDataLastModifiedAt `DateTime?`
  - SystemDataLastModifiedBy `String`
  - SystemDataLastModifiedByType `String`
  - Type `String`

### ChangeRecordAuditRecord [Models]
  - Id `String`
  - InitiatedBy `String`
  - InitiatedByType `String`
  - Property `IAny`
  - Timestamp `DateTime?`
  - Type `String`

### ChangeRecordListResult [Models]
  - NextLink `String`
  - Value `List<IChangeRecord>`

### ChangeRecordProperties [Models]
  - AdditionalData `IAny`
  - AnticipatedEndTime `DateTime`
  - AnticipatedStartTime `DateTime`
  - ChangeDefinitionDetail `IAny`
  - ChangeDefinitionKind `String`
  - ChangeDefinitionName `String`
  - ChangeType `String`
  - Comment `String`
  - Description `String`
  - Link `List<ILink>`
  - OrchestrationTool `String`
  - Parameter `IChangeRecordPropertiesParameters <IParameter>`
  - ProvisioningState `String`
  - ReleaseLabel `String`
  - RolloutType `String`
  - StageMapParameter `INestedStageMapParameters <Object>`
  - StageMapResourceId `String`
  - StageMapSnapshot `List<IAny>`
  - Status `String`

### ChangeRecordPropertiesUpdate [Models]
  - AdditionalData `IAny`
  - AnticipatedEndTime `DateTime?`
  - AnticipatedStartTime `DateTime?`
  - ChangeDefinitionDetail `IAny`
  - ChangeDefinitionKind `String`
  - ChangeDefinitionName `String`
  - ChangeType `String`
  - Comment `String`
  - Description `String`
  - Link `List<ILink>`
  - OrchestrationTool `String`
  - Parameter `IChangeRecordPropertiesUpdateParameters <IParameterUpdate>`
  - ReleaseLabel `String`
  - RolloutType `String`
  - StageMapParameter `INestedStageMapParameters <Object>`
  - StageMapResourceId `String`

### ChangeRecordRetrieveAuditTrailResponse [Models]
  - AuditRecord `List<IChangeRecordAuditRecord>`
  - TotalRecord `Int32?`

### ChangeRecordRetrieveNextStagesResponse [Models]
  - ChangeRecordResourceId `String`
  - LastStageProgressionSequence `Int32`
  - NextStage `List<IChangeRecordRetrieveNextStagesResponseItem>`

### ChangeRecordRetrieveNextStagesResponseItem [Models]
  - AdditionalData `IAny`
  - Comment `String`
  - Link `List<ILink>`
  - Parameter `IChangeRecordRetrieveNextStagesResponseItemParameters <IParameter>`
  - Sequence `Int32?`
  - StageReference `String`
  - StageVariable `IChangeRecordRetrieveNextStagesResponseItemStageVariables <Object>`
  - Status `String`

### ChangeRecordStageProgression [Models]
  - AdditionalData `IAny`
  - Comment `String`
  - Id `String`
  - Link `List<ILink>`
  - Name `String`
  - Parameter `IChangeRecordStageProgressionPropertiesParameters <Object>`
  - ProvisioningState `String`
  - ResourceGroupName `String`
  - Sequence `Int32?`
  - StageReference `String`
  - StageVariable `IChangeRecordStageProgressionPropertiesStageVariables <Object>`
  - Status `String`
  - SystemDataCreatedAt `DateTime?`
  - SystemDataCreatedBy `String`
  - SystemDataCreatedByType `String`
  - SystemDataLastModifiedAt `DateTime?`
  - SystemDataLastModifiedBy `String`
  - SystemDataLastModifiedByType `String`
  - Type `String`

### ChangeRecordStageProgressionListResult [Models]
  - NextLink `String`
  - Value `List<IChangeRecordStageProgression>`

### ChangeRecordStageProgressionProperties [Models]
  - AdditionalData `IAny`
  - Comment `String`
  - Link `List<ILink>`
  - Parameter `IChangeRecordStageProgressionPropertiesParameters <Object>`
  - ProvisioningState `String`
  - Sequence `Int32?`
  - StageReference `String`
  - StageVariable `IChangeRecordStageProgressionPropertiesStageVariables <Object>`
  - Status `String`

### ChangeRecordStageProgressionPropertiesUpdate [Models]
  - AdditionalData `IAny`
  - Comment `String`
  - Link `List<ILink>`
  - Parameter `IChangeRecordStageProgressionPropertiesUpdateParameters <Object>`
  - StageReference `String`
  - StageVariable `IChangeRecordStageProgressionPropertiesUpdateStageVariables <Object>`
  - Status `String`

### ChangeRecordStageProgressionUpdate [Models]
  - AdditionalData `IAny`
  - Comment `String`
  - Id `String`
  - Link `List<ILink>`
  - Name `String`
  - Parameter `IChangeRecordStageProgressionPropertiesUpdateParameters <Object>`
  - StageReference `String`
  - StageVariable `IChangeRecordStageProgressionPropertiesUpdateStageVariables <Object>`
  - Status `String`
  - SystemDataCreatedAt `DateTime?`
  - SystemDataCreatedBy `String`
  - SystemDataCreatedByType `String`
  - SystemDataLastModifiedAt `DateTime?`
  - SystemDataLastModifiedBy `String`
  - SystemDataLastModifiedByType `String`
  - Type `String`

### ChangeRecordUpdate [Models]
  - AdditionalData `IAny`
  - AnticipatedEndTime `DateTime?`
  - AnticipatedStartTime `DateTime?`
  - ChangeDefinitionDetail `IAny`
  - ChangeDefinitionKind `String`
  - ChangeDefinitionName `String`
  - ChangeType `String`
  - Comment `String`
  - Description `String`
  - Id `String`
  - Link `List<ILink>`
  - Name `String`
  - OrchestrationTool `String`
  - Parameter `IChangeRecordPropertiesUpdateParameters <IParameterUpdate>`
  - ReleaseLabel `String`
  - RolloutType `String`
  - StageMapParameter `INestedStageMapParameters <Object>`
  - StageMapResourceId `String`
  - SystemDataCreatedAt `DateTime?`
  - SystemDataCreatedBy `String`
  - SystemDataCreatedByType `String`
  - SystemDataLastModifiedAt `DateTime?`
  - SystemDataLastModifiedBy `String`
  - SystemDataLastModifiedByType `String`
  - Type `String`

### ChangeRecordVerifyChangeValidityRequest [Models]
  - BodyLocation `String`
  - BodyName `String`
  - BodyProperty `IAny`
  - ChangeSafetyReferenceId `String`
  - ContextClientId `String`
  - OperationHttpMethod `String`
  - OperationUri `String`

### ChangeRecordVerifyChangeValidityRequestContext [Models]
  - ClientId `String`

### ChangeRecordVerifyChangeValidityResponse [Models]
  - Message `String`
  - Outcome `String`
  - ValidUntil `DateTime?`

### ChangeSafetyIdentity [Models]
  - ChangeRecordName `String`
  - ChangeStateName `String`
  - Id `String`
  - ManagementGroupName `String`
  - ResourceGroupName `String`
  - StageMapName `String`
  - StageProgressionName `String`
  - SubscriptionId `String`

### ChangeState [Models]
  - AdditionalData `IAny`
  - AnticipatedEndTime `DateTime?`
  - AnticipatedStartTime `DateTime?`
  - ChangeDefinitionDetail `IAny`
  - ChangeDefinitionKind `String`
  - ChangeDefinitionName `String`
  - ChangeType `String`
  - Comment `String`
  - Description `String`
  - Id `String`
  - Link `List<ILink>`
  - Name `String`
  - OrchestrationTool `String`
  - Parameter `IChangeStatePropertiesParameters <IParameter>`
  - ProvisioningState `String`
  - ReleaseLabel `String`
  - ResourceGroupName `String`
  - RolloutType `String`
  - StageMapParameter `INestedStageMapParameters <Object>`
  - StageMapResourceId `String`
  - StageMapSnapshot `List<IAny>`
  - Status `String`
  - SystemDataCreatedAt `DateTime?`
  - SystemDataCreatedBy `String`
  - SystemDataCreatedByType `String`
  - SystemDataLastModifiedAt `DateTime?`
  - SystemDataLastModifiedBy `String`
  - SystemDataLastModifiedByType `String`
  - Type `String`

### ChangeStateListResult [Models]
  - NextLink `String`
  - Value `List<IChangeState>`

### ChangeStateProperties [Models]
  - AdditionalData `IAny`
  - AnticipatedEndTime `DateTime`
  - AnticipatedStartTime `DateTime`
  - ChangeDefinitionDetail `IAny`
  - ChangeDefinitionKind `String`
  - ChangeDefinitionName `String`
  - ChangeType `String`
  - Comment `String`
  - Description `String`
  - Link `List<ILink>`
  - OrchestrationTool `String`
  - Parameter `IChangeStatePropertiesParameters <IParameter>`
  - ProvisioningState `String`
  - ReleaseLabel `String`
  - RolloutType `String`
  - StageMapParameter `INestedStageMapParameters <Object>`
  - StageMapResourceId `String`
  - StageMapSnapshot `List<IAny>`
  - Status `String`

### ChangeStatePropertiesUpdate [Models]
  - AdditionalData `IAny`
  - AnticipatedEndTime `DateTime?`
  - AnticipatedStartTime `DateTime?`
  - ChangeDefinitionDetail `IAny`
  - ChangeDefinitionKind `String`
  - ChangeDefinitionName `String`
  - ChangeType `String`
  - Comment `String`
  - Description `String`
  - Link `List<ILink>`
  - OrchestrationTool `String`
  - Parameter `IChangeStatePropertiesUpdateParameters <IParameterUpdate>`
  - ReleaseLabel `String`
  - RolloutType `String`
  - StageMapParameter `INestedStageMapParameters <Object>`
  - StageMapResourceId `String`

### ChangeStateUpdate [Models]
  - AdditionalData `IAny`
  - AnticipatedEndTime `DateTime?`
  - AnticipatedStartTime `DateTime?`
  - ChangeDefinitionDetail `IAny`
  - ChangeDefinitionKind `String`
  - ChangeDefinitionName `String`
  - ChangeType `String`
  - Comment `String`
  - Description `String`
  - Id `String`
  - Link `List<ILink>`
  - Name `String`
  - OrchestrationTool `String`
  - Parameter `IChangeStatePropertiesUpdateParameters <IParameterUpdate>`
  - ReleaseLabel `String`
  - RolloutType `String`
  - StageMapParameter `INestedStageMapParameters <Object>`
  - StageMapResourceId `String`
  - SystemDataCreatedAt `DateTime?`
  - SystemDataCreatedBy `String`
  - SystemDataCreatedByType `String`
  - SystemDataLastModifiedAt `DateTime?`
  - SystemDataLastModifiedBy `String`
  - SystemDataLastModifiedByType `String`
  - Type `String`

### ErrorAdditionalInfo [Models]
  - Info `IAny`
  - Type `String`

### ErrorDetail [Models]
  - AdditionalInfo `List<IErrorAdditionalInfo>`
  - Code `String`
  - Detail `List<IErrorDetail>`
  - Message `String`
  - Target `String`

### ErrorResponse [Models]
  - AdditionalInfo `List<IErrorAdditionalInfo>`
  - Code `String`
  - Detail `List<IErrorDetail>`
  - Message `String`
  - Target `String`

### Link [Models]
  - Description `String`
  - Name `String`
  - Uri `String`

### NestedStageMap [Models]
  - Parameter `INestedStageMapParameters <Object>`
  - ResourceId `String`

### NumberParameter [Models]
  - AllowedValue `List<Int32>`
  - DefaultValue `Int32?`
  - Metadata `IParameterMetadata <String>`
  - Type `String`

### NumberParameterUpdate [Models]
  - AllowedValue `List<Int32>`
  - DefaultValue `Int32?`
  - Metadata `IParameterUpdateMetadata <String>`
  - Type `String`

### ObjectParameter [Models]
  - AllowedValue `List<IAny>`
  - DefaultValue `IAny`
  - Metadata `IParameterMetadata <String>`
  - Type `String`

### ObjectParameterUpdate [Models]
  - AllowedValue `List<IAny>`
  - DefaultValue `IAny`
  - Metadata `IParameterUpdateMetadata <String>`
  - Type `String`

### Operation [Models]
  - ActionType `String`
  - DisplayDescription `String`
  - DisplayOperation `String`
  - DisplayProvider `String`
  - DisplayResource `String`
  - IsDataAction `Boolean?`
  - Name `String`
  - Origin `String`

### OperationContent [Models]
  - Location `String`
  - Name `String`
  - Property `IAny`

### OperationDisplay [Models]
  - Description `String`
  - Operation `String`
  - Provider `String`
  - Resource `String`

### OperationListResult [Models]
  - NextLink `String`
  - Value `List<IOperation>`

### Parameter [Models]
  - Metadata `IParameterMetadata <String>`
  - Type `String`

### ParameterUpdate [Models]
  - Metadata `IParameterUpdateMetadata <String>`
  - Type `String`

### ProxyResource [Models]
  - Id `String`
  - Name `String`
  - SystemDataCreatedAt `DateTime?`
  - SystemDataCreatedBy `String`
  - SystemDataCreatedByType `String`
  - SystemDataLastModifiedAt `DateTime?`
  - SystemDataLastModifiedBy `String`
  - SystemDataLastModifiedByType `String`
  - Type `String`

### Resource [Models]
  - Id `String`
  - Name `String`
  - SystemDataCreatedAt `DateTime?`
  - SystemDataCreatedBy `String`
  - SystemDataCreatedByType `String`
  - SystemDataLastModifiedAt `DateTime?`
  - SystemDataLastModifiedBy `String`
  - SystemDataLastModifiedByType `String`
  - Type `String`

### RetrieveAuditTrailResponse [Models]
  - AuditRecord `List<IAuditRecord>`
  - TotalRecord `Int32?`

### RetrieveNextStagesResponse [Models]
  - ChangeStateResourceId `String`
  - LastStageProgressionSequence `Int32`
  - NextStage `List<IRetrieveNextStagesResponseItem>`

### RetrieveNextStagesResponseItem [Models]
  - AdditionalData `IAny`
  - Comment `String`
  - Link `List<ILink>`
  - Parameter `IRetrieveNextStagesResponseItemParameters <IParameter>`
  - Sequence `Int32?`
  - StageReference `String`
  - StageVariable `IRetrieveNextStagesResponseItemStageVariables <Object>`
  - Status `String`

### Stage [Models]
  - Name `String`
  - NestedStageMapParameter `INestedStageMapParameters <Object>`
  - NestedStageMapResourceId `String`
  - Sequence `Int32`
  - Variable `IStageVariables <Object>`

### StageMap [Models]
  - Id `String`
  - Name `String`
  - Parameter `IStageMapPropertiesParameters <IParameter>`
  - ProvisioningState `String`
  - ResourceGroupName `String`
  - Stage `List<IStage>`
  - SystemDataCreatedAt `DateTime?`
  - SystemDataCreatedBy `String`
  - SystemDataCreatedByType `String`
  - SystemDataLastModifiedAt `DateTime?`
  - SystemDataLastModifiedBy `String`
  - SystemDataLastModifiedByType `String`
  - Type `String`

### StageMapListResult [Models]
  - NextLink `String`
  - Value `List<IStageMap>`

### StageMapProperties [Models]
  - Parameter `IStageMapPropertiesParameters <IParameter>`
  - ProvisioningState `String`
  - Stage `List<IStage>`

### StageMapPropertiesUpdate [Models]
  - Parameter `IStageMapPropertiesUpdateParameters <IParameterUpdate>`
  - Stage `List<IStage>`

### StageMapUpdate [Models]
  - Id `String`
  - Name `String`
  - Parameter `IStageMapPropertiesUpdateParameters <IParameterUpdate>`
  - Stage `List<IStage>`
  - SystemDataCreatedAt `DateTime?`
  - SystemDataCreatedBy `String`
  - SystemDataCreatedByType `String`
  - SystemDataLastModifiedAt `DateTime?`
  - SystemDataLastModifiedBy `String`
  - SystemDataLastModifiedByType `String`
  - Type `String`

### StageProgression [Models]
  - AdditionalData `IAny`
  - Comment `String`
  - Id `String`
  - Link `List<ILink>`
  - Name `String`
  - Parameter `IStageProgressionPropertiesParameters <Object>`
  - ProvisioningState `String`
  - ResourceGroupName `String`
  - Sequence `Int32?`
  - StageReference `String`
  - StageVariable `IStageProgressionPropertiesStageVariables <Object>`
  - Status `String`
  - SystemDataCreatedAt `DateTime?`
  - SystemDataCreatedBy `String`
  - SystemDataCreatedByType `String`
  - SystemDataLastModifiedAt `DateTime?`
  - SystemDataLastModifiedBy `String`
  - SystemDataLastModifiedByType `String`
  - Type `String`

### StageProgressionListResult [Models]
  - NextLink `String`
  - Value `List<IStageProgression>`

### StageProgressionProperties [Models]
  - AdditionalData `IAny`
  - Comment `String`
  - Link `List<ILink>`
  - Parameter `IStageProgressionPropertiesParameters <Object>`
  - ProvisioningState `String`
  - Sequence `Int32?`
  - StageReference `String`
  - StageVariable `IStageProgressionPropertiesStageVariables <Object>`
  - Status `String`

### StageProgressionPropertiesUpdate [Models]
  - AdditionalData `IAny`
  - Comment `String`
  - Link `List<ILink>`
  - Parameter `IStageProgressionPropertiesUpdateParameters <Object>`
  - StageReference `String`
  - StageVariable `IStageProgressionPropertiesUpdateStageVariables <Object>`
  - Status `String`

### StageProgressionUpdate [Models]
  - AdditionalData `IAny`
  - Comment `String`
  - Id `String`
  - Link `List<ILink>`
  - Name `String`
  - Parameter `IStageProgressionPropertiesUpdateParameters <Object>`
  - StageReference `String`
  - StageVariable `IStageProgressionPropertiesUpdateStageVariables <Object>`
  - Status `String`
  - SystemDataCreatedAt `DateTime?`
  - SystemDataCreatedBy `String`
  - SystemDataCreatedByType `String`
  - SystemDataLastModifiedAt `DateTime?`
  - SystemDataLastModifiedBy `String`
  - SystemDataLastModifiedByType `String`
  - Type `String`

### StringParameter [Models]
  - AllowedValue `List<String>`
  - DefaultValue `String`
  - Metadata `IParameterMetadata <String>`
  - Type `String`

### StringParameterUpdate [Models]
  - AllowedValue `List<String>`
  - DefaultValue `String`
  - Metadata `IParameterUpdateMetadata <String>`
  - Type `String`

### SystemData [Models]
  - CreatedAt `DateTime?`
  - CreatedBy `String`
  - CreatedByType `String`
  - LastModifiedAt `DateTime?`
  - LastModifiedBy `String`
  - LastModifiedByType `String`

### VerifyChangeValidityRequest [Models]
  - BodyLocation `String`
  - BodyName `String`
  - BodyProperty `IAny`
  - ChangeSafetyReferenceId `String`
  - ContextClientId `String`
  - OperationHttpMethod `String`
  - OperationUri `String`

### VerifyChangeValidityRequestContext [Models]
  - ClientId `String`

### VerifyChangeValidityResponse [Models]
  - Message `String`
  - Outcome `String`
  - ValidUntil `DateTime?`

