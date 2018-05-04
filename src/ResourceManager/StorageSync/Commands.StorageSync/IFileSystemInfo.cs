using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AFSEvaluationTool
{
    public interface IFileSystemInfo
    {
        string Name { get; }

        string FullName { get; }
    }
}
