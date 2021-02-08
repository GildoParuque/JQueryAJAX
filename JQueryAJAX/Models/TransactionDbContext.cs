using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace JQueryAJAX.Models
{
    public class TransactionDbContext :  DbContext 
    {
       public TransactionDbContext(DbContextOptions<TransactionDbContext> options): base(options) 
        {
        }

        public DbSet<TransationModel> Transations { get; set; }
    }
}
