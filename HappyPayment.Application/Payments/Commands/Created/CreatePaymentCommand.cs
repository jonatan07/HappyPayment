using HappyPayment.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyPayment.Application.Payments.Commands.Created
{
    public class CreatePaymentCommand:IRequest <Response<CreatePaymentCommandResponse>>
    {

    }
}
