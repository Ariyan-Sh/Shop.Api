using Common.Application;
using Common.Application.FileUtil.Interfaces;
using Microsoft.AspNetCore.Http;
using Shop.Application._Utilities;
using Shop.Domain.SiteEntities.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.SiteEntities.Slider.Delete
{
    internal class DeleteSliderCommandHandler : IBaseCommandHandler<DeleteSliderCommand>
    {
        private readonly ISliderRepository _repository;
        private readonly IFileService _localFileService;

        public DeleteSliderCommandHandler(ISliderRepository repository, IFileService localFileService)
        {
            _repository = repository;
            _localFileService = localFileService;
        }

        public async Task<OperationResult> Handle(DeleteSliderCommand request, CancellationToken cancellationToken)
        {
            var slider = await _repository.GetTracking(request.Id);
            if (slider == null)
            {
                return OperationResult.NotFound();
            }
            _repository.Delete(slider);
            await _repository.Save();
            _localFileService.DeleteFile(Directories.SliderImages, slider.ImageName);
            return OperationResult.Success();
        }
    }
}
