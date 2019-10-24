using System;
using System.Collections.Generic;
using System.Text;

namespace ATM_1
{
    public interface IDecoder
    {
    	void DecodeData(RawTransponderDataEventArgs e);
    }
}
