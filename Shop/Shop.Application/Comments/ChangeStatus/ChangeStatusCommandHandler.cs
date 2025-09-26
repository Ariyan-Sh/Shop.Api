using Common.Application;
using Shop.Domain.CommentAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Comments.ChangeStatus
{
    public class ChangeStatusCommandHandler : IBaseCommandHandler<ChangeStatusCommand>
    {
        private readonly ICommentRepository _repository;

        public ChangeStatusCommandHandler(ICommentRepository repository)
        {
            _repository = repository;
        }

        public async Task<OperationResult> Handle(ChangeStatusCommand request, CancellationToken cancellationToken)
        {
            var status = await _repository.GetTracking(request.id);
            if (status == null)
            {
                return OperationResult.NotFound();
            }
            status.ChangeStatus(request.Status);
            await _repository.Save();
            return OperationResult.Success();
        }
    }
}
