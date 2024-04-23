﻿using MoneyControl.Core.DTOs.Response;
using MoneyControl.Core.DTOs.User;

namespace MoneyControl.Core.Interfaces.Repository
{
    public interface IUserRepository
    {
        public Task<ResponseDTO> CheckIn(CheckInDTO checkIn);
    }
}
