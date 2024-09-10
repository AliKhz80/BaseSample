using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;


namespace Infrustructure
{
    public class BaseProjectDBContext : DbContext
    {
    
        public BaseProjectDBContext(DbContextOptions<BaseProjectDBContext> dbContextOptions) : base(dbContextOptions)
        {

        }

        


        public DbSet<SampleModel> SampleModels { get; set; }

       

    }





}
