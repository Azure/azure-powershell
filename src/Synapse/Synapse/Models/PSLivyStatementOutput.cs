using Microsoft.Azure.Synapse.Models;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.Synapse.Models
{
    public class PSLivyStatementOutput
    {
        public PSLivyStatementOutput(LivyStatementOutput output)
        {
            this.Status = output?.Status;
            this.ExecutionCount = output?.ExecutionCount;
            //this.Data = LivyStatementOutputParser.Parse(output?.Data);
            this.Data = output?.Data;
            this.Ename = output?.Ename;
            this.Evalue = output?.Evalue;
            this.Traceback = output?.Traceback;
        }

        /// <summary>
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// </summary>
        public int? ExecutionCount { get; set; }

        /// <summary>
        /// </summary>
        public object Data { get; set; }

        /// <summary>
        /// </summary>
        public string Ename { get; set; }

        /// <summary>
        /// </summary>
        public string Evalue { get; set; }

        /// <summary>
        /// </summary>
        public IList<string> Traceback { get; set; }
    }
}