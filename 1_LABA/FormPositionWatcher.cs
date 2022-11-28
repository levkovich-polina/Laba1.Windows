using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using _1_LABA.Forms;

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
            int x;
            int y;
            x = _mainForm.Location.X + _mainForm.Width / 2;
            y = _mainForm.Location.Y;
            var Point = new Point(x, y);
            FormMoved.Invoke(Point);
        }
    }
}