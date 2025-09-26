﻿using Common.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.SiteEntities.Repository
{
    public interface IBannerRepository:IBaseRepository<Banner>
    {
        void Delete(Banner banner);
    }
}
