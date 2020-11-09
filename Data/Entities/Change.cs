namespace Project1.Data.Entities
{
    public class Change: BaseEntity
    {
        public string Property { get; set; }
        public string Before { get; set; }
        public string After { get; set; }
        public int UserId { get; set; }
    }
}