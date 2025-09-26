using Common.Application;
using Shop.Domain.CommentAgg.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Comments.ChangeStatus
{
    public record ChangeStatusCommand(long id, CommentStatus Status):IBaseCommand;
}
