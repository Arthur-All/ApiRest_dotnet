using ApiRest.Model;
using Microsoft.EntityFrameworkCore;

namespace RestWithASPNET.Model.Context
{
    public class SqlContext : DbContext
    {
        public SqlContext()
        {

        }
        public SqlContext(DbContextOptions<SqlContext> options ) : base( options )
        {

        }

        public DbSet<Person> Persons { get; set; }

    }
}
