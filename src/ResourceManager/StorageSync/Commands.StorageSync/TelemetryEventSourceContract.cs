using Microsoft.Diagnostics.Telemetry;
using Microsoft.Diagnostics.Tracing;

namespace AFSEvaluationTool
{
    [EventSource(Name = "AFSTelemetryEventSourceContractProvider")]
    sealed class TelemetryEventSourceContract : TelemetryEventSource
    {
        // The function name becomes the event name. 
        public TelemetryEventSourceContract() : base("AFSTelemetryEventSourceContractProvider") { }

        [Event(1)]
        public void AppRan(string aRandomString) { WriteEvent(1, aRandomString); }
    }
}
