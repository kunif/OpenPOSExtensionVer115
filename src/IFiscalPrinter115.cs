/* IFiscalPrinter115.cs UnifiedPOS FiscalPrinter Extension Interface for POS for.NET 1.14.1
  version 1.15.0.0 June 2nd, 2020

  Copyright (C) 2020 Kunio Fukuchi

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
    using System;

    [Flags]
    public enum FiscalCountryCodes115
    {
        Brazil = 1,
        Greece = 2,
        Hungary = 4,
        Italy = 8,
        Poland = 0x10,
        Turkey = 0x20,
        Russia = 0x40,
        Bulgaria = 0x80,
        Romania = 0x100,
        CzechRepublic = 0x200,
        Ukraine = 0x400,
        Sweden = 0x800,
        Germany = 0x1000,
        Other = 0x40000000
    }

    public enum FiscalDateType115
    {
        Configuration = 1,
        EndOfDay,
        Reset,
        RealTimeClock,
        VatChange,
        Start,
        TicketStart,
        TicketEnd
    }

    public interface IFiscalPrinter115
    {
        FiscalCountryCodes115 CountryCode115 { get; }
        FiscalDateType115 DateType115 { get; set; }
    }
}