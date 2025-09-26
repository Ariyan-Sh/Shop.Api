using Common.Application;
using Shop.Domain.CommentAgg;
using Shop.Domain.ProductAgg;
using Shop.Domain.UserAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Shop.Application.Comments.Create
{
    public class CreateCommentCommandHandler : IBaseCommandHandler<CreateCommentCommand>
    {
        private readonly ICommentRepository _repository;
        public async Task<OperationResult> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
        {
            var comment = new Comment(request.userId,request.productId,request.text);
            _repository.Add(comment);
            await _repository.Save();
            return OperationResult.Success();
        }
    }
}
