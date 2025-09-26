using AutoMapper;
using Common.AspNetCore;
using Common.Domain.ValueObjects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop.Api.ViewModels.Users;
using Shop.Application.Users.AddAddress;
using Shop.Application.Users.DeleteAddress;
using Shop.Application.Users.EditAddress;
using Shop.Application.Users.SetActiveAddress;
using Shop.Domain.UserAgg;
using Shop.Presentation.Facade.Users.Addresses;
using Shop.Query.Users.DTOs;


namespace Shop.Api.Controllers
{
    [Authorize]
    public class UserAddressController : ApiController
    {
        private readonly IUserAddressFacade _userAddressFacade;
        private readonly IMapper _mapper;

        public UserAddressController(IUserAddressFacade userAddressFacade, IMapper mapper)
        {
            _userAddressFacade = userAddressFacade;
            _mapper = mapper;
        }
        [HttpGet("{id}")]
        public async Task<ApiResult<AddressDto?>> GetById(long id)
        {
            var result = await _userAddressFacade.GetById(id);
            return QueryResult(result);
        }
        [HttpGet]
        public async Task<ApiResult<List<AddressDto>>> GetList(long id)
        {
            var result = await _userAddressFacade.GetList(User.GetUserId());
            return QueryResult(result);
        }
        [HttpPost]
        public async Task<ApiResult> AddAddress(AddUserAddressViewModel viewModel)
        {
            var command = new AddUserAddressCommand(User.GetUserId(),viewModel.Shire,
                viewModel.City,viewModel.PostalCode,viewModel.PostalAddress,
                new PhoneNumber(viewModel.PhoneNumber),viewModel.Name,viewModel.Family,
                viewModel.NationalCode);

            var result = await _userAddressFacade.AddAddress(command);
            return CommandResult(result);
        }
        [HttpPut]
        public async Task<ApiResult> Edit(EditUserAddressViewModel viewModel)
        {
            var command = new EditUserAddresssCommand(User.GetUserId(), viewModel.Shire,
                viewModel.City, viewModel.PostalCode, viewModel.PostalAddress,
                new PhoneNumber(viewModel.PhoneNumber), viewModel.Name, viewModel.Family,
                viewModel.NationalCode, viewModel.Id);

            command.UserId = User.GetUserId();
            var result = await _userAddressFacade.EditAddress(command);
            return CommandResult(result);
        }
        [HttpDelete("{addressId}")]
        public async Task<ApiResult> DeleteAddress(long addressId)
        {
            var result = await _userAddressFacade.DeleteAddress(new DeleteUserAddressCommand(User.GetUserId(),addressId));
            return CommandResult(result);
        }
        [HttpPut("SetActiveAddress/{addressId}")]
        public async Task<ApiResult> SetActiveAddress(long addressId)
        {
            var command = new SetActiveAddressCommand(User.GetUserId(),addressId);

            var result = await _userAddressFacade.SetActiveAddress(command);
            return CommandResult(result);
        }
    }
}
