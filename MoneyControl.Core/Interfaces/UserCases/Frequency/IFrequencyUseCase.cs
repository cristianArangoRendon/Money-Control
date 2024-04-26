using MoneyControl.Core.DTOs.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyControl.Core.Interfaces.UserCases.Frequency
{
    public interface IFrequencyUseCase
    {
        Task<ResponseDTO> GetFrequencys();
    }
}
