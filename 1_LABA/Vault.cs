using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_LABA
{
    public partial class Vault
    {
        private readonly AuthenticationManager _authenticationManager;
        public event Action Unlocked;

        public Vault(string password)
        {
            var vault = new Vault("123412");
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