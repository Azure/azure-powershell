namespace Microsoft.Azure.Commands.Network.ApplicationGateway.Model
{
    using System;
    using System.IO;
    using Microsoft.WindowsAzure.Commands.Utilities.Common;
    
    public class ApplicationGatewayConfigContext : ManagementOperationContext
    {
        public string XMLConfiguration { get; set; }
        public ApplicationGatewayConfiguration Config { get; set; }

        public void ExportToFile(string filePath)
        {
            if (string.IsNullOrEmpty(filePath))
            {
                throw new ArgumentNullException("filePath", "File path can not be null.");
            }

            if (!Directory.Exists(Path.GetDirectoryName(filePath)))
            {
                throw new ArgumentException("File path does not exist.", "filePath");
            }
            
            using (StreamWriter outfile = new StreamWriter(filePath))
            {
                outfile.Write(this.XMLConfiguration);
            }
        }
    }
}
