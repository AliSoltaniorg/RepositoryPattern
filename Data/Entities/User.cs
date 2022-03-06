namespace Data.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int Age { get; set; }

        public override string ToString()
        {
            return $"Id = {Id} Name = {Name} Age = {Age}";
        }
    }

    public class Comment
    {
        public int Id { get; set; }

        public string Subject { get; set; }

        public string Description { get; set; }
    }
}
