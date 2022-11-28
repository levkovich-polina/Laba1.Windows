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
        private string _password;
        private int _correctSymbolCount = 0;
        public event Action Unlocked;

        public Vault(string password)
        {
            _password = password;
        }

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

            if (_correctSymbolCount == _password.Length)
            {
                _correctSymbolCount = 0;
                Unlocked.Invoke();
            }
        }
    }
}