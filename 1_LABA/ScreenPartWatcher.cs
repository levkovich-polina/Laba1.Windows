using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_LABA
{
    public partial class ScreenPartWatcher
    {
        private readonly FormPositionWatcher _formPositionWatcher;
        public event Action<ScreenPart> ScreenPartChanged;

        public ScreenPartWatcher(FormPositionWatcher formPositionWatcher)
        {
            _formPositionWatcher = formPositionWatcher;
            _formPositionWatcher.FormMoved += _formPositionWatcher_FormMoved;
        }

        private void _formPositionWatcher_FormMoved(Point formPosition)
        {
            Size screenSize = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Size;
            int x0 = screenSize.Width / 2;
            int y0 = screenSize.Height / 2;

            int x1 = formPosition.X;
            int y1 = formPosition.Y;

            int x2 = x1 - x0;
            int y2 = y0 - y1;

            if (x2 > 0 && y2 > 0) //1 четверть
            {
                ScreenPartChanged.Invoke(ScreenPart.RightTop);
            }
            else if (x2 < 0 && y2 > 0) //2 четверть
            {
                ScreenPartChanged.Invoke(ScreenPart.LeftTop);
            }
            else if (x2 < 0 && y2 < 0) //3 четверть
            {
                ScreenPartChanged.Invoke(ScreenPart.LeftBottom);
            }
            else if (x2 > 0 && y2 < 0) //4 четверть
            {
                ScreenPartChanged.Invoke(ScreenPart.RightBottom);
            }
        }
    }
}