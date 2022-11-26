using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_LABA
{
    public partial class FormPositionWatcher
    {
        private readonly Form _mainForm;
        public event Action<Point> FormMoved;

        public FormPositionWatcher(Form mainForm)
        {
            _mainForm = mainForm;
            _mainForm.Move += _mainForm_Move;
        }

        private void _mainForm_Move(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
     
    }
}