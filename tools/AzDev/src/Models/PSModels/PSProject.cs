using AzDev.Models.Inventory;

namespace AzDev.Models.PSModels
{
    public class PSProject
    {
        public string Name { get; set; }
        public string Path { get; set; }
        public ProjectType Type { get; set; }
        public string TypeDeductionReason { get; set; }
        internal PSProject(Project p)
        {
            Name = p.Name;
            Path = p.Path;
            Type = p.Type;
            TypeDeductionReason = p.TypeDeductionReason;
        }
        internal PSProject() { }
        public override string ToString() => Name;
    }
}
