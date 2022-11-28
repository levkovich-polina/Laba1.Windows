using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _1_LABA.Forms;

namespace _1_LABA
{
    public partial class Vault
    {
        public event Action Unlocked;
        private string _password;

        public Vault(string password)
        {
            var vault = new Vault("123412");
            _password = password;
        }

        private int _correctSymbolCount = 0;

        public void Enter(char symbol)
        {
            if (_password[_correctSymbolCount] == symbol)
            {
                _correctSymbolCount++;
            }
            else if (_password[0] == symbol)
            {
                _correctSymbolCount = 1;
            }
            else
            {
                _correctSymbolCount = 0;
            }
        }
    }
}