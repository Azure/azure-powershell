using System.Collections.Generic;

namespace System.Management.Automation
{
    public class InvocationInfo
    {
        internal InvocationInfo()
        {
            BoundParameters = new Dictionary<string, object>();
        }

        public Dictionary<string, object> BoundParameters { get; internal set; }
        public CommandOrigin CommandOrigin { get; internal set; }
        public bool ExpectingInput { get; internal set; }
        public long HistoryId { get; internal set; }
        public string InvocationName { get; internal set; }
        public string Line { get; internal set; }
        public CommandInfo MyCommand { get; internal set; }
        public int OffsetInLine { get; internal set; }
        public int PipelineLength { get; internal set; }
        public int PipelinePosition { get; internal set; }
        public string PositionMessage { get; internal set; }
        public int ScriptLineNumber { get; internal set; }
        public string ScriptName { get; internal set; }
        public List<object> UnboundArguments { get; internal set; }
    }
}
