namespace Example.Domain
{
    public class Developer : Entity<DeveloperId>
    {
        public string Name { get; set; }
        public DeveloperStatus Status { get; set; }

    }

    public abstract class Entity<T1>
    {
        public T1 Id { get; set; }
    }
}