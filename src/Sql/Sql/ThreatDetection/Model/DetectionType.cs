using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.Sql.ThreatDetection.Model
{
    /// <summary>
    /// The possible disable alert types
    /// </summary> 
    public static class DetectionType
    {
        public const string Sql_Injection = "Sql_Injection";
        public const string Sql_Injection_Vulnerability = "Sql_Injection_Vulnerability";
        public const string Access_Anomaly = "Access_Anomaly";
        public const string Data_Exfiltration = "Data_Exfiltration";
        public const string Unsafe_Action = "Unsafe_Action";
        public const string None = "None";
    }
}
