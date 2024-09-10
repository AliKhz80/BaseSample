using Domain.Interfaces;
using Domain.Interfaces.BusinessIRepositories;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrustructure.BusinessRepositories
{
    public class SampleModelRepository(
    BaseProjectDBContext dbContext,
    ICurrentUser currentUser
    ) : Repository<SampleModel>(dbContext, currentUser), ISampleModelRepository
    {





    }
}
