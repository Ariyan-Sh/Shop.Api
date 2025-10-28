using Common.Application;
using Shop.Domain.RoleAgg.Repository;
using Shop.Domain.UserAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Roles.AssignRole
{
    internal class AssignRoleCommandHandler : IBaseCommandHandler<AssignRoleCommand>
    {
        private readonly  IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;

        public AssignRoleCommandHandler(IUserRepository userRepository, IRoleRepository roleRepository)
        {
            _userRepository = userRepository;
            _roleRepository = roleRepository;
        }

        public async Task<OperationResult> Handle(AssignRoleCommand request, CancellationToken cancellationToken)
        {
            // 1. بررسی وجود کاربر
            var user = await _userRepository.GetTracking(request.UserId);
            if (user == null)
            {
                return OperationResult.Error("کاربر یافت نشد.");
            }
            // 2. بررسی وجود نقش
            var role = await _roleRepository.GetTracking(request.RoleId);
            if (role == null)
            {
                return OperationResult.Error("نقش یافت نشد.");
            }
            // 3. بررسی تکراری نبودن نقش برای کاربر
            var exists = user.Roles.Any(r => r.RoleId == request.RoleId);
            if (exists)
            {
                return OperationResult.Error("این نقش قبلاً به کاربر اختصاص داده شده است.");
            }
            // 4. افزودن نقش به کاربر
            user.Roles.Add(new UserRole(request.RoleId));
            await _userRepository.Save();
            return OperationResult.Success("نقش با موفقیت به کاربر اختصاص داده شد.");
        }
    }
}
