namespace dishwasher.api.Models
{
    public interface IModel<T>
    {
        T Id { get; set; }
    }
}
