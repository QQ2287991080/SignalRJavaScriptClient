using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRForJavaScript
{
    public class SignalRDbContext:DbContext
    {
        public SignalRDbContext(DbContextOptions<SignalRDbContext> options):base(options)
        {
                
        }
    }
}
