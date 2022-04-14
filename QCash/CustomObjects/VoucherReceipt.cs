using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CustomObjects
{
  public  class VoucherReceipt
    {
      public String VoucherTypeName { get; set; }
      public String VoucherNo { get; set; }
      public String VoucherDate { get; set; }
      public String DebitAccountName { get; set; }
      public String CreditAccountName { get; set; }
      public String Amount { get; set; }
      public String AmountInWords { get; set; }
      public String Narration { get; set; }

      public VoucherReceipt() { }


    }
}
