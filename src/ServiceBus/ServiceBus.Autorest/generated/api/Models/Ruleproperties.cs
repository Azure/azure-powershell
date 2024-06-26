// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

namespace Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Runtime.Extensions;

    /// <summary>Description of Rule Resource.</summary>
    [Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.DoNotFormat]
    public partial class Ruleproperties :
        Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Models.IRuleproperties,
        Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Models.IRulepropertiesInternal
    {

        /// <summary>Backing field for <see cref="Action" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Models.IAction _action;

        /// <summary>
        /// Represents the filter actions which are allowed for the transformation of a message that have been matched by a filter
        /// expression.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Origin(Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Models.IAction Action { get => (this._action = this._action ?? new Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Models.Action()); set => this._action = value; }

        /// <summary>
        /// This property is reserved for future use. An integer value showing the compatibility level, currently hard-coded to 20.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Origin(Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.PropertyOrigin.Inlined)]
        public int? ActionCompatibilityLevel { get => ((Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Models.IActionInternal)Action).CompatibilityLevel; set => ((Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Models.IActionInternal)Action).CompatibilityLevel = value ?? default(int); }

        /// <summary>Value that indicates whether the rule action requires preprocessing.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Origin(Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.PropertyOrigin.Inlined)]
        public bool? ActionRequiresPreprocessing { get => ((Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Models.IActionInternal)Action).RequiresPreprocessing; set => ((Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Models.IActionInternal)Action).RequiresPreprocessing = value ?? default(bool); }

        /// <summary>SQL expression. e.g. MyProperty='ABC'</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Origin(Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.PropertyOrigin.Inlined)]
        public string ActionSqlExpression { get => ((Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Models.IActionInternal)Action).SqlExpression; set => ((Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Models.IActionInternal)Action).SqlExpression = value ?? null; }

        /// <summary>Backing field for <see cref="CorrelationFilter" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Models.ICorrelationFilter _correlationFilter;

        /// <summary>Properties of correlationFilter</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Origin(Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Models.ICorrelationFilter CorrelationFilter { get => (this._correlationFilter = this._correlationFilter ?? new Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Models.CorrelationFilter()); set => this._correlationFilter = value; }

        /// <summary>Content type of the message.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Origin(Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.PropertyOrigin.Inlined)]
        public string CorrelationFilterContentType { get => ((Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Models.ICorrelationFilterInternal)CorrelationFilter).ContentType; set => ((Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Models.ICorrelationFilterInternal)CorrelationFilter).ContentType = value ?? null; }

        /// <summary>Identifier of the correlation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Origin(Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.PropertyOrigin.Inlined)]
        public string CorrelationFilterCorrelationId { get => ((Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Models.ICorrelationFilterInternal)CorrelationFilter).CorrelationId; set => ((Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Models.ICorrelationFilterInternal)CorrelationFilter).CorrelationId = value ?? null; }

        /// <summary>Application specific label.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Origin(Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.PropertyOrigin.Inlined)]
        public string CorrelationFilterLabel { get => ((Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Models.ICorrelationFilterInternal)CorrelationFilter).Label; set => ((Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Models.ICorrelationFilterInternal)CorrelationFilter).Label = value ?? null; }

        /// <summary>Identifier of the message.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Origin(Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.PropertyOrigin.Inlined)]
        public string CorrelationFilterMessageId { get => ((Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Models.ICorrelationFilterInternal)CorrelationFilter).MessageId; set => ((Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Models.ICorrelationFilterInternal)CorrelationFilter).MessageId = value ?? null; }

        /// <summary>dictionary object for custom filters</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Origin(Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Models.ICorrelationFilterProperties CorrelationFilterProperty { get => ((Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Models.ICorrelationFilterInternal)CorrelationFilter).Property; set => ((Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Models.ICorrelationFilterInternal)CorrelationFilter).Property = value ?? null /* model class */; }

        /// <summary>Address of the queue to reply to.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Origin(Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.PropertyOrigin.Inlined)]
        public string CorrelationFilterReplyTo { get => ((Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Models.ICorrelationFilterInternal)CorrelationFilter).ReplyTo; set => ((Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Models.ICorrelationFilterInternal)CorrelationFilter).ReplyTo = value ?? null; }

        /// <summary>Session identifier to reply to.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Origin(Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.PropertyOrigin.Inlined)]
        public string CorrelationFilterReplyToSessionId { get => ((Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Models.ICorrelationFilterInternal)CorrelationFilter).ReplyToSessionId; set => ((Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Models.ICorrelationFilterInternal)CorrelationFilter).ReplyToSessionId = value ?? null; }

        /// <summary>Value that indicates whether the rule action requires preprocessing.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Origin(Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.PropertyOrigin.Inlined)]
        public bool? CorrelationFilterRequiresPreprocessing { get => ((Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Models.ICorrelationFilterInternal)CorrelationFilter).RequiresPreprocessing; set => ((Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Models.ICorrelationFilterInternal)CorrelationFilter).RequiresPreprocessing = value ?? default(bool); }

        /// <summary>Session identifier.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Origin(Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.PropertyOrigin.Inlined)]
        public string CorrelationFilterSessionId { get => ((Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Models.ICorrelationFilterInternal)CorrelationFilter).SessionId; set => ((Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Models.ICorrelationFilterInternal)CorrelationFilter).SessionId = value ?? null; }

        /// <summary>Address to send to.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Origin(Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.PropertyOrigin.Inlined)]
        public string CorrelationFilterTo { get => ((Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Models.ICorrelationFilterInternal)CorrelationFilter).To; set => ((Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Models.ICorrelationFilterInternal)CorrelationFilter).To = value ?? null; }

        /// <summary>Backing field for <see cref="FilterType" /> property.</summary>
        private string _filterType;

        /// <summary>Filter type that is evaluated against a BrokeredMessage.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Origin(Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.PropertyOrigin.Owned)]
        public string FilterType { get => this._filterType; set => this._filterType = value; }

        /// <summary>Internal Acessors for Action</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Models.IAction Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Models.IRulepropertiesInternal.Action { get => (this._action = this._action ?? new Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Models.Action()); set { {_action = value;} } }

        /// <summary>Internal Acessors for CorrelationFilter</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Models.ICorrelationFilter Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Models.IRulepropertiesInternal.CorrelationFilter { get => (this._correlationFilter = this._correlationFilter ?? new Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Models.CorrelationFilter()); set { {_correlationFilter = value;} } }

        /// <summary>Internal Acessors for SqlFilter</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Models.ISqlFilter Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Models.IRulepropertiesInternal.SqlFilter { get => (this._sqlFilter = this._sqlFilter ?? new Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Models.SqlFilter()); set { {_sqlFilter = value;} } }

        /// <summary>Backing field for <see cref="SqlFilter" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Models.ISqlFilter _sqlFilter;

        /// <summary>Properties of sqlFilter</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Origin(Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Models.ISqlFilter SqlFilter { get => (this._sqlFilter = this._sqlFilter ?? new Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Models.SqlFilter()); set => this._sqlFilter = value; }

        /// <summary>
        /// This property is reserved for future use. An integer value showing the compatibility level, currently hard-coded to 20.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Origin(Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.PropertyOrigin.Inlined)]
        public int? SqlFilterCompatibilityLevel { get => ((Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Models.ISqlFilterInternal)SqlFilter).CompatibilityLevel; set => ((Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Models.ISqlFilterInternal)SqlFilter).CompatibilityLevel = value ?? default(int); }

        /// <summary>Value that indicates whether the rule action requires preprocessing.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Origin(Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.PropertyOrigin.Inlined)]
        public bool? SqlFilterRequiresPreprocessing { get => ((Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Models.ISqlFilterInternal)SqlFilter).RequiresPreprocessing; set => ((Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Models.ISqlFilterInternal)SqlFilter).RequiresPreprocessing = value ?? default(bool); }

        /// <summary>The SQL expression. e.g. MyProperty='ABC'</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Origin(Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.PropertyOrigin.Inlined)]
        public string SqlFilterSqlExpression { get => ((Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Models.ISqlFilterInternal)SqlFilter).SqlExpression; set => ((Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Models.ISqlFilterInternal)SqlFilter).SqlExpression = value ?? null; }

        /// <summary>Creates an new <see cref="Ruleproperties" /> instance.</summary>
        public Ruleproperties()
        {

        }
    }
    /// Description of Rule Resource.
    public partial interface IRuleproperties :
        Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Runtime.IJsonSerializable
    {
        /// <summary>
        /// This property is reserved for future use. An integer value showing the compatibility level, currently hard-coded to 20.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"This property is reserved for future use. An integer value showing the compatibility level, currently hard-coded to 20.",
        SerializedName = @"compatibilityLevel",
        PossibleTypes = new [] { typeof(int) })]
        int? ActionCompatibilityLevel { get; set; }
        /// <summary>Value that indicates whether the rule action requires preprocessing.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Value that indicates whether the rule action requires preprocessing.",
        SerializedName = @"requiresPreprocessing",
        PossibleTypes = new [] { typeof(bool) })]
        bool? ActionRequiresPreprocessing { get; set; }
        /// <summary>SQL expression. e.g. MyProperty='ABC'</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"SQL expression. e.g. MyProperty='ABC'",
        SerializedName = @"sqlExpression",
        PossibleTypes = new [] { typeof(string) })]
        string ActionSqlExpression { get; set; }
        /// <summary>Content type of the message.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Content type of the message.",
        SerializedName = @"contentType",
        PossibleTypes = new [] { typeof(string) })]
        string CorrelationFilterContentType { get; set; }
        /// <summary>Identifier of the correlation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Identifier of the correlation.",
        SerializedName = @"correlationId",
        PossibleTypes = new [] { typeof(string) })]
        string CorrelationFilterCorrelationId { get; set; }
        /// <summary>Application specific label.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Application specific label.",
        SerializedName = @"label",
        PossibleTypes = new [] { typeof(string) })]
        string CorrelationFilterLabel { get; set; }
        /// <summary>Identifier of the message.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Identifier of the message.",
        SerializedName = @"messageId",
        PossibleTypes = new [] { typeof(string) })]
        string CorrelationFilterMessageId { get; set; }
        /// <summary>dictionary object for custom filters</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"dictionary object for custom filters",
        SerializedName = @"properties",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Models.ICorrelationFilterProperties) })]
        Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Models.ICorrelationFilterProperties CorrelationFilterProperty { get; set; }
        /// <summary>Address of the queue to reply to.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Address of the queue to reply to.",
        SerializedName = @"replyTo",
        PossibleTypes = new [] { typeof(string) })]
        string CorrelationFilterReplyTo { get; set; }
        /// <summary>Session identifier to reply to.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Session identifier to reply to.",
        SerializedName = @"replyToSessionId",
        PossibleTypes = new [] { typeof(string) })]
        string CorrelationFilterReplyToSessionId { get; set; }
        /// <summary>Value that indicates whether the rule action requires preprocessing.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Value that indicates whether the rule action requires preprocessing.",
        SerializedName = @"requiresPreprocessing",
        PossibleTypes = new [] { typeof(bool) })]
        bool? CorrelationFilterRequiresPreprocessing { get; set; }
        /// <summary>Session identifier.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Session identifier.",
        SerializedName = @"sessionId",
        PossibleTypes = new [] { typeof(string) })]
        string CorrelationFilterSessionId { get; set; }
        /// <summary>Address to send to.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Address to send to.",
        SerializedName = @"to",
        PossibleTypes = new [] { typeof(string) })]
        string CorrelationFilterTo { get; set; }
        /// <summary>Filter type that is evaluated against a BrokeredMessage.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Filter type that is evaluated against a BrokeredMessage.",
        SerializedName = @"filterType",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.PSArgumentCompleterAttribute("SqlFilter", "CorrelationFilter")]
        string FilterType { get; set; }
        /// <summary>
        /// This property is reserved for future use. An integer value showing the compatibility level, currently hard-coded to 20.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"This property is reserved for future use. An integer value showing the compatibility level, currently hard-coded to 20.",
        SerializedName = @"compatibilityLevel",
        PossibleTypes = new [] { typeof(int) })]
        int? SqlFilterCompatibilityLevel { get; set; }
        /// <summary>Value that indicates whether the rule action requires preprocessing.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Value that indicates whether the rule action requires preprocessing.",
        SerializedName = @"requiresPreprocessing",
        PossibleTypes = new [] { typeof(bool) })]
        bool? SqlFilterRequiresPreprocessing { get; set; }
        /// <summary>The SQL expression. e.g. MyProperty='ABC'</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The SQL expression. e.g. MyProperty='ABC'",
        SerializedName = @"sqlExpression",
        PossibleTypes = new [] { typeof(string) })]
        string SqlFilterSqlExpression { get; set; }

    }
    /// Description of Rule Resource.
    internal partial interface IRulepropertiesInternal

    {
        /// <summary>
        /// Represents the filter actions which are allowed for the transformation of a message that have been matched by a filter
        /// expression.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Models.IAction Action { get; set; }
        /// <summary>
        /// This property is reserved for future use. An integer value showing the compatibility level, currently hard-coded to 20.
        /// </summary>
        int? ActionCompatibilityLevel { get; set; }
        /// <summary>Value that indicates whether the rule action requires preprocessing.</summary>
        bool? ActionRequiresPreprocessing { get; set; }
        /// <summary>SQL expression. e.g. MyProperty='ABC'</summary>
        string ActionSqlExpression { get; set; }
        /// <summary>Properties of correlationFilter</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Models.ICorrelationFilter CorrelationFilter { get; set; }
        /// <summary>Content type of the message.</summary>
        string CorrelationFilterContentType { get; set; }
        /// <summary>Identifier of the correlation.</summary>
        string CorrelationFilterCorrelationId { get; set; }
        /// <summary>Application specific label.</summary>
        string CorrelationFilterLabel { get; set; }
        /// <summary>Identifier of the message.</summary>
        string CorrelationFilterMessageId { get; set; }
        /// <summary>dictionary object for custom filters</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Models.ICorrelationFilterProperties CorrelationFilterProperty { get; set; }
        /// <summary>Address of the queue to reply to.</summary>
        string CorrelationFilterReplyTo { get; set; }
        /// <summary>Session identifier to reply to.</summary>
        string CorrelationFilterReplyToSessionId { get; set; }
        /// <summary>Value that indicates whether the rule action requires preprocessing.</summary>
        bool? CorrelationFilterRequiresPreprocessing { get; set; }
        /// <summary>Session identifier.</summary>
        string CorrelationFilterSessionId { get; set; }
        /// <summary>Address to send to.</summary>
        string CorrelationFilterTo { get; set; }
        /// <summary>Filter type that is evaluated against a BrokeredMessage.</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.PSArgumentCompleterAttribute("SqlFilter", "CorrelationFilter")]
        string FilterType { get; set; }
        /// <summary>Properties of sqlFilter</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Models.ISqlFilter SqlFilter { get; set; }
        /// <summary>
        /// This property is reserved for future use. An integer value showing the compatibility level, currently hard-coded to 20.
        /// </summary>
        int? SqlFilterCompatibilityLevel { get; set; }
        /// <summary>Value that indicates whether the rule action requires preprocessing.</summary>
        bool? SqlFilterRequiresPreprocessing { get; set; }
        /// <summary>The SQL expression. e.g. MyProperty='ABC'</summary>
        string SqlFilterSqlExpression { get; set; }

    }
}