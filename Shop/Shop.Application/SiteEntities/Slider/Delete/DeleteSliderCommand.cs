using Common.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.SiteEntities.Slider.Delete
{
    public record DeleteSliderCommand(long Id):IBaseCommand;
}
