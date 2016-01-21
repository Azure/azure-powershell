using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FormatParser
{
    public class ValidationRecord
    {
        public string Assembly { get; set; }
        public string Target { get; set; }
        public int Severity { get; set; }
        public string Description { get; set; }
        public string Remediation { get; set; }

        public override string ToString()
        {
            return $"\"{Assembly}\",\"{Target}\",\"{Severity}\",\"{Description}\",\"{Remediation}\"";
        }

        public string PrintHeaders()
        {
            return $"{nameof(Assembly)},{nameof(Target)},{nameof(Severity)},{nameof(Description)},{nameof(Remediation)}";
        }
    }
}
