using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.Runtime.Serialization;

namespace SharedLib
{
    [ServiceContract(
        CallbackContract =typeof(IStockCallback),
        SessionMode = SessionMode.Required
    )]
    public interface IStockService
    {
        [OperationContract(
            IsInitiating = true
        )]
        void Login();

        [OperationContract(
            IsTerminating = true
        )]
        void Logout(string sessionID = null);

        [OperationContract]
        void StartTickerMonitoring();

        [OperationContract]
        void StopTickerMonitoring();

        [OperationContract]
        Stock GetStockQuote(string symbol);

        [OperationContract]
        void AddNewStock(string symbol, decimal price);
    }

    public interface IStockCallback
    {
        [OperationContract(
            IsOneWay = true
        )]
        void StockUpdated(StockTransaction tx);
    }
}
