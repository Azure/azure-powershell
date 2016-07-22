using Microsoft.Azure.Commands.OperationalInsights.Properties;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.OperationalInsights.Models
{

    public class PSWindowsEventDataSourceProperties : PSDataSourcePropertiesBase
    {
        [JsonIgnore]
        public override string Kind { get { return PSDataSourceKinds.WindowsEvent; } }

        [JsonProperty(PropertyName= "eventLogName")]
        public string EventLogName { get; set; }

        [JsonProperty(PropertyName = "eventTypes")]
        public List<WindowsEventTypeSubscription> EventTypes { get; set; }
    }

    /// <summary>
    /// The windows event type arm.
    /// </summary>
    public class WindowsEventTypeSubscription
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the event type.
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public WindowsEventType eventType { get; set; }

        #endregion
    }

    /// <summary>
    /// The event type.
    /// </summary>
    public enum WindowsEventType
    {
        /// <summary>
        /// The error.
        /// </summary>
        Error,

        /// <summary>
        /// The warning.
        /// </summary>
        Warning,

        /// <summary>
        /// The information.
        /// </summary>
        Information
    }
}
