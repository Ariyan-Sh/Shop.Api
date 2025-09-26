using Common.Application;
using Common.Domain.ValueObjects;
using Shop.Domain.CategoryAgg.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Categories.AddChild
{
    public record AddChildCategoryCommand(long ParentId, string title, string slug, SeoData seoData, ICategoryDomainService domainservice) :IBaseCommand<long>;
    
}
