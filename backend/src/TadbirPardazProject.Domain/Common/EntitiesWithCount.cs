namespace TadbirPardazProject.Domain.Common
{
    public class EntitiesWithCount<TType>
    {
        public int Count { get; set; }
        public List<TType> Entities { get; set; }
    }
}
