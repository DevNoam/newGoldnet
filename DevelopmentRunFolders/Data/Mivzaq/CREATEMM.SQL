/*

Answer: :PRIV:ANSWER.DB
AuxTables: True
RunMode: Default
Alias: WORK
LiveAnswer: FALSE

*/

//
// Defining global domains
//
Create Domain TBankCode As Integer;
Create Domain TBranchCode As Integer;
Create Domain TAccountCode As Integer;
Create Domain TAdditionCode As Integer;
Create Domain TCoinCode As Integer;
Create Domain TCustomerCode As Integer;
Create Domain TCompanyCode As Integer;
Create Domain TAcCode As Integer;
Create Domain TAccountType As Integer;
Create Domain TAccountRawNo As Integer;
Create Domain TUseInExport As Boolean;

Create Domain TBankName As NChar(50);
Create Domain TTokenOfs As Integer;
Create Domain TTokenLen As Integer;

Create Domain TCompanyCode As Integer;
Create Domain TCompanyName As NChar(80);

Create Domain TCustomerCode As Integer;
Create Domain TCustomerName As NChar(35);
Create Domain TBankCustomerCode As NChar(12);Create Domain TBankCode As Integer;


Create Table Accounts (
  BankCode TBankCode,
  BranchCode TBranchCode,
  AccountCode TAccountCode,
  AdditionCode TAdditionCode,
  CoinCode TCoinCode,
  CustomerCode TCustomerCode,
  CompanyCode TCompanyCode,
  AcCode TAcCode,
  Account Type TAccountType,
  Account Number (Raw) TAccountRawNo,
  UseInExport  TUseInExport,
  Primary Key (BankCode, BranchCode, AccountCode, AdditionCode, CoinCode),
  Foreign Key (RawAccount - Account Number (Raw)
  Foreign Key (SystemAccountCode - AcCode )
  );

Create Table Banks (
  BankCode TBankCode,
  Name TBankName,
  BranchStart TTokenOfs
  BranchLength TTokenLen
  AccountStart TTokenOfs
  AccountLength TTokenLen
  OtherStart TTokenOfs
  OtherLength TTokenLen
  UseInExport  TUseInExport,
  Primary Key (BankCode)
  );

Create Table Company (
  CompanyCode TCompanyCode
  CompanyName TCompanyName
  Primary Key (CompanyCode),
  );

Create Table Customer (
  CustomerCode TCustomerCode
  Name TCustomerName
  BankCustomerCode TBankCustomerCode
  BankCode TBankCode
  UseInExport TUseInExport
  Primary Key (TCustomerCode),
  Foreign Key (KeyFields - TCustomerName, TBankCustomerCode, TBankCode)
  );


Create Domain TBundleCode As Integer;
Create Domain TMsgNumber As Integer;
Create Domain FTartNumber As Integer;
Create Domain TPaperNumber As Integer;
Create Domain TBalanceSum As Integer;
Create Domain TIsDebit As Integer;
Create Domain TBalanceSum As Integer;
Create Domain TIsDebit As Boolean;
Create Domain TWasExported As Boolean;

Create Table MsgAcc (
  BundleCode TBundleCode,
  MessageNumber TMsgNumber,
  AcCode TAcCode,
  PartNumber TPartNumber,
  PaperNumber TPaperNumber,
  BalanceBefore TBalanceSum,
  BalanceBeforeDebit TIsDebit,
  BalanceAfter TBalanceSum,
  BalanceAfterDebit TIsDebit,
  WasExported TWasExported
  Primary Key (BundleCode)
  Foreign Key (ByMsgAndAccount - MessageNumber, AcCode)
  );

Create Domain TTransaction as NChar(16);
Create Domain TIndex as Integer;
Create Domain TActionDetails as NChar(35);
Create Domain TDate as Date;

Create Table MsgLines (
  Bundlecode TBundleCode
  LineNumber TIndex
  Transaction TTransaction
  OtherSystems TIndex
  ActionDetails TActionDetails
  ActionSum TBalanceSum
  ActionSumDebit TIsDebit,
  BalanceAfter TBalanceSum,
  BalanceAfterDebit TIsDebit,
  ValueDate TDate,
  ProcessDate TDate,
  Date TDate,
  Transaction2 TTransaction
  Primary Key (BundleCode, LineNumber),
  Foreign Key (ByBundle - BundleCode),
  );

Create Domain TReportType as NChar(3);

Create Table MsgHdr (
  CustomerCode TCustomerCode,
  Transaction TTransaction,
  PrepareDate TDate,
  PrepareTime TDate,
  ReportType TReportType,
  MessageNumber TIndex,
  WasExported TWasExported,
  Primary Key (CustomerCode, Transaction, PrepareDatee, PrepareTime),
  Foreign Key (ByMsqCode - MessageNumber)
  );
