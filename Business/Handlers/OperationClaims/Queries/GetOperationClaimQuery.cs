﻿using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Business.Handlers.OperationClaims.Queries
{
  public class GetOperationClaimQuery : IRequest<IDataResult<OperationClaim>>
  {
    public int Id { get; set; }
    public class GetOperationClaimQueryHandler : IRequestHandler<GetOperationClaimQuery, IDataResult<OperationClaim>>
    {
      private readonly IOperationClaimDal _operationClaimDal;

      public GetOperationClaimQueryHandler(IOperationClaimDal operationClaimDal)
      {
        _operationClaimDal = operationClaimDal;
      }

      public async Task<IDataResult<OperationClaim>> Handle(GetOperationClaimQuery request, CancellationToken cancellationToken)
      {
        return new SuccessDataResult<OperationClaim>(await _operationClaimDal.GetAsync(x => x.Id == request.Id));
      }
    }
  }
}
