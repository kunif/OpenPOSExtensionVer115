/* IElectronicValueRW115.cs UnifiedPOS ElectronicValueRW Extension Interface for POS for.NET 1.14.1
  version 1.15.0.0 June 2nd, 2020
  version 1.15.0.0 Feb. 19th, 2022

  Copyright (C) 2020-2022 Kunio Fukuchi

  This software is provided 'as-is', without any express or implied
  warranty.  In no event will the authors be held liable for any damages
  arising from the use of this software.

  Permission is granted to anyone to use this software for any purpose,
  including commercial applications, and to alter it and redistribute it
  freely, subject to the following restrictions:

  1. The origin of this software must not be misrepresented; you must not
     claim that you wrote the original software. If you use this software
     in a product, an acknowledgment in the product documentation would be
     appreciated but is not required.
  2. Altered source versions must be plainly marked as such, and must not be
     misrepresented as being the original software.
  3. This notice may not be removed or altered from any source distribution.

  Kunio Fukuchi

*/
namespace OpenPOS.Extension
{
    using Microsoft.PointOfService;

    public enum ServiceType115
    {
        Unspecified,
        ElectronicMoney,
        Point,
        Voucher,
        Membership,
        Cat
    }

    public static class IElectronicValueRW115Constants
    {
        public const int TransitionConfirmSearchTable = 24;
        public const int TransitionConfirmPaymentCondition = 25;
        public const int TransitionConfirmAuthorize = 26;
        public const int TransitionNotifyCheckCard = 27;
        public const int TransitionNotifySelectPaymentCondition = 28;
    }

    public interface IElectronicValueRW115
    {
        bool CapAdditionalSecurityInformation { get; }
        bool CapAuthorizeCompletion { get; }
        bool CapAuthorizePreSales { get; }
        bool CapAuthorizeRefund { get; }
        bool CapAuthorizeVoid { get; }
        bool CapAuthorizeVoidPreSales { get; }
        bool CapCashDeposit { get; }
        bool CapCenterResultCode { get; }
        bool CapCheckCard { get; }
        CatLogs CapDailyLog { get; }
        bool CapInstallments { get; }
        bool CapPaymentDetail { get; }
        bool CapTaxOthers { get; }
        bool CapTransactionNumber { get; }
        string CardCompanyId { get; }
        string CenterResultCode { get; }
        string DailyLog { get; }
        PaymentCondition PaymentCondition { get; }
        string PaymentDetail { get; }
        PaymentMedia PaymentMedia { get; set; }
        ServiceType115 ServiceType115 { get; }
        string SlipNumber { get; }
        string TransactionNumber { get; }
        CreditTransactionType TransactionType { get; }

        void AccessDailyLog(int sequenceNumber, CatLogs type, int timeout);

        void AuthorizeCompletion(int sequenceNumber, decimal amount, decimal taxOthers, int timeout);

        void AuthorizePreSales(int sequenceNumber, decimal amount, decimal taxOthers, int timeout);

        void AuthorizeRefund(int sequenceNumber, decimal amount, decimal taxOthers, int timeout);

        void AuthorizeSales(int sequenceNumber, decimal amount, decimal taxOthers, int timeout);

        void AuthorizeVoid(int sequenceNumber, decimal amount, decimal taxOthers, int timeout);

        void AuthorizeVoidPreSales(int sequenceNumber, decimal amount, decimal taxOthers, int timeout);

        void CheckCard(int sequenceNumber, int timeout);

        void CashDeposit(int sequenceNumber, decimal amount, int timeout);
    }
}