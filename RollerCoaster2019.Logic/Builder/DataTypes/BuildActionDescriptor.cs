namespace RollerCoaster2019.Logic.Builder.DataTypes
{
    public class BuildActionDescriptor
    {
        public bool Successful { get; set; } = true;
        public TaskResults BuildActionResult { get; set; } = TaskResults.NotSet;
        public TaskResults AutoCorrectResult { get; set; } = TaskResults.NotSet;
        public TaskResults FinshedCoaster { get; set; } = TaskResults.NotSet;
        public TaskResults AutoLooped { get; set; } = TaskResults.NotSet;
        public int TrackChangeCount { get; set; } = 0;
    }
}
