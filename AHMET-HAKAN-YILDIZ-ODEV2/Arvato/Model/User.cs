namespace Arvato.Model
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string TCNU { get; set; }
        public string Phone { get; set; }
        public string Mail { get; set; }
        public DateTime date { get; set; }
        public bool IsVerified { get; set; }
        public int BootcampId { get; set; } 
    }
}
