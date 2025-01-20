using dishwasher.engine;

namespace dishwasher.api.Models
{
    public class ProgramModel : WashingProgram, IModel<Guid>
    {
        public Guid Id { get; set; }
    }
}
