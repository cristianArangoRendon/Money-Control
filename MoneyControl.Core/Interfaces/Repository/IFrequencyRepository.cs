using MoneyControl.Core.DTOs.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyControl.Core.Interfaces.Repository
{
    public interface IFrequencyRepository
    {
        Task<ResponseDTO> GetFrequencys();
    }
}
