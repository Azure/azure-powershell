using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;

namespace Microsoft.Azure.Commands.Sql.DataClassification.Services
{
    public class DataClassificationAdapter
    {
        private readonly IAzureContext context;

        public DataClassificationAdapter(IAzureContext context)
        {
            this.context = context;
        }
    }
}
