using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace StaticAnalysis
{
    public interface IReportRecord
    {
        string Description { get; set; }
        string Remediation { get; set; }
        int Severity { get; set; }
        string PrintHeaders();
        string FormatRecord();
    }
}
