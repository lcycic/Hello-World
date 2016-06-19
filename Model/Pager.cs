using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShuaDanPingTai.Models
{
    public class Pager
    {
        private int _Count;
        public int Count
        {
            get
            {

                return _Count;
            }
            set
            {
                _Count = value;
            }
        }

        private int _PageSize;
        public int PageSize
        {
            get
            {
                if (_PageSize == 0)
                {
                    _PageSize = 10;
                }
                return _PageSize;
            }
            set
            {
                _PageSize = value;
            }
        }

        private int _PageIndex;
        public int PageIndex
        {
            get
            {
                if (_PageIndex == 0)
                {
                    _PageIndex = 1;
                }
                return _PageIndex;
            }
            set
            {
                _PageIndex = value;
            }
        }
    }
}
