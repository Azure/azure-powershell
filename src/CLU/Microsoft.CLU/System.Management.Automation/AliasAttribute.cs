using System.Collections.Generic;
using System.Linq;

namespace System.Management.Automation
{
    public sealed class AliasAttribute : ParsingBaseAttribute
    {
        public AliasAttribute(params string[] aliasNames)
        {
            AliasNames = aliasNames.ToList();
        }

        public IList<string> AliasNames { get; private set; }
    }
}
