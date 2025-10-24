using Common.Application;
using Common.Domain.ValueObjects;
using Shop.Domain.CategoryAgg.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Categories.Edit
{
    public record EditCategoryCommand(long Id,string Title, string Slug, SeoData SeoData) :IBaseCommand;
}
