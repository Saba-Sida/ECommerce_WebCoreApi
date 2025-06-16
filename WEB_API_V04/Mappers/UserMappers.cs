using WEB_API_V04.DTOs.User;
using WEB_API_V04.Models;
using WEB_API_V04.Services;

namespace WEB_API_V04.Mappers
{
    public static class UserMappers
    {
        public static UserGetCompleteWithReferenceObjectsDto ToUserGetCompleteWithReferenceObjectsDto(this User userModel)
        {
            return new UserGetCompleteWithReferenceObjectsDto
            {
                UserId = userModel.UserId,
                UserName = userModel.UserName,
                EMail = userModel.EMail,
                PhoneNumber = userModel.PhoneNumber,
                Gender = userModel.Gender,
                ProfileImageUrl = userModel.ProfileImageUrl,
                Products = userModel.Products.Select(pr => pr.ToProductGetWhenUserPropertyDto()).ToList()
            };
        }

        public static UserGetWhenInProductDto ToUserGetWhenInProductDto(this User userModel)
        {
            return new UserGetWhenInProductDto
            {
                UserId = userModel.UserId,
                UserName = userModel.UserName,
                EMail = userModel.EMail,
                PhoneNumber = userModel.PhoneNumber,
                Gender = userModel.Gender,
                ProfileImageUrl = userModel.ProfileImageUrl
            };
        }

        public static User FromCreateDtoToUserModel(this UserCreateDto userCreateDto)
        {
            return new User
            {
                UserName = userCreateDto.UserName,
                EMail = userCreateDto.EMail,
                PhoneNumber = userCreateDto.PhoneNumber,
                Gender = userCreateDto.Gender,
                ProfileImageUrl = userCreateDto.ProfileImageUrl,
                PasswordHash = PasswordService.HashPassword(userCreateDto.Password),
                Products = new()
            };
        }

        public static User FromUpdateDtoToUserModel(this UserUpdateDto userUpdateDto)
        {
            return new User
            {
                UserName = userUpdateDto.UserName,
                EMail = userUpdateDto.EMail,
                PhoneNumber = userUpdateDto.PhoneNumber,
                Gender = userUpdateDto.Gender,
                ProfileImageUrl = userUpdateDto.ProfileImageUrl,
                PasswordHash = PasswordService.HashPassword(userUpdateDto.Password)
            };
        }
    }
}
