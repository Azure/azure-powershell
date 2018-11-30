namespace Microsoft.Azure.Commands.DataMigration.Models.MongoDb
{
    public class MongoDbCollectionSetting 
    {
        public string Name { get; set; }

        public Microsoft.Azure.Management.DataMigration.Models.MongoDbCollectionSettings Setting { get; set; }
    }
}
