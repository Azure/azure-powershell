using Microsoft.Azure.Management.DataFactory.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections;

namespace Microsoft.Azure.Commands.DataFactoryV2.Models
{
    public class ConfigurePSDataFactoryParameters : DataFactoryParametersBase
    {
        public string FactoryResourceId { get; set; }
        public string LocationId { get; set; }
        public FactoryRepoConfiguration Repo { get; set; }
    }
}
