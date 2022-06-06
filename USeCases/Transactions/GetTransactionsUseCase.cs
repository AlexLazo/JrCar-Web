using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.UseCaseInterfaces;
using UseCases.DataSourcePluginInterfaces;
using CoreBusiness;

namespace UseCases.Transactions
{
    public class GetTransactionsUseCase : IGetTransactionsUseCase
    {
        private readonly ITransactionRepository transactionRepository;

        public GetTransactionsUseCase(ITransactionRepository transactionRepository)
        {
            this.transactionRepository = transactionRepository;
        }

        public IEnumerable<Transaction> Execute(
            string cashierName,
            DateTime startDate,
            DateTime endDate
            )
        {
            return transactionRepository.Search(cashierName, startDate, endDate);
        }
    }
}
