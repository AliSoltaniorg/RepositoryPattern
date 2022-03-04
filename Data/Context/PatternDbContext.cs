using Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Context
{
    public class PatternDbContext : DbContext, IPatternDbContext
    {

    }
}
