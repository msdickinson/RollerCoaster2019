namespace RollerCoaster2019.Logic.Builder.DataTypes
{
    public class BuildActionDescriptor
    {
        public bool Successful { get; set; } = false;
        public TaskResults BuildActionResult { get; set; } = TaskResults.NotSet;
        public TaskResults AutoCorrectResult { get; set; } = TaskResults.NotSet;
        public bool FinshedCoaster { get; set; } = false;
        public bool AutoLooped { get; set; } = false;
        public int TracksAdded { get; set; } = 0;
        public int TracksRemoved { get; set; } = 0;
    }
}
