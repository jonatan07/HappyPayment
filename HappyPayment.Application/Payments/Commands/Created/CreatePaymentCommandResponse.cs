using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyPayment.Application.Payments.Commands.Created
{
    public class CreatePaymentCommandResponse
    {
        public CreatePaymentCommandResponse(bool isSuccess)
        {
            IsSuccess = isSuccess;
        }

        public bool IsSuccess { get;}
    }
}
