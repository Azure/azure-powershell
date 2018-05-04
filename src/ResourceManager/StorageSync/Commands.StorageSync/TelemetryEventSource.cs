using Microsoft.Diagnostics.Tracing;
  
namespace Microsoft.Diagnostics.Telemetry
{
    /// <summary>
    /// <para>
    /// An Asimov-compatible EventSource. This inherits from EventSource, and
    /// is exactly the same as EventSource except that it forces Asimov-compatible
    /// construction (it always enables the EtwSelfDescribingEventFormat and
    /// Telemetry options). It also provides several Asimov-specific constants and
    /// helpers.
    /// </para>
    /// <para>
    /// Note that this class DOES NOT automatically add any keywords to your events.
    /// Even when using this class, events will be ignored by UTC unless they include
    /// one of the telemetry keywords. Each event that you want to send to UTC must
    /// have one (and only one) of the following keywords set in
    /// eventSourceOptions.Keywords: TelemetryKeyword, MeasuresKeyword, or
    /// CriticalDataKeyword. Use the TelemetryOptions(), MeasuresOptions(), or
    /// CriticalDataOptions() methods to efficiently create an eventSourceOptions
    /// object with the corresponding keyword set.
    /// </para>
    /// <para>
    /// When including this class in your project, you may define the following
    /// conditional-compilation symbols to adjust the default behaviors:
    /// </para>
    /// <para>
    /// TELEMETRYEVENTSOURCE_USE_NUGET - use Microsoft.Diagnostics.Tracing instead
    /// of System.Diagnostics.Tracing.
    /// </para>
    /// <para>
    /// TELEMETRYEVENTSOURCE_PUBLIC - define TelemetryEventSource as public instead
    /// of internal.
    /// </para>
    /// </summary>

    public abstract class TelemetryEventSource
        : EventSource
    {
        /// <summary>
        /// Add TelemetryKeyword to eventSourceOptions.Keywords to indicate that
        /// an event is for general-purpose telemetry.
        /// This keyword should not be combined with MeasuresKeyword or CriticalDataKeyword.
        /// </summary>
        public const EventKeywords TelemetryKeyword = (EventKeywords)0x0000200000000000;

        /// <summary>
        /// Add MeasuresKeyword to eventSourceOptions.Keywords to indicate that
        /// an event is for understanding measures and reporting scenarios.
        /// This keyword should not be combined with TelemetryKeyword or CriticalDataKeyword.
        /// </summary>
        public const EventKeywords MeasuresKeyword = (EventKeywords)0x0000400000000000;

        /// <summary>
        /// Add CriticalDataKeyword to eventSourceOptions.Keywords to indicate that
        /// an event powers user experiences or is critical to business intelligence.
        /// This keyword should not be combined with TelemetryKeyword or MeasuresKeyword.
        /// </summary>
        public const EventKeywords CriticalDataKeyword = (EventKeywords)0x0000800000000000;



        /// <summary>
        /// Add RealtimeLatency to eventSourceOptions.Tags to indicate that an event
        /// should be transmitted in real time (via any available connection).
        /// </summary>
        public const EventTags RealtimeLatency = (EventTags)0x0200000;

        /// <summary>
        /// Add NormalLatency to eventSourceOptions.Tags to indicate that an event
        /// should be transmitted via the preferred connection based on device policy.
        /// </summary>
        public const EventTags NormalLatency = (EventTags)0x0400000;

        /// <summary>
        /// Add CriticalPersistence to eventSourceOptions.Tags to indicate that an event
        /// should be deleted last when low on spool space.
        /// </summary>
        public const EventTags CriticalPersistence = (EventTags)0x0800000;

        /// <summary>
        /// Add NormalPersistence to eventSourceOptions.Tags to indicate that an event
        /// should be deleted first when low on spool space.
        /// </summary>
        public const EventTags NormalPersistence = (EventTags)0x1000000;

        /// <summary>
        /// Add DropPii to eventFieldAttribute.Tags to indicate that a field
        /// contains PII and should be dropped by the telemetry client;
        /// the event's Part A will be redacted and marked as having contained PII.
        /// </summary>
        public const EventFieldTags DropPii = (EventFieldTags)0x02000000;

        /// <summary>
        /// Add HashPii to eventFieldAttribute.Tags to indicate that a field
        /// contains PII and should be hashed (obfuscated) prior to uploading;
        /// the event's Part A will be redacted and marked as having contained PII.
        /// </summary>
        public const EventFieldTags HashPii = (EventFieldTags)0x04000000;

        /// <summary>
        /// Add MarkPii to eventFieldAttribute.Tags to indicate that a field
        /// contains PII and may be uploaded as-is;
        /// the event's Part A will be redacted and marked as containing PII in Part B/C.
        /// </summary>
        public const EventFieldTags MarkPii = (EventFieldTags)0x08000000;


        // private static readonly string[] telemetryTraits = { "ETW_GROUP", "{2a99de56-f4fe-41e5-a236-5b91226902e2}" };
        private static readonly string[] telemetryTraits = { "ETW_GROUP", "{4f50731a-89cf-4782-b3e0-dce8c90476ba}" };
            
        /// <summary>
        /// Constructs a new instance of the TelemetryEventSource class with the specified
        /// name. Sets the EtwSelfDescribingEventFormat and Telemetry options.
        /// </summary>
        /// <param name="eventSourceName">The name of the event source.</param>
        public TelemetryEventSource(
            string eventSourceName)
            : base(
            eventSourceName,
            EventSourceSettings.EtwSelfDescribingEventFormat
)
        {
            return;
        }

        /// <summary>
        /// For use by derived classes that set the eventSourceName via EventSourceAttribute.
        /// Sets the EtwSelfDescribingEventFormat and Telemetry options.
        /// </summary>
        protected TelemetryEventSource()
            : base(
            EventSourceSettings.EtwSelfDescribingEventFormat
            )
        {
            return;
        }

        /// <summary>
        /// Returns an instance of EventSourceOptions with the level set to verbose.
        /// </summary>
        /// <returns>Returns an instance of EventSourceOptions with the level set to verbose.</returns>
        public static EventSourceOptions DebugVerboseOptions()
        {
            return new EventSourceOptions { Level = EventLevel.Verbose };
        }

        /// <summary>
        /// Returns an instance of EventSourceOptions with the TelemetryKeyword set.
        /// </summary>
        /// <returns>Returns an instance of EventSourceOptions with the TelemetryKeyword set.</returns>
        public static EventSourceOptions TelemetryOptions()
        {
            return new EventSourceOptions { Keywords = TelemetryKeyword };
        }

        /// <summary>
        /// Returns an instance of EventSourceOptions with the MeasuresKeyword set
        /// and level set to error.
        /// </summary>
        /// <returns>Returns an instance of EventSourceOptions with the MeasuresKeyword set and level set to error.</returns>
        public static EventSourceOptions MeasuresErrorOptions()
        {
            return new EventSourceOptions { Level = EventLevel.Error, Keywords = MeasuresKeyword };
        }

        /// <summary>
        /// Returns an instance of EventSourceOptions with the MeasuresKeyword set
        /// and opcode set to start.
        /// </summary>
        /// <returns>Returns an instance of EventSourceOptions with the MeasuresKeyword set and opcode set to start.</returns>
        public static EventSourceOptions MeasuresStartOptions()
        {
            return new EventSourceOptions { Opcode = EventOpcode.Start, Keywords = MeasuresKeyword };
        }

        /// <summary>
        /// Returns an instance of EventSourceOptions with the MeasuresKeyword set
        /// and opcode set to stop.
        /// </summary>
        /// <returns>Returns an instance of EventSourceOptions with the MeasuresKeyword set and opcode set to stop.</returns>
        public static EventSourceOptions MeasuresStopOptions()
        {
            return new EventSourceOptions { Opcode = EventOpcode.Stop, Keywords = MeasuresKeyword };
        }

        /// <summary>
        /// Returns an instance of EventSourceOptions with the MeasuresKeyword set.
        /// </summary>
        /// <returns>Returns an instance of EventSourceOptions with the MeasuresKeyword set.</returns>
        public static EventSourceOptions MeasuresOptions()
        {
            return new EventSourceOptions { Keywords = MeasuresKeyword };
        }

        /// <summary>
        /// Returns an instance of EventSourceOptions with the CriticalDataKeyword set.
        /// </summary>
        /// <returns>Returns an instance of EventSourceOptions with the CriticalDataKeyword set.</returns>
        public static EventSourceOptions CriticalDataOptions()
        {
            return new EventSourceOptions { Keywords = CriticalDataKeyword };
        }

        /// <summary>
        /// Returns an instance of EventSourceOptions with the TelemetryKeyword set.
        /// </summary>
        /// <param name="tags">Event tags to set on the returned EventSourceOptions object.</param>
        /// <returns>Returns an instance of EventSourceOptions with the TelemetryKeyword set.</returns>
        public static EventSourceOptions TelemetryOptions(EventTags tags)
        {
            return new EventSourceOptions { Keywords = TelemetryKeyword, Tags = tags };
        }

        /// <summary>
        /// Returns an instance of EventSourceOptions with the MeasuresKeyword set.
        /// </summary>
        /// <param name="tags">Event tags to set on the returned EventSourceOptions object.</param>
        /// <returns>Returns an instance of EventSourceOptions with the MeasuresKeyword set.</returns>
        public static EventSourceOptions MeasuresOptions(EventTags tags)
        {
            return new EventSourceOptions { Keywords = MeasuresKeyword, Tags = tags };
        }

        /// <summary>
        /// Returns an instance of EventSourceOptions with the CriticalDataKeyword set.
        /// </summary>
        /// <param name="tags">Event tags to set on the returned EventSourceOptions object.</param>
        /// <returns>Returns an instance of EventSourceOptions with the CriticalDataKeyword set.</returns>
        public static EventSourceOptions CriticalDataOptions(EventTags tags)
        {
            return new EventSourceOptions { Keywords = CriticalDataKeyword, Tags = tags };
        }

    }
}
