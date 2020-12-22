using Microsoft.Build.Framework;

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace Microsoft.WindowsAzure.Build.Tasks
{
    public class CIFilterTaskResult : ITaskItem
    {
        readonly string _spec = "CIFilterTaskResult";
        public Dictionary<string, HashSet<string>> PhaseInfo = new Dictionary<string, HashSet<string>>();

        public string ItemSpec
        {
            get { return _spec; }
            set { }
        }

        public ICollection MetadataNames
        {
            get
            {
                return PhaseInfo.Keys;
            }
        }
        public int MetadataCount
        {
            get { return PhaseInfo.Keys.Count; }
        }

        public IDictionary CloneCustomMetadata()
        {
            Dictionary<string, string> Result = new Dictionary<string, string>();

            foreach (string key in PhaseInfo.Keys)
            {
                Result[key] = string.Join(";", PhaseInfo[key].ToList());
            }

            return Result;
        }

        public void CopyMetadataTo(ITaskItem destinationItem)
        {
        }

        public string GetMetadata(string metadataName)
        {
            return string.Format("[{0}]", string.Join(", ", PhaseInfo[metadataName].ToList()));
        }

        public void RemoveMetadata(string metadataName)
        {
        }

        public void SetMetadata(string metadataName, string metadataValue)
        {
        }
    }
}
