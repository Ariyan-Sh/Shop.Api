using Common.AspNetCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.Comments.ChangeStatus;
using Shop.Application.Comments.Create;
using Shop.Application.Comments.Edit;
using Shop.Presentation.Facade.Comments;
using Shop.Query.Comments.DTOs;
using Shop.Domain.RoleAgg.Enums;
using Shop.Query.Comments.GetByFilter;
using Shop.Query.Comments.GetById;
using Shop.Api.Infrastructure.Security;
using Microsoft.AspNetCore.Authorization;
using Shop.Application.Comments.Delete;

namespace Shop.Api.Controllers
{
    public class CommentController : ApiController
    {
        private readonly ICommentFacade _commentFacade;

        public CommentController(ICommentFacade commentFacade)
        {
            _commentFacade = commentFacade;
        }
        [PermissionChecker(Permission.Comment_Management)]
        [HttpGet]
        public async Task<ApiResult<CommentFilterResult>> GetCommentByFilter([FromQuery]CommentFilterParams filterParams)
        {
            var result = await _commentFacade.GetCommentsByFilter(filterParams);
            return QueryResult(result);
        }
        [PermissionChecker(Permission.Comment_Management)]
        [HttpGet("{commentId}")]
        public async Task<ApiResult<CommentDto?>> GetCommentById(long commentId)
        {
            var result = await _commentFacade.GetCommentById(commentId);
            return QueryResult(result);
        }
        [HttpPost]
        [Authorize]
        public async Task<ApiResult> CreateComment(CreateCommentCommand command)
        {
            var comment = await _commentFacade.CreateComment(command);
            return CommandResult(comment);
        }
        [HttpPut]
        [Authorize]
        public async Task<ApiResult> EditComment(EditCommentCommand command)
        {
            var comment = await _commentFacade.EditComment(command);
            return CommandResult(comment);
        }
        [HttpDelete("{commentId}")]
        [Authorize]
        public async Task<ApiResult> DeleteComment(long commentId)
        {
            var comment = await _commentFacade.DeleteComment(new DeleteCommentCommand(commentId,User.GetUserId()));
            return CommandResult(comment);
        }
        [HttpPut("changeStatus")]
        [PermissionChecker(Permission.Comment_Management)]
        public async Task<ApiResult> ChangeCommentStatus(ChangeStatusCommand command)
        {
            var comment = await _commentFacade.ChangeStatus(command);
            return CommandResult(comment);
        }
    }
}
