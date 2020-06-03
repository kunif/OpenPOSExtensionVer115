# POS for.NET 1.14.1 に付加する UnifiedPOS version 1.15 の追加機能

これは UnifiedPOS version 1.15 の追加機能を POS for.NET 1.14.1 に付加するためのインタフェースや定義をサポートした拡張DLLです。

- ElectronicValueReader/WriterデバイスへCATデバイス機能を追加  
- ElectronicValueReader/WriterデバイスのServiceTypeプロパティへEVRW_ST_CATを追加  
- FiscalPrinterデバイスのCountryCode, DateTypeプロパティへ値を追加  


## 開発/実行環境

このプログラムやサービスオブジェクト、アプリケーションの開発および実行には以下が必要です。

- Visual Studio 2019またはVisual Studio Community 2019 version 16.6.1 (開発のみ)  
- .NET framework 4.0以降  
- Microsoft Point of Service for .NET v1.14.1 (POS for.NET) : https://www.microsoft.com/en-us/download/details.aspx?id=55758  


## インストール/アンインストール

以下のバッチファイルを用意しているので、それを管理者として実行してください。

- RegisterExt115.bat
- UnregisterExt115.bat


## インタフェース

インタフェース名や既存のEnum,プロパティ名に、識別のために"115"を付加しています。

- Enum定義
  - FiscalCountryCode115 : Germany追加
  - FiscalDateType115 : TicketStart,TicketEnd追加
  - ServiceType115 : Cat追加

- インタフェース定義
  - IElectronicValueRW115
    - ServiceType115プロパティ追加
    - CAT関連プロパティ,メソッド追加
  - IFiscalPrinter115
    - CountryCode115,DateType115プロパティ追加


## 使用例

- サービスオブジェクト開発時、およびそれを利用するアプリケーション開発時

  - プロジェクトの参照に"OpenPOS.Extension.Ver115"を追加する(以下にある)
    "C:\\Windows\\Microsoft.NET\\assembly\\GAC_MSIL\\OpenPOS.Extension.Ver115\\v4.0_1.15.0.0__ad2c9a67c3439201\\OpenPOS.Extension.Ver115.dll"
  - ソースコードに"using OpenPOS.Extension;"を追加する

- サービスオブジェクト実装時のクラス定義

  - OPOSを呼び出す場合はソースコードに"using OpenPOS.Devices;"を追加する
  - サービスオブジェクトを開発する際は、該当デバイスクラスを継承すると共に、version 1.15用のインタフェースも追加する

コード例:

    [ServiceObject(DeviceType.ElectronicValueRW, "OpenPOS 1.15 ElectronicValueRW", "OPOS ElectronicValueRW CCO Interop", 1, 15)]
    public class OpenPOSElectronicValueRW : ElectronicValueRW, IElectronicValueRW115, ILegacyControlObject, IDisposable
    {
        ...
    }

- アプリケーションでの使用例

  - OpenPOS.Extension.Ver115のインターフェースを含んでいるかを確認してから UnifoedPOS 1.15 のメソッドを呼び出す  

コード例:


    // オブジェクトが ElectronicValueRW evrwObj1 で宣言されている
    
    try
    {
        if (evrwObj1 is IElectronicValueRW115)
        {
            if (((IElectronicValueRW115) evrwObj1).ServiceType115 == ServiceType115.Cat)
            {
                int iSequenceNumber = 9999;
                decimal dAmount = 5000;
                decimal dTaxOthers = 500;
                int iTimeout = 300000;
                try
                {
                    ((IElectronicValueRW115) evrwObj1).AuthorizeSales(iSequenceNumber, dAmount, dTaxOthers, iTimeout);
                }
                catch(UPOSException ue)
                {
                }
            }
        }
    }
    catch(Exception ae)
    {
    }


## 既知の課題   

既知の課題は以下になります。

- 実際のサービスオブジェクト、OPOSやデバイスを使った動作確認は行っていません。  

## ライセンス

[zlib License](./LICENSE) の下でライセンスされています。
