using Common.Application;
using Shop.Domain.RoleAgg;
using Shop.Domain.RoleAgg.Enums;
using Shop.Domain.RoleAgg.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Roles.Edit
{
    internal class EditRoleCommandHandler:IBaseCommandHandler<EditRoleCommand>
    {
        private readonly IRoleRepository _repository;
        public EditRoleCommandHandler(IRoleRepository repository)
        {
            _repository = repository;
        }
        public async Task<OperationResult> Handle(EditRoleCommand request, CancellationToken cancellationToken)
        {
            var role = await _repository.GetTracking(request.Id);
            if (role == null)
            {
                return OperationResult.NotFound();
            }
            role.Edit(request.title);
            var permission = new List<RolePermission>();
            request.Permissions.ForEach(f =>
            {
                permission.Add(new RolePermission(f));
            });
            role.SetPermissions(permission);
            await _repository.Save();
            return OperationResult.Success();
            
        }
    }
}
