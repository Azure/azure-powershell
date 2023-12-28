using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VersionController.Netcore.Models
{
    public enum ChangeType
    {
        CmdletAdd,
        CmdletRemove,
        CmdletSupportsShouldProcessChange,
        CmdletSupportsPagingChange,
        AliasAdd,
        AliasRemove,
        ParameterAdd,
        ParameterRemove,
        ParameterAliasAdd,
        ParameterAliasRemove,
        ParameterTypeChange,
        ParameterAttributeChange,
        ParameterSetAdd,
        ParameterSetRemove,
        ParameterSetAttributePropertyChange,
        OutputTypeChange
    }
    public class CmdletDiffInformation
    {
        public string ModuleName { get; set; }
        public string CmdletName { get; set; }
        public ChangeType Type { get; set; }
        public string ParameterSetName { get; set; }
        public string ParameterName { get; set; }
        public List<string> Before { get; set; }
        public List<string> After { get; set; }
        public string PropertyName { get; set; }
    }
}