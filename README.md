# Additional features of UnifiedPOS version 1.15 to be added to POS for.NET 1.14.1

This is an extended DLL that supports interfaces and definitions to add additional features of UnifiedPOS version 1.15 to POS for.NET 1.14.1.

- Added CAT device functions to ElectronicValueReader/Writer device.  
- Added EVRW_ST_CAT to the ServiceType property of ElectronicValueReader/Writer device.  
- Added values to CountryCode and DateType properties of FiscalPrinter device.  


## Development/Execuion environment

To develop and run this program, service object, or application, you need:

- Visual Studio 2019 or Visual Studio Community 2019  version 16.6.1 (development only)  
- .NET framework 4.0 or later  
- Microsoft Point of Service for .NET v1.14.1 (POS for.NET) : https://www.microsoft.com/en-us/download/details.aspx?id=55758  

## Install/Uninstall

Since the following batch files are prepared, please execute them as an administrator.

- RegisterExt115.bat
- UnregisterExt115.bat


## Interface

"115" is added to the interface name, existing Enum, and property name for identification.

- Enum definition
  - FiscalCountryCode115 : Germany added
  - FiscalDateType115 : TicketStart,TicketEnd added
  - ServiceType115 : Cat added

- interface definition
  - IElectronicValueRW115
    - ServiceType115 property added.
    - Added CAT related properties and methods.
  - IFiscalPrinter115
    - CountryCode115,DateType115 property added.


## Example of use

- When developing service objects and applications that use them.

  - Add "OpenPOS.Extension.Ver115" to the project reference (found below).
    "C:\\Windows\\Microsoft.NET\\assembly\\GAC_MSIL\\OpenPOS.Extension.Ver115\\v4.0_1.15.0.0__ad2c9a67c3439201\\OpenPOS.Extension.Ver115.dll"
  - Add "using OpenPOS.Extension;" to the source code.

- Class definition in service object implementation

  - When using OPOS, add "using OpenPOS.Devices;" to the source code.
  - When developing a service object, inherit the corresponding device class and add the interface for version 1.15.

Example code:


    [ServiceObject(DeviceType.ElectronicValueRW, "OpenPOS 1.15 ElectronicValueRW", "OPOS ElectronicValueRW CCO Interop", 1, 15)]
    public class OpenPOSElectronicValueRW : ElectronicValueRW, IElectronicValueRW115, ILegacyControlObject, IDisposable
    {
        ...
    }

- Application Examples

  - Check whether the interface of OpenPOS.Extension.Ver115 is included and then call the method of UnifoedPOS 1.15.  

Example code:


    // The object is declared in ElectronicValueRW evrwObj1
    
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


## Known issues

Currently known issues are as follows.

- The actual operation using the service object, OPOS and device has not been confirmed.  

## License

Licensed under the [zlib License](./LICENSE).
