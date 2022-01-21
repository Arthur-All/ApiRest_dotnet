using System.ComponentModel.DataAnnotations.Schema;

namespace ApiRest.Model
{
    [Table("person")] //Coloquei o Table e Column, pq eu to usando MySQL como BD ou seja base linux ou seja tem que estar como esta no BD...
    public class Person
    {
        [Column("id")]
        public long Id { get; set; }

        [Column("first_name")]
        public string FirstName { get; set; }

        [Column("last_name")]
        public string LastName { get; set; }

        [Column("address")]
        public string Address { get; set; }
        [Column("email")]
        public string Email { get; set; }
    }
}
