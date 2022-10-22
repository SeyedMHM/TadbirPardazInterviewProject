namespace TadbirPardazProject.Domain.Common
{
    public interface IEntity
    {
    }
    public abstract class BaseEntity<TKeyType> : IEntity
    {
        public TKeyType Id { get; set; }
    }
    public abstract class BaseEntity : BaseEntity<int>
    {
    }
}
